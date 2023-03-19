using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Scoreboard : MonoBehaviour
{
    [SerializeField] TMP_Text leftScoreboard;
    [SerializeField] TMP_Text rightScoreboard;

    [SerializeField] Canvas endscreen;
    [SerializeField] TMP_Text endscreenText;

    int player1Score = 0;
    int player2Score = 0;

    public void GiveScore(string col)
    {
        if (col == "Left_Goal")
        {
            player2Score++;
            leftScoreboard.text = player2Score.ToString();
        }

        if (col == "Right_Goal")
        {
            player1Score++;
            rightScoreboard.text = player1Score.ToString();
        }

    }

    private void Update()
    {
        if(player1Score == 11)
        {
            Time.timeScale = 0;
            endscreen.enabled = true;
            endscreenText.text = "Player 1 is the winner!";
        }

        if(player2Score == 11)
        {
            Time.timeScale = 0;
            endscreen.enabled = true;
            endscreenText.text = "Player 2 is the winner!";
        }
    }
}
