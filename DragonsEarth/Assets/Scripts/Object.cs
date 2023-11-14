using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.U2D;
//using System;
using UnityEngine.Events;

public class Object : MonoBehaviour
{
    public Sprite sprite;
    public string nameObject;
    public int idPlayer;
    public int value;
    public List<int> statRange = new List<int>(){0,0,0,0,0,0,0,0,0,0};
    public List<int> goldRange = new List<int>(){0,0};
    public List<Artifact> artifactsGift;
    public Skill skillGift;
    public Stat statGift = new Stat(0,0,0,0,0);
    public int goldGift;
    public Unit unitGift;
    public bool isGO;

    public void CalculateValueObject() {
        //todo
        value = goldGift + unitGift.cost * unitGift.cost + 6 * (3 * statGift.stats[0] + 1 * statGift.stats[1] + 2 * statGift.stats[2] + 1 * statGift.stats[3] + 1 * statGift.stats[4]) 
                + artifactsGift.Count * 10 + (isGO?100:0);
    }
}
