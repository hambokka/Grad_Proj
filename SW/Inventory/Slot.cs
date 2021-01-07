using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slot : MonoBehaviour
{
    public static Slot instanceslot;

    private void Awake()
    {
        if (instanceslot == null)
            instanceslot = this;
    }

    public int[,] grid;

    public Inventory playerinventory;
    public List<InventoryView> slotviews = new List<InventoryView>();

    public int_pair gridsize;

    public InventoryView prefabview;
    Vector2 cellsize = new Vector2(64f, 64f);

    List<Vector2> itempos = new List<Vector2>();

    void Start()
    {
        playerinventory = FindObjectOfType<Inventory>();

        grid = new int[gridsize.x, gridsize.y];
    }

    public bool Additem(Item item)
    {
        Start();
        int_pair itemsize = item.itemsize;

        for(int i = 0; i < gridsize.x; i++)
            for(int j = 0; j < gridsize.y; j++)
            {
                if (itempos.Count != (itemsize.x * itemsize.y))
                {
                    for (int y = 0; y < itemsize.y; y++)
                        for (int x = 0; x < itemsize.x; x++)
                        {
                            if ((i + x) < gridsize.x && (j + y) < gridsize.y && grid[i + x, j + y] != 1)
                            {
                                Vector2 pos = new Vector2(i + x, j + y);
                                itempos.Add(pos);
                            }
                            else
                            {
                                x = itemsize.x;
                                y = itemsize.y;
                                itempos.Clear();
                            }
                        }
                }
                else
                    break;
            }

        if(itempos.Count == (itemsize.x * itemsize.y))
        {
            InventoryView myitem = Instantiate(prefabview);
            myitem.startpos = new Vector2(itempos[0].x, itempos[0].y);
            myitem.item = item;
            myitem.itemsprite.sprite = item.itemsprite;
            RectTransform rectTransform = myitem.GetComponent<RectTransform>();
            rectTransform.anchoredPosition = Vector2.zero;
            rectTransform.anchorMax = new Vector2(0f, 1f);
            rectTransform.anchorMin = new Vector2(0f, 1f);
            myitem.transform.SetParent(this.GetComponent<RectTransform>(), false);
            myitem.gameObject.transform.localScale = new Vector3(1f, 1f, 1f);
            rectTransform.anchoredPosition = new Vector2(myitem.startpos.x * cellsize.x, -myitem.startpos.y * cellsize.y);
            slotviews.Add(myitem);

            for(int n = 0; n < itempos.Count; n++)
            {
                int posx = (int)itempos[n].x;
                int posy = (int)itempos[n].y;
                grid[posx, posy] = 1;
            }
            itempos.Clear();
            return true;
        }
        return false;
    }
}
