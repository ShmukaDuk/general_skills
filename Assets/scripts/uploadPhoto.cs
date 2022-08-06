using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using CI.HttpClient;
using UnityEngine.SceneManagement;

public class uploadPhoto : MonoBehaviour
{
	public string username;
	public string category;
	public string subCategory;

	public bool cat_1;
	public bool cat_2;
	public bool cat_3;
	public bool cat_4;

	public bool subCat_1;
	public bool subCat_2;
	public bool subCat_3;
	public bool subCat_4;

	public UpdateUserdata updateUserData;
	 

	public void UploadFromGallery()
    {
		PickImage(512);
    }
	public void UploadFromCamera()
    {
		TakePicture(512);
    }
	public void TakePicture(int maxSize)
	{
		NativeCamera.Permission permission = NativeCamera.TakePicture((path) =>
		{
			Upload(path);			
		}, maxSize);
		
	}



	// Start is called before the first frame update
	private void PickImage(int maxSize)
	{
		NativeGallery.Permission permission = NativeGallery.GetImageFromGallery((path) =>
		{			
			Upload(path);			
		});
				
	}


	//takePhoto.Upload(path);
	public void Upload(string path)
	{
		username = GlobalVariables.Username;
		int cat = 0;
		int subCat = 0;
		if (cat_1)
		{
			category = "cat_1";
			cat = 1;
		}
		if (cat_2)
		{
			category = "cat_2";
			cat = 2;
		}

		if (cat_3)
		{
			category = "cat_3";
			cat = 3;
		}
		if (cat_4)
		{
			category = "cat_4";
			cat = 4;
		}

		if (subCat_1) {subCategory = "subCat_1"; subCat = 1; }
		if (subCat_2) {subCategory = "subCat_2"; subCat = 2; }
		if (subCat_3) {subCategory = "subCat_3"; subCat = 3; }
		if (subCat_4) {subCategory = "subCat_4"; subCat = 4; }

		cat_1 = false;
		cat_2 = false;
		cat_3 = false;
		cat_4 = false;

		subCat_1 = false;
		subCat_2 = false;
		subCat_3 = false;
		subCat_4 = false;

		updateUserData.updateData2(cat, subCat);


		HttpClient client = new HttpClient();

		byte[] buffer = new byte[1000];
		new System.Random().NextBytes(buffer);		
		FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);


		StreamContent streamContent = new StreamContent(fs, "text/plain");
		MultipartFormDataContent content = new MultipartFormDataContent();
		content.Add(streamContent, "file", path);

	
		string url = GlobalVariables.serverAddress +"user/upload/" + username + "/" + category + "/" + subCategory;
		Debug.Log("Sending file: " + path + "to: " +url);
		client.Post(new System.Uri(GlobalVariables.serverAddress + "user/upload/" + username + "/" + category + "/" + subCategory), content, HttpCompletionOption.AllResponseContent, (r) =>
		{

		}, (u) =>
		{
			
		});
		
	}	

	public void setBool_cat_1()
    {
		cat_1 = true;
    }
	public void setBool_cat_2()
	{
		cat_2 = true;
	}
	public void setBool_cat_3()
	{
		cat_3 = true;
	}
	public void setBool_cat_4()
	{
		cat_4 = true;
	}

	public void setBool_subCat_1() { subCat_1 = true; }
	public void setBool_subCat_2() { subCat_2 = true; }
	public void setBool_subCat_3() { subCat_3 = true; }
	public void setBool_subCat_4() { subCat_4 = true; }
}
