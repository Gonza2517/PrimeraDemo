using UnityEngine;

public class Controlador : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 5f;
    public int maxJumps = 1; 
    private Rigidbody2D rb;
    private int jumpCount; 

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        jumpCount = 0; 
    }

    void Update()
    {
        float moveX = Input.GetAxis("Horizontal") * moveSpeed;
        rb.linearVelocity = new Vector2(moveX, rb.linearVelocity.y);

        if (jumpCount < maxJumps && Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            jumpCount++; 
        }

        if (Input.GetKey(KeyCode.A))
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);  
        }
        else if (Input.GetKey(KeyCode.D))
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);  
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            jumpCount = 0; 
        }
    }
}
