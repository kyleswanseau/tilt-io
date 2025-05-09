using System.Linq;
using UnityEngine;

public class ShieldPower : Power
{
    protected override void FixedUpdate()
    {

    }

    public override void Use(Vector3 position, float rotation)
    {
        Spawn();
    }

    public override void Trigger()
    {
        if (FindObjectsByType<ShieldPower>(FindObjectsSortMode.None).Count() <= 1)
        {
            Player.player.isInvincible = false;
        }
        Despawn();
    }

    public override void Spawn()
    {
        transform.position = Player.player.transform.position + new Vector3 (0f, 0f, 5f);
        transform.parent = Player.player.transform;
        transform.localScale = new Vector3(2.5f, 2f, 1f);
        transform.localEulerAngles = Vector3.zero;
        //Player.player.isInvincible = true;
    }
}
