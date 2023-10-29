using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;

public class GameManager : StateController<GameManager.GameState>
{
    //player
    public bool isPlayerControl;
    public bool isPlayerCameraControl;

    //Menu
    public bool isMenu = false;
    //tutorial
    public bool isTutorialFinished = false;

    //MiniGame variables
    [SerializeField] GameObject minigameObject;
    public bool isMinigame;

    //Introduction
    public GameObject movementControlsObject;
    public GameObject introductionObject;
    public GameObject barExplanationObject;
    public GameObject paperExplanationObject;

    public bool introductionDone;
    public bool movementControlsDone;
    public bool movementControlsDoe;
    public bool barExplained;
    public bool l;
    public enum GameState
    {
        Menu_State,
        Introduction_State,
        Moving_State,
        Minigame_State,
        Lose_State,
        Win_State
    }

    PoopingBar poopingBar;
    Collect collect;

    private void Awake()
    {
        States[GameState.Menu_State] = new MenuState(this);
        States[GameState.Introduction_State] = new IntroductionState(this);
        States[GameState.Moving_State] = new MovingState(this);
        States[GameState.Minigame_State] = new MinigameState(this);
        States[GameState.Lose_State] = new LoseState(this);
        States[GameState.Win_State] = new WinState(this);

        currentState = States[GameState.Introduction_State];
        VisibleMouse(false);

        poopingBar = Canvas.FindAnyObjectByType<PoopingBar>();
        collect = Canvas.FindAnyObjectByType<Collect>();


    }
    //private void FixedUpdate()
    //{
    //    if (poopingBar.hasEnded)
    //    {
    //        poopingBar.poopIncrease = 0f;
    //        SceneManager.LoadScene("Losing Scene");
    //        return;
    //    }
    //    if (collect.piecesOfPaper == 4)
    //    {
    //        SceneManager.LoadScene("Winning Scene");
    //        return;
    //    }
    //}

    public void VisibleMouse(bool boolean)
    {
        if (!boolean)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
        else
        {
            Cursor.lockState = CursorLockMode.Confined;
            Cursor.visible = true;

        }


    }

}
