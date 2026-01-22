using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    public static PlayerShooting instance;
    
    public GameObject bulletPrefabs;
    public float shootingInterval = 0.5f;
    public int weaponPower = 1;
    public int maxweaponPower = 5;

    private float lastBulletTime;

    void Awake()
    {
        instance = this;
    }

    void Update()
    {
        // Automatic shooting based on interval
        if (Time.time - lastBulletTime > shootingInterval)
        {
            ShootBullet();
            lastBulletTime = Time.time;
        }
    }

    private void ShootBullet()
    {
        Instantiate(bulletPrefabs, transform.position, transform.rotation);
    }
}