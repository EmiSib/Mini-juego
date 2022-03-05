/*
Emilio Sibaja Villarreal
Joshua Rubén Amaya Camilo


Here we make our second type of enemies (skeletons) move right and left forever

04/03/2022
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveMovement : MonoBehaviour
{
    public float move = 1f;
    public float rest;
    public int moves = 0;
    public int maxmoves;

    // Start is called before the first frame update
    void Start()
    {
        maxmoves = Random.Range(1, 10); //The maximum moves for the enemy at random between 1, 10
        rest = Random.Range(0.1f, 0.4f); //The time it waits for the next move at random between 0.1 and 0.4 seconds
        move = Random.Range(0, 1); // Direction of the enemy. If it is at one it moves to the right, if it's at 0 it moves to the left
        if (move == 0)
        {
            move = -1f;
        }
        StartCoroutine("mover");

    }

    IEnumerator mover()
    {
        while (true) //Infinite loop for enemy movement
        {

            transform.position = new Vector3(move + transform.position.x, transform.parent.position.y, 0);

            if (moves >= maxmoves || transform.position.x <= -4 || transform.position.x >= 4) //The enemy changes direction if it gets to the border of the screen
            {
                moves = 0;
                move = move * -1f;
            }
            else
            {
                moves++;
            }

            yield return new WaitForSeconds(rest); //Waits to make a new movement
        }
    }
}
