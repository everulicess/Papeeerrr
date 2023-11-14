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
    GameManager gM;
    public override void EnterState()
    {
        gM = GameObject.FindObjectOfType<GameManager>();
    }

    public override void ExitState()
    {
        throw new System.NotImplementedException();
    }

    public override PoopBarStateMachine.PoopBarState GetNextState()
    {
        return PoopBarStateMachine.PoopBarState.Failed_State;
    }

    public override void UpdateState()
    {

        gM.hasEnded = true;
    }
}
