using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Carrot : MonoBehaviour
{

    [SerializeField] private GameObject item;

    public static Vector2 carrotPosition;

    // Update is called once per frame
    void Update()
    {
        carrotPosition = item.transform.position;
    }
}
