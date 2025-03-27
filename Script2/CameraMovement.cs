using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public Transform target; // The player or object to follow
    float smoothSpeed = 0.125f;
    public Vector3 offset; // Adjust in the inspector

    void LateUpdate()
    {
        Vector3 desiredPosition = target.position + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothedPosition;

        transform.LookAt(target); // Optional if you want the camera to look at the player
    }
}
