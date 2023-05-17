using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.Networking;

public class ZipDownloader : MonoBehaviour
{
    public string url;
    public string path;
    // Start is called before the first frame updates
    void Start()
    {
        StartCoroutine(DownloadZipFile("https://firebasestorage.googleapis.com/v0/b/portal-fad1c.appspot.com/o/models%2FDieu%20Trung%20Quoc_1683169569482_dieu_trung_quoc.zip?alt=media&token=afeed382-0149-46eb-b388-220a91bb3187", "Downloads/myzipfile.zip"));
    }

    IEnumerator DownloadZipFile(string url, string savePath){
        UnityWebRequest www = UnityWebRequest.Get(url);
        yield return www.SendWebRequest();

        if (www.result == UnityWebRequest.Result.Success){
            byte[] data = www.downloadHandler.data;
            File.WriteAllBytes(savePath, data);
            Debug.Log("Downloaded " + savePath);
            string filePath = "Downloads/myzipfile1";
            if (Directory.Exists(filePath)) {
                string[] files = Directory.GetFiles(filePath); 
                foreach (string file in files)
                {
                    File.Delete(file); 
                }
                Debug.Log("Đã xóa toàn bộ file trong thư mục ");
            } else {
                Debug.Log("file " +  " doesnt exist");
          
            }
            
            System.IO.Compression.ZipFile.ExtractToDirectory("Downloads/myzipfile.zip","Downloads/myzipfile1");
            //Debug.Log("Unpacked " + savePath);
            
        }
        else {
            Debug.Log("Download failed: " + www.error);
        }
    }


}

   

