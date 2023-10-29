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

    

    IntroState introState;
    public enum IntroState
    {
        Part1,
        Part2,
        Part3,
        Part4,
        Part5,
        MovExplain,
        BarExplain,
        PaperExplain

    }
    public override void EnterState()
    {
        introState = IntroState.Part1;
        gM.introPart1.SetActive(false);
        gM.introPart2.SetActive(false);
        gM.introPart3.SetActive(false);
        gM.introPart4.SetActive(false);
        gM.introPart5.SetActive(false);

        gM.paperObject.SetActive(false);
        gM.barObject.SetActive(false);
    }

    public override void ExitState()
    {
        
    }

    public override GameManager.GameState GetNextState()
    {
        if (gM.introductionDone)
        {
            return GameManager.GameState.Moving_State;
        }
        return GameManager.GameState.Introduction_State;
    }

    public override void UpdateState()
    {
        if (gM.spacePressed)
        {
            Debug.Log("Space pressed");
        }
        switch (introState)
        {
            case IntroState.Part1:
                gM.isPlayerCameraControl = false;
                gM.isPlayerControl = false;
                gM.introPart1.SetActive(true);
                if (gM.spacePressed)
                {
                    gM.introPart1.SetActive(false);
                    introState = IntroState.Part2;
                }
                break;
            case IntroState.Part2:
                gM.introPart2.SetActive(true);
                if (gM.spacePressed)
                {
                    gM.introPart2.SetActive(false);
                    introState = IntroState.Part3;
                }
                break;
            case IntroState.Part3:
                gM.introPart3.SetActive(true);
                if (gM.spacePressed)
                {
                    gM.introPart3.SetActive(false);
                    introState = IntroState.Part4;
                }
                break;
            case IntroState.Part4:
                gM.introPart4.SetActive(true);
                if (gM.spacePressed)
                {
                    gM.introPart4.SetActive(false);
                    introState = IntroState.Part5;
                }
                break;
            case IntroState.Part5:
                gM.introPart5.SetActive(true);
                if (gM.spacePressed)
                {
                    gM.introObject.SetActive(false);
                    gM.introPart5.SetActive(false);
                    introState = IntroState.MovExplain;
                }
                break;
            case IntroState.MovExplain:
                gM.isPlayerCameraControl = true;
                gM.isPlayerControl = true;
                gM.movementControlsObject.SetActive(true);
                if (gM.movementControlsDone)
                {
                    gM.movementControlsObject.SetActive(false);
                    introState = IntroState.BarExplain;
                }
                break;
            case IntroState.BarExplain:
                gM.barExplanationObject.SetActive(true);
                gM.barObject.SetActive(true);
                if (gM.barExplained)
                {
                    gM.barExplanationObject.SetActive(false);
                    introState = IntroState.PaperExplain;
                }
                break;
            case IntroState.PaperExplain:
                gM.paperExplanationObject.SetActive(true);
                gM.paperObject.SetActive(true);
                if (gM.paperExplained)
                {
                    gM.paperExplanationObject.SetActive(false);
                    gM.introductionDone = true;
                }
                break;
            default:
                break;
        }
    }

    
}
