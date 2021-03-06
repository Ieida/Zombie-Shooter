using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// This script will be in charge of changing the game state, start, end, advance the level.
/// It will contain the scriptable object for the zoombies, and the functions to keep track, spawn and remove them
/// </summary>
public class ZoombieShooter : MonoBehaviour
{
    [System.Flags] // makes them visible in the editor
    public enum eGameStates
    {
        none = 0,
        mainMenu = 1,
        preLevel = 2,
        level = 3,
        postLevel = 4,
        endGame = 5,
        all = 0xFFFFFFF,
    }

    [Header("Set in Inspector")]
    public Camera mainMenuCamera;
    public GameObject player;

    public List<string> levels;

    [Header("Dynamic Fields")]
    public eGameStates _currentGameState;

    public static event Action<eGameStates> CURRENT_GAME_STATE_CHANGED;
   
    public static eGameStates CURRENT_GAME_STATE
    {
        get
        {
            return _S._currentGameState;
        }
        set
        {
            _S._currentGameState = value;
            CURRENT_GAME_STATE_CHANGED?.Invoke(value);
        }

    }
    public static ZoombieShooter S
    {
        get
        {
            if (_S == null)
            {
                Debug.LogError(" You should set ZoombieShotter in the game - returning null");

            }

            return _S;
        }
        set
        {
            if (_S != null)
            {
                Debug.LogError(" There are two ZoombieShotter in the game");
                return;
            }
            _S = value;
        }
    }

    private static ZoombieShooter _S;


    public void StartGame()
    {
        CURRENT_GAME_STATE = eGameStates.level;
        //TODO: Load StartScene
        if(levels!= null && levels.Count != 0)
        {
            SceneManager.LoadScene(levels[0], LoadSceneMode.Additive);
            mainMenuCamera.enabled = false;
            player.SetActive(true);
        }
        else
        {
            Debug.LogError("Error: missing levels reference - You should set the name of the levels in the Inspector!");
        }
      
    }


    private void Awake()
    {
        player.SetActive(false);
        S = this;
        CURRENT_GAME_STATE = eGameStates.mainMenu;
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
