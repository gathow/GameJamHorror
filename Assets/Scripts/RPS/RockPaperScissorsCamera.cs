using UnityEngine;
using System.Collections;
using System.Threading.Tasks;
public class RockPaperScissorsCamera : MonoBehaviour
{
    public Transform target;
    public float speed = 3.0f;
    public float arrivalThreshold = 0.01f;
    void Start()
    {
     StartCoroutine(MoveOnceToTarget());
    }
    IEnumerator MoveOnceToTarget()
    {
        while (Vector3.Distance(transform.position, target.position) > arrivalThreshold)
        {
            transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
            yield return null;
        }
    }
}

