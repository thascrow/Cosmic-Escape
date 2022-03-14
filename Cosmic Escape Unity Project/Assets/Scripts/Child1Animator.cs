using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Child1Animator : MonoBehaviour
{

    [SerializeField] CharacterController controller;
    // Update is called once per frame
    void Update()
    {

        
        AnimatorManager Anim = new AnimatorManager();
        CollectableItem Coll = new CollectableItem();
        Debug.Log(Coll.PickingUp);
        if (controller.velocity.x > 0 & controller.velocity.z > 0 & controller.velocity.x < 0 & controller.velocity.z < 0)
        {
            Anim.Child1SetWalk();
        }

        if (controller.velocity.x == 0 & controller.velocity.z == 0)
        {
            Anim.Child1Idle();
        }

        if (Coll.PickingUp == true)
        {
            Anim.Child1SetPickUp();
        }
    }
}
