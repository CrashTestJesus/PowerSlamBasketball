using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TimeScript : MonoBehaviour {

    public int minutes;
    public float seconds;
    int secondsLeft;
    int period = 0;
    int periodsAmount;

    public float speed;

    string dispMin;
    string dispSec;

    Text text;

    public bool pause;

    public Text periodText;

    public PlayerActions actionScriptLeft;
    public PlayerActions actionScriptRight;
    public PlayerMovement movementScript;
    public PlayerActions actionScriptLeftTwo;
    public PlayerActions actionScriptRightTwo;
    public PlayerMovement movementScriptTwo;
    public PlayerGraphicsController graphicsController;

    GameObject managerObj;
    public GameManager manager;

	void Start () {
        text = GetComponent<Text>();
        managerObj = GameObject.Find("GameManager");
        manager = managerObj.GetComponent<GameManager>();
        seconds = manager.periodSecs;
        minutes = manager.periodMins;
        periodsAmount = manager.periods;
	}
	
	void Update () {
            if (!pause)
            {
                if (seconds <= 0)
                {
                    seconds = 59;
                    minutes--;
                }
                if (minutes < 0)
                {
                    Pause();
                }
                else
                {
                    seconds -= Time.deltaTime * speed;
                    secondsLeft = (int)seconds;
                    text.text = DisplayMinutesProperly() + ":" + DisplaySecondsProperly();
                }
            }
            if (pause)
            {
                NextPeriod();
            }
        }
	

    string DisplayMinutesProperly()
    {
        if(minutes < 10)
        {
            return dispMin = "0" + minutes.ToString();
        }
        else
        {
           return dispMin = minutes.ToString();
        }
    }
    string DisplaySecondsProperly()
    {
        if(seconds < 10)
        {
            return dispSec = "0" + secondsLeft.ToString();
        }
        else
        {
            return dispSec = secondsLeft.ToString();
        }
    }
    public void Pause()
    {
        period++;
        if (period == periodsAmount)
        {
            SceneManager.LoadScene(2);
        }
        else
        {
            pause = true;
            speed = 0;
            periodText.text = "period: " + (period + 1).ToString();
            actionScriptLeft.pause = true;
            actionScriptLeftTwo.pause = true;
            actionScriptRight.pause = true;
            actionScriptLeftTwo.pause = true;
            movementScript.pause = true;
            movementScriptTwo.pause = true;
            graphicsController.pause = true;
        }
    }
    public void NextPeriod()
    {
        
        if (Input.GetButtonDown("Reset"))
        {
            pause = false;
            speed = 1;
            minutes = manager.periodMins;
            seconds = manager.periodSecs;
            actionScriptLeft.pause = false;
            actionScriptLeftTwo.pause = false;
            actionScriptRight.pause = false;
            actionScriptRightTwo.pause = false;
            movementScript.pause = false;
            movementScriptTwo.pause = false;
            graphicsController.pause = false;
        }     
    }
}
