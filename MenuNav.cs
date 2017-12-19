using UnityEngine.UI;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuNav : MonoBehaviour
{

    bool canMove = true;

    public int index = 0;

    public float sensitivity;

    RectTransform rect;

    bool mainMenu = true;
    bool options = false;
    bool selected = false;

    public GameObject master;
    public float speed;

    public Text periodsA;
    public Text timeA;

    public GameManager manager;

    int periods = 4;
    int periodMins = 2;
    int periodSecs = 30;

    float inputY;
    float inputX;

    string dispSecs;

    public GameObject selectObj;
    public GameObject BackObj;

    void Start()
    {
        rect = GetComponent<RectTransform>();
    }

    void Update()
    {

        if(selected == false)
        {
            selectObj.SetActive(true);
            BackObj.SetActive(false);
        }
        else
        {
            BackObj.SetActive(true);
            selectObj.SetActive(false);
        }
        inputX = Input.GetAxisRaw("XBox_player1");
        inputY = Input.GetAxisRaw("XBox_player1Y");

        if (!selected && inputY == 0)
        {
            sensitivity = 0.3f;
        }
        if (options && !selected && Input.GetButtonDown("Back"))
        {
            options = false;
            mainMenu = true;
            master.GetComponent<RectTransform>().localPosition = new Vector3(0, 0, 0);
        }
        if (selected && options && Input.GetButtonDown("Back"))
        {
            selected = false;
        }


        if (mainMenu || options)
        {
            if (inputX >= 1 && canMove)
            {
                //right
                canMove = false;
                StartCoroutine(Delay());

            }
            else if (inputX <= -1 && canMove)
            {
                //left
                canMove = false;
                StartCoroutine(Delay());
            }
            if (inputY >= 1 && canMove)
            {
                //down
                canMove = false;
                StartCoroutine(Delay());
                if (options && selected)
                {
                    StartCoroutine(Speed());
                    switch (index)
                    {
                        case 0:
                            if (periods >= 2)
                            {
                                periods--;
                                periodsA.text = periods.ToString();
                            }
                            break;
                        case 1:
                            if (periodMins > 0)
                            {
                                periodSecs--;
                                if (periodSecs <= 0)
                                {
                                    periodMins--;
                                    periodSecs = 59;
                                }
                                timeA.text = periodMins + ":" + DisplaySecondsProperly().ToString();
                            }
                            break;
                    }
                }
                else if (index <= 2)
                {
                    rect.localPosition -= new Vector3(0, 56, 0);
                    index++;
                }
            }
            else if (inputY <= -1 && canMove)
            {
                //up
                canMove = false;
                StartCoroutine(Delay());
                if (options && selected)
                {
                    StartCoroutine(Speed());
                    switch (index)
                    {
                        case 0:
                            if (periods <= 9)
                            {
                                periods++;
                                periodsA.text = periods.ToString();
                            }
                            break;
                        case 1:
                            if (periodMins <= 9)
                            {
                                periodSecs++;
                                if (periodSecs >= 59)
                                {
                                    periodMins++;
                                    periodSecs = 0;
                                }
                                timeA.text = periodMins + ":" + DisplaySecondsProperly().ToString();
                            }
                            break;
                    }
                }
                else if (index > 0)
                {
                    rect.localPosition += new Vector3(0, 56, 0);
                    index--;
                }
            }
            if (Input.GetButtonDown("Select") && mainMenu)
            {
                switch (index)
                {
                    case 0:
                        manager.periodSecs = periodSecs;
                        manager.periodMins = periodMins;
                        manager.periods = periods;
                        SceneManager.LoadScene(1);
                        break;
                    case 1:
                        mainMenu = false;
                        options = true;
                        master.GetComponent<RectTransform>().localPosition = new Vector3(-650, 0, 0);
                        break;
                    case 2:
                        SceneManager.LoadScene(4);
                        break;
                    case 3:
                        SceneManager.LoadScene(3);
                        break;
                }
            }
            else if (Input.GetButtonDown("Select") && options)
            {
                switch (index)
                {
                    case 0:
                        selected = true;
                        break;
                    case 1:
                        selected = true;
                        break;
                    case 2:
                        Application.Quit();
                        break;
                }
            }
        }
    }
    IEnumerator Delay()
    {
        yield return new WaitForSeconds(sensitivity);
        canMove = true;
    }

   
    string DisplaySecondsProperly()
    {
        if (periodSecs < 10)
        {
            return dispSecs = "0" + periodSecs.ToString();
        }
        else
        {
            return dispSecs = periodSecs.ToString();
        }
    }
    IEnumerator Speed()
    {
        yield return new WaitForSeconds(1);
        if(inputY != 0)
        {
            sensitivity = 0.1f;
        }
    }
}