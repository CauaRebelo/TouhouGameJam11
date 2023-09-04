using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Breakwall : MonoBehaviour
{

    [SerializeField] private GameObject plant;
    [SerializeField] private GameObject verify;
    [SerializeField] private GameObject wall;
    [SerializeField] private GameObject brokenWall;

    public void Start()
    {
        EventSystem.current.onDeath += OnDeath;
    }

    private void OnDeath()
    {
        if ((plant.activeSelf == true && brokenWall.activeSelf == false) || verify.GetComponent<GrowSeed>().isPlanted == true)
        {
            wall.SetActive(false);
            brokenWall.SetActive(true);
        }
    }

    private void OnDestroy()
    {
        EventSystem.current.onDeath -= OnDeath;
    }
}
