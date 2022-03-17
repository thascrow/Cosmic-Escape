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
    [SerializeField] private float damage;
    [SerializeField] private GameManager gameManager;
    ThirdPersonController tp;

    private void Start()
    {
        tp = GetComponent<ThirdPersonController>();
    }
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
        shot = Instantiate(bullet, this.bulletSpawn.position, bulletSpawn.rotation);
        shot.velocity = transform.forward * bulletSpeed;

        RaycastHit hit;

        if (Physics.Raycast(bulletSpawn.position, this.transform.forward, out hit))
        {
            if (hit.transform.tag == "Enemy")
            {
                hit.transform.GetComponent<DamagableCharacter>().DeductHealth(damage);
                gameManager.points += damage;
            }
        }

        ammo -= 1;
    }

    public void AutoFire()
    {
        autoFireTimer += Time.deltaTime;

        if (Input.GetButton("Fire1") && tp.player1 )
        {
            print("Hello");
            if (autoFireTimer > fireRate)
            {
                this.FireShot();
                autoFireTimer = 0f;
            }
        }
        if (Input.GetKeyDown(KeyCode.Joystick2Button1))
        {
            if (autoFireTimer > fireRate)
            {
                this.FireShot();
                autoFireTimer = 0f;
            }
        }
    }
}
