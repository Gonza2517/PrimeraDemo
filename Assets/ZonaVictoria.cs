using UnityEngine;
using UnityEngine.SceneManagement;

public class ZonaVictoria : MonoBehaviour
{
    public string nombreDeEscena = "NombreDeTuEscena";
    public float delayAntesDeCambio = 5f;

    private bool jugadorEnZona = false;
    private float tiempoDeEspera = 0f;

    private void Update()
    {
        if (jugadorEnZona)
        {
            tiempoDeEspera += Time.deltaTime;
            if (tiempoDeEspera >= delayAntesDeCambio)
            {
                SceneManager.LoadScene(nombreDeEscena);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            jugadorEnZona = true;
            tiempoDeEspera = 0f;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            jugadorEnZona = false;
            tiempoDeEspera = 0f;
        }
    }
}
