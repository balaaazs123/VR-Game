using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    public BulletController bullet_prefab;

    private Queue<BulletController> bullets = new Queue<BulletController>();

    public static ObjectPool Instance { get; set; }

    private void Awake()
    {
        Instance = this;
    }

    public BulletController GetBullet()
    {
        if(bullets.Count == 0)
        {
            BulletController projectile = Instantiate(bullet_prefab);
            projectile.gameObject.SetActive(false);
            bullets.Enqueue(projectile);
        }
        return bullets.Dequeue();
    }

    public void ReturnToPool(BulletController bullet)
    {
        bullet.gameObject.SetActive(false);
        bullets.Enqueue(bullet);
    }
}
