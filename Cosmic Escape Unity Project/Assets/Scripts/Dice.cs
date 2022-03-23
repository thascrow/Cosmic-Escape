using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class Dice : MonoBehaviour
{
    private List<GameObject> diceFaces;
    private float timeSinceFaceChange;
    private int lastDiceFace;
    private PlayerControls inputActions;
    private bool hasRolled;
    private bool beginRoll;
    private bool selectedDiceFace;

    private void Awake()
    {
        inputActions = new PlayerControls();

        inputActions.BoardScene.RollDice.started += ctx => BeginRoll();
        inputActions.BoardScene.RollDice.canceled += ctx => SelectRandomDiceFace();
    }

    void BeginRoll()
    {
        if (!hasRolled)
        {
            beginRoll = true;
            hasRolled = true;
        }
    }

    private void Update()
    {
        if (beginRoll)
        {
            Roll();
        }
    }

    void Roll()
    {
        LoopThroughDiceFaces();
    }

    private void Start()
    {
        diceFaces = new List<GameObject>();

        foreach(GameObject diceFace in GameObject.FindGameObjectsWithTag("Dice Face"))
        {
            diceFaces.Add(diceFace);
        }
    }

    private void SelectRandomDiceFace()
    {
        if (!selectedDiceFace)
        {
            beginRoll = false;

            int randomDiceFace = Random.Range(0, diceFaces.Count - 1);
            diceFaces[0].GetComponent<Image>().enabled = false;
            diceFaces[1].GetComponent<Image>().enabled = false;
            diceFaces[2].GetComponent<Image>().enabled = false;
            diceFaces[3].GetComponent<Image>().enabled = false;
            diceFaces[4].GetComponent<Image>().enabled = false;
            diceFaces[5].GetComponent<Image>().enabled = false;
            diceFaces[randomDiceFace].GetComponent<Image>().enabled = true;

            selectedDiceFace = true;
        }
        
    }

    private void LoopThroughDiceFaces()
    {
        timeSinceFaceChange += Time.deltaTime;

        if (timeSinceFaceChange >= .1f)
        {
            timeSinceFaceChange = 0;
            if (lastDiceFace == 5)
            {
                diceFaces[lastDiceFace].GetComponent<Image>().enabled = false;
                diceFaces[0].GetComponent<Image>().enabled = true;
                lastDiceFace = 0;
            }
            else if (lastDiceFace != 0)
            {
                diceFaces[lastDiceFace].GetComponent<Image>().enabled = false;
                diceFaces[lastDiceFace + 1].GetComponent<Image>().enabled = true;
                lastDiceFace += 1;
            }
            else
            {
                diceFaces[diceFaces.Count - 1].GetComponent<Image>().enabled = false;
                diceFaces[0].GetComponent<Image>().enabled = true;
                lastDiceFace += 1;
            }
        }
    }

    private void OnEnable()
    {
        inputActions.BoardScene.Enable();
    }

    private void OnDisable()
    {
        inputActions.BoardScene.Disable();
    }
}
