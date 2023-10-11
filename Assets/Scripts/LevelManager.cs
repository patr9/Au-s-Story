using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class LevelManager : MonoBehaviour
{
    public static LevelManager instance;

    //Variables
    public GameObject[] coins;
    public GameObject[] potions;
    public GameObject Player;
    private static int old;
    public static int currency;
    private float currentHealth;
    public string SceneToLoad;
    public TextMeshProUGUI text;

    //Methods
    void Start()
    {
        GameObject[] spawnPoints = GameObject.FindGameObjectsWithTag("SpawnPoint");
        foreach (GameObject spawnPoint in spawnPoints)
        {
            if (spawnPoint.name == SceneChange.currentScene)
            {
                Player.transform.position = spawnPoint.transform.position;
                break;
            }
        }
        for (int i = 0; i < coins.Length; i++)
        {
            if (PlayerPrefs.HasKey(coins[i].name.Replace("(Clone)", "").ToString()))
            {
                continue;
            }
            GameObject coin = (GameObject)Instantiate(coins[i]);
        }
        for (int i = 0; i < potions.Length; i++)
        {
            if (PlayerPrefs.HasKey(potions[i].name.Replace("(Clone)", "").ToString()))
            {
                continue;
            }
            GameObject potion = (GameObject)Instantiate(potions[i]);
        }
        currentHealth = PlayerPrefs.GetFloat("Health", currentHealth);
        currency = PlayerPrefs.GetInt("Currency", currency);
        text.text = currency.ToString();
    }

    void Update()
    {
        currency = PlayerPrefs.GetInt("Currency", currency);
        text.text = currency.ToString();
    }

    private void Awake()
    {
        instance = this;
    }

    public void IncreaseCurrency(int amount)
    {
        currency += amount;
        PlayerPrefs.SetInt("Currency", currency);
        text.text = currency.ToString();
    }

    public void IncreaseHealth(int amount)
    {
        currentHealth = PlayerPrefs.GetFloat("Health", currentHealth);
        PlayerPrefs.SetFloat("Health", currentHealth+amount);
    }
}
