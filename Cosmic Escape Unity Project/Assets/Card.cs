using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Card : MonoBehaviour
{
    [SerializeField] private List<Image> cardImages;
    [SerializeField] private Image card1Placeholder, card2Placeholder, card3Placeholder;
    [SerializeField] private List<GameObject> cards;
    private BoardUIManager boardUIManager;
    [SerializeField] private GameObject loseScreen;
    private GameManager gameManager;

    private Image randomCard1;
    private Image randomCard2;
    private Image randomCard3;

    private bool cardScreenShowing;

    private bool selected;

    private void OnCollisionEnter(Collision collision)
    {
        SelectRandomCards();
    }

    private void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        boardUIManager = GameObject.Find("UI Manager").GetComponent<BoardUIManager>();
    }

    private void Update()
    {
        if (cardScreenShowing)
        {
            if (Input.GetButtonDown("Xbox X"))
            {
                if (!selected)
                {
                    Card1Chosen();
                }
            }
            if (Input.GetButtonDown("Xbox A"))
            {
                if (!selected)
                {
                    Card2Chosen();
                }
            }
            if (Input.GetButtonDown("Xbox B"))
            {
                if (!selected)
                {
                    Card3Chosen();
                }
            }
        }
    }

    private void Card3Chosen()
    {
        switch (randomCard3.name)
        {
            case "Card 1":
                Card1Actions();
                break;
            case "Card 2":
                Card2Actions();
                break;
            case "Card 3":
                Card3Actions();
                break;
        }

        selected = true;
    }

    private void Card2Chosen()
    {
        switch (randomCard2.name)
        {
            case "Card 1":
                Card1Actions();
                break;
            case "Card 2":
                Card2Actions();
                break;
            case "Card 3":
                Card3Actions();
                break;
        }

        selected = true;
    }

    private void Card1Chosen()
    {

        switch (randomCard1.name)
        {
            case "Card 1":
                Card1Actions();
                break;
            case "Card 2":
                Card2Actions();
                break;
            case "Card 3":
                Card3Actions();
                break;
        }

        selected = true;
    }

    private void Card3Actions()
    {
        bool result = cards[3].GetComponent<CardActions>().ChanceToWinHousePiece();

        if (result)
        {
            switch (gameManager.currentPlayerTurn)
            {
                case 1:
                    gameManager.player1HousePoints++;
                    break;
                case 2:
                    gameManager.player2HousePoints++;
                    break;
                case 3:
                    gameManager.player3HousePoints++;
                    break;
                case 4:
                    gameManager.player4HousePoints++;
                    break;
            }
        }
        else
        {
            loseScreen.SetActive(true);
        }

        selected = true;
    }

    private void Card2Actions()
    {
        cards[2].GetComponent<CardActions>().MoveTwoSpacesLoseHousePiece();
    }

    private void Card1Actions()
    {
        cards[1].GetComponent<CardActions>().ExtraTurnLoseThreeHousePieces();
    }


    private void SelectRandomCards()
    {
        randomCard1 = cardImages[Random.Range(0, cardImages.Count - 1)];
        randomCard2 = cardImages[Random.Range(0, cardImages.Count - 1)];
        randomCard3 = cardImages[Random.Range(0, cardImages.Count - 1)];

        PresentCards();
    }

    private void PresentCards()
    {
        boardUIManager.cardScreen.SetActive(true);
        cardScreenShowing = true;

        card1Placeholder.sprite = randomCard1.sprite;
        card2Placeholder.sprite = randomCard2.sprite;
        card3Placeholder.sprite = randomCard3.sprite;
    }
}
