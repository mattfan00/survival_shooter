using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;
    // Update is called once per frame
    void Update()
    {
        Follow();
    }

    void Follow() {
        Vector3 newPosition = player.position;
        newPosition.z = transform.position.z;

        transform.position = newPosition;
    }
}
