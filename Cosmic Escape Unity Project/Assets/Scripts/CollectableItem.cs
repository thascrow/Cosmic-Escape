using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableItem : MonoBehaviour
{
    [SerializeField] private Inventory inventory;
    public bool PickingUp;
    [SerializeField] int points = 0;
    private float Timer = 0.5f;

    
    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            inventory = collider.gameObject.GetComponent<Inventory>();
            inventory.SetPoints(1);
            
            PickingUp = true;
            int sizeOfInventory = inventory.items.Count;

            inventory.uIElements[sizeOfInventory].gameObject.SetActive(true);

            inventory.items.Add(gameObject);
            gameObject.GetComponent<MeshRenderer>().enabled = false;
            gameObject.GetComponent<BoxCollider>().enabled = false;
            
        }
    }

    private void Update()
    {
        if (PickingUp == true)
        {
            Timer -= Time.deltaTime;
            
            if (Timer <= 0)
            {
                
                PickingUp = false;
                Timer = 0.5f;
            }
        }
       
    }



}
