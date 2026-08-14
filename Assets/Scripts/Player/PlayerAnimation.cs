using UnityEngine;

public class PlayerAnimation : MonoBehaviour, IRestartable
{
    private Animator animator;

    private readonly int[] hashs = new int[3]
    {
        Animator.StringToHash("IsShoot"),
        Animator.StringToHash("IsMove"),
        Animator.StringToHash("IsDead")
    };

    public void Initialize()
    {
        animator = transform.GetComponent<Animator>();
    }

    public void ShootAnimation(bool shouldShootAnimation)
    {
        animator.SetBool(hashs[0], shouldShootAnimation);
    }

    public void MoveAnimation(float directionMagnitude)
    {
        bool shouldMoveAnimation = directionMagnitude != 0;
        animator.SetBool(hashs[1], shouldMoveAnimation);
    }

    public void DieAnimation()
    {
        animator.SetBool(hashs[2], true);
    }

    public void Restart()
    {
        foreach (int hash in hashs)
        {
            animator.SetBool(hash, false);
        }
    }
}
