using System.Collections;
using System.Collections.Generic;
using Data;
using UnityEngine;
public class WorldManager : MonoBehaviour
{
    public Material worldMaterial;
    private Container container;

    public VoxelColor[] WorldColors;

    void Start()
    {

        if(_instance != null)
        {
            if (_instance != this)
                Destroy(this);
        }
        else
        {
            _instance = this;
        }

        GameObject cont = new GameObject("Container");
        cont.transform.parent = transform;
        container = cont.AddComponent<Container>();
        container.Initialize(worldMaterial, Vector3.zero);

        for (int x = 0; x < 16; x++)
        {
            for (int z = 0; z < 16; z++)
            {
                int randomYHeight = Random.Range(1, 16);
                for (int y = 0; y < randomYHeight; y++)
                {
                    container[new Vector3(x, y, z)] = new Voxel() { ID = 1 };
                }
            }
        }
        
        UpdateMesh();
    }

    public void AddBlock(Vector3 blockPos, Voxel voxel = null)
    {
        if (voxel == null)
            voxel = new Voxel() { ID = 1 };
        container.AddVoxel(blockPos, voxel);
        UpdateMesh();
    }

    public void RemoveBlock(Vector3 blockPos)
    {
        container.RemoveVoxel(blockPos);
    }

    public void ClearBlocks()
    {
        container.ClearData();
    }

    public void RenderBlocks(Dictionary<Vector3, Voxel> blockDict)
    {
        UpdateMesh(blockDict);
    }

    public void UpdateMesh(Dictionary<Vector3, Voxel> voxelDict = null)
    {
        container.GenerateMesh(voxelDict);
        container.UploadMesh();
    }

    private static WorldManager _instance;

    public static WorldManager Instance
    {
        get
        {
            if (_instance == null)
                _instance = GameObject.FindObjectOfType<WorldManager>();
            return _instance;
        }
    }

    void update()
    {

    }
}
