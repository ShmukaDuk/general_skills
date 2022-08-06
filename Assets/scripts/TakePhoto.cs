using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using CI.HttpClient;

using UnityEngine.UI;


public class TakePhoto : MonoBehaviour
{
	public Text LeftText;
	public Text RightText;
	public Slider ProgressSlider;
    private object httpResponse;







    /*void Update()
	{
		if (Input.GetMouseButtonDown(0))
		{
			// Don't attempt to use the camera if it is already open
			if (NativeCamera.IsCameraBusy())
				return;

			if (Input.mousePosition.y > 1)
			{
				// Take a picture with the camera
				// If the captured image's width and/or height is greater than 512px, down-scale it
				//TakePicture(2048);
				Upload();
			}
			else
			{
				// Record a video with the camera
				RecordVideo();
				return;
			}
		}
	}*/
    void button_TakePhoto()
    {
		if (NativeCamera.IsCameraBusy())
			return;
		TakePicture(512);
	}
	public void TakePicture(int maxSize)
	{
		
		NativeCamera.Permission permission = NativeCamera.TakePicture((path) =>
		{

			Upload(path);
			//Debug.Log("Image path: " + path);

			/*if (path != null)
			{
				Debug.Log("Here");
				Debug.Log("Here");
				Debug.Log("Here");
				Debug.Log("Here");
				// Create a Texture2D from the captured image
				Texture2D texture = NativeCamera.LoadImageAtPath(path, maxSize);
				if (texture == null)
				{
					Debug.Log("Couldn't load texture from " + path);
					return;
				}

				// Assign texture to a temporary quad and destroy it after 5 seconds
				GameObject quad = GameObject.CreatePrimitive(PrimitiveType.Quad);
				quad.transform.position = Camera.main.transform.position + Camera.main.transform.forward * 2.5f;
				quad.transform.forward = Camera.main.transform.forward;
				quad.transform.localScale = new Vector3(1f, texture.height / (float)texture.width, 1f);


				Material material = quad.GetComponent<Renderer>().material;
				if (!material.shader.isSupported) // happens when Standard shader is not included in the build
					material.shader = Shader.Find("Legacy Shaders/Diffuse");

				material.mainTexture = texture;
				File.Create(path).Dispose();
				
				//Destroy(quad, 5f);
				Debug.Log("this is the photo path:" + path);
				Handheld.PlayFullScreenMovie("file://" + path);
				// If a procedural texture is not destroyed manually, 
				// it will only be freed after a scene change
				Destroy(texture, 5f);

			}*/
		}, maxSize);

		Debug.Log("Permission result: " + permission);
	}

	private void RecordVideo()
	{
		NativeCamera.Permission permission = NativeCamera.RecordVideo((path) =>
		{
			Debug.Log("Video path: " + path);
			if (path != null)
			{
				Debug.Log("this is the video path:" + path);

				// Play the recorded video
				Handheld.PlayFullScreenMovie("file://" + path);
			}
		});

		Debug.Log("Permission result: " + permission);
	}

	

	public void Upload(string path)
	{		
		HttpClient client = new HttpClient();

		byte[] buffer = new byte[1000];
		new System.Random().NextBytes(buffer);


		string localPath = "/storage/emulated/0/DCIM/Screenshots/Screenshot_20210901-170746_Plex.jpg";
		FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
		

		StreamContent streamContent = new StreamContent(fs, "text/plain");
		MultipartFormDataContent content = new MultipartFormDataContent();
		content.Add(streamContent, "file", path);

		string fileType = "txt";
		Debug.Log("selected path:" + path);
		Debug.Log("default path:" + localPath);

		client.Post(new System.Uri("http://192.168.1.103:8080/main/user/upload/" + fileType), content, HttpCompletionOption.AllResponseContent, (r) =>
		{

		}, (u) =>
		{
			//LeftText.text = "Upload: " + u.PercentageComplete.ToString() + "%";
			//ProgressSlider.value = u.PercentageComplete;
		});
		Debug.Log("Upload passed");
	}	
}
