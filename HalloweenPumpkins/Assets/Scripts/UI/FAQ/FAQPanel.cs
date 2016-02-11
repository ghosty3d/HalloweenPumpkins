using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

[ExecuteInEditMode]
public class FAQPanel : MonoBehaviour
{
	public List<FAQRule> RulesList = new List<FAQRule> ();

	public RectTransform m_Transform;
	public int currentFAQRuleIndex = 0;

	public int rulesCount = 0;
	public float ruleOffset = 0f;
}
