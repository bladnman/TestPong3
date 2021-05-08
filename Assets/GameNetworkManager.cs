using System;
using System.Collections.Generic;
using Mirror;
using UnityEngine;

public class GameNetworkManager : NetworkManager {
  [SerializeField] GameObject ballPrefab;
  [SerializeField] int playerCount = 1;
  [SerializeField] Transform ballSpawnPoint;
  [SerializeField] Transform[] playerSpawnPoints = new Transform[0];

  public override void OnServerAddPlayer(NetworkConnection conn) {
    base.OnServerAddPlayer(conn);

    if (numPlayers == playerCount) {
      SpawnBalls(numPlayers);
    }

  }
  [Server]
  public void SpawnBalls(int count) {
    var startTransform = ballSpawnPoint;
    var ball = Instantiate(ballPrefab, startTransform.position, startTransform.rotation);
    NetworkServer.Spawn(ball);
  }

}
