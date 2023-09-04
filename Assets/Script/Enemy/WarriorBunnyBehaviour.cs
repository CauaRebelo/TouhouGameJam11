using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarriorBunnyBehaviour : MonoBehaviour
{

    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform carrotTransform;
    [SerializeField] private GameObject bunny;
    [SerializeField] private ScreenShake shake;

    public List<Transform> waypoints;

    public Vector2 checkPoint = Vector2.zero;
    public int nextPoints = 0;
    int pointChangeValue = 1;
    private float movementSpeed = 3;
    public float chaseDistance = 10;
    public bool isEnranged = false;

    public void Start()
    {
        EventSystem.current.onPickupCarrot += OnPickupCarrot;
        EventSystem.current.onDeath += OnDeath;
    }

    // Update is called once per frame
    void Update()
    {
        if (!isEnranged)
        {
            MoveToNextPoint();
        }
        if (isEnranged)
        {
            if(Vector2.Distance(rb.transform.position, carrotTransform.position) < chaseDistance)
            {
                MoveToCarrot();
            }
            else
            {
                MoveToNextPoint();
            }
        }
    }

    void MoveToNextPoint()
    {
        if(waypoints.Count > 0)
        {
            Transform goalPoint = waypoints[nextPoints];
            if (goalPoint.transform.position.x > rb.transform.position.x)
                rb.transform.localScale = new Vector3(-1, 1, 1);
            else
                rb.transform.localScale = new Vector3(1, 1, 1);
            rb.transform.position = Vector2.MoveTowards(rb.transform.position, goalPoint.position, movementSpeed * Time.deltaTime);
            if (Vector2.Distance(rb.transform.position, goalPoint.position) < 1f)
            {
                if (nextPoints == waypoints.Count - 1)
                    pointChangeValue = -1;
                if (nextPoints == 0)
                    pointChangeValue = 1;
                nextPoints += pointChangeValue;
            }
        }
    }

    void MoveToCarrot()
    {
        if(rb.transform.position.x > carrotTransform.position.x)
        {
            rb.transform.localScale = new Vector3(1, 1, 1);
            rb.transform.position += Vector3.left * movementSpeed * Time.deltaTime;
        }
        if (rb.transform.position.x < carrotTransform.position.x)
        {
            rb.transform.localScale = new Vector3(-1, 1, 1);
            rb.transform.position += Vector3.right * movementSpeed * Time.deltaTime;
        }
    }

    void OnPickupCarrot()
    {
        isEnranged = true;
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            Info_Player.deaths++;
            Info_Player.death_enemy2++;
            col.gameObject.GetComponent<Death>().Reincarnate();
        }
        if (col.gameObject.tag == "Climbable")
        {
            checkPoint = col.gameObject.transform.position;
            col.gameObject.SetActive(false);
        }
        if (col.gameObject.name == "Arvore")
        {
            Info_Player.deaths++;
            Destroy(col.gameObject);
            shake.duration = 0.2f;
            shake.magnitude = 0.1f;
            shake.ShakeScreen();
            EventSystem.current.ForceDeath();
            Destroy(bunny);
        }
    }

    private void OnDeath()
    {
        rb.transform.position = checkPoint;
        isEnranged = false;
    }

    private void OnDestroy()
    {
        EventSystem.current.onPickupCarrot -= OnPickupCarrot;
        EventSystem.current.onDeath -= OnDeath;
    }
}
