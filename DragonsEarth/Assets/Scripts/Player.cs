using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.U2D;
using System;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    public int id;
    public Color color;
    public Stat stat = new Stat(0,0,0,0,0);
    public Skill skill;
    public List<Unit> units;
    public List<Artifact> artifacts;
    public void StartPlayer(int idN, Color colorN) {
        id = idN;
        color = colorN;
        units = new List<Unit>();
        //todo
    }

    public List<Unit> GetUnitForStartRound(){
        //todo
        return units;
    }
}
