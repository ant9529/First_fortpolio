using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TilemapManager : MonoBehaviour
{

    private float m_activeTime = 3;
    private float m_activeTimer = 0;
    [SerializeField] private float m_activeControlTime = 3;
    private bool m_acton = true;

    GameObject spike;

    // Start is called before the first frame update
    void Start()
    {
        if (transform.GetChild(2) == null)
        {
            return;
        }
        else
        {
            spike = transform.GetChild(2).gameObject;
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        controllactive();
    }

    private void controllactive()
    {
        m_activeTimer += Time.deltaTime * m_activeControlTime;

        if (spike == null)
        {
            return;
        }
        else if (m_activeTimer >= m_activeTime && m_acton == true)
        {
            m_activeTimer = 0;
            spike.SetActive(false);
            m_acton = false;
        }
        else if (m_activeTimer >= m_activeTime && m_acton == false)
        {
            m_activeTimer = 0;
            spike.SetActive(true);
            m_acton = true;
        }
    }
}
