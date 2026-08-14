using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.EventSystems;

public class Weapon : MonoBehaviour, IRestartable
{
    protected PlayerAnimation playerAnimator;

    protected List<Bullet> bullets = new();
    protected GameObject bulletPrefab;
    protected float bulletSpeed = 50f;
    protected float bulletDamage = 20f;

    private float fireRate = 0.2f;
    protected float fireRateAtStart;

    protected Transform player;

    public void Initialize()
    {
        playerAnimator = transform.GetComponent<PlayerAnimation>();

        bulletPrefab = Resources.Load<GameObject>("Bullet");

        fireRateAtStart = fireRate;

        player = transform.GetComponent<Transform>();
    }

    private void Update()
    {
        playerAnimator.ShootAnimation(Input.GetMouseButton(0));
        fireRate -= Time.deltaTime;

        if (Input.GetMouseButtonDown(0) && !EventSystem.current.IsPointerOverGameObject() && fireRate <= 0)
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

        bullets = FindObjectsOfType<Bullet>().ToList();

        Bullet bulletComponent = bullet.transform.GetComponent<Bullet>();
        bulletComponent.speed = bulletSpeed;
        bulletComponent.damage = bulletDamage;

        fireRate = fireRateAtStart;
    }

    public void Restart()
    {
        foreach (Bullet bullet in bullets)
        {
            Destroy(bullet != null ? bullet.gameObject : null);
        }
    }
}
