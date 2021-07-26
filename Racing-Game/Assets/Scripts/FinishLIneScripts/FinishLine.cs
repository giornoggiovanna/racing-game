using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FinishLine : MonoBehaviour
{

    //Public Components/Gameobjects
    public Text _lapText;
    public Text _winText;
    public Text _raceTimeText;
    public Text _highscore;
    public Button _restartButton;
    public Image _restartButtonImage;

    //Public Variables
    public bool _hasWon;

    //Private Components/Gameobjects

    //Private Variables
    public int _lapNumber;
    float _lapCooldown;
    float _raceTime;
    float _lastRaceTime;

    void Start()
    {
        //Setting the variables to their required value at the beginning
        
        _hasWon = false;
        _winText.enabled = false;
        
        _raceTime = 0;
        _restartButton.enabled = false;
        _restartButtonImage.gameObject.SetActive(false);


        _highscore.text = $"Highscore: {PlayerPrefs.GetFloat("Highscore")}";
    }

    // Update is called once per frame
    void Update()
    {
        //Setting the cooldown timer
        

        //Checking the cooldown, for devs only
        print(_lapCooldown);

        _lapText.text = $"Lap {_lapNumber}";
        _raceTimeText.text = $"Time {_raceTime}";

        //Checking to see if the player has won
        if (_lapNumber >= 4)
        {
            gameWin();
            _lapText.text = $"Finish";
        }

        if(_lapNumber != 0 && !_hasWon)
        {
            _raceTime += Time.deltaTime;
            _lapCooldown += Time.deltaTime;
        }

    }

    //Checking to see if the player's front sensor has collided with the finish line
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "FrontSensor" && _lapCooldown >= 10)
        {
            //Resetting the lap cooldown, and adding another lap
            _lapCooldown = 0;
            _lapNumber++;
            print(_lapNumber);
            
        }else if (_lapNumber == 0)
        {
            
            
            _lapNumber++;
        }else return;
    }

    //Telling the code what to do when the player has won
    public void gameWin()
    {
        _hasWon = true;
        _winText.enabled = true;
        _restartButton.enabled = true;
        _restartButtonImage.gameObject.SetActive(true);

        _lastRaceTime = _raceTime;

        PlayerPrefs.SetFloat("Highscore", _lastRaceTime);

        if (PlayerPrefs.GetFloat("Highscore") > _lastRaceTime)
        {
           
        }else return;
    }

}
