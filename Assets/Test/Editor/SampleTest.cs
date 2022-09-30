using System.Threading;
using NUnit.Framework;
using Altom.AltUnityDriver;
using Altom.AltUnityTesterEditor;
using UnityEditor;
using UnityEditor.Build;
using UnityEngine;

public class SampleTest
{
    public static AltUnityDriver altUnityDriver = new AltUnityDriver();

    //Before any test it connects with the socket
    [OneTimeSetUp]
    public void SetUp()
    {
        // altUnityDriver =new AltUnityDriver();
    }

    //At the end of the test closes the connection with the socket
    [OneTimeTearDown]
    public void TearDown()
    {
        altUnityDriver.Stop();
    }

    public static void RunAllTest() {
      AltUnityTestRunner.RunTests(AltUnityTestRunner.TestRunMode.RunAllTest);
    }

    [Test]
    public static void Test() {
      // PlayerSettings.SetScriptingDefineSymbols(NamedBuildTarget.Android, "ALTUNITYTESTER");

      var walkButton = altUnityDriver.FindObject(By.NAME, "WalkButton");
      var stopWalkButton = altUnityDriver.FindObject(By.NAME, "StopWalkButton");
      walkButton.Click();
      Thread.Sleep(5000);
      stopWalkButton.Click();
    }

}