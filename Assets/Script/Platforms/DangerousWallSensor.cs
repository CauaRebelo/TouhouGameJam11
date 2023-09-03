using UnityEngine;

public class DangerousWallSensor : MonoBehaviour
{
    private PlayerItemGrab playerItemGrab;
    private ScreenShake screenShake;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        collision.GetComponent<BoxCollider2D>();

        if (!playerItemGrab.itemCarry)
        {
            Debug.Log("Passei na primeira checagem");

            if (collision.gameObject.name == "Picareta")
            {
                Debug.Log("Passei na segunda checagem");

                screenShake.ShakeScreen();
                collision.gameObject.SetActive(false);
            }
        }
        else
        {
            Debug.Log("Estou na terceira checagem");
        }
    }
}
