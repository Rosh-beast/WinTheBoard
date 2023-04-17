using UnityEngine;
using UnityEngine.UI;

public class GameControl : MonoBehaviour {

    private static GameObject whoWinsTextShadow, player1MoveText, player2MoveText;
    private static GameObject player1, player2;
    public static int diceSideThrown = 0;
    public static int player1StartWaypoint = 0;
    public static int player2StartWaypoint = 0;
    public static bool gameOver = false;
    public Image Highlight1;
    public Image Highlight2;
    void Start () {

        whoWinsTextShadow = GameObject.Find("WhoWinsText");
        player1MoveText = GameObject.Find("Player1MoveText");
        player2MoveText = GameObject.Find("Player2MoveText");

        player1 = GameObject.Find("Player1");
        player2 = GameObject.Find("Player2");

        player1.GetComponent<FollowThePath>().shouldMove = false;
        player2.GetComponent<FollowThePath>().shouldMove = false;

        whoWinsTextShadow.gameObject.SetActive(false);
    }
    void Update()
    {
        if (player1.GetComponent<FollowThePath>().waypointIndex > 
            player1StartWaypoint + diceSideThrown)
        {
            player1.GetComponent<FollowThePath>().shouldMove = false;
            Highlight2.gameObject.SetActive(true);
            Highlight1.gameObject.SetActive(false);
            player1StartWaypoint = player1.GetComponent<FollowThePath>().waypointIndex - 1;
        }
        if (player2.GetComponent<FollowThePath>().waypointIndex >
            player2StartWaypoint + diceSideThrown)
        {
            player2.GetComponent<FollowThePath>().shouldMove = false;
            Highlight1.gameObject.SetActive(true);
            Highlight2.gameObject.SetActive(false);
            player2StartWaypoint = player2.GetComponent<FollowThePath>().waypointIndex - 1;
        }
        if (player1.GetComponent<FollowThePath>().waypointIndex == 
            player1.GetComponent<FollowThePath>().waypoints.Length)
        {
            whoWinsTextShadow.gameObject.SetActive(true);
            whoWinsTextShadow.GetComponent<Text>().text = "Glupy Wins";
            gameOver = true;
        }
        if (player2.GetComponent<FollowThePath>().waypointIndex ==
            player2.GetComponent<FollowThePath>().waypoints.Length)
        {
            whoWinsTextShadow.gameObject.SetActive(true);
            Highlight1.gameObject.SetActive(false);
            Highlight2.gameObject.SetActive(false);
            whoWinsTextShadow.GetComponent<Text>().text = "Doppy Wins";
            gameOver = true;
        }
    }

    public static void MovePlayer(int playerToMove)
    {
        switch (playerToMove) { 
            case 1:
                player1.GetComponent<FollowThePath>().shouldMove = true;
                break;

            case 2:
                player2.GetComponent<FollowThePath>().shouldMove = true;
                break;
        }
    }
}
