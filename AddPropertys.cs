using UnityEngine.UI;
using UnityEngine;

public class AddPropertys : MonoBehaviour {

    public Player playr;

    public Text playerName;
    public Text wins;
    public Text loses;


    void Start() {
        playerName.text = playr.name;
        playerName.color = playr.color;
        wins.text = "Wins: " + playr.wins.ToString();
        loses.text = "Loses: " + playr.loses.ToString();
    }
}
