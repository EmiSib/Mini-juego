/*
Emilio Sibaja Villarreal
Joshua Rubén Amaya Camilo


Here is where we get our player move horizontaly.
We also call another script (tileMan) for vertical movement, where the points are added (and appear on the screen) 
and where it restarts if you touch an enemy or win if you get to the finish line.

04/03/2022
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class playerController : MonoBehaviour
{
    public float MoveAmount;
    public float MoveYAmount;

    public GameObject mundo;

    [SerializeField] int points = 0;

    public TMP_Text pointsText;

    public GameObject win;


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.D)) //Move to the right with the "D" key
            MoveRight();
        if (Input.GetKeyDown(KeyCode.A)) //Move to the left with the "A" key
            MoveLeft();


        if (Input.GetKeyDown(KeyCode.W)) //Move to the world down with the "W" key except our player)(
        {
            mundo.BroadcastMessage("MoveDown", MoveYAmount);
            points++; // Point are added when moving up
        }


        if (Input.GetKeyDown(KeyCode.S)) //Move to the world up with the "S" key (except our player)
        {
            mundo.BroadcastMessage("MoveUp", MoveYAmount);
            points--; // Point are substracted when moving down
        }

        pointsText.text = "Score: " + points; // The score is updated with the player's movement and it's shown on the screen


    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "enemy") //When colliding with an enemy
        {

            GetDed(); //Function to restart the game

        }

        if (other.gameObject.tag == "finish") //When colliding with the finish line 
        {
            pointsText.text = "Score: " + (points + 101); //Adds a 101 points to the player's score and shows it on the screen
            Finish(); //Function to end the game
        }
    }


    void MoveRight()
    {
        if (transform.position.x < 4) //Restricts player from leaving the screen
            transform.position = new Vector3(transform.position.x + MoveAmount, transform.position.y, transform.position.z); //Player's right movement
    }

    void MoveLeft()
    {
        if (transform.position.x > -4) //Restricts player from leaving the screen
            transform.position = new Vector3(transform.position.x - MoveAmount, transform.position.y, transform.position.z); //Player's left movement
    }

    void GetDed()
    {
        SceneManager.LoadScene(0); //Restarts game
    }


    void Finish()
    {
        Destroy(GameObject.FindWithTag("Player")); //Player is banished when winning the game
        win.SetActive(true); //A winning message appears 
    }
}


