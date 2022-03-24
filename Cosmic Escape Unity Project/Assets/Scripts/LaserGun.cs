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
    [SerializeField] private ThirdPersonController tp;

    // Update is called once per frame
    void Update()
    {
        if(ammo > 0)
        {
            AutoFire();
        }
    }

    void FireShot(int playerNum)
    {
        switch (playerNum)
        {
            case 1:
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
                break;

            case 2:
                Rigidbody shot2;
                shot2 = Instantiate(bullet, bulletSpawn.position, bulletSpawn.rotation);
                shot2.velocity = transform.forward * bulletSpeed;

                RaycastHit hit2;

                if (Physics.Raycast(bulletSpawn.position, transform.forward, out hit2))
                {
                    if (hit2.transform.tag == "Enemy")
                    {
                        hit2.transform.GetComponent<DamagableCharacter>().DeductHealth(damage, gameObject);
                        gameManager.points += damage;
                    }
                }
                break;
            case 3:
                Rigidbody shot3;
                shot3 = Instantiate(bullet, bulletSpawn.position, bulletSpawn.rotation);
                shot3.velocity = transform.forward * bulletSpeed;

                RaycastHit hit3;

                if (Physics.Raycast(bulletSpawn.position, transform.forward, out hit3))
                {
                    if (hit3.transform.tag == "Enemy")
                    {
                        hit3.transform.GetComponent<DamagableCharacter>().DeductHealth(damage, gameObject);
                        gameManager.points += damage;
                    }
                }
                break;
            case 4:
                Rigidbody shot4;
                shot4 = Instantiate(bullet, bulletSpawn.position, bulletSpawn.rotation);
                shot4.velocity = transform.forward * bulletSpeed;

                RaycastHit hit4;

                if (Physics.Raycast(bulletSpawn.position, transform.forward, out hit4))
                {
                    if (hit4.transform.tag == "Enemy")
                    {
                        hit4.transform.GetComponent<DamagableCharacter>().DeductHealth(damage, gameObject);
                        gameManager.points += damage;
                    }
                }
                break;
        }

        

        ammo -= 1;
    }

    public void AutoFire()
    {
        autoFireTimer += Time.deltaTime;
        if (tp.player1)
        {
            if (Input.GetButton("Fire1"))
            {
                if (autoFireTimer > fireRate)
                {
                    FireShot(1);
                    autoFireTimer = 0f;
                }
            }
        }
        if (tp.player2)
        {
            if (Input.GetButton("Fire2"))
            {
                if (autoFireTimer > fireRate)
                {
                    FireShot(2);
                    autoFireTimer = 0f;
                }
            }
        }
        if (tp.player3)
        {
            if (Input.GetButton("Fire3"))
            {
                if (autoFireTimer > fireRate)
                {
                    FireShot(3);
                    autoFireTimer = 0f;
                }
            }
        }
        if (tp.player4)
        {
            if (Input.GetButton("Fire4"))
            {
                if (autoFireTimer > fireRate)
                {
                    FireShot(4);
                    autoFireTimer = 0f;
                }
            }
        }
    }
}
