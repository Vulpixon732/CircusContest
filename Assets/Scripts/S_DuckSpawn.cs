using UnityEngine;
using UnityEngine.Rendering;

public class S_DuckSpawn : MonoBehaviour
{
    public GameObject duckPrefab;

    [Header("Random Added Rigidbody Force on Instantiate\n\nx - Min Spawn Force Value\ny - Max Spawn Force Value")]
    public Vector2 forceX = new Vector2(0.1f, 0.2f);
    public Vector2 forceY = new Vector2(0f, 0.1f);
    public Vector2 forceZ = new Vector2(-0.1f, 0.1f);

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
            GameObject newDuck = Instantiate(duckPrefab, this.transform.position, Quaternion.identity);
            newDuck.GetComponent<Rigidbody>().AddForce(new Vector3(Random.Range(forceX.x, forceX.y), Random.Range(forceY.x, forceY.y), Random.Range(forceZ.x, forceZ.y)), ForceMode.Impulse);
        }
    }
}
