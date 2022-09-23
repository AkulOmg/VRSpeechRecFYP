using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCollision : MonoBehaviour
{



    void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.tag == "Player")
        {

            //quit will only work when built
            Application.Quit();
            Debug.Log("enemy col script");

            //For testing the Enemy will simply teleport you to a safe location where the game will seem over.


        }

    }


}