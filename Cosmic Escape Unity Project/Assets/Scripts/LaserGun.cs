using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserGun : MonoBehaviour
{
    [SerializeField] private Rigidbody bullet;
    [SerializeField] private float bulletSpeed = 30f;
    [SerializeField] private Transform bulletSpawn;
    private float autoFireTimer;
    [SerializeField] private float damage;
    [SerializeField] private GameManager gameManager;

    private void Update()
    {
        if(GetComponent<ThirdPersonController>().fireRate > 0)
        {
            AutoFire();
        }
    }

    private void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }

    void FireShot()
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

    public void AutoFire()
    {
        if (autoFireTimer < GetComponent<ThirdPersonController>().fireRate)
        {
            FireShot();
            autoFireTimer = 1f;
        }
        autoFireTimer -= Time.deltaTime;
    }
}
