using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mirror : MonoBehaviour
{
    float rotation = 50;
    private int pos = 0;
    public bool seleccionado = false, apuntado = false;
    private LineRenderer lineR;
    Vector3 xero= new Vector3(0,0,0);
    public GameObject ultMirror;
    GameManager GM;


    void Start()
    {
        lineR = GetComponent<LineRenderer>();
        GM = GameObject.Find("Main Camera").transform.GetComponent<GameManager>();
        pos = PlayerPrefs.GetInt("Pos",0);
    }

    public void selecM()
    {
       
        seleccionado = !seleccionado;
    }
 
    void Update()
    {
       

       
        lineR.SetPosition(0, transform.localPosition);
        RaycastHit hit;

        if (Physics.Raycast(transform.position, transform.right , out hit))
        {
                if (hit.collider.CompareTag("Mirror"))
                {
                ultMirror = hit.transform.gameObject;
                if (hit.transform.GetComponent<LineRenderer>().enabled == false)
                {
                    
                    GM.Ward(this.transform.gameObject);
                    hit.transform.GetComponent<LineRenderer>().enabled = true;

                   
                }
                    hit.transform.GetComponent<Mirror>().enabled = true;
                    hit.transform.GetComponent<Mirror>().apuntado = true;
                    lineR.SetPosition(1, hit.transform.localPosition);
                }
        }
        else
        {
            if(ultMirror!= null)
            {

                ultMirror.transform.GetComponent<Mirror>().apuntado = false;

            }
            lineR.SetPosition(1, transform.right*5000);

        }

        if (apuntado == false)
        {
            this.transform.GetComponent<LineRenderer>().enabled = false;
            transform.GetComponent<Mirror>().enabled = false;
            if(ultMirror != null)
            {

                ultMirror.transform.GetComponent<Mirror>().apuntado = false;
                apuntado = !apuntado;
            }
        }
        if (seleccionado == true)
        {
            if (Input.GetKey(KeyCode.L))
            {
                this.transform.Rotate(new Vector3(0f, 0f, rotation) * -Time.deltaTime);
            }
            if (Input.GetKey(KeyCode.K))
            {
                this.transform.Rotate(new Vector3(0f, 0f, rotation) * Time.deltaTime);
            }
        }

    }
}
