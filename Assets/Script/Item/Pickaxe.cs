using UnityEngine;
using UnityEngine.Events;

public class Pickaxe : MonoBehaviour
{
    [SerializeField] private ScreenShake screenShake;

    // Eventos
    public UnityEvent Deslizamento;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "DangerousWall")
        {
            screenShake.ShakeScreen();
            this.gameObject.SetActive(false);
        }
    }
}
