using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BaseMonster : MonoBehaviour {

    public string Name;
    public Sprite image;
    //public Animator anim;


    public Stage stage;
    public Rarity rarity;
    public MonsterAttribute attribute;
    public MonsterType type;
    public MonsterField field;

    public string ID;

    public float _hunger;
    public float _happiness;

    public bool canEvol;
    public DigiEvolution evolution;

    //public Stat _hungerStat;
    //public Stat _happyStat;

    private bool _serverTime;

	// Use this for initialization
	void Start () {
        //DateTime now = Convert.ToDateTime("06/12/2018 09:00:00");
        //PlayerPrefs.SetString("then", "06 / 1 / 2018 09:05:00");
        
	}
	
	// Update is called once per frame
	void Update () {
        
	}

   

    public float hunger
    {
        get { return _hunger; }
        set { _hunger = value; }
    }

    public float happiness
    {
        get { return _happiness; }
        set { _happiness = value; }
    }
}

public enum Stage
{
    Egg,
    Baby,
    InTraining,
    Rookie,
    Champion,
    Ultimate,
    Mega
}

public enum Rarity
{
    E1,
    E2,
    E3,
    B1,
    B2,
    B3,
    T1,
    T2,
    T3,
    R1,
    R2,
    R3,
    C1,
    C2,
    C3,
    U1,
    U2,
    U3,
    M1,
    M2,
    M3
}

public enum MonsterAttribute

{
    Free,
    Data,
    Vaccine,
    Virus
}

public enum MonsterType
{
    NineThousand,
    Alien,
    Amphibian,
    AncientAquaticBeastMan,
    AncientBeast, 
    AncientBirdMan, 
    AncientBird, 
    AncientCrustacean, 
    AncientDragonMan, 
    AncientDragon, 
    AncientFish, 
    AncientHolyKnight, 
    AncientInsect, 
    AncientMutant, 
    AncientMythicalBeast, 
    AncientOre, 
    AncientPlant, 
    Ancient,
    Angel,
    Ankylosaur, 
    AquaticBeastMan, 
    AquaticMammal, 
    Aquatic,
    Archangel,
    Armor, 
    ArtDigimon,
    ArtificialFallenAngel,
    Avatar, 
    BabyDragon, 
    BeastDragon, 
    BeastKnight, 
    BeastMan, 
    Beast, 
    BewitchingBeast, 
    BewitchingBird, 
    BirdMan, 
    Bird, 
    Braun, 
    Bulb,
    Card,
    Ceratopsian,
    Cherub,
    Chick,
    Composite,
    Crustacean,
    Cyborg,
    DarkDragon, 
    DarkKnight, 
    DemonBeast, 
    DemonDragon, 
    DemonGod, 
    DemonLord, 
    DemonMan, 
    Devil, 
    Dinosaur, 
    Dominion, 
    DragonMan, 
    Dragon, 
    DragonWarrior,
    EarthDragon, 
    Enhancement, 
    EvilDragon,
    Fairy, 
    FallenAngel, 
    FlameDragon, 
    Flame, 
    Food, 
    Galaxy, 
    Ghost, 
    GiantBird, 
    GodBeast, 
    GodMan, 
    HolyBeast, 
    HolyBird, 
    HolyDragon, 
    HolyKnight, 
    HolySword, 
    Hybrid,
    IceSnow, 
    IcySnow, 
    Insect, 
    InsectivorousPlant, 
    Invade, 
    Larva, 
    LCD, 
    Lesser, 
    LightDragon, 
    LongNeckedDragon, 
    MachineDragon, 
    Machine, 
    MagicWarrior, 
    Major, 
    Mammal, 
    MarineAnimal, 
    MarineMan, 
    Mine, 
    Mineral, 
    Minor, 
    Mollusk, 
    Monk, 
    MusicalInstrument, 
    Mutant, 
    MythicalBeast, 
    MythicalDragon, 
    NoData, 
    OceanDragon, 
    Oni, 
    Ophan, 
    Ore, 
    Parasite, 
    Perfect, 
    PhantomDragon, 
    Plant, 
    Plesiosaur, 
    Pterosaur, 
    Puppet, 
    RareAnimal, 
    ReptileMan, 
    Reptile, 
    RockDragon, 
    Rock,
    Seed, 
    Seraph, 
    Shellfish, 
    Skeleton, 
    SkilledAngel, 
    SkyDragon, 
    Slime, 
    SmallAngel, 
    SmallBird, 
    SmallDevil, 
    SmallDragon, 
    Smoke, 
    Spirit, 
    Stegosaur, 
    SuperMajor, 
    SyntheticBeast, 
    Tathāgata, 
    Toy, 
    TropicalFish, 
    Unanalyzable, 
    Unbalanced, 
    Undead, 
    Unique, 
    Unknown, 
    Virtue, 
    Warrior, 
    Weapon, 
    WickedGod 


}

public enum MonsterField
{
    NatureSpirits,
    DeepSavers,
    NightmareSoldiers,
    WindGuardians,
    MetalEmpire,
    DarkArea,
    VirusBusters,
    DragonsRoar,
    JungleTroopers,
    Unknown
}

[System.Serializable]
public class DigiEvolution
{
    public BaseMonster[] nextEvolution;
}
