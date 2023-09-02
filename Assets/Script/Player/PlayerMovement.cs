using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    #region Variaveis
    // Componentes
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;

    // Atributos
    private float horizontal;
    private float movementSpeed = 8f;
    private float jumpPower = 10f;
    #endregion

    #region Funcoes Unity
    // Funções Unity
    private void Update()
    {
        MovePlayer();
    }
    #endregion

    #region Metodos Gerais
    // Metodos Gerais
    public void OnMovementAction(InputAction.CallbackContext context)
    {
        horizontal = context.ReadValue<Vector2>().x;
        if (horizontal > 0)
            transform.localScale = new Vector3(1, 1, 1);
        if (horizontal < 0)
            transform.localScale = new Vector3(-1, 1, 1);
    }

    public void OnJumpAction(InputAction.CallbackContext context)
    {
        if(context.performed && isGrounded())
        {
            Info_Player.jumps++;
            rb.velocity = new Vector2(rb.velocity.x, jumpPower);
        }
    }

    public void MovePlayer()
    {
        rb.velocity = new Vector2(horizontal * movementSpeed, rb.velocity.y);
    }

    private bool isGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }
    #endregion
}
