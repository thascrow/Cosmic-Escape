using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BoardUIManager : MonoBehaviour
{
    [SerializeField] public GameObject player1HousePointsUI;
    [SerializeField] public GameObject player2HousePointsUI;
    [SerializeField] public GameObject player3HousePointsUI;
    [SerializeField] public GameObject player4HousePointsUI;
    [SerializeField] public Text player1HousePoints;
    [SerializeField] public Text player2HousePoints;
    [SerializeField] public Text player3HousePoints;
    [SerializeField] public Text player4HousePoints;
    [SerializeField] public GameObject diceRollScreenTitle;
    [SerializeField] public GameObject diceRollHint;
    [SerializeField] public GameObject diceRolledText;
    [SerializeField] public GameObject diceRollScreen;
    [SerializeField] public GameObject beginGameText;
    [SerializeField] public GameObject turnCompleteText;
    [SerializeField] public GameObject cardScreen;
    [SerializeField] public GameObject cardScreenTitle;
    [SerializeField] public GameObject card3Hint;
    [SerializeField] public GameObject card2Hint;
    [SerializeField] public GameObject card1Hint;
    [SerializeField] public GameObject cardScreenContinueText;
    [SerializeField] public List<GameObject> cardSelectionHints;
    [SerializeField] public GameObject card3LosePrompt;
    [SerializeField] public GameObject card3WinPrompt;
    [SerializeField] public List<Image> cardImages;
    [SerializeField] public Image card1Placeholder, card2Placeholder, card3Placeholder, cardPlaceholder;

    public void UpdateSelectedCurrentPlayer(int playerSwitchingTo)
    {
        switch (playerSwitchingTo)
        {
            case 1:
                player1HousePointsUI.GetComponent<Image>().enabled = true;
                player2HousePointsUI.GetComponent<Image>().enabled = false;
                player3HousePointsUI.GetComponent<Image>().enabled = false;
                player4HousePointsUI.GetComponent<Image>().enabled = false;
                diceRollScreenTitle.GetComponent<TMP_Text>().text = "Player 1's Turn to Roll";
                cardScreenTitle.GetComponent<TMP_Text>().text = "Choose a Card, Player 1";
                break;
            case 2:
                player1HousePointsUI.GetComponent<Image>().enabled = false;
                player2HousePointsUI.GetComponent<Image>().enabled = true;
                player3HousePointsUI.GetComponent<Image>().enabled = false;
                player4HousePointsUI.GetComponent<Image>().enabled = false;
                diceRollScreenTitle.GetComponent<TMP_Text>().text = "Player 2's Turn to Roll";
                cardScreenTitle.GetComponent<TMP_Text>().text = "Choose a Card, Player 2";
                break;
            case 3:
                player1HousePointsUI.GetComponent<Image>().enabled = false;
                player2HousePointsUI.GetComponent<Image>().enabled = false;
                player3HousePointsUI.GetComponent<Image>().enabled = true;
                player4HousePointsUI.GetComponent<Image>().enabled = false;
                diceRollScreenTitle.GetComponent<TMP_Text>().text = "Player 3's Turn to Roll";
                cardScreenTitle.GetComponent<TMP_Text>().text = "Choose a Card, Player 3";
                break;
            case 4:
                player1HousePointsUI.GetComponent<Image>().enabled = false;
                player2HousePointsUI.GetComponent<Image>().enabled = false;
                player3HousePointsUI.GetComponent<Image>().enabled = false;
                player4HousePointsUI.GetComponent<Image>().enabled = true;
                diceRollScreenTitle.GetComponent<TMP_Text>().text = "Player 4's Turn to Roll";
                cardScreenTitle.GetComponent<TMP_Text>().text = "Choose a Card, Player 4";
                break;
        }
    }
}
