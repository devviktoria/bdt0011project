using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BehaviourTreeConditional : BehaviourTreeNodeProcessor
{
    public override bool CanChildMoveForward(BehaviourTreeStatus status, IBehaviourController controller)
    {
        bool conditionalNodeCanHaveMiltipleChildren = false;
        return conditionalNodeCanHaveMiltipleChildren;
    }

    public override BehaviourTreeState Process(BehaviourTreeNode node, IBehaviourController controller)
    {
        if (node._leftChild != null && IsConditionStatisfied(controller))
        {
            return new BehaviourTreeState { Node = node._leftChild, Status = BehaviourTreeStatus.Running, ActionStatus = BehaviourTreeActionStatus.Idle };
        }

        BehaviourTreeStatus currentStatus = BehaviourTreeStatus.Failure;
        if (node._rightSibling != null && node._parent._nodeProcessor.CanChildMoveForward(currentStatus, controller))
        {
            return new BehaviourTreeState { Node = node._rightSibling, Status = BehaviourTreeStatus.Running, ActionStatus = BehaviourTreeActionStatus.Idle };
        }

        return new BehaviourTreeState { Node = node._parent, Status = currentStatus, ActionStatus = BehaviourTreeActionStatus.Idle };
    }

    public virtual bool IsConditionStatisfied(IBehaviourController controller)
    {
        return true;
    }
}
