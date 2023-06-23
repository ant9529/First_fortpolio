using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    private float m_moveSpeed;
    private float m_damage;
    private bool enemyAttack = false;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        move();
        //overScreen();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            Destroy(gameObject);
        }
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

    private void move()
    {
        transform.position += transform.up * Time.deltaTime * m_moveSpeed;
    }

    //private void overScreen()
    //{
    //    Vector3 viewPosition = Camera.main.WorldToViewportPoint(transform.position);

    //    if (viewPosition.x <= 0.0f)
    //    {
    //        Destroy(gameObject);
    //    }
    //    else if (viewPosition.x >= 1.0f)
    //    {
    //        Destroy(gameObject);
    //    }
    //    else if (viewPosition.y <= 0.0f)
    //    {
    //        Destroy(gameObject);
    //    }
    //    else if (viewPosition.y >= 1.0f)
    //    {
    //        Destroy(gameObject);
    //    }
    //}

    public void SetDamage(float damage, float movespeed)
    {
        m_moveSpeed = movespeed;
        m_damage = damage;
        enemyAttack = false;
    }

    public float CheckDamage()
    {
        return m_damage;
    }

}
