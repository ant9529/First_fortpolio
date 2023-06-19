using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Player player;

    [SerializeField] private float m_Hp = 5.0f;
    [SerializeField] private float m_MoveSpeed = 1;
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

            m_Hp -= Player.Instance.M_attackDamage;
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
        if (m_Hp == 0)
        {
            Destroy(gameObject);
        }
    }

    private void movepatten()
    {
        transform.position += transform.right * Time.deltaTime * m_MoveSpeed;
    }

    private void changeMoveAngle()
    {

    }
}
