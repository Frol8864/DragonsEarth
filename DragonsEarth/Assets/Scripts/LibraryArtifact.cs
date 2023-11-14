using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.U2D;
using System;
using UnityEngine.Events;

public class LibraryArtifact : MonoBehaviour
{
    public Artifact GetArtifact(CodeArtifact codeArtifact){
        Artifact artifact = new Artifact();

        switch (codeArtifact) {
            case CodeArtifact.guard:
                
            break;
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
    guard
}