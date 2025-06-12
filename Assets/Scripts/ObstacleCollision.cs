using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ObstacleCollision : MonoBehaviour
{
    public Animator transition;
    public float transitionTime =1f;
    // A flag to check if the player is still alive
    public bool isAlive = true;
    //How many lives the player has
    public int lives;
    public ShakeFollow shake;
    //The link to the music source
    public AudioSource musicPlayer;
    public PlayerData playerData;

    private void Start()
    {
        lives = 3;
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Check if the player has collided with a wall
        if (collision.gameObject.CompareTag("Wall"))
        {
            // Check if the collision normal is pointing to the -z axis
            if (collision.contacts[0].normal.z < 0)
            {
                //Pauses the music whe an object is hit, could be changed to sound effect or smth
                musicPlayer.Pause();
                //Checking to see if the player's status should be changed to dead
                if (lives == 1)
                {
                    shake.start = true;
                    isAlive = false;
                    lives--;
                }
                else
                {
                    // The player hit the -z side of the object
                    shake.start = true;
                    lives--;
                }
                //Moves the object out of the way
                collision.gameObject.transform.position = new Vector3(0, 2f, 0);

            }
        }


        if(collision.gameObject.CompareTag("End"))
        {
            if (collision.contacts[0].normal.z < 0)
            {
                VariableSave.PlayerScore = PlayerData.PlayerScore;
                StartCoroutine(LoadLevel("BossFight"));
            }
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        //Unpauses the music when the object is moved out of the way
        if(collision.gameObject.CompareTag("Wall"))
        {
            musicPlayer.UnPause();
            
        }
    }

    IEnumerator LoadLevel (string level){
        //Play animation
        transition.SetTrigger("Start");

        //wait
        yield return new WaitForSeconds(transitionTime);
        //Load Scene
        SceneManager.LoadScene(level);
    }
}
