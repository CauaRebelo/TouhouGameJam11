using System.Collections;
using UnityEngine;

public class ScreenShake : MonoBehaviour
{
    public float duration;
    public float magnitude;

    public void ShakeScreen()
    {
        StartCoroutine(ShakeEnumerator());
    }

    public IEnumerator ShakeEnumerator()
    {
        Vector3 originalPosition = transform.position;

        float timer = 0.0f;

        while (timer < duration)
        {
            float y = Random.Range(-1f, 1f) * magnitude;

            Debug.Log(y);

            transform.position += new Vector3(0, y, 0);

            timer += Time.deltaTime;

            yield return null;
        }

        transform.position = originalPosition;
    }
}
