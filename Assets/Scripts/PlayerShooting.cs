using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    public static PlayerShooting instance;
    
    public GameObject bulletPrefab;
    public int weaponPower = 1;
    public int maxweaponPower = 5;

    void Awake()
    {
        instance = this;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Instantiate(bulletPrefab, transform.position,
            transform.rotation);
        }
    }
}