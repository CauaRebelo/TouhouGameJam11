using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerItemGrab : MonoBehaviour
{
    [SerializeField] private Transform itemCheck;
    [SerializeField] private Transform itemGrab;
    [SerializeField] private Transform itemDropLocation;
    [SerializeField] private GameObject item;
    public int desesp = 0;
    public bool itemTouch = false;
    public bool itemCarry = false;

    public void OnPickupAction(InputAction.CallbackContext context)
    {
        if(context.performed && itemTouch == true && itemCarry == false){
            item.transform.parent = itemGrab;
            item.GetComponent<Rigidbody2D>().constraints &= ~RigidbodyConstraints2D.FreezePositionY;
            if(item.gameObject.name == "Carrot")
            {
                EventSystem.current.PickupCarrot();
            }
            item.transform.position = itemGrab.position;
            item.GetComponent<Rigidbody2D>().isKinematic = true;
            item.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            item.GetComponent<Collider2D>().isTrigger = true;
            itemCarry = true;
        }

        else if(context.performed && itemCarry == true){
            item.transform.parent = null;
            item.transform.position = itemDropLocation.position;
            item.GetComponent<Rigidbody2D>().isKinematic = false;
            item.GetComponent<Collider2D>().isTrigger = false;
            itemCarry = false;
        }
    }

    public void OnTriggerEnter2D(Collider2D teste){
        if(teste.CompareTag("Item") && itemCarry == false){
            itemTouch = true;
            item = teste.gameObject;
        }

    }

    public void OnTriggerStay2D(Collider2D teste){
        if(teste.CompareTag("Item") && itemCarry == false){
            itemTouch = true;
            item = teste.gameObject;
        }

    }

    public void OnTriggerExit2D(Collider2D teste){
        itemTouch = false;
    }

    public void deathDrop(){
        if(itemCarry == true){
            item.transform.parent = null;
            item.transform.position = itemDropLocation.position;
            item.GetComponent<Rigidbody2D>().isKinematic = false;
            item.GetComponent<Collider2D>().isTrigger = false;
            itemCarry = false;
        }

    }

}
