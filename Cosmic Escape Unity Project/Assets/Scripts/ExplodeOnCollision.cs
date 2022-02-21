using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplodeOnCollision : MonoBehaviour
{
    [SerializeField] private string triggerObject;
    [SerializeReference] private GameObject explosionEffect;

    private void OnCollisionEnter(Collision collision)
    {
        if(collision != null)
        {
            if ((collision.gameObject.name == triggerObject) || (collision.gameObject.tag == "Enemy"))
            {
                Instantiate(explosionEffect, transform.position, transform.rotation);

                Destroy(gameObject);
            }
        }
    }
}
