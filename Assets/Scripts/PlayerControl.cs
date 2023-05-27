using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public float shootTime = 0.3f;
    private float lastShootTime = 0;

    private GvrReticlePointer aimCross;

    private static float healthPoint = 100f;
    public static float Health {get{return healthPoint; } set { healthPoint = value; }  }
    public static int score = 0;

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

    }

}
