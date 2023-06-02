using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButtonController : MonoBehaviour {

	void startGame()
	{
        SceneManager.LoadScene(1);
    }
    private void OnApplicationQuit()
    {
        Application.Quit();
        Debug.Log("exit");
    }		


}
