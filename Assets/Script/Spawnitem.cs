using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawnitem : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        spawnItem();
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

    private void spawnItem()
    {
        Vector3 position = new Vector3(transform.position.x, transform.position.y, 0);
        Instantiate(ItemManager.Instance.m_listItem[iRnad()], transform.transform);
    }
}
