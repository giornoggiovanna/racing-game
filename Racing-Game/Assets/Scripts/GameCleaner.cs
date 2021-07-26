using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameCleaner : MonoBehaviour
{

    public Scene gameScene;

    public void restartGame()
    {
        SceneManager.LoadScene("SampleScene");
    }


}
