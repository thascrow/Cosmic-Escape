using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BoardGameUIManager : MonoBehaviour
{
    [SerializeField] public GameObject player1HousePointsUI;
    [SerializeField] public GameObject player2HousePointsUI;
    [SerializeField] public GameObject player3HousePointsUI;
    [SerializeField] public GameObject player4HousePointsUI;

    public void UpdateSelectedCurrentPlayer(int playerSwitchingTo)
    {
        switch (playerSwitchingTo)
        {
            case 1:
                player1HousePointsUI.GetComponent<Image>().enabled = true;
                player2HousePointsUI.GetComponent<Image>().enabled = false;
                player3HousePointsUI.GetComponent<Image>().enabled = false;
                player4HousePointsUI.GetComponent<Image>().enabled = false;
                break;
            case 2:
                player1HousePointsUI.GetComponent<Image>().enabled = false;
                player2HousePointsUI.GetComponent<Image>().enabled = true;
                player3HousePointsUI.GetComponent<Image>().enabled = false;
                player4HousePointsUI.GetComponent<Image>().enabled = false; 
                break;
            case 3:
                player1HousePointsUI.GetComponent<Image>().enabled = false;
                player2HousePointsUI.GetComponent<Image>().enabled = false;
                player3HousePointsUI.GetComponent<Image>().enabled = true;
                player4HousePointsUI.GetComponent<Image>().enabled = false; 
                break;
            case 4:
                player1HousePointsUI.GetComponent<Image>().enabled = false;
                player2HousePointsUI.GetComponent<Image>().enabled = false;
                player3HousePointsUI.GetComponent<Image>().enabled = false;
                player4HousePointsUI.GetComponent<Image>().enabled = true; 
                break;
        }
    }
}
