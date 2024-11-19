using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class RetrocederTiempo : MonoBehaviour
{
    private List<Vector3> positions;
    private bool isRewinding = false;
    public float recordTime = 5f;

    void Start()
    {
        positions = new List<Vector3>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            StartRewind();
        }

        if (Input.GetKeyUp(KeyCode.E))
        {
            StopRewind();
        }

        if (isRewinding)
        {
            Rewind();
        }
        else
        {
            Record();
        }
    }

    void Record()
    {
        positions.Insert(0, transform.position);
        if (positions.Count > Mathf.Round(recordTime / Time.fixedDeltaTime))
        {
            positions.RemoveAt(positions.Count - 1);
        }
    }

    void Rewind()
    {
        if (positions.Count > 0)
        {
            transform.position = positions[0];
            positions.RemoveAt(0);
        }
        else
        {
            StopRewind();
        }
    }

    void StartRewind()
    {
        isRewinding = true;
    }

    void StopRewind()
    {
        isRewinding = false;
    }
}
