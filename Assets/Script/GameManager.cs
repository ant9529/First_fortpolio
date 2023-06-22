using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    GameObject objMap1;
    GameObject objMap2;
    GameObject objMap3;
    GameObject objMap4;
    public bool M_UpDoor = false;
    public bool M_DownDoor = false;
    public bool M_LeftDoor = false;
    public bool M_RightDoor = false;
    public int nowRoom = 1;

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
    // Start is called before the first frame update
    void Start()
    {
        objMap1 = GameObject.Find("ParentsMap1").transform.GetChild(0).gameObject;
        objMap2 = GameObject.Find("ParentsMap2").transform.GetChild(0).gameObject;
        objMap3 = GameObject.Find("ParentsMap3").transform.GetChild(0).gameObject;
        objMap4 = GameObject.Find("ParentsMap4").transform.GetChild(0).gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        changeRoom();
    }

    private void changeRoom()
    {
        Vector3 m_inRightDoor  = new Vector3(-8.7f, 1f, 0);
        Vector3 m_inLeftdoor = new Vector3(8.7f, 1f, 0);
        Vector3 m_inDoiwnDoor    = new Vector3(0, 5.7f, 0);
        Vector3 m_inUpDoor  = new Vector3(0, -3.6f, 0);

        switch (nowRoom)
        {
            case 1:
                if (M_LeftDoor == true && Input.GetKeyDown(KeyCode.Space))
                {
                    objMap1.SetActive(false);
                    objMap2.SetActive(true);
                    M_LeftDoor = false;
                    nowRoom = 2;
                    Player.Instance.transform.position = m_inLeftdoor;
                }
                else if (M_RightDoor == true && Input.GetKeyDown(KeyCode.Space))
                {
                    objMap1.SetActive(false);
                    objMap4.SetActive(true);
                    M_RightDoor = false;
                    nowRoom = 4;
                    Player.Instance.transform.position = m_inRightDoor;
                }
                else if (M_UpDoor == true && Input.GetKeyDown(KeyCode.Space))
                {
                    objMap1.SetActive(false);
                    objMap3.SetActive(true);
                    M_UpDoor = false;
                    nowRoom = 3;
                    Player.Instance.transform.position = m_inUpDoor;
                }
                break;

            case 2:
                if (M_RightDoor == true && Input.GetKeyDown(KeyCode.Space))
                {
                    objMap2.SetActive(false);
                    objMap1.SetActive(true);
                    M_RightDoor = false;
                    nowRoom = 1;
                    Player.Instance.transform.position = m_inRightDoor;
                }
                break;

            case 3:
                if (M_DownDoor == true && Input.GetKeyDown(KeyCode.Space))
                {
                    objMap3.SetActive(false);
                    objMap1.SetActive(true);
                    M_DownDoor = false;
                    nowRoom = 1;
                    Player.Instance.transform.position = m_inDoiwnDoor;
                }
                break;

            case 4:
                if (M_LeftDoor == true && Input.GetKeyDown(KeyCode.Space))
                {
                    objMap4.SetActive(false);
                    objMap1.SetActive(true);
                    M_LeftDoor = false;
                    nowRoom = 1;
                    Player.Instance.transform.position = m_inLeftdoor;
                }
                break;
        }
    }
}
