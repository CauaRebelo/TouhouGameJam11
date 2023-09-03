using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VineSeed : MonoBehaviour
{

    [SerializeField] private GameObject item;

    public void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Soil")
        {
            col.gameObject.GetComponent<GrowsSeed>().StartGrow();
            item.gameObject.Destroy(item.gameObject);
        }
    }
}
