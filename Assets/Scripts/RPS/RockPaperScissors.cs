using UnityEngine;
using System.Threading.Tasks;
using System.Threading;
public class RockPaperScissors : MonoBehaviour
{
    public int playerchoice;
    public float roomtimer = 500;
    public int machinechoice;
    public int movecounter = 0;
    public int wincount;
    public GameObject door;
    public bool playerhasdonechoice;
    public bool playerhasdonechoiceonce;
    
    // Update is called once per frame
    void Update()
    {
        if (playerchoice >= 1)
        {
            Thread.Sleep(2000);          
            RPSchoice();
        }
        roomtimer -= Time.deltaTime;
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
    _ = Decidewinner();
    }
    public async System.Threading.Tasks.Task Timewaster()
    {
        if (playerhasdonechoice == true)
        {
        await Task.Delay(5000);
        }
        playerhasdonechoice = false;
    }
    public async System.Threading.Tasks.Task Decidewinner()
    {
        while (playerchoice <= 0){
        await Task.Yield();
        }
        if((playerchoice == 1 && machinechoice == 3) || (playerchoice == 2 && machinechoice == 1) || (playerchoice == 3 && machinechoice == 2))
        {
            wincount ++;
            movecounter ++;
            Nextround();
            Debug.Log("You won:" + playerchoice + machinechoice);
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
    void Nextround()
    {
       Inbetweenrounds();
    }
    void Inbetweenrounds()
    {
        playerchoice = 0;
        _ = Timewaster();
        RPSchoice(); 
    }
}
