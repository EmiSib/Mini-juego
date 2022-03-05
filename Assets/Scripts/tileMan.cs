/*
Emilio Sibaja Villarreal
Joshua Rubén Amaya Camilo


Here we give our enemies a place to appear (one for each tile) and move our world up and down.

04/03/2022
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class tileMan : MonoBehaviour
{
    public GameObject[] enemies;

    private void Start()
    {
        Instantiate(enemies[Random.Range(0, enemies.Length)], new Vector3(Random.Range(-3, 3), transform.position.y, 0), Quaternion.identity, transform); //We place our Enemies in a random position of their tile between -3 and 3
    }

    public void MoveDown(float ammount)
    {
        transform.position = new Vector3(transform.position.x, transform.position.y - ammount, transform.position.z); //Moves the whole world down so our player goes up
    }

    public void MoveUp(float ammount)
    {

        transform.position = new Vector3(transform.position.x, transform.position.y + ammount, transform.position.z); //Moves the whole world up so our player goes down
    }
}
