using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class Death : MonoBehaviour
{

    [SerializeField] private GameObject player;
    [SerializeField] private UnityEvent _timeSkip;
    [SerializeField] private GameObject hitbox;
    [SerializeField] private GameObject canera;

    public PlayerInput playerInput;
    public static Vector2 checkPoint = Vector2.zero;

    public void Start()
    {
        EventSystem.current.onForceDeath += OnForceDeath;
        playerInput = player.GetComponent<PlayerInput>();
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
        StartCoroutine(Dying());
    }

    IEnumerator Dying()
    {
        playerInput.SwitchCurrentActionMap("UI");
        gameObject.GetComponent<CapsuleCollider2D>().enabled = false;
        canera.gameObject.GetComponent<CameraFollow>().enabled = false;
        yield return new WaitForSeconds(1f);
        gameObject.GetComponent<CapsuleCollider2D>().enabled = true;
        canera.gameObject.GetComponent<CameraFollow>().enabled = true;
        player.transform.position = checkPoint;
        playerInput.SwitchCurrentActionMap("Player");
    }

    IEnumerator Forced()
    {
        yield return new WaitForSeconds(0.2f);
        Reincarnate();
    }
}
