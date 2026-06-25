using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEngine.Rendering.DebugUI;

public class S_ControllerManager : MonoBehaviour
{
    public GameObject mainPlayer;
    public List<GameObject> valveControllers;

    private GameObject currentPossession;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //currentPossession = mainPlayer;
        //mainPlayer.GetComponent<PlayerInput>().enabled = true;
        foreach(GameObject valve in valveControllers)
        {
            UnpossessObject(valve);
        }
        if(currentPossession != mainPlayer)
        {
            PossessPlayer(true);
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

    public void PossessObject(GameObject target)
    {
        PossessPlayer(false);
        target.GetComponent<PlayerInput>().enabled = true;
        FindChildWithTag(target, "ValveCamera").SetActive(true);
        currentPossession = target;
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = true;
    }
    public void UnpossessObject(GameObject target)
    {
        target.GetComponent<PlayerInput>().enabled = false;
        FindChildWithTag(target, "ValveCamera").SetActive(false);
        currentPossession = null;
    }


    public void PossessPlayer(bool value)
    {
        if (currentPossession != mainPlayer && currentPossession != null && value)
        {
            UnpossessObject(currentPossession);
        }
        mainPlayer.GetComponent<PlayerInput>().enabled = value;
        FindChildWithTag(mainPlayer, "MainCamera").SetActive(value);
        if (value)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            currentPossession = mainPlayer;
        }
    }
}
