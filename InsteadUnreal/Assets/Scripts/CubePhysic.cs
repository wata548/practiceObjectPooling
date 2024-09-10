using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubePhysic : MonoBehaviour {
    [SerializeField] float power = 100f;
    [SerializeField] float deadLine = 0f;
    bool moveActive = false;

    public void StartMove() {
        moveActive = true;
    }

    void Update() {
        if (moveActive && GenerateCube.Active == true) {
            this.transform.position = new Vector2(this.transform.position.x, this.transform.position.y - power * Time.deltaTime);

            if(this.transform.position.y < deadLine) {
                ControleCubes.Instance.DeleteCube();
                moveActive = false;
            }
        }
    }
}
