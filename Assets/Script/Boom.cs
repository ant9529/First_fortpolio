using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Boom : MonoBehaviour
{
    [SerializeField] private GameObject explosion;

    private float m_boomtime = 3;
    private float m_boomtimer = 0;
    private float m_boomsec = 5;

    GameObject objmanager;
    GameManager scmanager;

    private GameObject objRock;


    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Rock"))
        {
            objRock = collision.gameObject;
            Tilemap tilemap = objRock.GetComponent<Tilemap>();
           
            Vector3Int boomtileorigin = scmanager.changeVector3(transform.position.x-0.5f,transform.position.y-0.5f);
            Vector3Int boomtile1 = new Vector3Int(boomtileorigin.x+1, boomtileorigin.y, 0);
            Vector3Int boomtile2 = new Vector3Int(boomtileorigin.x-1, boomtileorigin.y, 0);
            Vector3Int boomtile3 = new Vector3Int(boomtileorigin.x, boomtileorigin.y+1, 0);
            Vector3Int boomtile4 = new Vector3Int(boomtileorigin.x, boomtileorigin.y-1, 0);

            tilemap.SetTile(boomtile1, null);
            tilemap.SetTile(boomtile2, null);
            tilemap.SetTile(boomtile3, null);
            tilemap.SetTile(boomtile4, null);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        objmanager = GameObject.Find("Manager").transform.GetChild(0).gameObject;
        scmanager = objmanager.GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        boomtimer();
       
    }

    private void boomtimer()
    {
        if (m_boomtimer >= m_boomtime)
        {
            Destroy(gameObject);
            Instantiate(explosion, transform.position, Quaternion.identity);
        }
        m_boomtimer += Time.deltaTime * m_boomsec;
    }

}
