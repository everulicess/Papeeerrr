using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PoopBarStateMachine : StateController<PoopBarStateMachine.PoopBarState>
{
    public Slider poopingSliser;

    public float poopIncrease;
    public float decreaseAmount;

    public bool winMinigame;
    public bool loseMinigame;
    public int timesHoldItIn = 0;
    public enum PoopBarState
    {
        waiting_State,
        NormalIncrease_State,
        HoldItIn_State,
        Failed_State,

    }
    private void Awake()
    {
        States[PoopBarState.waiting_State] = new WaitState(this);
        States[PoopBarState.NormalIncrease_State] = new NormalIncreaseState(this);
        States[PoopBarState.HoldItIn_State] = new HoldItInState(this);
        States[PoopBarState.Failed_State] = new FailedState(this);

        currentState = States[PoopBarState.waiting_State];
    }
}
