using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemRespawnBehaviour : MonoBehaviour
{

    [SerializeField] private GameObject item;

    public Vector2 checkPoint = Vector2.zero;

    public void Start()
    {
        EventSystem.current.onDeath += OnDeath;
    }

    public void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "RespawnItem")
        {
            checkPoint = col.gameObject.transform.position;
            col.gameObject.SetActive(false);
        }
    }
    
    private void OnDeath()
    {
        item.transform.position = checkPoint;
    }

    private void OnDestroy()
    {
        EventSystem.current.onDeath -= OnDeath;
    }
}
