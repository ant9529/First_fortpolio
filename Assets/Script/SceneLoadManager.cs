using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoadManager : MonoBehaviour
{
    public SceneLoadManager Instance;

    public enum eSceneTag
    { 
        StartStage,
        MainStage,
    }

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
        
    }

    public void LoadScene(eSceneTag _value)
    {
        SceneManager.LoadSceneAsync((int)_value);
    }
}
