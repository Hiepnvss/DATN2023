using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ShootTank.Tank
{
    public class TankEnemyMove : MonoBehaviour
    {
        public float speed;
        bool move = false;
        DirectMove direct;
        float deltaMove;
        private void Start()
        {
            deltaMove = Time.deltaTime * speed;
            StartCoroutine(ChangeDirection());
            direct = GetDirectionMove();
        }
        void MoveDeult()
        {
            direct = DirectMove.Down;
            transform.rotation = Quaternion.Euler(0, 0, 180);
            transform.position = new Vector3(transform.position.x, transform.position.y + deltaMove * -1, 0);
        }
        private void Update()
        {
            TankMove();
        }

        IEnumerator ChangeDirection()
        {
            while (true)
            {
                yield return new WaitForSeconds(5);
                direct = GetDirectionMove();
            }
        }
        DirectMove GetDirectionMove()
        {
            switch (Random.Range(1, 5))
            {
                case 1:
                    if (direct == DirectMove.Top)
                        GetDirectionMove();
                    return DirectMove.Top;
                case 2:
                    if (direct == DirectMove.Down)
                        GetDirectionMove();
                    return DirectMove.Down;
                case 3:
                    if (direct == DirectMove.Left)
                        GetDirectionMove();
                    return DirectMove.Left;
                case 4:
                    if (direct == DirectMove.Right)
                        GetDirectionMove();
                    return DirectMove.Right;
            }
            return DirectMove.None;
        }
        void TankMove()
        {
            switch (direct)
            {
                case DirectMove.Top:
                    transform.rotation = Quaternion.Euler(0, 0, 0);
                    transform.position = new Vector3(transform.position.x, transform.position.y + deltaMove, 0);
                    break;
                case DirectMove.Down:
                    transform.rotation = Quaternion.Euler(0, 0, 180);
                    transform.position = new Vector3(transform.position.x, transform.position.y + deltaMove * -1, 0);
                    break;
                case DirectMove.Right:
                    transform.rotation = Quaternion.Euler(0, 0, -90);
                    transform.position = new Vector3(transform.position.x + deltaMove, transform.position.y, 0);
                    break;
                case DirectMove.Left:
                    transform.rotation = Quaternion.Euler(0, 0, 90);
                    transform.position = new Vector3(transform.position.x + deltaMove * -1, transform.position.y, 0);
                    break;
                default:
                    break;
            }
        }
        //private void OnTriggerEnter2D(Collider2D collision)
        //{
        //    if (collision.CompareTag("Brick") || collision.CompareTag("Stone") || collision.CompareTag("Water") || collision.CompareTag("Wall"))
        //    {
        //        direct = GetDirectionMove();
        //    }
        //}
        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.collider.CompareTag("Brick") || collision.collider.CompareTag("Stone") || collision.collider.CompareTag("Water") || collision.collider.CompareTag("Wall"))
            {
                direct = GetDirectionMove();
            }
        }
    }

}