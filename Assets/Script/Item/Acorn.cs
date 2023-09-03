using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Acorn : MonoBehaviour
{
    [SerializeField] private GameObject item;

    public void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "FluffDirt")
        {
            col.gameObject.GetComponent<GrowSeed>().StartGrow();
            Destroy(item);
        }
    }
}
