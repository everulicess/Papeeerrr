using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingState : State<GameManager.GameState>
{
    GameManager gM;
    public MovingState(GameManager _gM) : base(GameManager.GameState.Moving_State)
    {
        gM = _gM;
    }

    public override void EnterState()
    {

    }

    public override void ExitState()
    {

    }

    public override GameManager.GameState GetNextState()
    {
        return GameManager.GameState.Moving_State;
    }

    public override void UpdateState()
    {
        Debug.Log("MovingState");
    }


}
