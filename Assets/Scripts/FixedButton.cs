using UnityEngine;
using UnityEngine.EventSystems;

public class FixedButton : MonoBehaviour, IPointerUpHandler, IPointerDownHandler
{
    [HideInInspector]
    public bool Pressed;
	public static bool PublicPress;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
    if(Input.GetKeyDown("space"))
        {
            Pressed = true;
			Debug.Log("space");
			//PublicPress = true;
        }
		 if(Input.GetKeyUp("space"))
        {
            Pressed = false;
		//	PublicPress = false;
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        Pressed = true;
		PublicPress = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        Pressed = false;
		PublicPress = false;
    }
	
	
}

