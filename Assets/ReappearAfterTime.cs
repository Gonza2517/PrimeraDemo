using UnityEngine;
using System.Collections;

public class ReappearAfterTime : MonoBehaviour
{
    public GameObject targetObject; // El GameObject que deseas hacer reaparecer
    public float reappearTime = 5f; // Tiempo en segundos antes de que reaparezca

    // Método para ocultar el objeto y comenzar la corrutina
    public void HideAndReappear()
    {
        targetObject.SetActive(false); // Ocultar el objeto
        StartCoroutine(ReappearCoroutine()); // Iniciar la corrutina
    }

    // Corrutina que espera un tiempo antes de hacer reaparecer el objeto
    private IEnumerator ReappearCoroutine()
    {
        yield return new WaitForSeconds(reappearTime); // Esperar el tiempo especificado
        targetObject.SetActive(true); // Hacer reaparecer el objeto
    }
}