using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ShootTank.Tank;
using ShootTank.GameController;

namespace ShootTank.Item
{
    public class SupportItem : MonoBehaviour
    {
        [SerializeField] private SpriteRenderer spriteRenderer;
        private void Start()
        {
            IE_SHOW = IE_Show();
            StartCoroutine(IE_SHOW);
        }

        IEnumerator IE_SHOW = null;
        IEnumerator IE_Show()
        {
            while (true)
            {
                yield return new WaitForSeconds(0.1f);
                spriteRenderer.enabled = !spriteRenderer.enabled;
            }
        }

        protected virtual void OnTriggerEnter2D(Collider2D collision)
        {
            TankManager t = collision.gameObject.GetComponent<TankManager>();
            if (t != null)
            {
                if (t.typeTank == TypeTank.TankMain)
                {
                    GamePlayController.instance.RandomItem();
                    Destroy(gameObject);
                }
            }
        }
    }
}