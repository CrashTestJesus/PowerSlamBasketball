using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class WinLoseController : MonoBehaviour {

    GameObject managerObj;
    public GameManager manager;

    public GameObject draw;
    public GameObject winner;
    public GameObject winlose;

    public GameObject winnerSpriteObj;
    public GameObject loserSpriteObj;

    public GameObject winnerArmsLObj;
    public GameObject winnerArmsRObj;
    public GameObject loserArmslObj;
    public GameObject loserArmsRObj;

    public Sprite pOneSprite;
    public Sprite pTwoSprite;

    public Sprite pOneArms;
    public Sprite pTwoArms;

    int scoreP1;
    int scoreP2;

    bool canSkip;

    void Start()
    {
        
        managerObj = GameObject.Find("GameManager");
        manager = managerObj.GetComponent<GameManager>();

        scoreP1 = manager.scorePOne;
        scoreP2 = manager.scorePTwo;

        WinLoseDraw();

        StartCoroutine(skip());
    }

    void WinLoseDraw()
    {
        if (scoreP1 == scoreP2)
        {
            //draw
            draw.SetActive(true);
            winlose.SetActive(false);
            
        }
        else if (scoreP1 > scoreP2)
        {
            //p1 wins
            winner.SetActive(true);
            winnerSpriteObj.GetComponent<SpriteRenderer>().sprite = pOneSprite;
            winnerArmsLObj.GetComponent<SpriteRenderer>().sprite = pOneArms;
            winnerArmsRObj.GetComponent<SpriteRenderer>().sprite = pOneArms;
            loserSpriteObj.GetComponent<SpriteRenderer>().sprite = pTwoSprite;
            loserArmslObj.GetComponent<SpriteRenderer>().sprite = pTwoArms;
            loserArmsRObj.GetComponent<SpriteRenderer>().sprite = pTwoArms;
        }
        else
        {
            //p2 wins
            winner.SetActive(true);
            winnerSpriteObj.GetComponent<SpriteRenderer>().sprite = pTwoSprite;
            winnerArmsLObj.GetComponent<SpriteRenderer>().sprite = pTwoArms;
            winnerArmsRObj.GetComponent<SpriteRenderer>().sprite = pTwoArms;
            loserArmslObj.GetComponent<SpriteRenderer>().sprite = pOneArms;
            loserArmsRObj.GetComponent<SpriteRenderer>().sprite = pOneArms;
            loserSpriteObj.GetComponent<SpriteRenderer>().sprite = pOneSprite;
        }
    }
    void Update()
    {
        if (Input.GetButtonDown("Select") && canSkip)
        {
            SceneManager.LoadScene(0);
        }
    }
    IEnumerator skip()
    {
        yield return new WaitForSeconds(5);
        canSkip = true;
    }
    
}
