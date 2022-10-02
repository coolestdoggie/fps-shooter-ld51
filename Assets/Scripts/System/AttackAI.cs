using UnityEngine;

public class AttackAI : MonoBehaviour
{
    public float launchForce = 10.0f;
    public float cooldown = 3.0f;
    public int launchCount = 1;
    public float launchDistance = 5.0f;
    public float spreadAngle = 10f;
    public Transform launchPoint;
    public Projectile projectilePrefab;
    private GameObject _player;
    private float _attackedAt = 0.0f;

    void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        float distance = Vector3.Distance(transform.position, _player.transform.position);
        if (distance <= launchDistance && Time.time >= _attackedAt + cooldown)
        {
            ProjectileShot();
        }
    }

    private void ProjectileShot()
    {
        for (int i = 0; i < launchCount; ++i)
        {
            float angle = Random.Range(0.0f, spreadAngle * 0.5f);
            Vector2 angleDir = Random.insideUnitCircle * Mathf.Tan(angle * Mathf.Deg2Rad);

            Vector3 dir = transform.forward + (Vector3) angleDir;
            dir.Normalize();

            Projectile p = Instantiate(projectilePrefab);
            Weapon weapon = new Weapon();
            weapon.EndPoint = launchPoint;
            p.Launch(weapon, dir, launchForce);
        }
        _attackedAt = Time.time;
    }
}