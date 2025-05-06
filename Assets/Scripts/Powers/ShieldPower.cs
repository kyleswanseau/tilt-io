using UnityEngine;

public class ShieldPower : Power
{
    protected override void FixedUpdate()
    {

    }

    public override void Use(Vector2 position, float rotation)
    {
        Spawn();
    }

    public override void Trigger()
    {
        Player.player.isInvincible = false;
        Despawn();
    }

    public override void Spawn()
    {
        transform.position = Player.player.transform.position + new Vector3 (0f, 0f, 5f);
        transform.parent = Player.player.transform;
        Player.player.isInvincible = true;
    }

    public override void Despawn()
    {
        Destroy(gameObject);
    }
}
