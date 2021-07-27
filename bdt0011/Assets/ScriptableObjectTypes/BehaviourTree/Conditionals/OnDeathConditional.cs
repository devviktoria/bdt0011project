using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "BehaviourTree/Conditionals/OnDeath")]
public class OnDeathConditional : BehaviourTreeConditional
{
    public override bool IsConditionStatisfied(IBehaviourController controller)
    {
        return ((IDeathDataProvider)controller).IsDead;
    }
}
