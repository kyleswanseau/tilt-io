using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    private float _count = 0f;
    private ObjectPoolComponent _objectPoolComp;

    private void Start()
    {
        _objectPoolComp = GetComponent<ObjectPoolComponent>();
    }

    private void FixedUpdate()
    {
        _count += Time.deltaTime;
        if (_count + Time.deltaTime >= 3f)
        {
            _count = 0f;
            GameObject enemy = _objectPoolComp.Get();
            enemy.transform.position = Vector3.zero;
        }
    }
}
