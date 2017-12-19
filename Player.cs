public class Player {

    public UnityEngine.Color color;
    public int playerIndex;
    public string name;
    public  int wins;
    public int loses;

    public Player(int i, UnityEngine.Color c) {
        playerIndex = i;
        name = "Player " + (playerIndex + 1).ToString();
        wins = 0;
        loses = 0;
        color = c;
    }
}
