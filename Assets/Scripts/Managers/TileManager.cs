using UnityEngine;
using System.Collections.Generic;

public class TileManager : MonoBehaviour {

    private int tileNumber = 0;
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

        for(int i = 0; i<startingTiles; i++)
        {
            InstanciateTile(1, tileNumber);
            tileNumber++;
        }
    }

    private void Update()
    {
        if (player.transform.position.x >= (tilePos.x/2))
        {
            InstanciateTile(1, tileNumber);
            tileNumber++;
        }
    }

    private void InstanciateTile(int tileId, int tileNumber)
    {
        tilePos = new Vector3(tileLength * tileNumber, 0f);
        GameObject tile = Instantiate(tiles[0], tilePos, Quaternion.identity, terrain.transform);
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
    }
}
