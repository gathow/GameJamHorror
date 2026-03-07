using UnityEngine;
using UnityEngine.InputSystem;
public class DoorOpenLogic : MonoBehaviour
{
    public Transform PlayerPos;
    public Transform DoorPos;
    public Animator animator;
    public InputActionReference interactAction;
    public bool opendoorallowed;
private void OnEnable()
{
    interactAction.action.performed += OnInteractPerformed;
    interactAction.action.Enable();
}
private void OnDisable()
{
    interactAction.action.performed -= OnInteractPerformed;
    interactAction.action.Disable();
}
private void OnInteractPerformed(InputAction.CallbackContext ctx)
{
    Debug.Log("input good");  
    if (opendoorallowed == true)
        {
             OpenDoor();
            Debug.Log("input good");        
        }
}
void Update()
    {
        if(Vector3.Distance(PlayerPos.position, DoorPos.position) < 5f)
        {
         opendoorallowed = true;
        }
        else
        {
        opendoorallowed = false;
        }

    }
    void OpenDoor()
    {
        animator.SetTrigger("Open");
        Debug.Log("Opened");
    }
}
