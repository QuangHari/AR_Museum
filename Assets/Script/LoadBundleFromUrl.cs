// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
// using UnityEngine.Networking;
// using System;
 
// public class BundleWebLoader : MonoBehaviour
// {
//     public string bundleUrl = "https://firebasestorage.googleapis.com/v0/b/portal-fad1c.appspot.com/o/models%2FDieu%20Trung%20Quoc_1683169569482_dieu_trung_quoc.zip?alt=media&token=afeed382-0149-46eb-b388-220a91bb3187";
//     public string assetName = "DieuTQ";
     
//     // Start is called before the first frame update
//     IEnumerator Start()
//     {
//         using (WWW web = new WWW(bundleUrl))
//         {
//             yield return web;
//             AssetBundle remoteAssetBundle = web.assetBundle;
//             if (remoteAssetBundle == null) {
//                 Debug.LogError("Failed to download AssetBundle!");
//                 yield break;
//             }
//             Instantiate(remoteAssetBundle.LoadAsset(assetName));
//             remoteAssetBundle.Unload(false);
//         }
//     }
 
 
// }