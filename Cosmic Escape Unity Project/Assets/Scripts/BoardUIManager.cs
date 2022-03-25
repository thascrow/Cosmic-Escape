using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BoardUIManager : MonoBehaviour
{
    [SerializeField] public GameObject player1HousePointsUI;
    [SerializeField] public GameObject player2HousePointsUI;
    [SerializeField] public GameObject player3HousePointsUI;
    [SerializeField] public GameObject player4HousePointsUI;
    [SerializeField] public GameObject diceRollScreenTitle;
    [SerializeField] public GameObject diceRollHint;
    [SerializeField] public GameObject diceRolledText;
    [SerializeField] public GameObject diceRollScreen;
    [SerializeField] public GameObject beginGameText;
    [SerializeField] public GameObject cardScreen;
    [SerializeField] public GameObject cardScreenTitle;


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
                diceRollScreenTitle.GetComponent<TextMesh>().text = "Player 2's Turn to Roll";
                cardScreenTitle.GetComponent<TMP_Text>().text = "Choose a Card, Player 2";
                break;
            case 3:
                player1HousePointsUI.GetComponent<Image>().enabled = false;
                player2HousePointsUI.GetComponent<Image>().enabled = false;
                player3HousePointsUI.GetComponent<Image>().enabled = true;
                player4HousePointsUI.GetComponent<Image>().enabled = false;
                diceRollScreenTitle.GetComponent<TextMesh>().text = "Player 3's Turn to Roll";
                cardScreenTitle.GetComponent<TMP_Text>().text = "Choose a Card, Player 3";
                break;
            case 4:
                player1HousePointsUI.GetComponent<Image>().enabled = false;
                player2HousePointsUI.GetComponent<Image>().enabled = false;
                player3HousePointsUI.GetComponent<Image>().enabled = false;
                player4HousePointsUI.GetComponent<Image>().enabled = true;
                diceRollScreenTitle.GetComponent<TextMesh>().text = "Player 4's Turn to Roll";
                cardScreenTitle.GetComponent<TMP_Text>().text = "Choose a Card, Player 4";
                break;
        }
    }
}
