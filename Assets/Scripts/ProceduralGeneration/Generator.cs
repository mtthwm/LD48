using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Generator : MonoBehaviour
{
    public Tilemap groundTilemap;
    public Tile topTile;
    public Tile fillTile;
    public TreeObject[] treeObjects;
    public GameObject treeParent;
    public bool randomSeed = false;
    public float magnitude = 4.5f;
    public float spread = 4.5f;
    public TransformOption transformer;
    public enum TransformOption
    {
        Exponential,
        Logarithmic,
        None,
    };
    public Vector2 seed;
    public Vector2Int size;
    public Vector2Int origin;

    public void ApplyChanges()
    {
        GameObject[] trees = new GameObject[treeParent.transform.childCount];
        for (int i = 0; i < treeParent.transform.childCount; i++)
        {
            trees[i] = treeParent.transform.GetChild(i).gameObject;
            Debug.Log(trees[i]);
        }
        foreach (GameObject t in trees)
        {
            DestroyImmediate(t);
        }
        if (randomSeed)
        {
            seed = new Vector2(Random.Range(-10f, 10f), Random.Range(-10f, 10f));
        }
        groundTilemap.origin = (Vector3Int)origin;
        groundTilemap.size = (Vector3Int)size;
        groundTilemap.ResizeBounds();
        for (int x = origin.x; x < origin.x + size.x; x++)
        {
            float y = Mathf.PerlinNoise((float)(seed.x + x) / spread, (float)seed.y) * magnitude;
            switch (transformer)
            {
                case TransformOption.Exponential:
                    y = Mathf.Exp(y);
                    break;
                case TransformOption.Logarithmic:
                    y = Mathf.Log(y, Mathf.Exp(1));
                    break;
                default:
                    break;
            }
            int yInt = (int)y;
            Vector3Int tilePosition = new Vector3Int(x, yInt, 0);
            groundTilemap.SetTile(tilePosition, topTile);
            foreach (TreeObject to in treeObjects)
            {
                float rand = Random.value;
                bool doSpawn = to.probability > rand;
                if (doSpawn)
                {
                    GameObject t = Instantiate(to.prefab);
                    t.transform.parent = treeParent.transform;
                    Vector3 placeAt = groundTilemap.GetCellCenterWorld(tilePosition);
                    placeAt.y = placeAt.y + (groundTilemap.cellSize.y / 2f);
                    t.transform.position = placeAt;
                    break;
                }
            }
            for (int fillY = origin.y; fillY < yInt; fillY++)
            {
                groundTilemap.SetTile(new Vector3Int(x, fillY, 0), fillTile);
            }
        }
    }
}
