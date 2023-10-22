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
    }

    public override void ExitState()
    {
    }

    public override PoopBarStateMachine.PoopBarState GetNextState()
    {
        throw new System.NotImplementedException();
    }

    public override void UpdateState()
    {
        Debug.Log("yyyyyyyeeeeeeeeeeeeeeeeaaaaaaaaahhhhhhhhhh");
    }
}
