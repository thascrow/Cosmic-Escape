using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Dice : MonoBehaviour
{
    [SerializeField] private List<GameObject> diceFaces;
    private bool hasRolled;
    private GameManager gameManager;
    private int rolledFace;

    private void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }

    private void Update()
    {
        if (Input.GetButtonDown("Xbox Y"))
        {
            if (!hasRolled)
            {
                Roll();
                hasRolled = true;

                if (!gameManager.testingCards)
                {
                    gameManager.DiceRolled(rolledFace);
                    hasRolled = false;
                    //Destroy(gameObject);
                }
                else
                {
                    gameManager.DiceRolled(1);
                    Destroy(gameObject);
                }
            }
        }
    }

    private void Roll()
    {
        int randomDiceFace = Random.Range(0, diceFaces.Count - 1);
        diceFaces[randomDiceFace].GetComponent<Image>().enabled = true;

        rolledFace = randomDiceFace + 1;
        print(rolledFace);
    }
}