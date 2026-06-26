using UnityEngine;
using UnityEngine.Events;

public class S_DuckPickup : MonoBehaviour
{
    [Header("Call the [Placeholder Duck Manager]\n")]
    public UnityEvent onCollision;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Collision");
        if(collision.collider.CompareTag("Player"))
        {
            Debug.Log("DEBUG OnCollisionEnter > collider Tag == Player");
            //onCollision.Invoke();
            Destroy(transform.gameObject);
        }
    }
}
