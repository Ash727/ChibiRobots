#!/bin/sh
echo "==> Uninstalling the app from the device..."
adb uninstall com.DefaultCompany.ChibiRoboGames
echo "==> Installing the app on the device..."
adb install ~/Desktop/Builds/ChibiGym.apk
echo "==> Setup ADB port forwarding..."
adb forward --remove-all
adb forward tcp:13000 tcp:13000
echo "==> Start the app..."
adb shell monkey -p com.DefaultCompany.ChibiRoboGames 1
sleep 15
echo "==> Run the smoke test..."
/Applications/Unity/Hub/Editor/2021.3.9f1/Unity.app/Contents/MacOS/Unity -batchmode -projectPath ~/code/ChibiRobots/ -executeMethod SampleTest.Test -logFile AltUnityTesterRunSmokeTest.log -quit
echo "==> ALL DONE!"

#  Walk.sh
#  
#
#  Created by Ashley Morley on 2022-09-30.
#  
