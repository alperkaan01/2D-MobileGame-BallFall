using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverHandler : MonoBehaviour
{

    [SerializeField] private RingSpawner rs;
    [SerializeField] private PlatformSpawner ps;
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject gameOverDisplayer;
    [SerializeField] private ScoreSystem scoreSystem;
    [SerializeField] private TMP_Text gameOverText;
    [SerializeField] private GameObject trackObject;
    [SerializeField] private Button contButton;
    //[SerializeField] private Destroyer Dest;
    //[SerializeField] private GameObject pivot;
    [SerializeField] private PlayerSelector playerSelector;


    private void Start() {
        player = playerSelector.PlayerPrefabArray[PlayerPrefs.GetInt(Shop.charSelectionKey, 0)];
    }

    private bool stopCourutine = false;

    public bool StopCourutine {
        get{
            return stopCourutine;
        }set {
            stopCourutine = value;
        }

    }


    public IEnumerator EndGame()
    {
        rs.enabled = false;
        ps.enabled = false;

        int finalScore = scoreSystem.EndScore();
        gameOverText.text = "Your Score: " + finalScore.ToString() + "\n" + "Coin Count:" + Coin.coinCount;


        gameOverDisplayer.gameObject.SetActive(true);

        yield return new WaitForSeconds(5f);
        stopCourutine = true;
        trackObject.gameObject.SetActive(false);

    }

    internal void ContinueGame()
    {

        scoreSystem.ContScore();

        Debug.Log("Player: " + player.gameObject.name);
        
        player.gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        //Debug.Log("Velocity" + player.gameObject.GetComponent<Rigidbody2D>().velocity.ToString());


        player.transform.position = trackObject.transform.position + new Vector3(0f, 15f, 0f);
        player.gameObject.SetActive(true);


        rs.enabled = true;
        ps.enabled = true;

        gameOverDisplayer.gameObject.SetActive(false);

        trackObject.gameObject.SetActive(true);
    }


    public void ContinueButton(){
        AdManager.Instance.showAd(this);

        contButton.interactable = false;

        //extractCoin();
    }

    public void PlayAgain(){
        SceneManager.LoadScene(1);

        extractCoin();

        Coin.coinCount = 0;
    }

    public void BackToMainMenu(){
        SceneManager.LoadScene(0);

        extractCoin();

        Coin.coinCount = 0;
    }

    public void extractCoin(){
        int coin = PlayerPrefs.GetInt(Coin.coinKey, 0);

        coin += Coin.coinCount;

        PlayerPrefs.SetInt(Coin.coinKey , coin);
    }

}
