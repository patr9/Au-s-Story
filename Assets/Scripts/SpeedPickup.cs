using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class SpeedPickup : MonoBehaviour
{
    public int worth = 1;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            PlayerPrefs.SetInt(gameObject.name.Replace("(Clone)", "").ToString(), 1);
            Destroy(gameObject);
            SpecialController.instance.IncreaseSpeed(worth);
        }
    }
}
