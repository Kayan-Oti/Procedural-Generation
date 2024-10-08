using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomController : MonoBehaviour
{
    public static RoomController Instance;
    private List<Room> _listRooms = new List<Room>();
    public Room RoomPrefab;

    private void Awake()
    {
        if(Instance == null)
            Instance = this;
    }

    public void SpawnRoom(Vector2Int position){
        Room room = Instantiate(RoomPrefab, transform);
        room.SetPositionOnWorld(position);

        _listRooms.Add(room);
    }
}
