using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Minigame : MonoBehaviour
{
    //[SerializeField] Transform topPivot;
    //[SerializeField] Transform bottomPivot;

    //[SerializeField] Transform poop;

    //float poopPosition;
    //float poopDestination;

    //float poopTimer;
    //[SerializeField] float timerMultiplicator = 3f;

    //float poopSpeed;
    //[SerializeField] float smoothMotion = 1f;

    //[SerializeField] Transform hook;
    //float hookPosition;
    //[SerializeField] float hookSize = 0.1f;
    //[SerializeField] float hookPower = 5f;
    //float hookProgress;
    //float hookPullVelocity;
    //[SerializeField] float hookPullPower = 0.01f;
    //[SerializeField] float hookGravityPower = 0.05f;
    //[SerializeField] float hookProgressDegradationPower = 0.1f;


    [SerializeField] TextMeshProUGUI timerText;
    [SerializeField] TextMeshProUGUI clicksText;

    [SerializeField] PoopingBar poopingBar;

    int clickAmount = 20;
    int currentClickAmount = 0;
    GameManager gameManager;
    private void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        
        poopingBar = FindObjectOfType<PoopingBar>();
    }
    private void Update()
    {
        gameManager.VisibleMouse(true);
        Hook();
        Poop();
        clicksText.text = $"Clicks: {currentClickAmount}/{clickAmount} ";
    }
    public void OnButtonClicked()
    {
        if (currentClickAmount < clickAmount)
        {
            currentClickAmount++;
        }
        else if (currentClickAmount == clickAmount)
        {
            poopingBar.OnMiniGameWon();
            gameManager.VisibleMouse(false);
            this.gameObject.SetActive(false);
            clickAmount += 10;
            currentClickAmount = 0;

        }
        
    }
    void Hook()
    {
        //if (Input.GetMouseButtonDown(0))
        //{
        //    hookPullVelocity += hookPullPower * Time.deltaTime;
        //    Debug.Log("pressing mouese button");
        //}
        //hookPullVelocity -= hookGravityPower * Time.deltaTime;

        //hookPosition += hookPullVelocity;
        //hookPosition = Mathf.Clamp(hookPosition, hookSize/2,1-hookSize/2);
        //hook.position = Vector3.Lerp(bottomPivot.position, topPivot.position, hookPosition);

    }
    void Poop()
    {
        //    poopTimer -= Time.deltaTime;

        //    if (poopTimer < 0f)
        //    {
        //        poopTimer = UnityEngine.Random.value * timerMultiplicator;

        //        poopDestination = UnityEngine.Random.value;
        //    }

        //    poopPosition = Mathf.SmoothDamp(poopPosition, poopDestination, ref poopSpeed, smoothMotion);
        //    poop.position = Vector3.Lerp(bottomPivot.position, topPivot.position, poopPosition);
    }

}
