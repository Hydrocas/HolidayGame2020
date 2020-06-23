///-----------------------------------------------------------------
/// Author : Hugo TEYSSIER
/// Date : 11/11/2019 10:59
/// Note : Cette class a été créé tôt mais à été majoritairement implémenté durant ce projet
///-----------------------------------------------------------------


using Com.IsartDigital.Four.Common.UI.Object;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Com.IsartDigital.Four.Common.UI {

    /// <summary>
    /// ScreenDisplayer est une class qui a pour but de simplifier l'affichage d'ui et d'uniformiser le system d'affichage pour tous les projets.
    /// Cette class dépend de ScreenObject qui est la plus haute class mère dont héritent tous les écrans.
    /// </summary>
	public class ScreenDisplayer {

        private List<ScreenObject> displayedScreens;

        private ScreenObject nextScreenToAppear;
        private Action callback;
        private ScreenObject transitionScreen;
        private int counter = 0;

        public ScreenObject[] DisplayedScreens => displayedScreens.ToArray();

        #region Init

        public ScreenDisplayer(Canvas[] canvas)
        {
            for (int i = canvas.Length - 1; i >= 0; i--)
            {
                SetCanvas(canvas[i]);
            }

            displayedScreens = new List<ScreenObject>();
        }

        public ScreenDisplayer(Canvas canvas)
        {
            SetCanvas(canvas);
            displayedScreens = new List<ScreenObject>();
        }

        public void SetCanvas(Canvas canvas)
        {
            ScreenObject[] screensObjects = canvas.GetComponentsInChildren<ScreenObject>(true);
            ScreenObject screenObject;

            for (int i = screensObjects.Length - 1; i >= 0; i--)
            {
                screenObject = screensObjects[i];
                screenObject.gameObject.SetActive(true);
                screenObject.Init(this);
                screenObject.OnDisappearEnd += SortScreens;
            }
        }

        #endregion

        #region Display

        /// <summary>
        /// Affiche l'écran avec son animation
        /// </summary>
        /// <param name="screenObject"></param>
        public void Display(ScreenObject screenObject)
        {
            if (displayedScreens.Contains(screenObject)) return;

            displayedScreens.Add(screenObject);
            screenObject.Appear();
            SortScreens();
        }

        public void Display(ScreenObject screenObject, int index)
        {
            if (displayedScreens.Contains(screenObject)) return;

            displayedScreens.Insert(index, screenObject);
            screenObject.Appear();
            SortScreens();
        }

        /// <summary>
        /// Affiche l'écran sen prendre en compte son animation
        /// </summary>
        /// <param name="screenObject"></param>
        public void ForceDisplay(ScreenObject screenObject)
        {
            if (displayedScreens.Contains(screenObject) || screenObject.IsAppear) return;

            displayedScreens.Add(screenObject);
            screenObject.ForceAppear();
            SortScreens();
        }

        public void ForceDisplay(ScreenObject screenObject, int index)
        {
            if (displayedScreens.Contains(screenObject) || screenObject.IsAppear) return;

            displayedScreens.Insert(index, screenObject);
            screenObject.ForceAppear();
            SortScreens();
        }

        #endregion

        #region Remove

        /// <summary>
        /// Enlève l'écran avec son animation
        /// </summary>
        /// <param name="screenObject"></param>
        public void Remove(ScreenObject screenObject)
        {
            if (!displayedScreens.Contains(screenObject) || !screenObject.IsAppear) return;

            screenObject.OnDisappearEnd += ScreenObject_OnDisappearEnd;
            screenObject.Disappear();
        }

        public void RemoveAll()
        {
            for (int i = displayedScreens.Count - 1; i >= 0; i--)
            {
                Remove(displayedScreens[i]);
            }
        }

        public void RemoveAt(int index)
        {
            Remove(displayedScreens[index]);
        }

        #region Force Remove

        /// <summary>
        /// Enlève l'écran sen prendre en compte son animation
        /// </summary>
        /// <param name="screenObject"></param>
        public void ForceRemove(ScreenObject screenObject)
        {
            if (!displayedScreens.Contains(screenObject) || !screenObject.IsAppear) return;

            displayedScreens.Remove(screenObject);
            screenObject.ForceDisappear();
        }

        public void ForceRemoveAll()
        {
            for (int i = displayedScreens.Count - 1; i >= 0; i--)
            {
                ForceRemove(displayedScreens[i]);
            }
        }

        public void ForceRemoveAt(int index)
        {
            ForceRemove(displayedScreens[index]);
        }

        #endregion

        #endregion

        #region Sort
        /// <summary>
        /// Superpose les écrans en fonction de leurs ordres dans la liste displayedScreens.
        /// </summary>
        private void SortScreens()
        {
            int length = displayedScreens.Count - 1;

            if (length < 0) return;

            int i;
            ScreenObject screenObject;

            for (i = 0; i < length; i++)
            {
                screenObject = displayedScreens[i];
                screenObject.transform.SetSiblingIndex(i);
            }

            screenObject = displayedScreens[i];
            screenObject.Interectable = true;
            screenObject.transform.SetSiblingIndex(i);
        }

        private void SortScreens(ScreenObject sender)
        {
            SortScreens();
        }

        #endregion

        #region Transition

        /// <summary>
        /// Simplifie la transition entre les scènes de jeu.
        /// </summary>
        /// <param name="transitionScreen"></param>
        /// <param name="callback"></param>
        public void DisplayTransition(ScreenObject transitionScreen, Action callback)
        {
            this.callback = callback;
            transitionScreen.OnAppearEnd += TransitionScreen_OnAppearEnd;
            transitionScreen.Appear();
        }

        private void TransitionScreen_OnAppearEnd(ScreenObject sender)
        {
            sender.OnAppearEnd -= TransitionScreen_OnAppearEnd;
            transitionScreen = sender;

            callback();
            callback = null;
        }

        public void RemoveTransition(Action callback = null)
        {
            if (transitionScreen == null) return;

            if(callback != null)
            {
                this.callback = callback;
                transitionScreen.OnDisappearEnd += TransitionScreen_OnDisappearEnd;
            }

            transitionScreen.Disappear();
        }

        private void TransitionScreen_OnDisappearEnd(ScreenObject sender)
        {
            sender.OnDisappearEnd -= TransitionScreen_OnDisappearEnd;
            transitionScreen = null;

            callback();
            callback = null;
        }

        #endregion

        #region Switch

        /// <summary>
        /// Remplace lastScreen par nextScreen
        /// l'apparition de l'écran se fait seulement quand tous les anciens écrans auront disparu.
        /// </summary>
        /// <param name="nextScreen"></param>
        public void Switch(ScreenObject nextScreen, ScreenObject lastScreen)
        {
            if (displayedScreens.Contains(nextScreen)) return;

            callback = DisplayNextScreen;
            nextScreenToAppear = nextScreen;

            Remove(lastScreen);
        }

        /// <summary>
        /// Remplace tous les écrans du jeu par nextScreen.
        /// l'apparition de l'écran se fait seulement quand tous les anciens écrans auront disparu.
        /// </summary>
        /// <param name="nextScreen"></param>
        public void Switch(ScreenObject nextScreen)
        {
            if (displayedScreens.Contains(nextScreen)) return;

            if(displayedScreens.Count == 0)
            {
                Display(nextScreen);
                return;
            }

            callback = DisplayNextScreen;
            nextScreenToAppear = nextScreen;
            ScreenObject lastScreen;

            for (int i = displayedScreens.Count - 1; i >= 0; i--)
            {
                lastScreen = displayedScreens[0];
                counter++;

                Remove(lastScreen);
            }
        }

        private void ScreenObject_OnDisappearEnd(ScreenObject screenObject)
        {
            screenObject.OnDisappearEnd -= ScreenObject_OnDisappearEnd;
            displayedScreens.Remove(screenObject);

            if (counter > 0)
            {
                counter--;

                if (counter != 0) return;
            }

            callback?.Invoke();
            callback = null;
        }

        private void DisplayNextScreen()
        {
            Display(nextScreenToAppear);
            nextScreenToAppear = null;
        }

        #endregion
    }
}