using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Rewired;

public class MenuScript : MonoBehaviour
{
    public string gameSceneName;

    public GameObject howToPlayPanel;

    private Player player1;
    private Player player2;

    public void Awake()
    {
        player1 = ReInput.players.GetPlayer(0);
        player2 = ReInput.players.GetPlayer(1);
        howToPlayPanel.SetActive(false);

        Cursor.visible = false;
    }

    private void Update()
    {
        if (player1.GetButtonDown("Back") || player2.GetButtonDown("Back"))
        {
            howToPlayPanel.SetActive(false);
        }
    }
    public void Play()
    {
        SceneManager.LoadScene(gameSceneName);
    }

    public void Quit()
    {
        Application.Quit();
    }


}
