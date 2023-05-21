using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.Events;

namespace StickmanRagdoll.Data
{
    public class StoreGem : PanelBase
    {
        [SerializeField] private Text txtGem;
        [SerializeField] private AnimationCurve curve;
        [SerializeField] private float timeInit; // time transform text Gem

        [SerializeField] GameObject gemSpawn;
        [SerializeField] GameObject parentSpawn;

        private int valueGem;
        private float timeSpawnGem;
        private float timeMoveGem;
        private int amountGemSpawn;
        private Vector3 positionSpawn;
        private Vector2 sizeDeltaOrigin;

        private Transform parentSpawnBegin;
        private float[] rangeRandom;
        private bool isChaneText;
        private int storeGem = 0;

        private void Start()
        {
            InitGem();
        }
        public void OnClickGetGem()
        {
            SoundClickButton();
        }
        /// <summary>
        /// Set default Gem
        /// </summary>
        public void InitGem()
        {
            txtGem.text = VariableSystem.StoreGem.ToString();
        }
        /// <summary>
        /// set text Gem
        /// </summary>
        /// <param name="amountGem">Amount Gem</param>
        /// <param name="isIncress">increase or decrease ( 1 or -1 )</param>
        public void SetGem(int amountGem, int isIncress, UnityAction callback = null)
        {
            storeGem = VariableSystem.StoreGem;

            storeGem -= amountGem * isIncress;
            if (storeGem <= 0)
                storeGem = 0;

            StartCoroutine(IE_SetGem(amountGem, isIncress, callback));
        }

        /// <summary>
        /// coroutine inress Gem
        /// </summary>
        /// <param name="amountGem"></param>
        /// <param name="isIncress"></param>
        /// <returns></returns>
        IEnumerator IE_SetGem(int amountGem, int isIncress, UnityAction callback = null)
        {
            float timeCurrent = 0;
            while (timeCurrent < timeInit)
            {
                yield return new WaitForEndOfFrame();
                timeCurrent += Time.deltaTime;

                float valueWant = amountGem * curve.Evaluate(timeCurrent / timeInit);
                txtGem.text = storeGem + (int)valueWant * isIncress + "";
            }
            callback?.Invoke();
            InitGem();
        }

        /// <summary>
        /// Spawn Gem and move Gem to position
        /// </summary>
        /// <param name="_positionSpawn"> V? tr? sinh ra </param>
        /// <param name="_sizeDeltaOrigin"> K?ch th??c ban ??u </param>
        /// <param name="_valueGem"> S? ti?n ???c c?ng </param>
        /// <param name="_amountGemSpawn"> S? object sinh ra </param>
        /// <param name="_timeMoveGem"> Th?i gian Gem di chuy?n l?n ??ch </param>
        /// <param name="_timeSpawnGem"> Kho?ng c?ch sinh Object </param>
        /// <param name="isChangeTextGem"> C? thay ??i text hay kh?ng </param>
        public void EffectGem(Vector3 _positionSpawn, Vector2 _sizeDeltaOrigin, int _valueGem, int _amountGemSpawn = 10, float _timeMoveGem = 0.5f, float _timeSpawnGem = 0.1f, bool isChangeTextGem = false)
        {
            positionSpawn = _positionSpawn;
            sizeDeltaOrigin = _sizeDeltaOrigin;
            valueGem = _valueGem;
            timeMoveGem = _timeMoveGem;
            amountGemSpawn = _amountGemSpawn;
            timeSpawnGem = _timeSpawnGem;

            // rung h?p Gem ??ch khi Gem ?ang di chuy?n l?n
            this.transform.DOScale(0.95f, 0.1f).From(1).SetLoops(-1, LoopType.Yoyo).SetEase(Ease.Linear);


            if (isChangeTextGem)
            {
                timeInit = amountGemSpawn * timeSpawnGem;
                SetGem(valueGem, 1);
            }
            StartCoroutine(SpawnGem());
            SetSoundAddGem();
        }
        /// <summary>
        /// Spawn Gem
        /// </summary>
        /// <returns></returns>
        private IEnumerator SpawnGem()
        {
            int i = 0;
            while (i < amountGemSpawn)
            {
                i++;
                GameObject _GemSpawn = Instantiate(gemSpawn, positionSpawn, Quaternion.identity, parentSpawn.transform);
                _GemSpawn.GetComponent<RectTransform>().sizeDelta = sizeDeltaOrigin;
                _GemSpawn.transform.DOLocalMove(Vector3.zero, timeMoveGem).OnComplete(() => Destroy(_GemSpawn));
                _GemSpawn.GetComponent<RectTransform>()?.DOSizeDelta(parentSpawn.GetComponent<RectTransform>().sizeDelta, timeMoveGem).OnComplete(() => Destroy(_GemSpawn));
                yield return new WaitForSeconds(timeSpawnGem);
            }
            if (i >= amountGemSpawn)
            {
                // t?t rung, tr? v? k?ch th??c ban ??u
                this.transform.DOPause();
                this.transform.localScale = Vector3.one;
            }
        }
        /// <summary>
        /// Sinh ti?n ra xung quanh 1 object
        /// V? d? SpawnGemRandomPosition(Vector3.zero, this.transform,new float[2]{ 70,200}, storeGem.transform.GetChild(1).GetComponent<RectTransform>().sizeDelta, 2000, 20, _isChaneText: true);
        /// </summary>
        /// <param name="_positionSpawn"> V? tr? sinh ra </param>
        /// <param name="_parentSpawnBegin"> Parent l?c ??u </param>
        /// <param name="_rangeRandom"> Ph?m vi xung quanh </param>
        /// <param name="_sizeDeltaOrigin"> K?ch th??c ban ??u </param>
        /// <param name="_amountGem"> S? l??ng ti?n ???c c?ng </param>
        /// <param name="_amountGemSpawn"> S? l??ng object ???c sinh ra </param>
        /// <param name="_timeMoveGem"> Th?i gian object di chuy?n ra xung quanh </param>
        /// <param name="_timeSpawnGem"> Object sinh ra c?ch nhau m?t kho?ng th?i gian </param>
        /// <param name="isChangeTextGem"> Thay ??i text Gem hay kh?ng </param>
        public void SpawnGemRandomPosition(Vector3 _positionSpawn, Transform _parentSpawnBegin, float[] _rangeRandom, Vector2 _sizeDeltaOrigin, int _valueGem, int _amountGemSpawn = 10, float _timeMoveGem = 2, float _timeSpawnGem = 0f, bool _isChaneText = false, UnityAction callbackComplete = null)
        {
            positionSpawn = _positionSpawn;
            sizeDeltaOrigin = _sizeDeltaOrigin;

            valueGem = _valueGem;
            timeMoveGem = _timeMoveGem;
            timeSpawnGem = _timeSpawnGem;

            amountGemSpawn = _amountGemSpawn;
            parentSpawnBegin = _parentSpawnBegin;
            rangeRandom = _rangeRandom;
            isChaneText = _isChaneText;

            StartCoroutine(SpawnGemRoundPosition(callbackComplete));
            timeInit = amountGemSpawn * timeSpawnGem;
            // set sound get Gem
            Invoke(nameof(SetSoundAddGem), timeInit + timeMoveGem / 2);
        }
        private void SetSoundAddGem()
        {
            // AudioController.instance?.AddGem();
        }
        private IEnumerator SpawnGemRoundPosition(UnityAction callback = null)
        {
            int i = 0;
            while (i < amountGemSpawn)
            {
                i++;
                GameObject _GemSpawn = Instantiate(gemSpawn, positionSpawn, Quaternion.identity, parentSpawnBegin);
                _GemSpawn.GetComponent<RectTransform>().sizeDelta = sizeDeltaOrigin;

                int x = 1;
                int y = 1;
                x = Random.Range(0, 2) == 0 ? -1 : x;
                y = Random.Range(0, 2) == 0 ? -1 : y;

                Vector3 randomPos = new Vector3(Random.Range(positionSpawn.x - rangeRandom[0], positionSpawn.x + rangeRandom[1]) * x, Random.Range(positionSpawn.y - rangeRandom[0], positionSpawn.y + rangeRandom[1]) * y, 0);
                _GemSpawn.GetComponent<RectTransform>().anchoredPosition = Vector2.zero;
                _GemSpawn.GetComponent<RectTransform>()?.DOAnchorPos(randomPos, timeMoveGem).SetEase(Ease.OutCirc).OnComplete(() =>
                {
                    _GemSpawn.transform.SetParent(parentSpawn.transform);
                    _GemSpawn.GetComponent<RectTransform>()?.DOAnchorPos(Vector3.zero, timeMoveGem / 2);
                    _GemSpawn.GetComponent<RectTransform>()?.DOSizeDelta(parentSpawn.GetComponent<RectTransform>().sizeDelta, timeMoveGem / 2).OnComplete(() => Destroy(_GemSpawn));
                });
                yield return new WaitForSeconds(timeSpawnGem);
            }

            yield return new WaitForSeconds(timeMoveGem);
            this.transform.DOScale(0.95f, 0.2f).From(1).SetLoops(-1, LoopType.Yoyo).SetEase(Ease.Linear);

            if (isChaneText)
                SetGem(valueGem, 1, callback);

            yield return new WaitForSeconds(timeInit);
            if (i >= amountGemSpawn)
            {
                // t?t rung, tr? v? k?ch th??c ban ??u
                this.transform.DOKill();
                this.transform.localScale = Vector3.one;
            }
        }
    }
}
