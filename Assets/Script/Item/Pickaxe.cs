using UnityEngine;
using UnityEngine.Events;

public class Pickaxe : MonoBehaviour
{

    [SerializeField] private ScreenShake shake;
    [SerializeField] private GameObject item;

    public void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.name == "Pedras")
        {
            shake.duration = 0.2f;
            shake.magnitude = 0.1f;
            shake.ShakeScreen();
            col.gameObject.GetComponent<BreakWall>().FallingRocks();
            Info_Player.deaths++;
            EventSystem.current.ForceDeath();
            Destroy(item);
        }
    }
}
