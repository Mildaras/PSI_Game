using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target; // The target object to follow
    public float speed = 10.0f; // The speed at which the camera follows the target
    public Vector3 offset; // The offset between the camera and the target

    void Update()
    {
        // Calculate the target position based on the player's position and the offset
        Vector3 targetPosition = target.position + offset;

        // Move the camera towards the target position at the specified speed
        transform.position = Vector3.Lerp(transform.position, targetPosition, speed * Time.deltaTime);
    }
}
