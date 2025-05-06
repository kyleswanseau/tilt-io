using UnityEngine;

public class ExplosionBehaviour : MonoBehaviour, IAttack
{
    private void Start()
    {
        gameObject.SetActive(false);
    }

    public void Spawn()
    {
        gameObject.SetActive(true);
    }

    public void Despawn()
    {
        gameObject.SetActive(false);
    }
}
