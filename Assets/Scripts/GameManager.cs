using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private GameObject[] espejos;
    public List<GameObject> Nom;
    int cont;
    int index;

    void Start()
    {
        int j = 0;
        cont = GameObject.FindGameObjectsWithTag("Mirror").Length;
        espejos = new GameObject[cont];
        for(int i = 0; i < cont; i++)
        {
            espejos[j] = GameObject.Find("Mirrors").transform.GetChild(i).transform.gameObject;
            j++;
        }
    }

    public void Breack(string name)
    {
        for(int i=0; i<Nom.Count; i++)
        {
            if(Nom[i].name == name)
            {
                index = i;
                Debug.Log(i);
            }


        }


        Nom.RemoveRange(index, Nom.Count);
        
    }

   public void Ward(GameObject C)
    {
        Nom.Add(C);
    }
}
