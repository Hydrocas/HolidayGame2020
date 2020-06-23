///-----------------------------------------------------------------
/// Author : Hugo TEYSSIER
/// Date : 10/11/2019 15:23
///-----------------------------------------------------------------

using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;

namespace Com.IsartDigital.Four.Common.UI.Object {
    public delegate void ScreenObjectEventHandler(ScreenObject sender);

    [RequireComponent(typeof(CanvasGroup), typeof(Canvas))]
	public class ScreenObject : MonoBehaviour {

        private CanvasGroup canvasGroup;
        private Canvas canvas;
        protected ScreenDisplayer screenDisplayer;

        protected bool isAppear;
        public bool IsAppear => isAppear;

        public bool Interectable
        {
            set => canvasGroup.blocksRaycasts = value;
        }

        #region Events

        protected event Action OnAppearedLoop;
        public event ScreenObjectEventHandler OnAppearEnd;
        public event ScreenObjectEventHandler OnDisappearEnd;

        [Space]
        [SerializeField] private UnityEvent onAppear = default;
        [SerializeField] private UnityEvent onAppearEnd = default;
        [SerializeField] private UnityEvent onDisappear = default;
        [SerializeField] private UnityEvent onDisappearEnd = default;

        public event UnityAction OnApppear
        {
            add { onAppear.AddListener(value); }
            remove { onAppear.RemoveListener(value); }
        }

        public event UnityAction OnDisappear
        {
            add { onDisappear.AddListener(value); }
            remove { onDisappear.RemoveListener(value); }
        }

        #endregion

        #region Init

        public virtual void Init()
        {
            canvasGroup = GetComponent<CanvasGroup>();
            canvas = GetComponent<Canvas>();

            canvasGroup.blocksRaycasts = false;
            canvasGroup.interactable = false;
            canvas.enabled = false;

            StretchToRootcanvas();
        }

        public void Init(ScreenDisplayer screenDisplayer)
        {
            Init();
            this.screenDisplayer = screenDisplayer;
        }

        public void StretchToRootcanvas()
        {
            RectTransform rectTransform = (RectTransform)transform;
            
            rectTransform.offsetMin = Vector2.zero;
            rectTransform.offsetMax = Vector2.zero;

            rectTransform.anchorMin = Vector2.zero;
            rectTransform.anchorMax = Vector2.one;
        }

        #endregion

        #region Appear

        public virtual void Appear()
        {
            isAppear = true;
            canvas.enabled = true;
            canvasGroup.interactable = true;
            onAppear?.Invoke();
        }

        public virtual void ForceAppear()
        {
            Appear();
            EndAppear();
        }

        public virtual void EndAppear()
        {
            canvasGroup.blocksRaycasts = true;
            OnAppearEnd?.Invoke(this);
            onAppearEnd?.Invoke();

            if (OnAppearedLoop == null) return;

            appearedCoroutine = StartCoroutine(AppearedRoutine());
        }

        #endregion

        #region Disappear

        public virtual void Disappear()
        {
            isAppear = false;
            canvasGroup.blocksRaycasts = false;
            onDisappear?.Invoke();
        }

        public virtual void ForceDisappear()
        {
            Disappear();
            EndDisappear();
        }

        public virtual void EndDisappear()
        {
            canvasGroup.interactable = false;
            canvas.enabled = false;
            OnDisappearEnd?.Invoke(this);
            onDisappearEnd?.Invoke();

            if (appearedCoroutine == null) return;

            StopCoroutine(appearedCoroutine);
            appearedCoroutine = null;
        }

        #endregion

        #region Loop

        private Coroutine appearedCoroutine;

        private IEnumerator AppearedRoutine()
        {
            while (true)
            {
                OnAppearedLoop();
                yield return null;
            }
        }

        #endregion
    }
}