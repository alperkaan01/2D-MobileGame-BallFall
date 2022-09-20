using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bounds : MonoBehaviour
{

    [SerializeField] private GameObject player;
    [SerializeField] private PlayerSelector playerSelector;
    
    private Rigidbody2D playerRb;


    void Start()
    {

        player = playerSelector.PlayerPrefabArray[PlayerPrefs.GetInt(Shop.charSelectionKey, 0)];
        
        playerRb = player.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.CompareTag("Player")){

            Debug.Log("Player hit to the boundaries");

            Vector2 playerVelocity = -playerRb.velocity;
            playerRb.velocity = Vector2.zero;
            playerRb.velocity = playerVelocity;
        }
    }
}
