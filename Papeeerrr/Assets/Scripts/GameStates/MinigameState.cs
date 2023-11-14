using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinigameState : State<GameManager.GameState>
{
    GameManager gM;
    public MinigameState(GameManager _gM) : base(GameManager.GameState.Minigame_State)
    {
        gM = _gM;
    }

    public override void EnterState()
    {
        
        gM.minigameObject.SetActive(true);
        gM.isPlayerCameraControl = false;
        gM.isPlayerControl = false;
    }

    public override void ExitState()
    {
        gM.minigameObject.SetActive(false);
        gM.isPlayerCameraControl = true;
        gM.isPlayerControl = true;
    }

    public override GameManager.GameState GetNextState()
    {
        if (!gM.isMinigame)
        {
           
            return GameManager.GameState.Moving_State;
            
            
        }
        return GameManager.GameState.Minigame_State;
    }

    public override void UpdateState()
    {
        Debug.Log("mingame sTATEEEEEEEE");
    }


}