using UnityEngine;
using UnityEngine.InputSystem;

public class RockDetector : MonoBehaviour
{
    public RockPaperScissors rps;             // assign in Inspector
    public InputActionReference attackAction; // assign your attack/click action

    private void OnEnable()
    {
        attackAction.action.Enable();
        attackAction.action.performed += OnAttackPerformed;
    }

    private void OnDisable()
    {
        attackAction.action.performed -= OnAttackPerformed;
        attackAction.action.Disable();
    }

   private void OnAttackPerformed(InputAction.CallbackContext context)
   {
    // Read screen position from the pointer devices, not from the button action
    Vector2 screenPos = Vector2.zero;
    if (Pointer.current != null) screenPos = Pointer.current.position.ReadValue();
    else if (Mouse.current != null) screenPos = Mouse.current.position.ReadValue(); // fallback
    else if (Touchscreen.current != null) screenPos = Touchscreen.current.primaryTouch.position.ReadValue();

    if (screenPos == Vector2.zero) return;

    Ray ray = Camera.main.ScreenPointToRay(screenPos);
    if (Physics.Raycast(ray, out RaycastHit hit))
    {
        if (hit.collider.CompareTag("Clickable"))
        {
            rps.playerchoice = 1;
            Debug.Log("Clicked on: " + hit.transform.name);
        }
    }
    }
}
