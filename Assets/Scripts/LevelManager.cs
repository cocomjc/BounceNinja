using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private VoidEvent onGameStart;
    [SerializeField] private PlayerRules playerRules;
    [SerializeField] private CinemachineVirtualCamera gameCam;
    
    private void OnEnable()
    {
        onGameStart.OnEventRaised += OnGameStart;
    }

    private void OnDisable()
    {
        onGameStart.OnEventRaised -= OnGameStart;
    }

    private void OnGameStart()
    {
        gameCam.Priority = 10;
        playerRules.isActive = true;
    }
}
