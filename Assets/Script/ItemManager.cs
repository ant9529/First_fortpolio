using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Newtonsoft.Json;

public class ItemManager : MonoBehaviour
{
    public static ItemManager Instance;

    [Header("스테이터스")]
    public List<GameObject> m_listItem = new List<GameObject>();
    private List<Transform> m_listInventory = new List<Transform>();
    private List<Sprite> m_listSprite = new List<Sprite>();
    [SerializeField] private Transform m_trsinven;
    [SerializeField] private GameObject m_Item;
    [SerializeField] private GameObject m_statusUi;
    private bool m_onstatus = false;

    [Header("도감")]
    [SerializeField] GameObject m_item;
    [SerializeField] GameObject m_objBookUI;
    [SerializeField] Transform m_trsBookSlot;
    List<Transform> m_listBookUi = new List<Transform>();
    private bool onBookUI = false;

    [Space]
    public Transform m_itemCreat;

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

    void Start()
    {
        addListRange();
        GetBookList();
        GetBookSprite();
        setPlayerFrebs();
    }

    // Update is called once per frame
    void Update()
    {
        callStatusUI();
        callBookUI();
    }

    private void addListRange()
    {
        m_listInventory.AddRange(m_trsinven.GetComponentsInChildren<Transform>());
        m_listInventory.RemoveAt(0);
    }

    private int getEmptyInventory()
    {
        int count = m_listInventory.Count;

        for (int iNum = 0; iNum < count; iNum++)
        {
            if (m_listInventory[iNum].childCount == 0)
            {
                return iNum;
            }
        }
        return -1;
    }

    public bool getItem(Sprite _spr)
    {
        int slotNum = getEmptyInventory();
        if (slotNum == -1)
        {
            return false;
        }
        GameObject obj = Instantiate(m_Item, m_listInventory[slotNum]);
        ItemUI itemui = obj.GetComponent<ItemUI>();
        itemui.SetSprite(_spr);
        return true;
    }

        private void callStatusUI()
    {
        if (Input.GetKeyDown(KeyCode.E) && m_onstatus == false)
        {
            m_statusUi.SetActive(true);
            m_onstatus = true;
        }
        else if (Input.GetKeyDown(KeyCode.E) && m_onstatus == true)
        {
            m_statusUi.SetActive(false);
            m_onstatus = false;
        }
    }

    private void callBookUI()
    {
        if (Input.GetKeyDown(KeyCode.U))
        {
            if (onBookUI == true)
            {
                m_objBookUI.SetActive(false);
                onBookUI = false;
            }
            else
            {
                m_objBookUI.SetActive(true);
                onBookUI = true;
            }

        }
    }

    private void GetBookList()
    {
        m_listBookUi.AddRange(m_trsBookSlot.GetComponentsInChildren<Transform>());
        m_listBookUi.RemoveAt(0);
    }

    private void GetBookSprite()
    {
        
        for (int iNum = 0; iNum < m_listItem.Count; iNum++)
        {
            SpriteRenderer _spr = m_listItem[iNum].GetComponent<SpriteRenderer>();
            m_listSprite.Add(_spr.sprite);
        }
    }

    public void GetBookItem(Sprite _spr, eitemtag _tag, GameObject _obj)
    {
        int tagNum = (int)_tag;
        SpriteRenderer spr = _obj.GetComponent<SpriteRenderer>();
        GameObject obj = Instantiate(m_item, m_listBookUi[tagNum]);
        ItemUI ItemUI = obj.GetComponent<ItemUI>();
        ItemUI.SetSprite(_spr);
        playerfrebs(tagNum.ToString(),spr.sprite);
        
    }

    private void playerfrebs(string _key, Sprite _spr)
    {
        PlayerPrefs.SetString(_key, _spr.name);
    }

    private void setPlayerFrebs()
    {
        for (int iNum = 0; iNum < m_listItem.Count; iNum++)
        {
            SpriteRenderer _spr = m_listItem[iNum].GetComponent<SpriteRenderer>();
            if (m_listItem[iNum] == null)
            {
                return;       
            }
            else if (_spr.GetComponent<SpriteRenderer>().sprite.name == PlayerPrefs.GetString(iNum.ToString()))
            {
                GameObject obj = Instantiate(m_item, m_listBookUi[iNum]);
                ItemUI ItemUI = obj.GetComponent<ItemUI>();
                ItemUI.SetSprite(_spr.sprite);
            }
        }
    }
}
