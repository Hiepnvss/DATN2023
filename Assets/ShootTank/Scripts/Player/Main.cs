using ShootTank.Canvas.GamePlay;

namespace ShootTank.Tank
{
    public class Main : EntityManager
    {
        public static Main instance;
        public TankEffect tankEffect;
        private void Awake()
        {
            if (instance == null)
                instance = this;
        }
    }
}
