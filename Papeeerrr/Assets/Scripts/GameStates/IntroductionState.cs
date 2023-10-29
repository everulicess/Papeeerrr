using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntroductionState : State<GameManager.GameState>
{
    GameManager gM;
    public IntroductionState(GameManager _gM) : base(GameManager.GameState.Introduction_State)
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
        
    }

    
}
