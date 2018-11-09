using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Fungus;
using TMPro;

public class Main : MonoBehaviour {

    public static Main GMInstance;
    public PlayerData playerRef;
    public CrestTest crestManager;

    //public Animator crestDisplayAnim; //Animator that displayed the crest using GIF <<< replaced by static image <<<REMEMBER to delete after re-run



    //All Monsters
    public List<BaseMonster> allMonsters = new List<BaseMonster>();

    public bool displayOpen = true;
    public string playerName;

    public Flowchart MainChart;

    //public Button DigiCard; //Digicard or ICON would display at the APP's first run <<<REMEMBER delete after re-run

    public GameObject nameInputField;
    public GameObject nameSaveButton;

    //GAMEOBJECTS connected to a display panel << REMEMBER to delete after re-run
    //public GameObject crestDisplayOpener;
    //public GameObject crestDisplayCloser;

    public GameObject textNameDisplayer;
    
    public GameObject rPartner;
    public GameObject lPartner;



    

    void Awake()
    {
        //PlayerPrefs.DeleteAll();
        //ScreenStatusManager();

        MakeSingleton();
        Intro();
        //MainChart.GetStringVariable("Result");
        playerRef = GameObject.Find("PlayerDataOBJ").GetComponent<PlayerData>();
    }

    void Update()
    {
       
            

        


    }


    void MakeSingleton()
    {
        Debug.Log("MakeSingleton is called from Main");

        if (GMInstance != null)
        {
            Debug.Log("Game was not null and destroyed the object MakeSingleton in Main");
            Destroy(gameObject);
        }else
        {
            Debug.Log("Not Destroy on load Active Make Singleton in Main");
            GMInstance = this;
            DontDestroyOnLoad(gameObject);
        }
    }
    
    void Intro()
    {
        Debug.Log("Intro is called from Main");
         
        if (!PlayerPrefs.HasKey("Initialized"))
        {
            Debug.Log("No Initialized Key found Main");

            if (!PlayerPrefs.HasKey("QuitByChoice"))
            {
                Debug.Log("No Quitting by choice Main");
                MainChart.ExecuteBlock("Intro");
                
            }else if (PlayerPrefs.HasKey("QuitByChoice"))
            {
                Debug.Log("Quit by choice Main");
                MainChart.ExecuteBlock("Returner"); //change back before build
            }
        }else
        {
            Debug.Log("Found Initialized Key");
            MainChart.ExecuteBlock("Initializing");
            LoadPlayerData();
        }
    }

    public void LoadPlayerData()
    {
        Debug.Log("Player Data Loaded");
        
        crestManager.CrestIniSet();
        LoadPlayerName();
        LoadPlayerPartners();
        playerRef.UpdateStatus();
        
    }

    public void LoadPlayerPartners()
    {
        string rPartner = PlayerPrefs.GetString("rightID");
        string lPartner = PlayerPrefs.GetString("leftID");
        Debug.Log("your R partner is " + rPartner + "maybe?");
        playerRef.GetRightPartner(rPartner);
        playerRef.GetLeftPartner(lPartner);
    }

    public void QuitApplicationByChoice()
    {
        if (!PlayerPrefs.HasKey("QuitByChoice"))
        {
            PlayerPrefs.SetInt("QuitByChoice", 1);
            Debug.Log("You have exit the game and created a QuitByChoice");
            Application.Quit();
        }else
        {
            Debug.Log("You have exit the game");
            Application.Quit();
        }
    }

    public void Intro2()
    {
        Debug.Log("Calling Block");
        MainChart.ExecuteBlock("Intro2");
    }

    public void ContinueToIntro2()
    {

        Debug.Log("So good so far");
        //DigiCard.onClick.AddListener(Intro2);
    }

   
   //This was used for the opening and closing of a display panel <<< REMEMBER TO DELETE AFTER RE-RUN
    /*
    public void ScreenStatusManager()
    {
        Debug.Log("Function Working for crestManager");
        if(displayOpen == true)
        {
           //crestDisplayAnim.SetBool("IsOpen", false);
            displayOpen = false;
            crestDisplayOpener.SetActive(true);
            crestDisplayCloser.SetActive(false);
           
            Debug.Log("Closed");
        }else
        {
            //crestDisplayAnim.SetBool("IsOpen", true);
            displayOpen = true;
            if (PlayerPrefs.HasKey("Initialized"))
            {
                StartCoroutine(OpenPadLoad());
            }
            
            Debug.Log("Open");
        }
    }
    */

    public void SaveName()
    {
        
        playerName = nameInputField.GetComponent<InputField>().text;

        if (!PlayerPrefs.HasKey("PlayerName"))
        {
            Debug.Log("Does not have player name saved prior");
            PlayerPrefs.SetString("PlayerName", playerName);
            nameInputField.SetActive(false);
            nameSaveButton.SetActive(false);
            MainChart.ExecuteBlock("Result"); //change later for normal save
            playerRef.playerName = playerName;
        }else
        {
            Debug.Log("Re-Saving player name");
            PlayerPrefs.SetString("PlayerName", playerName);
            nameInputField.SetActive(false);
            nameSaveButton.SetActive(false);
            playerRef.playerName = playerName;
        }
        
       
        
    }

    public void GetName()
    {
        Debug.Log("Opening Input to get player name");
        nameInputField.SetActive(true);
        nameSaveButton.SetActive(true);
    }

    public void LoadPlayerName()
    {
        Debug.Log("Loading player name " + PlayerPrefs.GetString("PlayerName"));
        TextMeshProUGUI textDisplayPro = textNameDisplayer.GetComponent<TextMeshProUGUI>();
        textDisplayPro.text = (PlayerPrefs.GetString("PlayerName"));


    }

    //Conected to DISPLAY OPENER <<< REMEMBER to delete after re-run
    /*
    IEnumerator OpenPadLoad()
    {
        crestDisplayOpener.SetActive(false);
        yield return new WaitForSeconds(1.5f);
        crestDisplayCloser.SetActive(true);
        
    }
    */


}
