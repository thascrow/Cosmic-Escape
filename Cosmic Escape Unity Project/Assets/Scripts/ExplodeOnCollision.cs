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
            if ((collision.gameObject.name == triggerObject) || (collision.gameObject.tag == "Enemy") || (collision.gameObject.tag == "Player"))
            {
                Instantiate(explosionEffect, transform.position, transform.rotation);

                Destroy(gameObject);
            }
        }
    }

    private void Update()
    {
        Physics.IgnoreLayerCollision(3, 7);
    }
}
