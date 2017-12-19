using UnityEngine.UI;
using UnityEngine;

public class Transparent : MonoBehaviour {

    public Color transCol;
    public Color col;
    public Text[] text;
    public Image img;

	
 void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.CompareTag("Ball"))
        {
            img.color = transCol;
            for (int i = 0; i < text.Length; i++)
            {
                text[i].color = transCol;
            }
        }
    }
 void OnTriggerExit2D(Collider2D coll)
    {
        if (coll.gameObject.CompareTag("Ball"))
        {
            img.color = col;
            for (int i = 0; i < text.Length; i++)
            {
                text[i].color = col;
            }
        }
    }
}
