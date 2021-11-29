using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class Utilities
{
    public static int playerDeaths = 0;
    
    //Updates the number of death so far
    public static string UpdateDeathCount(ref int countReference)
    {
        countReference += 1;
        return "Next time you'll be at number " + countReference;
    }
    //Show player deaths and loads base game scene
    public static void RestartLevel()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1.0f;
        Debug.Log("Player deaths: " + playerDeaths);
        string message = UpdateDeathCount(ref playerDeaths);
        Debug.Log("Player deaths: " + playerDeaths);

    }
    //restarts scene by index
    public static bool RestartLevel(int sceneIndex)
        {
            SceneManager.LoadScene(sceneIndex);
            Time.timeScale = 1.0f;
        return true;
        }
}
