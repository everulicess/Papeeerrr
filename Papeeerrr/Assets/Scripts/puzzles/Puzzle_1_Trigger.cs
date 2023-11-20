using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Puzzle_1_Trigger : MonoBehaviour
{
    [SerializeField] GameObject puzzleObject;
    public bool isFinished;
    
    bool isNear;
    [SerializeField] TextMeshProUGUI interactText;

    // Start is called before the first frame update
    void Start()
    {
        mission = FindObjectOfType<Mission_2>();
    }
    Mission_2 mission;
    // Update is called once per frame
    void Update()
    {
        if (isNear&& Input.GetKeyDown(KeyCode.E))
        {
            if (this.gameObject.name != "PuzzleTrigger"||mission.isCompleted)
            {
                puzzleObject.SetActive(true);
            }
            else
            {
                Debug.LogWarning("Finish the mission first");
            }
            
            

        }
        if (isFinished)
        {
            puzzleObject.SetActive(false);
            interactText.text = "";
            this.gameObject.SetActive(false);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            interactText.text = "[E] Puzzle";
            isNear = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
            interactText.text = "";
        {
            isNear = false;
        }
    }
}
