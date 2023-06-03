using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float shootTime = 0.3f;
    private float lastShootTime = 0;

    private GvrReticlePointer aimCross;

    private static float healthPoint = 100f;
    public static float Health {get{return healthPoint; } set { healthPoint = value; }  }
    public static int score = 0;

    public Transform firepoint;

    void FixedUpdate()
    {
        if (lastShootTime > Time.time - shootTime)
            return;
        var target = aimCross.CurrentRaycastResult;
        if(target.gameObject)
        {
            if(target.gameObject.tag == "Enemy")
            {
                Fire();
                lastShootTime = Time.time;
            }
        }
    }

    public void Fire()
    {
        var projectile = ObjectPool.Instance.GetBullet();
        projectile.transform.position = firepoint.position;
        projectile.transform.rotation = Quaternion.Euler(90, 0, 0);
        projectile.gameObject.SetActive(true);
        projectile.GetComponent<Rigidbody>().velocity = Vector3.zero;
        projectile.GetComponent<Rigidbody>().AddForce(BulletController.bulletSpeed * firepoint.transform.forward);
    }

}
