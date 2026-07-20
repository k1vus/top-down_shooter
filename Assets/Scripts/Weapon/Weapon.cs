using UnityEngine;

public class Weapon : MonoBehaviour
{
    protected GameObject bulletPrefab;
    protected float bulletSpeed = 50f;
    protected float bulletDamage = 20f;

    private float fireRate = 0.5f;
    protected float fireRateAtStart;

    protected Transform player;

    protected void Awake()
    {
        bulletPrefab = Resources.Load<GameObject>("Bullet");

        fireRateAtStart = fireRate;

        player = transform.GetComponent<Transform>();
    }

    private void Update()
    {
        fireRate -= Time.deltaTime;

        if (Input.GetMouseButton(0) && fireRate <= 0)
        {
            Shoot();
        }
    }

    public void Shoot()
    {
        Vector2 position = (Vector2)player.position;

        // Calculate rotation
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 direction = mousePosition - (Vector2)player.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90;
        Quaternion rotation = Quaternion.Euler(0, 0, angle);

        GameObject bullet = Instantiate(bulletPrefab, position, rotation);

        Bullet bulletComponent = bullet.transform.GetComponent<Bullet>();
        bulletComponent.speed = bulletSpeed;
        bulletComponent.damage = bulletDamage;

        fireRate = fireRateAtStart;
    }
}
