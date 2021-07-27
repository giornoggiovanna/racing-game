using UnityEngine;
using UnityEngine.UI;

public class FinishLine : MonoBehaviour
{

    [Header("Components")]
    [SerializeField] private Text lapText;
    [SerializeField] private Text winText;
    [SerializeField] private Text raceTimeText;
    [SerializeField] private Text highScore;
    [SerializeField] private Button restartButton;
    [SerializeField] private Image restartButtonImage;

    [HideInInspector]
    public bool hasWon;

    private int _lapNumber;
    private float _lapCooldown;
    private float _raceTime;
    private float _lastRaceTime;

    private void Start()
    {
        SetComponents();
    }

    private void SetComponents()
    {
        winText.enabled = false;
        restartButton.enabled = false;
        restartButtonImage.gameObject.SetActive(false);

        highScore.text = "HighScore: " + PlayerPrefs.GetFloat("HighScore");
    }

    private void Update()
    {
        UpdateText();
        CheckHasWon();
        UpdateTimers();
    }

    private void UpdateTimers()
    {
        if (_lapNumber == 0 || hasWon) return;

        _raceTime += Time.deltaTime;
        _lapCooldown += Time.deltaTime;
    }

    private void UpdateText()
    {
        lapText.text = "Lap " + _lapNumber;
        raceTimeText.text = "Time: " + _raceTime;
    }

    private void CheckHasWon()
    {
        if (_lapNumber < 4) return;

        GameWin();
        lapText.text = "Finish";
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("FrontSensor") && _lapCooldown >= 10)
        {
            CompleteLap();
        }
        else if (_lapNumber == 0)
        {
            _lapNumber++;
        }
    }

    private void CompleteLap()
    {
        _lapCooldown = 0;
        _lapNumber++;
    }

    private void GameWin()
    {
        hasWon = true;
        winText.enabled = true;
        restartButton.enabled = true;
        restartButtonImage.gameObject.SetActive(true);

        _lastRaceTime = _raceTime;
        

        if (PlayerPrefs.GetFloat("HighScore") > _lastRaceTime | PlayerPrefs.GetFloat("Highscore") == 0f)
        {
            PlayerPrefs.SetFloat("HighScore", _lastRaceTime);
        }
    }
}