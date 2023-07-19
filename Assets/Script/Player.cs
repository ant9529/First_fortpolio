using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player Instance;

    [Header("체력")]
    [SerializeField]private int m_hp = 5;
    private int m_maxhp = 5;
    [SerializeField] private PlayerHp m_playerhp;

    [Header("능력치")]
    [SerializeField] private int m_attackSpeed = 10;
    [SerializeField] private int m_attackDamage = 1;
    [SerializeField] private int m_attackMoveSpeed = 10;
    [SerializeField] float m_moveSpeed = 3;

    [SerializeField] private GameObject m_objAttack;
    [SerializeField] private GameObject m_objBoom;
    [SerializeField] private Transform trsCoinparants;


    [SerializeField] private bool m_invicibillity = false;
    private float m_invicibilityTime = 3;
    private float m_invicibilityTimer = 0;

    private SpriteRenderer m_spr;
    private Animator m_anim;

    private float m_attackTime = 3;
    private float m_attackTimer = 0;
    private bool m_canAttack = true;


    //private void Awake()
    //{
    //    if (Instance == null)
    //    {
    //        Instance = this;
    //    }
    //    else
    //    {
    //        Destroy(this);
    //    }
    //}

    // Start is called before the first frame update
    void Start()
    {
        m_anim = GetComponent<Animator>();
        m_spr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        move();
        attack();
        boom();
        invicibillity();
        


    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Item")
        {
            Item item = collision.transform.GetComponent<Item>();
            eitemtag itemtag = item.Getitemtag();
            item.GetItem();
            SpriteRenderer itemspr = collision.transform.GetComponent<SpriteRenderer>();
            ItemManager.Instance.GetBookItem(itemspr.sprite, itemtag, collision.gameObject);

            switch (itemtag)
            {
                case eitemtag.Knife:
                    m_attackSpeed += 2;
                    break;

                case eitemtag.Axe:
                    m_attackDamage++;
                    break;

                case eitemtag.Hammer:
                    m_attackDamage += 2;
                    m_moveSpeed--;
                    break;

                case eitemtag.Sword:
                    m_attackDamage++;
                    m_attackSpeed++;
                    break;
            }
        }

        if (collision.tag == "ItemBoom")
        {
            GameManager.Instance.m_haveBoom++;
            Destroy(collision.gameObject);
        }

        if (collision.gameObject.layer == LayerMask.NameToLayer("Enemy") || collision.gameObject.layer == LayerMask.NameToLayer("Boss"))
        {
            checkHP();
            m_invicibillity = true;
            setalpha(0.2f);
            Physics2D.IgnoreLayerCollision(LayerMask.NameToLayer("Enemy"), LayerMask.NameToLayer("Player"), true);
            Physics2D.IgnoreLayerCollision(LayerMask.NameToLayer("EnemyBullet"), LayerMask.NameToLayer("Player"), true);
            Physics2D.IgnoreLayerCollision(LayerMask.NameToLayer("Boss"), LayerMask.NameToLayer("Player"), true);
            m_playerhp.Sethp(m_hp, m_maxhp);
        }
        else if (collision.gameObject.layer == LayerMask.NameToLayer("EnemyBullet"))
        {
            checkHP();
            m_invicibillity = true;
            setalpha(0.2f);
            Physics2D.IgnoreLayerCollision(LayerMask.NameToLayer("Enemy"), LayerMask.NameToLayer("Player"), true);
            Physics2D.IgnoreLayerCollision(LayerMask.NameToLayer("EnemyBullet"), LayerMask.NameToLayer("Player"), true);
            Physics2D.IgnoreLayerCollision(LayerMask.NameToLayer("Boss"), LayerMask.NameToLayer("Player"), true);
            m_playerhp.Sethp(m_hp, m_maxhp);
        }
        if (collision.gameObject.layer == LayerMask.NameToLayer("Potal"))
        {
            SceneLoadManager.Instance.m_inpotal = true;
        }

        if (collision.gameObject.layer == LayerMask.NameToLayer("Door"))
        {
            Door door = collision.transform.GetComponent<Door>();
            eDoortag tag = door.GetDoorTag();

            GameManager.Instance.SetBool(tag);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Door"))
        {
            GameManager.Instance.SetBoolfalse();
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

        if (horizontal == 1 || horizontal == -1 || vertical == 1 || vertical == -1)
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

        if (m_canAttack == false)
        {
            m_attackTimer += Time.deltaTime * m_attackSpeed;
            if (m_attackTimer >= m_attackTime)
            {
                m_canAttack = true;
                m_attackTimer = 0;
            }
        }

        if (Input.GetKey(KeyCode.UpArrow) && m_canAttack == true)
        {
            m_canAttack = false;

            GameObject objatck = Instantiate(m_objAttack, position, Quaternion.Euler(0,0,0f), trsCoinparants);
            Attack scAttack = objatck.GetComponent<Attack>();
            scAttack.SetDamage(m_attackDamage, m_attackMoveSpeed);
        }
        else if (Input.GetKey(KeyCode.DownArrow) && m_canAttack == true)
        {
            m_canAttack = false;

            GameObject objatck = Instantiate(m_objAttack, position, Quaternion.Euler(0, 0, 180f), trsCoinparants);
            Attack scAttack = objatck.GetComponent<Attack>();
            scAttack.SetDamage(m_attackDamage, m_attackMoveSpeed);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            scale.x = -1;
            transform.localScale = scale;
            if (m_canAttack == true)
            {
                GameObject objatck = Instantiate(m_objAttack, position, Quaternion.Euler(0, 0, 270f), trsCoinparants);
                Attack scAttack = objatck.GetComponent<Attack>();
                scAttack.SetDamage(m_attackDamage, m_attackMoveSpeed);
            }
            m_canAttack = false;
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            scale.x = 1;
            transform.localScale = scale;
            if (m_canAttack == true)
            {
                GameObject objatck = Instantiate(m_objAttack, position, Quaternion.Euler(0, 0, 90f), trsCoinparants);
                Attack scAttack = objatck.GetComponent<Attack>();
                scAttack.SetDamage(m_attackDamage, m_attackMoveSpeed);
            }
            m_canAttack = false;
        }
    }
    private void boom()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            if (GameManager.Instance.m_haveBoom <= 0)
            {
                return;
            }
            else if (GameManager.Instance.m_haveBoom > 0)
            {
                GameObject objboom = Instantiate(m_objBoom, transform.position, Quaternion.identity, trsCoinparants);
                GameManager.Instance.m_haveBoom--;
            }
        }
    }

    private void invicibillity()
    {
        if (m_invicibillity == false)
        {
            return;
        }
        if (m_invicibillity == true)
        {
            m_invicibilityTimer += Time.deltaTime * 3 ;
            if (m_invicibilityTimer >= m_invicibilityTime)
            {
                m_invicibilityTimer = 0;
                m_invicibillity = false;
                setalpha(1.0f);
                Physics2D.IgnoreLayerCollision(LayerMask.NameToLayer("Enemy"), LayerMask.NameToLayer("Player"), false);
                Physics2D.IgnoreLayerCollision(LayerMask.NameToLayer("EnemyBullet"), LayerMask.NameToLayer("Player"), false);
                Physics2D.IgnoreLayerCollision(LayerMask.NameToLayer("Boss"), LayerMask.NameToLayer("Player"), false);
            }
        }
    }
    private void setalpha(float _alpha)
    {
        Color color = m_spr.color;
        color.a = _alpha;
        m_spr.color = color;
    }

    private void checkHP()
    {

        if (m_hp > 0)
        {
            m_hp--;
        }
        else if (m_hp <= 0)
        {
            StartCoroutine(GameManager.Instance.FadeText());
        }
    }
    public Vector3 Getstatus()
    {
        Vector3 status = new Vector3(m_attackDamage, m_attackSpeed, m_moveSpeed);

        return status;
    }
    public void SetPosion(Vector3 _position)
    {
        transform.position = _position;
    }
}
