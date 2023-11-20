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
        Debug.Log("FAILED STATE");
        gM = GameObject.FindObjectOfType<GameManager>();
        bar.poopIncrease = 1 / 120f;
    }

    public override void ExitState()
    {
        
    }

    public override PoopBarStateMachine.PoopBarState GetNextState()
    {
        return PoopBarStateMachine.PoopBarState.Failed_State;
    }

    public override void UpdateState()
    {
        if (gM.isRunning)
        {
            bar.poopIncrease = 3 / 120f;
        }
        else
        {
            bar.poopIncrease = 1 / 120f;
        }
        bar.poopingSliser.value += bar.poopIncrease * Time.deltaTime;
        if (bar.poopingSliser.value>=1f)
        {
            gM.hasEnded = true;
        }
        
    }
}
