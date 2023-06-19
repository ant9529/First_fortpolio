using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoadManager : MonoBehaviour
{
    public static SceneLoadManager Instance;
    public bool m_inPotal;

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
        loadScene();
    }

    private void loadScene()
    {
        if (m_inPotal && Input.GetKeyDown(KeyCode.Space))
        {
            m_inPotal = false;
            SceneManager.LoadSceneAsync(CheckScene());
        }
    }

    public int CheckScene()
    {
        int sceneNumber = SceneManager.GetActiveScene().buildIndex;
        return sceneNumber+1;
    }

}
