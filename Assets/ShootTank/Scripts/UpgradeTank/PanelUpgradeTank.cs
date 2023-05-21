using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace ShootTank.Canvas.Home
{
    public class PanelUpgradeTank : PanelBase
    {
        [SerializeField] private Image imgTank;
        [SerializeField] private Button btnExit;

        [Space]
        [SerializeField] private Button btnUpgradeTankSpeed;
        [SerializeField] private Button btnUpgradeBulletSpeed;

        [Space]
        [SerializeField] private Text txtCoinUpgradeTankSpeed;
        [SerializeField] private Text txtCoinUpgradeBulletSpeed;

        [Space]
        [SerializeField] private Text txtSpeedTank;
        [SerializeField] private Text txtSpeedBulletTank;

        [Space]
        [SerializeField] private Text txtValueSpeedTank;
        [SerializeField] private Text txtValueSpeedBulletTank;

        [SerializeField] private List<Sprite> listSprTank = new List<Sprite>();

        [SerializeField] float valSpeedTank = 0.25f;
        [SerializeField] float valSpeedBulletTank = 0.25f;

        [Space]
        [SerializeField] float timeIncress = 1;
        [SerializeField] AnimationCurve animCurve;
        private float countTime = 0;

        private int valueCoinUpgradeTankSpeed = 200;
        private int valueCoinUpgradeBulletSpeed = 200;

        private string strSpeedTank;
        private string strSpeedBulletTank;

        public void ShowPanel()
        {
            base.Show();

            strSpeedTank = I2.Loc.ScriptLocalization.Tank_speed;
            strSpeedBulletTank = I2.Loc.ScriptLocalization.Bullet_speed;

            Init();
        }
        public void HidePanel()
        {
            base.Hide();
        }

        private void Init()
        {
            btnExit.interactable = true;
            imgTank.sprite = listSprTank[VariableSystem.TankColor];
           
            InitSpeedTank();
            InitSpeedBulletTank();
        }
        private void InitSpeedBulletTank()
        {
            if (VariableSystem.BulletSpeed >= 7)
            {
                btnUpgradeTankSpeed.interactable = false;
                txtCoinUpgradeTankSpeed.text = I2.Loc.ScriptLocalization.Max_upgrade;
                txtValueSpeedBulletTank.gameObject.SetActive(false);
                return;
            }

            btnUpgradeBulletSpeed.interactable = true;

            valueCoinUpgradeBulletSpeed = (int)(VariableSystem.BulletSpeed * 150);
            txtCoinUpgradeBulletSpeed.text = valueCoinUpgradeBulletSpeed.ToString();

            txtSpeedBulletTank.text = strSpeedBulletTank + ": " + (VariableSystem.BulletSpeed * 100);
            txtValueSpeedBulletTank.text = strSpeedBulletTank + " +" + (valSpeedBulletTank * 100);
        }
        private void InitSpeedTank()
        {
            if (VariableSystem.TankSpeed >= 5)
            {
                btnUpgradeTankSpeed.interactable = false;
                txtCoinUpgradeTankSpeed.text = I2.Loc.ScriptLocalization.Max_upgrade;
                txtValueSpeedTank.gameObject.SetActive(false);
                return;
            }

            btnUpgradeTankSpeed.interactable = true;

            valueCoinUpgradeTankSpeed = (int)(VariableSystem.TankSpeed * 150);
            txtCoinUpgradeTankSpeed.text = valueCoinUpgradeTankSpeed.ToString();

            txtSpeedTank.text = strSpeedTank + ": " + (VariableSystem.TankSpeed * 100);
            txtValueSpeedTank.text = strSpeedTank + " +" + (valSpeedTank * 100);
        }

        public void OnClickUpgradeTankSpeed()
        {
            if (valueCoinUpgradeTankSpeed > VariableSystem.StoreCoin)
            {
                string _str = I2.Loc.ScriptLocalization.Not_enough_coin;
                HomeUI.instance.ShowPopupNotResource(_str);
                return;
            }

            VariableSystem.StoreCoin -= valueCoinUpgradeTankSpeed;
            HomeUI.instance.storeCoin.SetCoin(valueCoinUpgradeTankSpeed, -1);

            Upgrade(valSpeedTank, 0);
        }
        public void OnClickUpgradeBulletSpeed()
        {
            if (valueCoinUpgradeBulletSpeed > VariableSystem.StoreCoin)
            {
                string _str = I2.Loc.ScriptLocalization.Not_enough_coin;
                HomeUI.instance.ShowPopupNotResource(_str);
                return;
            }
            VariableSystem.StoreCoin -= valueCoinUpgradeBulletSpeed;
            HomeUI.instance.storeCoin.SetCoin(valueCoinUpgradeBulletSpeed, -1);
            Upgrade(0, valSpeedBulletTank);
        }
        private void Upgrade(float valSpeedTank = 0, float valSpeedBulletTank = 0)
        {
            SoundMusicManager.instance.UpgradeTank();

            btnExit.interactable = false;
            btnUpgradeTankSpeed.interactable = false;
            btnUpgradeBulletSpeed.interactable = false;

            StartCoroutine(Incress(valSpeedTank, valSpeedBulletTank));
        }
        IEnumerator Incress(float valSpeedTank, float valSpeedBulletTank)
        {
            countTime = 0;
            while (countTime <= timeIncress)
            {
                yield return new WaitForEndOfFrame();

                countTime += Time.deltaTime;

                float _val = valSpeedTank * animCurve.Evaluate(countTime / timeIncress);
                txtSpeedTank.text = strSpeedTank + ": " + (int)((VariableSystem.TankSpeed * 100) + _val * 100) + "";


                float _val_1 = valSpeedBulletTank * animCurve.Evaluate(countTime / timeIncress);
                txtSpeedBulletTank.text = strSpeedBulletTank + ": " + (int)((VariableSystem.BulletSpeed * 100) + _val_1 * 100) + "";
            }

            VariableSystem.TankSpeed += valSpeedTank;
            VariableSystem.BulletSpeed += valSpeedBulletTank;

            Init();
        }
    }
}
