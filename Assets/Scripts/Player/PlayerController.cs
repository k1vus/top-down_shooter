using UnityEngine;

public class PlayerController : MonoBehaviour, IRestartable
{
    private Transform transform_;
    private Rigidbody2D rb;

    private PlayerAnimation playerAnimator;
    
    private float speed = 15f;

    public void Initialize()
    {
        transform_ = transform.GetComponent<Transform>();
        rb = transform_.GetComponent<Rigidbody2D>();

        playerAnimator = transform_.GetComponent<PlayerAnimation>();

        transform_.rotation = Quaternion.identity;
    }

    private void FixedUpdate()
    {
        float horizontalAxis = Input.GetAxis("Horizontal");
        float verticalAxis = Input.GetAxis("Vertical");
        Vector2 direction = new(horizontalAxis, verticalAxis);

        //Move
        rb.MovePosition((Vector2)transform_.position + speed * Time.fixedDeltaTime * direction.normalized);
        playerAnimator.MoveAnimation(direction.magnitude);

        //Rotation
        if (direction != Vector2.zero)
        {
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90f;
            transform_.rotation = Quaternion.Euler(0, 0, angle);
        }
    }

    public void Restart()
    {
        transform_.position = Vector3.zero;
        transform_.rotation = Quaternion.identity;
    }
}
