using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class VictoryScript : MonoBehaviour
{
    public string sceneToLoad;
    public GameObject victoryScreen;

    void Start()
    {
        victoryScreen.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        victoryScreen.SetActive(true);
    }

    public void LoadScene()
    {
        SceneManager.LoadScene(sceneToLoad);
    }
}
