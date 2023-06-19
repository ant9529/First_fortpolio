using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Door : MonoBehaviour
{
    public static Door Instance;

    public bool M_UpDoor = false;
    public bool M_DownDoor = false;
    public bool M_LeftDoor = false;
    public bool M_RightDoor = false;
    private int nowRoom = 1;

    [SerializeField] GameObject objMap1;
    [SerializeField] GameObject objMap2;
    [SerializeField] GameObject objMap3;
    [SerializeField] GameObject objMap4;


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
        moveRoom();
    }

    private void moveRoom()
    {

        switch (nowRoom)
        {
            case 1:
                if (M_LeftDoor == true && Input.GetKeyDown(KeyCode.Space))
                {
                    objMap1.SetActive(false);
                    objMap2.SetActive(true);
                    M_LeftDoor = false;
                    nowRoom = 2;
                }
                else if (M_RightDoor == true && Input.GetKeyDown(KeyCode.Space))
                {
                    objMap1.SetActive(false);
                    objMap3.SetActive(true);
                    M_RightDoor = false;
                    nowRoom = 3;
                }
                else if (M_UpDoor == true && Input.GetKeyDown(KeyCode.Space))
                {
                    objMap1.SetActive(false);
                    objMap4.SetActive(true);
                    M_UpDoor = false;
                    nowRoom = 4;
                }
                break;

            case 2:
                if (M_RightDoor == true && Input.GetKeyDown(KeyCode.Space))
                {
                    objMap2.SetActive(false);
                    objMap1.SetActive(true);
                    M_RightDoor = false;
                    nowRoom = 1;
                }
                break;

            case 3:
                if (M_DownDoor == true && Input.GetKeyDown(KeyCode.Space))
                {
                    objMap3.SetActive(false);
                    objMap1.SetActive(true);
                    M_DownDoor = false;
                    nowRoom = 1;
                }
                break;

            case 4:
                if (M_LeftDoor == true && Input.GetKeyDown(KeyCode.Space))
                {
                    objMap4.SetActive(false);
                    objMap1.SetActive(true);
                    M_LeftDoor = false;
                    nowRoom = 1;
                }
                break;
        }
    }
}
