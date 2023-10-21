using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetCheese : MonoBehaviour
{
    private CollectibleManagerTMP cManager;

    private void Start()
    {
        // inv = FindObjectOfType<PlayerInventory>();
        cManager = FindObjectOfType<CollectibleManagerTMP>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        cManager.Reset();
    }

}
