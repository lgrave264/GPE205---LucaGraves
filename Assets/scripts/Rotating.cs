using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotating : MonoBehaviour
{
    public Transform centerObject; // The central object to rotate around
    public float rotationSpeed = 50f; // Rotation speed in degrees per second

    void Update()
    {
        if (centerObject != null)
        {
            // Calculate the direction vector from the centerObject to this object
            Vector3 direction = transform.position - centerObject.position;

            // Calculate the rotation axis perpendicular to the direction vector and the Y-axis
            Vector3 rotationAxis = Vector3.Cross(direction, Vector3.up);

            // Rotate the object around the centerObject on the Y-axis
            transform.RotateAround(centerObject.position, Vector3.up, rotationSpeed * Time.deltaTime);
        }
        else
        {
            Debug.LogWarning("Center object not assigned!");
        }
    }
}
