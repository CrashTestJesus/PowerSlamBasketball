using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RollCredits : MonoBehaviour {

    RectTransform trans;

    public float speed;

    public GameObject text;

    void Start()
    {
        trans = GetComponent<RectTransform>();
    }
    void Update()
    {
        trans.localPosition += Vector3.up * speed * Time.deltaTime;
        if(trans.localPosition.y > 600)
        {
            speed = 0;
            StartCoroutine(Delay());
        }
        if (Input.GetButtonDown("Back"))
        {
            SceneManager.LoadScene(0);
        }
        if (Input.GetButtonDown("Select"))
        {
            speed *= 3;
        }
        if (Input.GetButtonUp("Select"))
        {
            speed /= 3;
        }
    }
    IEnumerator Delay()
    {
        yield return new WaitForSeconds(10);
        text.SetActive(true);
    }
}
