using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class PlayerSelector : MonoBehaviour
{

    [SerializeField] private GameObject player;

    [SerializeField] private GameObject [] playerPrefabArray;


    
    private GameObject playerInstance;


    public GameObject PlayerInstance {
        get {
            return playerInstance;
        }
    }

    public GameObject [] PlayerPrefabArray
    {
        get {
            return playerPrefabArray;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        InstantiatePrefab();
    }

    // Update is called once per frame
    private void InstantiatePrefab(){

        int indx = PlayerPrefs.GetInt(Shop.charSelectionKey, 0);

        playerPrefabArray[indx].gameObject.SetActive(true);

    }
}
