using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.SceneManagement;
using TMPro;

public class ShopController : MonoBehaviour
{
    //Variables
    public GameObject gui;
    public GameObject bgui;
    public GameObject trigger;
    public GameObject wall;
    public GameObject tilemap;
    public GameObject player;
    public TextMeshProUGUI text;
    private int temp;
    private string potion;
    private int worth;

    public void openDoor()
    {
        temp = PlayerPrefs.GetInt("Currency", temp);
        if (temp < 100)
        {
            text.text = "Insufficient funds. Please come back when you have the required amount.";
        }
        else
        {
            gui.SetActive(false);
            Destroy(trigger);
            if (temp - 100 < 0)
            {
                PlayerPrefs.SetInt("Currency", 0);
            }
            else
            {
                PlayerPrefs.SetInt("Currency", temp - 100);
            }
            tilemap.SetActive(true);
            wall.SetActive(false);
        }
    }
    
    public void closeDoor()
    {
        gui.SetActive(false);
        text.text = "Would you like to open this door for 100 gold? Be warned, the room is forever changing! You risk being rewarded everything to nothing!";
    }

    public void closeGUI()
    {
        gui.SetActive(false);
    }

    public void closePrompt()
    {
        bgui.SetActive(false);
    }

    public void promptBuy()
    {
        bgui.SetActive(true);
        potion = PlayerPrefs.GetString("Type", potion);
        worth = PlayerPrefs.GetInt("Worth", worth);
        text.text = "Would you like to buy a " + potion + " potion for " + worth + " gold?";
    }

    public void buyPotion()
    {
        temp = PlayerPrefs.GetInt("Currency", temp);
        potion = PlayerPrefs.GetString("Type", potion);
        worth = PlayerPrefs.GetInt("Worth", worth);
        if (temp < worth)
        {
            text.text = "Insufficient funds. Please come back when you have the required amount.";
        }
        else
        {
            bgui.SetActive(false);
            if (temp - worth < 0)
            {
                PlayerPrefs.SetInt("Currency", 0);
            }
            else
            { 
                PlayerPrefs.SetInt("Currency", temp - worth);
            }
            switch (potion)
            {
                case "health":
                    LevelManager.instance.IncreaseHealth(30);
                    break;
                case "speed":
                    SpecialController.instance.IncreaseSpeed(1);
                    break;
                case "growth":
                    player.transform.localScale += new Vector3(0.2f, 0.2f, 1);
                    break;
                case "shrinking":
                    player.transform.localScale -= new Vector3(0.2f, 0.2f, 1);
                    break;  
            }
        }
    }

    public void promptHealth()
    {
        PlayerPrefs.SetString("Type", "health");
        PlayerPrefs.SetInt("Worth", 30);
        promptBuy();
    }

    public void promptSpeed()
    {
        PlayerPrefs.SetString("Type", "speed");
        PlayerPrefs.SetInt("Worth", 50);
        promptBuy();
    }

    public void promptGrowth()
    {
        PlayerPrefs.SetString("Type", "growth");
        PlayerPrefs.SetInt("Worth", 60);
        promptBuy();
    }

    public void promptShrink()
    {
        PlayerPrefs.SetString("Type", "shrinking");
        PlayerPrefs.SetInt("Worth", 60);
        promptBuy();
    }

    public void endGame()
    {
        temp = PlayerPrefs.GetInt("Currency", temp);
        if(temp < 200)
        {
            text.text = "Insufficient funds. Please come back when you have 200 gold.";
        }
        else
        {
            PlayerPrefs.SetInt("Currency", temp - 200);
            SceneManager.LoadScene("MainMenu");
            PlayerPrefs.SetInt("Endgame", 1);
        }
    }

    public void revive()
    {
        temp = PlayerPrefs.GetInt("Currency", temp);
        if (temp < 50)
        {
            text.text = "Insufficient funds. Looks like you lose! Press no to restart.";
        }
        else
        {
            PlayerPrefs.SetInt("Currency", temp - 50);
            PlayerPrefs.SetFloat("Health", 100);
            PlayerPrefs.SetFloat("Speed", 5);
            gui.SetActive(false);
        }
    }

    public void noRevive()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
