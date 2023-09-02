using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Death : MonoBehaviour
{

    [SerializeField] private GameObject player;

    public Transform checkPoint;

    public void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Respawn")
        {
            checkPoint.position = col.gameObject.transform.position;
            col.gameObject.SetActive(false);
            Debug.Log("Guardado");
        }
    }

    public void Reincarnate()
    {
        player.transform.position = checkPoint.position;
    }

}
