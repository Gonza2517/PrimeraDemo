using UnityEngine;

public class Controlador : MonoBehaviour
{
    public float moveSpeed = 5f;       
    public float jumpForce = 5f;      
    public LayerMask groundLayer;    
    public Transform groundCheck;      
    public float groundCheckRadius = 0.2f; 

    private Rigidbody2D rb;           
    public bool isGrounded;           

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
       
        float moveX = Input.GetAxis("Horizontal") * moveSpeed;
        rb.linearVelocity = new Vector2(moveX, rb.linearVelocity.y);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }

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
