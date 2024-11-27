using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target; // El personaje al que seguirá la cámara
    public Vector3 offset; // La distancia configurable entre la cámara y el personaje

    void LateUpdate()
    {
        if (target != null)
        {
            // La posición de la cámara es la del personaje más el offset
            transform.position = target.position + offset;
        }
    }
}