using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    #region Variaveis
    // Componentes
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private float radius;
    

    // Atributos
    private float horizontal;
    private float movementSpeed = 8f;

    [SerializeField] private float jumpPower = 13f;
    private float jumpTime = 0.25f;
    private float fallSpeed = -40f;

    // Eventos Unity
    [field: SerializeField]
    public UnityEvent<float> OnVelocityChange { get; set; }

    [field: SerializeField]
    public UnityEvent<bool> OnGroundedChange {  get; set; }
    #endregion

    #region Funcoes Unity
    // Fun��es Unity
    private void Update()
    {
        OnGroundedChange?.Invoke(isGrounded());
    }

    private void FixedUpdate()
    {
        MovePlayer();

        if(!isGrounded())
        {
            rb.velocity += new Vector2(0, fallSpeed * Time.fixedDeltaTime);
        }
        else if(isGrounded() && rb.velocity.y < 0)
        {
            rb.velocity = new Vector2(rb.velocity.x, 0);
        }
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
            StartCoroutine(JumpTimeControl());
        }
    }

    public void MovePlayer()
    {
        rb.velocity = new Vector2(horizontal * movementSpeed, rb.velocity.y);
        OnVelocityChange?.Invoke(rb.velocity.x);
    }

    private bool isGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, radius, groundLayer);
    }
    
    private IEnumerator JumpTimeControl()
    {
        rb.velocity = new Vector2(rb.velocity.x, jumpPower);

        float timer = 0f;

        while (timer < jumpTime)
        {
            timer += Time.deltaTime;
            yield return null;
        }
    }
    #endregion
}
