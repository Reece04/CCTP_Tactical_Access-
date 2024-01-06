using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnblockedDoor : MonoBehaviour
{
    public GameObject enemyPrefab; // Drag your enemy prefab to this field in the Inspector
    public Transform spawnPoint; // Set the spawn point for the enemy in the Inspector

    public GameObject[] objectsToDestroy; // Drag objects to be destroyed to this array in the Inspector
    public GameObject[] objectsToSetActive; // Drag objects to be set active to this array in the Inspector

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Spawn the enemy at the designated location
            Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);

            // Destroy selected objects
            DestroyObjects();

            // Set selected objects active
            SetObjectsActive();

            // You may want to disable or destroy this trigger after it's triggered once
            // Destroy(gameObject); // Uncomment this line if you want to destroy the trigger itself
        }
    }

    void DestroyObjects()
    {
        // Destroy selected objects
        foreach (GameObject obj in objectsToDestroy)
        {
            Destroy(obj);
        }
    }

    void SetObjectsActive()
    {
        // Set selected objects active
        foreach (GameObject obj in objectsToSetActive)
        {
            obj.SetActive(true);
        }
    }
}
