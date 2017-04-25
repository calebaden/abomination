using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Terraingenerating : MonoBehaviour {

    public GameObject[] CliffTiles;
    public GameObject[] HillTiles;
    public GameObject[] RockTiles;
    public GameObject[] BushesTiles;
    public GameObject[] HouseTiles;
    public GameObject[] currentPieces;
    public GameObject newTile;
    public GameObject nextAnchor;
    public Animator carAnimator;
    public int[] pieceList;
    public int loopStop;
    public int DeleteLoop;
    public int animToPlay;
    public bool deleteStart;
    public float maxDistance;
    public int Direction; //1 = north, 2 = east, 3 = south, 4 = west
    public float nextAnchorXpos;
    public float nextAnchorZpos;
    int StartGen;
    public float timeScale;
    public string CurrentTerrainType;
    public float TerrainTypeSmooth;
    public float TerrainTypeSmoothMax;
    public string[] terrainTypes;
	// Use this for initialization
	void Start () {
       // DeleteLoop = 0;

	}
	
	// Update is called once per frame
	void Update () {
        //if (Input.GetKeyDown(KeyCode.G))
        //    animationEnd();
        if(StartGen <= currentPieces.Length-4)
        {
            int Rand = Random.Range(0, CliffTiles.Length - 2);
            int rand2 = Random.Range(0, 10);
            if (loopStop == 0)
            {
                loopStop = 10;
                if (Mathf.Abs(nextAnchorXpos) > maxDistance || Mathf.Abs(nextAnchorZpos) > maxDistance)
                {
                    if (Direction == 1)
                    {
                        if (nextAnchorXpos < 0)
                        {
                            Rand = CliffTiles.Length - 1;
                            Direction = 2;
                            Debug.Log("East");
                        }
                        else
                        {
                            Rand = CliffTiles.Length - 2;
                            Direction = 4;
                            Debug.Log("west");
                        }
                    }
                    else if (Direction == 3)
                    {
                        if (nextAnchorXpos < 0)
                        {
                            Rand = CliffTiles.Length - 2;
                            Direction = 2;
                            Debug.Log("East");
                        }
                        else
                        {
                            Rand = CliffTiles.Length - 1;
                            Direction = 4;
                            Debug.Log("west");
                        }
                    }
                    else if (Direction == 2)
                    {
                        if (nextAnchorZpos < 0)
                        {
                            Rand = CliffTiles.Length - 2;
                            Direction = 1;
                            Debug.Log("north");
                        }
                        else
                        {
                            Rand = CliffTiles.Length - 1;
                            Direction = 3;
                            Debug.Log("south");
                        }
                    }
                    else if (Direction == 4)
                    {
                        if (nextAnchorZpos < 0)
                        {
                            Rand = CliffTiles.Length - 1;
                            Direction = 1;
                            Debug.Log("north");
                        }
                        else
                        {
                            Rand = CliffTiles.Length - 2;
                            Direction = 3;
                            Debug.Log("south");
                        }
                    }
                }
                else
                {
                    if (rand2 == 1 && loopStop == 0)
                    {
                        Rand = CliffTiles.Length - 1;
                        loopStop = 10;
                    }
                    if (rand2 == 2 && loopStop == 0)
                    {
                        Rand = CliffTiles.Length - 2;
                        loopStop = 10;
                    }
                }
                
            }
            StartGen++;
            GeneratePiece(Rand);
            nextAnchor = newTile.transform.GetChild(1).gameObject;
            nextAnchorXpos = nextAnchor.transform.position.x;
            nextAnchorZpos = nextAnchor.transform.position.z;
            currentPieces[DeleteLoop] = newTile;
            pieceList[DeleteLoop] = Rand;
            DeleteLoop++;
            if (DeleteLoop > currentPieces.Length - 1)
            {
                DeleteLoop = 0;
                deleteStart = true;
            }
            if (loopStop > 0)
                loopStop--;

        }
        Time.timeScale = timeScale;
        //{
        //    if(deleteStart)
        //    Destroy(currentPieces[DeleteLoop]);
        //    int Rand = Random.Range(0, CliffTiles.Length-2);
        //    int rand2 = Random.Range(0, 10);
        //    if(rand2 == 1 && loopStop == 0)
        //    {
        //        Rand = CliffTiles.Length - 1;
        //        loopStop = 10;
        //    }
        //    if(rand2 == 2 && loopStop == 0)
        //    {
        //        Rand = CliffTiles.Length-2;
        //        loopStop = 10;
        //    }
        //    newTile = Instantiate(CliffTiles[Rand], nextAnchor.transform.position, nextAnchor.transform.rotation);
        //    nextAnchor = newTile.transform.GetChild(1).gameObject;
        //    if(loopStop >0)
        //        loopStop--;
        //    currentPieces[DeleteLoop] = newTile;
        //    pieceList[DeleteLoop] = Rand;
        //    DeleteLoop++;
        //    if(DeleteLoop > currentPieces.Length-1)
        //    {
        //        DeleteLoop = 0;
        //        deleteStart = true;
        //    }
        //}

    }
    public void animationEnd()
    {
        if (deleteStart)
            Destroy(currentPieces[DeleteLoop]);
        int Rand = Random.Range(0, CliffTiles.Length - 2);
        int rand2 = Random.Range(0, 10);
        if ( loopStop == 0)
        {
            loopStop = 10;
            if(Mathf.Abs(nextAnchorXpos) > maxDistance || Mathf.Abs(nextAnchorZpos)> maxDistance)
            {
                if(Direction == 1)
                {
                    if(nextAnchorXpos < 0)
                    {
                        Rand = CliffTiles.Length - 1;
                        Direction = 2;
                        Debug.Log("East");
                    }
                    else
                    {
                        Rand = CliffTiles.Length - 2;
                        Direction = 4;
                        Debug.Log("west");
                    }
                }
                else if(Direction == 3)
                {
                    if(nextAnchorXpos <0)
                    {
                        Rand = CliffTiles.Length - 2;
                        Direction = 2;
                        Debug.Log("East");
                    }
                    else
                    {
                        Rand = CliffTiles.Length - 1;
                        Direction = 4;
                        Debug.Log("west");
                    }
                }
                else if(Direction == 2)
                {
                    if(nextAnchorZpos <0)
                    {
                        Rand = CliffTiles.Length - 2;
                        Direction = 1;
                        Debug.Log("north");
                    }
                    else
                    {
                        Rand = CliffTiles.Length - 1;
                        Direction = 3;
                        Debug.Log("south");
                    }
                }
                else if(Direction == 4)
                {
                    if (nextAnchorZpos < 0)
                    {
                        Rand = CliffTiles.Length - 1;
                        Direction = 1;
                        Debug.Log("north");
                    }
                    else
                    {
                        Rand = CliffTiles.Length - 2;
                        Direction = 3;
                        Debug.Log("south");
                    }
                }
            }
            else
            {
                if (rand2 == 1 && loopStop == 0)
                {
                    Rand = CliffTiles.Length - 1;
                    loopStop = 10;
                }
                if (rand2 == 2 && loopStop == 0)
                {
                    Rand = CliffTiles.Length - 2;
                    loopStop = 10;
                }
            }
        }
        GeneratePiece(Rand);
        nextAnchor = newTile.transform.GetChild(1).gameObject;
        nextAnchorXpos = nextAnchor.transform.position.x;
        nextAnchorZpos = nextAnchor.transform.position.z;
        if (loopStop > 0)
            loopStop--;
        currentPieces[DeleteLoop] = newTile;
        pieceList[DeleteLoop] = Rand;
        DeleteLoop++;
        animToPlay++;
        if (DeleteLoop > currentPieces.Length - 1)
        {
            DeleteLoop = 0;
            deleteStart = true;
        }
        if (animToPlay > currentPieces.Length - 1)
        {
            animToPlay = 0;
        }
        carAnimator.Play(CliffTiles[pieceList[animToPlay]].gameObject.tag, 0, 0f);
        Debug.Log(CliffTiles[pieceList[animToPlay]].gameObject.tag);
    }

    public void GeneratePiece(int pieceToGen)
    {
        if(CurrentTerrainType == "cliffs")
        {
            newTile = Instantiate(CliffTiles[pieceToGen], nextAnchor.transform.position, nextAnchor.transform.rotation);
        }
        else if (CurrentTerrainType == "hills")
        {
            newTile = Instantiate(HillTiles[pieceToGen], nextAnchor.transform.position, nextAnchor.transform.rotation);
        }
        else if (CurrentTerrainType == "rocks")
        {
            newTile = Instantiate(RockTiles[pieceToGen], nextAnchor.transform.position, nextAnchor.transform.rotation);
        }
        else if (CurrentTerrainType == "bushes")
        {
            newTile = Instantiate(BushesTiles[pieceToGen], nextAnchor.transform.position, nextAnchor.transform.rotation);
        }
        else if (CurrentTerrainType == "houses")
        {
            newTile = Instantiate(HouseTiles[pieceToGen], nextAnchor.transform.position, nextAnchor.transform.rotation);
        }
        TerrainTypeSmooth++;
        int rand = Random.Range(1, 3);
        if (TerrainTypeSmooth > TerrainTypeSmoothMax && rand + TerrainTypeSmooth > TerrainTypeSmoothMax + 3)
        {
            TerrainTypeSmooth = 0;
            string thisTerrainType = CurrentTerrainType;
            print(thisTerrainType);
            do
            {
                int RandomTerrain = Random.Range(0, terrainTypes.Length);
                print(RandomTerrain);
                CurrentTerrainType = terrainTypes[RandomTerrain];
            } while (CurrentTerrainType == thisTerrainType);


        }

    }

}
