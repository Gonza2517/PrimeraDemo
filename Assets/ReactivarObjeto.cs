using UnityEngine;

public class ReactivarObjeto : MonoBehaviour
{
    public GameObject objetoAReactivar;  // El objeto que deseas reactivar
    public string objetoAGestionarTag = "Player";  // Tag del objeto que al tocar va a activar el objeto

    void OnTriggerEnter2D(Collider2D other)
    {
        // Verifica si el objeto que tocó el collider tiene el tag correcto
        if (other.CompareTag(objetoAGestionarTag))
        {
            // Reactiva el objeto deseado
            objetoAReactivar.SetActive(true);
            // También puedes desactivar el objeto que toca
            gameObject.SetActive(false);
        }
    }
}
