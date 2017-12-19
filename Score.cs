using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour {

    public GameObject collOne;
    public GameObject collTwo;
    public GameObject secondary;

    public SecondaryScoreCheck secCheck;

    public bool secondaryCheck;

    GameObject managerObj;
    public GameManager manager;

    public bool isLeft;

    int scorePOne;
    int scorePTwo;

    public Text pOneText;
    public Text pTwoText;

    public GameObject particle;

    void Start()
    {
        managerObj = GameObject.Find("GameManager");
        manager = managerObj.GetComponent<GameManager>();
        particle.SetActive(false);
    }

   void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.CompareTag("Ball"))
        {
            collOne.SetActive(true);
            collTwo.SetActive(true);
            secondary.GetComponent<BoxCollider2D>().isTrigger = true;
            secCheck.check = true;
            StartCoroutine(Wait());
            particle.SetActive(false);
        }
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(1);
        if (secondaryCheck)
        {
            if (isLeft)
            {
                manager.PTwoAddScore();
                scorePTwo++;
                pTwoText.text = scorePTwo.ToString();
                particle.SetActive(true);
            }
            else
            {
                manager.POneAddScore();
                scorePOne++;
                pOneText.text = scorePOne.ToString();
                particle.SetActive(true);
            }
        }
        collOne.SetActive(false);
        collTwo.SetActive(false);
        secCheck.check = false;
        secondaryCheck = false;
        secondary.GetComponent<BoxCollider2D>().isTrigger = false;
    }

}
