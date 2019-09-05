using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RabbitScript : MonoBehaviour
{

    int health;
    int hunger;
    int energy;

public GameObject rabbitHealthbar;
int height = 1;

    // Start is called before the first frame update
    void Start()
    {
        health = 100;
        hunger = 100;
        energy = 100;

        Instantiate(rabbitHealthbar,this.transform.position + Vector3.up * height, Quaternion.identity);
         Debug.DrawLine(Vector3.zero, new Vector3(5, 0, 0), Color.red, 100.5f);
        //StartCoroutine(Move());
        StartCoroutine(WaitAndMove(3));
    }

    // Update is called once per frame
    void Update()
    {
        WaitAndMove(3);
    }

 IEnumerator Move()
    {
        int moveDistance = 1;

        print(Time.time);
        yield return new WaitForSeconds(3);
        this.transform.Translate(new Vector3(1, 0, 0));
        print(Time.time);

        // this.transform.Translate(new Vector3.Lerp(this.transform.position, this.transform.position + Vector3.right * moveDistance, 1.0f));
        // print(Time.time);
        
        // transform.position=Vector3.Lerp(this.transform.position, this.transform.position + Vector3.right* moveDistance,Time.time-startTime);

        
    }

    IEnumerator WaitAndMove(float delayTime){
     yield return new WaitForSeconds(delayTime); // start at time X
     float startTime=Time.time; // Time.time contains current frame time, so remember starting point
     //while(Time.time-startTime<=1){ // until one second passed
         //transform.position=Vector3.Lerp(this.transform.position, this.transform.position + Vector3.right,Time.time-startTime); // lerp from A to B in one second
         this.transform.Translate(new Vector3(1, 0, 0));
         yield return 1; // wait for next frame
     //}
    }
    


    void SearchForFood()
    {
//Rotate random direction for second

//if food isnt in front of fov, turn again, if not remain on course

    }

    void Sleep()
    {


    }

    void Eat()
    {


    }


    void Mate()
    {

        
    }

} // Class
