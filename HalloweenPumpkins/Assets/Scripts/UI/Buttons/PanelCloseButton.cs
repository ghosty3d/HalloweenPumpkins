using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PanelCloseButton : MonoBehaviour {

	[SerializeField]
	private Button m_Button;
	[SerializeField]
	private StateUI m_StateUIPanel;

	void Awake() {

		m_Button = GetComponent<Button> ();
		m_StateUIPanel = transform.GetComponentInParent<StateUI> ();

		if (m_Button != null) {
			m_Button.onClick.AddListener (OnButtonClick);
		}
	}

	private void OnButtonClick() {
		if (m_StateUIPanel != null) {
			m_StateUIPanel.SetActive (false);
		}
	}
}
