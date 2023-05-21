using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ShootTank.Tank
{
    public class TankEffect : MonoBehaviour
    {
        [SerializeField] private List<ParticleSystem> listPsTankDie;



        public void PlayEffectTankDie()
        {
            if (listPsTankDie.Count == 0)
                return;

            int _rd = Random.Range(0, listPsTankDie.Count);
            ParticleSystem ps = Instantiate(listPsTankDie[_rd],transform.position,Quaternion.identity);
            PlaySoundEffect(ps);
        }

        private void PlaySoundEffect(ParticleSystem ps)
        {
            if (!SoundMusicManager.instance.GetSound())
                if (ps.GetComponent<AudioSource>() != null)
                    Destroy(ps.GetComponent<AudioSource>());
        }
    }
}
