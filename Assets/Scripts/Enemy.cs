using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameObject Player;
    public GameObject EnemyObj;
    private bool Chasing; 
    private Vector3 PlayerPos;
    private Vector3 EnemyPos;
    private Vector3 startDistance;
    public float Movetimer;
    private float timer;
    private bool TimerDone;
    private float finalDistance;
    void Start()
    {
         timer = 0f;
    }

    // Update is called once per frame
    void Update()
    {
    PlayerPos = Player.transform.position;
    EnemyPos = EnemyObj.transform.position; 
    startDistance = PlayerPos - EnemyPos;
    finalDistance = startDistance.magnitude;
    
    if (finalDistance < 5f)
    {
      Chasing = true;
    }
    else
        {
            Chasing = false;
        }
    timer += Time.deltaTime;
    if (timer >= Movetimer) {
        TimerDone = true;
        timer = 0f;
    }
    if (TimerDone && Chasing )
        {
            MoveTowardPlayer();
        }

    }
    void MoveTowardPlayer()
    {
    EnemyObj.transform.position = Vector3.MoveTowards(EnemyPos, PlayerPos, 1f * Time.deltaTime);
    }
}