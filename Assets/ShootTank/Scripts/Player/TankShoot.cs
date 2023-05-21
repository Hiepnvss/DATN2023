using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ShootTank.GameController;
using ShootTank.BulletManager;

namespace ShootTank.Tank
{
    public class TankShoot : MonoBehaviour
    {
        public TankManager tankManager;
        public Bullet bullet;
        public Bullet projectilePower;

        public int countBullet = 3;
        public float speedBullet = 2;

        public bool isShoot = true;

        private float timeReloadBullet = 0.75f;

        private IEnumerator IE_RELOAD = null;

        private void Start()
        {
            if (tankManager.typeTank == TypeTank.TankEnemy)
            {
                speedBullet = 2;
                timeReloadBullet = 0.75f;
            }
            else
            {
                speedBullet = VariableSystem.BulletSpeed;
                timeReloadBullet = 0.5f;
            }

        }

        public void OnShoot()
        {
            if (!isShoot)
                return;

            if (gameObject != null)
            {
                if (tankManager.typeTank == TypeTank.TankMain)
                    SoundMusicManager.instance.Bullet();

                if (VariableSystem.isPowerBullet)
                {
                    Bullet _b = Instantiate(bullet, transform.position, transform.rotation);

                    _b.InitInfor(TypeEntity.Bullet, tankManager.typeTank);
                    _b.velocityBullet = speedBullet;
                }
                else
                {
                    isShoot = false;
                    Bullet _b = Instantiate(bullet, transform.position, transform.rotation);

                    _b.InitInfor(TypeEntity.Bullet, tankManager.typeTank);
                    _b.velocityBullet = speedBullet;

                    IE_RELOAD = IE_Reload();
                    StartCoroutine(IE_RELOAD);
                }
            }
        }

        public void ChangeTimeReload()
        {
            timeReloadBullet = 0.5f - (VariableSystem.LevelTankInGame * 0.1f);
        }
        private IEnumerator IE_Reload()
        {
            yield return new WaitForSeconds(timeReloadBullet);
            isShoot = true;
        }
    }
}
