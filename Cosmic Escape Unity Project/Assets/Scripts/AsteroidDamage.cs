using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidDamage : MonoBehaviour
{
    [SerializeField] private DamagableCharacter damagableCharacter;

    private void OnTriggerEnter(Collider collider)
    {
        if (collider != null)
        {
            if (collider.tag == "Enemy")
            {
                damagableCharacter.DeductHealth(50);
            }
        }
    }
}
