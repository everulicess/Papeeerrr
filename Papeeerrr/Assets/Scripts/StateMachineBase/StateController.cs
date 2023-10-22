using System.Collections.Generic;
using UnityEngine;
using System;

public class StateController<EState> : MonoBehaviour where EState : Enum
{
    protected Dictionary<EState, State<EState>> States = new Dictionary<EState, State<EState>>();

    protected State<EState> currentState;
    protected bool isTransitioningState = false;

    private void Start()
    {

        currentState.EnterState();
    }
    private void Update()
    {
        //currentState.UpdateState();
        EState nextStateKey = currentState.GetNextState();

        if (!isTransitioningState && nextStateKey.Equals(currentState.stateKey))
        {
            currentState.UpdateState();
        }
        else
        {
            TransitionToState(nextStateKey);
        }

    }
    public void TransitionToState(EState stateKey)
    {
        isTransitioningState = true;
        currentState.ExitState();
        currentState = States[stateKey];
        currentState.EnterState();
        isTransitioningState = false;

    }
    private void OnTriggerEnter(Collider other)
    {
        currentState.OnTriggerEnter(other);
    }
    private void OnTriggerStay(Collider other)
    {
        currentState.OnTriggerStay(other);
    }
    private void OnTriggerExit(Collider other)
    {
        currentState.OnTriggerExit(other);
    }
    //State currentState;
    //public WalkingToTheDesk_State walkingToTheDeskState = new WalkingToTheDesk_State();
    //public WaitingForApproval_State waitingForApprovalState = new WaitingForApproval_State();
    //public Rejected_State rejectedState = new Rejected_State();
    //public Approved_State approvedState = new Approved_State();
    //// Start is called before the first frame update
    //private void Start()
    //{
    //    ChangeState(walkingToTheDeskState);
    //}

    //// Update is called once per frame
    //void Update()
    //{
    //    currentState.OnStateUpdate();
    //}
    //public void ChangeState(State newState)
    //{
    //    if (currentState != null)
    //    {
    //        currentState.OnStateExit();
    //    }
    //    currentState = newState;
    //    currentState.OnStateEnter();
    //}
}
