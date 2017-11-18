﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunScript : MonoBehaviour {

    public float reloadTime = 1.3f;
    public float autofireTime = 0.2f;

    public bool canFireAuto = true;
    public int ammo = 30;
    public int clips = 10;
    public int clipSize = 30;

    public float bulletSpeed = 10.0f;

    float timeSinceLastFire = 0f;

    public Transform BulletSpawn;
    public GameObject Bullet;

    public bool isFiring = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if(Input.GetMouseButtonDown(0))
        {
            isFiring = true;
        }
        if(Input.GetMouseButtonUp(0))
        {
            isFiring = false;
        }
        if(!canFireAuto)
        {
            timeSinceLastFire += Time.deltaTime;
            if(timeSinceLastFire > autofireTime)
            {
                canFireAuto = true;
                timeSinceLastFire = 0;
            }
        }
        if(isFiring)
        {
            Fire();
        }
	}

    void Fire()
    {
        if(CanFire())
        {
            GameObject bullet = Instantiate(Bullet, BulletSpawn.transform.position, this.transform.rotation);
            bullet.GetComponent<Rigidbody>().velocity = this.transform.TransformVector(Vector3.forward) * bulletSpeed;
            canFireAuto = false;
            this.ammo--;
        }
    }

    void InitializeBullet()
    {

    }

    bool CanFire()
    {
        return canFireAuto && this.ammo > 0;
    }
}
