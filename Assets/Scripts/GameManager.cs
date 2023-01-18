using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private VoidEvent onGameStart;
    [SerializeField] private BoolEvent onMenuTrigger;
    [SerializeField] private PlayerRules playerRules;
    [SerializeField] private CinemachineVirtualCamera gameCam;

    private void OnEnable()
    {
        playerRules.isActive = false;
        gameCam.Priority = 0;
        onMenuTrigger.OnEventRaised += OnMenuTrigger;
    }

    private void OnDisable()
    {
        onMenuTrigger.OnEventRaised -= OnMenuTrigger;
    }

    private void Start()
    {
        onMenuTrigger.RaiseEvent(true);
    }

    private void OnMenuTrigger(bool value)
    {
        if (!value)
        {
            onGameStart.RaiseEvent();
        }
    }
}
