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

    private bool turningLeft = false;
    private bool turningRight = false;

    float rot = 0.0f;
    float acc = 0.01f;

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

        if(Input.GetKeyDown(KeyCode.JoystickButton0)) {
            Debug.Log("!!!!!!!!!!!!!!!!!!! 0");
        };
        if(Input.GetKeyDown(KeyCode.JoystickButton1)) {
            Debug.Log("!!!!!!!!!!!!!!!!!!! 1");
        };
        if(Input.GetKeyDown(KeyCode.JoystickButton2)) {
            Debug.Log("!!!!!!!!!!!!!!!!!!! 2");
        };
        if(Input.GetKeyDown(KeyCode.JoystickButton3)) {
            Debug.Log("!!!!!!!!!!!!!!!!!!! 3");
        };
        if(Input.GetKeyDown(KeyCode.JoystickButton4)) {
            Debug.Log("!!!!!!!!!!!!!!!!!!! 4");
        };
        if(Input.GetKeyDown(KeyCode.JoystickButton5)) {
            Debug.Log("!!!!!!!!!!!!!!!!!!! 5");
        };
        if(Input.GetKeyDown(KeyCode.JoystickButton6)) {
            Debug.Log("!!!!!!!!!!!!!!!!!!! 6");
        };

        if (lives == 0)
        {
            gameOver = true;
            ui.GetComponent<UI>().setGameOver();
        }

        handleInput();

        if (!gameOver) {
            transform.Translate(Vector3.forward * Time.deltaTime * actualMoveSpeed, Space.World);
            
            moveFree();
        }
        
    }

    private void moveLane() {
        if (!(movingLeft || movingRight)) {
                if (turningLeft) {
                    if (this.gameObject.transform.position.x > LevelBoundary.leftSide)
                        movingLeft = true;
                }
                else if (turningRight) {
                    if (this.gameObject.transform.position.x < LevelBoundary.rightSide)
                        movingRight = true;
                }
            }
            if (movingLeft) {
                if (actualRoad == 0) {
                    movingLeft = false;
                }
                else if (actualRoad == 1 && this.gameObject.transform.position.x <= leftRoad) {
                    movingLeft = false;
                    actualRoad = 0;
                }
                else if (actualRoad == 2 && this.gameObject.transform.position.x <= midRoad) {
                    movingLeft = false;
                    actualRoad = 1;
                }
                else {
                    transform.Translate(Vector3.left * Time.deltaTime * leftRightSpeed, Space.World);
                }
            }
            else if (movingRight) {
                if (actualRoad == 0 && this.gameObject.transform.position.x >= midRoad) {
                    movingRight = false;
                    actualRoad = 1;
                }
                else if (actualRoad == 1 && this.gameObject.transform.position.x >= rightRoad) {
                    movingRight = false;
                    actualRoad = 2;
                }
                else if (actualRoad == 2) {
                    movingRight = false;
                }
                else {
                    transform.Translate(-1 * Vector3.left * Time.deltaTime * leftRightSpeed, Space.World);
                }
            }
    }

    private void moveFree() {
        if (turningLeft)
            if (this.gameObject.transform.position.x > LevelBoundary.leftSide)
                transform.Translate(-1 * rot * Vector3.left * Time.deltaTime * leftRightSpeed, Space.World);

        if (turningRight)
            if (this.gameObject.transform.position.x < LevelBoundary.rightSide)
                    transform.Translate(-1 * rot * Vector3.left * Time.deltaTime * leftRightSpeed, Space.World);
    }

    private void handleInput() {
        rot = Input.GetAxis("Horizontal") * Time.deltaTime * 700.0f;

        if (rot < 0) {
            turningLeft = true;
            turningRight = false;
          
            //Debug.Log("LEFT");
        }
        else if(rot > 0) {
            turningLeft = false;
            turningRight = true;
          
            //Debug.Log("RIGHT");
        }
        else {
            turningLeft = false;
            turningRight = false;
            //Debug.Log("no move");
        }
    }

    private void handleInputKey() {
        if (Input.GetKey(KeyCode.A)) {
            rot = -1.0f;
            turningLeft = true;
            turningRight = false;
        }
        else if (Input.GetKey(KeyCode.D)) {
            rot = 1.0f;
            turningLeft = false;
            turningRight = true;
        }
        else {
            rot = 0.0f;
            turningLeft = false;
            turningRight = false;
        }
    }
}
