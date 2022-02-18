using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserGun : MonoBehaviour
{
    [SerializeField] private Rigidbody bullet;
    [SerializeField] private float bulletSpeed = 30f;
    [SerializeField] private Transform bulletSpawn;
    private float autoFireTimer = 0f;
    [SerializeField] private int ammo;
    [SerializeField] private float fireRate;

    // Update is called once per frame
    void Update()
    {
        if(ammo > 0)
        {
            AutoFire();
        }
    }

    void FireShot()
    {
        Rigidbody shot;
        shot = Instantiate(bullet, bulletSpawn.position, bulletSpawn.rotation);
        shot.velocity = transform.forward * bulletSpeed;
        ammo -= 1;
    }

    public void AutoFire()
    {
        autoFireTimer += Time.deltaTime;

        if (Input.GetMouseButton(0))
        {
            if (autoFireTimer > fireRate)
            {
                FireShot();
                autoFireTimer = 0f;
            }
        }
    }
}
