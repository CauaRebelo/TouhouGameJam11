using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarriorBunnyBehaviour : MonoBehaviour
{

    [SerializeField] private Rigidbody2D rb;

    public List<Transform> waypoints;

    public int nextPoints = 0;
    int pointChangeValue = 1;
    private float movementSpeed = 3;
    public bool isEnranged = false;

    public void Start()
    {
        EventSystem.current.onPickupCarrot += OnPickupCarrot;
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
            MoveToCarrot();
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
            Info_Player.death_enemy1++;
            col.gameObject.GetComponent<Death>().Reincarnate();
        }
    }
}
