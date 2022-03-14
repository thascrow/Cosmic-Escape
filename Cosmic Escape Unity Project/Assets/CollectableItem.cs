using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableItem : MonoBehaviour
{
    [SerializeField] private Inventory inventory;
    public bool PickingUp;
    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            PickingUp = true;
            int sizeOfInventory = inventory.items.Count;

            inventory.uIElements[sizeOfInventory].gameObject.SetActive(true);

            inventory.items.Add(gameObject);
            gameObject.SetActive(false);
          
        }
    }


}
