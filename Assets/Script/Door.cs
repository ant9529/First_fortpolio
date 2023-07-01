using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Door : MonoBehaviour
{
    [SerializeField] private eDoortag m_eDoor; 

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public eDoortag GetDoorTag()
    {
        return m_eDoor;
    }
}
