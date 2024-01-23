using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeySpawn : MonoBehaviour
{
    public GameObject KeyPos;
    public int minY = -10;

    void Update()
    {
        // Check if the current object's Y position is below the specified limit
        if (transform.position.y < minY)
        {
            transform.position = KeyPos.transform.position;
        }
    }
}
