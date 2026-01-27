using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    public static PlayerShooting instance;

    public GameObject bulletPrefabs;
    public float shootingInterval;
    public Vector3 bulletOffset;
    
    public int weaponPower = 1;
    public int maxweaponPower = 5;

    private float lastBulletTime;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            UpdateFiring();
        }
    }

    private void UpdateFiring()
    {
        if (Time.time - lastBulletTime > shootingInterval)
        {
            ShootBullet();
            lastBulletTime = Time.time;
        }
    }

    private void ShootBullet()
    {
        var bullet = Instantiate(bulletPrefabs, transform.position + bulletOffset, transform.rotation);
    }
}