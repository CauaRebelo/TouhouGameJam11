using UnityEngine;

public class Turtle : MonoBehaviour
{
    // Componentes
    [SerializeField] private GameObject tinyTurtle;
    [SerializeField] private GameObject bigTurtle;

    // Atributos
    private bool turtleInWater = false;

    private void Start()
    {
        EventSystem.current.onDeath += OnDeath;
    }

    private void OnDestroy()
    {
        EventSystem.current.onDeath -= OnDeath;
    }

    private void OnDeath()
    {
        if (turtleInWater)
        {   
            bigTurtle.SetActive(true);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == tinyTurtle.gameObject.name)
        {
            tinyTurtle.SetActive(false);
            turtleInWater = true;
        }
    }
}
