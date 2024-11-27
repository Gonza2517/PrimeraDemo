using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target; // El personaje al que seguir� la c�mara
    public Vector3 offset; // La distancia configurable entre la c�mara y el personaje

    void LateUpdate()
    {
        if (target != null)
        {
            // La posici�n de la c�mara es la del personaje m�s el offset
            transform.position = target.position + offset;
        }
    }
}