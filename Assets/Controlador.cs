using UnityEngine;

public class Controlador : MonoBehaviour
{
    public float moveSpeed = 5f;       // Velocidad de movimiento del jugador
    public float jumpForce = 5f;       // Fuerza de salto del jugador
    public LayerMask groundLayer;      // Capa que representa el suelo
    public Transform groundCheck;      // Transform que verifica si el jugador está en el suelo
    public float groundCheckRadius = 0.2f; // Radio de verificación del suelo

    private Rigidbody2D rb;            // Referencia al Rigidbody2D del jugador
    public bool isGrounded;           // Indicador de si el jugador está en el suelo

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Movimiento horizontal
        float moveX = Input.GetAxis("Horizontal") * moveSpeed;
        rb.linearVelocity = new Vector2(moveX, rb.linearVelocity.y);

        // Verificar si el jugador está en el suelo
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);

        // Salto
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }

        // Rotación del jugador
        if (Input.GetKey(KeyCode.A))
        {
            transform.rotation = Quaternion.Euler(0, -180, 0);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
    }

    void OnDrawGizmosSelected()
    {
        if (groundCheck != null)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(groundCheck.position, groundCheckRadius);
        }
    }
}
