using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.U2D;
using System;
using UnityEngine.Events;
using Unity.VisualScripting;
using Unity.Mathematics;


public class BattleCont : MonoBehaviour
{
    [SerializeField] Map map;
    [SerializeField] GameCont gameCont;
    public List<BattleData> GetBattleDatas(List<int> idCageBlocks){
        List<BattleData> battleDatas = new List<BattleData>(){
            new BattleData(){
                damage = 0,
                isDeath = false
            },
            new BattleData(){
                damage = 0,
                isDeath = false
            },
        };
        List<UnitData> unitDatas = new List<UnitData>(){
            map.cageBlocks[idCageBlocks[0]].unit.GetUnitData(gameCont),
            map.cageBlocks[idCageBlocks[1]].unit.GetUnitData(gameCont),
        };
        for(int i = 0; i < unitDatas.Count; i++) {
            if(!unitDatas[i].isMelee){
                unitDatas[i].statAll.stats[1] /= 2;
            }
        }
        List<int> idCageBlockNears = map.GetidCageBlockNear(idCageBlocks[1]);
        for(int i = 0; i < idCageBlockNears.Count; i++) {
            UnitData _unitDataNear = map.cageBlocks[idCageBlockNears[i]].unit.GetUnitData(gameCont);
            foreach(UnitData _unitData in unitDatas) {
                if(_unitDataNear.idPlayer == _unitData.idPlayer && !_unitDataNear.isMelee){
                    _unitData.statAll.stats[1] += _unitDataNear.strongNowAll;
                    _unitData.statAll.stats[1] += _unitDataNear.statAll.stats[1];
                }
            }
        }
        for(int i = 0; i < battleDatas.Count; i++) {
            battleDatas[i].nameUnit = unitDatas[i].nameUnit;
            battleDatas[i].damage = math.min(0, (unitDatas[i].statAll.stats[2]) - 
                                   (unitDatas[(i+1)%2].strongNowAll + unitDatas[(i+1)%2].statAll.stats[1]) );
            
            battleDatas[i].isDeath = (unitDatas[i].strongNowAll + battleDatas[i].damage <= 0) ? true : false;
        }
        
        return battleDatas;
    }

    /*public void MoveBattle(List<int> idCageBlocks) {
        List<BattleData> battleDatas = GetBattleDatas(idCageBlocks);

        for(int i = 0; i < idCageBlocks.Count; i++) {
            map.cageBlocks[idCageBlocks[i]].unit.strongNow+=battleDatas[i].damage;
        }

        if (battleDatas[1].isDeath && !battleDatas[0].isDeath) {
            map.cageBlocks[idCageBlocks[1]].isUnit = true;
            map.cageBlocks[idCageBlocks[1]].unit = map.cageBlocks[idCageBlocks[0]].unit;
        }
        if (battleDatas[1].isDeath && battleDatas[0].isDeath){
            map.cageBlocks[idCageBlocks[1]].isUnit = false;
            map.cageBlocks[idCageBlocks[1]].unit = null;
        }
        map.cageBlocks[idCageBlocks[1]].UpdateShow();

        if (battleDatas[0].isDeath || battleDatas[1].isDeath) {
            map.cageBlocks[idCageBlocks[0]].isUnit = false;
            map.cageBlocks[idCageBlocks[0]].unit = null;
        } 
        map.cageBlocks[idCageBlocks[0]].UpdateShow();
    }*/
}

public class BattleData{
    public int damage;
    public bool isDeath;
    public string nameUnit;
}
