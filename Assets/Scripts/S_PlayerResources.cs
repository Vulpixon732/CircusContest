using System;
using Unity.Mathematics;
using UnityEngine;

public class S_PlayerStatus : MonoBehaviour
{

    private float ducks = 0;

    private void Awake()
    {
        S_DuckPickup.onCollisionEvent += AddDucks;
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddDucks(float value)
    {
        ducks = ducks + value;
        Debug.Log("Current Ducks: " + ducks);
    }

    private void OnDestroy()
    {
        S_DuckPickup.onCollisionEvent -= AddDucks;
    }
}
