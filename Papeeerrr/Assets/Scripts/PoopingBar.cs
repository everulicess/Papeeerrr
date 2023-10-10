using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PoopingBar : MonoBehaviour
{
    [SerializeField]Slider poopingSlider;
    public float poopIncrease = 0.01f;

    public bool hasEnded = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (poopingSlider.value > poopingSlider.maxValue/2)
        {
            poopIncrease = 0.1f;
        }
        if (poopingSlider.value == poopingSlider.maxValue)
        {
            hasEnded = true;
        }
        poopingSlider.value += poopIncrease * Time.deltaTime;

    }
}
