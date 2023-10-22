using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FailedState : State<PoopBarStateMachine.PoopBarState>
{

    PoopBarStateMachine bar;
    public FailedState(PoopBarStateMachine _bar) : base(PoopBarStateMachine.PoopBarState.Failed_State)
    {
        bar = _bar;
    }

    public override void EnterState()
    {
        throw new System.NotImplementedException();
    }

    public override void ExitState()
    {
        throw new System.NotImplementedException();
    }

    public override PoopBarStateMachine.PoopBarState GetNextState()
    {
        throw new System.NotImplementedException();
    }

    public override void UpdateState()
    {
       
        throw new System.NotImplementedException();
    }
}
