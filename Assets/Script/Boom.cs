using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boom : MonoBehaviour
{
    [SerializeField] private GameObject explosion;

    private float m_boomtime = 3;
    private float m_boomtimer = 0;
    private float m_boomsec = 5;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        boomtimer();
    }

    private void boomtimer()
    {
        m_boomtimer += Time.deltaTime * m_boomsec;
        if (m_boomtimer >= m_boomtime)
        {
            Destroy(gameObject);
            Instantiate(explosion, transform.position,Quaternion.identity);
        }
    }


}
