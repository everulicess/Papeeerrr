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

    public override void EnterState()
    {
        bar.timesHoldItIn++;
        
    }

    public override void ExitState()
    {
        //bar.poopIncrease *= 1.5f;
    }

    public override PoopBarStateMachine.PoopBarState GetNextState()
    {
        return PoopBarStateMachine.PoopBarState.NormalIncrease_State;
    }

    public override void UpdateState()
    {
        Debug.Log("yyyyyyyeeeeeeeeeeeeeeeeaaaaaaaaahhhhhhhhhh");
    }
}
