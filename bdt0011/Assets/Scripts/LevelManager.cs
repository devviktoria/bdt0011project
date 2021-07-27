using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [SerializeField]
    private List<Transform> _firstRowDoorPositions;
    [SerializeField]
    private List<Transform> _secondRowDoorPositions;
    [SerializeField]
    private TargetPositions _doorPositions;

    void Awake()
    {
        //Debug.Log("LevelManager Awake");
        _doorPositions._targetTransforms = new List<TargetPositionData>();
        AddPositionsToDoorPositions(_firstRowDoorPositions, 0);
        AddPositionsToDoorPositions(_secondRowDoorPositions, 1);
    }

    private void AddPositionsToDoorPositions(List<Transform> list, int row)
    {
        //Debug.Log("Add");
        foreach (Transform transform in list)
        {
            _doorPositions._targetTransforms.Add(
                new TargetPositionData { TargetPosition = transform.position, Occupied = false, Row = row });
        }
    }
}
