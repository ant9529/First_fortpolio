using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    private float m_moveSpeed;
    private float m_damage;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        move();
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

    public void SetDamage(float damage, float movespeed)
    {
        m_moveSpeed = movespeed;
        m_damage = damage;
    }

    public float CheckDamage()
    {
        return m_damage;
    }

}
