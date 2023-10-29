using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaitState : State<PoopBarStateMachine.PoopBarState>
{
    PoopBarStateMachine bar;
    public WaitState(PoopBarStateMachine _bar) : base(PoopBarStateMachine.PoopBarState.waiting_State)
    {
        bar = _bar;
    }


    GameManager gM;
    public override void EnterState()
    {
        gM = GameObject.FindObjectOfType<GameManager>();
        bar.poopIncrease = 0f;
    }

    public override void ExitState()
    {
        //bar.poopIncrease = 1/120;
    }

    public override PoopBarStateMachine.PoopBarState GetNextState()
    {
        if (gM.movementControlsDone)
        {
            return PoopBarStateMachine.PoopBarState.NormalIncrease_State;
        }
        return PoopBarStateMachine.PoopBarState.waiting_State;
    }

    public override void UpdateState()
    {
        
    }
}

