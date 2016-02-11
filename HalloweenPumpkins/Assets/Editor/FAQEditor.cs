using UnityEngine;
using UnityEditor;
using System.Collections;

[CustomEditor(typeof(FAQPanel))]
public class FAQEditor : Editor
{
	public override void OnInspectorGUI ()
	{
		FAQPanel faq = (FAQPanel)target;

		DrawDefaultInspector ();

		faq.rulesCount = faq.m_Transform.childCount;
		faq.ruleOffset = faq.m_Transform.rect.width / faq.rulesCount;

		GUILayout.BeginHorizontal ();

		if(GUILayout.Button("Prev", GUILayout.Height(32)) && faq.currentFAQRuleIndex > 0)
		{
			faq.currentFAQRuleIndex--;
			faq.m_Transform.anchoredPosition3D = new Vector3(faq.m_Transform.anchoredPosition3D.x + faq.ruleOffset, 0f, 0f);
		}

		if(GUILayout.Button("Next", GUILayout.Height(32)) && faq.currentFAQRuleIndex < faq.rulesCount - 1)
		{
			faq.currentFAQRuleIndex++;
			faq.m_Transform.anchoredPosition3D = new Vector3(faq.m_Transform.anchoredPosition3D.x - faq.ruleOffset, 0f, 0f);
		}

		GUILayout.EndHorizontal ();
	}
}
