using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[CreateAssetMenu(menuName = "BehaviourTree/Actions/GoToTarget")]
public class GoToTargetAction : BehaviourTreeGoToLocation
{
    public override Vector3 GetMoveTarget(IBehaviourController controller)
    {
        return ((ITargetLocationDataProvider)controller).TargetPosition;
    }
}
