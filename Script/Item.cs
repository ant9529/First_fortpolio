using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    [SerializeField] private eitemtag m_itemtag;
    private SpriteRenderer m_spr;
    private ItemManager inven;

    // Start is called before the first frame update
    void Start()
    {
        inven = ItemManager.Instance;
        m_spr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public eitemtag Getitemtag()
    {
        return m_itemtag;
    }

    public void GetItem()
    {
        if (inven.getItem(m_spr.sprite))
        {
            Destroy(gameObject);
        }
        else
        {
            Debug.Log("�κ��丮�� �ڸ��� �����ϴ�");
        }
    }
}
