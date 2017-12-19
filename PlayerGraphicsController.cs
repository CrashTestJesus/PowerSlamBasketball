
using UnityEngine;

public class PlayerGraphicsController : MonoBehaviour {
    [Header("renderers")]
    public SpriteRenderer shoeOne;
    public SpriteRenderer shoeTwo;
    public SpriteRenderer face;
    [Header("animators")]
    public Animator feet;
    [Header("variables")]
    public bool pause;
    public bool Xbox;
    public bool isPTwo;

    void Update()
    {
        if (!pause)
        {
            float direction = 0;
            if (!isPTwo)
            {
                if (!Xbox)
                {
                    direction = Input.GetAxisRaw("Horizontal");
                }
                else
                {
                    direction = Input.GetAxisRaw("XBox_player1");
                }
            }
            else
            {
                if (!Xbox)
                {
                    direction = Input.GetAxisRaw("HorizontalP2");
                }
                else
                {
                    direction = Input.GetAxisRaw("XBox_player2");
                }
            }
            if (direction > 0)
            {
                TurnRight();
                feet.SetBool("isWalking", true);
            }
            else if (direction < 0)
            {
                TurnLeft();
                feet.SetBool("isWalking", true);
            }
            else
            {
                feet.SetBool("isWalking", false);
            }
            }
        }

    void TurnLeft()
    {
        shoeOne.flipX = true;
        shoeTwo.flipX = true;
        face.flipX = true;
    }
    void TurnRight()
    {
        shoeOne.flipX = false;
        shoeTwo.flipX = false;
        face.flipX = false;
    }

}

