using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float m_enemyHp = 5.0f;
    [SerializeField] private float m_enemyMoveSpeed = 1;
    [SerializeField] private float m_Damage;
    [SerializeField] private enemypatten m_nowMoving = enemypatten.right;
    Vector3 position = new Vector3(1, 0, 0);

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
        if (m_nowMoving == enemypatten.right)
        { 
            position = new Vector3(1, 0, 0);
        }
        else if (m_nowMoving == enemypatten.left)
        {
            position =  new Vector3(-1, 0, 0);
        }
        else if (m_nowMoving == enemypatten.down)
        {
            position =  new Vector3(0, -1, 0);
        }
        else if (m_nowMoving == enemypatten.up)
        {
            position =  new Vector3(0, 1, 0);
        }

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Attack")
        {
            Attack m_Attack = collision.transform.GetComponent<Attack>();
            m_enemyHp -= m_Attack.CheckDamage();
            setalpha(0.5f);
            hit = true;
        }

        if (collision.gameObject.tag == "Ground" || collision.gameObject.tag == "Rock")
        {
            movepatten();
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

    // Update is called once per frame
    void Update()
    {
        checktimer();
        checkHp();
        moveing();
    }

    private void checkHp()
    {
        if (m_enemyHp <= 0)
        {
            int irand = Random.Range(0,0);
            if (irand == 0)
            {
                Instantiate(m_objBoom, transform.position, Quaternion.identity,ItemManager.Instance.m_itemCreat);
            }
            Destroy(gameObject);
        }
    }

    private void movepatten()
    {
        Vector3 scale = new Vector3(1, 1, 1);
        switch (m_nowMoving)
        {
            case enemypatten.right:
                position.x = 0;
                position.y = -1;
                m_nowMoving = enemypatten.down;
                break;
            case enemypatten.down:
                position.x = -1;
                position.y = 0;
                m_nowMoving = enemypatten.left;
                scale.x = -1;
                transform.localScale = scale;
                break;
            case enemypatten.left:
                position.x = 0;
                position.y = 1;
                m_nowMoving = enemypatten.up;
                break;
            case enemypatten.up:
                position.x = 1;
                position.y = 0;
                m_nowMoving = enemypatten.right;
                scale.x = 1;
                transform.localScale = scale;
                break;
        }
    }

    private void moveing()
    {
        transform.position += position * Time.deltaTime * m_enemyMoveSpeed;
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
