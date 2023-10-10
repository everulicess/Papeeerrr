using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Collect : MonoBehaviour
{
    bool isNear = false;

    public int piecesOfPaper = 0;
    GameObject collectable;
    [SerializeField]TextMeshProUGUI piecesOfPaper_text;
    [SerializeField]TextMeshProUGUI interact_text;

    private void Awake()
    {
        interact_text.text = "";
        piecesOfPaper_text.text = "";
    }
    private void Update()
    {
        if (isNear && Input.GetKeyDown(KeyCode.E))
        {
            Destroy(collectable);
            piecesOfPaper += 1;
            piecesOfPaper_text.text = $"paper:{piecesOfPaper}";
            isNear = false;
            interact_text.text = "";
        }
        Debug.Log($"{piecesOfPaper}");
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Collectable"))
        {
            isNear = true;
            collectable = other.gameObject;
            interact_text.text = "[E]";
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Collectable"))
        {
            isNear = false;
            collectable = null;
            interact_text.text = "";
        }
    }
}
