using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.U2D;
using System;
using UnityEngine.Events;

public class LibaryUnit : MonoBehaviour
{
    [SerializeField] GameCont gameCont;
    [SerializeField] SpriteAtlas spritesUnit;
    private int idUnit = 0;

    public void AddUnit(int idPlayer, CodeUnit codeUnit) {
        Unit unit = GetUnit(codeUnit);
        unit.idPlayer = idPlayer;
        unit.id = idUnit;
        idUnit++;

        gameCont.players[idPlayer].units.Add(unit);
    }

    public Unit GetUnit(CodeUnit codeUnit) {
        Unit unit = new Unit();
        unit.id = -1;
        unit.idPlayer = -1;
        unit.sprite = spritesUnit.GetSprite(codeUnit.ToString());
        switch(codeUnit) {
            case CodeUnit.angel: 
                unit.nameUnit = "Ангел";
                unit.stat = new Stat(2,6,6,2,5);
            break;
            case CodeUnit.devil: 
                unit.nameUnit = "Дьявол";
                unit.stat = new Stat(5,5,4,3,2);
            break;
            default: break;
        }
        return unit;
    }
}

public enum CodeUnit{
    angel,
    devil,
}