using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndPointCollision : MonoBehaviour
{
    [SerializeField] private Text winText;

    private void OnCollisionEnter(Collision collision)
    {
        winText.text = collision.gameObject.name + " wins!";
        winText.gameObject.SetActive(true);

    }
}
