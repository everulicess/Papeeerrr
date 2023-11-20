using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LibraryChecker : MonoBehaviour
{
    Mission_3 mission;
    bool isNear;

    [SerializeField] GameObject book1;
    [SerializeField] GameObject book2;
    [SerializeField] GameObject book3;
    private void Update()
    {
        if (isNear && player.booksPickedNumber > 0)
        {
            if (!book1.activeInHierarchy)
            {
                book1.SetActive(true);
                player.booksPickedNumber--;
            }
            else if (!book2.activeInHierarchy)
            {
                book2.SetActive(true);
                player.booksPickedNumber--;
            }
            else
            {
                book3.SetActive(true);
                mission.isCompleted = true;
                player.booksPickedNumber--;
                player.piecesOfPaper++;
            }
        }
    }
    private void Awake()
    {
        mission = FindObjectOfType<Mission_3>();
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
