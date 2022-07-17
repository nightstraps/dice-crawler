using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class sceneLoader : MonoBehaviour
{
    public void LoadNextScene()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        if(currentSceneIndex == 0)
        {
            Destroy(GameObject.Find("player"));
        }
        SceneManager.LoadScene(currentSceneIndex += 1);
    
    }
    public void LoadMenuScene()
    {
        SceneManager.LoadScene(0);
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
