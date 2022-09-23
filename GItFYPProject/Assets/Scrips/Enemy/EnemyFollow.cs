using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class EnemyFollow : MonoBehaviour
{

    public Transform Player;
    public GameObject Enemy;

    [SerializeField]
    int MoveSpeed = 4;
    int MaxDist = 5;
    int MinDist = 1;


    AudioSource audioSource;

    /*Enemy random direction on collison*/

    public Vector3 direction;

    void Start()
    {
        direction = (new Vector3(Random.Range(-1.0f, 1.0f), Random.Range(-1.0f, 1.0f), 0.0f)).normalized;
        transform.Rotate(direction);
    }

    void Update()
    {
        transform.LookAt(Player);

        if (Vector3.Distance(transform.position, Player.position) >= MinDist)
        {

            transform.position += transform.forward * MoveSpeed * Time.deltaTime;



            if (Vector3.Distance(transform.position, Player.position) <= MaxDist)
            {
                //Here Call any function U want Like Shoot at here or something
                Application.Quit();
                Debug.Log("enemy hits player");



                //the audio attached to the enemy is played (jumpscare) or attach the jump scare to a collider trigger in bad end room
                audioSource.Play();
                /*Enemy.SetActive(false);*/ //once player sent away enemy stopped
            }

        }




    }

    /*Enemy random direction on collison*/


    void OnCollisionEnter(Collision col)
    {

        if (col.gameObject.tag == "Enemy")
        {
            direction = col.contacts[0].normal;
            direction = Quaternion.AngleAxis(Random.Range(-70.0f, 70.0f), Vector3.forward) * direction;
            transform.rotation = Quaternion.LookRotation(direction);
        }



    }

}