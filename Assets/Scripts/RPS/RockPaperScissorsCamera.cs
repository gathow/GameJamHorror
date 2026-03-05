using UnityEngine;
using System.Collections;

public class RockPaperScissorsCamera : MonoBehaviour
{
    public Transform target;
    public Transform screentarget;
    public float speed = 3.0f;
    public float upspeed = 6.0f;
    public float arrivalThreshold = 0.01f;
    public RockPaperScissors rps;  

    void Start()
    {
     StartCoroutine(MoveOnceToTarget());
    }
    void Update()
    {
        if (rps.playerchoice != 0)
        {
            StartCoroutine(MoveToScreen());
        }
        
    }

    IEnumerator MoveOnceToTarget()
    {
        while (Vector3.Distance(transform.position, target.position) > arrivalThreshold)
        {
            transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
            yield return null;
        }
    }
    IEnumerator MoveToScreen()
    {
        transform.rotation = Quaternion.RotateTowards(transform.rotation, screentarget.rotation, upspeed * Time.deltaTime);
        yield return null;
    }
}

