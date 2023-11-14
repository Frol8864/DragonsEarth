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
    public int value;
}
