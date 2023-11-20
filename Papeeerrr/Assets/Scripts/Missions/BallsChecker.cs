using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallsChecker : MonoBehaviour
{
    Mission_2 mission;
    bool isNear;

    [SerializeField] GameObject ball;
    [SerializeField] GameObject ball2;
    [SerializeField] GameObject ball3;
    private void Update()
    {
        if (isNear && player.ballsNumber > 0)
        {
            if (!ball.activeInHierarchy)
            {
                ball.SetActive(true);
                player.ballsNumber--;
            }
            else if (!ball2.activeInHierarchy)
            {
                ball2.SetActive(true);
                player.ballsNumber--;
            }
            else
            {
                ball3.SetActive(true);
                player.ballsNumber--;
                mission.is2Completed = true;
            }


        }
    }
    private void Awake()
    {
        mission = FindObjectOfType<Mission_2>();
    }
    Collect player;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isNear = true;
            player = other.GetComponent<Collect>();
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isNear = false;
            player = null;
        }
    }
}
