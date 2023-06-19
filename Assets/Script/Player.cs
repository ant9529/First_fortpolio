using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player Instance;
    
    [SerializeField] float m_moveSpeed = 3;
    [SerializeField] public float M_attackDamage = 1.0f;
    private Camera m_camera;
    private Animator m_anim;
    [SerializeField] private GameObject m_objcoin;
    [SerializeField] private Transform trsCoinparants;

    [SerializeField] private float attackSpeed = 10;
    private float m_attackTime = 3;
    private float m_attackTimer = 0;
    [SerializeField] private bool m_canAttack = true;


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

    // Start is called before the first frame update
    void Start()
    {
        m_camera = GetComponent<Camera>();
        m_anim = GetComponent<Animator>();
       
    }

    // Update is called once per frame
    void Update()
    {
        move();
        attack();
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Potal")
        {
            SceneLoadManager.Instance.m_inPotal = true;
        }
        if (collision.tag == "LeftDoor")
        {
            Door.Instance.M_LeftDoor = true;
        }
        else if (collision.tag == "RightDoor")
        {
            Door.Instance.M_RightDoor = true;
        }
        else if (collision.tag == "UpDoor")
        {
            Door.Instance.M_UpDoor = true;
        }
        else if (collision.tag == "DownDoor")
        {
            Door.Instance.M_DownDoor = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "LeftDoor")
        {
            Door.Instance.M_LeftDoor = false;
        }
        else if (collision.tag == "RightDoor")
        {
            Door.Instance.M_RightDoor = false;
        }
        else if (collision.tag == "UpDoor")
        {
            Door.Instance.M_UpDoor = false;
        }
        else if (collision.tag == "DownDoor")
        {
            Door.Instance.M_DownDoor = false;
        }
    }

    private void move()
    {
        float horizontal = 0;
        float vertical = 0;
        Vector3 scale = new Vector3(transform.localScale.x, transform.localScale.y, 0);
        if (Input.GetKey(KeyCode.A))
        {
            horizontal = -1;
            scale.x = 1;
           
        }
        else if (Input.GetKey(KeyCode.D))
        {
            horizontal = 1;
            scale.x = -1;
            
        }
        if (Input.GetKey(KeyCode.W))
        {
            vertical = 1;
           
        }
        else if (Input.GetKey(KeyCode.S))
        {
            vertical = -1;
           
        }

        Vector3 position = new Vector3(transform.position.x, transform.position.y, 0);

        position.x += horizontal * Time.deltaTime * m_moveSpeed;
        position.y += vertical * Time.deltaTime * m_moveSpeed;

        transform.position = position;
        transform.localScale = scale;

        if (horizontal == 1 || horizontal == -1)
            m_anim.SetBool("move", true);
        else
        {
            m_anim.SetBool("move", false);
        }
    }

    private void attack()
    {
        Vector3 scale = new Vector3(transform.localScale.x, transform.localScale.y, 0);
        Vector3 position = new Vector3(transform.position.x, transform.position.y, 0);

        m_attackTimer += Time.deltaTime * attackSpeed;
        if (m_attackTimer >= m_attackTime)
        {
            m_canAttack = true;
            m_attackTimer = 0;
        }

        if (Input.GetKey(KeyCode.UpArrow) && m_canAttack == true)
        {
            m_canAttack = false;

            Instantiate(m_objcoin, position, Quaternion.Euler(0,0,0f), trsCoinparants);
        }
        else if (Input.GetKey(KeyCode.DownArrow) && m_canAttack == true)
        {
            m_canAttack = false;

            Instantiate(m_objcoin, position, Quaternion.Euler(0, 0, 180f), trsCoinparants);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            scale.x = -1;
            transform.localScale = scale;
            if (m_canAttack == true)
            {
                
                Instantiate(m_objcoin, position, Quaternion.Euler(0, 0, 270f), trsCoinparants);
            }
            m_canAttack = false;
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            scale.x = 1;
            transform.localScale = scale;
            if (m_canAttack == true)
            {
                
                Instantiate(m_objcoin, position, Quaternion.Euler(0, 0, 90f), trsCoinparants);
            }
            m_canAttack = false;
        }
    }

}
