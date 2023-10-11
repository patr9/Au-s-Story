using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class HealthPickup : MonoBehaviour
{
    public int worth = 30;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            PlayerPrefs.SetInt(gameObject.name.Replace("(Clone)", "").ToString(), 1);
            Destroy(gameObject);
            LevelManager.instance.IncreaseHealth(worth);
        }
    }
}
