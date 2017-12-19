using System.Collections;
using UnityEngine;

public class SecondaryScoreCheck : MonoBehaviour {

    public Score scoreScript;

    public bool check = false;

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.CompareTag("Ball") && check)
        {
            scoreScript.secondaryCheck = true;
        }
    }
}
