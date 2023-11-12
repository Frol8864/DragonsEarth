using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stat : MonoBehaviour
{
    public List<int> stats = new List<int>(){0,0,0,0,0};

    public Stat(int valueStrongN, int valueAttackN, int valueArmorN, int valueWizardN, int valueSpeedN){
        stats[0] = valueStrongN;
        stats[1] = valueAttackN;
        stats[2] = valueArmorN;
        stats[3] = valueWizardN;
        stats[4] = valueSpeedN;
    }
}
