using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public GameObject ui;
    public float baseMoveSpeed = 6;
    public float leftRightSpeed = 8;
    public static int lives = 3;

    private float actualMoveSpeed = 3;
    private bool gameOver = false;
    private bool movingLeft = false;
    private bool movingRight = false;
    private float leftRoad = -2.0f;
    private float midRoad = 0f;
    private float rightRoad = 2.0f;
    private int actualRoad = 1;

    void Start()
    {
        actualMoveSpeed = baseMoveSpeed;
    }

    public void removeLife()
    {
        lives--;
        if (lives == 0)
        {
            gameOver = true;
            ui.GetComponent<UI>().setGameOver();
        }
    }

    public void enterCollision()
    {
        removeLife();
    }


    void Update()
    {

        if (lives == 0)
        {
            gameOver = true;
            ui.GetComponent<UI>().setGameOver();
        }


        if (!gameOver)
        {
            transform.Translate(Vector3.forward * Time.deltaTime * actualMoveSpeed, Space.World);

            if (!(movingLeft || movingRight))
            {
                

                if (Input.GetKey(KeyCode.A))
                {
                    if (this.gameObject.transform.position.x > LevelBoundary.leftSide)
                        movingLeft = true;
                            //transform.Translate(Vector3.left * Time.deltaTime * leftRightSpeed, Space.World);
                }
                else if (Input.GetKey(KeyCode.D))
                {

                    if (this.gameObject.transform.position.x < LevelBoundary.rightSide)
                        movingRight = true;
                    //transform.Translate(-1 * Vector3.left * Time.deltaTime * leftRightSpeed, Space.World);
                }
            }
            if (movingLeft)
            {
                //if (this.gameObject.transform.position.x > LevelBoundary.leftSide)
                //transform.Translate(Vector3.left * Time.deltaTime * leftRightSpeed, Space.World);
                if (actualRoad == 0)
                {
                    movingLeft = false;
                }
                else if (actualRoad == 1 && this.gameObject.transform.position.x <= leftRoad)
                {
                    movingLeft = false;
                    actualRoad = 0;
                }
                else if (actualRoad == 2 && this.gameObject.transform.position.x <= midRoad)
                {
                    movingLeft = false;
                    actualRoad = 1;
                }
                else
                {
                    transform.Translate(Vector3.left * Time.deltaTime * leftRightSpeed, Space.World);
                }
            }
            else if (movingRight)
            {
                if (actualRoad == 0 && this.gameObject.transform.position.x >= midRoad)
                {
                    movingRight = false;
                    actualRoad = 1;
                }
                else if (actualRoad == 1 && this.gameObject.transform.position.x >= rightRoad)
                {
                    movingRight = false;
                    actualRoad = 2;
                }
                else if (actualRoad == 2)
                {
                    movingRight = false;
                }
                else
                {
                    transform.Translate(-1 * Vector3.left * Time.deltaTime * leftRightSpeed, Space.World);
                }
            }
        }
        
    }
}
