using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyNinjaShotgun : MonoBehaviour
{
    /// <summary>
    /// Petka nenc anel vor patronnery destroy charven ayl texapoxven startpoint
    /// </summary>
    public GameObject patron;
    public  Transform shotpoint;
    private float tBTWattack;
    public float starttBTWattack;
    // Start is called before the first frame update
    void Start()
    {
        ///starttime = (int)Time.unscaledTime;
        
    }
    
    // Update is called once per frame
    void Update()
    {
        if (NinjaWithShotGun.hasContact)
        {
            if (tBTWattack <= 0)
            {
                Instantiate(patron, shotpoint.position, transform.rotation);
                tBTWattack = starttBTWattack;
            }
            else
            {
                tBTWattack -= Time.deltaTime;
            }

        }
    }
}