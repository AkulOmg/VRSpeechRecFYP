using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Windows.Speech;


public class VoiceMovement : SoundTracker
{
    // Start is called before the first frame update
    private KeywordRecognizer keywordRecognizer;
    public Dictionary<string, Action> actions = new Dictionary<string, Action>();

    public float movementSpeed = 8.0f;




    //Continues forward movement code eddited from unity doc
    Rigidbody m_Rigidbody;
    float m_Speed;





    public void Start()
    {

        /*actions.Clear();*/

        //continues forward movement (edited)
        //Fetch the Rigidbody component you attach from your GameObject
        m_Rigidbody = GetComponent<Rigidbody>();
        //Set the speed of the GameObject
        m_Speed = 10.0f;


        //what will be stored to listen for
        actions.Add("turn right", TurnRight);
        actions.Add("turn left", TurnLeft);

        actions.Add("bare right", BareRight);
        actions.Add("bare left", BareLeft);


        actions.Add("forward", Forward);
        actions.Add("back", Back);

        //left/right that also works
        actions.Add("right", Right);
        actions.Add("left", Left);

        /* //Experimental words to test
         actions.Add("stop", stop);
         actions.Add("help", Help);
         actions.Add("slow", SlowDown);
         actions.Add("speed", SpeedUp);
         actions.Add("reboot", Reboot);
         actions.Add("restart", Restart);*/

        //must go after actions.add
        keywordRecognizer = new KeywordRecognizer(actions.Keys.ToArray());
        keywordRecognizer.OnPhraseRecognized += RecognizedSpeech;
        keywordRecognizer.Start(); //knows to start it listening





    }



    void Update()
    {
        m_Rigidbody.velocity = transform.forward * m_Speed;

    }


    //Smooth Rotation
    IEnumerator RotateDirection(Vector3 byAngles, float inTime)
    {
        var fromAngle = transform.rotation;
        var toAngle = Quaternion.Euler(transform.eulerAngles + byAngles);
        for (var t = 0f; t < 1; t += Time.deltaTime / inTime)
        {
            transform.rotation = Quaternion.Slerp(fromAngle, toAngle, t);
            yield return null;
        }
    }


    private void RecognizedSpeech(PhraseRecognizedEventArgs speech)
    {
        Debug.Log(speech.text);//lets us know what was picked up
        actions[speech.text].Invoke();
    }



    private void Forward()
    {

        transform.Translate(0, 0, 0);
        transform.position += transform.forward * Time.deltaTime * movementSpeed;

    }




    private void TurnRight()
    {
        transform.Rotate(0, 90, 0);
        //Smooth rotate right
        /*StartCoroutine(RotateDirection(Vector3.right * 90, 0.8f));*/

    }

    private void TurnLeft()
    {
        transform.Rotate(0, -90, 0);

        //Smooth rotate right
        /*StartCoroutine(RotateDirection(Vector3.left * -90, 0.8f));*/


    }

    private void Right()
    {
        transform.Rotate(0, 90, 0);

        //Smooth rotate right
        /*StartCoroutine(RotateDirection(Vector3.up * 90, 0.8f));*/

    }

    private void Left()
    {
        transform.Rotate(0, -90, 0);

        //Smooth rotate Left
        /*StartCoroutine(RotateDirection(Vector3.down * -90, 0.8f));*/


    }



    private void Back()
    {

        transform.Translate(-20, 0, 0);
        transform.position += transform.forward * Time.deltaTime * movementSpeed;
    }


    private void BareLeft()
    {
        transform.Rotate(0, -40, 0);

        //Smooth rotate Slight Left
        /*StartCoroutine(RotateDirection(Vector3.left * -40, 0.8f));*/

    }



    private void BareRight()
    {
        transform.Rotate(0, 40, 0);

        //Smooth rotate Slight Right
        /*StartCoroutine(RotateDirection(Vector3.right * 40, 0.8f));*/


    }





    /* //Experimental words//

     private void stop()
     {


         soundFX[0].Play();
         //when triggeres should spawn and play the clip added in inspector

     }


     *//*private void SlowDown()
     {

     }



     private void SpeedUp()
     {

     }*//*



     private void Help()//maybe remove private and try
     {

         soundFX[3].Play();

         //Should trigger a audio file 
     }



     private void Reboot()
     {
         soundFX[2].Play();
         //Should trigger a audio file " Sorry I am unable to do that for you"
     }


     private void Restart()
     {
         soundFX[1].Play();
         //Should trigger a audio file " Sorry I will not do that for you"
     }
 */







    // Words/phrases to use to development

    /*private void Back()
    {
        transform.Translate(-1, 0, 0);
    }

    private void Up()
    {
        transform.Translate(0, 1, 0);
    }

    private void Down()
    {
        transform.Translate(0, -1, 0);
    }*/

}
