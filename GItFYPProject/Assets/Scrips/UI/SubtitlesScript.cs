using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SubtitlesScript : MonoBehaviour
{

    public GameObject textBox;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(TheSequence());



    }


    IEnumerator TheSequence()
    {

        //Game Intro Subs

        textBox.GetComponent<Text>().text = "Hey! Congrats on getting the big assignment, the company is set for new records by next quarter thanks to you.";
        yield return new WaitForSeconds(6);

        textBox.GetComponent<Text>().text = "As a thanks the company is letting you use the brand new self driving car. ";
        yield return new WaitForSeconds(3);

        textBox.GetComponent<Text>().text = "We've been working on this car and it has all the bells and whistles….";
        yield return new WaitForSeconds(3);

        textBox.GetComponent<Text>().text = "once we get through the human trials. I assure you it's safe enough to test.";
        yield return new WaitForSeconds(4);

        textBox.GetComponent<Text>().text = "The car currently has the most simple low level operating system on board so you will be fine. It will try to get you home safe and sound. The car is set to take you straight home as quickly as possible.";
        yield return new WaitForSeconds(9);

        textBox.GetComponent<Text>().text = "If you do get in a spot of trouble then I'm legally obligated to let you know that there is an emergency break on the bottom right but unfortunately no one told Dale to hook it up, same goes for the steering wheel. haha (I'm sure it's no biggie)...";
        yield return new WaitForSeconds(11);

        textBox.GetComponent<Text>().text = "The developers have quickly uploaded a bare bones speech recognition system onboard. So in an emergency you can just tell the car to turn in a direction or whatever.";
        yield return new WaitForSeconds(7);

        textBox.GetComponent<Text>().text = "I'm sure you will figure it out when it comes to it…IF it comes to it.";
        yield return new WaitForSeconds(4);

        textBox.GetComponent<Text>().text = "I'm sure you will be fine, see you Monday for the big presentation and congrats on being the first to test this thing out in real life.";
        yield return new WaitForSeconds(5);

        textBox.GetComponent<Text>().text = "Bye!";
        yield return new WaitForSeconds(2);

        textBox.GetComponent<Text>().text = "";
        yield return new WaitForSeconds(2);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
