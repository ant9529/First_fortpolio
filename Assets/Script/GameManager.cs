using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public int m_nowRoom = 1;
    public int m_haveBoom = 3;

    GameObject objMap1;
    GameObject objMap2;
    GameObject objMap3;
    GameObject objMap4;
    GameObject objMap5;
    [SerializeField]public bool m_bright = false;
    [SerializeField]public bool m_bleft = false;
    [SerializeField]public bool m_bup = false;
    [SerializeField]public bool m_bdown = false;

    [SerializeField] private TextMeshProUGUI m_haveBoomText;
    [SerializeField] private TextMeshProUGUI m_damageText;
    [SerializeField] private TextMeshProUGUI m_attackSpeedText;
    [SerializeField] private TextMeshProUGUI m_moveSpeedText;
    [SerializeField] private Player m_player;
    [SerializeField] private Transform m_trsAttack;

    Vector3 m_inRightDoor = new Vector3(-8.7f, 1f, 0);
    Vector3 m_inLeftdoor = new Vector3(8.7f, 1f, 0);
    Vector3 m_inDownDoor = new Vector3(0, 5.7f, 0);
    Vector3 m_inUpDoor = new Vector3(0, -3.6f, 0);

    void Awake()
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
        objMap1 = GameObject.Find("ParentsMap1").transform.GetChild(0).gameObject;
        objMap2 = GameObject.Find("ParentsMap2").transform.GetChild(0).gameObject;
        objMap3 = GameObject.Find("ParentsMap3").transform.GetChild(0).gameObject;
        objMap4 = GameObject.Find("ParentsMap4").transform.GetChild(0).gameObject;
        objMap5 = GameObject.Find("ParentsMap5").transform.GetChild(0).gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        SetText();
        changeRoomKeyDown();
    }

    public void Setalpha(float _alpha)
    {
        SpriteRenderer m_spr;
        m_spr = GetComponent<SpriteRenderer>();

        Color color = m_spr.color;
        color.a = _alpha;
        m_spr.color = color;
    }

    private void SetText()
    {
        m_haveBoomText.SetText($"X{m_haveBoom}");
        m_damageText.SetText($"{m_player.Getstatus().x}");
        m_attackSpeedText.SetText($"{m_player.Getstatus().y}");
        m_moveSpeedText.SetText($"{m_player.Getstatus().z}");
    }

    public Vector3Int changeVector3(float _x, float _y)
    {
        float roundX = Mathf.Round(_x);
        float roundY = Mathf.Round(_y);

        int Xvector3 = (int)roundX;
        int Yvector3 = (int)roundY;
        int Zvector3 = 0;

        Vector3Int intvector3 = new Vector3Int(Xvector3, Yvector3, Zvector3);
        return intvector3;
    }

    public void DestroyAttack()
    {
        int count = m_trsAttack.childCount;
        for (int iNum = 0; iNum < count; iNum++)
        {
            Destroy(m_trsAttack.GetChild(iNum).gameObject);
        }
    }

    public void SetBool(eDoortag _tag)
    {
        switch (_tag)
        {
            case eDoortag.RightDoor:
                m_bright = true;
                break;
            case eDoortag.LeftDoor:
                m_bleft = true;
                break;
            case eDoortag.UpDoor:
                m_bup = true;
                break;
            case eDoortag.DownDoor:
                m_bdown = true;
                break;
        }
    }

    public void SetBoolfalse()
    {
        m_bright = false;
        m_bleft = false;
        m_bup = false;
        m_bdown = false;
    }

    private void changeRoomKeyDown()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ChangeRoom();
        }
    }

    private void ChangeRoom()
    {
        DestroyAttack();
        switch (m_nowRoom)
        {
            case 1:
                if (m_bleft == true)
                {
                    objMap1.SetActive(false);
                    objMap2.SetActive(true);
                    m_nowRoom = 2;
                    m_player.SetPosion(m_inLeftdoor);
                    m_bleft = false;
                }
                else if (m_bright == true)
                {
                    objMap1.SetActive(false);
                    objMap4.SetActive(true);
                    m_nowRoom = 4;
                    m_player.SetPosion(m_inRightDoor);
                m_bright = false;
                }
                else if (m_bup == true)
                {
                    objMap1.SetActive(false);
                    objMap3.SetActive(true);
                    m_nowRoom = 3;
                    m_player.SetPosion(m_inUpDoor);
                m_bup = false;
                }
                break;

            case 2:
                if (m_bright == true)
                {
                    objMap2.SetActive(false);
                    objMap1.SetActive(true);
                    m_nowRoom = 1;
                    m_player.SetPosion(m_inRightDoor);
                m_bright = false;
                }
                break;

            case 3:
                if (m_bdown == true)
                {
                    objMap3.SetActive(false);
                    objMap1.SetActive(true);
                    m_nowRoom = 1;
                    m_player.SetPosion(m_inDownDoor);
                    m_bdown = false;
                }
                else if (m_bup == true)
                {
                    objMap3.SetActive(false);
                    objMap5.SetActive(true);
                    m_nowRoom = 5;
                    m_player.SetPosion(m_inUpDoor);
                    m_bup = false;
                }
                break;

            case 4:
                if (m_bleft == true)
                {
                    objMap4.SetActive(false);
                    objMap1.SetActive(true);
                    m_nowRoom = 1;
                    m_player.SetPosion(m_inLeftdoor);
                m_bleft = false;
                }
                break;
        }
        
    }
}
