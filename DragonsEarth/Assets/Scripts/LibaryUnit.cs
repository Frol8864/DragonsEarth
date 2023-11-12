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
        unit.gameCont = gameCont;
        unit.id = -1;
        unit.idPlayer = -1;
        unit.sprite = spritesUnit.GetSprite(codeUnit.ToString());
        switch(codeUnit) {
            case CodeUnit.farmer: 
                unit.nameUnit = "Крестьянин";
                unit.stat = new Stat(1,0,0,0,1);
                unit.cost = 1;
                unit.isMelee = true;
                unit.isWizard = false;
            break;
            case CodeUnit.crossbowman: 
                unit.nameUnit = "Арбалетчик";
                unit.stat = new Stat(2,2,1,0,2);
                unit.cost = 4;
                unit.isMelee = false;
                unit.isWizard = false;
            break;
            case CodeUnit.priest: 
                unit.nameUnit = "Жрец";
                unit.stat = new Stat(2,0,0,4,1);
                unit.cost = 4;
                unit.isMelee = false;
                unit.isWizard = true;
            break;
            case CodeUnit.witcher: 
                unit.nameUnit = "Ведьмак";
                unit.stat = new Stat(3,2,2,0,2);
                unit.cost = 6;
                unit.isMelee = true;
                unit.isWizard = false;
            break;
            case CodeUnit.griffin: 
                unit.nameUnit = "Грифон";
                unit.stat = new Stat(5,0,0,0,5);
                unit.cost = 6;
                unit.isMelee = true;
                unit.isWizard = false;
            break;
            case CodeUnit.paladin: 
                unit.nameUnit = "Паладин";
                unit.stat = new Stat(3,2,4,3,2);
                unit.cost = 9;
                unit.isMelee = true;
                unit.isWizard = true;
            break;
            case CodeUnit.knight: 
                unit.nameUnit = "Рыцарь";
                unit.stat = new Stat(4,2,3,0,4);
                unit.cost = 9;
                unit.isMelee = true;
                unit.isWizard = false;
            break;
            case CodeUnit.angel: 
                unit.nameUnit = "Ангел";
                unit.stat = new Stat(2,6,6,2,5);
                unit.cost = 11;
                unit.isMelee = true;
                unit.isWizard = true;
            break;
            case CodeUnit.hobbit: 
                unit.nameUnit = "Хоббит";
                unit.stat = new Stat(1,0,0,0,1);
                unit.cost = 1;
                unit.isMelee = false;
                unit.isWizard = false;
            break;
            case CodeUnit.fairy: 
                unit.nameUnit = "Фея";
                unit.stat = new Stat(1,0,0,4,5);
                unit.cost = 4;
                unit.isMelee = true;
                unit.isWizard = true;
            break;
            case CodeUnit.sabermaster: 
                unit.nameUnit = "Мастер сабли";
                unit.stat = new Stat(2,2,0,0,2);
                unit.cost = 4;
                unit.isMelee = true;
                unit.isWizard = false;
            break;
            case CodeUnit.archer: 
                unit.nameUnit = "Лучник";
                unit.stat = new Stat(2,5,0,0,2);
                unit.cost = 5;
                unit.isMelee = false;
                unit.isWizard = false;
            break;
            case CodeUnit.druid: 
                unit.nameUnit = "Друид";
                unit.stat = new Stat(3,0,0,4,2);
                unit.cost = 5;
                unit.isMelee = false;
                unit.isWizard = true;
            break;
            case CodeUnit.unicorn: 
                unit.nameUnit = "Единорог";
                unit.stat = new Stat(6,0,0,2,4);
                unit.cost = 8;
                unit.isMelee = true;
                unit.isWizard = true;
            break;
            case CodeUnit.pegasus: 
                unit.nameUnit = "Пегас";
                unit.stat = new Stat(7,0,0,0,5);
                unit.cost = 9;
                unit.isMelee = true;
                unit.isWizard = false;
            break;
            case CodeUnit.ent: 
                unit.nameUnit = "Энт";
                unit.stat = new Stat(7,0,4,3,1);
                unit.cost = 12;
                unit.isMelee = true;
                unit.isWizard = true;
            break;
            case CodeUnit.skeleton: 
                unit.nameUnit = "Скелет";
                unit.stat = new Stat(2,1,0,0,2);
                unit.cost = 3;
                unit.isMelee = true;
                unit.isWizard = false;
            break;
            case CodeUnit.ghost: 
                unit.nameUnit = "Призрак";
                unit.stat = new Stat(1,1,3,0,4);
                unit.cost = 4;
                unit.isMelee = true;
                unit.isWizard = false;
            break;
            case CodeUnit.zombie: 
                unit.nameUnit = "Зомби";
                unit.stat = new Stat(3,0,2,0,1);
                unit.cost = 4;
                unit.isMelee = true;
                unit.isWizard = false;
            break;
            case CodeUnit.werewolf: 
                unit.nameUnit = "Обротень";
                unit.stat = new Stat(3,2,2,0,4);
                unit.cost = 7;
                unit.isMelee = true;
                unit.isWizard = false;
            break;
            case CodeUnit.vampire: 
                unit.nameUnit = "Вампир";
                unit.stat = new Stat(6,0,0,0,2);
                unit.cost = 8;
                unit.isMelee = true;
                unit.isWizard = false;
            break;
            case CodeUnit.lich: 
                unit.nameUnit = "Лич";
                unit.stat = new Stat(3,2,0,8,2);
                unit.cost = 8;
                unit.isMelee = false;
                unit.isWizard = true;
            break;
            case CodeUnit.corpseeater: 
                unit.nameUnit = "Трупоед";
                unit.stat = new Stat(6,0,2,0,1);
                unit.cost = 8;
                unit.isMelee = true;
                unit.isWizard = false;
            break;
            case CodeUnit.deathknight: 
                unit.nameUnit = "Рыцарь Смерти";
                unit.stat = new Stat(5,5,4,0,4);
                unit.cost = 11;
                unit.isMelee = true;
                unit.isWizard = false;
            break;
            case CodeUnit.imp: 
                unit.nameUnit = "Бес";
                unit.stat = new Stat(1,0,0,0,5);
                unit.cost = 3;
                unit.isMelee = true;
                unit.isWizard = false;
            break;
            case CodeUnit.magog: 
                unit.nameUnit = "Магог";
                unit.stat = new Stat(2,0,0,2,2);
                unit.cost = 4;
                unit.isMelee = false;
                unit.isWizard = true;
            break;
            case CodeUnit.heretic: 
                unit.nameUnit = "Еритик";
                unit.stat = new Stat(2,0,0,5,1);
                unit.cost = 4;
                unit.isMelee = false;
                unit.isWizard = true;
            break;
            case CodeUnit.succubus: 
                unit.nameUnit = "Суккуб";
                unit.stat = new Stat(3,0,0,5,1);
                unit.cost = 6;
                unit.isMelee = true;
                unit.isWizard = true;
            break;
            case CodeUnit.demon: 
                unit.nameUnit = "Демон";
                unit.stat = new Stat(4,2,2,0,2);
                unit.cost = 6;
                unit.isMelee = true;
                unit.isWizard = false;
            break;
            case CodeUnit.ifrit: 
                unit.nameUnit = "Ифрит";
                unit.stat = new Stat(4,3,1,3,5);
                unit.cost = 9;
                unit.isMelee = true;
                unit.isWizard = true;
            break;
            case CodeUnit.hellhound: 
                unit.nameUnit = "Цербер";
                unit.stat = new Stat(6,3,1,0,4);
                unit.cost = 9;
                unit.isMelee = true;
                unit.isWizard = false;
            break;
            case CodeUnit.devil: 
                unit.nameUnit = "Дьявол";
                unit.stat = new Stat(5,5,4,3,2);
                unit.cost = 11;
                unit.isMelee = true;
                unit.isWizard = true;
            break;
            default: break;
        }
        unit.StartStrongNow();
        return unit;
    }
}

public enum CodeUnit{
    angel,
    devil,
    farmer,
    crossbowman,
    priest,
    witcher,
    griffin,
    paladin,
    knight,
    hobbit,
    fairy,
    sabermaster,
    archer,
    druid,
    unicorn,
    pegasus,
    ent,
    skeleton,
    ghost,
    zombie,
    werewolf,
    vampire,
    lich,
    corpseeater,
    deathknight,
    imp,
    magog,
    heretic,
    succubus,
    demon,
    ifrit,
    hellhound,
}