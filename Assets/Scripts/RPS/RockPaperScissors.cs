using UnityEngine;

public class RockPaperScissors : MonoBehaviour
{
    public int playerchoice;
    private float roomtimer = 500;
    private int machinechoice;
    private int movecounter = 1;
    private int wincount;
    public GameObject door;
    public bool RockPicked;
    public bool PaperPicked;
    public bool ScissorsPicked;

    // Update is called once per frame

    void Update()
    {
        StartTimer();
        if (movecounter == 3)
        {
            Getresults();
        }
        if (roomtimer == 0)
        {
            door.transform.position += new Vector3(0, 7, 0);
        }
    }
    void RPSchoice() // Rock=1 Paper=2 Scissors=3
    {
    machinechoice = Random.Range(1, 4);
    
    }
    void Decidewinner()
    {
        if((playerchoice == 1 && machinechoice == 3) || (playerchoice == 2 && machinechoice == 1) || (playerchoice == 3 && machinechoice == 2))
        {
            wincount ++;
            movecounter ++;
            Nextround();
        }
        else
        {
           movecounter ++;
           Nextround(); 
        }
    }
    void Getresults()
    {
        if(wincount > 1)
        {
            Finishminigame();
        }
    }
    void Finishminigame()
    {
        roomtimer = 0;
        Currency.pointnumber += 10;
    }
    void StartTimer()
    {
        roomtimer -= Time.deltaTime;
    }
    void Nextround()
    {
       playerchoice = 0;
       RPSchoice();
    }
}
