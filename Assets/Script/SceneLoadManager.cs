using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoadManager : MonoBehaviour
{
    public static SceneLoadManager Instance;
    public bool m_inpotal = false;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(this);
        }
    }
    void Start()
    {
        DontDestroyOnLoad(this);
    }

    // Update is called once per frame
    void Update()
    {
        InputChangeScene();
    }

    private void InputChangeScene()
    {
        if (m_inpotal == true && Input.GetKeyDown(KeyCode.Space))
        {
            LoadScene();
        }
    }
    public void LoadScene()
    {
        m_inpotal = false;
        SceneManager.LoadSceneAsync(checkScene());
    }

    private int checkScene()
    {
        int sceneNumber = SceneManager.GetActiveScene().buildIndex;
        return sceneNumber+1;
    }

   

}
