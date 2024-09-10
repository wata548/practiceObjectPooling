using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateCube : MonoBehaviour
{
    [SerializeField] GameObject cubePrefab;
    [SerializeField] float GENERATE_TERM = 3;
    [SerializeField] int sumLine = 5;
    public static bool Active{ private set; get; }
    float timer = 0;

    void Start()
    {
        Active = true;

        for(int i = 0; i < 1600; i++) {
            ControleCubes.Instance.GenerateCube(cubePrefab).transform.position = new Vector2(0, -3);
        }
    }


    void Update()
    {
        timer += Time.deltaTime;

        if(timer >= GENERATE_TERM) {
            timer = 0;
            
            int randomCount = Random.Range(1, sumLine);

            List<int> array = new();
            for(int i = 0; i < sumLine; i++) {
                array.Add(i);
            }

            for(int i = 0; i < randomCount; i++) {
                int randomIndex = Random.Range(0, array.Count);
                ControleCubes.Instance.GenerateCube(cubePrefab, array[randomIndex]);
                array.RemoveAt(randomIndex);
            }

        }
    }
}
