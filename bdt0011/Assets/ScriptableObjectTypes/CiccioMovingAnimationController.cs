using UnityEngine;
using UnityEngine.AI;

[CreateAssetMenu(menuName = "MovingAnimation/CiccioController")]
public class CiccioMovingAnimationController : MovingAnimationController
{
    public override void InitializeMovingAnimation(Animator animator)
    {
        animator.SetBool("Move", true);
    }

    public override void StopMovingAnimation(Animator animator)
    {
        animator.SetFloat("Blend", 0);
        animator.SetBool("Move", false);
    }

    public override void UpdateMovingAnimation(Animator animator, NavMeshAgent navMeshAgent)
    {
        animator.SetFloat("Blend", navMeshAgent.velocity.magnitude);
    }
}
