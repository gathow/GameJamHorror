using UnityEngine;
using System.Threading.Tasks;
using System.Threading;
public class RockPaperScissors : MonoBehaviour
{
    [Header("Values")]
    public int playerchoice;
    public float roomtimer = 500;
    public int machinechoice;
    public int movecounter = 0;
    public int wincount = 0;
    [Header("Gameobjects")]
    public GameObject playerpickedtext;
    public GameObject enemypickedtext;
    public GameObject playerimgshow;
    public GameObject enemyimgshow;
    public GameObject wintextshow;
    public GameObject losstextshow;
    public RockPaperScissorsCamera rpsc;
    public Texture RockMaterial;
    public Texture PaperMaterial;
    public Texture ScissorsMaterial;
    private Renderer playerimgrenderer;
    private Renderer enemyimgrenderer;

    // Update is called once per frame
    void Start()
    {
    //get renderers for placing textures later
    playerimgrenderer = playerimgshow != null ? playerimgshow.GetComponent<Renderer>() : null;
    enemyimgrenderer  = enemyimgshow  != null ? enemyimgshow.GetComponent<Renderer>()  : null;
    // start round
    RPSround();
    }
    void Update()
    {
        roomtimer -= Time.deltaTime;
        IsGameFinished();
    }
    public async System.Threading.Tasks.Task Decidewinner()
    {
        while (playerchoice == 0 )
        {
        await Task.Yield();
        }
        ShowText();
        if((playerchoice == 1 && machinechoice == 3) || (playerchoice == 2 && machinechoice == 1) || (playerchoice == 3 && machinechoice == 2))
        {
            wincount ++;
            movecounter ++;
            wintextshow.SetActive(true);
            losstextshow.SetActive(false);
            Preparenextround();
            Debug.Log("You won, you picked :" + playerchoice);
        }
        else
        {
           movecounter ++;
           losstextshow.SetActive(true);
           wintextshow.SetActive(false);
           Preparenextround(); 
           Debug.Log("You Lose, you picked :" + playerchoice);
        }
    }
    void IsGameFinished()
    {
        if(wincount > 1 || movecounter == 3)
        {
            roomtimer = 0;
        }
    }
    void Preparenextround()
    {
        playerchoice = 0;
        RPSround();
    }
    void ShowText()
    {
       playerpickedtext.SetActive(true);
       enemypickedtext.SetActive(true);
       playerimgshow.SetActive(true);
       enemyimgshow.SetActive(true);
       playerimgshow.SetActive(true);
switch (playerchoice) 
{
    case 1:
        playerimgrenderer.material.SetTexture("_MainTex", RockMaterial);
        break;
    case 2:
        playerimgrenderer.material.SetTexture("_MainTex", PaperMaterial);
        break;
    case 3:
        playerimgrenderer.material.SetTexture("_MainTex", ScissorsMaterial);
        break;
    
}
switch (machinechoice)
{
    case 1:
        enemyimgrenderer.material.SetTexture("_MainTex", RockMaterial);
        break;
    case 2:
        enemyimgrenderer.material.SetTexture("_MainTex", PaperMaterial);
        break;
    case 3:
        enemyimgrenderer.material.SetTexture("_MainTex", ScissorsMaterial);
        break;
    
}
    
    }
    void RPSround()
    {
        machinechoice = Random.Range(1, 4);
        _ = Decidewinner(); // this is where players input is recieved too

    }
}
