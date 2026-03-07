using UnityEngine;

public class BallLogic : MonoBehaviour
{
    public int ballselect;
    public int points;
    public GameObject LeftBall;
    public GameObject MiddleBall;
    public GameObject RightBall;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
     Invoke("BeginGame", 3);
    }

    // Update is called once per frame
    void Update()
    {
    
    }
    void SelectBall()
    {
     ballselect = Random.Range(1, 4);
    }
    void TeleportBall()
    {
    switch (ballselect)
        {
            case 1:
            Debug.Log("1");
            break;
            case 2:
            Debug.Log("2");
            break;
            case 3:
            Debug.Log("3");
            break;
        }
        BeginGame();
    }
    void BeginGame()
    {
     SelectBall();
     TeleportBall();
    }    
}
