using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    [SerializeField] private TMP_Text highScoreText;


    private void Start() {
        highScoreText.text = "High Score: " + PlayerPrefs.GetInt(ScoreSystem.HighScoreKey, 0).ToString();

        highScoreText.text += "\n" + "Total Coin: " + PlayerPrefs.GetInt(Coin.coinKey, 0).ToString();
    }

    public void Play(){
        SceneManager.LoadScene(1);
    }

    public void goToShop(){
        SceneManager.LoadScene(2);
    }
}
