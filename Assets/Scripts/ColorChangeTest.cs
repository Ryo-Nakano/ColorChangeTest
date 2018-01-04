using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChangeTest : MonoBehaviour {

	Renderer[] renderers;//Rendererを格納しておく為の変数
	float colorChangeTimer;
	float timer;

	// Use this for initialization
	void Start () {
		renderers = gameObject.GetComponentsInChildren<Renderer>();//子要素のRenderer全てをGetCompomnent→renderers格納
	}
	
	// Update is called once per frame
	void Update () {
		colorChangeTimer += Time.deltaTime;
		timer += Time.deltaTime;

		if(timer > 1.0f)
		{
			if(colorChangeTimer > 1.0f && colorChangeTimer < 2.0f)
			{
				ChangeColorByName (Color.red);
				Debug.Log ("Change Red");
			}
			else if(colorChangeTimer > 2.0f && colorChangeTimer < 3.0f)
			{
				ChangeRGBA ();
				Debug.Log ("Change Blue");
			}
			else if(colorChangeTimer > 3.0f)
			{
				ChangeRandomColor ();
				Debug.Log ("Change Random Color");
				colorChangeTimer = 0;//timerの初期化
			}
			timer = 0;//timer初期化
		}







//		Debug.Log(renderer.material.color);//現在のColorをコンソールに表示

	}

	//===Colorを変える関数(Unity上のカラーネームで指定)===
	void ChangeColorByName(Color colorName)
	{
		foreach(Renderer r in renderers)//renderersの中の全要素に対して処理
		{
			r.material.color = colorName;//RedにColor変更
		}


	}

	//===Colorを変える関数(RGBA値で指定)===
	void ChangeRGBA()
	{
		foreach(Renderer r in renderers)//renderersの中の全要素に対して処理
		{
			r.material.color = new Color(0, 0, 255f, 1f);//RGBAで色指定(ここではblueを指定)
			//第4引数は"透過度"を指定(0に近ければ近いほど透過する)
		}
	}

	//===Colorをランダムに変更(RGBA指定)
	void ChangeRandomColor()
	{
		Color randomColor = new Color (Random.value, Random.value, Random.value, 1.0f);//ランダムな色取得

		foreach(Renderer r in renderers)//renderersの中の全要素に対して処理
		{
			r.material.color = randomColor;
		}
	}
}
