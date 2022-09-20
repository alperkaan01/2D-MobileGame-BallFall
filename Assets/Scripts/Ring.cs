using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ring : MonoBehaviour
{

    [SerializeField] private float ofsetAmount;

    private Material mat;

    public Color[] colArray;
    //[SerializeField] private Renderer myObject;
    //[SerializeField] private TrailRenderer myTrailRend;

    private void Start() {
        mat = GetComponent<Renderer>().material;
        int randomNumber = Random.Range(0, colArray.Length);
        //Debug.Log(randomNumber);
        mat.color = colArray[randomNumber];
    }

    private void Update() {
        //Debug.Log(mat.color.ToString());
    }


    private void OnTriggerEnter2D(Collider2D other) {
        //Debug.Log(other.gameObject.tag);
        if(other.CompareTag("Player")) {
            
            Color thisColor = mat.color;

            //Debug.Log(thisColor);
            //Debug.Log("1st " + other.gameObject.GetComponent<Renderer>().material.color.ToString());
            
            //myObject.material.color = Color.white;
            //myObject.material.color = thisColor;
            //myTrailRend.material.color = thisColor;

            other.gameObject.GetComponent<Renderer>().material.color = thisColor;
            other.gameObject.GetComponent<TrailRenderer>().material.color = thisColor;


            //Debug.Log("2nd " + other.gameObject.GetComponent<Renderer>().material.color.ToString());

        }else if(other.CompareTag("obstacle")){
            //obstacle is triggered

            Debug.Log("Obstacle is triggered");

            this.gameObject.transform.position = new Vector3(
                Random.Range(this.gameObject.transform.position.x - ofsetAmount, this.gameObject.transform.position.x + ofsetAmount) ,
            this.gameObject.transform.position.y - ofsetAmount , 
            this.gameObject.transform.position.z);
        }
    }

}

//434343
