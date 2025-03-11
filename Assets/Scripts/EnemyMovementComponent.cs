using UnityEngine;

public class EnemyMovementComponent : MonoBehaviour
{
    private const float minAggroDistance = 40f;
    private const float maxAggroDistance = 100f;
    private const float aggroMult = 10f;

    private Camera _cam;
    private Vector2 _playerPos;
    private Vector2 _myPos;

    private void Start()
    {
        _cam = Camera.main;
    }

    private void FixedUpdate()
    {
        _playerPos = GameObject.FindWithTag("Player").GetComponent<PlayerMovementComponent>().playerPos;
        _myPos = _cam.WorldToScreenPoint(transform.position);
        float distanceToPlayer = (float)System.Math.Floor(Vector2.Distance(_myPos, _playerPos));
        float moveMag = (distanceToPlayer > maxAggroDistance ? aggroMult : distanceToPlayer > minAggroDistance ? (1f - (distanceToPlayer - minAggroDistance) / (maxAggroDistance - minAggroDistance)) * aggroMult + aggroMult : aggroMult * 2);
        Vector2 moveVector = _playerPos - _myPos;
        float moveAngle = Vector2.SignedAngle(Vector2.up, moveVector);
        transform.eulerAngles = new Vector3(0f, 0f, moveAngle);
        transform.Translate(Vector2.up * (moveMag / 500f));
        /*
        if (moveMag > aggroMult)
        {
            Vector3 baseScale = new Vector3(0.2f, 0.2f, 1f);
            Vector3 chaseScale = new Vector3(1f, moveMag / aggroMult, 1f);
            transform.localScale = Vector3.Scale(baseScale, chaseScale);
        }
        */
        //Debug.Log(moveMag / aggroMult);
    }
}
