using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField]
    private Transform player;

    private float speed = 5f;

    private void Update()
    {
        Vector3 newPosition = Vector3.Lerp
        (
            transform.position, 
            player.position, 
            speed * Time.deltaTime
        );

        Vector3 position = transform.position;
        position.x = newPosition.x;
        position.y = newPosition.y;
        position.z = -10;

        transform.position = position;
    }
}
