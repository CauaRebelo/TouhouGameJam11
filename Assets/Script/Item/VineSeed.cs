using UnityEngine;

public class VineSeed : MonoBehaviour
{

    [SerializeField] private GameObject item;

    public void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Soil")
        {
            col.gameObject.GetComponent<GrowSeed>().StartGrow();
            Destroy(item);
        }
    }
}
