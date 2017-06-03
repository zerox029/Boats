using UnityEngine;
using System.Collections.Generic;

public class TileManager : MonoBehaviour {

    private int tileNumber = 0;
    private Vector3 firstTilePos;
    private Vector3 tilePos;
    private GameObject player;
    private List<GameObject> tilesOnScreen;

    public GameObject terrain;
    public float tileLength;
    public int startingTiles;

    [Space(5)]
    public GameObject[] tiles;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        tilesOnScreen = new List<GameObject>();
        firstTilePos = new Vector3(0, 0);

        //Add the first tile

        for(int i = 0; i<startingTiles; i++)
        {
            InstanciateTile(Random.Range(0, tiles.Length), tileNumber);
            tileNumber++;
        }
    }

    private void Update()
    {
        if (player.transform.position.x >= ((tilePos.x + firstTilePos.x)/2))
        {
            InstanciateTile(Random.Range(0, tiles.Length), tileNumber);
            tileNumber++;
        }
    }

    private void InstanciateTile(int tileId, int tileNumber)
    {
        tilePos = new Vector3(tileLength * tileNumber, 0f);
        GameObject tile = Instantiate(tiles[tileId], tilePos, Quaternion.identity, terrain.transform);
        tilesOnScreen.Add(tile);

        if (tilesOnScreen.Count > 10)
        {
            DeleteFirstTile();
        }
    }

    private void DeleteFirstTile()
    {
        Destroy(tilesOnScreen[0]);
        tilesOnScreen.RemoveAt(0);
        firstTilePos.x += tileLength;
    }
}
