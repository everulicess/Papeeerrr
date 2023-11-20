using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puzzle3 : MonoBehaviour
{
    [SerializeField] GameObject triggerObject;

    GameManager gM;
    // Start is called before the first frame update
    void Start()
    {
        gM = GameObject.FindObjectOfType<GameManager>();
        gM.VisibleMouse(true);
        gM.isPlayerControl = false;
        gM.isPlayerCameraControl = false;

    }
    private void Update()
    {
        gM.VisibleMouse(true);
        gM.isPlayerControl = false;
        gM.isPlayerCameraControl = false;
    }
    public void SolvePuzzle()
    {
        triggerObject.GetComponent<Puzzle_1_Trigger>().isFinished = true;
        gM.VisibleMouse(false);
        gM.isPlayerControl = true;
        gM.isPlayerCameraControl = true;
        this.gameObject.SetActive(false);
    }
}
