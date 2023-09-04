using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StonesonLake : MonoBehaviour
{

    public List<GameObject> pedras;
    public int index = 0;

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.name == "Pedra")
        {
            AparecerPedra();
            col.gameObject.SetActive(false);
        }
        if (col.gameObject.name == "Pedra (1)")
        {
            AparecerPedra();
            col.gameObject.SetActive(false);
        }
        if (col.gameObject.name == "Pedra(2)")
        {
            AparecerPedra();
            col.gameObject.SetActive(false);
        }
    }

    void AparecerPedra()
    {
        pedras[index].SetActive(true);
        index++;
    }
}
