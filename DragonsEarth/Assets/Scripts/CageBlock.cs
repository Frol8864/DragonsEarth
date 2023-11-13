using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.U2D;
using System;
using UnityEngine.Events;

public class CageBlock : MonoBehaviour
{
    [SerializeField] GameObject turnColor;
    [SerializeField] GameObject playerColor;
    [SerializeField] GameObject fon;
    [SerializeField] GameObject spriteObject;
    [SerializeField] GameObject spriteUnit;
    [SerializeField] GameObject damage;
    [SerializeField] GameObject typeAtack;
    [SerializeField] GameObject strength;
    [SerializeField] GameObject wizard;
    [SerializeField] GameObject dead;
    [SerializeField] Text textDamage;
    [SerializeField] Text textStrength;
    [SerializeField] Text textwizard;
    [SerializeField] Text textAtack;
    [SerializeField] Sprite meleeAtack;
    [SerializeField] Sprite notMeleeAtack;
    [SerializeField] Message message;

    private Unit unit;
    private Object Object;
    private bool isActive;
    private bool isGuard;

    public int x;
    public int y;

    public void AddObject(CageBlockData _cageBlockData) {
        isGuard = true;
        unit = _cageBlockData.unit;
        Object = _cageBlockData.Object;
        UnitData _unitData = unit.GetUnitData();
        turnColor.GetComponent<Image>().color = new Color(0,0,0,0);
        playerColor.SetActive(false);
        //fon.GetComponent<Image>().sprite = unit.sprite;
        spriteObject.GetComponent<Image>().sprite = Object.sprite;
        spriteUnit.GetComponent<Image>().sprite = unit.sprite;
        damage.SetActive(true);
        typeAtack.GetComponent<Image>().sprite = unit.isMelee ? meleeAtack : notMeleeAtack;
        strength.SetActive(true);
        if(unit.isWizard){
            wizard.SetActive(true);
            textwizard.GetComponent<Text>().text = _unitData.wizard.ToString();
        } else {
            wizard.SetActive(false);
        }
        dead.SetActive(false);
        textDamage.GetComponent<Text>().text = _unitData.damage.ToString();
        textStrength.GetComponent<Text>().text = _unitData.strength.ToString();
        textAtack.GetComponent<Text>().text = "";
    }

    public void StartCageBlock(int _x, int _y) {
        x = _x;
        y = _y;
    }

    private void OnMouseEnter() {
        if (isGuard)
            message.LookCageBlock(new CageBlockData(){
                unit = unit,
                Object = Object
            });
    }

    private void OnMouseExit() {
        message.NotLookCageBlock();
    }

}

public class CageBlockData {
    public Unit unit;
    public Object Object;
}