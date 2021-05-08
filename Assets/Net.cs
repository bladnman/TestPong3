using System;
using System.Collections.Generic;
using Mirror;
using UnityEngine;
using UnityEngine.UI;

public class Net : NetworkBehaviour {
  [SerializeField] Image fillBar;
  [SerializeField] int startingHealth = 10;
  [SerializeField] int health = 10;

  #region Server  -  -  -  -  -  -  -  -  -  

  #endregion

  #region Client  -  -  -  -  -  -  -  -  -  
  private void Start() {
    health = startingHealth;
    SetNetColor();
  }
  void SetNetColor() {
    fillBar.material.color = GameColors.players[UnityEngine.Random.Range(0, GameColors.players.Length)];
  }
  private void OnTriggerEnter2D(Collider2D other) {
    health -= 1;
    float perc = (float)health / startingHealth;
    fillBar.fillAmount = perc;

    // tell server to destroy the ball

    // play hit "splash" / and sound

    // check for death
  }
  #endregion
}
