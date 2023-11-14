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
    [SerializeField] LibraryArtifact libraryArtifact;
    private int maxStatGuardUnit = 4;
    private int deltaValueGuard = 7;
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
        CodeObject.prison,
        CodeObject.prison,
        
        CodeObject.blacksmith,
        CodeObject.towermagiciansson,
        CodeObject.stable,
        CodeObject.lifetree,
        
        CodeObject.blacksmith,
        CodeObject.towermagiciansson,
        CodeObject.stable,
        CodeObject.lifetree,
        
        CodeObject.blacksmith,
        CodeObject.towermagiciansson,
        CodeObject.stable,
        CodeObject.lifetree,
        
        CodeObject.bank,
        CodeObject.dragondungeon,
        CodeObject.crypt,
        CodeObject.temple,
        CodeObject.arsenal,
        
        CodeObject.bank,
        CodeObject.dragondungeon,
        CodeObject.crypt,
        CodeObject.temple,
        CodeObject.arsenal,
    };

    private List<CodeObject> codeObjectsHigh = new List<CodeObject>() {
        CodeObject.blacksmith,
        CodeObject.towermagiciansson,
        CodeObject.stable,
        CodeObject.lifetree,
        
        CodeObject.dragondungeon,
        CodeObject.temple,

        CodeObject.dragondungeon,
        CodeObject.temple,

        CodeObject.dragondungeon,
        CodeObject.temple,
    };
    
    private List<UnitGuard> unitGuards = new List<UnitGuard>();
    public CageBlockData GetCageBlockData(int idCageBlock){
        Object _Object = new Object();
        
        if(idCageBlock == 27 || idCageBlock == 67) {
            _Object = libaryObject.GetGO();
        } else {
            if (idCageBlock <= 29 || idCageBlock >= 65) {
                _Object = libaryObject.GetObject(codeObjects[Random.Range(0, codeObjects.Count)]);
                _Object.goldGift = Random.Range(_Object.goldRange[0], _Object.goldRange[1]);
                _Object.statGift = new Stat(Random.Range(_Object.statRange[0], _Object.statRange[1]),
                                        Random.Range(_Object.statRange[2], _Object.statRange[3]),
                                        Random.Range(_Object.statRange[4], _Object.statRange[5]),
                                        Random.Range(_Object.statRange[6], _Object.statRange[7]),
                                        Random.Range(_Object.statRange[8], _Object.statRange[9]));
            } else {
                _Object = libaryObject.GetObject(codeObjectsHigh[Random.Range(0, codeObjectsHigh.Count)]);
                _Object.goldGift = Random.Range(_Object.goldRange[0] * 2, _Object.goldRange[1]);
                _Object.statGift = new Stat(Random.Range(_Object.statRange[0] * 2, _Object.statRange[1]),
                                        Random.Range(_Object.statRange[2] * 2, _Object.statRange[3]),
                                        Random.Range(_Object.statRange[4] * 2, _Object.statRange[5]),
                                        Random.Range(_Object.statRange[6] * 2, _Object.statRange[7]),
                                        Random.Range(_Object.statRange[8] * 2, _Object.statRange[9]));
            }
        }

        _Object.CalculateValueObject();
        _Object.nameObject += " " + _Object.value;
        
        List<UnitGuard> _unitGuards = GetUnitGuards(_Object.value);
        UnitGuard _unitGuard = _unitGuards[Random.Range(0, _unitGuards.Count)];
        Unit _unit = libaryUnit.GetUnit(_unitGuard.codeUnit);
        _unit.AddArtifact(_unitGuard.artifactGuard);


        return new CageBlockData(){
            unit = _unit,
            Object = _Object
        };
    }

    private List<UnitGuard> GetUnitGuards(int valueObject){
        List<UnitGuard> _unitGuards = new List<UnitGuard>();
        foreach(UnitGuard _unitGuard in unitGuards) {
            if(valueObject - deltaValueGuard <= _unitGuard.value && _unitGuard.value <= valueObject + deltaValueGuard){
                _unitGuards.Add(_unitGuard);
            }
        }
        return _unitGuards;
    }

    public void GenerationUnitGuards(){
        for(int iU = 0; iU < codeUnits.Count; iU++) {
            for(int iS = 0; iS < 1; iS++) {
                for(int iAt = 0; iAt < maxStatGuardUnit; iAt++) {
                    for(int iAr = 0; iAr < maxStatGuardUnit; iAr++) {
                        for(int iW = 0; iW < 1; iW++) {
                            UnitGuard _unitGuard = new UnitGuard(){
                                codeUnit = codeUnits[iU],
                                artifactGuard = libraryArtifact.GetArtifactGuard(iS,iAt,iAr+3,iW,5),
                                libaryUnit = libaryUnit
                            };
                            _unitGuard.CalculateValueGuard();
                            unitGuards.Add(_unitGuard);
                        }   
                    }
                }
            }
        }
    }
}

public class UnitGuard{
    public int value;
    public CodeUnit codeUnit;
    public Artifact artifactGuard;
    public LibaryUnit libaryUnit;

    public void CalculateValueGuard(){
        Unit _unit = libaryUnit.GetUnit(codeUnit);
        _unit.AddArtifact(artifactGuard);
        UnitData _unitData = _unit.GetUnitData();
        //todo
        value = (_unitData.strength-3)  * (_unit.isMelee ? _unitData.damage : _unitData.damage / 2 * 3);
    }
}
