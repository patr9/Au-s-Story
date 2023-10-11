using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class MenuController : MonoBehaviour
{
    public GameObject gui;
    public GameObject wgui;
    public TextMeshProUGUI text;
    public Animator anim;

    [SerializeField] Canvas SceneTransition;

    void Start()
    {
        if (PlayerPrefs.HasKey("Endgame"))
        {
            wgui.SetActive(true);
            text.text = "Congratulations! You made it with " + PlayerPrefs.GetInt("Currency").ToString() + " gold left! If you did it on your first try then good news.. I'm sure you can figure out why. I hope you learned something useful from this adventure. Until next time...";
        }
    }

    public void Play()
    {
        PlayerPrefs.DeleteAll();
        SceneTransition.enabled = true;
        anim.SetTrigger("transition");
        SceneManager.LoadScene("Start");
        anim.SetTrigger("transition");
        SceneTransition.enabled = false;
    }

    public void Controls()
    {
        gui.SetActive(true);
    }

    public void Close()
    {
        gui.SetActive(false);
    }
}
