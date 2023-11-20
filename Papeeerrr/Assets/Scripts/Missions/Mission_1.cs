using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Mission_1 : MonoBehaviour
{
    //Take a book to the library
    public bool isActive;

    //book
    public Collider bookCollider;
    //public bool bookPlaced;

    public bool isCompleted;

    [SerializeField] GameObject visualFeedback;
    [SerializeField] TextMeshProUGUI missionText;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isCompleted&&isNear)
        {
            this.gameObject.GetComponent<DialogueTrigger>().enabled = false;
            isActive = false;
            missionText.text = "completed";
            visualFeedback.SetActive(false);
            Debug.Log("mission accomplished");
            this.enabled = false;

        }
        if (isActive&&!isCompleted)
        {
            visualFeedback.SetActive(true);
            missionText.text = "Take the book to the library     +1";
            bookCollider.enabled = true;
            
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
