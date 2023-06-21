using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    [SerializeField]private float moveSpeed = 10;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        move();
        overScreen();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            Destroy(gameObject);
        }
    }

    private void move()
    {
        transform.position += transform.up * Time.deltaTime * moveSpeed;
    }

    private void overScreen()
    {
        Vector3 viewPosition = Camera.main.WorldToViewportPoint(transform.position);

        if (viewPosition.x <= 0.0f)
        {
            Destroy(gameObject);
        }
        else if (viewPosition.x >= 1.0f)
        {
            Destroy(gameObject);
        }
        else if (viewPosition.y <= 0.0f)
        {
            Destroy(gameObject);
        }
        else if (viewPosition.y >= 1.0f)
        {
            Destroy(gameObject);
        }

    }

}
