using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueTrigger : MonoBehaviour
{
    public Dialogue dialogue;
    [SerializeField] bool isNear;
    int number = 0;
    [SerializeField] TextMeshProUGUI interactText;
    private void Update()
    {
        if (isNear && Input.GetKeyDown(KeyCode.E))
        {
            
            TriggerDialogue();
            if (this.gameObject.name=="NPC")
            {
                
                number++;
                if (number ==1)
                {
                    FindObjectOfType<Collect>().piecesOfPaper += 1;
                }
                
            }
            if (this.gameObject.name=="NPC (1)")
            {
                FindObjectOfType<Mission_1>().isActive = true;
            }
            if (this.gameObject.name == "NPC (2)")
            {
                FindObjectOfType<Mission_2>().isActive = true;
            } 
            if (this.gameObject.name == "NPC (3)"||this.gameObject.name =="NPC (4)")
            {
                FindObjectOfType<Mission_3>().isActive = true;
                FindObjectOfType<Mission_3>().isActive = true;
                interactText.text = "";
            }
        }
        
    }
    public void TriggerDialogue()
    {
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
        FindObjectOfType<DialogueManager>().DisplayNextSentence();
    }
    private void OnTriggerEnter(Collider other)
    {
        
        if (other.CompareTag("Player")  )
        {
            if (this.enabled)
            {
                interactText.text = "[E] Talk";
            }
            else
            {
                interactText.text = "";
            }
            
            isNear = true;
        }
       
    }
    private void OnTriggerExit(Collider other)
    {
        interactText.text = "";
        if (other.CompareTag("Player"))
        {
            interactText.text = "";
            isNear = false;
        }
    }
}
