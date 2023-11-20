using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Puzzle2 : MonoBehaviour
{
    [SerializeField] TMP_InputField answer;
    [SerializeField] GameObject triggerObject;

    [SerializeField] GameObject prompt;
    GameManager gM;
    // Start is called before the first frame update
    void Start()
    {
        gM = GameObject.FindObjectOfType<GameManager>();
        gM.VisibleMouse(true);
        gM.isPlayerControl = false;
        gM.isPlayerCameraControl = false;

    }

    // Update is called once per frame
    void Update()
    {
        gM.VisibleMouse(true);
        gM.isPlayerControl = false;
        gM.isPlayerCameraControl = false;

    }
    public void CheckAnswer()
    {
        if (answer.text=="7"||answer.text=="seven"||answer.text=="Seven"||answer.text=="SEVEN")
        {
            triggerObject.GetComponent<Puzzle_1_Trigger>().isFinished=true;
            gM.VisibleMouse(false);
            gM.isPlayerControl = true;
            gM.isPlayerCameraControl = true;
            this.gameObject.SetActive(false);
        }
        else
        {
            gM.VisibleMouse(false);
            gM.isPlayerControl = true;
            gM.isPlayerCameraControl = true;
            answer.text = "";
            this.gameObject.SetActive(false);
            prompt.SetActive(true);

        }

    }
}
