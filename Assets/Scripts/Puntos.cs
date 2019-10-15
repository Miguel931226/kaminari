using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puntos : MonoBehaviour
{
    public int Width;
    public int Heigth;
    public int limitWidth, limitHeigth, startWidth, startHeigth, PrefabTam, PrefabsSpace, WidthSpace, HeigthSpace;
    public int TotalHeigth, TotalWidth;
    public GameObject PrefabFicha ;
    // Start is called before the first frame update
    void Start()
    {
        

        PrefabFicha = Resources.Load("Image") as GameObject;

        

        PredecirCantidad();
        IniciarFichas();
    }

    // Update is called once per frame

    void PredecirCantidad()
    {
        WidthSpace = startWidth - limitWidth;
        HeigthSpace = startHeigth - limitHeigth;
        if (WidthSpace < 0)
        {
            WidthSpace *= -1;
        }
        if (HeigthSpace < 0)
        {
            HeigthSpace *= -1;
        }
        TotalHeigth = HeigthSpace / (PrefabTam + PrefabsSpace);
        TotalWidth = WidthSpace / (PrefabTam + PrefabsSpace);

    }
    void IniciarFichas()
    {
        Width = startWidth;
        Heigth = startHeigth;
        int PosXName = 0, PosYName = 0;
        for (int i = 0; i <= TotalWidth; i++)
        {
            for (int j = 0; j <= TotalHeigth; j++)
            {
                GameObject Other = Instantiate(PrefabFicha, this.transform.position, Quaternion.identity);

             
                    Other.transform.SetParent(GameObject.Find("Canvas").transform);

                
                

                Other.transform.position = new Vector2(Width, Heigth);
                Other.transform.name = PosXName.ToString() + PosYName.ToString();
                PosYName++;
                Heigth += 40;
            }
            PosXName++;
            PosYName = 0;
            Width += 40;
            Heigth = startHeigth;
        }


    }
}
