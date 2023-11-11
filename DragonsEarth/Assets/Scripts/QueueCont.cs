using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.U2D;
using System;
using UnityEngine.Events;

public class QueueCont : MonoBehaviour
{
    [SerializeField] GameCont gameCont;
    [SerializeField] List<Button> unitBlocks; //todo
    [SerializeField] GameObject fon;
    
    public int idPlayerTurn;

    private int idFirstUnitBlock;

    public void StartTest() {
        idPlayerTurn = 0;
        UpdateShow();
    }

    public void ClickEndTurn() {
        //todo
        switch(gameCont.statusGame){
            case StatusGame.test: idPlayerTurn = (idPlayerTurn + 1) % 2; break;
            default: break;
        }
        UpdateShow();
    }

    private void UpdateShow() {
        fon.GetComponent<Image>().color = gameCont.players[idPlayerTurn].color;
    }
}
