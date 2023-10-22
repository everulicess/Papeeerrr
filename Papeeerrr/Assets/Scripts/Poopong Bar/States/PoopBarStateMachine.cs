using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PoopBarStateMachine : StateController<PoopBarStateMachine.PoopBarState>
{
    public Slider poopingSliser;

    public float poopIncrease = 0.03f;
    public enum PoopBarState
    {
        NormalIncrease_State,
        HoldItIn_State,
        Failed_State,

    }
    private void Awake()
    {
        States[PoopBarState.NormalIncrease_State] = new NormalIncreaseState(this);
        States[PoopBarState.HoldItIn_State] = new HoldItInState(this);
        States[PoopBarState.Failed_State] = new FailedState(this);

        currentState = States[PoopBarState.NormalIncrease_State];
    }
}
