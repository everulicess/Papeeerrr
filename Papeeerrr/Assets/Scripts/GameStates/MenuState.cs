using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuState : State<GameManager.GameState>
{
    GameManager gM;
    public MenuState(GameManager _gM) : base(GameManager.GameState.Menu_State)
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
