using UnityEngine;
using System.Collections.Generic;
using Unity.AI.Navigation;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private List<Patterns> patternsList;
    private Patterns currentPattern;
    private int currentObjectIndex;
    [SerializeField] private GameObject currentTrackingTarget;
    private int seed;

    [SerializeField] private NavMeshSurface navMeshSurface;

    private int createdObjectsCount;

    private void Awake()
    {
        seed = Random.Range(0, 10000);
        currentPattern = patternsList[seed % patternsList.Count];
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

        if (Vector3.Distance(transform.position,currentTrackingTarget.transform.position)<=50&&createdObjectsCount<=10)
        {
            Spawn();
        }
    }

    private void Spawn()
    {
        GameObject obj= Instantiate(currentPattern.objectPrefab[currentObjectIndex]);
        obj.transform.position = transform.position;
        transform.position += new Vector3(0, 0, 10);
        createdObjectsCount++;
        currentObjectIndex++;
        if(currentObjectIndex >= currentPattern.objectPrefab.Count)
        {
            currentObjectIndex = 0;
        }
        if (navMeshSurface.navMeshData != null)
        {
            navMeshSurface.UpdateNavMesh(navMeshSurface.navMeshData);
        }
        else
        {
            navMeshSurface.BuildNavMesh();
        }
    }

}
