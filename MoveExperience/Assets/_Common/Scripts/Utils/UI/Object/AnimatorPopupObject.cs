///-----------------------------------------------------------------
/// Author : Hugo TEYSSIER
/// Date : 21/01/2020 13:55
///-----------------------------------------------------------------

using UnityEngine;
using UnityEngine.UI;

namespace Com.IsartDigital.Four.Common.UI.Object {
    public class AnimatorPopupObject : AnimatorScreenObject
    {
		[SerializeField] protected Button closeButton;

		public override void Init()
		{
			base.Init();
			closeButton.onClick.AddListener(Close);
		}

		protected virtual void Close()
		{
			Debug.Log("close");
			screenDisplayer.Remove(this);
		}
	}
}
