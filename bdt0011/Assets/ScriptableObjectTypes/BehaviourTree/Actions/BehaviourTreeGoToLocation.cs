using UnityEngine;
using UnityEngine.AI;

public abstract class BehaviourTreeGoToLocation : BehaviourTreeNodeAction
{
    public bool UseNavMeshAgentStoppingDistance;
    public float StoppingDistance;
    public MovingAnimationController MovingAnimationController;
    public bool StopOnArrival;

    public abstract Vector3 GetMoveTarget(IBehaviourController controller);

    public override BehaviourTreeState Process(BehaviourTreeNode node, IBehaviourController controller)
    {
        IActionDataProvider goToLocationDataProvider = (IActionDataProvider)controller;
        (BehaviourTreeStatus status, BehaviourTreeActionStatus actionStatus) =
            MoveAgentToLocation(
                goToLocationDataProvider,
                ((ICurrentLocationDataProvider)controller).CurrentPosition,
                GetMoveTarget(controller),
                GetStoppingDistance(controller));

        if (status == BehaviourTreeStatus.Running)
        {
            return new BehaviourTreeState { Node = node, Status = status, ActionStatus = actionStatus };
        }

        if (node._rightSibling != null && node._parent._nodeProcessor.CanChildMoveForward(status, controller))
        {
            return new BehaviourTreeState { Node = node._rightSibling, Status = BehaviourTreeStatus.Running, ActionStatus = actionStatus };
        }

        return new BehaviourTreeState { Node = node._parent, Status = status, ActionStatus = actionStatus };
    }

    private (BehaviourTreeStatus, BehaviourTreeActionStatus) MoveAgentToLocation(
                                                                IActionDataProvider goToLocationDataProvider,
                                                                Vector3 from,
                                                                Vector3 destination,
                                                                float stoppingDistance)
    {
        NavMeshAgent navMeshAgent = goToLocationDataProvider.NavigationAgent;
        Animator animator = goToLocationDataProvider.Animator;
        BehaviourTreeActionStatus currentActionStatus = goToLocationDataProvider.CurrentActionStatus;

        BehaviourTreeActionStatus newActionState = currentActionStatus;
        if (currentActionStatus == BehaviourTreeActionStatus.Idle)
        {
            navMeshAgent.autoBraking = StopOnArrival;
            navMeshAgent.SetDestination(destination);
            navMeshAgent.isStopped = false;
            newActionState = BehaviourTreeActionStatus.Working;
            MovingAnimationController.InitializeMovingAnimation(animator);
        }
        else if (!navMeshAgent.pathPending && navMeshAgent.pathStatus != NavMeshPathStatus.PathComplete)
        {
            StopMovement(navMeshAgent, animator);
            newActionState = BehaviourTreeActionStatus.Idle;
            return (BehaviourTreeStatus.Failure, newActionState);
        }
        else if (!navMeshAgent.pathPending && navMeshAgent.remainingDistance <= stoppingDistance)
        {
            if (StopOnArrival)
            {
                StopMovement(navMeshAgent, animator);
            }
            newActionState = BehaviourTreeActionStatus.Idle;
            return (BehaviourTreeStatus.Success, newActionState);
        }

        MovingAnimationController.UpdateMovingAnimation(animator, navMeshAgent);
        return (BehaviourTreeStatus.Running, newActionState);
    }

    private void StopMovement(NavMeshAgent navMeshAgent, Animator animator)
    {
        navMeshAgent.isStopped = true;
        MovingAnimationController.StopMovingAnimation(animator);
    }

    private float GetStoppingDistance(IBehaviourController controller)
    {
        if (UseNavMeshAgentStoppingDistance)
        {
            return ((IActionDataProvider)controller).NavigationAgent.stoppingDistance;
        }

        return StoppingDistance;
    }
}
