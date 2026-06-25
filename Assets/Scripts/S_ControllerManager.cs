using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;
using UnityEngine.InputSystem;

public class S_ControllerManager : MonoBehaviour
{
    public GameObject mainPlayer;
    public List<GameObject> valveControllers;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        mainPlayer.GetComponent<PlayerInput>().enabled = true;
        FindChildWithTag(mainPlayer, "MainCamera").SetActive(true);


        foreach(GameObject valve in valveControllers)
        {
            valve.GetComponent<PlayerInput>().enabled = false;
            FindChildWithTag(valve, "ValveCamera").SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    GameObject FindChildWithTag(GameObject parent, string tag)
    {
        GameObject child = null;

        foreach (Transform transform in parent.transform)
        {
            if (transform.CompareTag(tag))
            {
                child = transform.gameObject;
                break;
            }
        }

        return child;
    }
}
