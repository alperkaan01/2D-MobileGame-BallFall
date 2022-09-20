using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{

    [SerializeField] private Ring ringScript;
    // Start is called before the first frame update
    //[SerializeField] private float platformScaleIncrementer;
    //[SerializeField] private float maxPlatformScale;
    
    private Material mat;

    void Start()
    {

        mat = GetComponent<Renderer>().material;

        int randomNumber = Random.Range(0, ringScript.colArray.Length);
        //Debug.Log(randomNumber);
        mat.color = ringScript.colArray[randomNumber];


        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.CompareTag("Player")) {
            GameObject player = other.gameObject;
            Renderer rend = player.GetComponent<Renderer>();
            //Debug.Log(rend.material.color.ToString());

            if(rend.material.color == this.GetComponent<Renderer>().material.color) {
                //Debug.Log("They are same!!!");
                Destroy(this.gameObject); //Player can Continue to its move without any velocity reduction
            }
        }
    }
}
