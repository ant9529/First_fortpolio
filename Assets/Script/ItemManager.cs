using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour
{
    [SerializeField] private List<GameObject> m_listItem = new List<GameObject>();
    // Start is called before the first frame update
    void Start()
    {
        Vector3 position = new Vector3(transform.position.x, transform.position.y, 0);
        Instantiate(m_listItem[iRnad()],transform.transform);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private int iRnad()
    {
        int Rand = Random.Range(0, 4);
        return Rand;
    }
}