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
    }

    public void OnJumpAction(InputAction.CallbackContext context)
    {
        if(context.performed && isGrounded())
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpPower);
        }

        // Pulo sensível ao toque
        if (context.canceled && rb.velocity.y > 0f)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpPower * 0.5f); ;
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
