using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidDamage : MonoBehaviour
{
    [SerializeField] private DamagableCharacter damagableCharacter;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision != null)
        {
            if (collision.gameObject.tag == "Enemy")
            {
                damagableCharacter.DeductHealth(50, gameObject);
            }
        }
    }
}
