using UnityEngine;
using UnityEngine.SceneManagement;

public class EmpezarCreditos1 : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            SceneManager.LoadScene("Creditos 1");
        }
    }
}
