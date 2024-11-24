using UnityEngine;
using UnityEngine.SceneManagement;

public class EmpezarLevel1 : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            SceneManager.LoadScene("SampleScene");
        }
    }
}
