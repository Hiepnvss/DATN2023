using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.Events;

namespace ShootTank.Data
{
    public class StoreCoin : MonoBehaviour
    {
        [SerializeField] private Text txtCoin;
        [SerializeField] private AnimationCurve curve;
        [SerializeField] private float timeInit; // time transform text coin

        [SerializeField] GameObject coinSpawn;
        [SerializeField] GameObject parentSpawn;

        private int valueCoin;
        private float timeSpawnCoin;
        private float timeMoveCoin;
        private int amountCoinSpawn;
        private Vector3 positionSpawn;
        private Vector2 sizeDeltaOrigin;

        private Transform parentSpawnBegin;
        private float[] rangeRandom;
        private bool isChaneText;
        private int storeCoin = 0;

        private void Start()
        {
            InitCoin();
        }
        /// <summary>
        /// Set default coin
        /// </summary>
        public void InitCoin()
        {
            txtCoin.text = VariableSystem.StoreCoin.ToString();
        }
        /// <summary>
        /// set text coin
        /// </summary>
        /// <param name="amountCoin">Amount Coin</param>
        /// <param name="isIncress">increase or decrease ( 1 or -1 )</param>
        public void SetCoin(int amountCoin, int isIncress, UnityAction callback = null)
        {
            storeCoin = VariableSystem.StoreCoin;

            storeCoin -= amountCoin * isIncress;
            if (storeCoin <= 0)
                storeCoin = 0;

            StartCoroutine(IE_SetCoin(amountCoin, isIncress, callback));
        }

        /// <summary>
        /// coroutine inress coin
        /// </summary>
        /// <param name="amountCoin"></param>
        /// <param name="isIncress"></param>
        /// <returns></returns>
        IEnumerator IE_SetCoin(int amountCoin, int isIncress, UnityAction callback = null)
        {
            float timeCurrent = 0;
            while (timeCurrent < timeInit)
            {
                yield return new WaitForEndOfFrame();
                timeCurrent += Time.deltaTime;

                float valueWant = amountCoin * curve.Evaluate(timeCurrent / timeInit);
                txtCoin.text = storeCoin + (int)valueWant * isIncress + "";
            }
            callback?.Invoke();
            InitCoin();
        }

        /// <summary>
        /// Spawn coin and move coin to position
        /// </summary>
        /// <param name="_positionSpawn"> Vị trí sinh ra </param>
        /// <param name="_sizeDeltaOrigin"> Kích thước ban đầu </param>
        /// <param name="_valueCoin"> Số tiền được cộng </param>
        /// <param name="_amountCoinSpawn"> Số object sinh ra </param>
        /// <param name="_timeMoveCoin"> Thời gian coin di chuyển lên đích </param>
        /// <param name="_timeSpawnCoin"> Khoảng cách sinh Object </param>
        /// <param name="isChangeTextCoin"> Có thay đổi text hay không </param>
        public void EffectCoin(Vector3 _positionSpawn, Vector2 _sizeDeltaOrigin, int _valueCoin, int _amountCoinSpawn = 10, float _timeMoveCoin = 0.5f, float _timeSpawnCoin = 0.1f, bool isChangeTextCoin = false)
        {
            positionSpawn = _positionSpawn;
            sizeDeltaOrigin = _sizeDeltaOrigin;
            valueCoin = _valueCoin;
            timeMoveCoin = _timeMoveCoin;
            amountCoinSpawn = _amountCoinSpawn;
            timeSpawnCoin = _timeSpawnCoin;

            // rung hộp coin đích khi coin đang di chuyển lên
            this.transform.DOScale(0.95f, 0.1f).From(1).SetLoops(-1, LoopType.Yoyo).SetEase(Ease.Linear);


            if (isChangeTextCoin)
            {
                timeInit = amountCoinSpawn * timeSpawnCoin;
                SetCoin(valueCoin, 1);
            }
            StartCoroutine(SpawnCoin());
            SetSoundAddCoin();
        }
        /// <summary>
        /// Spawn Coin
        /// </summary>
        /// <returns></returns>
        private IEnumerator SpawnCoin()
        {
            int i = 0;
            while (i < amountCoinSpawn)
            {
                i++;
                GameObject _coinSpawn = Instantiate(coinSpawn, positionSpawn, Quaternion.identity, parentSpawn.transform);
                _coinSpawn.GetComponent<RectTransform>().sizeDelta = sizeDeltaOrigin;
                _coinSpawn.transform.DOLocalMove(Vector3.zero, timeMoveCoin).OnComplete(() => Destroy(_coinSpawn));
                _coinSpawn.GetComponent<RectTransform>()?.DOSizeDelta(parentSpawn.GetComponent<RectTransform>().sizeDelta, timeMoveCoin).OnComplete(() => Destroy(_coinSpawn));
                yield return new WaitForSeconds(timeSpawnCoin);
            }
            if (i >= amountCoinSpawn)
            {
                // tắt rung, trả về kích thước ban đầu
                this.transform.DOPause();
                this.transform.localScale = Vector3.one;
            }
        }
        /// <summary>
        /// Sinh tiền ra xung quanh 1 object
        /// Ví dụ SpawnCoinRandomPosition(Vector3.zero, this.transform,new float[2]{ 70,200}, storeCoin.transform.GetChild(1).GetComponent<RectTransform>().sizeDelta, 2000, 20, _isChaneText: true);
        /// </summary>
        /// <param name="_positionSpawn"> Vị trí sinh ra </param>
        /// <param name="_parentSpawnBegin"> Parent lúc đầu </param>
        /// <param name="_rangeRandom"> Phạm vi xung quanh </param>
        /// <param name="_sizeDeltaOrigin"> Kích thước ban đầu </param>
        /// <param name="_amountCoin"> Số lượng tiền được cộng </param>
        /// <param name="_amountCoinSpawn"> Số lượng object được sinh ra </param>
        /// <param name="_timeMoveCoin"> Thời gian object di chuyển ra xung quanh </param>
        /// <param name="_timeSpawnCoin"> Object sinh ra cách nhau một khoảng thời gian </param>
        /// <param name="isChangeTextCoin"> Thay đổi text Coin hay không </param>
        public void SpawnCoinRandomPosition(Vector3 _positionSpawn, Transform _parentSpawnBegin, float[] _rangeRandom, Vector2 _sizeDeltaOrigin, int _valueCoin, int _amountCoinSpawn = 10, float _timeMoveCoin = 2, float _timeSpawnCoin = 0f, bool _isChaneText = false, UnityAction callbackComplete = null)
        {
            positionSpawn = _positionSpawn;
            sizeDeltaOrigin = _sizeDeltaOrigin;

            valueCoin = _valueCoin;
            timeMoveCoin = _timeMoveCoin;
            timeSpawnCoin = _timeSpawnCoin;

            amountCoinSpawn = _amountCoinSpawn;
            parentSpawnBegin = _parentSpawnBegin;
            rangeRandom = _rangeRandom;
            isChaneText = _isChaneText;

            StartCoroutine(SpawnCoinRoundPosition(callbackComplete));
            timeInit = amountCoinSpawn * timeSpawnCoin;
            // set sound get coin
            Invoke(nameof(SetSoundAddCoin), timeInit + timeMoveCoin / 2);
        }
        private void SetSoundAddCoin()
        {
            SoundMusicManager.instance?.AddCoin();
        }
        private IEnumerator SpawnCoinRoundPosition(UnityAction callback = null)
        {
            int i = 0;
            while (i < amountCoinSpawn)
            {
                i++;
                GameObject _coinSpawn = Instantiate(coinSpawn, positionSpawn, Quaternion.identity, parentSpawnBegin);
                _coinSpawn.GetComponent<RectTransform>().sizeDelta = sizeDeltaOrigin;

                int x = 1;
                int y = 1;
                x = Random.Range(0, 2) == 0 ? -1 : x;
                y = Random.Range(0, 2) == 0 ? -1 : y;

                Vector3 randomPos = new Vector3(Random.Range(positionSpawn.x - rangeRandom[0], positionSpawn.x + rangeRandom[1]) * x, Random.Range(positionSpawn.y - rangeRandom[0], positionSpawn.y + rangeRandom[1]) * y, 0);
                _coinSpawn.GetComponent<RectTransform>().anchoredPosition = Vector2.zero;
                _coinSpawn.GetComponent<RectTransform>()?.DOAnchorPos(randomPos, timeMoveCoin).SetEase(Ease.OutCirc).OnComplete(() =>
                {
                    _coinSpawn.transform.SetParent ( parentSpawn.transform);
                    _coinSpawn.GetComponent<RectTransform>()?.DOAnchorPos(Vector3.zero, timeMoveCoin / 2);
                    _coinSpawn.GetComponent<RectTransform>()?.DOSizeDelta(parentSpawn.GetComponent<RectTransform>().sizeDelta, timeMoveCoin / 2).OnComplete(() => Destroy(_coinSpawn));
                });
                yield return new WaitForSeconds(timeSpawnCoin);
            }

            yield return new WaitForSeconds(timeMoveCoin);
            this.transform.DOScale(0.95f, 0.2f).From(1).SetLoops(-1, LoopType.Yoyo).SetEase(Ease.Linear);

            if (isChaneText)
                SetCoin(valueCoin, 1, callback);

            yield return new WaitForSeconds(timeInit);
            if (i >= amountCoinSpawn)
            {
                // tắt rung, trả về kích thước ban đầu
                this.transform.DOKill();
                this.transform.localScale = Vector3.one;
            }
        }
    }
}
