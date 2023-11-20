using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI nameText;
    [SerializeField] TextMeshProUGUI dialogueText;

    [SerializeField] Animator animator;
    private Queue<string> sentences;

    public bool isDialogue = true;
    GameManager gM;
    // Start is called before the first frame update
    void Start()
    {
        gM = FindObjectOfType<GameManager>();
        sentences = new Queue<string>();
    }

    public void StartDialogue(Dialogue dialogue)
    {
        isDialogue = true;
        dialogueText.text = "";
        gM.isPlayerControl = false;
        gM.isPlayerCameraControl = false;
        gM.VisibleMouse(true);

        animator.SetBool("isOpen", true);


        nameText.text = dialogue.name;

        
        sentences.Clear();

        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }
    }

    public void DisplayNextSentence()
    {
        if (sentences.Count==0)
        {
            EndDialogue();
            return;
        }
        string sentence = sentences.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
        //dialogueText.text = sentence;
    }
   
    IEnumerator TypeSentence (string sentence)
    {
        dialogueText.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            yield return null;
        }
    }
    void EndDialogue()
    {
        isDialogue = false;
        gM.isPlayerControl = true;
        gM.isPlayerCameraControl = true;
        gM.VisibleMouse(false);

        animator.SetBool("isOpen", false);
       
        Debug.Log("DONE TALKING");
    }
}
