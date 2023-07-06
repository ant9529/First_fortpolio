using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Button : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void MainScene()
    {
        SceneManager.LoadSceneAsync(2);
    }

    public void RetryScene()
    {
        SceneManager.LoadSceneAsync(0);
    }

    public void GameStart()
    {
        SceneManager.LoadSceneAsync(0);
    }

    public void GameQuit()
    {

#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}
