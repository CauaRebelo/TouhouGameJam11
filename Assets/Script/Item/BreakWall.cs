using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakWall : MonoBehaviour
{

    [SerializeField] private GameObject pedraBloqueio;
    [SerializeField] private GameObject pedraRestos;

    public void FallingRocks()
    {
        pedraBloqueio.SetActive(false);
        pedraRestos.SetActive(true);
    }
}
