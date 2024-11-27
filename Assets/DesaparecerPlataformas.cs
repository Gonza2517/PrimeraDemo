using UnityEngine;
using System.Collections;

public class DesaparecerPlataformas : MonoBehaviour
{
    public float disappearTime = 2.0f;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            StartCoroutine(DisappearAfterTime(disappearTime));
        }
    }

    private IEnumerator DisappearAfterTime(float time)
    {
        yield return new WaitForSeconds(time);
        gameObject.SetActive(false);
    }
}
