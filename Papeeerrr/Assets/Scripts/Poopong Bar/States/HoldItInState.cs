using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoldItInState : State<PoopBarStateMachine.PoopBarState>
{
    PoopBarStateMachine bar;
    public HoldItInState(PoopBarStateMachine _bar): base(PoopBarStateMachine.PoopBarState.HoldItIn_State)
    {
        bar = _bar;
    }

    GameManager gM;

    public override void EnterState()
    {
        gM = GameObject.FindObjectOfType<GameManager>();
        bar.timesHoldItIn++;
        gM.isMinigame = true;
        bar.winMinigame = false;
        bar.loseMinigame = false;
        bar.poopIncrease = 0f;
        
    }

    public override void ExitState()
    {
        gM.isMinigame = false;
        bar.poopIncrease *= 1.5f;
        Debug.Log("holditin state");
    }

    public override PoopBarStateMachine.PoopBarState GetNextState()
    {
        if (bar.winMinigame)
        {
            bar.poopingSliser.value -= 2 / 12f;
            return PoopBarStateMachine.PoopBarState.NormalIncrease_State;

        }
        else if (bar.loseMinigame)
        {
            return PoopBarStateMachine.PoopBarState.NormalIncrease_State;
        }
        return PoopBarStateMachine.PoopBarState.HoldItIn_State;
    }

    public override void UpdateState()
    {
        if (bar.loseMinigame||bar.winMinigame)
        {
            gM.isMinigame = false;
        }
        Debug.Log("yyyyyyyeeeeeeeeeeeeeeeeaaaaaaaaahhhhhhhhhh");
    }
}
