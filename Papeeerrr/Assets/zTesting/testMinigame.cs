using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testMinigame : MonoBehaviour
{
    [SerializeField] GameObject holdObject;

    Vector3 scale = new Vector3(0.65f, 0.65f, 0.65f);
    Vector3 scaleDecrease = new Vector3(0.12f, 0.12f, 0.12f);
    Vector3 initScale = new Vector3(1f, 1f, 1f);

    GameManager gM;
    PoopBarStateMachine bar;
    // Start is called before the first frame update
    void Start()
    {
        gM = FindObjectOfType<GameManager>();

        bar = FindObjectOfType<PoopBarStateMachine>();
        holdObject.transform.localScale = initScale;
        timer = 2f;
    }
    float timer=2f;
    bool issmaller;
    // Update is called once per frame
    void Update()
    {
        gM.VisibleMouse(true);
        holdObject.transform.localScale += scale * Time.deltaTime;
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("DECREASING");
            holdObject.transform.localScale -= scaleDecrease;
            if (holdObject.GetComponent<RectTransform>().localScale.x < 0.1f)
            {
                
            }

        }
        if (holdObject.GetComponent<RectTransform>().localScale.x < 1f)
        {
            issmaller = true;

            Debug.LogWarning(issmaller);
        }
        else
        {
            issmaller = false; ;
        }
        if (issmaller)
        {

            timer -= Time.deltaTime;
            Debug.Log(timer);
            if (timer <= 0f)
            {
                timer = 2f;
                gM.VisibleMouse(false);
                bar.winMinigame = true;
                Debug.Log("YOU WONNNNNNN");
            }
        }

        if (holdObject.GetComponent<RectTransform>().localScale.x > 3f)
        {
            bar.loseMinigame = true;
            Debug.Log("YOU LOOOOOOOOSSSTTTT");
            //this.gameObject.SetActive(false);
        }
    }
}
