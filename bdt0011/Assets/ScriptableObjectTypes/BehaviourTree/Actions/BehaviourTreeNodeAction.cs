using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BehaviourTreeNodeAction : BehaviourTreeNodeProcessor
{
    public override bool CanChildMoveForward(BehaviourTreeStatus status, IBehaviourController controller)
    {
        bool actionNodeCanHaveChildren = false;
        return actionNodeCanHaveChildren;
    }

    protected BehaviourTreeState DefaultProcess(BehaviourTreeNode node, IBehaviourController controller)
    {
        if (node._rightSibling != null && node._parent._nodeProcessor.CanChildMoveForward(BehaviourTreeStatus.Success, controller))
        {
            return new BehaviourTreeState { Node = node._rightSibling, Status = BehaviourTreeStatus.Running, ActionStatus = BehaviourTreeActionStatus.Idle };
        }

        return new BehaviourTreeState { Node = node._parent, Status = BehaviourTreeStatus.Success, ActionStatus = BehaviourTreeActionStatus.Idle };
    }
}
