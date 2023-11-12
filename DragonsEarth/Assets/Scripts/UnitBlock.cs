using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.U2D;
using System;
using UnityEngine.Events;

public class UnitBlock : MonoBehaviour
{
    [SerializeField] GameCont gameCont;
    [SerializeField] GameObject fon;
    [SerializeField] GameObject color;
    [SerializeField] GameObject damage;
    [SerializeField] GameObject initiative;
    [SerializeField] GameObject strength;
    [SerializeField] Text textDamage;
    [SerializeField] Text textInitiative;
    [SerializeField] Text textStrength;
    [SerializeField] Text textRound;
    [SerializeField] Sprite empty;
    private Unit unit;

    public void ShowEmpty() {
        fon.GetComponent<Image>().sprite = empty;
        color.GetComponent<Image>().color = new Color(0,0,0,0);
        damage.SetActive(false);
        initiative.SetActive(false);
        strength.SetActive(false);
        textRound.GetComponent<Text>().text = "";
        unit = null;
    }

    public void ShowUnit(Unit _unit){
        unit = _unit;
        UnitData _unitData = unit.GetUnitData();
        fon.GetComponent<Image>().sprite = unit.sprite;
        color.GetComponent<Image>().color = unit.idPlayer == 0 ? new Color(1,0,0,0.15f) : new Color(0,0,1,0.15f);
        damage.SetActive(true);
        initiative.SetActive(true);
        strength.SetActive(true);
        textRound.GetComponent<Text>().text = "";
        textDamage.GetComponent<Text>().text = _unitData.damage.ToString();
        textInitiative.GetComponent<Text>().text = _unitData.initiative.ToString();
        textStrength.GetComponent<Text>().text = _unitData.strength.ToString();
    }

    public void ShowRound(int _round){
        unit = null;
        fon.GetComponent<Image>().sprite = empty;
        color.GetComponent<Image>().color = new Color(0,0,0,0);
        damage.SetActive(false);
        initiative.SetActive(false);
        strength.SetActive(false);
        textRound.GetComponent<Text>().text = _round.ToString() + '\n' + "Раунд";
    }
}
