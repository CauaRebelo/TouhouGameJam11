using System;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    #region Variaveis
    // Compenentes
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;

    // Atributos
    private float horizontal;
    private float movementSpeed = 5;
    private float jumpPower = 5;
    #endregion

    #region Funcoes Unity
    // Funções Unity
    private void Update()
    {
        GetInput();
    }

    private void FixedUpdate()
    {
        MovePlayer();
        Jump();
    }
    #endregion

    #region Metodos Gerais
    private void GetInput()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
    }

    private void MovePlayer()
    {
        rb.velocity = new Vector2(horizontal * movementSpeed, rb.velocity.y);
    }

    private void Jump()
    {
        if (Input.GetKey(KeyCode.Space) && IsGrounded())
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpPower);
        }
    }

    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }
    #endregion
}
