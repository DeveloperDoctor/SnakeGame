using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeMovement : MonoBehaviour
{
    private float timer1, snakeWidth;
    public float timer2;
    private string direction, nowDirection;
    public GameObject apple, tail;
    [HideInInspector]
    public int totalTail;
    [HideInInspector]
    public Vector3[] snakeTails;
    private bool tailSpawn;
    void Start()
    {
        tailSpawn = false;
        transform.position = new Vector3(0, 0, transform.position.z);

        timer2 /= 100;

        snakeWidth = gameObject.GetComponent<SpriteRenderer>().size.x;

        snakeTails = new Vector3[10 * 19];
        
        

    }

    
    void Update()
    {
        if (transform.position.x > 10 * snakeWidth)
        {
            transform.position = new Vector3(- 10 * snakeWidth, transform.position.y, transform.position.z);
        }
        if (transform.position.x < -10 * snakeWidth)
        {
            transform.position = new Vector3(10 * snakeWidth, transform.position.y, transform.position.z);
        }
        if (transform.position.y > 19 * snakeWidth)
        {
            transform.position = new Vector3(transform.position.x, -19 * snakeWidth, transform.position.z);
        }
        if (transform.position.y < -19 * snakeWidth)
        {
            transform.position = new Vector3(transform.position.x, 19 * snakeWidth, transform.position.z);
        }



        if (GameObject.FindGameObjectWithTag("Apple") == null)
      {
            Instantiate(apple, new Vector3(Random.Range(-10, 11)*snakeWidth, Random.Range(-19, 20)*snakeWidth, apple.transform.position.z), Quaternion.identity);
      }
        
        
        
        
        //daha sonra buton eklenecek kodlar
        if (Input.GetKey("w") || Input.GetKey("up"))
        {
            if (nowDirection != "down")
            {
                direction = "up";

            }
        }
        if (Input.GetKey("s") || Input.GetKey("down"))
        {
            if (nowDirection != "up")
            {
                direction = "down";

            }
        }
        if (Input.GetKey("a") || Input.GetKey("left"))
        {
            if (nowDirection != "right")
            {
                direction = "left";

            }
        }
        if (Input.GetKey("d") || Input.GetKey("right"))
        {
            if (nowDirection != "left")
            {
                direction = "right";

            }
        }
        azUpdate();             
    }

    private void Instantiate(GameObject apple, Vector3 vector3)
    {
        throw new System.NotImplementedException();
    }

    private void azUpdate()
    {

        if (Time.time > timer1)
        {
           for (int i = 0; i<totalTail; i++) 
           {

                snakeTails[totalTail-i] = snakeTails[totalTail-1-i];
            
           }

            snakeTails[0] = transform.position;

            if (direction == "right")
            {
                nowDirection = direction;
                transform.position = new Vector3(transform.position.x + snakeWidth, transform.position.y, transform.position.z);
            }

            if (direction == "left")
            {
                nowDirection = direction;
                transform.position = new Vector3(transform.position.x - snakeWidth, transform.position.y, transform.position.z);
            }
            if (direction == "up")
            {
                nowDirection = direction;
                transform.position = new Vector3(transform.position.x, transform.position.y + snakeWidth, transform.position.z);
            }
            if (direction == "down")
            {
                nowDirection = direction;
                transform.position = new Vector3(transform.position.x, transform.position.y - snakeWidth, transform.position.z);
            }
            if (tailSpawn == true)
            {
                Instantiate(tail, transform.position, Quaternion.identity);
                tailSpawn = false;
            }

            timer1 = timer2 + Time.time;

           

        }



    }

    public void eatApple()
    {
        totalTail += 1;
        tailSpawn = true;
    }

}
