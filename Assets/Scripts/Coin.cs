using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{

    [SerializeField] private float ofsetAmount = 0.5f;
    public const string coinKey = "coinKey";

    public static int coinCount = 0;
   
    private void Update() {
        //Debug.Log(coinCount);
    }


    private void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("Player")) {
            coinCount += 1;

            Destroy(this.gameObject);
        }else if(other.CompareTag("obstacle") || other.CompareTag("ring")){
            this.gameObject.transform.position = new Vector3(this.gameObject.transform.position.x,
            this.gameObject.transform.position.y - ofsetAmount , 
            this.gameObject.transform.position.z);
        }
    }

    
}
