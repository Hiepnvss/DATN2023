using ShootTank.GameController.LevelLoad;
using ShootTank.Tank;
using System.Collections.Generic;
using UnityEngine;

namespace ShootTank.BulletManager
{
    public class Bullet : Bullets
    {
        public float velocityBullet = 2;
        // Start is called before the first frame update
        public List<ParticleSystem> listEffectTankDie = null;
        // Update is called once per frame
        void Update()
        {
            transform.Translate(0, Time.deltaTime * velocityBullet, 0);
        }
        //private void OnTriggerEnter2D(Collider2D collision)
        //{
        //    if (collision.CompareTag("Wall") || collision.CompareTag("Stone"))
        //    {
        //        SoundMusicManager.instance.BuzzStone();
        //        //TankShoot.instance.listBullet.Remove(this);
        //        SetDestroy();
        //    }
        //    if (collision.CompareTag("Brick"))
        //    {
        //        SoundMusicManager.instance.BuzzBrick();
        //        //TankShoot.instance.listBullet.Remove(this);
        //        Destroy(collision.gameObject);
        //        SetDestroy();
        //    }
        //    if (collision.CompareTag("Enemy"))
        //    {
        //        // TankShoot.instance.listBullet.Remove(this);
        //        Vector3 posEffect = new Vector3(transform.position.x, transform.position.y + 0.2f, transform.position.z);
        //        Instantiate(listEffectTankDie[Random.Range(0, listEffectTankDie.Count - 1)], posEffect, Quaternion.identity);
        //        SoundMusicManager.instance.TankDie();

        //        collision.gameObject.GetComponent<TankEnemyManager>().SetDestroy();
        //        SetDestroy();
        //    }
        //    if (collision.CompareTag("Main"))
        //    {
        //        Vector3 posEffect = new Vector3(transform.position.x, transform.position.y + 0.2f, transform.position.z);
        //        Instantiate(listEffectTankDie[Random.Range(0, listEffectTankDie.Count - 1)], posEffect, Quaternion.identity);
        //        SoundMusicManager.instance.TankDie();
        //        collision.gameObject.GetComponent<Main>().SetDestroy();
        //        SetDestroy();
        //    }
        //    if (collision.CompareTag("BulletEnemy"))
        //    {
        //        // TankShoot.instance.listBullet.Remove(this);
        //        Destroy(collision.gameObject);
        //        SetDestroy();
        //    }
        //}
    }
}
