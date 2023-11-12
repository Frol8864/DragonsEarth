using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.U2D;
using System;
using UnityEngine.Events;

public class ButtonEndRound : MonoBehaviour
{
    [SerializeField] QueueCont queueCont;
    public void ClickEndTurn(){
        queueCont.EndTurn();
    }
}
