using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class build_with_noise : MonoBehaviour
{
    public int Max_amount_of_peices = 20;
   


    public int min_variation_of_pieces = 3;
    public int Max_variation_of_pieces = 3;
    public GameObject[] baseParts;
    public GameObject[] middle_pieces;
    public GameObject[] Roofs;
    // this script uses the perlin noise generator script to build buiildings based on the perlin noise
    void Start()
    {
        build();
    }


    public void build()
    {
        float perlinvalue = PerlinGenerator.instance.PerlinSteppedPosition(transform.position);

        int numberpieces = Mathf.FloorToInt(Max_amount_of_peices * (perlinvalue));
        numberpieces += Random.Range(min_variation_of_pieces, Max_variation_of_pieces);

        if (numberpieces <= 0)
        {
            return;
        }

        float height = 0;
        height += Spawn_Pieces(baseParts, height);

        for (int i = 2; i < numberpieces; i++)
        {
            height += Spawn_Pieces(middle_pieces, height);
        }

        Spawn_Pieces(Roofs, height);
    }

    float Spawn_Pieces(GameObject[] pieceArray, float inputHeight)
    {
        Transform randomTransform = pieceArray[Random.Range(0, pieceArray.Length)].transform;
        GameObject Buildingblock = Instantiate(randomTransform.gameObject, this.transform.position + new Vector3(0, inputHeight, 0), transform.rotation) as GameObject;
        Mesh buildingmesh = Buildingblock.GetComponentInChildren<MeshFilter>().mesh;
        Bounds baseBounds = buildingmesh.bounds;
        float height = baseBounds.size.y;

        Buildingblock.transform.SetParent(this.transform);

        GeneratedObjectControl.instance.AddObject(Buildingblock);

        return height;
    }
}
