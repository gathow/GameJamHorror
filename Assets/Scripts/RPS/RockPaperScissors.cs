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
     playerimgrenderer = playerimgshow != null ? playerimgshow.GetComponent<Renderer>() : null;
    enemyimgrenderer  = enemyimgshow  != null ? enemyimgshow.GetComponent<Renderer>()  : null;

    if (playerimgshow == null) Debug.LogError("playerimgshow is null");
    if (enemyimgshow  == null) Debug.LogError("enemyimgshow is null");
    if (playerimgrenderer == null) Debug.LogError("playerimgrenderer missing Renderer");
    if (enemyimgrenderer  == null) Debug.LogError("enemyimgrenderer missing Renderer");
    }
    void Update()
    {
        if (playerhasdonechoice == true)
        {
            ShowText();    
        }
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
    public async System.Threading.Tasks.Task Decidewinner()
    {
        while (playerchoice <= 0){
        await Task.Yield();
        }
        if((playerchoice == 1 && machinechoice == 3) || (playerchoice == 2 && machinechoice == 1) || (playerchoice == 3 && machinechoice == 2))
        {
            wincount ++;
            movecounter ++;
            wintextshow.SetActive(true);
            losstextshow.SetActive(false);
            Nextround();
            Debug.Log("You won:" + playerchoice + machinechoice);
        }
        else
        {
           movecounter ++;
           losstextshow.SetActive(true);
           wintextshow.SetActive(false);
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
        playerhasdonechoice = false;
        RPSchoice(); 
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
}
