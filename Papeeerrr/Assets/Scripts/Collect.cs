using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Collect : MonoBehaviour
{
    bool isCollectableNear = false;
    bool isNear1 = false;
    bool isNear21 = false;
    bool isNear22 = false;
    bool isNear3 = false;
    public bool isToilet;

    public int piecesOfPaper = 0;
    GameObject collectable;
    [SerializeField]TextMeshProUGUI piecesOfPaper_text;
    [SerializeField]TextMeshProUGUI interact_text;

    GameManager gM;

    public int bookNumber;

    public int foodNumber;
    public int ballsNumber;

    public int booksPickedNumber;

    private void Awake()
    {
        gM = GameObject.FindObjectOfType<GameManager>();
        interact_text.text = "";
        //piecesOfPaper_text.text = "";
        
        
    }
    private void Update()
    {
        piecesOfPaper_text.text = $"paper:{piecesOfPaper}/8";
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (isCollectableNear)
            {
                gM.paperExplained = true;
                piecesOfPaper += 1;
                isCollectableNear = false;
                interact_text.text = "";
                //piecesOfPaper_text.text = $"paper:{piecesOfPaper}/8";
                //Destroy(collectable);
            }
            if (isNear1)
            {
                isNear1 = false;
                bookNumber++;
                interact_text.text = "";
                Debug.Log("MIssion Picked");
                //Destroy(collectable);
            }
            if (isNear21)
            {
                isNear21 = false;
                foodNumber++;
                interact_text.text = "";
            } 
            if (isNear22)
            {
                isNear22 = false;
                ballsNumber++;
                interact_text.text = "";
            }
            if (isNear3)
            {
                isNear3 = false;
                booksPickedNumber++;
                interact_text.text = "";
            }
            Destroy(collectable);



        }
        //if (isNear && Input.GetKeyDown(KeyCode.E))
        //{
        //    gM.paperExplained = true;
        //    Destroy(collectable);
        //    piecesOfPaper += 1;
        //    piecesOfPaper_text.text = $"paper:{piecesOfPaper}/4";
        //    isNear = false;
        //    interact_text.text = "";
        //}
        Debug.Log($"{piecesOfPaper}");
    }
    private void OnTriggerEnter(Collider other)
    {
        
        
        string tagName = other.tag;
        switch (tagName)
        {
            case "Mission":
                //Debug.LogError("SWITCH MISSION");
                isNear1 = true;
                collectable = other.gameObject;
                interact_text.text = "[E]";
                break;
            case "Mission 3":
                //Debug.LogError("SWITCH MISSION");
                isNear3 = true;
                collectable = other.gameObject;
                interact_text.text = "[E]";
                break;
            case "Mission 2 Food":
                //Debug.LogError("SWITCH MISSION");
                isNear21 = true;
                collectable = other.gameObject;
                interact_text.text = "[E]";
                break;
            case "Mission 2 Balls":
                //Debug.LogError("SWITCH MISSION");
                isNear22 = true;
                collectable = other.gameObject;
                interact_text.text = "[E]";
                break;
            case "Toilet":
                isToilet = true;
                //Debug.LogError("SWITCH TOILET");

                break;
            case "Collectable":
                //Debug.LogError("SWITCH COLLECTABLE");
                collectable = other.gameObject;
                interact_text.text = "[E]";

                isCollectableNear = true;
                break;
            case "Boost":
                //Debug.LogError("SWITCH Boost");

                break;
            default:
                
                break;
        }
       
    }
    private void OnTriggerExit(Collider other)
    {
        string tagName = other.tag;
        switch (tagName)
        {
            case "Mission":
                Debug.LogError("SWITCH MISSION");
                isNear1 = false;
                collectable = null;
                interact_text.text = "";
                break;
            case "Mission 3":
                Debug.LogError("SWITCH MISSION");
                isNear3 = false;
                collectable = null;
                interact_text.text = "";
                break;
            case "Mission 2 Food":
                Debug.LogError("SWITCH MISSION");
                isNear21 = false;
                collectable = null;
                interact_text.text = "";
                break;
            case "Mission 2 Balls":
                Debug.LogError("SWITCH MISSION");
                isNear22 = false;
                collectable = null;
                interact_text.text = "";
                break;
            case "Toilet":
                isToilet = false;
                Debug.LogError("SWITCH TOILET");

                break;
            case "Collectable":
                Debug.LogError("SWITCH COLLECTABLE");
                isCollectableNear = false;
                collectable = null;
                interact_text.text = "";
                break;
            case "Boost":
                Debug.LogError("SWITCH Boost");

                break;
            default:
                
                break;
        }
    }

    //make a method to check for the item that is being collected
    public void CheckItem(string tagName)
    {
       
    }
}
