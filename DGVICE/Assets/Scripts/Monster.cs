using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;
using UnityEngine.UI;

public class Monster : MonoBehaviour
{

    public Main manager;
    public MonsterStage stage;




    void Awake()
    {

    }

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {


    }
}

public enum MonsterStage
{
    Egg,
    Baby,
    InTraining,
    Rookie,
    Champion,
    Ultimate,
    Mega
}