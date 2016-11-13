﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileNova : MonoBehaviour {

    public int numberOfProjectiles;
    public GameObject prefab;
    public GameObject fireFrom;
    public float projectileVelocity;
    public float fireDelay;
    public float fireRate;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        //Decrement timer until its time to fire
        if (fireDelay > 1.0)
        {
            fireDelay -= Time.deltaTime;
        }
        //Fire
        else
        {
            Vector3 center = transform.position;
            for (int i = 0; i < numberOfProjectiles; i++)
            {

                Vector3 pos = getProjectilePosition(center, i, 2.0f);

                //Get the rotation each projectile should have
                Quaternion rot = Quaternion.FromToRotation(Vector3.forward, pos - center);

                //Instantiate each projectile and give a velocity in each's forward direction
                GameObject projectile = Instantiate(prefab, pos, rot);
                Rigidbody rigidbody = projectile.GetComponent<Rigidbody>();
                rigidbody.velocity = projectile.transform.forward * projectileVelocity;
            }
            //Reset the fire timer
            fireDelay += fireRate;
        }
    }

    //Calculate the position of each projectile around the character
    Vector3 getProjectilePosition(Vector3 center, int count, float r)
    {
        Vector3 position;
        float ang = 360 / numberOfProjectiles * count;
        position.x = center.x + r * Mathf.Sin(ang * Mathf.Deg2Rad);
        position.y = center.y;
        position.z = center.z + r * Mathf.Cos(ang * Mathf.Deg2Rad);
        return position;
    }
}