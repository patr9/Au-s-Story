using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopPrompt : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject gui;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            gui.SetActive(true);
        }
    }
}
