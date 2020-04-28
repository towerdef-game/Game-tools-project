using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridSpawner : MonoBehaviour
{

    public int BulidngsongridX = 4;
    public int BuildingsongridZ = 4;
    public GameObject prefabToSpawn;
    public Vector3 gridOrigin = Vector3.zero;
    public float Distancebetweenbuildings = 2f;
  //  public bool generateOnEnable;


    void Start()
    {
       // if (generateOnEnable)
       // {
            Generate();
        //}
    }

    public void Generate()
    {
        SpawnGrid();
    }


    void SpawnGrid()
    {
        for (int x = 0; x < BulidngsongridX; x++)
        {
            for (int z = 0; z < BuildingsongridZ; z++)
            {
                GameObject clone = Instantiate(prefabToSpawn, 
                    transform.position + gridOrigin + new Vector3(Distancebetweenbuildings * x, 0, Distancebetweenbuildings * z), transform.rotation);
                clone.transform.SetParent(this.transform);
            }
        }
    }

    
}
