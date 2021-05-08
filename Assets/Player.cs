using System;
using System.Collections.Generic;
using Mirror;
using UnityEngine;
using UnityEngine.UI;

public class Player : NetworkBehaviour {

  [SerializeField] GameObject paddle;
  [SerializeField] GameObject net;
  [SerializeField] Image fillBar;
  [SerializeField] float paddleSpeed = 8f;
  [SerializeField] float paddleRotationSpeed = 90f;
  [SerializeField] float maxRotation = 30f;
  [SerializeField] int health = 10;

  Rigidbody2D paddleRB;
  Vector2 paddleStartPoint;
  Quaternion originalRotationValue;
  float currentRotation = 0f;

  public override void OnStartAuthority() {
    base.OnStartAuthority();
    paddleRB = paddle.GetComponent<Rigidbody2D>();
    paddleStartPoint = paddle.transform.localPosition;
    originalRotationValue = paddle.transform.rotation;
  }
  void FixedUpdate() {
    if (isLocalPlayer) {
      var horiz = Input.GetAxisRaw("Horizontal");

      // no input -- clear
      if (Mathf.Abs(horiz) <= Mathf.Epsilon) {
        // clear rotation
        if (currentRotation != 0f) {
          // paddle.transform.Rotate(0, 0, 0, Space.Self);
          paddle.transform.rotation = Quaternion.Slerp(paddle.transform.rotation, originalRotationValue, Time.time * paddleRotationSpeed);
          currentRotation = 0;
        }

        return;
      }

      float xDelta = horiz * paddleSpeed * Time.fixedDeltaTime;
      paddle.transform.localPosition = new Vector2(paddle.transform.localPosition.x + xDelta, paddleStartPoint.y);


      if (paddleRotationSpeed > 0 && Mathf.Abs(currentRotation) < maxRotation) {
        float rotDelta = (float)horiz * paddleRotationSpeed * Time.deltaTime * -1;
        paddle.transform.Rotate(0, 0, rotDelta, Space.Self);

        currentRotation += rotDelta;
      }
    }
  }

}
