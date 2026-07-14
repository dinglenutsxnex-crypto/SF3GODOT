using System;
using UnityEngine;

public class ResourcesUtil
{
	public static T[] GetResources<T>(string path) where T : class
	{
		path = ConvertResourcesPath(path);
		return Resources.LoadAll<T>(path);
	}

	public static T GetResource<T>(string path) where T : class
	{
		path = ConvertResourcesPath(path);
		return Resources.Load<T>(path);
	}

	public static void UnloadAsset(object value, bool immediate = true)
	{
		if (value is GameObject)
		{
			GlobalLoad.Destroy(value, immediate);
		}
		else
		{
			Resources.UnloadAsset(value as UObject);
		}
	}

	public static void UnloadUnusedAssets()
	{
		Resources.UnloadUnusedAssets();
	}

	private static string ConvertResourcesPath(string path)
	{
		string text = "resources/";
		int num = path.LastIndexOf(text, StringComparison.OrdinalIgnoreCase);
		if (num > -1)
		{
			num += text.Length;
			int indexExtension = GlobalPath.GetIndexExtension(path, num);
			return path.Substring(num, indexExtension);
		}
		return path;
	}
}
