using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public bool reset = false;

    public GameObject GameOverUI;

    // Update is called once per frame

    public void resetGame()
    {
        reset = true;
        GameOverUI.SetActive(false);
        Time.timeScale = 1f;
    }
        public void loadMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Menu");
    }
}
