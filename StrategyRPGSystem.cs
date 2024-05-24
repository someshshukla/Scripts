using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StrategyRPGSystem : MonoBehaviour
{
    // Assignment 1 - Strategy RPG Class Design

    // Class: Sky Sentinel
    public class SkySentinel
    {
        public string unitName = "Sky Sentinel";
        public List<string> weapons = new List<string> { "Spear", "Crossbow", "Short Sword" };
        public List<Ability> abilities;

        public StatProfile stats;
        public int experience = 0;
        public int level = 1;

        //Sky Sentinel stats and abilities
        public SkySentinel()
        {
            abilities = new List<Ability>
            {
                new Ability("Skyward Strike", "Ascend to great heights and dive down, delivering a powerful strike that deals extra damage based on the height difference."),
                new Ability("Aerial Advantage", "Grants increased evasion and critical hit chance when attacking from a higher elevation than the target."),
                new Ability("Wind Barrier", "Creates a protective barrier of wind around themselves or an ally, reducing damage from ranged attacks for three turns.")
            };

            stats = new StatProfile(100, 50, 15, 10, 5, 10, 12, 5, 3);
        }

        // Update is called once per frame
        public void Update()
        {
            // Ability Controls
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                UseAbility(abilities[0]);
            }
            if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                UseAbility(abilities[1]);
            }
            if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                UseAbility(abilities[2]);
            }
        }

        public void GainExperience(int amount)
        {
            experience += amount;
            while (experience >= ExperienceToLevelUp(level))
            {
                LevelUp();
            }
        }

        void LevelUp()
        {
            experience -= ExperienceToLevelUp(level);
            level++;
            stats.HP += 10;
            stats.MP += 5;
            stats.ATK += 3;
            stats.DEF += 2;
            stats.MAG += 2;
            stats.RES += 3;
            stats.SPD += 2;
            if (level % 5 == 0) stats.MOV += 1;
            if (level % 3 == 0) stats.JMP += 1;

            Debug.Log(unitName + " leveled up to level " + level);
        }

        int ExperienceToLevelUp(int level)
        {
            if (level <= 5) return 100;
            if (level <= 10) return 200;
            return 300;
        }

        void UseAbility(Ability ability)
        {
            Debug.Log("Using ability: " + ability.Name + " - " + ability.Description);
            // actual ability logic
        }
    }

    // Assignment 2 - Strategy RPG Stats System - Systems Design

    // Stat Profile for Units
    public class StatProfile
    {
        public int HP;
        public int MP;
        public int ATK;
        public int DEF;
        public int MAG;
        public int RES;
        public int SPD;
        public int MOV;
        public int JMP;

        public StatProfile(int hp, int mp, int atk, int def, int mag, int res, int spd, int mov, int jmp)
        {
            HP = hp;
            MP = mp;
            ATK = atk;
            DEF = def;
            MAG = mag;
            RES = res;
            SPD = spd;
            MOV = mov;
            JMP = jmp;
        }
    }

    // Experience System
    public class ExperienceSystem
    {
        public int ExperienceToLevelUp(int level)
        {
            if (level <= 5) return 100;
            if (level <= 10) return 200;
            return 300;
        }
    }

    // Assignment 3 - Character Profile - Narrative Design

    // Character Profile Class
    public class CharacterProfile
    {
        public string Name;
        public string Backstory;
        public List<string> Dialogues;

        public CharacterProfile(string name, string backstory, List<string> dialogues)
        {
            Name = name;
            Backstory = backstory;
            Dialogues = dialogues;
        }

        public void PrintCharacterProfile()
        {
            Debug.Log($"Name: {Name}");
            Debug.Log($"Backstory: {Backstory}");
            Debug.Log("Dialogues:");
            foreach (var dialogue in Dialogues)
            {
                Debug.Log($"- {dialogue}");
            }
        }
    }

    // Main function to demonstrate usage
    void Start()
    {
        // Assignment 1 - Sky Sentinel class usage
        SkySentinel skySentinel = new SkySentinel();
        skySentinel.GainExperience(150); // Gain some experience
        skySentinel.Update(); // Update to simulate ability usage

        // Assignment 2 - Stat Profile and Experience System
        StatProfile unitStats = new StatProfile(100, 50, 15, 10, 5, 10, 12, 5, 3);
        ExperienceSystem expSystem = new ExperienceSystem();
        int expToLevelUp = expSystem.ExperienceToLevelUp(6);

        // Assignment 3 - Character Profile
        List<string> warriorDialogues = new List<string>
        {
            "For honor and glory!",
            "Victory is our destiny!",
            "By the might of my blade!"
        };

        CharacterProfile warrior = new CharacterProfile("Sir Valor", "A noble knight dedicated to protecting the realm.", warriorDialogues);
        warrior.PrintCharacterProfile();
    }
}
