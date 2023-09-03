using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Death : MonoBehaviour
{

    [SerializeField] private GameObject player;
    [SerializeField] private UnityEvent _timeSkip;

    public static Vector2 checkPoint = Vector2.zero;

    public void Start()
    {
        EventSystem.current.onForceDeath += OnForceDeath;
    }

    public void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Respawn")
        {
            checkPoint = col.gameObject.transform.position;
            col.gameObject.SetActive(false);
        }
    }
    
    public void OnForceDeath()
    {
        StartCoroutine(Forced());
    }

    public void Reincarnate()
    {
        player.GetComponent<PlayerItemGrab>().deathDrop();
        EventSystem.current.Death();
        _timeSkip?.Invoke();
        player.transform.position = checkPoint;
    }

    IEnumerator Forced()
    {
        yield return new WaitForSeconds(0.2f);
        Reincarnate();
    }
}
