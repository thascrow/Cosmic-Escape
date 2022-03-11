using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ThirdPersonController : MonoBehaviour
{
    [SerializeField] private CharacterController controller;
    private Vector3 playerVelocity;
    [SerializeField] private float playerSpeed;
    [SerializeField] private float mouseSensitivity;
    [SerializeField] bool player1, player2, player3, player4;
    
    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        // move player based on inputs
        if (player1)
        {
            Vector3 move1 = new Vector3(Input.GetAxis("Horizontal1"), 0, Input.GetAxis("Vertical1"));
            controller.Move(-move1 * Time.deltaTime * playerSpeed);
            controller.Move(-playerVelocity * Time.deltaTime);
            float mouseX = Input.GetAxis("XRotation1") * mouseSensitivity * Time.deltaTime;
            float mouseY = Input.GetAxis("YRotation1") * mouseSensitivity * Time.deltaTime;
            gameObject.transform.Rotate(Vector3.up * mouseX);
            gameObject.transform.Rotate(Vector3.up * mouseY);

        }
        /*
        if (player2)
        {
            Vector3 move2 = new Vector3(Input.GetAxis("Horizontal2"), 0, Input.GetAxis("Vertical2"));
            controller.Move(move2 * Time.deltaTime * playerSpeed);
            controller.Move(-playerVelocity * Time.deltaTime);

        }
        */
        if (Input.GetButton("XRotation1"))
        {
            print("Hello");
            print("Hello");
        }

        if (Input.GetButton("YRotation1"))
        {
            print("Hello");
            print("Hello");
            print("Hello");
        }




        // rotate player based on inputs
        

        
    } 
}
