using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.U2D;
using System;
using UnityEngine.Events;

public class Message : MonoBehaviour
{
    [SerializeField] Text message;
    [SerializeField] GameObject history;
    [SerializeField] Text textHistory;
    private string strLastRound = '\n'.ToString();
    private string strNowRound = '\n'.ToString();
    private string strMessage = "";
    private string strLook = "";
    private bool isUnitAction;

    public void OpenHistory(){
        history.SetActive(true);
        textHistory.GetComponent<Text>().text = strNowRound + strLastRound;
    }

    public void CloseHistory() {
        history.SetActive(false);
    }

    public void EndRound(int _round){
        strLastRound = strNowRound;
        strNowRound = '\n' + "Начало " + _round.ToString() + " раунда" + '\n';
        isUnitAction = false;
    }

    public void EndTurn(Unit _unit) {
        if(!isUnitAction){
            strNowRound = _unit.nameUnit + " бездействует. " + strNowRound;
        }
        isUnitAction = false;
    }

    private void OnMouseDown() {
        OpenHistory();
    }
}
