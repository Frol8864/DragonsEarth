using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stat : MonoBehaviour
{
    public int valueStrong;
    public int valueAttack;
    public int valueArmor;
    public int valueWizard;
    public int valueSpeed;

    public Stat(int valueStrongN, int valueAttackN, int valueArmorN, int valueWizardN, int valueSpeedN){
        valueStrong = valueStrongN;
        valueAttack = valueAttackN;
        valueArmor = valueArmorN;
        valueWizard = valueWizardN;
        valueSpeed = valueSpeedN;
    }
}
