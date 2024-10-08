using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DungeonGenerator : MonoBehaviour
{
    public DungeonData dungeonGenerationData;
    private List<Vector2Int> roomsPositions;

    void Start()
    {
        //Gera a lista de coordenadas das Salas a partir dos Crawlers
        roomsPositions = DungeonCrawlerController.GeneratePositions(dungeonGenerationData);
        //Gera as Rooms
        SpawnRooms(roomsPositions);
    }

     private void SpawnRooms(List<Vector2Int> positions){
        foreach(Vector2Int roomPositions in positions)
        {
            //Gera a sala
            RoomController.Instance.SpawnRoom(roomPositions);
        }
    }
}
