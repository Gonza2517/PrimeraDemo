using UnityEngine;

public class ReactivarObjeto : MonoBehaviour
{
    public GameObject objetoAReactivar;  
    public string objetoAGestionarTag = "Player";  

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag(objetoAGestionarTag))
        {
            objetoAReactivar.SetActive(true);
            gameObject.SetActive(false);
        }
    }
}
