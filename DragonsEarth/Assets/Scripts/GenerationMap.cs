using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.U2D;
//using System;
using UnityEngine.Events;
using UnityEngine.Networking;

public class GenerationMap : MonoBehaviour
{
    [SerializeField] LibaryUnit libaryUnit;
    [SerializeField] LibaryObject libaryObject;
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

    private List<CodeObject> codeObjects = new List<CodeObject>() {
        CodeObject.prison,
        CodeObject.blacksmith,
        CodeObject.towermagiciansson,
        CodeObject.stable,
        CodeObject.lifetree,
        CodeObject.bank,
        CodeObject.dragondungeon,
        CodeObject.crypt,
        CodeObject.temple,
        CodeObject.arsenal,
    };
    public CageBlockData GetCageBlockData(){
        //todo
        return new CageBlockData(){
            unit = libaryUnit.GetUnit(codeUnits[Random.Range(0, codeUnits.Count)]),
            Object = libaryObject.GetObject(codeObjects[Random.Range(0, codeObjects.Count)])
        };
    }
}
