using UnityEngine;

public class Bootstrap : MonoBehaviour
{
    [SerializeField] private PlayerController playerController;
    [SerializeField] private PlayerAnimation playerAnimator;
    [SerializeField] private PlayerHealth playerHealth;
    [SerializeField] private Weapon weapon;

    private void Awake()
    {
        playerController.Initialize();
        playerAnimator.Initialize();
        playerHealth.Initialize();
        weapon.Initialize();

        Destroy(transform.gameObject);
    }
}
