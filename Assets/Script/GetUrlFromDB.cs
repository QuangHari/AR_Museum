using UnityEngine;
using System.Net;
using Newtonsoft.Json.Linq;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine.Networking;
using CreateImageTarget;

public class GetUrlFromDB : MonoBehaviour
{
    void Start()
    {
        //StartCoroutine(DownloadData());
        string imagePath = "Assets/Resources/Model1/marker.jpg";
        Texture2D texture = new Texture2D(2, 2);
        byte[] imageData = System.IO.File.ReadAllBytes(imagePath);
        texture.LoadImage(imageData);
        GenerateImageTarget gen = new GenerateImageTarget(texture, "marker");
        gen.Start();
    }
    IEnumerator DownloadData()
    {
        WebClient client = new WebClient();
        string url = "https://portal-fad1c-default-rtdb.asia-southeast1.firebasedatabase.app/models.json?fbclid=IwAR3t2JjYxZK1kscXyYQ-Muq-nsF7V2FOvlrYnFku4dORJz1qTBdoAkI-YvY";
        string json = client.DownloadString(url);

        JObject jsonObj = JObject.Parse(json);
        
        int i = 0;
        foreach (JProperty prop in jsonObj.Properties())
        {
            i++;

            JObject item = (JObject)prop.Value;
            string description = (string)item.GetValue("description");
            string marker = (string)item.GetValue("marker");
            string model = (string)item.GetValue("model");
            string name = (string)item.GetValue("name");
            string savePath = "Assets/Resources/Model" + i.ToString();
            Debug.Log("bắt đầu tải");
            
            // Start the coroutine and wait for it to finish
            yield return StartCoroutine(DownloadZipFile(model, savePath));
            
            string markerPath = savePath + "/marker.jpg";
            yield return StartCoroutine(DownloadImg(marker, markerPath));
        }
    }

    IEnumerator DownloadZipFile(string url, string savePath)
    {
        UnityWebRequest www = UnityWebRequest.Get(url);
        yield return www.SendWebRequest();

        if (www.result == UnityWebRequest.Result.Success)
        {
            byte[] data = www.downloadHandler.data;
            string save = savePath + ".zip";
            File.WriteAllBytes(save, data);

            if (Directory.Exists(savePath))
            {
                string[] files = Directory.GetFiles(savePath);
                foreach (string file in files)
                {
                    File.Delete(file);
                }
                Caching.ClearCache();
                Debug.Log("Đã xóa toàn bộ file trong thư mục ");
            }
            else
            {
                Debug.Log("file " + " doesnt exist");
            }

            System.IO.Compression.ZipFile.ExtractToDirectory(save, savePath);
            if (File.Exists(save))
            {
                File.Delete(save);
                Debug.Log("Delete rac thanh cong");
            }
            Debug.Log("Unpacked " + savePath);
        }
        else
        {
            Debug.Log("Download failed: " + www.error);
        }
    }

    IEnumerator DownloadImg(string filePath, string savePath)
    {
        UnityWebRequest request = UnityWebRequest.Get(filePath);
        Debug.Log(filePath);
        yield return request.SendWebRequest();

        if (request.result != UnityWebRequest.Result.Success)
        {
            Debug.Log("Lỗi tải file: " + request.error);
        }
        else
        {
            byte[] fileData = request.downloadHandler.data;
            File.WriteAllBytes(savePath, fileData);

            if (File.Exists(savePath))
            {
                Debug.Log("Them marker thanh cong");
            }
            else
            {
                Debug.Log("Them marker ngu r");
            }
        }
    }
}
