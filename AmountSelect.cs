using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine;

public class AmountSelect : MonoBehaviour {

    private float inputY;
    private bool canMove = true;

    public float sensitivity = 0.3f;

    public int amount = 2;

    public Text amountText;
    public Text errText;

    bool err = false;

    public GameObject Master;

    void Start()
    {
        amountText.text = amount.ToString();
    }
    void Update()
    {
        inputY = Input.GetAxisRaw("XBox_player1Y");
        if (inputY >= 0.4 && canMove)
        {
            if (err)
            {
                err = false;
                errText.enabled = false;
            }
            //down
            canMove = false;
            StartCoroutine(Delay());
            if (amount >= 3)
            {
                amount = amount / 2;
                amountText.text = amount.ToString();
            }
        }
        if (inputY <= -0.4 && canMove)
        {
            if (err)
            {
                err = false;
                errText.enabled = false;
            }
            //up
            canMove = false;
            StartCoroutine(Delay());
            if (amount <= 5)
            {
                amount = amount * 2;
                amountText.text = amount.ToString();
            }
        }
        if (Input.GetButtonDown("Select"))
        {
            if(amount >= 3)
            {
                //continue
                Master.transform.localPosition -= new Vector3(1000, 0, 0);
                Master.GetComponent<TournamentController>().AddPlayers(amount);
            }
            else
            {
                errText.enabled = true;
                string players;
                if(amount == 1)
                {
                    players = " player";
                }
                else
                {
                    players = " players";
                }
                errText.text = "you need more than " + amount.ToString() + players + " to play";
                err = true;
            }           
        }
        if (Input.GetButtonDown("Back"))
        {
            SceneManager.LoadScene(0);
        }
    }
    IEnumerator Delay() {
        yield return new WaitForSeconds(sensitivity);
        canMove = true;
    }
}
