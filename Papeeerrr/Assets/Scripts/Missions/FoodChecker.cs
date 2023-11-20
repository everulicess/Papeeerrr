using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodChecker : MonoBehaviour
{
    Mission_2 mission;
    bool isNear;

    [SerializeField] GameObject food;
    [SerializeField] GameObject food2;
    private void Update()
    {
        if (isNear && player.foodNumber > 0)
        {
            if (!food.activeInHierarchy)
            {
                food.SetActive(true);
                player.foodNumber--;
            }
            else
            {
                
                food2.SetActive(true);
                player.foodNumber--;
                mission.is1Completed = true;
                this.enabled = false;
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
