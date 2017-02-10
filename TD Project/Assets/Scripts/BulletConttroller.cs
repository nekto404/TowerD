﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletConttroller : MonoBehaviour {


    private Transform target;
    public float speed = 7f;
    public GameObject impactEffect;

    public void Seek (Transform _target)
    {
        target = _target;
    }
        
	void Update () {
		if (target == null)
        {
            Destroy(gameObject);
            return;
        }
        Vector3 dir = target.position - transform.position;
        float distanceThisFrame = speed * Time.deltaTime;

        if (dir.magnitude <= distanceThisFrame)
        {
            HitTarget();
            return;
        }

        transform.Translate(dir.normalized * distanceThisFrame, Space.World);
	}

    void HitTarget()
    {
        GameObject effectIns = Instantiate(impactEffect, transform.position, transform.rotation);
        Destroy(effectIns,1F);
        Destroy(gameObject);
    }
}
