using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class apple : MonoBehaviour
{
    private GameObject snake;
    void Start()
    {
        snake = GameObject.Find("Snake");

    }


    void Update()
    {
        if (new Vector2(transform.position.x, transform.position.y) == new Vector2(snake.transform.position.x, snake.transform.position.y))
        {
            snake.GetComponent<SnakeMovement>().eatApple();
            Destroy(gameObject);
        }
    }  
}