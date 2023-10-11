using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialController : MonoBehaviour
{

    public static SpecialController instance;

    //Variables
    private int temp;
    private float currentSpeed;
    public GameObject[] items;

    // Start is called before the first frame update
    void Start()
    {
        deleteKeys(items);
        for(int i = 0; i < 4; i++)
        {
            temp = Random.Range(0, items.Length);
            if (items[temp] == null || PlayerPrefs.HasKey(items[temp].name.Replace("(Clone)", "").ToString()))
            {
                continue;
            }
            else
            {
                GameObject item = (GameObject)Instantiate(items[temp]);
                PlayerPrefs.SetInt(item.name.Replace("(Clone)", "").ToString(), 1);
                switch(i)
                {
                    case 0:
                        item.transform.position = new Vector3(-4, 0, 0);
                        break;
                    case 1:
                        item.transform.position = new Vector3(4, 0, 0);
                        break;
                    case 2:
                        item.transform.position = new Vector3(0, 4, 0);
                        break;
                    case 3:
                        item.transform.position = new Vector3(0, -4, 0);
                        break;
                }
            }
        }
    }

    private void Awake()
    {
        instance = this;
    }

    public void IncreaseSpeed(int amount)
    {
        currentSpeed = PlayerPrefs.GetFloat("Speed", currentSpeed);
        PlayerPrefs.SetFloat("Speed", currentSpeed + amount);
    }

    private void deleteKeys(GameObject[] items)
    {
        for(int i = 0; i < items.Length; i++)
        {
            if (items[i] == null)
            {
                continue;
            }
            PlayerPrefs.DeleteKey(items[i].name.Replace("(Clone)", "").ToString());
        }
    }
}
