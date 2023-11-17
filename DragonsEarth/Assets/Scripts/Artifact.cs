using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.U2D;
//using System;
using UnityEngine.Events;
using UnityEngine.Networking;

public class Artifact : MonoBehaviour
{
    public string nameArtifact;
    public Stat stat = new Stat(0,0,0,0,0);
    public List<Skill> skills;
    public Sprite sprite;
    public int value;
    public TypeAtack typeAtack;
    public TypeWizard typeWizard;
}

public enum TypeAtack{
    all,
    melee,
    notMelee
}

public enum TypeWizard{
    all,
    wizard,
    noWizard
}