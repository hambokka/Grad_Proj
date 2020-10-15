using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{
    public GameObject bulletobj;
    public Transform pos;
    public float cooltime;
    private float curtime;
    bool right = true;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Shoot();
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
            Instantiate(bulletobj, pos.position, transform.rotation);
    }
}