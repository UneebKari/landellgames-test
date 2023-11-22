using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCameraManager : MonoBehaviour
{
    public Transform target; // The target (player) to orbit around
    public float rotationSpeed = 3.0f; // Adjust the speed of the rotation

    void Update()
    {
        // Check if a target is assigned
        if (target == null)
        {
            Debug.LogWarning("No target assigned to the OrbitCamera script.");
            return;
        }

        // Get the mouse input
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");

        // Rotate the camera around the target based on mouse movement
        transform.RotateAround(target.position, Vector3.up, mouseX * rotationSpeed);

        // Rotate the camera up and down based on mouse movement
        transform.RotateAround(target.position, transform.right, -mouseY * rotationSpeed);

        // Limit the vertical rotation to avoid camera flipping
        float currentRotationX = transform.eulerAngles.x;
        if (currentRotationX > 180.0f)
        {
            currentRotationX -= 360.0f;
        }
        float newRotationX = Mathf.Clamp(currentRotationX, -80.0f, 80.0f);

        // Apply the limited vertical rotation
        transform.rotation = Quaternion.Euler(newRotationX, transform.eulerAngles.y, 0.0f);
    }
}
