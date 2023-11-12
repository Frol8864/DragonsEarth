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
    public List<Player> players;
    public StatusGame statusGame;
    void Start() {
        StartPlayers();
        //todo
        statusGame = StatusGame.battle;
        libaryUnit.AddUnit(0,CodeUnit.hellhound);
        libaryUnit.AddUnit(1,CodeUnit.demon);
        libaryUnit.AddUnit(0,CodeUnit.heretic);
        libaryUnit.AddUnit(1,CodeUnit.imp);
        libaryUnit.AddUnit(0,CodeUnit.devil);
        libaryUnit.AddUnit(1,CodeUnit.magog);
        libaryUnit.AddUnit(0,CodeUnit.succubus);
        libaryUnit.AddUnit(1,CodeUnit.ifrit);
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