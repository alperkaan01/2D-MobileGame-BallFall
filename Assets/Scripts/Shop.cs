using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

[System.Serializable]
public struct Character {
    public string name;
    public int price;
    public bool isUnlocked;
}


public class Shop : MonoBehaviour
{

    public const string charSelectionKey = "SelectedCharacter";
    
    public GameObject[] players;
    public Character[] charactersForBuySystem;
    
    [SerializeField] private int currentIndex = 0;
    [SerializeField] private TMP_Text totalCoinText;
    [SerializeField] private TMP_Text unlockPriceText;
    [SerializeField] private Button chooseButton;
    [SerializeField] private Button unlockButton;
    

    // Start is called before the first frame update
    void Start()
    {
        
        chooseCharacter();
        setCharacterLock();
        UpdateUI();
    }


    private void chooseCharacter(){
        currentIndex = PlayerPrefs.GetInt(charSelectionKey, 0);

        foreach(GameObject player in players){
            player.gameObject.SetActive(false);
        }

        players[currentIndex].gameObject.SetActive(true);
    }


    private void setCharacterLock(){
        for(int i = 0 ; i < charactersForBuySystem.Length ; i++){
            if(charactersForBuySystem[i].price == 0){
                charactersForBuySystem[i].isUnlocked = true;
            }else {
                charactersForBuySystem[i].isUnlocked = PlayerPrefs.GetInt(charactersForBuySystem[i].name, 0) == 0 ? false : true;
            }
        }
    }

    public void NextButton(){
        
        players[currentIndex].gameObject.SetActive(false);

        currentIndex++;

        if(currentIndex == players.Length) {
            currentIndex = 0;
        }

        players[currentIndex].gameObject.SetActive(true);

        if(charactersForBuySystem[currentIndex].isUnlocked){
            PlayerPrefs.SetInt( charSelectionKey, currentIndex);
            chooseButton.interactable = true;
        }

        UpdateUI();

    }

    public void PrevButton(){

        players[currentIndex].gameObject.SetActive(false);

        currentIndex--;

        if(currentIndex < 0) {
            currentIndex = players.Length - 1;
        }

        players[currentIndex].gameObject.SetActive(true);

        if(charactersForBuySystem[currentIndex].isUnlocked){
            PlayerPrefs.SetInt( charSelectionKey, currentIndex);
            chooseButton.interactable = true;
        }
        

        UpdateUI();

    }

    public void ChooseButton(){
        SceneManager.LoadScene(0);
    }

    public void backToHome(){
        SceneManager.LoadScene(0);
    }

    public void UpdateUI(){

        totalCoinText.text = ": " + PlayerPrefs.GetInt(Coin.coinKey, 0).ToString();
        unlockPriceText.text = "Buy - " + charactersForBuySystem[currentIndex].price.ToString();


        if(charactersForBuySystem[currentIndex].isUnlocked) {
            unlockButton.gameObject.SetActive(false);
            //unlockButton.interactable = false;
            //chooseButton.interactable = true;
        }else {
            if(PlayerPrefs.GetInt(Coin.coinKey, 0) < charactersForBuySystem[currentIndex].price){
                unlockButton.gameObject.SetActive(true);
                unlockButton.interactable = false;
                //chooseButton.interactable = false;
            }else {
                unlockButton.gameObject.SetActive(true);
                unlockButton.interactable = true;
            }
        }
    }

    public void buyButton(){


        if(PlayerPrefs.GetInt(Coin.coinKey, 0) >= charactersForBuySystem[currentIndex].price){
            PlayerPrefs.SetInt(Coin.coinKey, PlayerPrefs.GetInt(Coin.coinKey, 0) - charactersForBuySystem[currentIndex].price);
            PlayerPrefs.SetInt(charactersForBuySystem[currentIndex].name, 1);
            PlayerPrefs.SetInt(charSelectionKey, currentIndex);
            charactersForBuySystem[currentIndex].isUnlocked = true;
            UpdateUI(); 
        }
    }
}