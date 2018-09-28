class Editor {
        static string[] SCENES = FindEnabledEditorScenes();
 
        static string APP_NAME = "YourProject";
        static string TARGET_DIR = "target";
 
        [MenuItem ("Custom/CI/Build Windows 64-bit")]
	static void PerformWinBuild (){
		SetupNameAndDir();
		string target_dir = APP_NAME + ".exe";
		GenericBuild(SCENES, TARGET_DIR + "/win/" + target_dir, BuildTarget.StandaloneWindows64,BuildOptions.None);
	}

 
    private static string[] FindEnabledEditorScenes() {
        List<string> EditorScenes = new List<string>();
        foreach(EditorBuildSettingsScene scene in EditorBuildSettings.scenes) {
            if (!scene.enabled) continue;
            EditorScenes.Add(scene.path);
        }
        return EditorScenes.ToArray();
    }
 
        static void GenericBuild(string[] scenes, string target_dir, BuildTarget build_target, BuildOptions build_options)
        {
                EditorUserBuildSettings.SwitchActiveBuildTarget(build_target);
                string res = BuildPipeline.BuildPlayer(scenes,target_dir,build_target,build_options);
                if (res.Length > 0) {
                        throw new Exception("BuildPlayer failure: " + res);
                }
        }
}