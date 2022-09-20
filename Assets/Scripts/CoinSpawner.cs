using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSpawner : MonoBehaviour
{


    [SerializeField] private GameObject coinPrefab;
    [SerializeField] private float secBetweenCoins = 1.5f;


    private float timer = 3f;




    // Start is called before the first frame update
    void Start()
    {
        //PlayerPrefs.SetInt(Coin.coinKey, 0); To reset the coin amount in game
    }

    // Update is called once per frame
    void Update()
    {

        timer -= Time.deltaTime;

        if(timer <= 0){
            
            SpawnCoin();

            timer += secBetweenCoins;

        }
    }

    private void SpawnCoin(){
        Vector2 spawnPoint = Vector2.zero;

        spawnPoint.x = Random.value;
        spawnPoint.y = 0f;

        Vector3 worldPos = Camera.main.ViewportToWorldPoint(spawnPoint);
        worldPos.z = 0f;


        GameObject coinInstance = Instantiate(coinPrefab, worldPos, Quaternion.identity);

    }


}
