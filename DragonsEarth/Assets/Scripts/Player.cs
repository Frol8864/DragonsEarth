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
    public Stat stat;
    public Skill skill;
    public void StartPlayer(int idN, Color colorN) {
        id = idN;
        color = colorN;
        //todo
    }
}
