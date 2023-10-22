using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PoopingBar : MonoBehaviour
{
    [SerializeField]Slider poopingSlider;
    public float poopIncrease = 0.03f;

    public bool hasEnded = false;

    [SerializeField] GameObject minigame;
    // Update is called once per frame
    void Update()
    {
        if (poopingSlider.value > poopingSlider.maxValue/4)
        {
            poopIncrease += 0.02f;
            Debug.Log("more than a quarter");
        }
        if (poopingSlider.value < poopingSlider.maxValue)
        {
            poopingSlider.value += poopIncrease * Time.deltaTime;
            
        }
        if (poopingSlider.value >= poopingSlider.maxValue - 0.5f)
        {
            minigame.SetActive(true);
            poopIncrease = 0f;
            
        }
        if (poopingSlider.value >= poopingSlider.maxValue)
        {
            hasEnded = true;
        }
        
        
    }
    public void OnMiniGameWon()
    {
        poopingSlider.value -= poopingSlider.maxValue/10;
    }
}
