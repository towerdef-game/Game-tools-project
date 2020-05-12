using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridSpawner : MonoBehaviour
{

    public int Bulidngs_on_grid_X = 4;
    public int Buildings_on_grid_Z = 4;
    public GameObject prefabToSpawn;
    public Vector3 Gridspawnpoint = Vector3.zero;
    public float Distancebetweenbuildings = 2f;
 


    void Start()
    {
      
            Generate();
        // of some reason unless this generate function and the generate from my generated ObjectControl script it wont generate the buildings at all
    }

    public void Generate()
    {
        SpawnGrid();
    }


    void SpawnGrid()
    {
        for (int x = 0; x < Bulidngs_on_grid_X; x++)
        {
            for (int z = 0; z < Buildings_on_grid_Z; z++)
            {
                GameObject clone = Instantiate(prefabToSpawn, transform.position + Gridspawnpoint + new Vector3(Distancebetweenbuildings * x, 0, Distancebetweenbuildings * z), transform.rotation);
                clone.transform.SetParent(this.transform);
            }
        }
    }

    
}
