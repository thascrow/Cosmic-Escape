using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Child1Animator : MonoBehaviour
{

    [SerializeField] CharacterController controller;

    [SerializeField] CollectableItem Coll1, Coll2, Coll3, Coll4;
    // Update is called once per frame
    void Update()
    {

        
        AnimatorManager Anim = new AnimatorManager();
        
        
        if (controller.velocity.x > 0 && controller.velocity.z > 0 && controller.velocity.x < 0 && controller.velocity.z < 0)
        {
            Anim.Child1SetWalk();
        } 

        if (controller.velocity.x == 0 & controller.velocity.z == 0)
        {
            Anim.Child1Idle();
        }

        if (Coll1.PickingUp == true || Coll2.PickingUp == true || Coll3.PickingUp == true || Coll4.PickingUp == true)
        {
            Anim.Child1SetPickUp();
        }
    }
}
