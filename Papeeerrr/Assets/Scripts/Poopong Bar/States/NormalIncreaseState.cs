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

    GameManager gM;

    public override void EnterState()
    {
        gM = GameObject.FindObjectOfType<GameManager>();
        bar.poopIncrease = 1/120f;

        Debug.Log($"increase value is {bar.poopIncrease}");
    }

    public override void ExitState()
    {
    }

    public override PoopBarStateMachine.PoopBarState GetNextState()
    {

        switch (bar.timesHoldItIn)
        {
            case 0:
                if (bar.poopingSliser.value >= 0.80f)
                {

                    return PoopBarStateMachine.PoopBarState.HoldItIn_State;
                }
                break;
            case 1:
                if (bar.poopingSliser.value >= 0.84f)
                {
                    return PoopBarStateMachine.PoopBarState.HoldItIn_State;
                }
                break;
            case 2:
                if (bar.poopingSliser.value >= 0.88f)
                {
                    return PoopBarStateMachine.PoopBarState.HoldItIn_State;
                }
                break;
            case 3:
                if (bar.poopingSliser.value >= 0.92f)
                {
                    return PoopBarStateMachine.PoopBarState.HoldItIn_State;
                }
                break;
            case 4:
                if (bar.poopingSliser.value >= 0.96f)
                {
                    return PoopBarStateMachine.PoopBarState.HoldItIn_State;
                }
                break;
            case 5:
                if (bar.poopingSliser.value >= 1f)
                {
                    return PoopBarStateMachine.PoopBarState.HoldItIn_State;
                }
                break;
            default:
                break;
        }

        return PoopBarStateMachine.PoopBarState.NormalIncrease_State;
    }

    public override void UpdateState()
    {
        

        bar.poopingSliser.value += bar.poopIncrease * Time.deltaTime;
        Debug.Log($"max value is {bar.poopingSliser.maxValue}");
        Debug.Log($"increase value is {bar.poopIncrease}");
        Debug.Log($"normal value of the bar is {bar.poopingSliser.value}");


    }
}
