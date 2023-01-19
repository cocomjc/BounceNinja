using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinGather : MonoBehaviour
{
    [SerializeField] private VoidEvent onCoinGather;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            onCoinGather.RaiseEvent();
            GetComponent<MeshRenderer>().enabled = false;
            GetComponent<Collider>().enabled = false;
            GetComponent<ParticleSystem>().Play();
        }
    }
}
