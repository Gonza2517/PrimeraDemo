using UnityEngine;

public class TeleportConClon : MonoBehaviour
{
    private Vector3 spawnPoint;
    private bool hasSpawned = false;
    private bool isReturning = false;
    private GameObject clone;
    private Collider2D playerCollider;

    public GameObject characterPrefab;  // Asigna tu personaje aquí (debe ser un prefab 2D)
    public Color cloneColor = Color.gray;  // Color gris para el clon
    public float returnSpeed = 10f;  // Velocidad de retorno del personaje

    void Start()
    {
        // Obtener el collider del personaje
        playerCollider = GetComponent<Collider2D>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))  // Detecta cuando se presiona la tecla Q
        {
            if (!hasSpawned && !isReturning)
            {
                // Marca el punto de spawn y crea una copia del personaje
                spawnPoint = transform.position;
                clone = Instantiate(characterPrefab, spawnPoint, Quaternion.identity);

                // Cambia el color del clon a gris
                clone.GetComponent<SpriteRenderer>().color = cloneColor;

                // Desactivar cualquier componente de movimiento o física en el clon
                Rigidbody2D cloneRb = clone.GetComponent<Rigidbody2D>();
                if (cloneRb != null)
                {
                    cloneRb.linearVelocity = Vector2.zero;  // Asegura que no se mueva
                    cloneRb.isKinematic = true;  // Desactiva la física
                }

                // Desactivar cualquier collider del clon para evitar colisiones
                Collider2D cloneCollider = clone.GetComponent<Collider2D>();
                if (cloneCollider != null)
                {
                    cloneCollider.enabled = false;  // Desactiva el collider para que no colisione
                }

                // Desactivar cualquier script o comportamiento de movimiento en el clon
                MonoBehaviour[] scripts = clone.GetComponents<MonoBehaviour>();
                foreach (MonoBehaviour script in scripts)
                {
                    if (script != null)
                    {
                        script.enabled = false;  // Desactiva scripts adicionales que pudieran moverlo
                    }
                }

                hasSpawned = true;
            }
            else if (hasSpawned && !isReturning)
            {
                // Inicia el retorno con animación
                isReturning = true;
                // Desactivar el collider del personaje
                if (playerCollider != null)
                {
                    playerCollider.enabled = false;
                }
                // Desactivar el clon temporalmente para evitar colisiones
                if (clone != null)
                {
                    clone.SetActive(false);
                }
            }
        }

        if (isReturning)
        {
            // Movimiento rápido pero visible hacia el punto de spawn
            transform.position = Vector3.MoveTowards(transform.position, spawnPoint, returnSpeed * Time.deltaTime);

            // Si llega al punto de spawn exacto
            if (transform.position == spawnPoint)
            {
                // Reactivar el collider del personaje
                if (playerCollider != null)
                {
                    playerCollider.enabled = true;
                }

                // Destruir el clon
                Destroy(clone);  // Destruye el clon
                hasSpawned = false;  // Restablece el estado de retorno
                isReturning = false;  // Termina el movimiento hacia el punto
            }
        }
    }
}
