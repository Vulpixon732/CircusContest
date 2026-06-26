using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Events;

public class S_ValveController : MonoBehaviour
{
    public Transform valve;
    public GameObject handle;
    public Transform spawner;

    public float rotationSpeed = 30f;

    private bool isMouseHeld = false;
    private Vector3 travelDistance;

    [Header("Calls ControllerManager's S_ControllerManager.PossessPlayer(Player Character)\n")]
    public UnityEvent onUnpossessAction;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        if (isMouseHeld)
        {
            RotateHandle();
        }
    }

    void RotateHandle()
    {
        if (IsCursorOnHandle())
        {
            valve.transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime);

            travelDistance = travelDistance + (Vector3.up * rotationSpeed * Time.deltaTime);
            //Debug.Log("Travel Distance: " + travelDistance.ToString());
            if(travelDistance.y >= 360)
            {
                //Debug.Log("FULL ROTATION");
                RotationTrigger();
            }
        }      
    }

    bool IsCursorOnHandle()
    {
        if(handle != null)
        {
            return handle.GetComponent<S_HoverManager>().IsMouseOverElement();
        }
        else
        {
            return false;
        }
    }

    void RotationTrigger()
    {
        travelDistance.y = travelDistance.y - 360;
        spawner.GetComponent<S_DuckSpawn>().Spawn();
    }
    
    public void OnUnpossess()
    {
        //Debug.Log("DEBUG OnUnpossess ACTION");
        onUnpossessAction.Invoke();
    }

    void OnMoveHandle()
    {
        //Debug.Log("DEBUG OnMoveHandle");
        isMouseHeld = true;
    }
    void OnReleaseHandle()
    {
        //Debug.Log("DEBUG OnReleaseHandle");
        isMouseHeld = false;
    }

}
