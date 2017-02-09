using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerController : MonoBehaviour {

    public GameObject spawnObject;
    public float spawnTime=3f;
    
    private float timer=1f;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            Instantiate(spawnObject, transform.position, transform.rotation);
            timer = spawnTime;
        }
	}
}
