using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerSelector : MonoBehaviour
{
    public bool player2Active;

    void Awake()
    {
        GameObject[] objs = GameObject.FindGameObjectsWithTag("PlayerSelector");

        if (objs.Length > 1)
        {
            Destroy(this.gameObject);
        }

        DontDestroyOnLoad(this.gameObject);
    }

    public void OnePlayer()
    {
        player2Active = false;
        Time.timeScale = 1.0f;
        SceneManager.LoadScene(1);
    }

    public void TwoPlayers()
    {
        player2Active = true;
        Time.timeScale = 1.0f;
        SceneManager.LoadScene(1);
    }
}
