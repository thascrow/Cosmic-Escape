using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZorgonDamage : MonoBehaviour
{
    [SerializeField] private DamagableCharacter damagableCharacter;
    private float timeAttackingFor;

    private void OnTriggerEnter(Collider collider)
    {
        if(collider != null)
        {
            if(collider.tag == "Enemy")
            {
                damagableCharacter.DeductHealth(10, collider.gameObject);
            }
        }
    }

    private void OnTriggerStay(Collider collider)
    {
        if (collider != null)
        {
            if (collider.tag == "Enemy")
            {
                timeAttackingFor += Time.deltaTime;

                damagableCharacter.DeductHealth(timeAttackingFor, collider.gameObject);
            }
        }
    }
}
