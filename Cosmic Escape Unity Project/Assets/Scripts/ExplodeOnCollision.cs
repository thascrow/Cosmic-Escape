using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplodeOnCollision : MonoBehaviour
{
    [SerializeField] private string triggerObject;

    private void OnCollisionEnter(Collision collision)
    {
        if(collision != null)
        {
            if(collision.gameObject.name == triggerObject)
            {
                // trigger explosion

                Destroy(gameObject);
            }
        }
    }
}
