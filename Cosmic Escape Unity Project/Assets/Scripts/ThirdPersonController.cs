using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class ThirdPersonController : MonoBehaviour
{
    [SerializeField] private CharacterController controller;
    private Vector2 move;
    private Vector2 rotate;
    [SerializeField] private float playerSpeed;
    [SerializeField] private float mouseSensitivity;
    public bool player1, player2, player3, player4;
    private PlayerControls inputActions;

    private void Awake()
    {
        inputActions = new PlayerControls();

        inputActions.TPMovement.Move.performed += ctx => move = ctx.ReadValue<Vector2>();
        inputActions.TPMovement.Move.canceled += ctx => move = Vector2.zero;

        inputActions.TPMovement.Rotate.performed += ctx => rotate = ctx.ReadValue<Vector2>();
        inputActions.TPMovement.Rotate.canceled += ctx => rotate = Vector2.zero;
    }

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        // move player based on inputs
        if (player1)
        {
            Vector3 velocity = new Vector3(move.x, 0, move.y) * Time.deltaTime;
            controller.Move(velocity * playerSpeed);

            Vector3 rotation = new Vector3(0, rotate.x, 0) * Time.deltaTime * mouseSensitivity;
            transform.Rotate(rotation);
        }
        
        if (player2)
        {
            Vector3 velocity2 = new Vector3(move.x, 0, move.y) * Time.deltaTime;
            controller.Move(velocity2 * playerSpeed);

            Vector3 rotation = new Vector3(0, rotate.x, 0) * Time.deltaTime * mouseSensitivity;
            transform.Rotate(rotation);
        }
        if (player3)
        {
            Vector3 move3 = new Vector3(Input.GetAxis("Horizontal3"), 0, Input.GetAxis("Vertical3"));
            controller.Move(move3 * Time.deltaTime * playerSpeed);
            controller.Move(playerVelocity * Time.deltaTime);
            float mouseX = Input.GetAxis("XRotation3") * mouseSensitivity * Time.deltaTime;
            float mouseY = Input.GetAxis("YRotation3") * mouseSensitivity * Time.deltaTime;

            gameObject.transform.Rotate(Vector3.up * mouseX);
            gameObject.transform.Rotate(Vector3.up * mouseY);
        }
        if (player4)
        {
            Vector3 move4 = new Vector3(Input.GetAxis("Horizontal4"), 0, Input.GetAxis("Vertical4"));
            controller.Move(move4* Time.deltaTime * playerSpeed);
            controller.Move(playerVelocity * Time.deltaTime);
            float mouseX = Input.GetAxis("XRotation4") * mouseSensitivity * Time.deltaTime;
            float mouseY = Input.GetAxis("YRotation4") * mouseSensitivity * Time.deltaTime;

            gameObject.transform.Rotate(Vector3.up * mouseX);
            gameObject.transform.Rotate(Vector3.up * mouseY);
        }

        if (Input.GetButton("YRotation1"))
        {
            print("Hello");
            print("Hello");
            print("Hello");
        }*/

        // rotate player based on inputs




    }

    private void OnEnable()
    {
        inputActions.TPMovement.Enable();
    }

    private void OnDisable()
    {
        inputActions.TPMovement.Disable();
    }
}
