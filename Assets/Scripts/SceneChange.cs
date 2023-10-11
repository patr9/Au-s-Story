using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{
    //Variables
    public string SceneToLoad;
    public GameObject Player;
    public Animator anim;
    public static string currentScene;
    private GameObject[] spawnPoints;

    [SerializeField] Canvas SceneTransition;

    // Start is called before the first frame update
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            currentScene = SceneManager.GetActiveScene().name;
            SceneTransition.enabled = true;
            anim.SetTrigger("transition");
            AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(SceneToLoad, LoadSceneMode.Single);
            anim.SetTrigger("transition");
            SceneTransition.enabled = false;
        }
    }
}
