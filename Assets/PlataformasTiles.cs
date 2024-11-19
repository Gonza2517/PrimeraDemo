using UnityEngine;

public class PlataformasTiles : MonoBehaviour
{
    public GameObject[] platformObjects; 
    public float moveSpeed = 1f; 
    public float leftBound = -5f; 
    public float rightBound = 5f; 
    private Vector3 direction = Vector3.right; 

    void Update()
    {
        MovePlatform();
    }

    void MovePlatform()
    {
        foreach (GameObject obj in platformObjects)
        {
            if (obj != null)
            {
                obj.transform.position += direction * moveSpeed * Time.deltaTime;
            }
        }
        foreach (GameObject obj in platformObjects)
        {
            if (obj != null)
            {
                if (obj.transform.position.x >= rightBound)
                {
                    direction = Vector3.left;
                    break;
                }
                else if (obj.transform.position.x <= leftBound)
                {
                    direction = Vector3.right;
                    break;
                }
            }
        }
    }
}
