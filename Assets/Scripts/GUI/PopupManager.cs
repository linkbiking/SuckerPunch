using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PopupManager : MonoBehaviour
{
	private static PopupManager _instance = null;


	public static PopupManager instance
	{
		get
		{
			if (_instance == null)
			{
				_instance = GameObject.Find("PopupManager").GetComponent<PopupManager>();


			}	

			return _instance;
		}
	}

	// Use this for initialization
	void Awake()
	{
		foreach (Transform child in transform)
		{
			Destroy(child.gameObject);
		}
	}
	void Start () {

	}

	// Update is called once per frame
	void Update () {

	}

	public void Add(GameObject obj, Vector3 position = default(Vector3), bool setLayer = true)
	{
		// find new z
		float min_z = 0;
		int maxDepth = 10;
		//UIPanel minZPanel = null;

		/*UIPanel[] childsTrans = GetComponentsInChildren<UIPanel>(true);

        List<UIPanel> children = new List<UIPanel>();

        foreach (UIPanel p in childsTrans)
        {
            if (p.transform.parent == this.transform)
                children.Add(p);
        }*/

		// get max depth
		//if (minZPanel != null)
		{
			UIPanel[] childsPanel = GetComponentsInChildren<UIPanel>(true);
			foreach (UIPanel child in childsPanel)
			{
				if (child.gameObject.GetComponent<TutorialPopup>() != null) continue;
				if (child.depth > maxDepth)
				{
					maxDepth = child.depth;
				}
			}
		}

		obj.transform.parent = this.gameObject.transform;
		obj.transform.localPosition = new Vector3(position.x, position.y, min_z);

		//if (obj.GetComponent<TutorialPopup>() == null)
		//{
		//    // set depth for new obj
		//    int newDept = maxDepth + 1;
		//    UIPanel childsPanelObj = obj.GetComponent<UIPanel>();
		//    childsPanelObj.depth = newDept;
		//}

		//GlowCamPopupOn();

		//add new popup to list.
		//_listCurrentPopup.Add(obj.GetComponent<PopupBase>());
	}
}
