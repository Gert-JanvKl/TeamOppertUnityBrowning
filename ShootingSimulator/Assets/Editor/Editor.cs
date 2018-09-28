using UnityEditor;
using UnityEngine;
using UnityEditor.Build.Reporting;
// Output the build size or a failure depending on BuildPlayer.
public class BuildPlayerExample : MonoBehaviour
{
    [MenuItem("Build/Build iOS")]
    public static void MyBuild()
    {
        BuildPlayerOptions buildPlayerOptions = new BuildPlayerOptions();
        buildPlayerOptions.scenes = new[] { "Assets/SampleScene.unity"};
        buildPlayerOptions.locationPathName = "/Build";
        buildPlayerOptions.target = BuildTarget.StandaloneWindows64;
        buildPlayerOptions.options = BuildOptions.None;
        BuildReport report = BuildPipeline.BuildPlayer(buildPlayerOptions);
        BuildSummary summary = report.summary;
        if (summary.result == BuildResult.Succeeded)
        {
            Debug.Log("Build succeeded: " + summary.totalSize + " bytes");
        }
        if (summary.result == BuildResult.Failed)
        {
            Debug.Log("Build failed");
        }
    }
}