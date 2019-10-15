using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserShoot : MonoBehaviour
{
    private LineRenderer lineR;
    void Start()
    {
        lineR = GetComponent<LineRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        lineR.SetPosition(0, transform.position);
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.right*-1, out hit))
        {
            if (hit.collider)
            {
                lineR.SetPosition(1, hit.point);
            }
        }
        else lineR.SetPosition(1, transform.right * -5000);
    
    }

}
