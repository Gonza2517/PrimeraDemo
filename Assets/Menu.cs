using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    void Update()
    {
      if (Input.GetKeyDown(KeyCode.Return))
       {
         SceneManager.LoadScene("Tutorial");
       }  
    }
}
