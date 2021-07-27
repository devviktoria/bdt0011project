using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[CreateAssetMenu(menuName = "BehaviourTree/Actions/SinkBellowGround")]
public class SinkBellowGroundAction : BehaviourTreeNodeAction
{
    public override BehaviourTreeState Process(BehaviourTreeNode node, IBehaviourController controller)
    {
        Debug.Log("Sinking");
        return DefaultProcess(node, controller);
    }
}
