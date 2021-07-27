public interface IBehaviourController
{
    public void HandleEvent(BehaviourTreeEventData eventData);
}

public interface IActionDataProvider
{
    public UnityEngine.AI.NavMeshAgent NavigationAgent { get; }
    public UnityEngine.Animator Animator { get; }
    public BehaviourTreeActionStatus CurrentActionStatus { get; }
}

public interface ICurrentLocationDataProvider
{
    public UnityEngine.Vector3 CurrentPosition { get; }
}

public interface IDeathDataProvider
{
    public bool IsDead { get; }
}

public interface ITargetLocationDataProvider
{
    public UnityEngine.Vector3 TargetPosition { get; set; }
}