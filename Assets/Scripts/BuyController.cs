using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class BuyController : MonoBehaviour
{
    public GameObject gui;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            gui.SetActive(true);
        }
    }
}
