﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerController : MonoBehaviour {

    public Transform target;
    public float range =2f;

    public Transform partToRotate;
    public float turnSpeed=50f;

    public string enemyTag = "Enemy";

    public float fireRate=1f;
    private float fireCoutdown = 0f;

    public GameObject bulletPrefab;
    public Transform firePoint;


	// Use this for initialization
	void Start () {
        InvokeRepeating("UpdateTarget",0f,0.25f);
    }
	
	// Update is called once per frame
	void Update () {
        if (target == null)
            return;
        Vector3 dir = target.position - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(dir);
        Vector3 rotation = Quaternion.Lerp(partToRotate.rotation,lookRotation,Time.deltaTime).eulerAngles;
        partToRotate.rotation = Quaternion.Euler(0f, rotation.y, 0f);

        if (fireCoutdown <=0f)
        {
            Shoot();
            fireCoutdown = 1f / fireRate;
        }

        fireCoutdown -= Time.deltaTime;

	}

    void Shoot()
    {
        GameObject bulletGO = (GameObject)Instantiate(bulletPrefab,firePoint.position, firePoint.rotation);
        BulletConttroller bullet = bulletGO.GetComponent<BulletConttroller>();
        if (bullet != null)
            bullet.Seek(target);
        Debug.Log("Shoot");
    }

    void UpdateTarget()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);
        float shortestDistance = Mathf.Infinity;
        GameObject nearestEnemy = null;
        foreach (GameObject enemy in enemies)
        {
            float distanceToEnemy = Vector3.Distance(transform.position,enemy.transform.position);
            if (distanceToEnemy < shortestDistance)
            {
                shortestDistance = distanceToEnemy;
                nearestEnemy = enemy;
            }
        }
        if ( nearestEnemy != null && shortestDistance <= range)
        {
            target = nearestEnemy.transform;
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
