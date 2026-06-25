using UnityEngine;
using UnityEngine.InputSystem;

public class S_ValveController : MonoBehaviour
{
    //private PlayerInput playerInput;
    public Transform valve;
    public GameObject handle;

    public float rotationSpeed = 30f;

    private bool isMouseHeld = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
    //    playerInput = new PlayerInput();
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
        //DEBUG
        Debug.Log("IsCursorOnHandle: " + IsCursorOnHandle().ToString());
        //
        valve.transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime);
    }

    bool IsCursorOnHandle()
    {
        //Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        //Ray ray = Camera.main.ScreenPointToRay(Mouse.current.position.ReadValue());
        Vector3 mousePos = 
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            GameObject selectedObject = hit.collider.gameObject;

            if (selectedObject != null)
            {
                if (selectedObject == handle)
                {
                    return true;
                }
            }
        }
        return false;
    }

    void OnUnpossess()
    {
        Debug.Log("DEBUG OnUnpossess ACTION");
    }

    void OnMoveHandle()
    {
        Debug.Log("DEBUG OnMoveHandle");
        isMouseHeld = true;
    }
    void OnReleaseHandle()
    {
        Debug.Log("DEBUG OnReleaseHandle");
        isMouseHeld = false;
    }
}
