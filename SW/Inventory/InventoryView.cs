using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class InventoryView : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler, IPointerEnterHandler, IPointerExitHandler
{
    public Vector2 size = new Vector2(64f, 64f);
    public Item item;

    public Vector2 startpos;
    public Vector2 oldpos;
    public Image itemsprite;

    Slot slots;

    void Start()
    {
        GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, item.itemsize.y * size.y);
        GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, item.itemsize.x * size.x);

        foreach(RectTransform child in transform)
        {
            child.GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, item.itemsize.y * child.rect.height);
            child.GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, item.itemsize.x * child.rect.width);

            foreach(RectTransform contchild in child)
            {
                contchild.GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, item.itemsize.y * contchild.rect.height);
                contchild.GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, item.itemsize.x * contchild.rect.width);
                contchild.localPosition = new Vector2(child.localPosition.x + child.rect.width / 2, child.localPosition.y + child.rect.height / 2 * -1f);
            }
        }

        slots = FindObjectOfType<Slot>();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        //아이템설명창 구현
    }

    public void OnPointerExit(PointerEventData eventData)
    {

    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        oldpos = transform.GetComponent<RectTransform>().anchoredPosition;

        GetComponent<CanvasGroup>().blocksRaycasts = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = eventData.position;

        for (int i = 0; i < item.itemsize.y; i++)
            for (int j = 0; j < item.itemsize.x; j++)
                slots.grid[(int)startpos.x + j, (int)startpos.y + i] = 0;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if(EventSystem.current.IsPointerOverGameObject())
        {
            Vector2 finalpos = GetComponent<RectTransform>().anchoredPosition;

            Vector2 finalslot;
            finalslot.x = Mathf.Floor(finalpos.x / size.x);
            finalslot.y = Mathf.Floor(-finalpos.y / size.y);
            Debug.Log(finalslot);

            if(((int)(finalslot.x) + (int)(item.itemsize.x) - 1) < slots.gridsize.x && ((int)(finalslot.y) + (int)(item.itemsize.y)-1) < slots.gridsize.y && (int)(finalslot.y) >= 0 && (int)(finalslot.x) >= 0)
            {
                List<Vector2> newitempos = new List<Vector2>();
                bool fit = false;

                for (int y = 0; y < item.itemsize.y; y++)
                    for(int x = 0; x < item.itemsize.x; x++)
                    {
                        if(slots.grid[(int)finalslot.x + x, (int)finalslot.y + y] != 1)
                        {
                            Debug.Log("fit");
                            Vector2 pos;
                            pos.x = (int)finalslot.x + x;
                            pos.y = (int)finalslot.y + y;
                            newitempos.Add(pos);
                            fit = true;
                        }

                        else
                        {
                            fit = false;
                            Debug.Log("un fit");

                            this.transform.GetComponent<RectTransform>().anchoredPosition = oldpos;
                            x = (int)item.itemsize.x;
                            y = (int)item.itemsize.y;
                            newitempos.Clear();
                        }
                    }

                if(fit)
                {
                    for (int i = 0; i < item.itemsize.y; i++)
                        for (int j = 0; j < item.itemsize.x; j++)
                            slots.grid[(int)startpos.x + j, (int)startpos.y + i] = 0;

                    for (int i = 0; i < newitempos.Count; i++)
                        slots.grid[(int)newitempos[i].x, (int)newitempos[i].y] = 1;

                    this.startpos = newitempos[0];
                    transform.GetComponent<RectTransform>().anchoredPosition = new Vector2(newitempos[0].x * size.x, -newitempos[0].y * size.y);
                }

                else
                {
                    for (int i = 0; i < item.itemsize.y; i++)
                        for (int j = 0; j < item.itemsize.x; j++)
                            slots.grid[(int)startpos.x + j, (int)startpos.y + i] = 1;
                }
            }

            else
            {
                this.transform.GetComponent<RectTransform>().anchoredPosition = oldpos;
            }
        }

        else
        {
            
        }

        GetComponent<CanvasGroup>().blocksRaycasts = true;
    }

    public void Clicked()
    {

    }
}
