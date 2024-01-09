using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleManager : MonoBehaviour
{
    public List<Light[]> lightsGroups; // List of groups of lights, each group represents a puzzle
    public List<GameObject> puzzleObjects; // List of objects associated with each puzzle group

    private void Start()
    {
        // Check for null references before initializing the puzzles
        if (lightsGroups != null && puzzleObjects != null)
        {
            // Initialize the puzzle objects and lights
            for (int i = 0; i < lightsGroups.Count; i++)
            {
                if (i < puzzleObjects.Count && puzzleObjects[i] != null && lightsGroups[i] != null)
                {
                    Puzzle puzzle = new Puzzle(puzzleObjects[i], lightsGroups[i]);
                    puzzle.Initialize();
                }
                else
                {
                    Debug.LogError("Missing or null references in PuzzleMan inspector assignments.");
                }
            }
        }
        else
        {
            Debug.LogError("Null references in PuzzleMan inspector assignments.");
        }
    }
}

public class Puzzle
{
    private GameObject puzzleObject;
    private Light[] lights;
    private Color[] originalColors;

    public Puzzle(GameObject puzzleObject, Light[] lights)
    {
        this.puzzleObject = puzzleObject;
        this.lights = lights;
    }

    public void Initialize()
    {
        // Store the original colors of the lights
        originalColors = new Color[lights.Length];
        for (int i = 0; i < lights.Length; i++)
        {
            originalColors[i] = lights[i].color;
        }
    }

    public void ChangeLightsColor(Color newColor)
    {
        // Change the color of each light in the array
        foreach (Light light in lights)
        {
            light.color = newColor;
        }
    }

    public void ResetLightsColor()
    {
        // Reset the color of the lights to their original colors
        for (int i = 0; i < lights.Length; i++)
        {
            lights[i].color = originalColors[i];
        }
    }

    public bool AreAllLightsGreen()
    {
        // Check if all lights have turned green
        foreach (Light light in lights)
        {
            if (light.color != Color.green)
            {
                return false;
            }
        }
        return true;
    }
}