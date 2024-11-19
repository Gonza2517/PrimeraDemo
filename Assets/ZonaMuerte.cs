using UnityEngine;
using UnityEngine.SceneManagement;

public class ZonaMuerte : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            RestartScene();
        }
    }

  
    void RestartScene()
    {
       
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
