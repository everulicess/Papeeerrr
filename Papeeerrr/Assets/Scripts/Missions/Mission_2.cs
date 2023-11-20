using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Mission_2 : MonoBehaviour
{
    // mission go to the cafeteria and pick up 2 things and leave it at the table at the back
    //Take a book to the library
    public bool isActive;

    //book
    public Collider[] missionColliders;
    public bool bookPlaced;

    public bool is1Completed;
    public bool is2Completed;
    public bool isCompleted;

    [SerializeField] GameObject[] visualFeedback;
    [SerializeField] TextMeshProUGUI missionText;
    [SerializeField] TextMeshProUGUI missionText2;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        var player = FindObjectOfType<Collect>();
        
        if (is1Completed&&is2Completed)
        {
            isCompleted = true;
        }
        if (isCompleted&&isNear)
        {
            this.gameObject.GetComponent<DialogueTrigger>().enabled = false;
            isActive = false;
            missionText.text = "completed";
            foreach (GameObject vf in visualFeedback)
            {
                vf.SetActive(false);
            }
            //visualFeedback.SetActive(false);
            Debug.Log("mission accomplished");
            this.enabled = false;

        }
        if (isActive && !isCompleted)
        {
            if (is1Completed)
            {
                //player.foodNumber = 2;
                missionText.text = $"Completed";

            }
            else
            {
                missionText.text = $"collect food {player.foodNumber}/2";
            }
            
            foreach (GameObject vf in visualFeedback)
            {
                vf.SetActive(true);
            }
            
            
            if (player.foodNumber == 2)
            {
                missionText.text = $"put the food on the table on the left";
                

            }
            if (is2Completed)
            {
                //player.ballsNumber = 3;
                missionText2.text = $"Completed";

            }
            else
            {
                missionText2.text = $"collect balls {player.ballsNumber}/3";
            }
            
            if (player.ballsNumber==3)
            {
                missionText2.text = $"give Rick the balls";
                

            }
            foreach (Collider col in missionColliders)
            {
                col.enabled = true;
            }
            

        }
    }
    bool isNear;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isNear = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isNear = false;
        }
    }
}
