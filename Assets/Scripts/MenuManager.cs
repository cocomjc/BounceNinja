using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    [SerializeField] private BoolEvent onMenuTrigger;

    private void OnEnable()
    {
        onMenuTrigger.OnEventRaised += OnMenuTrigger;
    }

    private void OnDisable()
    {
        onMenuTrigger.OnEventRaised -= OnMenuTrigger;
    }

    private void OnMenuTrigger(bool value)
    {
        if (value)
        {
            GetComponent<CanvasGroup>().alpha = 1;
            GetComponent<CanvasGroup>().blocksRaycasts = true;
        }
    }

    public void OnMenuExit()
    {
        GetComponent<CanvasGroup>().blocksRaycasts = false;
        GetComponent<Animation>().Play();
        onMenuTrigger.RaiseEvent(false);
    }
}
