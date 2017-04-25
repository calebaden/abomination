using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;

public class LevelGen : MonoBehaviour {

    public string beatsPath;
    public GameObject blockPrefab;
    GameManager gm;
    public float offset;
    public float gapMinimum;
    bool firstOfChunk = true;
    public float graceTime;

    void Start () {

        gm = GameManager.instance;

        float lastTime = 0f;

        StreamReader beatsReader = new StreamReader(beatsPath);

        while (!beatsReader.EndOfStream) {
            string nextblock = beatsReader.ReadLine();
            float thisTime = float.Parse(nextblock);
            Vector3 blockSpot = new Vector3 (Mathf.Floor(gm.blockSpeed * lastTime) - 0.03f + offset, 0.53f, 0f);
            if (thisTime > graceTime) {
                if (thisTime - lastTime > gapMinimum / gm.blockSpeed) {
                    Instantiate(blockPrefab, blockSpot, Quaternion.identity);
                    Instantiate(blockPrefab, blockSpot + Vector3.left, Quaternion.identity);
                    firstOfChunk = true;
                    lastTime = thisTime;
                } else if (firstOfChunk) {
                    Instantiate(blockPrefab, blockSpot, Quaternion.identity);
                    Instantiate(blockPrefab, blockSpot + Vector3.right, Quaternion.identity);
                    Instantiate(blockPrefab, blockSpot + Vector3.up + Vector3.right, Quaternion.identity);
                    firstOfChunk = false;
                    lastTime = thisTime;
                }
            }

        }

	}
}
