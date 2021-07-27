using UnityEngine;

[CreateAssetMenu(menuName = "BehaviourTree/Actions/Attack")]
public class AttackAction : BehaviourTreeNodeAction
{
    public override BehaviourTreeState Process(BehaviourTreeNode node, IBehaviourController controller)
    {
        Animator animator = ((IActionDataProvider)controller).Animator;
        animator.SetBool("Attack", true);
        return DefaultProcess(node, controller);
    }
}
