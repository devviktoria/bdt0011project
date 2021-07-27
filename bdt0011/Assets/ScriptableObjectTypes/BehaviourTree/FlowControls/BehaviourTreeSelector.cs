using UnityEngine;

[CreateAssetMenu(menuName = "BehaviourTree/Selector")]
public class BehaviourTreeSelector : BehaviourTreeNodeProcessor
{
    public override bool CanChildMoveForward(BehaviourTreeStatus status, IBehaviourController controller)
    {
        if (status == BehaviourTreeStatus.Running || status == BehaviourTreeStatus.Success)
        {
            return false;
        }

        return true;
    }

    public override BehaviourTreeState Process(BehaviourTreeNode node, IBehaviourController controller)
    {
        BehaviourTreeNode nextNode = node._leftChild != null ? node._leftChild : node._parent;
        return new BehaviourTreeState { Node = nextNode, Status = BehaviourTreeStatus.Running, ActionStatus = BehaviourTreeActionStatus.Idle };
    }
}
