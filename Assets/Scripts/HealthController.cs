using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthController : MonoBehaviour
{
    public static HealthController instance;

    private Image HealthBar;

    private const float MaxHealth = 100f;

    public float health = MaxHealth;
    public GameObject gui;

    // Start is called before the first frame update
    void Start()
    {
        HealthBar = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        health = PlayerPrefs.GetFloat("Health", health);
        if (health <= 0)
        {
            gui.SetActive(true);
            PlayerPrefs.SetFloat("Speed", 0);
        }
        else if(health > 100)
        {
            health = 100;
        }
        PlayerPrefs.SetFloat("Health", health);
        HealthBar.fillAmount = health / MaxHealth;
    }

    void Awake()
    {
        instance = this;
    }
}
