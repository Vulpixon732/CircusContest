using System.Xml.Serialization;
using UnityEngine;
using UnityEngine.InputSystem;

public interface IInteractable
{
    void Interact();
    void OnHover();
    void OnHoverExit();
    void Drop();
}

public class InteractionSystem : MonoBehaviour
{
    public S_FPC_PlayerLook look;
    public Camera cam; //remember to set Camera
    public float playerReach = 3f;
    InteractableOutline currentInteractable;

    void Update()
    {
        CheckInteraction();
        if (Keyboard.current.eKey.wasPressedThisFrame)
        {
            currentInteractable.Interact();
        }
        
    }

    void CheckInteraction()
    {
        // if colliders with anything within player reach
        RaycastHit hit;
        Ray ray = new Ray(cam.transform.position, cam.transform.forward);
        if(Physics.Raycast(ray, out hit, playerReach))
        {
            if(hit.collider.tag == "Interactable") //if looking at interactable
            {
                InteractableOutline newInteractable = hit.collider.GetComponent<InteractableOutline>();

                if(currentInteractable && newInteractable != currentInteractable)
                {
                    currentInteractable.DisableOutline();
                }

                if (newInteractable.enabled)
                {
                    SetNewCurrentInteractable(newInteractable);
                    look.mouseSensitivity = 30f;
                }
                else // if new interactable is not enabled
                {
                    DisableCurrentInteractable();
                    
                }
            }
            else // if not an interactable
            {
                DisableCurrentInteractable();
            }
        }
        else //nothing in reach
        {
            DisableCurrentInteractable();
        }
    }

    void SetNewCurrentInteractable(InteractableOutline newInteractable)
    {
        currentInteractable = newInteractable;
        currentInteractable.EnableOutline();
       //UIControler.instance.EnableInteractionText(currentInteractable.message);
    }

    void DisableCurrentInteractable()
    {
        /*UIControler.instance.DisableInteractionText();
        if (currentInteractable)
        {
            currentInteractable.DisableOutline();
            currentInteractable = null;
        }
        */
 
    }


    /*

    public Camera cam;
    public float distance = 3f;
    public Color hoverColor = Color.green;

    private IInteractable current;
    private Renderer r;
    private Color originalColor;

    void Update()
    {
        RaycastHit hit;
        if(Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, distance) && hit.collider.TryGetComponent(out IInteractable i))
        {
            if(current != i)
            {
                Clear();
                current = i;
                current.OnHover();

                r = hit.collider.GetComponent<Renderer>();
                if (r)
                {
                    originalColor = r.material.color;
                    r.material.color = hoverColor;
                }
            }

            
            if (Mouse.current.leftButton.wasPressedThisFrame)
            {
                current.Interact();
            }
            
        }

        else
        {
            Clear();
        }
    }
    void Clear()
    {
        if (current != null) current.OnHoverExit();
        if (r) r.material.color = originalColor;
        current = null;
        r = null;
    }*/
}
