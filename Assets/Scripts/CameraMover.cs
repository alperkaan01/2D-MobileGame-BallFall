using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMover : MonoBehaviour
{

    [SerializeField] private float moveSpeed;
    [SerializeField] private float speedIncrementer;
    [SerializeField] private float maxSpeed;


    public float MaxSpeed {
        get {
            return maxSpeed;
        }set {
            maxSpeed = value;
        }
    }
    

    private void Update() {
        if(moveSpeed < maxSpeed) {
            moveSpeed += Time.deltaTime * speedIncrementer;
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        this.GetComponent<Rigidbody2D>().velocity = Vector2.down * moveSpeed * Time.deltaTime;
    }
}
