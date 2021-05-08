using System;
using System.Collections.Generic;
using Mirror;
using UnityEngine;

public class Ball : NetworkBehaviour {
  [SerializeField] float speed = 8f;

  Rigidbody2D rigidbody2d;

  #region Server  -  -  -  -  -  -  -  -  -  
  public override void OnStartServer() {
    base.OnStartServer();

    rigidbody2d = GetComponent<Rigidbody2D>();

    // rigidbody2d.velocity = Vector2.down * speed;
    float randRadius = 2f;
    rigidbody2d.velocity = UnityEngine.Random.insideUnitCircle * randRadius * speed;
  }
  [Command]
  private void CmdServerRemoveBall() {
    Debug.Log($"M@ [{GetType()}] {gameObject} : DESTROY");   // M@: 
    NetworkServer.Destroy(gameObject);
  }
  #endregion

  #region Client  -  -  -  -  -  -  -  -  -  
  private void OnTriggerEnter2D(Collider2D other) {
    Debug.Log($"M@ [{GetType()}] {other} {other.name} : other");   // M@: 
    if (!hasAuthority) return;
    CmdServerRemoveBall();
  }
  #endregion
}
