using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickup : MonoBehaviour
{

    public enum ItemType
    {
        ExtraBomb,
        BlastRadius,
        SpeedIncrease
    }

    public ItemType type;


    private void OnItemPickup(GameObject player)
    {
        switch (type)
        {
            case ItemType.ExtraBomb:
                player.GetComponent<newBombController>().AddBomb();
                break;
            case ItemType.BlastRadius:
                player.GetComponent<newBombController>().explosionRadius++;
                break;
            case ItemType.SpeedIncrease:
                player.GetComponent<newPlayerMovementController>().speed++;
                break;
        }

        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            OnItemPickup(other.gameObject);
        }
    }

}
