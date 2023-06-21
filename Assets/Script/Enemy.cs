using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float m_enemyHp = 5.0f;
    [SerializeField] private float m_enemyMoveSpeed = 1;
    [SerializeField] private float m_Damage;
    private Player m_player;


    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Coin")
        {
         m_player = GetComponent<Player>();
         m_enemyHp -= m_player.Setdamage();
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
        checkHp();
        movepatten();
    }

    private void checkHp()
    {
        if (m_enemyHp == 0)
        {
            Destroy(gameObject);
        }
    }

    private void movepatten()
    {
        transform.position += transform.right * Time.deltaTime * m_enemyMoveSpeed;
    }
}
