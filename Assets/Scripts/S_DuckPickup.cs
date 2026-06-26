using UnityEngine;
using UnityEngine.Events;

public class S_DuckPickup : MonoBehaviour
{
    public delegate void onCollision(float val);
    public static event onCollision onCollisionEvent;

    private float value = -1;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetValue(float val)
    {
        if(val > 0)
        {
            value = val;
        }
        else
        {
            Debug.LogError("val argument is <= 0");
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Collision");
        if(collision.collider.CompareTag("Player"))
        {
            Debug.Log("DEBUG OnCollisionEnter > collider Tag == Player");
            onCollisionEvent?.Invoke(value);
            Destroy(transform.gameObject);
        }
    }
}
