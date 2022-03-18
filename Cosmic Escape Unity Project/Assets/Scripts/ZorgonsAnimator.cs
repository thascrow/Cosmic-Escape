using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZorgonsAnimator : MonoBehaviour
{
    

    [SerializeField] CollectableItem Coll1, Coll2, Coll3, Coll4;
    private Vector3 lastPosition = new Vector3(0, 0, 0);
    AnimatorManager Anim;
    private void Start()
    {
        lastPosition = gameObject.transform.position;
        Anim = GameObject.Find("AnimatorManager").GetComponent<AnimatorManager>();
    }
    void Update()
    {



        if (lastPosition != gameObject.transform.position)
        {
            Anim.ZorgonsSetWalk();
        }

        if (lastPosition == gameObject.transform.position)
        {
            Anim.ZorgonsIdle();
        }

        lastPosition = gameObject.transform.position;


        if (Coll1.PickingUp == true || Coll2.PickingUp == true || Coll3.PickingUp == true || Coll4.PickingUp == true)
        {
            Anim.ZorgonsSetPickUp();
        }
    }
}
