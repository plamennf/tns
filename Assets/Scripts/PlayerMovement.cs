using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
    [SerializeField] private Camera camera;

    private Rigidbody rigidbody;

    private int tilePositionX = 0;

    private bool shouldJump = false;
    private bool shouldMoveLeft = false;
    private bool shouldMoveRight = false;

    // Start is called before the first frame update
    void Start() {
        rigidbody = GetComponent<Rigidbody>();
    }

    private void Update() {
        if (Input.GetKeyDown(KeyCode.Space)) {
            shouldJump = true;
        }

        if (Input.GetKeyDown(KeyCode.A)) {
            shouldMoveLeft = true;
        } else if (Input.GetKeyDown(KeyCode.D)) {
            shouldMoveRight = true;
        }
    }

    // Update is called once per frame
    void FixedUpdate() {
        Vector3 position = transform.position;
        position.z += 5.0f * Time.fixedDeltaTime;

        if (shouldMoveLeft) {
            tilePositionX -= 1;
            if (tilePositionX < -1) {
                tilePositionX = -1;
            } else {
                position.x -= 10.0f;
            }
            shouldMoveLeft = false;
        }

        if (shouldMoveRight) {
            tilePositionX += 1;
            if (tilePositionX > +1) {
                tilePositionX = +1;
            } else {
                position.x += 10.0f;
            }
            shouldMoveRight = false;
        }

        if (shouldJump) {
            rigidbody.AddForce(0.0f, 10.0f, 0.0f, ForceMode.Impulse);
            shouldJump = false;
        }

        transform.position = position;

        camera.transform.position = transform.position + new Vector3(0, 1, -5);
    }
}
