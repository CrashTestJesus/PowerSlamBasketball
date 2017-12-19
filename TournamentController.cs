using UnityEngine;

public class TournamentController : MonoBehaviour {
    public Player[] players;
    public Color[] col;

    public GameObject playerPanel;
    public GameObject Line;

    public Transform playersTransform;
    public Transform[] panelTransforms;
    public Transform matchGrid;

    public void AddPlayers(int p) {
        players = new Player[p];
        for (int i = 0; i < players.Length; i++)
        {
            players[i] = new Player(i, col[i]);
        }
        CreatePlayers();
    }
    public void CreatePlayers() {
        panelTransforms = new Transform[players.Length];
        for (int i = 0; i < players.Length; i++)
        {
            GameObject panel = (GameObject) Instantiate(playerPanel, transform.position, transform.rotation);
            panel.transform.SetParent(playersTransform);
            panelTransforms[i] = panel.transform;
            panel.GetComponent<AddPropertys>().playr = players[i];
        }
        //CreateTournamentGrid();
    }
    public void CreateTournamentGrid()
    {
        for (int i = 0; i < panelTransforms.Length; i++)
        {
            GameObject line = (GameObject)Instantiate(Line, panelTransforms[i].localPosition, Quaternion.identity);
            line.transform.SetParent(panelTransforms[i]);
            line.transform.localPosition = new Vector3(0, 100, 0);
        }
        //check if even
        if(players.Length%2 == 0)
        {
            for (int i = 0; i < panelTransforms.Length; i += 2)
            {
                GameObject line = (GameObject)Instantiate(Line, panelTransforms[i].localPosition, Quaternion.identity);
                line.transform.SetParent(panelTransforms[i]);
                line.transform.localScale = new Vector3(1, 2, 1);
                line.transform.rotation = Quaternion.Euler(0, 0, 90);
                line.transform.localPosition = new Vector3(100, 150, 0);
            }
        }
    }
}
