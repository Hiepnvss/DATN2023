using ShootTank.Tank;
using System.Collections.Generic;
using UnityEngine;

namespace Script.Tank
{
    public class ButtletEnemy : EntityManager
    {
        public float velocityBullet = 2;
        public List<ParticleSystem> listEffectTankDie = null;
        void Update()
        {
            transform.Translate(0, Time.deltaTime * velocityBullet, 0);
        }
        private void OnTriggerEnter2D(Collider2D collision)
        {
            //if (collision.CompareTag("Wall"))
            //{
            //    SetDestroy();
            //}
            //if (collision.CompareTag("Stone"))
            //{
            //    SetDestroy();
            //}
            //if (collision.CompareTag("Brick"))
            //{
            //    Destroy(collision.gameObject);
            //    SetDestroy();
            //}
            //if (collision.CompareTag("Player"))
            //{
            //    SoundMusicManager.instance.TankDie();
            //    Vector3 posEffect = new Vector3(transform.position.x, transform.position.y + 0.2f, transform.position.z);
            //    Instantiate(listEffectTankDie[Random.Range(0, listEffectTankDie.Count - 1)], posEffect, Quaternion.identity);
            //    collision.gameObject.GetComponent<TankManager>().SetDestroy();
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
            //if (collision.CompareTag("BulletPlayer"))
            //{
               
            //    Destroy(collision.gameObject);
            //    SetDestroy();
            //}
        }
    }
}
