using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    private Animator animator;

    private readonly int Shoot = Animator.StringToHash("IsShoot");
    private readonly int Move = Animator.StringToHash("IsMove");
    private readonly int Die = Animator.StringToHash("IsDead");

    public void Initialize()
    {
        animator = transform.GetComponent<Animator>();
    }

    public void ShootAnimation(bool shouldShootAnimation)
    {
        animator.SetBool(Shoot, shouldShootAnimation);
    }

    public void MoveAnimation(float directionMagnitude)
    {
        bool shouldMoveAnimation = directionMagnitude != 0;
        animator.SetBool(Move, shouldMoveAnimation);
    }

    public void DieAnimation()
    {
        animator.SetBool(Die, true);
    }

}
