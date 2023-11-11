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
    public GameObject gameObj;
    public List<Player> players;
    public StatusGame statusGame;
    void Start() {
        StartPlayers();
        //todo
        statusGame = StatusGame.test;
        libaryUnit.AddUnit(0,CodeUnit.angel);
        libaryUnit.AddUnit(1,CodeUnit.devil);
        queueCont.StartTest();
    }

    private void StartPlayers(){
        Player p = new Player();
        players = new List<Player>() {new Player(), new Player()};
        players[0].StartPlayer(0,new Color(1,0,0,0.5f));
        players[1].StartPlayer(0,new Color(0,0,1,0.5f));
    }

}

public enum StatusGame{
    none,
    test
}