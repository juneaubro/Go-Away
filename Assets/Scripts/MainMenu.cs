using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayBlocks()
    {
        SceneManager.LoadScene("BlockApples");
    }

    public void PlayReaction()
    {
        SceneManager.LoadScene("ReactionTime");
    }

    public void QuitGame()
    {
        Debug.Log("Quit.");
        Application.Quit();
    }
}
