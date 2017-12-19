using UnityEngine;
using System.Collections;

public class PlayerActions : MonoBehaviour {
    [Header("Inputs")]
    public GameObject parent;
    public GameObject ball;
    public GameObject otherHand;
    
    public Transform ballPos;

    public Animator swingAnim;

    public PlayerActions otherScript;

    Rigidbody2D ballRig;
    [Header("Variables")]
    public int forceForward;
    public int forceUpward;

    public bool isPTwo;
    public bool leftArm;

    bool isLeft = true;
    bool shoot = false;
    bool isHolding;
    bool isHoldingHand;

    public bool hitting;

    public string otherPlayerTag;

    public bool pause;

    public Transform ballSpawnPos;

    void Start()
    {
        ballRig = ball.GetComponent<Rigidbody2D>();
    }
    void OnTriggerStay2D(Collider2D coll)
    {
        if (!pause)
        {
            if (coll.gameObject.CompareTag(otherPlayerTag))
            {
                if (hitting)
                {
                    PlayerActions playerActionsOne = coll.gameObject.transform.parent.transform.GetChild(1).GetComponent<PlayerActions>();
                    PlayerActions playerActionsTwo = coll.gameObject.transform.parent.transform.GetChild(2).GetComponent<PlayerActions>();

                    if (playerActionsOne.isHolding || playerActionsTwo.isHolding)
                    {
                        playerActionsOne.Drop();
                        playerActionsTwo.Drop();
                    }
                }
            }
        }
     }
    void OnTriggerEnter2D(Collider2D coll)
    {
        if (!pause)
        {
            if (coll.gameObject.CompareTag("Ball"))
            {
                if (!isHolding && !hitting)
                {
                    parent.transform.rotation = Quaternion.identity;
                    ball.GetComponent<CircleCollider2D>().enabled = false;
                    if (leftArm)
                    {
                        swingAnim.SetBool("leftUp", true);
                    }
                    else
                    {
                        swingAnim.SetBool("rightUp", true); ;
                    }
                    isHolding = true;
                    otherScript.isHolding = true;
                    isHoldingHand = true;
                }
            }
        }
    }

    void Update()
    {
        if (!pause)
        {
            if(ballRig.isKinematic == true)
            {
                ballRig.isKinematic = false;
                ballRig.gravityScale = 1;
            }
            if (isPTwo)
            {
                float direction = Input.GetAxisRaw("XBox_player2");
                if (direction > 0)
                {
                    isLeft = false;
                }
                else if (direction < 0)
                {
                    isLeft = true;
                }
                if (Input.GetButtonDown("HitP2") && isLeft && !isHolding)
                {
                    HitLeft();
                }
                if (Input.GetButtonDown("HitP2") && !isLeft && !isHolding)
                {
                    HitRight();
                }
                if (isHoldingHand)
                {
                    ball.transform.position = ballPos.position;
                }
                if (Input.GetButtonDown("ThrowBallP2") && isHoldingHand)
                {
                    ThrowBall();

                }
            }
            else
            {
                float direction = Input.GetAxisRaw("XBox_player1");
                if (direction > 0)
                {
                    isLeft = false;
                }
                else if (direction < 0)
                {
                    isLeft = true;
                }
                if (Input.GetButtonDown("Hit") && isLeft && !isHolding)
                {
                    HitLeft();
                }
                if (Input.GetButtonDown("Hit") && !isLeft && !isHolding)
                {
                    HitRight();
                }
                if (isHoldingHand)
                {
                    ball.transform.position = ballPos.position;
                }
                if (Input.GetButtonDown("ThrowBall") && isHoldingHand)
                {
                    ThrowBall();

                }
            }
        }
        else
        {
            ballRig.velocity = new Vector2(0, 0);
            isHolding = false;
            isHoldingHand = false;
            ball.transform.position = ballSpawnPos.position;
            ballRig.isKinematic = true;
            ballRig.gravityScale = 0;
            StartCoroutine(SetBoolFalse());
            ball.GetComponent<CircleCollider2D>().enabled = true;
        }
    }
    void FixedUpdate()
    {
        if (shoot)
        {
            ballRig.velocity = new Vector2(0, 0);
            if (isLeft)
            {
                ballRig.velocity += new Vector2(-forceForward, forceUpward) * Time.deltaTime;
            }
            else
            {
                ballRig.velocity += new Vector2(forceForward, forceUpward) * Time.deltaTime;
            }
            shoot = false;
        }
    }
    public void Drop()
    {
        GetComponent<BoxCollider2D>().enabled = false;
        ball.transform.parent = null;
        isHolding = false;
        isHoldingHand = false;
        otherScript.isHolding = false;
        parent.transform.rotation = Quaternion.identity;
        otherHand.GetComponent<BoxCollider2D>().enabled = false;
        ball.GetComponent<CircleCollider2D>().enabled = true;
        ballRig.velocity = Vector3.zero;
        ballRig.velocity += new Vector2(Random.Range(-300,300), Random.Range(200, 500)) * Time.deltaTime;
        StartCoroutine(BoxReset());
        StartCoroutine(SetBoolFalse());
       
    }
 void ThrowBall()
    {
        shoot = true;
        GetComponent<BoxCollider2D>().enabled = false;
        ball.transform.parent = null;
        isHolding = false;
        isHoldingHand = false;
        otherScript.isHolding = false;
        parent.transform.rotation = Quaternion.identity;
        otherHand.GetComponent<BoxCollider2D>().enabled = false;
        ball.GetComponent<CircleCollider2D>().enabled = true;
        StartCoroutine(BoxReset());
        StartCoroutine(SetBoolFalse());
        return;
    }
 IEnumerator BoxReset()
    {
        yield return new WaitForSeconds(0.5f);
        GetComponent<BoxCollider2D>().enabled = true;
        otherHand.GetComponent<BoxCollider2D>().enabled = true;
    }

    void HitLeft()
    {
        swingAnim.SetBool("swingLeft", true);
        StartCoroutine(SetBoolFalse());
        hitting = true;
        StartCoroutine(hitfalse());
    }
    void HitRight()
    {
        swingAnim.SetBool("swingRight", true);
        StartCoroutine(SetBoolFalse());
        hitting = true;
        StartCoroutine(hitfalse());
    }

    IEnumerator SetBoolFalse()
    {
        yield return new WaitForEndOfFrame();
        swingAnim.SetBool("swingRight", false);
        swingAnim.SetBool("swingLeft", false);
        swingAnim.SetBool("leftUp", false);
        swingAnim.SetBool("rightUp", false);
    }
    IEnumerator hitfalse()
    {
        yield return new WaitForSeconds(0.3f);
        hitting = false;
    }
}
