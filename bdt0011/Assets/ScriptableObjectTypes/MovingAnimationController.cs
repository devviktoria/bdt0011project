using UnityEngine;
using UnityEngine.AI;

public abstract class MovingAnimationController : ScriptableObject
{
    public abstract void InitializeMovingAnimation(Animator animator);
    public abstract void UpdateMovingAnimation(Animator animator, NavMeshAgent navMeshAgent);
    public abstract void StopMovingAnimation(Animator animator);
}
