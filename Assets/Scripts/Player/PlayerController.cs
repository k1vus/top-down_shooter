using System.Collections;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Transform transform_;
    private Rigidbody2D rb;

    private PlayerAnimator playerAnimator;
    
    private float speed = 15f;

    private float maxHealth = 100f;
    public float currentHealth;
    private float heal = 5f; // per second
    private float phantomHealedHealth;

    private WaitForSeconds waitForSeconds;

    public void Initialize()
    {
        transform_ = transform.GetComponent<Transform>();
        rb = transform_.GetComponent<Rigidbody2D>();

        playerAnimator = transform_.GetComponent<PlayerAnimator>();

        currentHealth = maxHealth;

        waitForSeconds = new(10f);

        transform_.rotation = Quaternion.Euler(Vector2.zero);
    }

    private void Update()
    {
        if (currentHealth < maxHealth)
        {
            Heal();
        }

        if (currentHealth <= 0f)
        {
            playerAnimator.DieAnimation();
        }

        #if DEBUG
            if (Input.GetKeyUp(KeyCode.X))
                TakeDamage(50f);
        #endif
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

    private void TakeDamage(float damage)
    {
        currentHealth -= damage;
    }

    private void Heal()
    {
        phantomHealedHealth += Time.deltaTime * heal;

        if (Mathf.Round(phantomHealedHealth) == heal)
        {
            currentHealth += Mathf.Clamp(heal, 0f, maxHealth);
            phantomHealedHealth = 0f;
        } 
    }

    public void Die()
    {
        Time.timeScale = 0f;
    }
}
