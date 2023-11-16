using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.U2D;
using System;
using UnityEngine.Events;

public class GameCont : MonoBehaviour
{
    [SerializeField] QueueCont queueCont;
    [SerializeField] LibaryUnit libaryUnit;
    [SerializeField] Map map;
    public List<Player> players;
    public StatusGame statusGame;
    void Start() {
        StartPlayers();
        //todo
        statusGame = StatusGame.battle;
        /*libaryUnit.AddUnit(0,CodeUnit.hobbit);
        libaryUnit.AddUnit(1,CodeUnit.fairy);
        libaryUnit.AddUnit(0,CodeUnit.sabermaster);
        libaryUnit.AddUnit(1,CodeUnit.archer);
        libaryUnit.AddUnit(0,CodeUnit.druid);
        libaryUnit.AddUnit(1,CodeUnit.unicorn);
        libaryUnit.AddUnit(0,CodeUnit.ent);*/


        map.StartMap();
        Unit _unit = libaryUnit.GetUnit(CodeUnit.knight);
        _unit.idPlayer = 0;
        _unit.strongNow+=10;
        players[0].units.Add(_unit);
        map.AddUnit(_unit, 15);
        queueCont.StartQueueCont();
    }

    private void StartPlayers(){
        players = new List<Player>() {new Player(), new Player()};
        players[0].StartPlayer(0,new Color(1,0,0,0.5f));
        players[1].StartPlayer(0,new Color(0,0,1,0.5f));
    }

}

public enum StatusGame{
    none,
    test,
    battle
}