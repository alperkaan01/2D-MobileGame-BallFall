using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSpawner : MonoBehaviour
{

    [SerializeField] private GameObject[] platformPrefab;
    [SerializeField] private float secondsBetweenPlatforms = 1.5f;
    [SerializeField] private float secondsBetweenPlatformsDecrementer;
    [SerializeField] private float minSecondsBetweenPlatforms;
    [SerializeField] private ScoreSystem scoreSystem;
    //[SerializeField] private CameraMover cm;


    private float timer;
    private Camera mainCam;
    //private bool firstPhase = true;
    private bool secondPhase = true;
    private bool thirdPhase = true;
    private bool lastPhase = true;



    public RingSpawner rs;
    public bool contRing;


    private void Awake()
    {
        mainCam = Camera.main;
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;

        if (timer <= 0)
        {
            rs.continueToSpawnRing = false;
            if (!rs.continueToSpawnRing)
            {
                SpawnPlatform();
                new WaitForSeconds(0.3f);
                rs.continueToSpawnRing = true;
                timer += secondsBetweenPlatforms;
            }

        }

        if (secondsBetweenPlatforms > minSecondsBetweenPlatforms)
        {
            secondsBetweenPlatforms -= Time.deltaTime * secondsBetweenPlatformsDecrementer;
        }


        gameSpeedIncrementer();

    }

    private void SpawnPlatform()
    {

        //Debug.Log("Platform spawner is invoked!");

        Vector2 spawnPoint = Vector2.zero;

        spawnPoint.x = Random.value;
        spawnPoint.y = 0f;

        if(spawnPoint.x < 0.5) {
            spawnPoint.x += 0.30f;
        }else if(spawnPoint.x > 0.5){
            spawnPoint.x -= 0.30f;
        }

        Vector3 worldPosition = mainCam.ViewportToWorldPoint(spawnPoint);
        worldPosition.z = 0;


        if(scoreSystem.Score < 100){
            
            GameObject platformInstance = Instantiate(platformPrefab[0], worldPosition, Quaternion.identity);

        }else if(scoreSystem.Score >= 100  && scoreSystem.Score < 200){
            
            GameObject platformInstance = Instantiate(platformPrefab[1], worldPosition, Quaternion.identity);

            //secondsBetweenPlatforms -= 0.5f;

        }else if(scoreSystem.Score >= 200  && scoreSystem.Score < 300){
            
            GameObject platformInstance = Instantiate(platformPrefab[2], worldPosition, Quaternion.identity);

            //secondsBetweenPlatforms -= 0.5f;
            

        }else {
            
            GameObject platformInstance = Instantiate(platformPrefab[3], worldPosition, Quaternion.identity);

            //secondsBetweenPlatforms -= 0.5f;

        }



    }


    private void gameSpeedIncrementer(){
        if(scoreSystem.Score >= 100  && scoreSystem.Score < 200 && secondPhase){

            secondsBetweenPlatforms -= 0.2f;

            secondPhase = false;

        }else if(scoreSystem.Score >= 200  && scoreSystem.Score < 300 && thirdPhase){
            
            

            secondsBetweenPlatforms -= 0.25f;

            thirdPhase = false;
            

        }else {
            
            
            if(lastPhase) {
                secondsBetweenPlatforms -= 0.3f;
            
                lastPhase = false;
            }
            

        }
    }


}
