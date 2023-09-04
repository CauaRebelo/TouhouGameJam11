using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadBnuy : MonoBehaviour
{

    [SerializeField] private GameObject bunny;

    public void Start()
    {
        EventSystem.current.onForceDeath += OnForceDeath;
    }

    private void OnForceDeath()
    {
        bunny.SetActive(true);
    }

    private void OnDestroy()
    {
        EventSystem.current.onForceDeath -= OnForceDeath;
    }
}
