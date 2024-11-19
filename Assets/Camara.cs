using UnityEngine;

public class Camara : MonoBehaviour
{
    public Transform target; 
    public float smoothSpeed = 0.125f;
    public Vector3 offset; 

    public Vector2 minLimits; 
    public Vector2 maxLimits; 

    public float zoomSize = 5f; 
    public float zoomSpeed = 0.1f; 

    private Camera cam;

    private void Start()
    {
        cam = GetComponent<Camera>();
        if (cam.orthographic)
        {
            cam.orthographicSize = zoomSize;
        }
    }

    private void LateUpdate()
    {
        Vector3 desiredPosition = target.position + offset;
        desiredPosition.x = Mathf.Clamp(desiredPosition.x, minLimits.x, maxLimits.x);
        desiredPosition.y = Mathf.Clamp(desiredPosition.y, minLimits.y, maxLimits.y);
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = new Vector3(smoothedPosition.x, smoothedPosition.y, transform.position.z);
        if (cam.orthographic)
        {
            cam.orthographicSize = Mathf.Lerp(cam.orthographicSize, zoomSize, zoomSpeed);
        }
    }
}
