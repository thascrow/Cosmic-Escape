using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorManager : MonoBehaviour
{
    [SerializeField] Animator Child1;
    [SerializeField] Animator Child2;
    [SerializeField] Animator Astronaut;
    [SerializeField] Animator Zorgons;
    [SerializeField] Animator Robot;



    public void Child1SetWalk()
    {
        Child1.SetBool("Walk", true);
        Child1.SetBool("PickUp", false);
    }

    public void Child1SetPickUp()
    {
        Child1.SetBool("PickUp", true);
        Child1.SetBool("Walk", false);
    }

    public void Child1Idle()
    {
        Child1.SetBool("PickUp", false);
        Child1.SetBool("Walk", false);
    }

    //


    public void Child2SetWalk()
    {
        Child2.SetBool("Walk", true);
        Child2.SetBool("PickUp", false);
    }

    public void Child2SetPickUp()
    {
        Child2.SetBool("PickUp", true);
        Child2.SetBool("Walk", false);
    }

    public void Child2Idle()
    {
        Child2.SetBool("PickUp", false);
        Child2.SetBool("Walk", false);
    }


    // 

    public void RobotSetWalk()
    {
        Robot.SetBool("Walk", true);
        Robot.SetBool("PickUp", false);
    }

    public void RobotSetPickUp()
    {
        Robot.SetBool("PickUp", true);
        Robot.SetBool("Walk", false);
    }

    public void RobotIdle()
    {
        Robot.SetBool("PickUp", false);
        Robot.SetBool("Walk", false);
    }


    // 


    public void AstronautSetWalk()
    {
        Astronaut.SetBool("Walk", true);
        Astronaut.SetBool("PickUp", false);
    }

    public void AstronautSetPickUp()
    {
        Astronaut.SetBool("PickUp", true);
        Astronaut.SetBool("Walk", false);
    }

    public void AstronautIdle()
    {
        Astronaut.SetBool("PickUp", false);
        Astronaut.SetBool("Walk", false);
    }


    //


    public void ZorgonsSetWalk()
    {
        Zorgons.SetBool("Walk", true);
        Zorgons.SetBool("PickUp", false);
    }

    public void ZorgonsSetPickUp()
    {
        Zorgons.SetBool("PickUp", true);
        Zorgons.SetBool("Walk", false);
    }

    public void ZorgonsIdle()
    {
        Zorgons.SetBool("PickUp", false);
        Zorgons.SetBool("Walk", false);
    }
}
