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
    [SerializeField] private Text winText;
    [SerializeField] int points;


    public void SetPoints(int addPoint)
    {
        points += addPoint;

    }

    public int GetPoints()
    {
        return points;
    }
    private void Update()
    {
        if (points >= 4)
        {
            winText.text = gameObject.name + " " + "Wins";
            Debug.Log(gameObject.name + " " + "Wins");
        }
    }
    //[SerializeField]float collectibles;
    //[SerializeField] bool red, blue, yellow, green;
    //[SerializeField] Image head, arm, leg, body;


}
