using System.Collections;
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

    private float jumpPower = 7f;
    private float jumpTime = 0.25f;
    private float fallSpeed = -40f;
    private bool isFalling = false;
    #endregion

    #region Funcoes Unity
    // Funções Unity
    private void FixedUpdate()
    {
        MovePlayer();

        if(isFalling && isGrounded())
        {
            rb.velocity = new Vector2(rb.velocity.x, 0);
        }
        else if(isFalling && !isGrounded())
        {
            rb.velocity += new Vector2(0, fallSpeed * Time.fixedDeltaTime);
        }

        Debug.Log(rb.velocity.y);
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
            //rb.velocity = new Vector2(rb.velocity.x, jumpPower);
            StartCoroutine(JumpTimeControl());
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
    
    private IEnumerator JumpTimeControl()
    {
        isFalling = false;
        rb.velocity = new Vector2(rb.velocity.x, jumpPower);

        float timer = 0f;

        while (timer < jumpTime)
        {
            timer += Time.deltaTime;
            yield return null;
        }

        isFalling = true;
    }
    #endregion
}
