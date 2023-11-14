using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.U2D;
//using System;
using UnityEngine.Events;

public class LibaryObject : MonoBehaviour
{
    [SerializeField] GameCont gameCont;
    [SerializeField] LibaryUnit libaryUnit;
    [SerializeField] SpriteAtlas spritesObject;
    private List<CodeUnit> codeUnits = new List<CodeUnit>() {
        CodeUnit.angel,
        CodeUnit.devil,
        CodeUnit.farmer,
        CodeUnit.crossbowman,
        CodeUnit.priest,
        CodeUnit.witcher,
        CodeUnit.griffin,
        CodeUnit.paladin,
        CodeUnit.knight,
        CodeUnit.hobbit,
        CodeUnit.fairy,
        CodeUnit.sabermaster,
        CodeUnit.archer,
        CodeUnit.druid,
        CodeUnit.unicorn,
        CodeUnit.pegasus,
        CodeUnit.ent,
        CodeUnit.skeleton,
        CodeUnit.ghost,
        CodeUnit.zombie,
        CodeUnit.werewolf,
        CodeUnit.vampire,
        CodeUnit.lich,
        CodeUnit.corpseeater,
        CodeUnit.deathknight,
        CodeUnit.imp,
        CodeUnit.magog,
        CodeUnit.heretic,
        CodeUnit.succubus,
        CodeUnit.demon,
        CodeUnit.ifrit,
        CodeUnit.hellhound,
        CodeUnit.blacksmith,
        CodeUnit.javelinthrower,
        CodeUnit.gnome,
        CodeUnit.valkyrie,
        CodeUnit.giant,
        CodeUnit.shaman,
        CodeUnit.stoning,
        CodeUnit.polarbear,
        CodeUnit.goblin,
        CodeUnit.troll,
        CodeUnit.hawk,
        CodeUnit.dogman,
        CodeUnit.centaur,
        CodeUnit.orc,
        CodeUnit.ogre,
        CodeUnit.cyclop,
        CodeUnit.gremlin,
        CodeUnit.golem,
        CodeUnit.gargoyle,
        CodeUnit.mage,
        CodeUnit.magician,
        CodeUnit.titan,
        CodeUnit.gin,
        CodeUnit.phoenix,
        CodeUnit.troglodyte,
        CodeUnit.naga,
        CodeUnit.harpy,
        CodeUnit.jellyfish,
        CodeUnit.minotaur,
        CodeUnit.manticore,
        CodeUnit.wyvern,
        CodeUnit.hydra,
        CodeUnit.bonedragon,
        CodeUnit.poisonousdragon,
        CodeUnit.firedragon,
        CodeUnit.horneddragon,
        CodeUnit.stonedragon
    };

    public Object GetObject(CodeObject codeObject){
        Object Object = new Object();
        Object.idPlayer = -1;
        Object.sprite = spritesObject.GetSprite(codeObject.ToString());
        switch (codeObject) {
            case CodeObject.prison:
                Object.nameObject = "Тюрьма";
                Object.statRange = new List<int>(){0,0,0,0,0,0,0,0,0,0};
                Object.goldRange = new List<int>(){0,0};
                Object.artifactsGift = new List<Artifact>();
                Object.skillGift = new Skill();
                Object.unitGift = new Unit();
                Object.unitGift = libaryUnit.GetUnit(codeUnits[Random.Range(0,codeUnits.Count)]);
            break;
            case CodeObject.blacksmith:
                Object.nameObject = "Кузня";
                Object.statRange = new List<int>(){0,0,1,4,1,4,0,0,0,0};
                Object.goldRange = new List<int>(){0,0};
                Object.artifactsGift = new List<Artifact>();
                Object.skillGift = new Skill();
                Object.unitGift = new Unit();
            break;
            case CodeObject.towermagiciansson:
                Object.nameObject = "Башня Магов";
                Object.statRange = new List<int>(){0,0,0,0,0,0,1,6,0,0};
                Object.goldRange = new List<int>(){0,0};
                Object.artifactsGift = new List<Artifact>();
                Object.skillGift = new Skill();
                Object.unitGift = new Unit();
            break;
            case CodeObject.stable:
                Object.nameObject = "Конюшня";
                Object.statRange = new List<int>(){0,0,0,0,0,0,0,0,1,4};
                Object.goldRange = new List<int>(){0,0};
                Object.artifactsGift = new List<Artifact>();
                Object.skillGift = new Skill();
                Object.unitGift = new Unit();
            break;
            case CodeObject.lifetree:
                Object.nameObject = "Древо Жизни";
                Object.statRange = new List<int>(){1,4,0,0,0,0,0,0,0,0};
                Object.goldRange = new List<int>(){0,0};
                Object.artifactsGift = new List<Artifact>();
                Object.skillGift = new Skill();
                Object.unitGift = new Unit();
            break;
            case CodeObject.bank:
                Object.nameObject = "Банк Гоблинов";
                Object.statRange = new List<int>(){0,0,0,0,0,0,0,0,0,0};
                Object.goldRange = new List<int>(){15,45};
                Object.artifactsGift = new List<Artifact>();
                Object.skillGift = new Skill();
                Object.unitGift = new Unit();
            break;
            case CodeObject.dragondungeon:
                Object.nameObject = "Подземелье Драконов";
                Object.statRange = new List<int>(){0,0,0,0,0,0,0,0,0,0};
                Object.goldRange = new List<int>(){10,30};
                Object.artifactsGift = new List<Artifact>(){
                    new Artifact(),
                    new Artifact(),
                    new Artifact()
                };
                Object.skillGift = new Skill();
                Object.unitGift = new Unit();
            break;
            case CodeObject.crypt:
                Object.nameObject = "Склеп";
                Object.statRange = new List<int>(){0,0,0,0,0,0,0,0,0,0};
                Object.goldRange = new List<int>(){5,10};
                Object.artifactsGift = new List<Artifact>(){
                    new Artifact()
                };
                Object.skillGift = new Skill();
                Object.unitGift = new Unit();
            break;
            case CodeObject.temple:
                Object.nameObject = "Храм";
                Object.statRange = new List<int>(){0,0,0,0,0,0,0,0,0,0};
                Object.goldRange = new List<int>(){10,20};
                Object.artifactsGift = new List<Artifact>(){
                    new Artifact(),
                    new Artifact()
                };
                Object.skillGift = new Skill();
                Object.unitGift = new Unit();
            break;
            case CodeObject.arsenal:
                Object.nameObject = "Заброшенная тележка";
                Object.statRange = new List<int>(){0,0,0,0,0,0,0,0,0,0};
                Object.goldRange = new List<int>(){0,0};
                Object.artifactsGift = new List<Artifact>(){
                    new Artifact(),
                    new Artifact()
                };
                Object.skillGift = new Skill();
                Object.unitGift = new Unit();
            break;

            default: break;
        }

        return Object;
    }
}

public enum CodeObject{
    prison,
    blacksmith,
    towermagiciansson,
    stable,
    lifetree,
    bank,
    dragondungeon,
    crypt,
    temple,
    arsenal,
}
