using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemGrabController : MonoBehaviour
{


    void Start()
    {
        Physics2D.IgnoreLayerCollision(7, 3);
    }
}
