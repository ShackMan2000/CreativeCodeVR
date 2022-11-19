using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InsectManager : MonoBehaviour
{
    private List<GameObject> insects = new();
    [SerializeField] private GameObject insectPrefab;
    [SerializeField] private SphereCollider insectCollider;
    [SerializeField] private ControllerInfo leftController;

    [ContextMenu("spawn six of me baby")]
    public void Spawn5Insects()
    {
        SpawnInsect();
        SpawnInsect();
        SpawnInsect();
        SpawnInsect();
        SpawnInsect();
        SpawnInsect();
    }

    [ContextMenu("spawn me baby")]
    public void SpawnInsect() {
        GameObject newInsect = Instantiate(insectPrefab, transform);
        insects.Add(newInsect);

        var distance = leftController.GetMovementLastSeconds(1).magnitude;
        var lifespan = Random.Range(3f, 8f);
        newInsect.GetComponent<Insect>().Initialize(insectCollider.radius, insectCollider.center, distance, lifespan);
    }
}
