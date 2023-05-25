using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class tailMovement : MonoBehaviour
{
    private GameObject snake;
    private int tailNumber;
    private bool checkDeath;
    void Start()
    {
        checkDeath = false;
        snake = GameObject.Find("Snake");
        tailNumber = snake.GetComponent<SnakeMovement>().totalTail - 1;
    }

   
    void Update()
    {
        if (checkDeath == true)
        {
            if (new Vector2(transform.position.x, transform.position.y) == new Vector2(snake.transform.position.x, snake.transform.position.y))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }

        else
        {
            checkDeath= true;
        }
        transform.position = snake.GetComponent<SnakeMovement>().snakeTails[tailNumber];


    }
}
