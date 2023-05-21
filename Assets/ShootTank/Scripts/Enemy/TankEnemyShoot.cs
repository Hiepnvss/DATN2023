using Script.Tank;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ShootTank.Tank
{
    public class TankEnemyShoot : MonoBehaviour
    {
        public ButtletEnemy buttletEnemy;
        public float speedBullte;

        private void Start()
        {
            StartCoroutine(Shoot());
        }
        private void OnShoot()
        {
        }

        IEnumerator Shoot()
        {
            float timeShoot = Random.Range(2, 4);
            while (true)
            {
                yield return new WaitForSeconds(timeShoot);
                switch (Random.Range(0, 2))
                {
                    case 0:
                        OnShoot();
                        yield return new WaitForSeconds(0.5f);
                        OnShoot();
                        yield return new WaitForSeconds(0.5f);
                        OnShoot();
                        break;
                    case 1:
                        OnShoot();
                        break;
                }
            }
        }
    }
}