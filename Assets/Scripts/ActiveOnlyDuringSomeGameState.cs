using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveOnlyDuringSomeGameState : MonoBehaviour
{

    public ZoombieShooter.eGameStates activeState;
    // Start is called before the first frame update

    private void Awake()
    {
        ZoombieShooter.CURRENT_GAME_STATE_CHANGED += SetGameObjectState;
        SetGameObjectState(ZoombieShooter.CURRENT_GAME_STATE);
    }

    private void SetGameObjectState(ZoombieShooter.eGameStates currentGameState)
    {

        Debug.Log(" calling set gameObject state");
        bool shouldBeActive = (currentGameState & activeState) == currentGameState;

        gameObject.SetActive(shouldBeActive);

    }

    private void OnDestroy()
    {

        ZoombieShooter.CURRENT_GAME_STATE_CHANGED -= SetGameObjectState;
    }

  
}
