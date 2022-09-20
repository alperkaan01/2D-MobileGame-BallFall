using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreSystem : MonoBehaviour
{

    [SerializeField] private TMP_Text scoreText;
    [SerializeField] private float scoreMultiplier = 1f;

    private float score;
    private bool contCount = true;
    
    public const string HighScoreKey = "HighScore";


    public float Score {  //use property to access score variable outside of the class safely
        get{
            return score;
        }

        set{   
            score = score + value;
        } 
        
    }


    // Start is called before the first frame update
    void Start()
    {
        score = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        if(!contCount){
            return;
        }

        score += Time.deltaTime * scoreMultiplier;

        scoreText.text = Mathf.FloorToInt(score).ToString();
    }


    public int EndScore(){
        contCount = false;
        scoreText.text = string.Empty;

        return Mathf.FloorToInt(score);
    }

    public void ContScore(){
        contCount = true;
    }

    //onDestroy += highScore system
    private void OnDestroy() {
        int highScore = PlayerPrefs.GetInt(HighScoreKey , 0);

        if(score > highScore) {
            highScore = Mathf.FloorToInt(score);
            PlayerPrefs.SetInt(HighScoreKey, highScore);
        }
    }

}
