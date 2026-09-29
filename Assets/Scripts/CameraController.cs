using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform player;

    private Vector3 offset;

    private void Start()
    {
        // Remember the starting distance between camera and player
        offset = transform.position - player.position;
    }

    private void LateUpdate()
    {
        transform.position = new Vector3(transform.position.x, player.position.y + offset.y, transform.position.z);
    }
}
