using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerItemGrab : MonoBehaviour
{
    [SerializeField] private Transform itemCheck;
    [SerializeField] private Transform itemGrab;
    [SerializeField] private Transform itemDropLocation;
    [SerializeField] private GameObject item;
    private bool itemTouch = false;
    private bool itemCarry = false;

    

    public void OnPickupAction(InputAction.CallbackContext context)
    {
        if(context.performed && itemTouch == true && itemCarry == false){
            item.transform.parent = itemGrab;
            item.transform.position = itemGrab.position;
            item.GetComponent<Rigidbody2D>().isKinematic = true;
            item.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            item.GetComponent<Collider2D>().enabled = false;
            itemCarry = true;
        }

        else if(context.performed && itemCarry == true){
            item.transform.parent = null;
            item.transform.position = itemDropLocation.position;
            item.GetComponent<Rigidbody2D>().isKinematic = false;
            item.GetComponent<Collider2D>().enabled = true;
            itemCarry = false;
        }
    }

    public void OnTriggerEnter2D(Collider2D teste){
        if(teste.CompareTag("Item") && itemCarry == false){
            itemTouch = true;
            item = teste.gameObject;
        }

    }

    public void OnTriggerExit2D(Collider2D teste){
        itemTouch = false;
    }
}
