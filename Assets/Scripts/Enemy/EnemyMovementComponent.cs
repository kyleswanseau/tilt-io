using UnityEngine;

public class EnemyMovementComponent : MonoBehaviour
{
    private const float minAggroDistance = 40f;
    private const float maxAggroDistance = 100f;
    private const float aggroMult = 10f;

    private Camera _cam;
    private PlayerMovementComponent _playerController;
    private Vector2 _playerPos;
    private Vector2 _myPos;

    private void Start()
    {
        _cam = Camera.main;
        _playerController = GameObject.FindWithTag("Player").GetComponent<PlayerMovementComponent>();
    }

    private void FixedUpdate()
    {
        // Get positions of player model and this enemy
        _playerPos = _playerController.playerPos;
        _myPos = _cam.WorldToScreenPoint(transform.position);

        // Compute movement speed as function of distance to player
        float distanceToPlayer = (float)System.Math.Floor(Vector2.Distance(_myPos, _playerPos));
        float moveMag = 
            (distanceToPlayer > maxAggroDistance ? 
            aggroMult : distanceToPlayer > minAggroDistance ? 
            (1f - (distanceToPlayer - minAggroDistance) / (maxAggroDistance - minAggroDistance)) * aggroMult + aggroMult : aggroMult * 2);
        
        // Compute movement direction
        Vector2 moveVector = _playerPos - _myPos;
        float moveAngle = Vector2.SignedAngle(Vector2.up, moveVector);

        // Rotate and translate this enemy
        transform.eulerAngles = new Vector3(0f, 0f, moveAngle);
        transform.Translate(Vector2.up * (moveMag / 500f));

        // WIP code that stretches enemies when they move faster
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
