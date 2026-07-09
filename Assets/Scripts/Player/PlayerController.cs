using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Transform transform_;
    private Rigidbody2D rb;
    private Animator animator;

    private float speed = 15f;

    private void Awake()
    {
        transform_ = transform.GetComponent<Transform>();
        rb = transform_.GetComponent<Rigidbody2D>();
        animator = transform_.GetComponent<Animator>();
    }

    void Start()
    {
        transform_.rotation = Quaternion.Euler(Vector2.zero);
    }

    private void FixedUpdate()
    {
        float horizontalAxis = Input.GetAxis("Horizontal");
        float verticalAxis = Input.GetAxis("Vertical");
        Vector2 direction = new(horizontalAxis, verticalAxis);

        //Move
        rb.MovePosition((Vector2)transform_.position + speed * Time.fixedDeltaTime * direction.normalized);
        animator.SetFloat("Speed", direction.magnitude);

        //Rotation
        if (direction != Vector2.zero) 
        {
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90f;
            transform_.rotation = Quaternion.Euler(0, 0, angle);
        }
    }
}
