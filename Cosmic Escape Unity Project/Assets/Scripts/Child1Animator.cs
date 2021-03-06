using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Child1Animator : MonoBehaviour
{

    [SerializeField] CharacterController controller;

    AnimatorManager Anim;

    [SerializeField] CollectableItem Coll1, Coll2, Coll3, Coll4;
    // Update is called once per frame
    private Vector3 lastPosition = new Vector3(0, 0, 0);
    private void Start()
    {
        lastPosition = gameObject.transform.position;
        Anim = GameObject.Find("AnimatorManager").GetComponent<AnimatorManager>();
    }
    void Update()
    {

        
        
       if (lastPosition != gameObject.transform.position)
        {
            Anim.Child1SetWalk();
        }

       if (lastPosition == gameObject.transform.position)
        {
            Anim.Child1Idle();
        }

        lastPosition = gameObject.transform.position;
        

        if (Coll1.PickingUp == true || Coll2.PickingUp == true || Coll3.PickingUp == true || Coll4.PickingUp == true)
        {
            Anim.Child1SetPickUp();
        }
    }
}
