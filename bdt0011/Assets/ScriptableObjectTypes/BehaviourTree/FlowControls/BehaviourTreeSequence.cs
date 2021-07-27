using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "BehaviourTree/Sequence")]
public class BehaviourTreeSequence : BehaviourTreeNodeProcessor
{
    public override bool CanChildMoveForward(BehaviourTreeStatus status, IBehaviourController controller)
    {
        if (status == BehaviourTreeStatus.Running || status == BehaviourTreeStatus.Failure)
        {
            return false;
        }

        return true;
    }

    public override BehaviourTreeState Process(BehaviourTreeNode node, IBehaviourController controller)
    {
        return new BehaviourTreeState { Node = node._leftChild, Status = BehaviourTreeStatus.Running, ActionStatus = BehaviourTreeActionStatus.Idle };
    }
}
