@echo off
"C:\\Program Files\\Unity\\Hub\\Editor\\2023.1.0b11\\Editor\\Data\\PlaybackEngines\\AndroidPlayer\\OpenJDK\\bin\\java" ^
  --class-path ^
  "C:\\Users\\User\\.gradle\\caches\\modules-2\\files-2.1\\com.google.prefab\\cli\\2.0.0\\f2702b5ca13df54e3ca92f29d6b403fb6285d8df\\cli-2.0.0-all.jar" ^
  com.google.prefab.cli.AppKt ^
  --build-system ^
  cmake ^
  --platform ^
  android ^
  --abi ^
  armeabi-v7a ^
  --os-version ^
  22 ^
  --stl ^
  c++_shared ^
  --ndk-version ^
  23 ^
  --output ^
  "C:\\Users\\User\\Desktop\\Disasters\\.utmp\\RelWithDebInfo\\171j3j5m\\prefab\\armeabi-v7a\\prefab-configure" ^
  "C:\\Users\\User\\.gradle\\caches\\transforms-3\\d7a4fef6c1de50f289bfe736463a11a6\\transformed\\games-frame-pacing-1.10.0\\prefab"
