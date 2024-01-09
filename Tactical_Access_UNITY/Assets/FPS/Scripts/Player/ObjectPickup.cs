using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPickup : MonoBehaviour
{
    public Camera playerCamera; // Assign the camera in the Inspector
    public LayerMask pickupLayer; // Specify the layer for pickupable objects

    private bool isHoldingObject = false;
    private GameObject heldObject;
    private Vector3 objectOffset;

    void Start()
    {
        if (playerCamera == null)
        {
            playerCamera = Camera.main;
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (isHoldingObject)
            {
                DropObject();
            }
            else
            {
                TryPickUpObject();
            }
        }

        if (isHoldingObject)
        {
            MoveHeldObject();
        }
    }

    void TryPickUpObject()
    {
        RaycastHit hit;
        if (Physics.Raycast(playerCamera.transform.position, playerCamera.transform.forward, out hit, 5f, pickupLayer))
        {
            if (hit.collider.CompareTag("Pickupable"))
            {
                PickUpObject(hit.collider.gameObject);
            }
        }
    }

    void PickUpObject(GameObject obj)
    {
        isHoldingObject = true;
        heldObject = obj;
        objectOffset = playerCamera.transform.position - obj.transform.position;

        // Disable the Rigidbody's gravity and make it kinematic
        Rigidbody rb = heldObject.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.useGravity = false;
            rb.isKinematic = true;
        }
    }

    void MoveHeldObject()
    {
        // Calculate the target position based on the player's forward direction and a distance
        Vector3 targetPosition = playerCamera.transform.position + playerCamera.transform.forward * 3f;

        // Lerp towards the target position to smoothly move the object
        heldObject.transform.position = Vector3.Lerp(heldObject.transform.position, targetPosition, Time.deltaTime * 10f);

        if (Input.GetMouseButtonDown(0))
        {
            DropObject();
        }
    }

    void DropObject()
    {
        isHoldingObject = false;

        // Enable the Rigidbody's gravity and make it non-kinematic
        Rigidbody rb = heldObject.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.useGravity = true;
            rb.isKinematic = false;
        }

        heldObject = null;
    }
}
