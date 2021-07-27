using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BehaviourTreeNodeProcessor : ScriptableObject
{
    public abstract bool CanChildMoveForward(BehaviourTreeStatus status, IBehaviourController controller);
    public abstract BehaviourTreeState Process(BehaviourTreeNode node, IBehaviourController controller);
}
