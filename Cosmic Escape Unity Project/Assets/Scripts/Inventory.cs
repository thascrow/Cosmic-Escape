using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    [SerializeField] public List<GameObject> items;
    [SerializeField] public List<Image> uIElements;

    //[SerializeField]float collectibles;
    //[SerializeField] bool red, blue, yellow, green;
    //[SerializeField] Image head, arm, leg, body;
}
