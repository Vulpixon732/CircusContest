using UnityEngine;
using UnityEngine.EventSystems;

public class S_HoverManager : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    //[PREREQUISITES]
    //Requires Physics Raycaster on target Camera
    //Requires EventSystem on the Scene

    //[RECOMMENDED]
    //Set Layer Mask on Physics Raycaster to match the Layer of Objects that are checked for

    private bool isMouseOver = false;

    public void OnPointerEnter(PointerEventData eventData)
    {
        isMouseOver = true;
        //Debug.Log("Mouse entered " + gameObject.name);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        isMouseOver = false;
        //Debug.Log("Mouse exited " + gameObject.name);
    }

    public bool IsMouseOverElement()
    {
        return isMouseOver;
    }
}
