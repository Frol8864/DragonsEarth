using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.U2D;
using System;
using UnityEngine.Events;

public class LibraryArtifact : MonoBehaviour
{
    [SerializeField] SpriteAtlas spritesArtifact;
    public Artifact GetArtifact(CodeArtifact codeArtifact){
        Artifact artifact = new Artifact();
        artifact.sprite = spritesArtifact.GetSprite(codeArtifact.ToString());

        switch (codeArtifact) {
            case CodeArtifact.pegasuswings:
                artifact.nameArtifact = "Крылья Пегаса";
                artifact.stat = new Stat(0,0,0,0,4);
                artifact.typeAtack = TypeAtack.all;
                artifact.typeWizard = TypeWizard.all;
            break;
            case CodeArtifact.elfcloak:
                artifact.nameArtifact = "Плащ Эльфа";
                artifact.stat = new Stat(0,0,2,0,1);
                artifact.typeAtack = TypeAtack.all;
                artifact.typeWizard = TypeWizard.all;
            break;
            case CodeArtifact.vampiresword:
                artifact.nameArtifact = "Шпага Вампира";
                artifact.stat = new Stat(0,2,0,0,0);
                artifact.typeAtack = TypeAtack.melee;
                artifact.typeWizard = TypeWizard.all;
            break;
            case CodeArtifact.magogstaff:
                artifact.nameArtifact = "Посох Магога";
                artifact.stat = new Stat(0,0,0,4,0);
                artifact.typeAtack = TypeAtack.all;
                artifact.typeWizard = TypeWizard.wizard;
            break;
            case CodeArtifact.manticorespear:
                artifact.nameArtifact = "Копье из жала Мантикоры";
                artifact.stat = new Stat(0,3,0,0,0);
                artifact.typeAtack = TypeAtack.melee;
                artifact.typeWizard = TypeWizard.all;
            break;
            case CodeArtifact.succubuswhip:
                artifact.nameArtifact = "Плетка Суккуба";
                artifact.stat = new Stat(0,2,0,2,0);
                artifact.typeAtack = TypeAtack.melee;
                artifact.typeWizard = TypeWizard.wizard;
            break;
            case CodeArtifact.devilscythe:
                artifact.nameArtifact = "Коса Дьявола";
                artifact.stat = new Stat(0,5,0,0,0);
                artifact.typeAtack = TypeAtack.melee;
                artifact.typeWizard = TypeWizard.all;
            break;
            case CodeArtifact.orcaxe:
                artifact.nameArtifact = "Топор Орка";
                artifact.stat = new Stat(0,4,0,0,0);
                artifact.typeAtack = TypeAtack.melee;
                artifact.typeWizard = TypeWizard.all;
            break;
            case CodeArtifact.elfbow:
                artifact.nameArtifact = "Лук Эльфа";
                artifact.stat = new Stat(0,5,0,0,0);
                artifact.typeAtack = TypeAtack.notMelee;
                artifact.typeWizard = TypeWizard.all;
            break;
            case CodeArtifact.valkyriewings:
                artifact.nameArtifact = "Крылья Валькирии";
                artifact.stat = new Stat(0,1,1,0,3);
                artifact.typeAtack = TypeAtack.all;
                artifact.typeWizard = TypeWizard.all;
            break;
            case CodeArtifact.shamantambourine:
                artifact.nameArtifact = "Бубен Шамана";
                artifact.stat = new Stat(0,0,0,2,0);
                artifact.typeAtack = TypeAtack.all;
                artifact.typeWizard = TypeWizard.wizard;
            break;
            case CodeArtifact.ifritlamp:
                artifact.nameArtifact = "Лампа Ифрита";
                artifact.stat = new Stat(0,0,0,2,0);
                artifact.typeAtack = TypeAtack.all;
                artifact.typeWizard = TypeWizard.wizard;
            break;
            case CodeArtifact.ginlamp:
                artifact.nameArtifact = "Лампа Джина";
                artifact.stat = new Stat(0,0,0,2,0);
                artifact.typeAtack = TypeAtack.all;
                artifact.typeWizard = TypeWizard.wizard;
            break;
            case CodeArtifact.knighthorse:
                artifact.nameArtifact = "Конь Рыцаря";
                artifact.stat = new Stat(0,2,2,0,2);
                artifact.typeAtack = TypeAtack.all;
                artifact.typeWizard = TypeWizard.all;
            break;
            case CodeArtifact.lichskull:
                artifact.nameArtifact = "Череп Лича";
                artifact.stat = new Stat(0,0,0,5,0);
                artifact.typeAtack = TypeAtack.all;
                artifact.typeWizard = TypeWizard.wizard;
            break;
            case CodeArtifact.cyclopsbelt:
                artifact.nameArtifact = "Пояc Циклопа";
                artifact.stat = new Stat(0,2,2,0,0);
                artifact.typeAtack = TypeAtack.notMelee;
                artifact.typeWizard = TypeWizard.all;
            break;
            case CodeArtifact.firesword:
                artifact.nameArtifact = "Огненный меч";
                artifact.stat = new Stat(0,3,0,3,0);
                artifact.typeAtack = TypeAtack.melee;
                artifact.typeWizard = TypeWizard.all;
            break;
            case CodeArtifact.fireonion:
                artifact.nameArtifact = "Огненный лук";
                artifact.stat = new Stat(0,3,0,3,0);
                artifact.typeAtack = TypeAtack.notMelee;
                artifact.typeWizard = TypeWizard.all;
            break;
            case CodeArtifact.unicornhelmet:
                artifact.nameArtifact = "Шлем с рогом Единорога";
                artifact.stat = new Stat(0,1,1,4,0);
                artifact.typeAtack = TypeAtack.all;
                artifact.typeWizard = TypeWizard.all;
            break;
            /*
            case CodeArtifact.guard:
                artifact.nameArtifact = "";
                artifact.stat = new Stat(0,0,0,0,0);
                artifact.typeAtack = TypeAtack.all;
                artifact.typeWizard = TypeWizard.all;
            break;
            */
            default: break;
        }

        return artifact;
    }

    public Artifact GetArtifactGuard(int valueStrongN, int valueAttackN, int valueArmorN, int valueWizardN, int valueSpeedN){
        Artifact artifact = new Artifact();
        artifact.nameArtifact = "Мощь Драконов";
        artifact.stat = new Stat(valueStrongN, valueAttackN, valueArmorN, valueWizardN, valueSpeedN);

        return artifact;
    }
}

public enum CodeArtifact{
    guard,
    pegasuswings,
    elfcloak,
    vampiresword,
    magogstaff,
    manticorespear,
    succubuswhip,
    devilscythe,
    orcaxe,
    elfbow,
    valkyriewings,
    shamantambourine,
    ifritlamp,
    ginlamp,
    knighthorse,
    lichskull,
    cyclopsbelt,
    firesword,
    fireonion,
    unicornhelmet
}