using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEditor;

public class MenuHandler : MonoBehaviour
{
    private void Start()
    {
        
    }
   
    private void OnDisable()
    {
        
    }
    private void Update()
    {
        //if (SceneManager.GetActiveScene().name == "SampleScene")
        //{
            if (this.gameObject.activeInHierarchy)
            {
                Time.timeScale = 0f;
                Cursor.lockState = CursorLockMode.Confined;
                Cursor.visible = true;
                //if (Input.GetKeyDown(KeyCode.Escape))
                //{
                //    OnCloseClicked();
                //}
            }
            else
            {
                Time.timeScale = 1f;
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
            }
            
        //}
    }
    public void OnStartGameClicked()
    {
        
        SceneManager.LoadScene("SampleScene",0);
    }
    public void OnCloseClicked()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        Time.timeScale = 1f;
        this.enabled = false;
        this.gameObject.SetActive(false);
    }
    public void OnMenuClicked()
    {
        SceneManager.LoadScene("Menu Scene");
    }
    public void OnQuitGameClicked()
    {

        Application.Quit();
    }
}
