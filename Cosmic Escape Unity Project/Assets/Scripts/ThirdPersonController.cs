using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

[RequireComponent(typeof(CharacterController))]
public class ThirdPersonController : MonoBehaviour
{
    private CharacterController controller;
    private Vector3 playerVelocity;

    private Vector2 movementInput = Vector2.zero;
    private Vector2 rotationInput = Vector2.zero;

    [SerializeField] private float playerSpeed;
    [SerializeField] private float mouseSensitivity;
    public float fireRate;

    private void Start()
    {
        controller = gameObject.GetComponent<CharacterController>();
    }

    public void OnMove(Vector2 movement)
    {
        movementInput = movement;
    }

    public void OnRotate(Vector2 rotation)
    {
        rotationInput = rotation;
    }

    public void OnShoot(float triggerAmount)
    {
        fireRate = triggerAmount;
        GetComponent<LaserGun>().AutoFire();
    }

    void Update()
    {
        Vector3 move = new Vector3(movementInput.x, 0, movementInput.y);
        controller.Move(move * Time.deltaTime * playerSpeed);

        if(SceneManager.GetActiveScene().name != "Zorgon Mini Game")
        {
            if (move != Vector3.zero)
            {
                gameObject.transform.forward = move;
            }
        }
        
        controller.Move(playerVelocity * Time.deltaTime);

        Vector3 rotate = new Vector3(0, rotationInput.x, 0) * Time.deltaTime * mouseSensitivity;
        transform.Rotate(rotate);
    }

    /*
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
        }

        // rotate player based on inputs


    

    private void OnEnable()
    {
        inputActions.TPMovement.Enable();
    }

    private void OnDisable()
    {
        inputActions.TPMovement.Disable();
    }*/
}
