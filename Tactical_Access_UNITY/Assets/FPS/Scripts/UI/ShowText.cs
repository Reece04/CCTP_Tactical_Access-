using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowText : MonoBehaviour
{
    public GameObject uiPanel; // Reference to your UI panel or canvas

    private void OnTriggerEnter(Collider other)
    {
        // Check if the entering collider is the player
        if (other.CompareTag("Player"))
        {
            // Show the UI panel
            ShowUI(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // Check if the exiting collider is the player
        if (other.CompareTag("Player"))
        {
            // Hide the UI panel
            ShowUI(false);
        }
    }

    private void ShowUI(bool show)
    {
        // Toggle the visibility of the UI panel
        if (uiPanel != null)
        {
            uiPanel.SetActive(show);
        }
    }
}
