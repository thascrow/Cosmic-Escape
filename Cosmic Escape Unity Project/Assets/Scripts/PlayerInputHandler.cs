using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputHandler : MonoBehaviour
{
    private ThirdPersonController thirdPersonPlayer1, thirdPersonPlayer2, thirdPersonPlayer3, thirdPersonPlayer4;
    [SerializeField] private List<GameObject> playerPrefabs;

    // Start is called before the first frame update
    void Start()
    {
        thirdPersonPlayer1 = GameObject.Find(playerPrefabs[0].name).GetComponent<ThirdPersonController>();
        thirdPersonPlayer2 = GameObject.Find(playerPrefabs[1].name).GetComponent<ThirdPersonController>();
        thirdPersonPlayer3 = GameObject.Find(playerPrefabs[2].name).GetComponent<ThirdPersonController>();
        thirdPersonPlayer4 = GameObject.Find(playerPrefabs[3].name).GetComponent<ThirdPersonController>();
    }

    public void Move(InputAction.CallbackContext context)
    {
        if (thirdPersonPlayer1)
        {
            thirdPersonPlayer1.OnMove(context.ReadValue<Vector2>());
        }
        else if (thirdPersonPlayer2)
        {
            thirdPersonPlayer2.OnMove(context.ReadValue<Vector2>());
        }
        else if (thirdPersonPlayer3)
        {
            thirdPersonPlayer3.OnMove(context.ReadValue<Vector2>());
        }
        else if (thirdPersonPlayer4)
        {
            thirdPersonPlayer4.OnMove(context.ReadValue<Vector2>());
        }
    }

    public void Rotate(InputAction.CallbackContext context)
    {
        if (thirdPersonPlayer1)
        {
            thirdPersonPlayer1.OnRotate(context.ReadValue<Vector2>());
        }
        else if (thirdPersonPlayer2)
        {
            thirdPersonPlayer2.OnRotate(context.ReadValue<Vector2>());
        }
        else if (thirdPersonPlayer3)
        {
            thirdPersonPlayer3.OnRotate(context.ReadValue<Vector2>());
        }
        else if (thirdPersonPlayer4)
        {
            thirdPersonPlayer4.OnRotate(context.ReadValue<Vector2>());
        }
    }

    public void Shoot(InputAction.CallbackContext context)
    {
        if (thirdPersonPlayer1)
        {
            thirdPersonPlayer1.OnShoot(context.ReadValue<float>());
        }
        else if (thirdPersonPlayer2)
        {
            thirdPersonPlayer2.OnShoot(context.ReadValue<float>());
        }
        else if (thirdPersonPlayer3)
        {
            thirdPersonPlayer3.OnShoot(context.ReadValue<float>());
        }
        else if (thirdPersonPlayer4)
        {
            thirdPersonPlayer4.OnShoot(context.ReadValue<float>());
        }
    }
}
