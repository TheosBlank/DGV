using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using TMPro;

public class PlayerData : MonoBehaviour {

    public static PlayerData playerInstance;
    public BaseMonster rightPartnerData;
    public BaseMonster leftPartnerData;
    public Main gameManager;
    public Stat rHunger;
    public Stat rHappy;
    public Stat lHunger;
    public Stat lHappy;
    public string playerName;

    public string leftID;
    public string rightID;

    

    public Transform rightPos;
    public Transform leftPos;
    public GameObject emptyMon;
    public GameObject rightPartner;
    public GameObject leftPartner;

    //public GameObject rHappinessText;
    //public GameObject rHungerText;
    //public GameObject lHappinessText;
    //public GameObject lHungerText;

    public bool hasRightP;
    public bool hasLeftP;

    private bool _serverTime;

    void Awake()
    {
        //PlayerPrefs.SetString("then", "06/16/2018 02:00:00");
        MakeSingleton();
        gameManager = GameObject.FindGameObjectWithTag("GameController").GetComponent<Main>();
        //rightPartnerData = rightPartner.GetComponent<BaseMonster>();
        //leftPartnerData= leftPartner.GetComponent<BaseMonster>();
        

        if (!PlayerPrefs.HasKey("rightID"))
        {
            rightID = "";
        }else
        {
            rightID = PlayerPrefs.GetString("rightID");
        }

        if (!PlayerPrefs.HasKey("leftID"))
        {
            leftID = "";
        }else
        {
            leftID = PlayerPrefs.GetString("leftID");
        }

        rHunger.InitializeBar();
        rHappy.InitializeBar();
        lHunger.InitializeBar();
        lHappy.InitializeBar();

        rHunger.BarStatusCheck();
        lHunger.BarStatusCheck();
        rHappy.BarStatusCheck();
        lHappy.BarStatusCheck();
        

        Debug.Log("player data is in awake and your right partner is " + rightID);
    }

	// Use this for initialization
	void Start () {
        Debug.Log("called start in player");
        
	}
	
	// Update is called once per frame
	void Update () {

        //rHappinessText.GetComponent<TextMeshProUGUI>().text = "" + rightPartnerData.happiness.ToString("F0");
        //lHappinessText.GetComponent<TextMeshProUGUI>().text = "" + leftPartnerData.happiness.ToString("F0");
        //rHungerText.GetComponent<TextMeshProUGUI>().text = "" + rightPartnerData.hunger.ToString("F0");
        //lHungerText.GetComponent<TextMeshProUGUI>().text = "" + leftPartnerData.hunger.ToString("F0");

        if (PlayerPrefs.HasKey("Initialized"))
        {

            if (rHunger.CurrVal != rightPartnerData._hunger)
            {
                rHunger.CurrVal = rightPartnerData._hunger;
                rHunger.BarStatusCheck();
            }

            if (rHappy.CurrVal != rightPartnerData._happiness)
            {
                rHappy.CurrVal = rightPartnerData._happiness;
                rHappy.BarStatusCheck();
            }

            if (lHunger.CurrVal != leftPartnerData._hunger)
            {
                lHunger.CurrVal = leftPartnerData._hunger;
                lHunger.BarStatusCheck();
            }

            if (lHappy.CurrVal != leftPartnerData._happiness)
            {
                lHappy.CurrVal = leftPartnerData._happiness;
                lHappy.BarStatusCheck();
            }
        }
        

    }

   public void UpdateStatus()
    {
        rightPartnerData = rightPartner.GetComponent<BaseMonster>();
        leftPartnerData = leftPartner.GetComponent<BaseMonster>();

        if (!PlayerPrefs.HasKey("Hunger1"))
        {
            Debug.Log("no hunger key");
            rightPartnerData._hunger = 100;
            leftPartnerData._hunger = 100;
            PlayerPrefs.SetFloat("Hunger1", rightPartnerData._hunger);
            PlayerPrefs.SetFloat("Hunger2", leftPartnerData._hunger);
        }
        else
        {
            Debug.Log("you have a hunger key");
            Debug.Log("you hunger1 is "+ PlayerPrefs.GetFloat("Hunger1"));
            rightPartnerData._hunger = PlayerPrefs.GetFloat("Hunger1");
            leftPartnerData._hunger = PlayerPrefs.GetFloat("Hunger2");
        }

        if (!PlayerPrefs.HasKey("Happy1"))
        {
            Debug.Log("no happy key");
            rightPartnerData._happiness = 100;
            leftPartnerData._happiness = 100;
            PlayerPrefs.SetFloat("Happy1", rightPartnerData._happiness);
            PlayerPrefs.SetFloat("Happy2", leftPartnerData._happiness);
        }
        else
        {
            Debug.Log("your happy1 key is "+ PlayerPrefs.GetFloat("Happy1"));
            rightPartnerData._happiness = PlayerPrefs.GetFloat("Happy1");
            leftPartnerData._happiness = PlayerPrefs.GetFloat("Happy2");
        }

        if (!PlayerPrefs.HasKey("then"))
        {
            PlayerPrefs.SetString("then", getStringTime());
        }

        //TimeSpan ts = getTimeSpan();

        HungerPassTime();
        HappyPassTime();
       
        Debug.Log(getTimeSpan().ToString());
        Debug.Log(getTimeSpan().TotalHours);

        if (_serverTime)
        {
            updateServer();
        }
        else
        {
            InvokeRepeating("updateDevice", 0f, 30f);
        }
    }

    void updateServer()
    {

    }

    void updateDevice()
    {
        PlayerPrefs.SetString("then", getStringTime());
        SaveHunger();
        SaveHappiness();
    }

    TimeSpan getTimeSpan()
    {
        if (_serverTime)
        {
            return new TimeSpan();
        }
        else
        {
            return DateTime.Now - Convert.ToDateTime(PlayerPrefs.GetString("then"));
        }
    }

    string getStringTime()
    {
        DateTime now = DateTime.Now;
        return now.Month + "/" + now.Day + "/" + now.Year + " " + now.Hour + ":" + now.Minute + ":" + now.Second;
    }

    //put this in UpdateStatus to reduce the hunger once the player comes back to the game
    public void HungerPassTime()
    {
        TimeSpan ts = getTimeSpan();
        Debug.Log("the time that has passed is " + (float)ts.TotalHours);
       
        Debug.Log("hunger1 is "+ rightPartnerData._hunger);
        rightPartnerData._hunger -= (float)(ts.TotalHours * 2);
        Debug.Log("after reduction is it " + rightPartnerData._hunger);

        leftPartnerData._hunger -= (float)(ts.TotalHours * 2);

        if(rightPartnerData._hunger < 0)
        {
            Debug.Log("hunger1 is less than 0");
            rightPartnerData._hunger = 0;
        }

        if(rightPartnerData._hunger > 100f)
        {
            Debug.Log("hunger1 is greater than 100");
            rightPartnerData._hunger = 100f;
        }

        if(leftPartnerData._hunger < 0)
        {
            
            leftPartnerData._hunger = 0;
        }

        if(leftPartnerData._hunger > 100f)
        {
            leftPartnerData._hunger = 100f;
        }

        Debug.Log("You reduced the hunger by " + (float)ts.TotalHours +"and the current hunger is"+ rightPartnerData._hunger);
      
    }

    //put this in the UpdateStatus to reduce the Happiness once the player comes back to the game
    public void HappyPassTime()
    {
        TimeSpan ts = getTimeSpan();
     
        rightPartnerData._happiness -= (float)(ts.TotalHours * 2);
        leftPartnerData._happiness -= (float)(ts.TotalHours * 2);

        if (rightPartnerData._happiness < 0)
        {
            rightPartnerData._happiness = 0;
        }

        if (rightPartnerData._happiness > 100f)
        {
            rightPartnerData._happiness = 100f;
        }

        if (leftPartnerData._happiness < 0)
        {
            leftPartnerData._happiness = 0;
        }

        if (leftPartnerData._happiness > 100f)
        {
            leftPartnerData._happiness = 100f;
        }
    }

    public void GetRightPartner(string rID)
    {
        BaseMonster Right = GetPartner(rID);
        Debug.Log("Get right partner called "+ rID);
        Debug.Log(Right.Name);

        if (!hasRightP)
        {
            Debug.Log("You do not have a right partner on you, let make one");
            GameObject dDigi = Instantiate(emptyMon, rightPos.transform.position, Quaternion.identity);
            gameManager.rPartner = dDigi;
            rightPartner = dDigi;
            
            dDigi.transform.parent = rightPos;

            BaseMonster tempMonster = dDigi.AddComponent<BaseMonster>() as BaseMonster;
            //Animator tempAnim = dDigi.AddComponent<Animator>() as Animator;
            tempMonster = Right;
            //tempAnim = Right.anim;
            

            dDigi.GetComponent<SpriteRenderer>().sprite = Right.image;
            
            //tempAnim.Play("CourageEggIdle");
            PlayerPrefs.SetString("rightID", rID);
            rightID = rID;
            hasRightP = true;

            Debug.Log("Created! it is a "+ rightID);

        }
        else
        {
            Debug.Log("You got a partner, it is being modified to "+ rID);
            BaseMonster currMonster = this.GetComponent<BaseMonster>();
            currMonster = Right;

            currMonster.GetComponent<SpriteRenderer>().sprite = Right.image;
            
            PlayerPrefs.SetString("rightID", rID);
            rightID = rID;
        }
        
    }

    public void GetLeftPartner(string lID)
    {
        BaseMonster Left = GetPartner(lID);
        Debug.Log("Get left partner called " + lID);
        Debug.Log(Left.Name);

        if (!hasLeftP)
        {
            Debug.Log("You do not have a left prtner on you, let me make one");
            GameObject lDigi = Instantiate(emptyMon, leftPos.transform.position, Quaternion.identity);
            gameManager.lPartner = lDigi;
            leftPartner = lDigi;
            
            lDigi.transform.parent = leftPos;

            BaseMonster tempMonster = lDigi.AddComponent<BaseMonster>() as BaseMonster;
            tempMonster = Left;
            

            lDigi.GetComponent<SpriteRenderer>().sprite = Left.image;
            PlayerPrefs.SetString("leftID", lID);
            leftID = lID;
            hasLeftP = true;

            Debug.Log("Created! is it a " + leftID);

        }else
        {
            Debug.Log("You got a partner, it is being modified to " + lID);
            BaseMonster currMonster = this.GetComponent<BaseMonster>();
            currMonster = Left;

            currMonster.GetComponent<SpriteRenderer>().sprite = Left.image;
            PlayerPrefs.SetString("leftId", lID);
            leftID = lID;
        }
    }


    public BaseMonster GetPartner(string id)
    {
        BaseMonster digi = new BaseMonster();
        Debug.Log("the id is "+ id);
        Debug.Log("Your base monster is loading " + digi.Name);
        foreach (BaseMonster Digimon in gameManager.allMonsters)
        {
            Debug.Log("START OF TEST DigiName: " + Digimon.ID + "Name: " + id);
            if (Digimon.ID == id)
            {
                Debug.Log("You checked the list, it may have been twice and you found " + Digimon.Name);
                digi = Digimon;

                //Debug.Log("Congratz it is a " + digi.name);
            }
        }

        Debug.Log("HEY LOOK AT ME I GOT YOUR PARTNER RIGHT HERE "+ digi.ID);
        //return digi;

        return digi;

    }

    public void SaveHunger()
    {
        PlayerPrefs.SetFloat("Hunger1", rightPartnerData._hunger);
        PlayerPrefs.SetFloat("Hunger2", leftPartnerData._hunger);
    }

    public void SaveHappiness()
    {
        PlayerPrefs.SetFloat("Happy1", rightPartnerData._happiness);
        PlayerPrefs.SetFloat("Happy2", leftPartnerData._happiness);
    }



    void MakeSingleton()
    {
        Debug.Log("MakeSingleton is called from Player");

        if (playerInstance != null)
        {
            Debug.Log("Game was not null and destroyed the object MakeSingleton in player");
            Destroy(gameObject);
        }
        else
        {
            Debug.Log("Not Destroy on load Active Make Singleton in player");
            playerInstance = this;
            DontDestroyOnLoad(gameObject);
        }
    }
}
