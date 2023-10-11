using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterMovement : MonoBehaviour
{
    //Variables
    Rigidbody2D rb;
    private float speed = 3f;
    private Vector2 dir;
    private bool dirx = false;
    private float rot;
    private float temp;

    public float leftPos;
    public float rightPos;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rot = rb.transform.rotation.eulerAngles.y;
        if(rot == 180)
        {
            dirx = true;
        }
            
    }

    // Update is called once per frame
    void Update()
    {
        rot = rb.transform.rotation.eulerAngles.y;
        if (rot == 0 || dirx == false)
        {
            dir = new Vector2(-1, 0);
            rb.velocity = dir * speed;
            if (rb.transform.position.x <= leftPos)
            {
                rb.transform.Rotate(0, 180, 0);
                dirx = true;
            }
        }
        else if (rot == 180 || dirx == true)
        {
            dir = new Vector2(1, 0);
            rb.velocity = dir * speed;
            if (rb.transform.position.x >= rightPos)
            {
                rb.transform.Rotate(0, 180, 0);
                dirx = false;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            temp = PlayerPrefs.GetFloat("Health", temp);
            PlayerPrefs.SetFloat("Health", temp - Random.Range(20, 30));
        }
    }
}
