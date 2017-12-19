using UnityEngine.UI;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public int scorePOne;
    public int scorePTwo;

    public int periods;
    public int periodMins;
    public int periodSecs;

    private static GameManager instance = null;

    public static GameManager Instance
    {
        get
        {
            return instance;
        }
    }

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
        }

        instance = this;
        DontDestroyOnLoad(this.gameObject);
    }


public void POneAddScore()
    {
        scorePOne++;
    }
    public void PTwoAddScore()
    {
        scorePTwo++;
    }
}
