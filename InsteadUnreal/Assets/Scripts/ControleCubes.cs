using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ControleCubes : MonoBehaviour
{
    public static ControleCubes Instance { get; private set; } = null;
    [SerializeField] float startCoorY = 7;
    [SerializeField] float startCoorX = -3.3f;
    [SerializeField] float intervalX = 1.1f;

    Queue<GameObject> objectPooling = new();
    Queue<GameObject> activeCube = new();
    void Awake()
    {
        if(Instance == null) {
            Instance = this;
        }
    }

    public GameObject GenerateCube(GameObject cube, int line = 0) {
        GameObject newCude;
        if (objectPooling.Count == 0) {
            newCude = Instantiate(cube);
        }

        else {
            newCude = objectPooling.Dequeue();
            newCude.GetComponent<SpriteRenderer>().enabled = true;
        }

        newCude.GetComponent<CubePhysic>().StartMove();
        activeCube.Enqueue(newCude);
        newCude.transform.position = new Vector2(startCoorX + intervalX * line, startCoorY);

        return newCude;
    }

    public void DeleteCube() {
        GameObject target = activeCube.Dequeue();

        target.GetComponent<SpriteRenderer>().enabled = false;

        objectPooling.Enqueue(target);
    }

}
