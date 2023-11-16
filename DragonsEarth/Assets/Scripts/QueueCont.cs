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
    [SerializeField] GameObject fon;
    [SerializeField] List<UnitBlock> unitBlocks;
    [SerializeField] Message message;
    [SerializeField] Map map;
    
    public int idPlayerTurn;
    public int idRound;

    private List<UnitQueue> unitQueues;
    private int idFirstUnitBlock;

    public void StartQueueCont() {
        idFirstUnitBlock = 0;
        idPlayerTurn = 1;
        idRound = 0;
        UpdateUnitForStartRound();
        if(unitQueues.Count > 0)
            idPlayerTurn = unitQueues[0].unit.idPlayer;
        UpdateShow();
    }

    public void DeathUnit(int _idUnit){
        for(int i = 0; i < unitQueues.Count; i++) {
            if(_idUnit == unitQueues[i].unit.id){
                unitQueues.RemoveAt(i);
                i--;
            }  
        }
        UpdateShow();
    }

    public void EndTurn() {
        if(unitQueues.Count > 0)
            message.EndTurn(unitQueues[0].unit);
        //todo
        switch(gameCont.statusGame){
            case StatusGame.battle: 
                EndBattleTurn();
            break;
            default: break;
        }
        SortUnit();
        if(unitQueues.Count > 0){
            message.StartTurn(unitQueues[0].unit);
            map.TurnUnit(unitQueues[0].unit.id);
        }
        UpdateShow();
    }
    private void EndBattleTurn(){
        idFirstUnitBlock = 0;
        if(unitQueues.Count > 0){
            unitQueues[0].isTurn = false;
            unitQueues.RemoveAt(0);
        }
        SortUnit();
        if(unitQueues.Count > 0 && !unitQueues[0].isTurn || unitQueues.Count == 0){
            Debug.Log("start");
            UpdateUnitForStartRound();
        }
        if(unitQueues.Count > 0)
            idPlayerTurn = unitQueues[0].unit.idPlayer;
        else 
            idPlayerTurn = (idPlayerTurn + 1) % 2; 
    }

    public void ChangeIdFirstUnitBlock (int x) {
        if( (idFirstUnitBlock+x >=0 ) && (idFirstUnitBlock+x <= unitQueues.Count - unitBlocks.Count + 1)) {
            idFirstUnitBlock += x;
            UpdateShow();
        }
    }

    public void UpdateShow() {
        fon.GetComponent<Image>().color = gameCont.players[idPlayerTurn].color;
        foreach(UnitBlock _unitBlock in unitBlocks){
            _unitBlock.ShowEmpty();
        }

        switch(gameCont.statusGame){
            case StatusGame.battle: 
                ShowUnitBlocksRoundBattle();
            break;
            default: break;
        }
    }

    private void ShowUnitBlocksRoundBattle(){
        bool _isTurn = true;
        int k = 0;
        for(int i = idFirstUnitBlock; i < unitQueues.Count && k < unitBlocks.Count; i++) {
            if(_isTurn && !unitQueues[i].isTurn){
                unitBlocks[k].ShowRound(idRound+1);
                _isTurn = unitQueues[i].isTurn;
                i--; 
            } else {
                unitBlocks[k].ShowUnit(unitQueues[i].unit);
            }
            k++;
        }
    }

    private void UpdateUnitForStartRound() {
        idRound++;
        message.EndRound(idRound);
        unitQueues = new List<UnitQueue>();
        for(int i = 0; i < 2; i++) {
            List<Unit> _units = gameCont.players[i].GetUnitForStartRound();
            foreach(Unit _unit in _units){
                unitQueues.Add(
                    new UnitQueue(){unit = _unit, isTurn = true}
                );
                unitQueues.Add(
                    new UnitQueue(){unit = _unit, isTurn = false}
                );
            }
        }
        SortUnit();
        if(unitQueues.Count > 0){
            message.StartTurn(unitQueues[0].unit);
            map.TurnUnit(unitQueues[0].unit.id);
        }
    }

    private void SortUnit() {
        List<UnitQueue> _unitQueues = new List<UnitQueue>();
        foreach(UnitQueue _unitQueue in unitQueues) {
            _unitQueues.Add(_unitQueue);
        }
        unitQueues = new List<UnitQueue>();
        int _idPlayerTurn = (idPlayerTurn+1)%2;
        int _count = _unitQueues.Count;
        List<int> maxs = new List<int>(){0,0};

        for(int i = 0; i < _count; i++) {
            maxs[0]=GetMaxInitiative(0,_unitQueues,true);
            maxs[1]=GetMaxInitiative(1,_unitQueues,true);
            if(maxs[(_idPlayerTurn+1)%2] > maxs[_idPlayerTurn]) 
                _idPlayerTurn = (_idPlayerTurn+1)%2;

            bool isAdd = false;
            for(int j = 0; j < _unitQueues.Count; j++) {
                if(!isAdd && _unitQueues[j].isTurn && _unitQueues[j].unit.idPlayer == _idPlayerTurn && maxs[_idPlayerTurn] == _unitQueues[j].unit.GetUnitData().initiative){
                    unitQueues.Add(_unitQueues[j]);
                    _unitQueues.RemoveAt(j);
                    _idPlayerTurn = (_idPlayerTurn+1)%2;
                    break;
                }
            }
        }

        for(int i = 0; i < _count; i++) {
            maxs[0]=GetMaxInitiative(0,_unitQueues,false);
            maxs[1]=GetMaxInitiative(1,_unitQueues,false);
            if(maxs[(_idPlayerTurn+1)%2] > maxs[_idPlayerTurn]) _idPlayerTurn = (_idPlayerTurn+1)%2;

            bool isAdd = false;
            for(int j = 0; j < _unitQueues.Count; j++) {
                if(!isAdd && !_unitQueues[j].isTurn && _unitQueues[j].unit.idPlayer == _idPlayerTurn && maxs[_idPlayerTurn] == _unitQueues[j].unit.GetUnitData().initiative){
                    unitQueues.Add(_unitQueues[j]);
                    _unitQueues.RemoveAt(j);
                    _idPlayerTurn = (_idPlayerTurn+1)%2;
                    break;
                }
            }
        }
    }

    private int GetMaxInitiative(int _idPlayer, List<UnitQueue> _unitQueues,bool flagTurn) {
        int max = 0;
        foreach(UnitQueue _unitQueue in _unitQueues){
            if(_unitQueue.isTurn == flagTurn && _unitQueue.unit.idPlayer == _idPlayer && max < _unitQueue.unit.GetUnitData().initiative){
                max = _unitQueue.unit.GetUnitData().initiative;
            }
        }
        return max;
    }
}

public class UnitQueue{
    public Unit unit;
    public bool isTurn;
}
