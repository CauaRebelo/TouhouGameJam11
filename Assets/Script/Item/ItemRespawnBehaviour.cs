using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemRespawnBehaviour : MonoBehaviour
{

    [SerializeField] private GameObject item;

    public static Vector2 checkPoint = Vector2.zero;

    public void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "RespawnItem")
        {
            checkPoint = col.gameObject.transform.position;
            col.gameObject.SetActive(false);
        }
    }
    
    public void Respawn()
    {
        item.transform.position = checkPoint;
    }
}
