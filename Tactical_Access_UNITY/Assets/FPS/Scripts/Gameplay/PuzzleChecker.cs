using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleChecker : MonoBehaviour
{
    public GameObject selectedObject; // Assign the selected object in the Inspector
    public Light[] lightsToChangeColor; // Assign the lights you want to change color in the Inspector
    public GameObject door;

    private Color originalColor; // Store the original color of the lights

    void Start()
    {
        // Store the original color of the lights
        originalColor = lightsToChangeColor[0].color; // Assuming all lights have the same color initially
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == selectedObject)
        {
            // The selected object has entered the collider
            Debug.Log(selectedObject.name + " entered the collider!");

            // Change the color of the lights to green
            ChangeLightsColor(Color.green);
            Destroy(door);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == selectedObject)
        {
            // The selected object has exited the collider
            Debug.Log(selectedObject.name + " exited the collider!");

            // Reset the color of the lights to the original color
            ChangeLightsColor(originalColor);
        }
    }

    private void ChangeLightsColor(Color newColor)
    {
        // Change the color of each light in the array
        foreach (Light light in lightsToChangeColor)
        {
            light.color = newColor;
        }
    }
}
