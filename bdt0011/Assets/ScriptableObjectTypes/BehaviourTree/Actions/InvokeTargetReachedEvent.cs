using UnityEngine;

[CreateAssetMenu(menuName = "BehaviourTree/Actions/InvokeTargetReachedEvent")]
public class InvokeTargetReachedEvent : BehaviourTreeNodeAction
{
    public override BehaviourTreeState Process(BehaviourTreeNode node, IBehaviourController controller)
    {
        controller.HandleEvent(new BehaviourTreeTargetReachedEventData());
        return DefaultProcess(node, controller);
    }
}
