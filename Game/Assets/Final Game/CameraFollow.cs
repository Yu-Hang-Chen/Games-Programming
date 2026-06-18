using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target; // The Model of the character
    private Vector3 offset;

    void Start()
    {
        offset = transform.position - target.position;
    }

    void LateUpdate()
    {
        // Core£ºOnly follow the position instead of the rotation.
        transform.position = target.position + offset;
    }
}