using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Card : MonoBehaviour
{
    [SerializeField] private List<Image> cardImages;
    [SerializeField] private Image card1Placeholder, card2Placeholder, card3Placeholder, cardPlaceholder;
    [SerializeField] private List<GameObject> cards;
    private BoardUIManager boardUIManager;
    private GameManager gameManager;

    private Image randomCard1;
    private Image randomCard2;
    private Image randomCard3;

    private bool cardScreenShowing;
    private bool continueToCardAction;
    private bool selected;
    private bool card3Continue;
    private bool card2Continue;
    private bool card1Continue;

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
                    Card1Chosen(false);
                }
                if (continueToCardAction)
                {
                    foreach (GameObject hint in boardUIManager.cardSelectionHints)
                    {
                        hint.SetActive(false);
                    }
                    boardUIManager.cardScreenContinueText.SetActive(true);
                    Card1Chosen(true);
                }
            }
            if (Input.GetButtonDown("Xbox A"))
            {
                if (!selected)
                {
                    Card2Chosen(false);
                }
                if (continueToCardAction)
                {
                    foreach (GameObject hint in boardUIManager.cardSelectionHints)
                    {
                        hint.SetActive(false);
                    }
                    boardUIManager.cardScreenContinueText.SetActive(true);
                    Card2Chosen(true);
                }

                // generic actions mapped to A button
                if (card3Continue)
                {
                    Card3Actions(true);
                }
                if (card2Continue)
                {
                    Card2Actions(true);
                }
                if (card1Continue)
                {
                    Card1Actions(true);
                }
            }
            if (Input.GetButtonDown("Xbox B"))
            {
                if (!selected)
                {
                    Card3Chosen(false);
                }
                if (continueToCardAction)
                {
                    foreach (GameObject hint in boardUIManager.cardSelectionHints)
                    {
                        hint.SetActive(false);
                    }
                    boardUIManager.cardScreenContinueText.SetActive(true);
                    Card3Chosen(true);
                }
            }
        }
    }

    IEnumerator ExecuteAfterTime(float time)
    {
        yield return new WaitForSeconds(time);

        ResetCardScreen();
    }

    private void ResetCardScreen()
    {
        boardUIManager.cardScreen.SetActive(false);
        card1Placeholder.sprite = cardPlaceholder.sprite;
        card2Placeholder.sprite = cardPlaceholder.sprite;
        card3Placeholder.sprite = cardPlaceholder.sprite;
        foreach(GameObject hint in boardUIManager.cardSelectionHints)
        {
            hint.SetActive(true);
        }
        boardUIManager.card3LosePrompt.SetActive(false);
        boardUIManager.card3WinPrompt.SetActive(false);
        boardUIManager.cardScreenContinueText.SetActive(false);
        boardUIManager.card2Hint.SetActive(false);
        cardScreenShowing = false;
        continueToCardAction = false;
        selected = false;
        card3Continue = false;
        card2Continue = false;
        card1Continue = false;

        gameManager.SwitchPlayerTurn(gameManager.currentPlayerTurn + 1);
    }

    private void Card3Chosen(bool next)
    {
        selected = true;

        if (!next)
        {
            card3Placeholder.sprite = randomCard3.sprite;

            continueToCardAction = true;
        }

        if (next)
        {
            switch (randomCard3.name)
            {
                case "Card 1":
                    Card1Actions(false);
                    break;
                case "Card 2":
                    Card2Actions(false);
                    break;
                case "Card 3":
                    Card3Actions(false);
                    break;
            }
        }
    }

    private void Card2Chosen(bool next)
    {
        selected = true;

        if (!next)
        {
            card2Placeholder.sprite = randomCard2.sprite;

            continueToCardAction = true;
        }

        if (next)
        {
            switch (randomCard2.name)
            {
                case "Card 1":
                    Card1Actions(false);
                    break;
                case "Card 2":
                    Card2Actions(false);
                    break;
                case "Card 3":
                    Card3Actions(false);
                    break;
            }
        }
    }

    private void Card1Chosen(bool next)
    {
        selected = true;

        if (!next)
        {
            card1Placeholder.sprite = randomCard1.sprite;

            continueToCardAction = true;
        }

        if (next)
        {
            switch (randomCard1.name)
            {
                case "Card 1":
                    Card1Actions(false);
                    break;
                case "Card 2":
                    Card2Actions(false);
                    break;
                case "Card 3":
                    Card3Actions(false);
                    break;
            }
        }
    }

    private void Card3Actions(bool next)
    {
        if (!next)
        {
            boardUIManager.cardScreenContinueText.SetActive(false);
            boardUIManager.card3Hint.SetActive(true);

            card3Continue = true;
        }

        if (next)
        {
            boardUIManager.card3Hint.SetActive(false);

            bool result = cards[2].GetComponent<CardActions>().ChanceToWinHousePiece();

            if (result)
            {
                boardUIManager.card3WinPrompt.SetActive(true);

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
                boardUIManager.card3LosePrompt.SetActive(true);
            }
            StartCoroutine(ExecuteAfterTime(3));
        }
    }

    private void Card2Actions(bool next)
    {
        if (!next)
        {
            boardUIManager.cardScreenContinueText.SetActive(false);
            boardUIManager.card2Hint.SetActive(true);

            card2Continue = true;
        }
        if (next)
        {
            MoveTwoSpacesLoseHousePiece();

            boardUIManager.card2Hint.GetComponent<TMP_Text>().text = "You've advanced two spaces at the cost of a house piece.";

            StartCoroutine(ExecuteAfterTime(3));
        }
    }

    private void Card1Actions(bool next)
    {
        if (!next)
        {
            boardUIManager.cardScreenContinueText.SetActive(false);
            boardUIManager.card1Hint.SetActive(true);

            card1Continue = true;
        }
        if (next)
        {
            //ExtraTurnLoseThreeHousePieces();

            boardUIManager.card1Hint.SetActive(false);
            StartCoroutine(ExecuteAfterTime(3));
        }

        
    }

    public void ExtraTurnLoseThreeHousePieces()
    {
        switch (gameManager.currentPlayerTurn)
        {
            case 1:
                if(gameManager.player1HousePoints >= 3)
                {
                    gameManager.player1HousePoints -= 3;
                    gameManager.ReDoDice(gameManager.currentPlayerTurn);
                }
                else
                {
                    boardUIManager.card1Hint.SetActive(true);
                    boardUIManager.card1Hint.GetComponent<TMP_Text>().text = "You don't have enough house points.";
                }
                break;
            case 2:
                if (gameManager.player2HousePoints >= 3)
                {
                    gameManager.player2HousePoints -= 3;
                    gameManager.ReDoDice(gameManager.currentPlayerTurn);
                }
                else
                {
                    boardUIManager.card1Hint.SetActive(true);
                    boardUIManager.card1Hint.GetComponent<TMP_Text>().text = "You don't have enough house points.";
                }
                break;
            case 3:
                if (gameManager.player3HousePoints >= 3)
                {
                    gameManager.player3HousePoints -= 3;
                    gameManager.ReDoDice(gameManager.currentPlayerTurn);
                }
                else
                {
                    boardUIManager.card1Hint.SetActive(true);
                    boardUIManager.card1Hint.GetComponent<TMP_Text>().text = "You don't have enough house points.";
                }
                break;
            case 4:
                if (gameManager.player4HousePoints >= 3)
                {
                    gameManager.player4HousePoints -= 3;
                    gameManager.ReDoDice(gameManager.currentPlayerTurn);
                }
                else
                {
                    boardUIManager.card1Hint.SetActive(true);
                    boardUIManager.card1Hint.GetComponent<TMP_Text>().text = "You don't have enough house points.";
                }
                break;
        }
    }

    private void MoveTwoSpacesLoseHousePiece()
    {
        switch (gameManager.currentPlayerTurn)
        {
            case 1:
                if(gameManager.player1HousePoints > 0)
                {
                    gameManager.AdvancePlayerOnBoard(2);
                    gameManager.player1HousePoints--;
                }
                break;
            case 2:
                if (gameManager.player2HousePoints > 0)
                {
                    gameManager.AdvancePlayerOnBoard(2);
                    gameManager.player2HousePoints--;
                }
                break;
            case 3:
                if (gameManager.player3HousePoints > 0)
                {
                    gameManager.AdvancePlayerOnBoard(2);
                    gameManager.player3HousePoints--;
                }
                break;
            case 4:
                if (gameManager.player4HousePoints > 0)
                {
                    gameManager.AdvancePlayerOnBoard(2);
                    gameManager.player4HousePoints--;
                }
                break;
        }
    }

    private void SelectRandomCards()
    {
        cardImages = boardUIManager.cardImages;
        card1Placeholder = boardUIManager.card1Placeholder;
        card2Placeholder = boardUIManager.card2Placeholder;
        card3Placeholder = boardUIManager.card3Placeholder;
        cardPlaceholder = boardUIManager.cardPlaceholder;

        randomCard1 = cardImages[Random.Range(0, cardImages.Count)];
        randomCard2 = cardImages[Random.Range(0, cardImages.Count)];
        randomCard3 = cardImages[Random.Range(0, cardImages.Count)];

        print(randomCard1.name + randomCard2.name + randomCard3.name);

        PresentCards();
    }

    private void PresentCards()
    {
        boardUIManager.cardScreen.SetActive(true);
        cardScreenShowing = true;
    }
}
