using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrowSeed : MonoBehaviour
{

    [SerializeField] private GameObject seed;
    [SerializeField] private GameObject plant;

    public bool isPlanted = false;

    public void Start()
    {
        EventSystem.current.onDeath += OnDeath;
    }

    public void StartGrow()
    {
        seed.SetActive(true);
        isPlanted = true;
    }

    private void OnDeath()
    {
        if(isPlanted)
        {
            seed.SetActive(false);
            plant.SetActive(true);
        }
    }

    private void OnDestroy()
    {
        EventSystem.current.onDeath -= OnDeath;
    }

}
