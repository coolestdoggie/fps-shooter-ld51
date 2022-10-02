using UnityEngine;

public class AttackAI : MonoBehaviour
{
    public float launchForce = 10.0f;
    public float cooldown = 3.0f;
    public int launchCount = 1;
    private GameObject _player;
    private Weapon _weapon;
    private float attackedAt = 0.0f;

    void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player");
        _weapon = GetComponentInChildren<Weapon>();
    }

    void Update()
    {
        float distance = Vector3.Distance(transform.position, _player.transform.position);
        Debug.Log((Time.time >= attackedAt + cooldown) + " " + Time.time + " " + (attackedAt + cooldown));
        if (distance <= 5.0f && Time.time >= attackedAt + cooldown)
        {
            ProjectileShot();
        }
    }

    private void ProjectileShot()
    {
        Debug.Log("Shot");
        for (int i = 0; i < launchCount; ++i)
        {
            float angle = Random.Range(0.0f, 10.0f * 0.5f);
            Vector2 angleDir = Random.insideUnitCircle * Mathf.Tan(angle * Mathf.Deg2Rad);

            Vector3 dir = transform.forward + (Vector3) angleDir;
            dir.Normalize();

            Projectile p = Instantiate(_weapon.projectilePrefab);
            p.Launch(_weapon, dir, launchForce);
        }
        attackedAt = Time.time;
    }
}