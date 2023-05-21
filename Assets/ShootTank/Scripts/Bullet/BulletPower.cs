using ShootTank.GameController.LevelLoad;
using System.Collections.Generic;
using UnityEngine;
using ShootTank.Tank;

namespace ShootTank.BulletManager
{
    public class BulletPower : EntityManager
    {
        public float velocityBullet = 2;
        int powerOfBullet = 3;
        public List<ParticleSystem> listEffectTankDie = null;


        // Start is called before the first frame update
        private void Start()
        {
        }
        // Update is called once per frame
        void Update()
        {
                transform.Translate(0, Time.deltaTime * velocityBullet, 0);
        }
        private void OnTriggerEnter2D(Collider2D collision)
        {
            //if (collision.CompareTag("Wall"))
            //{
            //    SoundMusicManager.instance.BuzzStone();
            //    //TankShoot.instance.listBulletPower.Remove(this);
            //    SetDestroy();
            //}
            //if (collision.CompareTag("Stone"))
            //{
            //    SoundMusicManager.instance.BuzzStone();
            //    //  TankShoot.instance.listBulletPower.Remove(this);
            //    Destroy(collision.gameObject);
            //    SetDestroy();
            //}
            //if (collision.CompareTag("Brick"))
            //{
            //    SoundMusicManager.instance.BuzzBrick();
            //    powerOfBullet--;
            //    Destroy(collision.gameObject);
            //    if (powerOfBullet == 0)
            //    {
            //        //     TankShoot.instance.listBulletPower.Remove(this);
            //        SetDestroy();
            //    }
            //}
            //if (collision.CompareTag("Enemy"))
            //{
            //    SoundMusicManager.instance.TankDie();
            //    Vector3 posEffect = new Vector3(transform.position.x, transform.position.y + 0.2f, transform.position.z);
            //    Instantiate(listEffectTankDie[Random.Range(0, listEffectTankDie.Count - 1)], posEffect, Quaternion.identity);
            //    //  TankShoot.instance.listBulletPower.Remove(this);
            //    collision.gameObject.GetComponent<TankEnemyManager>().SetDestroy();
            //    SetDestroy();
            //}
            //if (collision.CompareTag("Main"))
            //{
            //    SoundMusicManager.instance.TankDie();
            //    Vector3 posEffect = new Vector3(transform.position.x, transform.position.y + 0.2f, transform.position.z);
            //    Instantiate(listEffectTankDie[Random.Range(0, listEffectTankDie.Count - 1)], posEffect, Quaternion.identity);
            //    collision.gameObject.GetComponent<Main>().SetDestroy();
            //    SetDestroy();
            //}
            //if (collision.CompareTag("BulletEnemy"))
            //{
            //    powerOfBullet--;
            //    Destroy(collision.gameObject);
            //    if (powerOfBullet == 0)
            //    {
            //        //    TankShoot.instance.listBulletPower.Remove(this);
            //        SetDestroy();
            //    }
            //}
        }
    }
}

