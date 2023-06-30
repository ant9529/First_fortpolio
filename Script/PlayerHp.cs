using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHp : MonoBehaviour
{
    [SerializeField]private Image m_HpUI;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Sethp(int _hp, int _maxhp )
    {
        m_HpUI.fillAmount = (float)_hp / _maxhp;
    }
}
