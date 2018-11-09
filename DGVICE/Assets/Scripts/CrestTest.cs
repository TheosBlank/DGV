using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;
using UnityEngine.UI;

public class CrestTest : MonoBehaviour {

    public static CrestTest CrestIns;
    public Main manager;
    public PlayerData player;
    

    
    
    public GameObject dpadDisplay;
    public Sprite[] dpadSprite;

    

    public string[] explorers;
    public string[] diplomats;
    public string[] sentinals;
    public string[] analysts;

    public int extrover = 0;
    public int introvert = 0;
    public int intuitive = 0;
    public int sensing = 0;
    public int thinking = 0;
    public int feeling = 0;
    public int perceiving = 0;
    public int judging = 0;

    public string mainCrest;
    public string secondaryCrest;

    public string _1stLetter;
    public string _2ndLetter;
    public string _3rdLetter;
    public string _4thLetter;

    void Awake()
    {
        MakeSingleton();
        Debug.Log("Awake at CrestTest getting inner and outer circle");
       
        
        dpadDisplay = GameObject.Find("DisplayDpadCrest");
        
    }

    /// <summary>
    //Only needed for OuterCircle Animations, Dissregard for further implementation
    /// </summary>
    
    public void CrestIniSet()
    {
        Debug.Log("CrestIniSet Called during Intro from Main");

        
        OuterCircleColorChanger(PlayerPrefs.GetString("OuterCircleColor"));
        Debug.Log("Your 1 color is" + PlayerPrefs.GetString("OuterCircleColor"));
        InnerCircleColorChanger(PlayerPrefs.GetString("InnerCircleColor"));
        Debug.Log("Your 2 color is" + PlayerPrefs.GetString("InnerCircleColor"));
        

        

    }

    


    public void ExtrovertIncrease()
    {
        extrover++;
    }

    public void IntrovertIncrease()
    {
        introvert++;
    }

    public void IntuitiveIncrease()
    {
        intuitive++;
    }

    public void SensingIncrease()
    {
        sensing++;
    }

    public void ThinkingIncrease()
    {
        thinking++;
    }

    public void FeelingIncrease()
    {
        feeling++;
    }

    public void PerceivingIncrease()
    {
        perceiving++;
    }

    public void JudgingIncrease()
    {
        judging++;
    }

    public void CrestResult()
    {
        if(extrover > introvert)
        {
            _1stLetter = "E";
            
        }else
        {
            _1stLetter = "I";
            
        }

        if(intuitive > sensing)
        {
            _2ndLetter = "N";
            
        }
        else
        {
            _2ndLetter = "S";
            
        }

        if(thinking > feeling)
        {
            _3rdLetter = "T";
           
        }
        else
        {
            _3rdLetter = "F";
            
        }

        if(perceiving > judging)
        {
            _4thLetter = "P";
            
        }else
        {
            _4thLetter = "J";
            
        }
        Debug.Log("your type is "+_1stLetter+_2ndLetter+_3rdLetter+_4thLetter);
    }

    public void DisplayMyCrest()
    {
        string personalityType = _1stLetter + _2ndLetter + _3rdLetter + _4thLetter;

        if (!PlayerPrefs.HasKey("personalityType"))
        {
            PlayerPrefs.SetString("personalityType", personalityType);
        }else
        {
            personalityType = PlayerPrefs.GetString("personalityType");
        }
        

        Debug.Log("your personality is " + personalityType);

        string crestType = "test";
        string polarCrest = "test";

        Debug.Log("main and second"+ crestType+polarCrest);


        switch (personalityType)
        {
            case "ISTP":
                crestType = explorers[Random.Range(0, explorers.Length)];
                polarCrest = diplomats[Random.Range(0, diplomats.Length)];
                break;
            case "ISFP":
                crestType = explorers[Random.Range(0, explorers.Length)];
                polarCrest = diplomats[Random.Range(0, diplomats.Length)];
                break;
            case "ESTP":
                crestType = explorers[Random.Range(0, explorers.Length)];
                polarCrest = diplomats[Random.Range(0, diplomats.Length)];
                break;
            case "ESFP":
                crestType = explorers[Random.Range(0, explorers.Length)];
                polarCrest = diplomats[Random.Range(0, diplomats.Length)];
                break;
            case "INFJ":
                crestType = diplomats[Random.Range(0, diplomats.Length)];
                polarCrest = explorers[Random.Range(0, explorers.Length)];
                break;
            case "INFP":
                crestType = diplomats[Random.Range(0, diplomats.Length)];
                polarCrest = explorers[Random.Range(0, explorers.Length)];
                break;
            case "ENFJ":
                crestType = diplomats[Random.Range(0, diplomats.Length)];
                polarCrest = explorers[Random.Range(0, explorers.Length)];
                break;
            case "ENFP":
                crestType = diplomats[Random.Range(0, diplomats.Length)];
                polarCrest = explorers[Random.Range(0, explorers.Length)];
                break;
            case "INTJ":
                crestType = analysts[Random.Range(0, analysts.Length)];
                polarCrest = sentinals[Random.Range(0, sentinals.Length)];
                break;
            case "INTP":
                crestType = analysts[Random.Range(0, analysts.Length)];
                polarCrest = sentinals[Random.Range(0, sentinals.Length)];
                break;
            case "ENTJ":
                crestType = analysts[Random.Range(0, analysts.Length)];
                polarCrest = sentinals[Random.Range(0, sentinals.Length)];
                break;
            case "ENTP":
                crestType = analysts[Random.Range(0, analysts.Length)];
                polarCrest = sentinals[Random.Range(0, sentinals.Length)];
                break;
            case "ISTJ":
                crestType = sentinals[Random.Range(0, sentinals.Length)];
                polarCrest = analysts[Random.Range(0, analysts.Length)];
                break;
            case "ISFJ":
                crestType = sentinals[Random.Range(0, sentinals.Length)];
                polarCrest = analysts[Random.Range(0, analysts.Length)];
                break;
            case "ESTJ":
                crestType = sentinals[Random.Range(0, sentinals.Length)];
                polarCrest = analysts[Random.Range(0, analysts.Length)];
                break;
            case "ESFJ":
                crestType = sentinals[Random.Range(0, sentinals.Length)];
                polarCrest = analysts[Random.Range(0, analysts.Length)];
                break;

        }

        Debug.Log("main and second after case "+crestType+polarCrest);

        OuterCircleColorChanger(crestType);
        InnerCircleColorChanger(polarCrest);
        

        //mainCrest = crestType;
        //secondaryCrest = polarCrest;

        StartCoroutine(CirclesColorChanger());

        string crestResult = crestType + "\n" + polarCrest;

        //manager.MainChart.SetStringVariable("Result", crestResult);
        
        Debug.Log("Your Type is "+ crestResult);

        
        if (!PlayerPrefs.HasKey("Initialized"))
        {
            Debug.Log("Player data created");
            PlayerPrefs.SetInt("Initialized", 1);
            PlayerPrefs.SetString("MainCrest", mainCrest);
            PlayerPrefs.SetString("SecondCrest", secondaryCrest);
            player.GetRightPartner(player.rightID);
            player.GetLeftPartner(player.leftID);        
        }
        else
        {
            player.GetRightPartner(player.rightID);
            player.GetLeftPartner(player.leftID);
            manager.LoadPlayerData();
        }
    }

    IEnumerator CirclesColorChanger()
    {

        Debug.Log("Courutine Start");
        if (!PlayerPrefs.HasKey("Initialized")) {
            Debug.Log("Courutine for ini");
            OuterCircleColorChanger(PlayerPrefs.GetString("OuterCircleColor"));
        yield return new WaitForSeconds(3);
        InnerCircleColorChanger(PlayerPrefs.GetString("InnerCircleColor"));
    }else{
            Debug.Log("Courutine for not Ini");
            OuterCircleColorChanger(PlayerPrefs.GetString("MainCrest"));
            yield return new WaitForSeconds(3);
            InnerCircleColorChanger(PlayerPrefs.GetString("SecondCrest"));
        }
    }

    public void OuterCircleColorChanger(string outerColor)//Outer Color is the First Crest and Main
    {
        Debug.Log("Outer Cicle Color is " + outerColor);

        switch (outerColor)
        {
            case "Courage":
                dpadDisplay.GetComponent<Image>().sprite = dpadSprite[0];
                if (!PlayerPrefs.HasKey("rightID"))
                {
                    player.rightID = "BOTAMONEGG";
                    PlayerPrefs.SetString("rightID", player.rightID);
                }
                break;
            case "Friendship":
                dpadDisplay.GetComponent<Image>().sprite = dpadSprite[1];
                if (!PlayerPrefs.HasKey("rightID"))
                {
                    player.rightID = "PUNIMONEGG";
                    PlayerPrefs.SetString("rightID", player.rightID);
                }
                break;
            case "Love":
                dpadDisplay.GetComponent<Image>().sprite = dpadSprite[2];
                if (!PlayerPrefs.HasKey("rightID"))
                {
                    player.rightID = "NYOKIMONEGG";
                    PlayerPrefs.SetString("rightID", player.rightID);
                }
                break;
            case "Knowledge":
                dpadDisplay.GetComponent<Image>().sprite = dpadSprite[5];
                if (!PlayerPrefs.HasKey("rightID"))
                {
                    player.rightID = "BUBBMONEGG";
                    PlayerPrefs.SetString("rightID", player.rightID);
                }
                break;
            case "Sincerity":
                dpadDisplay.GetComponent<Image>().sprite = dpadSprite[3];
                if (!PlayerPrefs.HasKey("rightID"))
                {
                    player.rightID = "YURAMONEGG";
                    PlayerPrefs.SetString("rightID", player.rightID);
                }
                break;
            case "Reliability":
                dpadDisplay.GetComponent<Image>().sprite = dpadSprite[4];
                if (!PlayerPrefs.HasKey("rightID"))
                {
                    player.rightID = "PITCHMONEGG";
                    PlayerPrefs.SetString("rightID", player.rightID);
                }
                break;
            case "Hope":
                dpadDisplay.GetComponent<Image>().sprite = dpadSprite[6];
                if (!PlayerPrefs.HasKey("rightID"))
                {
                    player.rightID = "POYOMONEGG";
                    PlayerPrefs.SetString("rightID", player.rightID);
                }
                break;
            case "Light":
                dpadDisplay.GetComponent<Image>().sprite = dpadSprite[7];
                if (!PlayerPrefs.HasKey("rightID"))
                {
                    player.rightID = "YUKIBOTAMONEGG";
                    PlayerPrefs.SetString("rightID", player.rightID);
                }
                break;
            case "Kindness":
                dpadDisplay.GetComponent<Image>().sprite = dpadSprite[8];
                if (!PlayerPrefs.HasKey("rightID"))
                {
                    player.rightID = "LEAFMONEGG";
                    PlayerPrefs.SetString("rightID", player.rightID);
                }
                break;
        }

        PlayerPrefs.SetString("OuterCircleColor", outerColor);
        
        Debug.Log("You created a rightID with " + PlayerPrefs.GetString("rightID") + " in it");
        Debug.Log("saved outer color "+ PlayerPrefs.GetString("OuterCircleColor"));
    }

    public void InnerCircleColorChanger(string innerColor)
    {

        Debug.Log("Inner Cicle Color is " + innerColor);

        switch (innerColor)
        {
            case "Courage":
                if (!PlayerPrefs.HasKey("leftID"))
                {
                    player.leftID = "BOTAMONEGG";
                    PlayerPrefs.SetString("leftID", player.leftID);
                }
                break;
            case "Friendship":
                if (!PlayerPrefs.HasKey("leftID"))
                {
                    player.leftID = "PUNIMONEGG";
                    PlayerPrefs.SetString("leftID", player.leftID);
                }
                break;
            case "Love":
                if (!PlayerPrefs.HasKey("leftID"))
                {
                    player.leftID = "NYOKIMONEGG";
                    PlayerPrefs.SetString("leftID", player.leftID);
                }
                break;
            case "Knowledge":
                if (!PlayerPrefs.HasKey("leftID"))
                {
                    player.leftID = "BUBBMONEGG";
                    PlayerPrefs.SetString("leftID", player.leftID);
                }
                break;
            case "Sincerity":
                if (!PlayerPrefs.HasKey("leftID"))
                {
                    player.leftID = "YURAMONEGG";
                    PlayerPrefs.SetString("leftID", player.leftID);
                }
                break;
            case "Reliability":
                if (!PlayerPrefs.HasKey("leftID"))
                {
                    player.leftID = "PITCHMONEGG";
                    PlayerPrefs.SetString("leftID", player.leftID);
                }
                break;
            case "Hope":
                if (!PlayerPrefs.HasKey("leftID"))
                {
                    player.leftID = "POYOMONEGG";
                    PlayerPrefs.SetString("leftID", player.leftID);
                }
                break;
            case "Light":
                if (!PlayerPrefs.HasKey("leftID"))
                {
                    player.leftID = "YUKIBOTAMONEGG";
                    PlayerPrefs.SetString("leftID", player.leftID);
                }
                break;
            case "Kindness":
                if (!PlayerPrefs.HasKey("leftID"))
                {
                    player.leftID = "LEAFMONEGG";
                    PlayerPrefs.SetString("leftID", player.leftID);
                }
                break;
        }

        PlayerPrefs.SetString("InnerCircleColor", innerColor);
        Debug.Log("your second partner is " + PlayerPrefs.GetString("leftID"));
        Debug.Log("you saced inner color "+ PlayerPrefs.GetString("InnerCircleColor"));
    }

    void MakeSingleton()
    {
        Debug.Log("MakeSingleton is called from Main");

        if (CrestIns != null)
        {
            Debug.Log("Game was not null and destroyed the object MakeSingleton in Main");
            Destroy(gameObject);
        }
        else
        {
            Debug.Log("Not Destroy on load Active Make Singleton in Main");
            CrestIns = this;
            DontDestroyOnLoad(gameObject);
        }
    }


}
