using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {
    
    public float speed=100f;

    private Transform waypoints;
    private Transform waypoint;
    private int waypointIndex=-1;
	// Use this for initialization
	void Start () {
        waypoints = GameObject.Find("WayPoints").transform;
        NextWayPoint();
    }
	
	// Update is called once per frame
	void Update () {
        Vector3 dir = waypoint.transform.position - transform.position;
        dir.y = 0;
        float _speed = Time.deltaTime * speed;
        transform.Translate(dir.normalized * Time.deltaTime * _speed);
        if (dir.magnitude <= _speed/10)
            NextWayPoint();

    }

    void NextWayPoint()
    {
        waypointIndex++;
        if (waypointIndex >= waypoints.childCount)
        {
            Destroy(gameObject);
            return;
        }

        waypoint = waypoints.GetChild(waypointIndex);
    }
}
