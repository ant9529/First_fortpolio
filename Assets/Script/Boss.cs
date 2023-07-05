using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    [SerializeField] private GameObject m_objBullet;
    [SerializeField] private Transform m_bulletPos;
    [SerializeField] private Transform m_bulletPatents;

    [SerializeField] private Transform m_trsRightUp;
    [SerializeField] private Transform m_trsRightDown;
    [SerializeField] private Transform m_trsLeftUp;
    [SerializeField] private Transform m_trsLeftDown;
    private SpriteRenderer m_spr;


    Vector3 pos = new Vector3(0, 0, 0);
    private int m_nowPatten = 1;
    private int m_angle = 0;
    private float m_bulletTimer = 0;
    private float m_bulletTime = 3;
    private bool m_bGetDamage = false;
    private float m_invicibilityTime = 3;
    private float m_invicibilityTimer = 0;

    private int m_hp = 20;
    private float m_bossMoveSpeed = 5;




    
    // Start is called before the first frame update
    void Start()
    {
        m_spr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        bossPatten();
        invicibillity();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Attack")
        {
            Attack scAttack = collision.transform.GetComponent<Attack>();
            m_hp -= (int)scAttack.CheckDamage();
            setalpha(0.2f);
            m_bGetDamage = true;
            checkHp();
        }
    }

    private void checkHp()
    {
        if (m_hp <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void bossPatten()
    {
        m_bulletTimer += Time.deltaTime * 50;
        switch (m_nowPatten)
        {
            case 1:
                pos.x = 1;
                pos.y = 0;

                if (transform.position.x >= m_trsRightUp.position.x && m_bulletTimer >= m_bulletTime)
                {
                    m_bulletTimer = 0;
                    m_angle += 20;
                    transform.rotation = Quaternion.Euler(0, 0, m_angle);
                    Instantiate(m_objBullet, m_bulletPos.position, Quaternion.Euler(0, 0, m_angle+180), m_bulletPatents);
                }
                else if(transform.position.x < m_trsRightUp.position.x)
                {
                    transform.position += pos * Time.deltaTime * m_bossMoveSpeed;
                }
                else if (m_angle >= 360)
                {
                    m_bulletTimer = 0;
                    m_angle = 0;
                    m_nowPatten = 2;
                }
                
                break;

            case 2:
                pos.x = 0;
                pos.y = -1;

                if (transform.position.y <= m_trsRightDown.position.y && m_bulletTimer >= m_bulletTime)
                {
                    m_bulletTimer = 0;
                    m_angle += 20;
                    transform.rotation = Quaternion.Euler(0, 0, m_angle);
                    Instantiate(m_objBullet, m_bulletPos.position, Quaternion.Euler(0, 0, m_angle+180), m_bulletPatents);
                }
                else if (transform.position.y > m_trsRightDown.position.y)
                {
                    transform.position += pos * Time.deltaTime * m_bossMoveSpeed;
                }
                else if (m_angle >= 360)
                {
                    m_bulletTimer = 0;
                    m_angle = 0;
                    m_nowPatten = 3;
                }
                break;

            case 3:
                pos.x = -1;
                pos.y = 0;

                if (transform.position.x <= m_trsLeftDown.position.x && m_bulletTimer >= m_bulletTime)
                {
                    m_bulletTimer = 0;
                    m_angle += 20;
                    transform.rotation = Quaternion.Euler(0, 0, m_angle);
                    Instantiate(m_objBullet, m_bulletPos.position, Quaternion.Euler(0, 0, m_angle+180), m_bulletPatents);
                }
                else if (transform.position.x > m_trsLeftDown.position.x)
                {
                    transform.position += pos * Time.deltaTime * m_bossMoveSpeed;
                }
                else if (m_angle >= 360)
                {
                    m_bulletTimer = 0;
                       m_angle = 0;
                    m_nowPatten = 4;
                }
                break;

            case 4:
                pos.x = 0;
                pos.y = 1;

                if (transform.position.y >= m_trsLeftUp.position.y && m_bulletTimer >= m_bulletTime)
                {
                    m_bulletTimer = 0;
                    m_angle += 20;
                    transform.rotation = Quaternion.Euler(0, 0, m_angle);
                    Instantiate(m_objBullet, m_bulletPos.position, Quaternion.Euler(0, 0, m_angle+180), m_bulletPatents);
                }
                else if (transform.position.y < m_trsLeftUp.position.y)
                {
                    transform.position += pos * Time.deltaTime * m_bossMoveSpeed;
                }
                else if (m_angle >= 360)
                {
                    m_bulletTimer = 0;
                    m_angle = 0;
                    m_nowPatten = 1;
                }
                break;

        }

    }
    private void setalpha(float _alpha)
    {
        Color color = m_spr.color;
        color.a = _alpha;
        m_spr.color = color;
    }

    private void invicibillity()
    {
        if (m_bGetDamage == false)
        {
            return;
        }
        if (m_bGetDamage == true)
        {
            m_invicibilityTimer += Time.deltaTime * 30;
            if (m_invicibilityTimer >= m_invicibilityTime)
            {
                m_invicibilityTimer = 0;
                m_bGetDamage = false;
                setalpha(1.0f);
            }
        }
    }
}
