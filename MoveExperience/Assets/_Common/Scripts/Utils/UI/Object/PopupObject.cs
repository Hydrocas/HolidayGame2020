///-----------------------------------------------------------------
/// Author : Hugo TEYSSIER
/// Date : 21/01/2020 13:55
///-----------------------------------------------------------------

using UnityEngine;
using UnityEngine.UI;

namespace Com.IsartDigital.Four.Common.UI.Object {
    public class PopupObject : ScreenObject
    {
		[SerializeField] private Button closeButton = null;

		public override void Init()
		{
			base.Init();
			closeButton.onClick.AddListener(Close);
		}

		private void Close()
		{
			screenDisplayer.Remove(this);
		}
	}
}
