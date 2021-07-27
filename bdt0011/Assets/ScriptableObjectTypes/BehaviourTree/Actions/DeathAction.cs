using UnityEngine;

[CreateAssetMenu(menuName = "BehaviourTree/Actions/Death")]
public class DeathAction : BehaviourTreeNodeAction
{
    public MovingAnimationController MovingAnimationController;

    public override BehaviourTreeState Process(BehaviourTreeNode node, IBehaviourController controller)
    {
        Debug.Log("Death occured");
        IActionDataProvider actionDataProvider = ((IActionDataProvider)controller);
        Animator animator = actionDataProvider.Animator;
        if (!actionDataProvider.NavigationAgent.isStopped)
        {
            actionDataProvider.NavigationAgent.isStopped = true;
            MovingAnimationController.StopMovingAnimation(animator);
        }

        actionDataProvider.NavigationAgent.enabled = false; // To allow sinking bellow ground
        animator.SetBool("Dead", true);
        return DefaultProcess(node, controller);
    }
}
