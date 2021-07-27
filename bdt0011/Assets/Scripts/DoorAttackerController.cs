using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class DoorAttackerController : MonoBehaviour,
                                        IBehaviourController,
                                        IDeathDataProvider,
                                        ICurrentLocationDataProvider,
                                        IActionDataProvider,
                                        ITargetLocationDataProvider
{

    private MessageBroker _messageBroker;

    private NavMeshAgent _navMeshAgent;
    private Transform _transform;
    private IDeathDataProvider _deathDataProvider;

    private bool _isDead;
    private bool _treeAbortNeeded;

    private Vector3 _targetPostion;

    private BehaviourTreeState _currentBehaviourTreeState;

    [SerializeField]
    private BehaviourTreeNode _rootNode;
    [SerializeField]
    private Animator _animator;

    public bool IsDead => _isDead;

    public NavMeshAgent NavigationAgent => _navMeshAgent;

    public Animator Animator => _animator;

    public Vector3 CurrentPosition => _transform.position;

    public BehaviourTreeActionStatus CurrentActionStatus => _currentBehaviourTreeState.ActionStatus;

    public Vector3 TargetPosition
    {
        get => _targetPostion;
        set
        {
            _targetPostion = value;
        }
    }

    public void Initialize(MessageBroker messageBroker)
    {
        _messageBroker = messageBroker;

        _isDead = false;
        _treeAbortNeeded = false;
        _currentBehaviourTreeState = new BehaviourTreeState { Node = _rootNode, Status = BehaviourTreeStatus.Running, ActionStatus = BehaviourTreeActionStatus.Idle };
    }

    public void HandleEvent(BehaviourTreeEventData eventData)
    {
        if (eventData is BehaviourTreeTargetReachedEventData)
        {
            _messageBroker?.AlienReachedDoor.Invoke();
        }
    }

    private void Awake()
    {
        _transform = GetComponent<Transform>();
        _navMeshAgent = GetComponent<NavMeshAgent>();
        _deathDataProvider = GetDeathDataProvider();
    }

    // private void Start()
    // {
    //     Initialize(null);
    // }

    private void Update()
    {
        if (_currentBehaviourTreeState.Status != BehaviourTreeStatus.Running)
        {
            return;
        }

        if (!_isDead && _deathDataProvider.IsDead)
        {
            _isDead = _deathDataProvider.IsDead;
            _treeAbortNeeded = true;
        }

        if (!_treeAbortNeeded)
        {
            if (_currentBehaviourTreeState.Node != null && _currentBehaviourTreeState.Status == BehaviourTreeStatus.Running)
            {
                BehaviourTreeNode previousNode = _currentBehaviourTreeState.Node;
                _currentBehaviourTreeState = _currentBehaviourTreeState.Node._nodeProcessor.Process(_currentBehaviourTreeState.Node, this);
                //Debug.Log($"{gameObject.name}: newNode: {_currentBehaviourTreeState.Node}, _currentTreeStatus: {_currentBehaviourTreeState.Status}");
                if (previousNode != _currentBehaviourTreeState.Node && _currentBehaviourTreeState.Status == BehaviourTreeStatus.Failure)
                {
                    //Debug.Log($"{ _objectName}: newNode: {newNode}, _currentTreeStatus: {_currentTreeStatus}");
                    Debug.Log($"{gameObject.name} Failed at doing {_currentBehaviourTreeState.Node._nodeProcessor.ToString()}");
                }
            }
        }
        else
        {
            _treeAbortNeeded = false;
            _currentBehaviourTreeState = new BehaviourTreeState { Node = _rootNode, Status = BehaviourTreeStatus.Running, ActionStatus = BehaviourTreeActionStatus.Idle };
        }
    }

    private IDeathDataProvider GetDeathDataProvider()
    {
        IDeathDataProvider[] deathDataProviders = GetComponents<IDeathDataProvider>();
        foreach (IDeathDataProvider item in deathDataProviders)
        {
#pragma warning disable CS0252 // This is intended reference comparison
            if (item != this)
            {
                return item;
            }
#pragma warning restore CS0252
        }

        return null;
    }


}