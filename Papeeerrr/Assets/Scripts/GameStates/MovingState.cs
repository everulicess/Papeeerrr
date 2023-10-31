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
        if (gM.isMinigame)
        {
            return GameManager.GameState.Minigame_State;
        }
        if (gM.isGameWin)
        {
            return GameManager.GameState.Win_State;
        }
        if (gM.isGameLost)
        {
            return GameManager.GameState.Lose_State;
        }
        return GameManager.GameState.Moving_State;
    }

    public override void UpdateState()
    {
        Debug.Log("MovingState");
    }


}
