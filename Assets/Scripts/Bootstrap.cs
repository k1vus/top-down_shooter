using UnityEngine;

public class Bootstrap : MonoBehaviour
{
    [SerializeField] private PlayerController playerController;
    [SerializeField] private PlayerAnimator playerAnimator;
    [SerializeField] private Weapon weapon;

    private void Awake()
    {
        playerController.Initialize();
        playerAnimator.Initialize();
        weapon.Initialize();


        Destroy(transform.gameObject);
    }
}
