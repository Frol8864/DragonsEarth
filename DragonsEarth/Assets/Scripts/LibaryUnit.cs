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
            case CodeUnit.blacksmith: 
                unit.nameUnit = "Кузнец";
                unit.stat = new Stat(1,0,1,0,2);
                unit.cost = 2;
                unit.isMelee = true;
                unit.isWizard = false;
            break;
            case CodeUnit.javelinthrower: 
                unit.nameUnit = "Метатель копья";
                unit.stat = new Stat(2,4,0,0,2);
                unit.cost = 4;
                unit.isMelee = false;
                unit.isWizard = false;
            break;
            case CodeUnit.gnome: 
                unit.nameUnit = "Гном";
                unit.stat = new Stat(2,0,2,0,2);
                unit.cost = 4;
                unit.isMelee = true;
                unit.isWizard = false;
            break;
            case CodeUnit.valkyrie: 
                unit.nameUnit = "Валькирия";
                unit.stat = new Stat(2,2,2,0,5);
                unit.cost = 6;
                unit.isMelee = true;
                unit.isWizard = false;
            break;
            case CodeUnit.giant: 
                unit.nameUnit = "Великан";
                unit.stat = new Stat(4,3,3,0,1);
                unit.cost = 7;
                unit.isMelee = true;
                unit.isWizard = false;
            break;
            case CodeUnit.shaman: 
                unit.nameUnit = "Шаман";
                unit.stat = new Stat(3,2,2,4,2);
                unit.cost = 8;
                unit.isMelee = true;
                unit.isWizard = true;
            break;
            case CodeUnit.stoning: 
                unit.nameUnit = "Камнещит";
                unit.stat = new Stat(3,1,6,0,2);
                unit.cost = 9;
                unit.isMelee = true;
                unit.isWizard = false;
            break;
            case CodeUnit.polarbear: 
                unit.nameUnit = "Белый Медведь";
                unit.stat = new Stat(7,0,3,0,4);
                unit.cost = 11;
                unit.isMelee = true;
                unit.isWizard = false;
            break;
            case CodeUnit.goblin: 
                unit.nameUnit = "Гоблин";
                unit.stat = new Stat(2,1,0,0,2);
                unit.cost = 3;
                unit.isMelee = true;
                unit.isWizard = false;
            break;
            case CodeUnit.troll: 
                unit.nameUnit = "Троль";
                unit.stat = new Stat(3,2,0,0,2);
                unit.cost = 4;
                unit.isMelee = false;
                unit.isWizard = false;
            break;
            case CodeUnit.hawk: 
                unit.nameUnit = "Ястреб";
                unit.stat = new Stat(3,0,0,0,5);
                unit.cost = 4;
                unit.isMelee = true;
                unit.isWizard = false;
            break;
            case CodeUnit.dogman: 
                unit.nameUnit = "Псарь";
                unit.stat = new Stat(4,4,0,0,4);
                unit.cost = 6;
                unit.isMelee = true;
                unit.isWizard = false;
            break;
            case CodeUnit.centaur: 
                unit.nameUnit = "Кентавр";
                unit.stat = new Stat(5,3,0,0,4);
                unit.cost = 7;
                unit.isMelee = false;
                unit.isWizard = false;
            break;
            case CodeUnit.orc: 
                unit.nameUnit = "Орк";
                unit.stat = new Stat(6,3,0,0,2);
                unit.cost = 8;
                unit.isMelee = true;
                unit.isWizard = false;
            break;
            case CodeUnit.ogre: 
                unit.nameUnit = "Огр";
                unit.stat = new Stat(7,3,1,0,1);
                unit.cost = 9;
                unit.isMelee = true;
                unit.isWizard = false;
            break;
            case CodeUnit.cyclop: 
                unit.nameUnit = "Циклоп";
                unit.stat = new Stat(8,3,2,0,1);
                unit.cost = 11;
                unit.isMelee = false;
                unit.isWizard = false;
            break;
            case CodeUnit.gremlin: 
                unit.nameUnit = "Гремлен";
                unit.stat = new Stat(2,0,0,0,2);
                unit.cost = 3;
                unit.isMelee = false;
                unit.isWizard = false;
            break;
            case CodeUnit.golem: 
                unit.nameUnit = "Голем";
                unit.stat = new Stat(1,1,2,0,2);
                unit.cost = 4;
                unit.isMelee = true;
                unit.isWizard = false;
            break;
            case CodeUnit.gargoyle: 
                unit.nameUnit = "Горгуля";
                unit.stat = new Stat(2,1,1,0,5);
                unit.cost = 4;
                unit.isMelee = true;
                unit.isWizard = false;
            break;
            case CodeUnit.mage: 
                unit.nameUnit = "Маг";
                unit.stat = new Stat(3,3,0,2,2);
                unit.cost = 5;
                unit.isMelee = false;
                unit.isWizard = true;
            break;
            case CodeUnit.magician: 
                unit.nameUnit = "Колдун";
                unit.stat = new Stat(2,0,0,4,2);
                unit.cost = 5;
                unit.isMelee = false;
                unit.isWizard = true;
            break;
            case CodeUnit.titan: 
                unit.nameUnit = "Титан";
                unit.stat = new Stat(3,3,3,3,1);
                unit.cost = 8;
                unit.isMelee = true;
                unit.isWizard = true;
            break;
            case CodeUnit.gin: 
                unit.nameUnit = "Джин";
                unit.stat = new Stat(4,1,2,3,5);
                unit.cost = 9;
                unit.isMelee = true;
                unit.isWizard = true;
            break;
            case CodeUnit.phoenix: 
                unit.nameUnit = "Феникс";
                unit.stat = new Stat(5,0,2,4,5);
                unit.cost = 10;
                unit.isMelee = true;
                unit.isWizard = true;
            break;
            case CodeUnit.troglodyte: 
                unit.nameUnit = "Троглодит";
                unit.stat = new Stat(2,0,0,0,2);
                unit.cost = 3;
                unit.isMelee = true;
                unit.isWizard = false;
            break;
            case CodeUnit.naga: 
                unit.nameUnit = "Нага";
                unit.stat = new Stat(2,2,0,0,2);
                unit.cost = 4;
                unit.isMelee = true;
                unit.isWizard = false;
            break;
            case CodeUnit.harpy: 
                unit.nameUnit = "Гарпия";
                unit.stat = new Stat(1,3,0,0,4);
                unit.cost = 4;
                unit.isMelee = true;
                unit.isWizard = false;
            break;
            case CodeUnit.jellyfish: 
                unit.nameUnit = "Медуза";
                unit.stat = new Stat(3,3,0,0,3);
                unit.cost = 5;
                unit.isMelee = false;
                unit.isWizard = false;
            break;
            case CodeUnit.minotaur: 
                unit.nameUnit = "Минотавр";
                unit.stat = new Stat(3,1,2,0,3);
                unit.cost = 6;
                unit.isMelee = true;
                unit.isWizard = false;
            break;
            case CodeUnit.manticore: 
                unit.nameUnit = "Мантикора";
                unit.stat = new Stat(5,3,0,0,5);
                unit.cost = 8;
                unit.isMelee = true;
                unit.isWizard = false;
            break;
            case CodeUnit.wyvern: 
                unit.nameUnit = "Виверна";
                unit.stat = new Stat(6,1,1,0,5);
                unit.cost = 9;
                unit.isMelee = true;
                unit.isWizard = false;
            break;
            case CodeUnit.hydra: 
                unit.nameUnit = "Гидра";
                unit.stat = new Stat(6,3,2,0,4);
                unit.cost = 11;
                unit.isMelee = true;
                unit.isWizard = false;
            break;
            case CodeUnit.bonedragon: 
                unit.nameUnit = "Костяной Дракон";
                unit.stat = new Stat(6,3,3,3,5);
                unit.cost = 14;
                unit.isMelee = true;
                unit.isWizard = true;
            break;
            case CodeUnit.poisonousdragon: 
                unit.nameUnit = "Ядовитый Дракон";
                unit.stat = new Stat(6,3,3,3,5);
                unit.cost = 14;
                unit.isMelee = true;
                unit.isWizard = true;
            break;
            case CodeUnit.firedragon: 
                unit.nameUnit = "Огенный Дракон";
                unit.stat = new Stat(6,3,3,5,5);
                unit.cost = 15;
                unit.isMelee = true;
                unit.isWizard = true;
            break;
            case CodeUnit.horneddragon: 
                unit.nameUnit = "Рогатый Дракон";
                unit.stat = new Stat(6,6,3,3,5);
                unit.cost = 15;
                unit.isMelee = true;
                unit.isWizard = true;
            break;
            case CodeUnit.stonedragon: 
                unit.nameUnit = "Каменный Дракон";
                unit.stat = new Stat(6,3,6,3,5);
                unit.cost = 16;
                unit.isMelee = true;
                unit.isWizard = true;
            break;
            /*case CodeUnit.farmer: 
                unit.nameUnit = "Крестьянин";
                unit.stat = new Stat(1,0,0,0,1);
                unit.cost = 1;
                unit.isMelee = true;
                unit.isWizard = false;
            break;*/
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
    blacksmith,
    javelinthrower,
    gnome,
    valkyrie,
    giant,
    shaman,
    stoning,
    polarbear,
    goblin,
    troll,
    hawk,
    dogman,
    centaur,
    orc,
    ogre,
    cyclop,
    gremlin,
    golem,
    gargoyle,
    mage,
    magician,
    titan,
    gin,
    phoenix,
    troglodyte,
    naga,
    harpy,
    jellyfish,
    minotaur,
    manticore,
    wyvern,
    hydra,
    bonedragon,
    poisonousdragon,
    firedragon,
    horneddragon,
    stonedragon
}