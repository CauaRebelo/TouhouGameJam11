using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallDamage : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            Info_Player.deaths++;
            Info_Player.death_fall++;
            col.gameObject.GetComponent<Death>().Reincarnate();
        }
    }
}
