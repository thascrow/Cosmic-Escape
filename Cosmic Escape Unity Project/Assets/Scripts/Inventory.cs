using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class Inventory : MonoBehaviour
{
    [SerializeField] public List<GameObject> items;
    [SerializeField] public List<Image> uIElements;

    [SerializeField] int points;


    public void SetPoints(int addPoint)
    {
        points += addPoint;
    }

    private void Update()
    {
        if (points >= 4)
        {
            Debug.Log(gameObject.name + " " + "Wins");
        }
    }
    //[SerializeField]float collectibles;
    //[SerializeField] bool red, blue, yellow, green;
    //[SerializeField] Image head, arm, leg, body;


}
