using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    private MessageBroker _messageBroker;

    [SerializeField]
    private List<LevelData> _levelDataList;
    [SerializeField]
    private TargetPositions _doorPositions;

    [Range(0, 2)]
    public int zeroBasedCurrentLevel = 0;

    void Awake()
    {
        _messageBroker = GetComponent<MessageBrokerService>().MessageBroker;
    }

    void Start()
    {
        //Debug.Log("LevelManager Awake");
        ProcessCommandLine();
        InititalizeGame();
    }

    private void InititalizeGame()
    {
        _doorPositions._targetTransforms = new List<TargetPositionData>();
        LevelData levelData = _levelDataList[zeroBasedCurrentLevel];
        Transform levelPrefab = levelData._levelConfiguration.transform;
        Transform caveEntranceTransform = levelPrefab.Find("CaveEntrance");
        Instantiate(caveEntranceTransform.gameObject, caveEntranceTransform.position, caveEntranceTransform.rotation);

        int maxAliensAtTheDoor = AddPositionsToDoorPositions(levelPrefab.Find("DoorLocations1stRow"), 0);
        AddPositionsToDoorPositions(levelPrefab.Find("DoorLocations2ndRow"), 1);

        GameData gameData = new GameData
        {
            _numberOfAliensToSpawn = levelData._alienTargetKillCount + maxAliensAtTheDoor,
            _waitTime = levelData._alienWaitTime,
            _spawnIntervall = levelData._spawnIntervall,
            _maximumAliensAtDoor = maxAliensAtTheDoor,
            _targetKillCount = levelData._alienTargetKillCount
        };

        _messageBroker.GameInitialize.Invoke(gameData);
    }

    private void ProcessCommandLine()
    {
        string[] arguments = System.Environment.GetCommandLineArgs();
        if (arguments.Length > 1)
        {
            string firstArg = arguments[1];

            if (int.TryParse(firstArg, out int levelNumber) && levelNumber > -1 && levelNumber < 3)
            {
                zeroBasedCurrentLevel = levelNumber;
            }
            else
            {
                Debug.Log("First command line is the 0 based index of the level, for now it can be from 0 to 2.");
            }
        }

        Debug.Log($"Running level {zeroBasedCurrentLevel}.");
    }

    private int AddPositionsToDoorPositions(Transform parent, int row)
    {
        //Debug.Log("Add");
        int doorPositionAdded = 0;
        IEnumerable childAndParentTransforms = parent.GetComponentsInChildren<Transform>(); // This returns the paretn tranform as well not just the childrens!!!!
        foreach (Transform transform in childAndParentTransforms)
        {
            if (transform != parent)
            {
                _doorPositions._targetTransforms.Add(
                    new TargetPositionData { TargetPosition = transform.position, Occupied = false, Row = row });
                doorPositionAdded++;
            }
        }

        return doorPositionAdded;
    }
}
