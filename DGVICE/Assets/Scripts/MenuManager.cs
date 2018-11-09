using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Fungus;

public class MenuManager : MonoBehaviour {

    public static MenuManager MenuInstance;
    public Flowchart mainChart;
    public Main manager;
    public CrestTest crest;
    public PlayerData player;

    public Button update;

    public GameObject DisplayerTop; //The display that hold the Crest and Name, Level
    public ParticleSystem BackgroundEmission;

    


    void Awake()
    {
        MakeSingleton();
        manager = GameObject.FindGameObjectWithTag("GameController").GetComponent<Main>();
        crest = GameObject.FindGameObjectWithTag("GameController").GetComponent<CrestTest>();
    }

	// Use this for initialization
	void Start () {
        UIOnBackgroundEffectOn();
    }
	
	// Update is called once per frame
	void Update () {
        
	}

    void MakeSingleton()
    {
        Debug.Log("MakeSingleton is called from menu");

        if (MenuInstance != null)
        {
            Debug.Log("Game was not null and destroyed the object MakeSingleton in menu");
            Destroy(gameObject);
        }
        else
        {
            Debug.Log("Not Destroy on load Active Make Singleton in menu");
            MenuInstance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

   

    public void FeedDigimon(float food)
    {
        

        if(player.rightPartnerData._hunger < 100)
        {
            player.rightPartnerData._hunger += food;
            player.rightPartnerData._happiness += 10;

            if(player.rightPartnerData._hunger > 100)
            {
                player.rightPartnerData._hunger = 100;
            }
            if(player.rightPartnerData._happiness > 100)
            {
                player.rightPartnerData._happiness = 100;
            }
        }

        if(player.leftPartnerData._hunger < 100)
        {
            player.leftPartnerData._hunger += food;
            player.leftPartnerData._happiness += 10;

            if(player.leftPartnerData._hunger > 100)
            {
                player.leftPartnerData._hunger = 100;
            }
            if (player.leftPartnerData._happiness > 100)
            {
                player.leftPartnerData._happiness = 100;
            }
        }

        player.SaveHunger();
        player.SaveHappiness();
    }


    public void UIOnBackgroundEffectOn()
    {

        BackgroundEmission.Play();
        //EnableUI();

        //OuterCircleText.transform.Rotate(Vector3.forward * -90);
        
       
    }

    public void DisableUI()
    {
        mainChart.ExecuteBlock("DisableUI");
    }

    public void EnableUI()
    {
        mainChart.ExecuteBlock("UIEnabled");
    }

}
