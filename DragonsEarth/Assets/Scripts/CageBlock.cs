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

    public Unit unit;
    public bool isUnit;
    public Object Object;
    private bool isGuard;
    private StatusActive statusActive;
    private bool isActive;
    private int id;
    public Map map;

    public void AddObject(CageBlockData _cageBlockData, Map _map, int _id) {
        map = _map;
        id = _id;
        isGuard = true;
        isUnit = true;
        isActive = false;
        statusActive = StatusActive.none;
        dead.SetActive(false);
        textAtack.GetComponent<Text>().text = "";
        unit = _cageBlockData.unit;
        Object = _cageBlockData.Object;
        UnitData _unitData = unit.GetUnitData();
        turnColor.GetComponent<Image>().color = new Color(0,0,0,0);
        //fon.GetComponent<Image>().sprite = unit.sprite;
        UpdateShow();
    }

    public void ActiveCageBlock() {
        isActive = true;
        turnColor.GetComponent<Image>().color = new Color(0,1,0,0.3f);
        //todo
        statusActive = StatusActive.move;
    }

    public void ActiveCageBlockUnitTurn(){
        isActive = false;
        turnColor.GetComponent<Image>().color = new Color(1,1,0,1);
        statusActive = StatusActive.none;
    }

    public void NotActiveCageBlock() {
        isActive = false;
        turnColor.GetComponent<Image>().color = new Color(0,0,0,0);
        statusActive = StatusActive.none;
        dead.SetActive(false);
        textAtack.GetComponent<Text>().text = "";
    }

    public void DeleteUnit() {
        isUnit = false;
        unit = null;
        UpdateShow();
    }

    public void ShowDamageCageBlocks(BattleData battleData){
        if(battleData.isDeath){
            dead.SetActive(true);
            textAtack.GetComponent<Text>().text = "";
        } else {
            dead.SetActive(false);
            textAtack.GetComponent<Text>().text = battleData.damage.ToString();
        }
    }

    public void NoShowDamageCageBlocks(){
        dead.SetActive(false);
        textAtack.GetComponent<Text>().text = "";
    }

    public void UpdateShow() {
        if(isUnit) {
            playerColor.SetActive(false);
            UnitData _unitData = unit.GetUnitData();
            spriteUnit.GetComponent<Image>().sprite = unit.sprite;
            if(unit.isWizard){
                wizard.SetActive(true);
                textwizard.GetComponent<Text>().text = _unitData.wizard.ToString();
            } else {
                wizard.SetActive(false);
            }

            damage.SetActive(true);
            typeAtack.GetComponent<Image>().sprite = unit.isMelee ? meleeAtack : notMeleeAtack;
            strength.SetActive(true);
            textDamage.GetComponent<Text>().text = _unitData.damage.ToString();
            textStrength.GetComponent<Text>().text = _unitData.strength.ToString();
        } else {
            playerColor.SetActive(false);
            spriteUnit.GetComponent<Image>().sprite = null;
            wizard.SetActive(false);
            damage.SetActive(false);
            strength.SetActive(false);
        }
        if (isGuard) {
            spriteObject.GetComponent<Image>().sprite = Object.sprite;   
        } else {
            spriteObject.GetComponent<Image>().sprite = null; 
        }
    }

    private void OnMouseEnter() {
        if (isGuard && !isActive && isUnit)
            message.LookCageBlock(new CageBlockData(){
                unit = unit,
                Object = Object
            });
        
        if (isActive){
            turnColor.GetComponent<Image>().color = new Color(0,1,0,1);
        }

        if (isUnit && isActive){
            map.ShowDamageCageBlocks(id);
        }

    }

    private void OnMouseExit() {
        message.NotLookCageBlock();
        if (isActive){
            turnColor.GetComponent<Image>().color = new Color(0,1,0,0.3f);
        }

        if (isUnit && isActive){
            NoShowDamageCageBlocks();
            map.NoShowDamageCageBlockUnitTurn();
        }
    }

    private void OnMouseDown() {
        switch (statusActive) {
            case StatusActive.move:
                if(isUnit) {
                    map.MoveBattle(id);
                } else {
                    map.Move(map.idCageBlockUnit, id);
                }
            break;
            default:break;
        }
    }

}

public enum StatusActive{
    none,
    move,
}

public class CageBlockData {
    public Unit unit;
    public Object Object;
}