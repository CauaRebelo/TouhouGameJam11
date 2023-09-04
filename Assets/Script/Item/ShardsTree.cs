using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShardsTree : MonoBehaviour
{

    [SerializeField] private GameObject toco1;
    [SerializeField] private GameObject toco2;
    [SerializeField] private GameObject toco3;

    public void Start()
    {
        EventSystem.current.onForceDeath += OnForceDeath;
    }

    private void OnForceDeath()
    {
        StartCoroutine(CreateShards());
    }

    IEnumerator CreateShards()
    {
        yield return new WaitForSeconds(1f);
        toco1.SetActive(true);
        toco2.SetActive(true);
        toco3.SetActive(true);
    }

    private void OnDestroy()
    {
        EventSystem.current.onForceDeath -= OnForceDeath;
    }
}
