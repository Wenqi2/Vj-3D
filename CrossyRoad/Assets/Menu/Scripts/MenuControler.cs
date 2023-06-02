using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuControler : MonoBehaviour
{
    public void startGame()
    {
        SceneManager.LoadScene("GameScene");
    }
    public void OnApplicationQuit()
    {
        Application.Quit();
        Debug.Log("exit");
    }
}
