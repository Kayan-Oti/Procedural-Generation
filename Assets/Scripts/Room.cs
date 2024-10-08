using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room : MonoBehaviour
{
    public float width, height, offset;
    public Vector2Int Position;

    //Defini a posição relativa da sala no Mundo
    public void SetPositionOnWorld(Vector2Int position){
        Position = position;

        transform.position = new Vector3(
            Position.x * (width + offset),
            Position.y * (height + offset),
            0
        );
    }

    //Desenha os limites da Sala no Inspector
    private void OnDrawGizmos(){
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(transform.position, new Vector3(width+offset, height+offset, 0));
    }
}
