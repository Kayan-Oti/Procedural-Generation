using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DungeonGenerator : MonoBehaviour
{
    public DungeonData DungeonGenerationData;

    void Start()
    {
        //Gera a lista de coordenadas das Salas a partir dos Crawlers
        List<Vector2Int> roomsPositions = DungeonCrawlerController.GeneratePositions(DungeonGenerationData);
        //Gera as Rooms
        SpawnRooms(roomsPositions);
    }

     private void SpawnRooms(List<Vector2Int> positions){
       //Percorre cada posição gerando salas
        foreach(Vector2Int roomPosition in positions)
        {
            //Gera a sala
            RoomController.Instance.SpawnRoom(roomPosition);
        }
    }
}