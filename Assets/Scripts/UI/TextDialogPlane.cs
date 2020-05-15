using System;
using UnityEngine;


public class TextDialogPlane 
{
    public string KEY_TEST_PLANE = "EZGUI/TextPlane";

    public GameObject _JuQPlane;

 //   public SpriteText _text;

 //   private void Awake()
	//{
	//	base.RegisterGUI();
	//}

	//public override bool Init()
	//{
	//	GameObject original = (GameObject)ResourceLoader.Load(this.KEY_TEST_PLANE, typeof(GameObject));
	//	this._JuQPlane = (UnityEngine.Object.Instantiate(original, Vector3.zero, Quaternion.identity) as GameObject);
	//	this._text = this._JuQPlane.transform.FindChild("Text").GetComponent<SpriteText>();
	//	this._text.Text = string.Empty;
	//	this._text.maxWidth = 20f;
	//	this._text.Color = Color.white;
	//	base.SetParentEx(this._JuQPlane);
	//	this._JuQPlane.name = "Textplane";
	//	this.AdjustPosition();
	//	this._JuQPlane.SetActiveRecursively(false);
	//	return true;
	//}

	//public void AdjustPosition()
	//{
	//	this._JuQPlane.transform.position = base.Position(GUI_LAYER.UILAYER_LOADING, GUI_POS.UIPOS_MIDDLE, 0f, 0f);
	//	this._JuQPlane.transform.position = new Vector3(this._JuQPlane.transform.position.x, this._JuQPlane.transform.position.y - 7.5f, this._JuQPlane.transform.position.z + 1.8f);
	//}

	//public void ShowTextDialog(string s)
	//{
	//	this._text.Text = s;
	//	this.Show();
	//}

	//public override void Hide()
	//{
	//	if (this._JuQPlane.active)
	//	{
	//		this._JuQPlane.SetActiveRecursively(false);
	//	}
	//}

	//public override void Show()
	//{
	//	if (!this._JuQPlane.active)
	//	{
	//		this._JuQPlane.SetActiveRecursively(true);
	//	}
	//}
}
