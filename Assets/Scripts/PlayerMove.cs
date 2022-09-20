using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class PlayerMove : MonoBehaviour
{


    [SerializeField] private float forceMagnitude;
    [SerializeField] private float forceForPlayer;
    [SerializeField] private Ring ringScript;

    private Rigidbody2D playerBody;
    private Camera mainCam;
    private Vector2 direction;


    private void Awake() {
        mainCam = Camera.main;
    }

    // Start is called before the first frame update
    void Start()
    {
        playerBody = GetComponent<Rigidbody2D>();

        int random = Random.Range(0, ringScript.colArray.Length);

        this.GetComponent<Renderer>().material.color = ringScript.colArray[random];
        this.GetComponent<TrailRenderer>().material.color = this.GetComponent<Renderer>().material.color;
    }

    // Update is called once per frame
    void Update()
    {
        
        if(playerBody == null) return;

        getPosition();
    }

    private void FixedUpdate() {
        
        //playerBody.velocity = Vector2.down * forceMagnitude * Time.deltaTime;
        //playerBody.AddForce(Vector2.down * forceMagnitude * Time.deltaTime, ForceMode2D.Force);
        MovePlayer();

    }

    private void MovePlayer() {
        if (direction != null || direction == Vector2.zero) {
            //playerBody.AddForce(direction * forceForPlayer * Time.deltaTime , ForceMode2D.Force);  //apply force to ball
            playerBody.velocity = direction * forceForPlayer * Time.deltaTime;
        }
    }

    private void getPosition(){
        if(Touchscreen.current.primaryTouch.press.isPressed) {  //Input.touchCount > 0
            
            //Touch touch = Input.GetTouch(0);

            Vector2 touchPosition = Touchscreen.current.primaryTouch.position.ReadValue();
            Vector3 worldPosition = mainCam.ScreenToWorldPoint(touchPosition);

            worldPosition.z = 0f;
            direction = worldPosition - transform.position;
            direction.Normalize();
            //Debug.Log(direction);

        }
    }

    
}
