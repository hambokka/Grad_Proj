using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playeraim : MonoBehaviour
{
    Transform aimtransform;
    // Start is called before the first frame update
    void Start()
    {
        aimtransform = transform.Find("Weapons");
    }

    // Update is called once per frame
    void Update()
    {
        Aim();
    }

    void Aim()
    {
        Vector3 mouseposition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 aimdir = (mouseposition - transform.position).normalized;

        float angle = Mathf.Atan2(aimdir.y, aimdir.x) * Mathf.Rad2Deg;

        aimtransform.eulerAngles = new Vector3(0, 0, angle);

        Vector3 localscale = Vector3.one;

        if (angle > 90 || angle < -90)
            localscale.y = -1f;
        else
            localscale.y = 1f;
        aimtransform.localScale = localscale;
    }
}
