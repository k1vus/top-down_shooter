using UnityEngine;

public class PlayerHealth : MonoBehaviour, IRestartable
{
    private GameController gameManager;
    private PlayerAnimation playerAnimator;

    private float maxHealth = 100f;
    public float currentHealth;
    private float heal = 5f; // per second
    private float phantomHealedHealth;

    public void Initialize()
    {
        gameManager = GameObject.Find("Game Controller").transform.GetComponent<GameController>();
        playerAnimator = transform.GetComponent<PlayerAnimation>();

        currentHealth = maxHealth;
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

    private void TakeDamage(float damage)
    {
        currentHealth -= damage;
    }

    private void Heal()
    {
        phantomHealedHealth += Time.deltaTime * heal;

        if (Mathf.Round(phantomHealedHealth) == heal)
        {
            currentHealth += Mathf.Clamp(heal, 0f, maxHealth - currentHealth);
            phantomHealedHealth = 0f;
        } 
    }

    public void Die()
    {
        gameManager.GameOver();
    }

    public void Restart()
    {
        currentHealth = maxHealth;
    }
}
