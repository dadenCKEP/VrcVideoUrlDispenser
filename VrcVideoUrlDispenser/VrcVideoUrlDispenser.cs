// ----------------------------------------------------------------------------------------------------
// This code written by Hakka Sanko(TwitterId : hakkafox).
// I abandon this code copyright. You can freely modify it. Let's enjoy VrChat ;)
// I made this code for myself and my dear friend Tonodai.
// So, this code update may be fickle. Sry!
// ----------------------------------------------------------------------------------------------------

using UnityEngine;
using VRCSDK2;

/// <summary>
/// VRC_SyncVideoPlayerのPlaylistにUrlリストを一括で入れるクラス
/// 
/// ※注意！：TextAreaにUrlを貼り付ける時、キー認識が鈍いみたいなので、しっかり押して下さい。
/// </summary>
public class VrcVideoUrlDispenser : MonoBehaviour
{
	public VRC_SyncVideoPlayer GetSyncVideoPlayer()
	{
		return gameObject.GetComponent<VRC_SyncVideoPlayer>();
	}
}
