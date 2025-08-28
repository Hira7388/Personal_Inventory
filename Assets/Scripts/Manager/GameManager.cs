using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    public Player player { get; private set; }
    
    // 생성자 대신 플레이어 등록
    public void RegisterPlayer(Player playerInstance)
    {
        player = playerInstance;
    }
}
