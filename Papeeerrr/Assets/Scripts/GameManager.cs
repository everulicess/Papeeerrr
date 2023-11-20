using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
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
    public GameObject minigameObject;
    public bool isMinigame;
    public bool isGameWin;
    public bool isGameLost;

    //Introduction
    public GameObject movementControlsObject;

    public GameObject introObject;
    public GameObject introPart1;
    public GameObject introPart2;
    public GameObject introPart3;
    public GameObject introPart4;
    public GameObject introPart5;

    public GameObject barExplanationObject;
    public GameObject barObject;
    public GameObject paperExplanationObject;
    public GameObject paperObject;

    //interaction
    public bool spacePressed;

    public bool introductionDone;
    public bool movementControlsDone;
    public bool paperExplained;
    public bool barExplained;

    //Poop Bar
    public bool isRunning;
    public bool isBoosted;
    public bool hasEnded;
    //public Slider poopBar;
    //public float normalIncrease = 1 / 360f;
    //public float coffeeIncrease;
    //public float runningIncrease;

    //puzzle 1
    public int puzzle2AmountCorrect;

    //Missions
    

    public int foodPicked;
    public int foodPlaced;
    public int ballsPicked;

    //winning condition
    Collect collect;

    //Menu
    [SerializeField] GameObject Menu;
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
    

    private void Awake()
    {

        Time.timeScale = 1f;
        States[GameState.Menu_State] = new MenuState(this);
        States[GameState.Introduction_State] = new IntroductionState(this);
        States[GameState.Moving_State] = new MovingState(this);
        States[GameState.Minigame_State] = new MinigameState(this);
        States[GameState.Lose_State] = new LoseState(this);
        States[GameState.Win_State] = new WinState(this);

        currentState = States[GameState.Introduction_State];
        VisibleMouse(false);

        poopingBar = Canvas.FindAnyObjectByType<PoopingBar>();
        collect = GameObject.FindAnyObjectByType<Collect>();


    }
    [SerializeField] TextMeshProUGUI toiletText;
    private void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Menu.GetComponent<MenuHandler>().enabled = true;
            Menu.SetActive(true);
            

        }
        if (hasEnded)
        {
            //poopingBar.poopIncrease = 0f;
            SceneManager.LoadScene("Losing Scene");
            return;
        }
        if (collect.piecesOfPaper >= 8)
        {
            toiletText.text = "Go to the toilet!!!!";
        }
        else
        {
            toiletText.text = "";
        }
        if (collect.isToilet)
        {
            if (collect.piecesOfPaper >= 8)
            {
                SceneManager.LoadScene("Winning Scene");

            }
            else
            {
                toiletText.text = "Not enough paper";
                Debug.LogWarning("Need paper before shitting");
            }
            
        }
    }

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
