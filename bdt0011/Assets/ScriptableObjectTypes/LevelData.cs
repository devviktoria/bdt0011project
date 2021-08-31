using UnityEngine;

[CreateAssetMenu(menuName = "LevelData")]
public class LevelData : ScriptableObject
{
    public GameObject _levelConfiguration;
    public float _alienWaitTime;
    public float _spawnIntervall;
    public int _alienTargetKillCount;
}
