using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.U2D;
using System;
using UnityEngine.Events;
using Unity.VisualScripting;

public class Map : MonoBehaviour
{
    public List<CageBlock> cageBlocks;
    [SerializeField] GenerationMap generationMap;
    [SerializeField] LibaryUnit libaryUnit;
    [SerializeField] BattleCont battleCont;
    [SerializeField] Message message;
    [SerializeField] QueueCont queueCont;
    private int xMax = 5;
    public int idCageBlockUnit = -1;

    public void StartMap(){
        generationMap.GenerationUnitGuards();

        for(int i = 0; i < cageBlocks.Count; i++) {
            cageBlocks[i].AddObject(generationMap.GetCageBlockData(i), this, i);
        }

        /*Unit _unit = libaryUnit.GetUnit(CodeUnit.demon);
        _unit.idPlayer = 0;
        AddUnit(_unit, 16);
        TurnUnit(_unit.id);*/

        /*cageBlocks[10].DeleteUnit();
        cageBlocks[12].ActiveCageBlock();
        cageBlocks[11].ActiveCageBlock();
        cageBlocks[13].ActiveCageBlock();
        cageBlocks[17].ActiveCageBlock();
        cageBlocks[7].ActiveCageBlock();*/
    }

    public void AddUnit(Unit _unit, int idCageBlock) {
        cageBlocks[idCageBlock].isUnit = true;
        cageBlocks[idCageBlock].unit = _unit;
        cageBlocks[idCageBlock].UpdateShow();
    }

    public void TurnUnit(int idUnit) {
        NotActiveMap();
        idCageBlockUnit = -1;
        Unit _unit = new Unit();
        for(int i = 0; i < cageBlocks.Count; i++) {
            if(cageBlocks[i].isUnit && cageBlocks[i].unit.id == idUnit) {
                idCageBlockUnit = i;
                _unit = cageBlocks[i].unit;
                break;
            }
        }
        int speed = _unit.GetSpeed();
        for(int i = 0; i < cageBlocks.Count; i++) {
            List<BattleData> battleDatas = new List<BattleData>(){
                new BattleData(){ isDeath = false},
                new BattleData(){ isDeath = false},
            };
            if(cageBlocks[i].isUnit)
                battleDatas = battleCont.GetBattleDatas(new List<int>(){idCageBlockUnit, i});

            if(GetDelta(idCageBlockUnit, i) <= speed && GetDelta(idCageBlockUnit, i) != 0 && 
                (cageBlocks[i].isUnit && cageBlocks[idCageBlockUnit].isUnit && cageBlocks[i].unit.idPlayer != cageBlocks[idCageBlockUnit].unit.idPlayer 
                    || !cageBlocks[i].isUnit || !cageBlocks[idCageBlockUnit].isUnit)  && (!cageBlocks[i].isUnit || battleDatas[0].isDeath || battleDatas[1].isDeath)) {
                cageBlocks[i].ActiveCageBlock();
            }
            if((GetDelta(idCageBlockUnit, i) == 0) || ((cageBlocks[i].isUnit && cageBlocks[idCageBlockUnit].isUnit && cageBlocks[i].unit.idPlayer != cageBlocks[idCageBlockUnit].unit.idPlayer 
                    || !cageBlocks[i].isUnit || !cageBlocks[idCageBlockUnit].isUnit) && (cageBlocks[i].isUnit && !battleDatas[0].isDeath && !battleDatas[1].isDeath))) {
                cageBlocks[i].ActiveCageBlockUnitTurn();
            }
        }
    }

    public void Move(int idWas, int idIs){
        cageBlocks[idIs].isUnit = true;
        cageBlocks[idIs].unit = cageBlocks[idWas].unit;
        cageBlocks[idIs].UpdateShow();
        cageBlocks[idWas].isUnit = false;
        cageBlocks[idWas].unit = null;
        cageBlocks[idWas].UpdateShow();
        NotActiveMap();
    }

    public void MoveBattle(int _idCageBlock){
        List<int> idCageBlocks = new List<int>(){idCageBlockUnit ,_idCageBlock};
        List<BattleData> battleDatas = battleCont.GetBattleDatas(idCageBlocks);
        
        for(int i = 0; i < idCageBlocks.Count; i++) {
            if(battleDatas[i].isDeath)
                queueCont.DeathUnit(cageBlocks[idCageBlocks[i]].unit.id);
        }

        for(int i = 0; i < idCageBlocks.Count; i++) {
            cageBlocks[idCageBlocks[i]].unit.strongNow+=battleDatas[i].damage;
        }

        if (battleDatas[1].isDeath && !battleDatas[0].isDeath) {
            cageBlocks[idCageBlocks[1]].isUnit = true;
            cageBlocks[idCageBlocks[1]].unit = cageBlocks[idCageBlocks[0]].unit;
        }
        if (battleDatas[1].isDeath && battleDatas[0].isDeath){
            cageBlocks[idCageBlocks[1]].isUnit = false;
            cageBlocks[idCageBlocks[1]].unit = null;
        }
        cageBlocks[idCageBlocks[1]].UpdateShow();

        if (battleDatas[0].isDeath || battleDatas[1].isDeath) {
            cageBlocks[idCageBlocks[0]].isUnit = false;
            cageBlocks[idCageBlocks[0]].unit = null;
        } 
        cageBlocks[idCageBlocks[0]].UpdateShow();
        queueCont.UpdateShow();
        NotActiveMap();
        if (battleDatas[1].isDeath && !battleDatas[0].isDeath)
            cageBlocks[idCageBlocks[1]].ActiveCageBlockUnitTurn();
    }

    public List<int> GetidCageBlockNear(int idCageBlock){
        List<int> idCageBlockNears = new List<int>();

        if (idCageBlock%xMax != 0 && cageBlocks[idCageBlock - 1].isUnit) {
            idCageBlockNears.Add(idCageBlock - 1);
        }
        if (idCageBlock%xMax != 4 && cageBlocks[idCageBlock + 1].isUnit) {
            idCageBlockNears.Add(idCageBlock + 1);
        }
        if (idCageBlock/xMax != 0 && cageBlocks[idCageBlock - xMax].isUnit) {
            idCageBlockNears.Add(idCageBlock - xMax);
        }
        if (idCageBlock/xMax != (cageBlocks.Count-1)/xMax && cageBlocks[idCageBlock + xMax].isUnit) {
            idCageBlockNears.Add(idCageBlock + xMax);
        }

        return idCageBlockNears;
    }

    public void ShowDamageCageBlocks(int _idCageBlockUnit) {
        List<BattleData> battleDatas = battleCont.GetBattleDatas(new List<int>(){idCageBlockUnit, _idCageBlockUnit});
        cageBlocks[idCageBlockUnit].ShowDamageCageBlocks(battleDatas[0]);
        cageBlocks[_idCageBlockUnit].ShowDamageCageBlocks(battleDatas[1]);
        message.LookCageBlockBattle(new CageBlockData(){
                unit = null,
                Object = cageBlocks[_idCageBlockUnit].Object}, battleDatas);
    }

    public void NoShowDamageCageBlockUnitTurn(){
        cageBlocks[idCageBlockUnit].NoShowDamageCageBlocks();
    }

    private int GetDelta(int id1, int id2){
        return Math.Abs(id1%xMax - id2%xMax) + Math.Abs(id1/xMax - id2/xMax);
    }

    private void NotActiveMap(){
        for(int i = 0; i < cageBlocks.Count; i++) {
            cageBlocks[i].NotActiveCageBlock();
        }
    }
}
