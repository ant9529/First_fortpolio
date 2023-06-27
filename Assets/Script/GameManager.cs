using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public int m_nowRoom = 1;
    public int m_haveBoom = 3;

    [SerializeField] private TextMeshProUGUI m_haveBoomText;



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
        
    }

    // Update is called once per frame
    void Update()
    {
        boomcount();
    }

    public void Setalpha(float _alpha)
    {
        SpriteRenderer m_spr;
        m_spr = GetComponent<SpriteRenderer>();

        Color color = m_spr.color;
        color.a = _alpha;
        m_spr.color = color;
    }

    private void boomcount()
    {
        m_haveBoomText.SetText($"X{m_haveBoom}");
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


}
