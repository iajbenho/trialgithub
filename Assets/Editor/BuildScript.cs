using System;
using System.Linq;
using UnityEditor;
using System.IO;

public class BuildScript {

	private static readonly string _versionNumber;
	private static readonly string _buildNumber;


	public static string[] GetScenes()
	{
		return EditorBuildSettings.scenes.Where(s => s.enabled).Select(s => s.path).ToArray();
	}

	public static void Win()
	{
		try{
			PlayerSettings.showUnitySplashScreen = false;	
		}catch(Exception e) {
			UnityEngine.Debug.Log (e);
		}
		Directory.CreateDirectory (UnityEngine.Application.dataPath+"/../Bin/Windows/"+"v "+PlayerSettings.bundleVersion);	
		BuildPipeline.BuildPlayer(GetScenes(), UnityEngine.Application.dataPath+"/../Bin/Windows/"+"v " + PlayerSettings.bundleVersion +"/"+PlayerSettings.productName + " v" +PlayerSettings.bundleVersion+".exe", BuildTarget.StandaloneWindows, BuildOptions.None);
	}

	public static void Android()
	{
		try{
			PlayerSettings.Android.splashScreenScale = AndroidSplashScreenScale.ScaleToFill;
		}catch(Exception e){
		
		}
		Directory.CreateDirectory (UnityEngine.Application.dataPath+"/../Bin/Android");	
		BuildPipeline.BuildPlayer(GetScenes(), UnityEngine.Application.dataPath+"/../Bin/Android/" + PlayerSettings.productName + " v" + PlayerSettings.bundleVersion +".apk", BuildTarget.Android, BuildOptions.None);
	}

}