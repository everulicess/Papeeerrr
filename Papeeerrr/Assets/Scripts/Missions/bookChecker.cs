using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bookChecker : MonoBehaviour
{
    Mission_1 mission;
    bool isNear;

    [SerializeField] GameObject book;
    private void Update()
    {
        if (isNear && player.bookNumber > 0)
        {
            mission.isCompleted = true;
            book.SetActive(true);
            player.bookNumber--;
            player.piecesOfPaper++;
        }
    }
    private void Awake()
    {
        mission = FindObjectOfType<Mission_1>();
    }
    Collect player;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isNear = true;
            player = other.GetComponent<Collect>();
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isNear = false;
            player = null;
        }
    }
}
