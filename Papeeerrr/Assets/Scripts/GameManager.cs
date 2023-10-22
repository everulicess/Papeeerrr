using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    PoopingBar poopingBar;
    Collect collect;

    private void Awake()
    {
        VisibleMouse(false);
        
        poopingBar = Canvas.FindAnyObjectByType<PoopingBar>();
        collect = Canvas.FindAnyObjectByType<Collect>();


    }
    private void FixedUpdate()
    {
        if (poopingBar.hasEnded)
        {
            poopingBar.poopIncrease = 0f;
            SceneManager.LoadScene("Losing Scene");
            return;
        }
        if (collect.piecesOfPaper == 4)
        {
            SceneManager.LoadScene("Winning Scene");
            return;
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
