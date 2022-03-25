using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LazerGunPlayer2 : MonoBehaviour
{
    [SerializeField] private Rigidbody bullet;
    [SerializeField] private float bulletSpeed = 30f;
    [SerializeField] private Transform bulletSpawn;
    private float autoFireTimer = 0f;
    [SerializeField] private int ammo;
    [SerializeField] private float fireRate;
    [SerializeField] private float damage;
    [SerializeField] private GameManager gameManager;
    [SerializeField] private ThirdPersonController tp;

    private void Start()
    {
        tp = GetComponent<ThirdPersonController>();
    }
    private void Update()
    {
        if (ammo > 0)
        {
            AutoFire();
        }

    }
    void ShotObject()
    {
        Rigidbody shot;
        shot = Instantiate(bullet, bulletSpawn.position, bulletSpawn.rotation);
        shot.velocity = transform.forward * bulletSpeed;

        RaycastHit hit;

        if (Physics.Raycast(bulletSpawn.position, transform.forward, out hit))
        {
            if (hit.transform.tag == "Enemy")
            {
                hit.transform.GetComponent<DamagableCharacter>().DeductHealth(damage, gameObject);
                gameManager.points += damage;
            }
        }
    }
    void AutoFire()
    {
        autoFireTimer += Time.deltaTime;
        if (Input.GetButton("Fire2"))
        {
            if (autoFireTimer > fireRate)
            {
                ShotObject();
                autoFireTimer = 0f;
                ammo -= 1;
            }
        }
    }
}