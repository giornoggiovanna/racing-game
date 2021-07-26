using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallRemover : MonoBehaviour
{
    //Public Components/Gameobjects
    public BoxCollider _finishLineWall;

    //Checking to see if the player's front sensor has collided with the trigger
    private void OnTriggerEnter(Collider other) {
        if (other.tag == "FrontSensor")
        {
            //Removing the wall
            _finishLineWall.enabled = false;
        }
    }
}
