using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Minigame : MonoBehaviour
{
    int clicksAmount = 0;
    public void IncreaseNumber()
    {
        clicksAmount++;
        Debug.Log($"{clicksAmount}");
    }
}
