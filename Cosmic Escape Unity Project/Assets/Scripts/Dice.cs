using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dice : MonoBehaviour
{
    private List<GameObject> diceFaces;
    private float timeSinceFaceChange;
    private int lastDiceFace;
    private bool hasRolled;

    private void Start()
    {
        hasRolled = false;

        diceFaces = new List<GameObject>();

        foreach(GameObject diceFace in GameObject.FindGameObjectsWithTag("Dice Face"))
        {
            diceFaces.Add(diceFace);
        }
    }

    private void Update()
    {
        Roll();
    }

    private void Roll()
    {
        if (hasRolled == false)
        {
            if (Input.GetButton("Xbox Y"))
            {
                LoopThroughDiceFaces();
            }
            if(hasRolled == true)
            {
                SelectRandomDiceFace();
            }
        }
    }

    private void SelectRandomDiceFace()
    {
        int randomDiceFace = Random.Range(0, diceFaces.Count - 1);
        diceFaces[0].GetComponent<Image>().enabled = false;
        diceFaces[1].GetComponent<Image>().enabled = false;
        diceFaces[2].GetComponent<Image>().enabled = false;
        diceFaces[3].GetComponent<Image>().enabled = false;
        diceFaces[4].GetComponent<Image>().enabled = false;
        diceFaces[5].GetComponent<Image>().enabled = false;
        diceFaces[randomDiceFace].GetComponent<Image>().enabled = true;
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
}
