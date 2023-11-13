using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.U2D;
using System;
using UnityEngine.Events;

public class LibaryObject : MonoBehaviour
{
    [SerializeField] GameCont gameCont;
    [SerializeField] SpriteAtlas spritesObject;

    public Object GetObject(CodeObject codeObject){
        Object Object = new Object();
        Object.idPlayer = -1;
        Object.sprite = spritesObject.GetSprite(codeObject.ToString());
        switch (codeObject) {
            case CodeObject.prison:
                Object.nameObject = "Тюрьма";
            break;
            case CodeObject.blacksmith:
                Object.nameObject = "Кузнеца";
            break;
            case CodeObject.towermagiciansson:
                Object.nameObject = "Башня Магов";
            break;
            case CodeObject.stable:
                Object.nameObject = "Конюшня";
            break;
            case CodeObject.lifetree:
                Object.nameObject = "Древо Жизни";
            break;
            case CodeObject.bank:
                Object.nameObject = "Банк";
            break;
            case CodeObject.dragondungeon:
                Object.nameObject = "Подземелье драконов";
            break;
            case CodeObject.crypt:
                Object.nameObject = "Склеп";
            break;
            case CodeObject.temple:
                Object.nameObject = "Храм";
            break;
            case CodeObject.arsenal:
                Object.nameObject = "Заброшенный арсенал";
            break;

            default: break;
        }

        return Object;
    }
}

public enum CodeObject{
    prison,
    blacksmith,
    towermagiciansson,
    stable,
    lifetree,
    bank,
    dragondungeon,
    crypt,
    temple,
    arsenal,
}
