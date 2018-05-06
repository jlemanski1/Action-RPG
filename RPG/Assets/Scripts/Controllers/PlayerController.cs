using UnityEngine;
using UnityEngine.EventSystems;

[RequireComponent(typeof(PlayerMotor))]
public class PlayerController : MonoBehaviour {

    public LayerMask movementMask;
    public Interactable focus;

    Camera cam;
    PlayerMotor motor;

	void Start ()
    {
        cam = Camera.main;
        motor = GetComponent<PlayerMotor>();

	}
	
	void Update ()
    {
        //Check for hovering over UI
        if (EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }

        //Player Movement: Left Click
		if (Input.GetMouseButtonDown(0))
        {
            //Create a ray on mouse position
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            //Ray hits
            if (Physics.Raycast(ray, out hit, 100, movementMask))
            {
                //Move player to hit location & perform action
                motor.MoveToPoint(hit.point);

                //Stop focusing any objects
                RemoveFocus();
            }
        }

        //Player Interaction: Right Click
        if (Input.GetMouseButtonDown(1))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            //Ray hits
            if (Physics.Raycast(ray, out hit, 100))
            {
                //Check if interactble is hit, if it is, set as focus
                Interactable interactable = hit.collider.GetComponent<Interactable>();

                if (interactable != null)
                {
                    SetFocus(interactable);
                }
            }
        }
    }

    #region Interactable Focus Methods

    //Set focus to object's transform
    void SetFocus(Interactable newFocus)
    {
        if (newFocus != focus)
        {
            if (focus != null)
                focus.OnDeFocused();

            focus = newFocus;
            motor.FollowTarget(newFocus);
        }

        newFocus.OnFocused(transform);
    }

    //Remove any focus
    void RemoveFocus()
    {
        if (focus != null)
            focus.OnDeFocused();

        focus = null;
        motor.StopFollowingTarget();
    }

    #endregion

}
