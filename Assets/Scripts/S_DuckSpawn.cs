using UnityEngine;

public class S_DuckSpawn : MonoBehaviour
{
    public GameObject duckPrefab;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Spawn()
    {
        if(duckPrefab != null)
        {
            Instantiate(duckPrefab, this.transform.position, Quaternion.identity);
        }
    }
}
