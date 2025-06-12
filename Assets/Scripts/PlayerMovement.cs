using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    public float lookatspeed = 5f;
    //The jump velocity of the player
    public float jumpSpeed = 5f;
    //index used for the player to not get out of bounds by moving left to right
    public double indexedDistance = 1;
    //Boolean which determines if the player is moving to the left at the moment
    public bool left = false;
    //Boolean which determines if the player is moving to the right at the moment
    public bool right = false;
    //The position which the player has to reach when moving to the left
    public float leftPositionX;
    //The position which the player has to reach when moving to the right
    public float rightPositionX;
    //Links to other required scripts
    public ObstacleCollision obstacleCollision;
    public AudioSource musicPlayer;
    public Conductor conductor;
    public GameOver gameOver;
    public Canvas canvas;
    public PlayerData playerdata;
    public Animator animator;

    public void OnTriggerEnter(Collider other)
    {
        switch (other.tag)
        {
            case "Coin":
                {
                    Destroy(other.gameObject);
                    playerdata.AddScore(100);
                }
                break;
            case "3xMulti":
                {
                    Destroy(other.gameObject);
                    playerdata.Score3x();
                }
                break;
            case "Heart":
                {
                    Destroy(other.gameObject);
                    playerdata.Heart();
                }
                break;
            default:
                break;
        }
    }

    public void Update()
    {
        //Checking if to see if the player is dead
        //to determine when to stop the movement and music
        if (obstacleCollision != null && obstacleCollision.isAlive == false)
        {
            GetComponent<Rigidbody>().velocity = new Vector3(0, jumpSpeed, 0);
            transform.Rotate(90.0f, 0.0f, 0.0f);
            musicPlayer.Stop();
            enabled = false;
            gameOver.Setup();
            playerdata.ResetSc();
            //canvas.gameObject.SetActive(false);

        }

        float horizontalInput = Input.GetAxis("Horizontal");
        //Normal moving with A and D
        //transform.Translate(horizontalInput * Time.deltaTime * moveSpeed, 0, 0);

        //Left side moving input
        if(Input.GetKeyDown(KeyCode.A) && indexedDistance != 0 && right == false)
        {
            leftPositionX = transform.position.x - 3f;
            indexedDistance--;
            left = true;
        }

        //Movement to the left side
        if(left)
        {
            float step = 50 * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(leftPositionX,transform.position.y,transform.position.z), step);
        }

        //Stopping the movement to the left side when the desired position
        //has been reached
        if(transform.position.x == leftPositionX || transform.position.x == 0f)
        {
            left = false;
        }


        //Right side moving input
        if (Input.GetKeyDown(KeyCode.D) && indexedDistance != 2 && left == false)
        {
            rightPositionX = transform.position.x + 3f;
            right = true;
            indexedDistance++;
        }

        //Movement to the right side
        if (right)
        {
            float step = 50 * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(rightPositionX, transform.position.y, transform.position.z), step);
        }

        //Stopping the movement to the right side when the desired position
        //has been reached
        if (transform.position.x == rightPositionX)
        {
            right = false;
        }

        if (transform.position.y < 1.9f && animator != null)
        {
            animator.SetBool("isJumping", false);
        }

        //Jump
        if (Input.GetKeyDown(KeyCode.Space) && transform.position.y < 1.9f)
        {

            GetComponent<Rigidbody>().velocity = new Vector3(0, jumpSpeed, 0);
            animator.SetBool("isJumping", true);
        }

        //Movement forward dependent on beats calculated by the conductor class
        if(conductor != null)
        transform.position = new Vector3(transform.position.x, transform.position.y, conductor.songPositionInBeats * 2 + -401.71f);
    }
}