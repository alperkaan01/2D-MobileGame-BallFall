using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RingSpawner : MonoBehaviour
{

    [SerializeField] private GameObject[] ringPrefab;
    [SerializeField] private float secondsBetweenRings = 3f;
    [SerializeField] private ScoreSystem scoreSystem;
    [SerializeField] private CameraMover cm;

    private float timer;
    private Camera mainCam;
    private bool secondPhase = true;
    private bool thirdPhase = true;
    private bool lastPhase = true;



    public bool continueToSpawnRing = false;


    private void Awake()
    {
        mainCam = Camera.main;
    }
    // Start is called before the first frame update
    void Start()
    {
        new WaitForSeconds(1f);
        continueToSpawnRing = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (continueToSpawnRing)
        {
            timer -= Time.deltaTime;

            if (timer <= 0)
            {
                SpawnRing();
                timer += secondsBetweenRings;
            }
        }


        gameSpeedIncrementer();
    }

    private void SpawnRing()
    {

        Vector2 spawnPoint = Vector2.zero;

        spawnPoint.x = Random.value;
        spawnPoint.y = 0f;

        if (scoreSystem.Score >= 400)
        {

            if (spawnPoint.x < 0.5)
            {
                spawnPoint.x += 0.2f;
            }
            else if (spawnPoint.x > 0.5)
            {
                spawnPoint.x -= 0.2f;
            }

        }

        Vector3 worldSpawnPoint = mainCam.ViewportToWorldPoint(spawnPoint);
        worldSpawnPoint.z = 0;

        //GameObject ringInstance = Instantiate(ringPrefab[0], worldSpawnPoint, Quaternion.identity);


        //after score 200 spawn bigger platforms below


        //after score 400 spawn bigger platforms below && increase the game speed


        //after score 600 spawn bigger platforms below && increase game speed && increase platform spawn speed

        if (scoreSystem.Score < 100)
        {

            GameObject ringInstance = Instantiate(ringPrefab[0], worldSpawnPoint, Quaternion.identity);

        }
        else if (scoreSystem.Score >= 100 && scoreSystem.Score < 200)
        {

            GameObject ringInstance = Instantiate(ringPrefab[1], worldSpawnPoint, Quaternion.identity);

            cm.MaxSpeed = 383f;

            //secondsBetweenRings -= 0.5f;

        }
        else if (scoreSystem.Score >= 200 && scoreSystem.Score < 300)
        {

            GameObject ringInstance = Instantiate(ringPrefab[2], worldSpawnPoint, Quaternion.identity);

            cm.MaxSpeed = 387f;

            //secondsBetweenRings -= 0.5f;

        }
        else
        {

            GameObject ringInstance = Instantiate(ringPrefab[3], worldSpawnPoint, Quaternion.identity);

            //increase gamespeed
            //cm.MaxSpeed = 391f;

            //increase ring spawn speed
            //secondsBetweenRings -= 0.5f;

        }


    }

    private void gameSpeedIncrementer(){
        if(scoreSystem.Score >= 100  && scoreSystem.Score < 200 && secondPhase){

            secondsBetweenRings -= 0.5f;

            secondPhase = false;

        }else if(scoreSystem.Score >= 200  && scoreSystem.Score < 300 && thirdPhase){
            
            

            secondsBetweenRings -= 0.5f;

            thirdPhase = false;
            

        }else {
            
            
            if(lastPhase) {
                secondsBetweenRings -= 0.5f;
            
                lastPhase = false;
            }
            

        }
    }
}
