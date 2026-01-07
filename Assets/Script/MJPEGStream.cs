using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

public class MJPEGStream : MonoBehaviour
{
    public string streamURL;
    public Renderer targetRenderer;

    void Start()
    {
        Debug.Log("SCRIPT STARTED");
        StartCoroutine(Stream());
    }

    IEnumerator Stream()
    {
        while (true)
        {
            UnityWebRequest req =
                UnityWebRequestTexture.GetTexture(streamURL);

            yield return req.SendWebRequest();

            if (req.result == UnityWebRequest.Result.Success)
            {
                Texture tex =
                    DownloadHandlerTexture.GetContent(req);

                targetRenderer.material.mainTexture = tex;
                Debug.Log("FRAME RECEIVED");
            }
            else
            {
                Debug.Log("ERROR");
            }
        }
    }
}
