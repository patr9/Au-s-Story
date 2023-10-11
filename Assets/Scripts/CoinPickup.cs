using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CoinPickup : MonoBehaviour
{
    public int worth = 100;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            PlayerPrefs.SetInt(gameObject.name.Replace("(Clone)", "").ToString(), 1);
            Destroy(gameObject);
            LevelManager.instance.IncreaseCurrency(worth);
        }
    }
}
