using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyer : MonoBehaviour
{

    [SerializeField] private GameOverHandler goh;

    private Vector2 lastPosition;

    public Vector2 LastPosition { 
        get{
            return lastPosition;
        }
    }
    private void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.CompareTag("Player")) {
            //Destroy(other.gameObject);

            StartCoroutine(goh.EndGame());
            //Debug.Log("coroutine is Started");
            //goh.EndGame();

            //StartCoroutine(waiter());
            if(goh.StopCourutine) {
                StopCoroutine(goh.EndGame());
                //Debug.Log("coroutine is stopped");
                goh.StopCourutine = false;
            }
            //StopCoroutine(waiter());
            
            StopCoroutine(goh.EndGame());
            other.gameObject.SetActive(false);
            lastPosition = other.gameObject.transform.position;

        }else if(other.gameObject.CompareTag("obstacle")) {
            //Debug.Log("Obstacle is hit");
            Destroy(other.gameObject);
        }
        
    }

    private void OnTriggerEnter2D(Collider2D other) {
        Destroy(other.gameObject);
    }

    IEnumerator waiter() {
        yield return new WaitForSeconds(6f);
    }
}
