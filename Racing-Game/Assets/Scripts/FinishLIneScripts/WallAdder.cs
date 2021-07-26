using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallAdder : MonoBehaviour
{
    //Public Components/Gameobjects
    public BoxCollider finishLineWall;

    //Checking to see if the player's back sensor has collided with the trigger
    private void OnTriggerEnter(Collider other) {
        if (other.tag == "BackSensor")
        {
            //Adding back the wall
            finishLineWall.enabled = true;
        }
    }
}
