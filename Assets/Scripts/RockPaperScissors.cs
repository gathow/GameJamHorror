using UnityEngine;

public class RockPaperScissors : MonoBehaviour
{
    private int playerchoice;
    private int roomtimer;
    private int machinechoice;
    private int movecounter = 1;
    private int wincount;
    public GameObject door;
    // Update is called once per frame
    void Update()
    {
        if (movecounter = 3)
        {
            getresults();
        }
        if (roomtimer = 0)
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
        if(playerchoice = 1 + machinechoice = 3 || playerchoice = 2 + machinechoice = 1 || playerchoice = 3 + machinechoice = 2)
        {
            wincount +1;
            movecounter +1;
            nextround();
        }
        else
        {
           movecounter +1;
           nextround(); 
        }
    }
    void Getresults()
    {
        if(wincount > 1)
        {
            Currency.pointnumber +10;
            Finishminigame();
        }
    }
    void Finishminigame()
    {
        roomtimer = 0;
    }
}
