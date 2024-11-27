using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathZone : MonoBehaviour
{
    // Método llamado cuando otro collider 2D entra en el trigger
    private void OnTriggerEnter2D(Collider2D other)
    {
        // Verifica si el objeto tiene el tag "Player"
        if (other.CompareTag("Player"))
        {
            // Reinicia el nivel cargando de nuevo la escena actual
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        else if (other.CompareTag("Enemy"))
        {
            // Destruye el enemigo
            Destroy(other.gameObject);
        }
    }
}