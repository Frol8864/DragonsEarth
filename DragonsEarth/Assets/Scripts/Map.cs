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
    [SerializeField] List<CageBlock> cageBlocks;
    [SerializeField] GenerationMap generationMap;
    [SerializeField] LibaryUnit libaryUnit;
    private int xMax = 5;
    public int idCageBlockUnit = -1;

    public void StartMap(){
        generationMap.GenerationUnitGuards();

        for(int i = 0; i < cageBlocks.Count; i++) {
            cageBlocks[i].AddObject(generationMap.GetCageBlockData(i), this, i);
        }

        Unit _unit = libaryUnit.GetUnit(CodeUnit.demon);
        AddUnit(_unit, 16);
        TurnUnit(_unit.id);

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
            //Debug.Log(cageBlocks[i].unit.id);
            if(cageBlocks[i].isUnit && cageBlocks[i].unit.id == idUnit) {
                idCageBlockUnit = i;
                _unit = cageBlocks[i].unit;
                //Debug.Log(_unit.codeUnit);
                break;
            }
        }
        int speed = _unit.GetSpeed();
        for(int i = 0; i < cageBlocks.Count; i++) {
            if(GetDelta(idCageBlockUnit, i) <= speed) {
                cageBlocks[i].ActiveCageBlock();
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

    private int GetDelta(int id1, int id2){
        return Math.Abs(id1%xMax - id2%xMax) + Math.Abs(id1/xMax - id2/xMax);
    }

    private void NotActiveMap(){
        for(int i = 0; i < cageBlocks.Count; i++) {
            cageBlocks[i].NotActiveCageBlock();
        }
    }
}
