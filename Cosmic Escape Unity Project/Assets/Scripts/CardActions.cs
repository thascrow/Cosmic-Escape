using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardActions : MonoBehaviour
{
    public bool ChanceToWinHousePiece()
    {
        int probability = 5;

        int result = Random.Range(1, probability);

        if(result == probability)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
