using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Mission_3 : MonoBehaviour
{
    //Mission to put 2 books in the right tables
    public bool isActive;

    //book
    public Collider[] colliders;
    //public bool bookPlaced;

    public bool isCompleted;

    [SerializeField] GameObject visualFeedback;
    [SerializeField] TextMeshProUGUI missionText;

    [SerializeField] GameObject NPC;
    [SerializeField] GameObject NPCreplace1;
    [SerializeField] GameObject NPCreplace2;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        var player = FindObjectOfType<Collect>();
        if (isCompleted && isNear)
        {
            this.gameObject.GetComponent<DialogueTrigger>().enabled = false;
            isActive = false;
            
            missionText.text = "completed";
            visualFeedback.SetActive(false);
            Debug.Log("mission accomplished");
            this.gameObject.SetActive(false);
            NPC.GetComponent<DialogueTrigger>().enabled = false;
            NPC.SetActive(false);
            NPCreplace1.SetActive(true);
            NPCreplace2.SetActive(true);
            this.enabled = false;
        }
        if (isActive && !isCompleted)
        {
            visualFeedback.SetActive(true);
            missionText.text = $"prepare the study place {player.booksPickedNumber}/3";
            foreach (Collider col in colliders)
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
