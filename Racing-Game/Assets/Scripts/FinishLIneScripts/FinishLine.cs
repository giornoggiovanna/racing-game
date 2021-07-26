using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FinishLine : MonoBehaviour
{

    //Public Components/Gameobjects
    public Text lapText;
    public Text winText;

    //Public Variables
    public bool hasWon;

    //Private Components/Gameobjects

    //Private Variables
    int lapNumber;
    float lapCooldown;

    void Start()
    {
        //Setting the variables to their required value at the beginning
        lapNumber = 1;
        hasWon = false;
        winText.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        //Setting the cooldown timer
        lapCooldown += Time.deltaTime;

        //Checking the cooldown, for devs only
        print(lapCooldown);

        //Checking to see if the player has won
        if (lapNumber >= 3)
        {
            gameWin();
        }

    }

    //Checking to see if the player's front sensor has collided with the finish linle
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "FrontSensor" && lapCooldown >= 10)
        {
            //Resetting the lap cooldown, and adding another lap
            lapCooldown = 0;
            lapNumber++;
            print(lapNumber);
        }
    }

    //Telling the code what to do when the player has won
    public void gameWin()
    {
        hasWon = true;
        winText.enabled = true;
    }

}
