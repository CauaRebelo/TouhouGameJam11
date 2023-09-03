using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemGl : MonoBehaviour
{
    [SerializeField] private GameObject item;

    public static Vector2 checkPoint = Vector2.zero;

    public void OnTriggerEnter2D(Collider2D col)
    {
        Debug.Log(col.gameObject.tag);
        if (col.gameObject.tag == "RespawnItem")
        {
            checkPoint = col.gameObject.transform.position;
            col.gameObject.SetActive(false);
        }
        if (col.gameObject.tag == "DeathRespawnItem")
        {
            checkPoint = col.gameObject.transform.position;
        }
        if (col.gameObject.tag == "Ground")
        {
            StartCoroutine(ChangeSpawn());
        }
    }

    IEnumerator ChangeSpawn()
    {
        yield return new WaitForSeconds(0.5f);
        Debug.Log("Obrigado por esperar");
        Vector2 newSpawn = item.transform.position;
        yield return new WaitForSeconds(1f);
        if (newSpawn.x == item.transform.position.x && newSpawn.y == item.transform.position.y)
        {
            Debug.Log("Sucesso!");
            checkPoint = newSpawn;
        }
    }

    public void Respawn()
    {
        item.transform.position = checkPoint;
    }
}
