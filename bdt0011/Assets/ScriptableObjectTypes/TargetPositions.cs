using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct TargetPositionData
{
    public Vector3 TargetPosition;
    public bool Occupied;
    public int Row;
}

[CreateAssetMenu(menuName = "TargetPositions")]
public class TargetPositions : ScriptableObject
{
    public List<TargetPositionData> _targetTransforms;
}
