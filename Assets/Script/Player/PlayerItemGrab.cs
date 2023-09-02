using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerItemGrab : MonoBehaviour
{
    [SerializeField] private Transform itemCheck;
    [SerializeField] private Transform itemGrab;
    private bool itemTouch = false;

    

    public void OnPickupAction(InputAction.CallbackContext context)
    {
        if(context.performed && itemTouch){
         
        }

        if (context.canceled){

        }
    }

    public void OnTriggerEnter2D(Collider2D teste){
        itemTouch = true;
        Debug.Log("Entrou trigger");

    }

    public void OnTriggerExit2D(Collider2D teste){
        itemTouch = false;
        Debug.Log("Saiu trigger");
    }
}
