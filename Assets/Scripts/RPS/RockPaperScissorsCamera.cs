using UnityEngine;
using System.Collections;
using System.Threading.Tasks;
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
        _ = MovedOnceCheck();
        if (rps.playerhasdonechoice == true && rps.playerhasdonechoiceonce == true)
        {
            StartCoroutine(MoveToScreen());
        }
        if (rps.playerhasdonechoice == false && rps.playerhasdonechoiceonce == true)
        {
            StartCoroutine(MoveToSelect());
        }

        
    }
    public async System.Threading.Tasks.Task MovedOnceCheck()
    {
        while (rps.movecounter <= 0)
        {
        await Task.Delay(5000);
        }
        rps.playerhasdonechoiceonce = true;
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
    IEnumerator MoveToSelect()
    {
        transform.rotation = Quaternion.RotateTowards(transform.rotation, target.rotation, upspeed * Time.deltaTime);
        yield return null;
    }
}

