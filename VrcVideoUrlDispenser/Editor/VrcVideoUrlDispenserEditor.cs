// ----------------------------------------------------------------------------------------------------
// This code written by Hakka Sanko(TwitterId : hakkafox).
// I abandon this code copyright. You can freely modify it. Let's enjoy VrChat ;)
// I made this code for myself and my dear friend Tonodai.
// So, this code update may be fickle. Sry!
// ----------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using VRCSDK2;

[CustomEditor(typeof(VrcVideoUrlDispenser))]
public class VrcVideoUrlDispenserEditor : Editor
{
	string urls = "";
	static readonly string SuccessLog = @"VrcVideoUrlDispenser : 処理成功！ IndexOutOfRangeExceptionエラーが出ても気にしないで下さい。
カスタムインスペクターからコンポーネントを消すと起きるようです。";

	public override void OnInspectorGUI()
	{
		base.OnInspectorGUI();

		GUILayout.Label("UrlList");
		urls = TextAreaExt.TextArea(urls, GUILayout.Height(200));

		if (!GUILayout.Button("Start"))
		{
			return;
		}

		var dispenser = target as VrcVideoUrlDispenser;
		if (dispenser == null)
		{
			return;
		}

		// 改行でパース
		var urlArray = urls.Split(new string[] { "\n" }, StringSplitOptions.None);

		var urlList = new List<string>();
		urlList.AddRange(urlArray);

		// 変なものを抜く
		urlList.RemoveAll(url =>
		{
			return url.Length <= 0;
		});

		if (urlList.Count <= 0)
		{
			return;
		}

		var videoPlayer = dispenser.GetSyncVideoPlayer();
		videoPlayer.Videos = new VRC_SyncVideoPlayer.VideoEntry[urlList.Count];

		for (int i = 0; i < urlList.Count; i++)
		{
			var url = urlList[i];

			// 登録
			var entry = new VRC_SyncVideoPlayer.VideoEntry();
			entry.URL = url;
			videoPlayer.Videos[i] = entry;
		}

		Debug.Log(SuccessLog);

		// 処理した後はいらないので削除
		DestroyImmediate(dispenser);
	}
}
