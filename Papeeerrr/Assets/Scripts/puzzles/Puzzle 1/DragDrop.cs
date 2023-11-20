using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragDrop : MonoBehaviour
{
    [SerializeField] GameObject objectToDrag;
    [SerializeField] GameObject objectDragToPos;

    private bool isLocked;
    private float dropDistance = 20f;

    Vector2 objectInitPos;

    GameManager gM;
    [SerializeField] GameObject objectTriggered;
    // Start is called before the first frame update
    void Start()
    {
        //objectToDrag.transform.position = objectInitPos;
        gM = FindObjectOfType<GameManager>();
        objectInitPos = objectToDrag.transform.position;
        
    }
    private void Update()
    {
        gM.isPlayerCameraControl = false;
        gM.isPlayerControl = false;
        gM.VisibleMouse(true);
    }

    public void DragObject()
    {
        if (!isLocked)
        {
            objectToDrag.transform.position = Input.mousePosition;
        }
    }
    public void DropObject()
    {
        float distance = Vector3.Distance(objectToDrag.transform.position, objectDragToPos.transform.position);
        if (distance<dropDistance)
        {
            isLocked = true;
            objectToDrag.transform.position = objectDragToPos.transform.position;
            gM.puzzle2AmountCorrect++;
            if (gM.puzzle2AmountCorrect == 5)
            {
                objectTriggered.GetComponent<Puzzle_1_Trigger>().isFinished = true;
                gM.isPlayerCameraControl = true;
                gM.isPlayerControl = true;
                gM.VisibleMouse(false);
            }
        }
        else
        {
            objectToDrag.transform.position = objectInitPos;
        }
    }
}
