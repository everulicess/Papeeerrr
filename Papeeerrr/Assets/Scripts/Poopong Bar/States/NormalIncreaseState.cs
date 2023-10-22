using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalIncreaseState : State<PoopBarStateMachine.PoopBarState>
{
    PoopBarStateMachine bar;
    public NormalIncreaseState(PoopBarStateMachine _bar): base(PoopBarStateMachine.PoopBarState.NormalIncrease_State)
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
        if (Input.GetKeyDown(KeyCode.P))
        {
            return PoopBarStateMachine.PoopBarState.HoldItIn_State;

        }
        return PoopBarStateMachine.PoopBarState.NormalIncrease_State;
    }

    public override void UpdateState()
    {
        bar.poopingSliser.value += bar.poopIncrease * Time.deltaTime;
    }
}
