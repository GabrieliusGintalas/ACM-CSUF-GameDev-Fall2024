using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public static SceneController instance;
    public GameObject playerPrefab;
    private GameObject playerInstance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else{
            Destroy(gameObject);
        }
        if(playerInstance == null && playerPrefab != null)
        {
            InstantiatePlayer();
        }
    }
    
    public void ChangeScene(string sceneName)
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
        SceneManager.LoadSceneAsync(sceneName);
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        InstantiatePlayer();
    }

    private void InstantiatePlayer()
    {
        Transform spawnPoint = GameObject.FindWithTag("Respawn").transform;

        if(playerInstance == null)
        {
            playerInstance = Instantiate(playerPrefab, spawnPoint.position, spawnPoint.rotation);

        }
        else
        {
            playerInstance.transform.position = spawnPoint.position;
            playerInstance.transform.rotation = spawnPoint.rotation;
        }
    }
}
