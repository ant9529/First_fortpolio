using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float m_enemyHp = 5.0f;
    [SerializeField] private float m_enemyMoveSpeed = 1;
    [SerializeField] private float m_Damage;

    [SerializeField] private GameObject m_objBoom;

    private bool hit = false;

    private SpriteRenderer m_spr;
    private float m_clockingtime = 3;
    private float m_clockingtimer = 0;
    float m_clocking = 25;

    // Start is called before the first frame update
    void Start()
    {
        m_spr = GetComponent<SpriteRenderer>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Coin")
        {
            Attack m_Attack = collision.transform.GetComponent<Attack>();
            m_enemyHp -= m_Attack.CheckDamage();
            setalpha(0.5f);
            hit = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Boom")
        {
            m_enemyHp -= 1;
            setalpha(0.5f);
            hit = true;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground" || collision.gameObject.tag == "Rock")
        {
            transform.Rotate(0, 0, -90);
        }
    }

    // Update is called once per frame
    void Update()
    {
        checktimer();
        checkHp();
        movepatten();
    }

    private void checkHp()
    {
        if (m_enemyHp <= 0)
        {
            int irand = Random.Range(0,5);
            if (irand == 0)
            {
                Instantiate(m_objBoom, transform.position, Quaternion.identity);
            }
            Destroy(gameObject);
        }
    }

    private void movepatten()
    {
        transform.position += transform.right * Time.deltaTime * m_enemyMoveSpeed;
    }
    private void setalpha(float _alpha)
    {
        Color color = m_spr.color;
        color.a = _alpha;
        m_spr.color = color;
    }

    private void checktimer()
    {
        if (hit == false)
        {
            m_clockingtimer = 0;
            return;
        }
        else if(hit == true)
        {
            m_clockingtimer += Time.deltaTime * m_clocking;
            if (m_clockingtimer >= m_clockingtime)
            {
                setalpha(1.0f);
                hit = false;
            }
        }
    }
}
