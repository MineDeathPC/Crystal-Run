@echo off
"C:\\Program Files\\Unity\\Hub\\Editor\\2023.1.0b11\\Editor\\Data\\PlaybackEngines\\AndroidPlayer\\SDK\\cmake\\3.22.1\\bin\\cmake.exe" ^
  "-HC:\\Users\\User\\Desktop\\Disasters\\Library\\Bee\\Android\\Prj\\Mono2x\\Gradle\\unityLibrary\\src\\main\\cpp" ^
  "-DCMAKE_SYSTEM_NAME=Android" ^
  "-DCMAKE_EXPORT_COMPILE_COMMANDS=ON" ^
  "-DCMAKE_SYSTEM_VERSION=22" ^
  "-DANDROID_PLATFORM=android-22" ^
  "-DANDROID_ABI=armeabi-v7a" ^
  "-DCMAKE_ANDROID_ARCH_ABI=armeabi-v7a" ^
  "-DANDROID_NDK=C:\\Program Files\\Unity\\Hub\\Editor\\2023.1.0b11\\Editor\\Data\\PlaybackEngines\\AndroidPlayer\\NDK" ^
  "-DCMAKE_ANDROID_NDK=C:\\Program Files\\Unity\\Hub\\Editor\\2023.1.0b11\\Editor\\Data\\PlaybackEngines\\AndroidPlayer\\NDK" ^
  "-DCMAKE_TOOLCHAIN_FILE=C:\\Program Files\\Unity\\Hub\\Editor\\2023.1.0b11\\Editor\\Data\\PlaybackEngines\\AndroidPlayer\\NDK\\build\\cmake\\android.toolchain.cmake" ^
  "-DCMAKE_MAKE_PROGRAM=C:\\Program Files\\Unity\\Hub\\Editor\\2023.1.0b11\\Editor\\Data\\PlaybackEngines\\AndroidPlayer\\SDK\\cmake\\3.22.1\\bin\\ninja.exe" ^
  "-DCMAKE_LIBRARY_OUTPUT_DIRECTORY=C:\\Users\\User\\Desktop\\Disasters\\Library\\Bee\\Android\\Prj\\Mono2x\\Gradle\\unityLibrary\\build\\intermediates\\cxx\\RelWithDebInfo\\171j3j5m\\obj\\armeabi-v7a" ^
  "-DCMAKE_RUNTIME_OUTPUT_DIRECTORY=C:\\Users\\User\\Desktop\\Disasters\\Library\\Bee\\Android\\Prj\\Mono2x\\Gradle\\unityLibrary\\build\\intermediates\\cxx\\RelWithDebInfo\\171j3j5m\\obj\\armeabi-v7a" ^
  "-DCMAKE_BUILD_TYPE=RelWithDebInfo" ^
  "-DCMAKE_FIND_ROOT_PATH=C:\\Users\\User\\Desktop\\Disasters\\.utmp\\RelWithDebInfo\\171j3j5m\\prefab\\armeabi-v7a\\prefab" ^
  "-BC:\\Users\\User\\Desktop\\Disasters\\.utmp\\RelWithDebInfo\\171j3j5m\\armeabi-v7a" ^
  -GNinja ^
  "-DBUILD_GRADLE_DIRECTORY=C:\\Users\\User\\Desktop\\Disasters\\Library\\Bee\\Android\\Prj\\Mono2x\\Gradle\\unityLibrary" ^
  "-DANDROID_STL=c++_shared"
