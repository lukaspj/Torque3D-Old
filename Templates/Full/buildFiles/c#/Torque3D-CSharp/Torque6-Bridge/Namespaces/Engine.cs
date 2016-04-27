using System;
using System.Runtime.InteropServices;
using Torque6_Bridge.SimObjects;
using Torque6_Bridge.SimObjects.Scene;
using Torque6_Bridge.Utility;
using Torque6_Bridge.Types;

namespace Torque6_Bridge.Namespaces
{
   public static unsafe class Engine
   {
      
      #region UnsafeNativeMethods

      new internal struct InternalUnsafeMethods
      {
         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void Engine_CopyBehaviorToComponent(IntPtr behavior, IntPtr component);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void Engine_DebugBreak();

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern string Engine_GetAppleDeviceIPAddress();

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void Engine_Quit();

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void Engine_QuitWithErrorMessage(string msg);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern string Engine_Detag(int tagId);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern string Engine_GetTag(string taggedString);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern int Engine_GetStockColorCount();

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern string Engine_GetStockColorName(int index);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern bool Engine_IsStockColor(string name);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern Color Engine_GetStockColor(string name);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern bool Engine_CaptureScreenArea(int posX, int posY, uint width, uint height, string fileName, string fileType);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern bool Engine_PNG2JPG(string bmpname, uint quality);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void Engine_ShowStats(bool enable);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void Engine_PopulateFontCacheString(string faceName, int size, string str);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void Engine_PopulateFontCacheRange(string faceName, int size, int rangeStart, int rangeEnd);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void Engine_DumpFontCacheStatus();

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void Engine_WriteFontCache();

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void Engine_PopulateAllFontCacheString(string inString);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void Engine_PopulateAllFontCacheRange(int rangeStart, int rangeEnd);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void Engine_ExportCachedFont(string fontName, int size, string fileName, int padding, int kerning);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void Engine_ImportCachedFont(string fontName, int size, string fileName, int padding, int kerning);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void Engine_DuplicateCachedFont(string oldFontName, int oldFontSize, string newFontName, int newFontSize);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void Engine_SetOpenGLTextureCompressionHint(string hint);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void Engine_FlushTextureCache();

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void Engine_DumpTextureManagerMetrics();

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern bool Engine_CreateCanvas(string windowTitle);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void Engine_SetCanvasTitle(string windowTitle);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void Engine_ScreenShot(string file, string format);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern string Engine_StripMLControlChars(string sourceString);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void Engine_InitLeapMotionManager();

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void Engine_EnableLeapMotionManager(bool enable);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern bool Engine_IsLeapMotionManagerEnabled();

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void Engine_EnableLeapCursorControl(bool enable);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern bool Engine_IsLeapCursorControlled();

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern bool Engine_ConfigureLeapGesture(string gestureString, float value);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void Engine_GetPointFromProjection(Point3F pos, Point2F outPos);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void Engine_GetPointFromIntersection(int fingerID, Point2F outPos);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern string Engine_FindFirstFile(string pattern);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern string Engine_FindNextFile(string pattern);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern int Engine_GetFileCount(string pattern);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern string Engine_FindFirstFileMultiExpr(string pattern);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern string Engine_FindNextFileMultiExpr(string pattern);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern int Engine_GetFileCountMultiExpr(string pattern);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern int Engine_GetFileCRC(string fileName);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern bool Engine_IsDirectory(string path);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern bool Engine_IsFile(string fileName);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern bool Engine_IsWriteableFileName(string fileName);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern string Engine_GetDirectoryList(string dirPath, int depth);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern string Engine_GetFileList(string strPath);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern int Engine_FileSize(string fileName);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern bool Engine_FileDelete(string fileName);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern bool Engine_DirectoryDelete(string directoryName);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern bool Engine_IsValidImageFile(string filePath);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern string Engine_FileExt(string fileName);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern string Engine_FileBase(string fileName);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern string Engine_FileName(string fileName);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern string Engine_FilePath(string fileName);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void Engine_OpenFolder(string path);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern bool Engine_PathCopy(string fromFile, string toFile, bool noOverwrite);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern string Engine_GetCurrentDirectory();

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern bool Engine_SetCurrentDirectory(string absolutePathName);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern string Engine_GetExecutableName();

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern string Engine_GetMainDotCsDir();

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern string Engine_MakeFullPath(string path, string currentWorkingDirectory);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern string Engine_MakeRelativePath(string path, string to);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern string Engine_PathConcat(string path, int argc, string[] argv);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void Engine_RestartInstance();

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern bool Engine_CreatePath(string path);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void Engine_DumpResources(bool onlyLoaded);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void Engine_AddResPath(string path, bool ignoreZips);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void Engine_RemoveResPath(string path);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void Engine_SetModPaths(string path);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern string Engine_GetModPaths();

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void Engine_PurgeResources();

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern bool Engine_IsUsingVFS();

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern int Engine_GetMaxFrameAllocation();

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern bool Engine_IsQueueRegistered(string queueName);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void Engine_RegisterMessageQueue(string queueName);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void Engine_UnregisterMessageQueue(string queueName);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern bool Engine_RegisterMessageListener(string queueName, IntPtr listener);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void Engine_UnregisterMessageListener(string queueName, IntPtr listener);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern bool Engine_DispatchMessage(string queueName, string evt, string data);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern bool Engine_DispatchMessageObject(string queueName, IntPtr msgObj);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void Engine_DNetSetLogging(bool enabled);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void Engine_AllowConnections(bool enable);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void Engine_DumpNetStringTable();

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void Engine_CommandToServer(int argc, string[] argv);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void Engine_CommandToClient(IntPtr conn, int argc, string[] argv);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void Engine_RemoveTaggedString(string tag);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern string Engine_AddTaggedString(string tag);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern string Engine_GetTaggedString(string tag);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern string Engine_BuildTaggedString(string format, int argc, string[] argv);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void Engine_QueryLanServers(uint lanPort, byte flags, string gameType, string missionType, byte minPlayers, byte maxPlayers, byte maxBots, uint regionMask, uint maxPing, ushort minCPU, byte filterFlags);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void Engine_QueryMasterServer(uint lanPort, byte flags, string gameType, string missionType, byte minPlayers, byte maxPlayers, byte maxBots, uint regionMask, uint maxPing, ushort minCPU, byte filterFlags);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void Engine_QuerySingleServer(string address, byte flags);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void Engine_CancelServerQuery();

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void Engine_StopServerQuery();

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void Engine_StartHeartBeat();

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void Engine_StopHeartBeat();

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern int Engine_GetServerCount();

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern bool Engine_SetServerInfo(int index);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void Engine_telnetSetParameters(int port, string consolePass, string listenPass, bool remoteEcho);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern bool Engine_TamlWrite(IntPtr obj, string filename, string format, bool compressed);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern IntPtr Engine_TamlRead(string filename, string format);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern bool Engine_GenerateTamlSchema();

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void Engine_InputPushCursor(string cursorShapeName);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void Engine_InputPopCursor();

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern string Engine_GetTemporaryDirectory();

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern string Engine_GetTemporaryFileName();

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern string Engine_GetUserDataDirectory();

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern string Engine_GetUserHomeDirectory();

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void Engine_SetMainDotCsDir(string csDir);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern bool Engine_ActivateKeyboard();

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void Engine_DeactivateKeyboard();

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void Engine_EnableMouse();

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void Engine_DisableMouse();

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern bool Engine_EnableJoystick();

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void Engine_DisableJoystick();

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void Engine_EchoInputState();

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern bool Engine_EnableXInput();

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void Engine_DisableXInput();

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void Engine_ResetXInput();

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern bool Engine_IsXInputConnected(int controllerID);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern int Engine_GetXInputState(int controllerID, string prop, bool current);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void Engine_Rumble(string device, float xRumble, float yRumble);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern bool Engine_SetNetPort(int port);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void Engine_CloseNetPort();

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern string Engine_StripChars(string sourceString, string chars);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern string Engine_StripColorCodes(string sourceString, string chars);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern bool Engine_SetDisplayDevice(string deviceName, uint width, uint height, uint bpp, bool fullScreen);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern bool Engine_SetScreenMode(uint width, uint height, uint bpp, bool fullScreen);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern bool Engine_ToggleFullScreen();

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern bool Engine_IsFullScreen();

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern bool Engine_SwitchBitDepth();

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern bool Engine_PrevResolution();

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern bool Engine_NextResolution();

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern string Engine_GetResolution();

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern bool Engine_SetResolution(uint width, uint height, uint bpp);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern string Engine_GetDesktopResolution();

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern string Engine_GetDisplayDeviceList();

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern string Engine_GetResolutionList(string deviceName);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern string Engine_GetVideoDriverInfo();

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern bool Engine_IsDeviceFullScreenOnly(string deviceName);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void Engine_VideoSetGammaCorrection(float gamma);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern bool Engine_SetVerticalSync(bool enable);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void Engine_MinimizeWindow();

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void Engine_RestoreWindow();

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void Engine_SetMouseLock(bool enable);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern int Engine_GetRealTime();

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern string Engine_GetLocalTime();

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern string Engine_GetClipboard();

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern bool Engine_SetClipboard(string val);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern string Engine_CreateUUID();

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern int Engine_MessageBox(string title, string message, string buttons, string icon);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void Engine_InitDisplayDeviceInfo();

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void Engine_EnableWinConsole(bool enable);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern bool Engine_ShellExecute(string executable, string args, string directory);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern bool Engine_ShellExecuteBlocking(string executable, string args, string directory);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void Engine_GLEnableLogging(bool enable);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void Engine_GLEnableOutline(bool enable);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void Engine_GLEnableMetrics(bool enable);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern bool Engine_IsJoystickDetected();

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern string Engine_GetJoystickAxes(int instance);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern int Engine_GetJoystickCount();

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void Engine_MathInit(int argc, string[] argv);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void Engine_AddCardProfile(string vendor, string renderer, bool safeMode, bool lockArray, bool subImage, bool fogTexture, bool noEnvColor, bool clipHigh, bool deleteContext, bool texCompress, bool interiorLock, bool skipFirstFog, bool only16, bool noArraysAlpha, string profileName);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void Engine_AddOSCardProfile(string vendor, string renderer, bool allowOpenGL, bool preferOpenGL);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern int Engine_GetSimTime();

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void Engine_Cancel(int eventID);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern bool Engine_IsEventPending(int eventID);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern int Engine_GetEventTimeLeft(int eventID);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern int Engine_GetScheduleDuration(int eventID);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern int Engine_GetTimeSinceStart(int eventID);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern int Engine_Schedule(uint timeDelta, IntPtr refObject, string functionName, int argc, string[] argv);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern bool Engine_IsObjectByName(string handle);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern bool Engine_IsObjectByID(int handle);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void Engine_DeleteDataBlocks();

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern bool Engine_SaveObject(IntPtr obj, string filename);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern IntPtr Engine_LoadObject(string filename);

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void Engine_sbmDumpStats();

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern void Engine_sbmDumpStrings();

         [DllImport("Torque6_DEBUG", CallingConvention = CallingConvention.Cdecl)]
         internal static extern int Engine_RunAllUnitTests();
      }

      #endregion
      
      #region Functions

      public static void CopyBehaviorToComponent(BehaviorInstance behavior, SimComponent component)
      {
         InternalUnsafeMethods.Engine_CopyBehaviorToComponent(behavior.ObjectPtr->ObjPtr, component.ObjectPtr->ObjPtr);
      }

      public static void DebugBreak()
      {
         InternalUnsafeMethods.Engine_DebugBreak();
      }

      public static string GetAppleDeviceIPAddress()
      {
         return InternalUnsafeMethods.Engine_GetAppleDeviceIPAddress();
      }

      public static void Quit()
      {
         InternalUnsafeMethods.Engine_Quit();
      }

      public static void QuitWithErrorMessage(string msg)
      {
         InternalUnsafeMethods.Engine_QuitWithErrorMessage(msg);
      }

      public static string Detag(int tagId)
      {
         return InternalUnsafeMethods.Engine_Detag(tagId);
      }

      public static string GetTag(string taggedString)
      {
         return InternalUnsafeMethods.Engine_GetTag(taggedString);
      }

      public static int GetStockColorCount()
      {
         return InternalUnsafeMethods.Engine_GetStockColorCount();
      }

      public static string GetStockColorName(int index)
      {
         return InternalUnsafeMethods.Engine_GetStockColorName(index);
      }

      public static bool IsStockColor(string name)
      {
         return InternalUnsafeMethods.Engine_IsStockColor(name);
      }

      public static Color GetStockColor(string name)
      {
         return InternalUnsafeMethods.Engine_GetStockColor(name);
      }

      public static bool CaptureScreenArea(int posX, int posY, uint width, uint height, string fileName, string fileType)
      {
         return InternalUnsafeMethods.Engine_CaptureScreenArea(posX, posY, width, height, fileName, fileType);
      }

      public static bool PNG2JPG(string bmpname, uint quality)
      {
         return InternalUnsafeMethods.Engine_PNG2JPG(bmpname, quality);
      }

      public static void ShowStats(bool enable)
      {
         InternalUnsafeMethods.Engine_ShowStats(enable);
      }

      public static void PopulateFontCacheString(string faceName, int size, string str)
      {
         InternalUnsafeMethods.Engine_PopulateFontCacheString(faceName, size, str);
      }

      public static void PopulateFontCacheRange(string faceName, int size, int rangeStart, int rangeEnd)
      {
         InternalUnsafeMethods.Engine_PopulateFontCacheRange(faceName, size, rangeStart, rangeEnd);
      }

      public static void DumpFontCacheStatus()
      {
         InternalUnsafeMethods.Engine_DumpFontCacheStatus();
      }

      public static void WriteFontCache()
      {
         InternalUnsafeMethods.Engine_WriteFontCache();
      }

      public static void PopulateAllFontCacheString(string inString)
      {
         InternalUnsafeMethods.Engine_PopulateAllFontCacheString(inString);
      }

      public static void PopulateAllFontCacheRange(int rangeStart, int rangeEnd)
      {
         InternalUnsafeMethods.Engine_PopulateAllFontCacheRange(rangeStart, rangeEnd);
      }

      public static void ExportCachedFont(string fontName, int size, string fileName, int padding, int kerning)
      {
         InternalUnsafeMethods.Engine_ExportCachedFont(fontName, size, fileName, padding, kerning);
      }

      public static void ImportCachedFont(string fontName, int size, string fileName, int padding, int kerning)
      {
         InternalUnsafeMethods.Engine_ImportCachedFont(fontName, size, fileName, padding, kerning);
      }

      public static void DuplicateCachedFont(string oldFontName, int oldFontSize, string newFontName, int newFontSize)
      {
         InternalUnsafeMethods.Engine_DuplicateCachedFont(oldFontName, oldFontSize, newFontName, newFontSize);
      }

      public static void SetOpenGLTextureCompressionHint(string hint)
      {
         InternalUnsafeMethods.Engine_SetOpenGLTextureCompressionHint(hint);
      }

      public static void FlushTextureCache()
      {
         InternalUnsafeMethods.Engine_FlushTextureCache();
      }

      public static void DumpTextureManagerMetrics()
      {
         InternalUnsafeMethods.Engine_DumpTextureManagerMetrics();
      }

      public static bool CreateCanvas(string windowTitle)
      {
         return InternalUnsafeMethods.Engine_CreateCanvas(windowTitle);
      }

      public static void SetCanvasTitle(string windowTitle)
      {
         InternalUnsafeMethods.Engine_SetCanvasTitle(windowTitle);
      }

      public static void ScreenShot(string file, string format)
      {
         InternalUnsafeMethods.Engine_ScreenShot(file, format);
      }

      public static string StripMLControlChars(string sourceString)
      {
         return InternalUnsafeMethods.Engine_StripMLControlChars(sourceString);
      }

      public static void InitLeapMotionManager()
      {
         InternalUnsafeMethods.Engine_InitLeapMotionManager();
      }

      public static void EnableLeapMotionManager(bool enable)
      {
         InternalUnsafeMethods.Engine_EnableLeapMotionManager(enable);
      }

      public static bool IsLeapMotionManagerEnabled()
      {
         return InternalUnsafeMethods.Engine_IsLeapMotionManagerEnabled();
      }

      public static void EnableLeapCursorControl(bool enable)
      {
         InternalUnsafeMethods.Engine_EnableLeapCursorControl(enable);
      }

      public static bool IsLeapCursorControlled()
      {
         return InternalUnsafeMethods.Engine_IsLeapCursorControlled();
      }

      public static bool ConfigureLeapGesture(string gestureString, float value)
      {
         return InternalUnsafeMethods.Engine_ConfigureLeapGesture(gestureString, value);
      }

      public static void GetPointFromProjection(Point3F pos, Point2F outPos)
      {
         InternalUnsafeMethods.Engine_GetPointFromProjection(pos, outPos);
      }

      public static void GetPointFromIntersection(int fingerID, Point2F outPos)
      {
         InternalUnsafeMethods.Engine_GetPointFromIntersection(fingerID, outPos);
      }

      public static string FindFirstFile(string pattern)
      {
         return InternalUnsafeMethods.Engine_FindFirstFile(pattern);
      }

      public static string FindNextFile(string pattern)
      {
         return InternalUnsafeMethods.Engine_FindNextFile(pattern);
      }

      public static int GetFileCount(string pattern)
      {
         return InternalUnsafeMethods.Engine_GetFileCount(pattern);
      }

      public static string FindFirstFileMultiExpr(string pattern)
      {
         return InternalUnsafeMethods.Engine_FindFirstFileMultiExpr(pattern);
      }

      public static string FindNextFileMultiExpr(string pattern)
      {
         return InternalUnsafeMethods.Engine_FindNextFileMultiExpr(pattern);
      }

      public static int GetFileCountMultiExpr(string pattern)
      {
         return InternalUnsafeMethods.Engine_GetFileCountMultiExpr(pattern);
      }

      public static int GetFileCRC(string fileName)
      {
         return InternalUnsafeMethods.Engine_GetFileCRC(fileName);
      }

      public static bool IsDirectory(string path)
      {
         return InternalUnsafeMethods.Engine_IsDirectory(path);
      }

      public static bool IsFile(string fileName)
      {
         return InternalUnsafeMethods.Engine_IsFile(fileName);
      }

      public static bool IsWriteableFileName(string fileName)
      {
         return InternalUnsafeMethods.Engine_IsWriteableFileName(fileName);
      }

      public static string GetDirectoryList(string dirPath, int depth)
      {
         return InternalUnsafeMethods.Engine_GetDirectoryList(dirPath, depth);
      }

      public static string GetFileList(string strPath)
      {
         return InternalUnsafeMethods.Engine_GetFileList(strPath);
      }

      public static int FileSize(string fileName)
      {
         return InternalUnsafeMethods.Engine_FileSize(fileName);
      }

      public static bool FileDelete(string fileName)
      {
         return InternalUnsafeMethods.Engine_FileDelete(fileName);
      }

      public static bool DirectoryDelete(string directoryName)
      {
         return InternalUnsafeMethods.Engine_DirectoryDelete(directoryName);
      }

      public static bool IsValidImageFile(string filePath)
      {
         return InternalUnsafeMethods.Engine_IsValidImageFile(filePath);
      }

      public static string FileExt(string fileName)
      {
         return InternalUnsafeMethods.Engine_FileExt(fileName);
      }

      public static string FileBase(string fileName)
      {
         return InternalUnsafeMethods.Engine_FileBase(fileName);
      }

      public static string FileName(string fileName)
      {
         return InternalUnsafeMethods.Engine_FileName(fileName);
      }

      public static string FilePath(string fileName)
      {
         return InternalUnsafeMethods.Engine_FilePath(fileName);
      }

      public static void OpenFolder(string path)
      {
         InternalUnsafeMethods.Engine_OpenFolder(path);
      }

      public static bool PathCopy(string fromFile, string toFile, bool noOverwrite)
      {
         return InternalUnsafeMethods.Engine_PathCopy(fromFile, toFile, noOverwrite);
      }

      public static string GetCurrentDirectory()
      {
         return InternalUnsafeMethods.Engine_GetCurrentDirectory();
      }

      public static bool SetCurrentDirectory(string absolutePathName)
      {
         return InternalUnsafeMethods.Engine_SetCurrentDirectory(absolutePathName);
      }

      public static string GetExecutableName()
      {
         return InternalUnsafeMethods.Engine_GetExecutableName();
      }

      public static string GetMainDotCsDir()
      {
         return InternalUnsafeMethods.Engine_GetMainDotCsDir();
      }

      public static string MakeFullPath(string path, string currentWorkingDirectory)
      {
         return InternalUnsafeMethods.Engine_MakeFullPath(path, currentWorkingDirectory);
      }

      public static string MakeRelativePath(string path, string to)
      {
         return InternalUnsafeMethods.Engine_MakeRelativePath(path, to);
      }

      public static string PathConcat(string path, int argc, string[] argv)
      {
         return InternalUnsafeMethods.Engine_PathConcat(path, argc, argv);
      }

      public static void RestartInstance()
      {
         InternalUnsafeMethods.Engine_RestartInstance();
      }

      public static bool CreatePath(string path)
      {
         return InternalUnsafeMethods.Engine_CreatePath(path);
      }

      public static void DumpResources(bool onlyLoaded)
      {
         InternalUnsafeMethods.Engine_DumpResources(onlyLoaded);
      }

      public static void AddResPath(string path, bool ignoreZips)
      {
         InternalUnsafeMethods.Engine_AddResPath(path, ignoreZips);
      }

      public static void RemoveResPath(string path)
      {
         InternalUnsafeMethods.Engine_RemoveResPath(path);
      }

      public static void SetModPaths(string path)
      {
         InternalUnsafeMethods.Engine_SetModPaths(path);
      }

      public static string GetModPaths()
      {
         return InternalUnsafeMethods.Engine_GetModPaths();
      }

      public static void PurgeResources()
      {
         InternalUnsafeMethods.Engine_PurgeResources();
      }

      public static bool IsUsingVFS()
      {
         return InternalUnsafeMethods.Engine_IsUsingVFS();
      }

      public static int GetMaxFrameAllocation()
      {
         return InternalUnsafeMethods.Engine_GetMaxFrameAllocation();
      }

      public static bool IsQueueRegistered(string queueName)
      {
         return InternalUnsafeMethods.Engine_IsQueueRegistered(queueName);
      }

      public static void RegisterMessageQueue(string queueName)
      {
         InternalUnsafeMethods.Engine_RegisterMessageQueue(queueName);
      }

      public static void UnregisterMessageQueue(string queueName)
      {
         InternalUnsafeMethods.Engine_UnregisterMessageQueue(queueName);
      }

      public static bool RegisterMessageListener(string queueName, SimObject listener)
      {
         return InternalUnsafeMethods.Engine_RegisterMessageListener(queueName, listener.ObjectPtr->ObjPtr);
      }

      public static void UnregisterMessageListener(string queueName, SimObject listener)
      {
         InternalUnsafeMethods.Engine_UnregisterMessageListener(queueName, listener.ObjectPtr->ObjPtr);
      }

      public static bool DispatchMessage(string queueName, string evt, string data)
      {
         return InternalUnsafeMethods.Engine_DispatchMessage(queueName, evt, data);
      }

      public static bool DispatchMessageObject(string queueName, Message msgObj)
      {
         return InternalUnsafeMethods.Engine_DispatchMessageObject(queueName, msgObj.ObjectPtr->ObjPtr);
      }

      public static void DNetSetLogging(bool enabled)
      {
         InternalUnsafeMethods.Engine_DNetSetLogging(enabled);
      }

      public static void AllowConnections(bool enable)
      {
         InternalUnsafeMethods.Engine_AllowConnections(enable);
      }

      public static void DumpNetStringTable()
      {
         InternalUnsafeMethods.Engine_DumpNetStringTable();
      }

      public static void CommandToServer(int argc, string[] argv)
      {
         InternalUnsafeMethods.Engine_CommandToServer(argc, argv);
      }

      public static void CommandToClient(NetConnection conn, int argc, string[] argv)
      {
         InternalUnsafeMethods.Engine_CommandToClient(conn.ObjectPtr->ObjPtr, argc, argv);
      }

      public static void RemoveTaggedString(string tag)
      {
         InternalUnsafeMethods.Engine_RemoveTaggedString(tag);
      }

      public static string AddTaggedString(string tag)
      {
         return InternalUnsafeMethods.Engine_AddTaggedString(tag);
      }

      public static string GetTaggedString(string tag)
      {
         return InternalUnsafeMethods.Engine_GetTaggedString(tag);
      }

      public static string BuildTaggedString(string format, int argc, string[] argv)
      {
         return InternalUnsafeMethods.Engine_BuildTaggedString(format, argc, argv);
      }

      public static void QueryLanServers(uint lanPort, byte flags, string gameType, string missionType, byte minPlayers, byte maxPlayers, byte maxBots, uint regionMask, uint maxPing, ushort minCPU, byte filterFlags)
      {
         InternalUnsafeMethods.Engine_QueryLanServers(lanPort, flags, gameType, missionType, minPlayers, maxPlayers, maxBots, regionMask, maxPing, minCPU, filterFlags);
      }

      public static void QueryMasterServer(uint lanPort, byte flags, string gameType, string missionType, byte minPlayers, byte maxPlayers, byte maxBots, uint regionMask, uint maxPing, ushort minCPU, byte filterFlags)
      {
         InternalUnsafeMethods.Engine_QueryMasterServer(lanPort, flags, gameType, missionType, minPlayers, maxPlayers, maxBots, regionMask, maxPing, minCPU, filterFlags);
      }

      public static void QuerySingleServer(string address, byte flags)
      {
         InternalUnsafeMethods.Engine_QuerySingleServer(address, flags);
      }

      public static void CancelServerQuery()
      {
         InternalUnsafeMethods.Engine_CancelServerQuery();
      }

      public static void StopServerQuery()
      {
         InternalUnsafeMethods.Engine_StopServerQuery();
      }

      public static void StartHeartBeat()
      {
         InternalUnsafeMethods.Engine_StartHeartBeat();
      }

      public static void StopHeartBeat()
      {
         InternalUnsafeMethods.Engine_StopHeartBeat();
      }

      public static int GetServerCount()
      {
         return InternalUnsafeMethods.Engine_GetServerCount();
      }

      public static bool SetServerInfo(int index)
      {
         return InternalUnsafeMethods.Engine_SetServerInfo(index);
      }

      public static void telnetSetParameters(int port, string consolePass, string listenPass, bool remoteEcho)
      {
         InternalUnsafeMethods.Engine_telnetSetParameters(port, consolePass, listenPass, remoteEcho);
      }

      public static bool TamlWrite(SimObject obj, string filename, string format, bool compressed)
      {
         return InternalUnsafeMethods.Engine_TamlWrite(obj.ObjectPtr->ObjPtr, filename, format, compressed);
      }

      public static SimObject TamlRead(string filename, string format)
      {
         return new SimObject(InternalUnsafeMethods.Engine_TamlRead(filename, format));
      }

      public static bool GenerateTamlSchema()
      {
         return InternalUnsafeMethods.Engine_GenerateTamlSchema();
      }

      public static void InputPushCursor(string cursorShapeName)
      {
         InternalUnsafeMethods.Engine_InputPushCursor(cursorShapeName);
      }

      public static void InputPopCursor()
      {
         InternalUnsafeMethods.Engine_InputPopCursor();
      }

      public static string GetTemporaryDirectory()
      {
         return InternalUnsafeMethods.Engine_GetTemporaryDirectory();
      }

      public static string GetTemporaryFileName()
      {
         return InternalUnsafeMethods.Engine_GetTemporaryFileName();
      }

      public static string GetUserDataDirectory()
      {
         return InternalUnsafeMethods.Engine_GetUserDataDirectory();
      }

      public static string GetUserHomeDirectory()
      {
         return InternalUnsafeMethods.Engine_GetUserHomeDirectory();
      }

      public static void SetMainDotCsDir(string csDir)
      {
         InternalUnsafeMethods.Engine_SetMainDotCsDir(csDir);
      }

      public static bool ActivateKeyboard()
      {
         return InternalUnsafeMethods.Engine_ActivateKeyboard();
      }

      public static void DeactivateKeyboard()
      {
         InternalUnsafeMethods.Engine_DeactivateKeyboard();
      }

      public static void EnableMouse()
      {
         InternalUnsafeMethods.Engine_EnableMouse();
      }

      public static void DisableMouse()
      {
         InternalUnsafeMethods.Engine_DisableMouse();
      }

      public static bool EnableJoystick()
      {
         return InternalUnsafeMethods.Engine_EnableJoystick();
      }

      public static void DisableJoystick()
      {
         InternalUnsafeMethods.Engine_DisableJoystick();
      }

      public static void EchoInputState()
      {
         InternalUnsafeMethods.Engine_EchoInputState();
      }

      public static bool EnableXInput()
      {
         return InternalUnsafeMethods.Engine_EnableXInput();
      }

      public static void DisableXInput()
      {
         InternalUnsafeMethods.Engine_DisableXInput();
      }

      public static void ResetXInput()
      {
         InternalUnsafeMethods.Engine_ResetXInput();
      }

      public static bool IsXInputConnected(int controllerID)
      {
         return InternalUnsafeMethods.Engine_IsXInputConnected(controllerID);
      }

      public static int GetXInputState(int controllerID, string prop, bool current)
      {
         return InternalUnsafeMethods.Engine_GetXInputState(controllerID, prop, current);
      }

      public static void Rumble(string device, float xRumble, float yRumble)
      {
         InternalUnsafeMethods.Engine_Rumble(device, xRumble, yRumble);
      }

      public static bool SetNetPort(int port)
      {
         return InternalUnsafeMethods.Engine_SetNetPort(port);
      }

      public static void CloseNetPort()
      {
         InternalUnsafeMethods.Engine_CloseNetPort();
      }

      public static string StripChars(string sourceString, string chars)
      {
         return InternalUnsafeMethods.Engine_StripChars(sourceString, chars);
      }

      public static string StripColorCodes(string sourceString, string chars)
      {
         return InternalUnsafeMethods.Engine_StripColorCodes(sourceString, chars);
      }

      public static bool SetDisplayDevice(string deviceName, uint width, uint height, uint bpp, bool fullScreen)
      {
         return InternalUnsafeMethods.Engine_SetDisplayDevice(deviceName, width, height, bpp, fullScreen);
      }

      public static bool SetScreenMode(uint width, uint height, uint bpp, bool fullScreen)
      {
         return InternalUnsafeMethods.Engine_SetScreenMode(width, height, bpp, fullScreen);
      }

      public static bool ToggleFullScreen()
      {
         return InternalUnsafeMethods.Engine_ToggleFullScreen();
      }

      public static bool IsFullScreen()
      {
         return InternalUnsafeMethods.Engine_IsFullScreen();
      }

      public static bool SwitchBitDepth()
      {
         return InternalUnsafeMethods.Engine_SwitchBitDepth();
      }

      public static bool PrevResolution()
      {
         return InternalUnsafeMethods.Engine_PrevResolution();
      }

      public static bool NextResolution()
      {
         return InternalUnsafeMethods.Engine_NextResolution();
      }

      public static string GetResolution()
      {
         return InternalUnsafeMethods.Engine_GetResolution();
      }

      public static bool SetResolution(uint width, uint height, uint bpp)
      {
         return InternalUnsafeMethods.Engine_SetResolution(width, height, bpp);
      }

      public static string GetDesktopResolution()
      {
         return InternalUnsafeMethods.Engine_GetDesktopResolution();
      }

      public static string GetDisplayDeviceList()
      {
         return InternalUnsafeMethods.Engine_GetDisplayDeviceList();
      }

      public static string GetResolutionList(string deviceName)
      {
         return InternalUnsafeMethods.Engine_GetResolutionList(deviceName);
      }

      public static string GetVideoDriverInfo()
      {
         return InternalUnsafeMethods.Engine_GetVideoDriverInfo();
      }

      public static bool IsDeviceFullScreenOnly(string deviceName)
      {
         return InternalUnsafeMethods.Engine_IsDeviceFullScreenOnly(deviceName);
      }

      public static void VideoSetGammaCorrection(float gamma)
      {
         InternalUnsafeMethods.Engine_VideoSetGammaCorrection(gamma);
      }

      public static bool SetVerticalSync(bool enable)
      {
         return InternalUnsafeMethods.Engine_SetVerticalSync(enable);
      }

      public static void MinimizeWindow()
      {
         InternalUnsafeMethods.Engine_MinimizeWindow();
      }

      public static void RestoreWindow()
      {
         InternalUnsafeMethods.Engine_RestoreWindow();
      }

      public static void SetMouseLock(bool enable)
      {
         InternalUnsafeMethods.Engine_SetMouseLock(enable);
      }

      public static int GetRealTime()
      {
         return InternalUnsafeMethods.Engine_GetRealTime();
      }

      public static string GetLocalTime()
      {
         return InternalUnsafeMethods.Engine_GetLocalTime();
      }

      public static string GetClipboard()
      {
         return InternalUnsafeMethods.Engine_GetClipboard();
      }

      public static bool SetClipboard(string val)
      {
         return InternalUnsafeMethods.Engine_SetClipboard(val);
      }

      public static string CreateUUID()
      {
         return InternalUnsafeMethods.Engine_CreateUUID();
      }

      public static int MessageBox(string title, string message, string buttons, string icon)
      {
         return InternalUnsafeMethods.Engine_MessageBox(title, message, buttons, icon);
      }

      public static void InitDisplayDeviceInfo()
      {
         InternalUnsafeMethods.Engine_InitDisplayDeviceInfo();
      }

      public static void EnableWinConsole(bool enable)
      {
         InternalUnsafeMethods.Engine_EnableWinConsole(enable);
      }

      public static bool ShellExecute(string executable, string args, string directory)
      {
         return InternalUnsafeMethods.Engine_ShellExecute(executable, args, directory);
      }

      public static bool ShellExecuteBlocking(string executable, string args, string directory)
      {
         return InternalUnsafeMethods.Engine_ShellExecuteBlocking(executable, args, directory);
      }

      public static void GLEnableLogging(bool enable)
      {
         InternalUnsafeMethods.Engine_GLEnableLogging(enable);
      }

      public static void GLEnableOutline(bool enable)
      {
         InternalUnsafeMethods.Engine_GLEnableOutline(enable);
      }

      public static void GLEnableMetrics(bool enable)
      {
         InternalUnsafeMethods.Engine_GLEnableMetrics(enable);
      }

      public static bool IsJoystickDetected()
      {
         return InternalUnsafeMethods.Engine_IsJoystickDetected();
      }

      public static string GetJoystickAxes(int instance)
      {
         return InternalUnsafeMethods.Engine_GetJoystickAxes(instance);
      }

      public static int GetJoystickCount()
      {
         return InternalUnsafeMethods.Engine_GetJoystickCount();
      }

      public static void MathInit(int argc, string[] argv)
      {
         InternalUnsafeMethods.Engine_MathInit(argc, argv);
      }

      public static void AddCardProfile(string vendor, string renderer, bool safeMode, bool lockArray, bool subImage, bool fogTexture, bool noEnvColor, bool clipHigh, bool deleteContext, bool texCompress, bool interiorLock, bool skipFirstFog, bool only16, bool noArraysAlpha, string profileName)
      {
         InternalUnsafeMethods.Engine_AddCardProfile(vendor, renderer, safeMode, lockArray, subImage, fogTexture, noEnvColor, clipHigh, deleteContext, texCompress, interiorLock, skipFirstFog, only16, noArraysAlpha, profileName);
      }

      public static void AddOSCardProfile(string vendor, string renderer, bool allowOpenGL, bool preferOpenGL)
      {
         InternalUnsafeMethods.Engine_AddOSCardProfile(vendor, renderer, allowOpenGL, preferOpenGL);
      }

      public static int GetSimTime()
      {
         return InternalUnsafeMethods.Engine_GetSimTime();
      }

      public static void Cancel(int eventID)
      {
         InternalUnsafeMethods.Engine_Cancel(eventID);
      }

      public static bool IsEventPending(int eventID)
      {
         return InternalUnsafeMethods.Engine_IsEventPending(eventID);
      }

      public static int GetEventTimeLeft(int eventID)
      {
         return InternalUnsafeMethods.Engine_GetEventTimeLeft(eventID);
      }

      public static int GetScheduleDuration(int eventID)
      {
         return InternalUnsafeMethods.Engine_GetScheduleDuration(eventID);
      }

      public static int GetTimeSinceStart(int eventID)
      {
         return InternalUnsafeMethods.Engine_GetTimeSinceStart(eventID);
      }

      public static int Schedule(uint timeDelta, SimObject refObject, string functionName, int argc, string[] argv)
      {
         return InternalUnsafeMethods.Engine_Schedule(timeDelta, refObject.ObjectPtr->ObjPtr, functionName, argc, argv);
      }

      public static bool IsObjectByName(string handle)
      {
         return InternalUnsafeMethods.Engine_IsObjectByName(handle);
      }

      public static bool IsObjectByID(int handle)
      {
         return InternalUnsafeMethods.Engine_IsObjectByID(handle);
      }

      public static void DeleteDataBlocks()
      {
         InternalUnsafeMethods.Engine_DeleteDataBlocks();
      }

      public static bool SaveObject(SimObject obj, string filename)
      {
         return InternalUnsafeMethods.Engine_SaveObject(obj.ObjectPtr->ObjPtr, filename);
      }

      public static SimObject LoadObject(string filename)
      {
         return new SimObject(InternalUnsafeMethods.Engine_LoadObject(filename));
      }

      public static void sbmDumpStats()
      {
         InternalUnsafeMethods.Engine_sbmDumpStats();
      }

      public static void sbmDumpStrings()
      {
         InternalUnsafeMethods.Engine_sbmDumpStrings();
      }

      public static int RunAllUnitTests()
      {
         return InternalUnsafeMethods.Engine_RunAllUnitTests();
      }      

      #endregion
   }
}