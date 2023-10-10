using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GameManager : MonoBehaviour
{
    PoopingBar poopingBar;
    private void Awake()
    {
        poopingBar = Canvas.FindAnyObjectByType<PoopingBar>();
    }
    private void FixedUpdate()
    {
        if (poopingBar.hasEnded)
        {
            Application.Quit();
        }
    }
}
