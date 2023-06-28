using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour
{
    public static ItemManager Instance;

    [SerializeField] private GameObject m_inventory;
    [SerializeField] private Transform m_trsinven;
    [SerializeField] private GameObject m_Item;


    private List<Transform> m_listInventory = new List<Transform>();

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

    void Start()
    {
        addListRange();
    }

    // Update is called once per frame
    void Update()
    {
        
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
}
