using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SpawnerOfEnemy : MonoBehaviour
{
    [SerializeField] private Enemy _enemy;
    [SerializeField] private List<Transform> _spawnPossitions;
    [SerializeField] private float _timeSpawning;

    private void Start()
    {
        Spawn();
    }

    public void Spawn() => StartCoroutine(Spawning());

    private IEnumerator Spawning()
    {
        bool isSpawning = true;
        WaitForSeconds wait = new WaitForSeconds(_timeSpawning);
        int counter = 0;

        while (isSpawning)
        {
            Instantiate(_enemy, _spawnPossitions[counter].position, Quaternion.identity);
            counter++;

            if (counter == _spawnPossitions.Count)
            {
                counter = 0;
            }

            yield return wait;
        }
    }

    private void OnDrawGizmos()
    {
        if (_spawnPossitions.Count > 0)
        {
            Gizmos.color = Color.magenta;
            float radius = .5f;

            foreach (Transform pointSpawn in _spawnPossitions)
            {
                Gizmos.DrawSphere(pointSpawn.position, radius);
            }
        }
    }
}
