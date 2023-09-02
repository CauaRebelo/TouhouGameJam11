using System.Collections;
using UnityEngine;

public class ScreenShake : MonoBehaviour
{
    [SerializeField] private float duration;
    [SerializeField] private float magnitude;

    public void ShakeScreen()
    {
        StartCoroutine(ShakeEnumerator());
    }

    public IEnumerator ShakeEnumerator()
    {
        Vector3 originalPosition = transform.localPosition;

        float timer = 0.0f;

        while (timer < duration)
        {
            float y = Random.Range(-1f, 1f) * magnitude;

            transform.localPosition = new Vector3(originalPosition.x, y, originalPosition.z);

            timer += Time.deltaTime;

            yield return null;
        }

        transform.localPosition = originalPosition;
    }
}
