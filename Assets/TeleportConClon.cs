using UnityEngine;

public class TeleportConClon : MonoBehaviour
{
    private Vector3 spawnPoint;
    private bool hasSpawned = false;
    private bool isReturning = false;
    private GameObject clone;
    private Collider2D playerCollider;

    public GameObject characterPrefab;  
    public Color cloneColor = Color.gray;  
    public float returnSpeed = 10f;  

    void Start()
    {
        playerCollider = GetComponent<Collider2D>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q)) 
        {
            if (!hasSpawned && !isReturning)
            {
                spawnPoint = transform.position;
                clone = Instantiate(characterPrefab, spawnPoint, Quaternion.identity);
                clone.GetComponent<SpriteRenderer>().color = cloneColor;
                Rigidbody2D cloneRb = clone.GetComponent<Rigidbody2D>();
                if (cloneRb != null)
                {
                    cloneRb.linearVelocity = Vector2.zero;  
                    cloneRb.isKinematic = true;  
                }
                Collider2D cloneCollider = clone.GetComponent<Collider2D>();
                if (cloneCollider != null)
                {
                    cloneCollider.enabled = false;
                }
                MonoBehaviour[] scripts = clone.GetComponents<MonoBehaviour>();
                foreach (MonoBehaviour script in scripts)
                {
                    if (script != null)
                    {
                        script.enabled = false;  
                    }
                }

                hasSpawned = true;
            }
            else if (hasSpawned && !isReturning)
            {
                isReturning = true;
                if (playerCollider != null)
                {
                    playerCollider.enabled = false;
                }
                if (clone != null)
                {
                    clone.SetActive(false);
                }
            }
        }

        if (isReturning)
        {
            transform.position = Vector3.MoveTowards(transform.position, spawnPoint, returnSpeed * Time.deltaTime);
            if (transform.position == spawnPoint)
            {
                if (playerCollider != null)
                {
                    playerCollider.enabled = true;
                }
                Destroy(clone);  
                hasSpawned = false; 
                isReturning = false;  
            }
        }
    }
}
