using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.U2D;
using System;
using UnityEngine.Events;

public class Unit : MonoBehaviour
{
    public GameCont gameCont;
    public CodeUnit codeUnit;
    public Stat stat = new Stat(0,0,0,0,0);
    public int strongNow;
    public Sprite sprite;
    public string nameUnit;
    public int id;
    public int idPlayer;
    public int cost;
    public Skill skill;
    public bool isWizard;
    public bool isMelee; 
    public List<Artifact> artifacts = new List<Artifact>();

    public UnitData GetUnitData(GameCont gameCont){
        Stat statArtifact = GetStatArtifact();
        Stat statPlayer = new Stat(0,0,0,0,0);
        if(idPlayer != -1){
            statPlayer = gameCont.players[idPlayer].stat;
        }
        return new UnitData(){
            statAll = new Stat(stat.stats[0] + statArtifact.stats[0] + statPlayer.stats[0],stat.stats[1] + statArtifact.stats[1] + statPlayer.stats[1],
                                stat.stats[2] + statArtifact.stats[2] + statPlayer.stats[2],stat.stats[3] + statArtifact.stats[3] + statPlayer.stats[3],
                                stat.stats[4] + statArtifact.stats[4] + statPlayer.stats[4]),
            strongNowAll = strongNow,
            strength = strongNow + stat.stats[2] + statArtifact.stats[2] + statPlayer.stats[2],
            initiative = strongNow + stat.stats[4] + statArtifact.stats[4] + statPlayer.stats[4],
            damage = stat.stats[1] + strongNow + statArtifact.stats[1] + statPlayer.stats[1],
            wizard = strongNow + stat.stats[3] + statArtifact.stats[3] + statPlayer.stats[3],
            idPlayer = idPlayer,
            isMelee = isMelee,
            nameUnit = nameUnit
        };
    }

    public void StartStrongNow() {
        strongNow = stat.stats[0];
    }

    public int GetSpeed(){
        //Debug.Log(codeUnit);
        Stat statArtifact = GetStatArtifact();
        return stat.stats[4] + statArtifact.stats[4];
    }

    public void AddArtifact(Artifact artifact){
        artifacts.Add(artifact);
        //todo
        strongNow+=artifact.stat.stats[0];
    }

    private Stat GetStatArtifact(){
        Stat _stat = new Stat(0,0,0,0,0);
        for(int i = 0; i < artifacts.Count; i++) {
            for(int j = 0; j < _stat.stats.Count; j++) {
                _stat.stats[j]+=artifacts[i].stat.stats[j];
            }
        }
        //Debug.Log(_stat.stats[4]);
        return _stat;
    }
}

public class UnitData{
    public Stat statAll;
    public int strongNowAll;
    public int strength;
    public int initiative;
    public int damage;
    public int wizard;
    public int idPlayer;
    public bool isMelee;
    public string nameUnit;
}