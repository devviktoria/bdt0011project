using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "BehaviourTree/Actions/SelectClosestTarget")]
public class SelectClosestTargetAction : BehaviourTreeNodeAction
{
    public bool MirroredMinimumDistanceCalculation;
    public bool ReservePosition;

    public TargetPositions TargetPositions;

    public override BehaviourTreeState Process(BehaviourTreeNode node, IBehaviourController controller)
    {
        ((ITargetLocationDataProvider)controller).TargetPosition = GetClosestPosition(controller).TargetPosition;

        return DefaultProcess(node, controller);
    }

    protected TargetPositionData GetClosestPosition(IBehaviourController controller)
    {
        Vector3 currentPosition = ((ICurrentLocationDataProvider)controller).CurrentPosition;
        float minDistance = float.PositiveInfinity;

        List<TargetPositionData> targetPositions = TargetPositions._targetTransforms;
        TargetPositionData closestPointData = targetPositions[targetPositions.Count - 1];
        int minIndex = targetPositions.Count - 1;

        if (MirroredMinimumDistanceCalculation)
        {
            currentPosition += new Vector3(0, 0, closestPointData.TargetPosition.z);
        }

        for (int i = 0; i < targetPositions.Count; i++)
        {
            TargetPositionData targetPositionData = targetPositions[i];
            if (!targetPositionData.Occupied)
            {
                float currentDistance = Vector3.Distance(currentPosition, targetPositionData.TargetPosition);
                if (currentDistance < minDistance)
                {
                    minDistance = currentDistance;
                    closestPointData = targetPositionData;
                    minIndex = i;
                }
            }
        }

        if (ReservePosition)
        {
            targetPositions[minIndex] = new TargetPositionData { TargetPosition = closestPointData.TargetPosition, Row = closestPointData.Row, Occupied = true };
        }

        return targetPositions[minIndex];
    }
}
