using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.U2D;
using System;
using UnityEngine.Events;

public class Map : MonoBehaviour
{
    [SerializeField] List<CageBlock> cageBlocks;
    [SerializeField] GenerationMap generationMap;
    private int xMax = 5;

    public void StartMap(){
        for(int i = 0; i < cageBlocks.Count; i++) {
            cageBlocks[i].StartCageBlock(i%xMax,i/xMax);
        }

        for(int i = 0; i < cageBlocks.Count; i++) {
            cageBlocks[i].AddObject(generationMap.GetCageBlockData());
        }
    }
}
