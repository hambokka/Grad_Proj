using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{
    public GameObject bulletobj;
    public Transform pos;
    public float cooltime;
    public float maxoffset;
    public float recoilaccel;
    public float recoilsteartspeed;

    private float curtime;
    private bool inrecoil;
    private bool originpos;

    private Vector3 offsetpos;
    private Vector3 recoilspeed;
    bool right = true;

    // Start is called before the first frame update
    void Start()
    {
        recoilspeed = Vector3.zero;
        offsetpos = Vector3.zero;
        inrecoil = false;
        originpos = false;
    }

    // Update is called once per frame
    void Update()
    {
        Shoot();
        Updaterecoil();
    }

    void Shoot()
    {
        Vector2 len = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float z = Mathf.Atan2(len.y, len.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, z);

        Vector3 localscail = Vector3.one;
        if (z > 90 || z < -90)
            localscail.y = -1f;
        else
            localscail.y = 1f;

        transform.localScale = localscail;


        if (Input.GetMouseButtonDown(0))
        {
            Instantiate(bulletobj, pos.position, transform.rotation);
            Addrecoil();
        }
    }

    public void Addrecoil()
    {
        inrecoil = true;
        originpos = false;

        recoilspeed = transform.right * recoilsteartspeed;
    }

    void Updaterecoil()
    {
        if(inrecoil == false)
        {
            return;
        }

        recoilspeed += (-offsetpos.normalized) * recoilaccel * Time.deltaTime;
        Vector3 newoffsetpos = offsetpos + recoilspeed * Time.deltaTime;
        Vector3 newtranseformpos = transform.position - offsetpos;

        if(newoffsetpos.magnitude > maxoffset)
        {
            recoilspeed = Vector3.zero;
            originpos = true;
            newoffsetpos = offsetpos.normalized * maxoffset;
        }

        else if(originpos == true && newoffsetpos.magnitude > offsetpos.magnitude)
        {
            transform.position -= offsetpos;
            offsetpos = Vector3.zero;

            inrecoil = false;
            originpos = false;
        }

        transform.position = newtranseformpos + newoffsetpos;
        offsetpos = newoffsetpos;
    }
}