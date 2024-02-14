using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.IO;
using System.Diagnostics;
using EO.WebBrowser;
using System.Security.Cryptography;
using System.Reflection;
using Microsoft.Win32.SafeHandles;
using System.Threading;
using System.Numerics;
using System.Globalization;
using HtmlAgilityPack;
using Ozeki.Media;
using BrandonPotter.XBox;
namespace FTA
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        [DllImport("winmm.dll", EntryPoint = "timeBeginPeriod")]
        public static extern uint TimeBeginPeriod(uint ms);
        [DllImport("winmm.dll", EntryPoint = "timeEndPeriod")]
        public static extern uint TimeEndPeriod(uint ms);
        [DllImport("ntdll.dll", EntryPoint = "NtSetTimerResolution")]
        public static extern void NtSetTimerResolution(uint DesiredResolution, bool SetResolution, ref uint CurrentResolution);
        public static uint CurrentResolution = 0;
        [DllImport("advapi32.dll")]
        private static extern bool LogonUser(string lpszUsername, string lpszDomain, string lpszPassword, int dwLogonType, int dwLogonProvider, out IntPtr phToken);
        [DllImport("User32.dll")]
        public static extern bool GetCursorPos(out int x, out int y);
        [DllImport("user32.dll")]
        public static extern void SetCursorPos(int X, int Y);
        public static int width = System.Windows.Forms.Screen.PrimaryScreen.Bounds.Width;
        public static int height = System.Windows.Forms.Screen.PrimaryScreen.Bounds.Height;
        private static EO.WebBrowser.DOM.Document document;
        private static string htmlscript = "", pagename = "", stringscript = "", openpath = "", ftascript = "", microsoftkeyboard = "", microsoftmouse = "", xboxcontroller = "", htmlscripttemp = "";
        public static bool scriptrunning = false, Getstate = false, disguardscriptrunning = false;
        private static string[] UsersAllowedList, SpeechToText;
        private static bool checkingusername;
        private static int sleeptime;
        private Type program;
        private object obj;
        private Assembly assembly;
        private System.CodeDom.Compiler.CompilerResults results;
        private Microsoft.CSharp.CSharpCodeProvider provider;
        private System.CodeDom.Compiler.CompilerParameters parameters;
        string code = @"
                using System;
                using System.Runtime.InteropServices;
                namespace StringToCode
                {
                    public class FooClass 
                    { 
                        public int pollcount = 0, sleeptime = 1;
                        public bool getstate = false;
                        string[] UsersAllowedList = new string[] { };
                        string[] SpeechToText = new string[] { };
                        string KeyboardMouseDriverType = """"; double MouseMoveX; double MouseMoveY; double MouseAbsX; double MouseAbsY; double MouseDesktopX; double MouseDesktopY; bool SendLeftClick; bool SendRightClick; bool SendMiddleClick; bool SendWheelUp; bool SendWheelDown; bool SendLeft; bool SendRight; bool SendUp; bool SendDown; bool SendLButton; bool SendRButton; bool SendCancel; bool SendMBUTTON; bool SendXBUTTON1; bool SendXBUTTON2; bool SendBack; bool SendTab; bool SendClear; bool SendReturn; bool SendSHIFT; bool SendCONTROL; bool SendMENU; bool SendPAUSE; bool SendCAPITAL; bool SendKANA; bool SendHANGEUL; bool SendHANGUL; bool SendJUNJA; bool SendFINAL; bool SendHANJA; bool SendKANJI; bool SendEscape; bool SendCONVERT; bool SendNONCONVERT; bool SendACCEPT; bool SendMODECHANGE; bool SendSpace; bool SendPRIOR; bool SendNEXT; bool SendEND; bool SendHOME; bool SendLEFT; bool SendUP; bool SendRIGHT; bool SendDOWN; bool SendSELECT; bool SendPRINT; bool SendEXECUTE; bool SendSNAPSHOT; bool SendINSERT; bool SendDELETE; bool SendHELP; bool SendAPOSTROPHE; bool Send0; bool Send1; bool Send2; bool Send3; bool Send4; bool Send5; bool Send6; bool Send7; bool Send8; bool Send9; bool SendA; bool SendB; bool SendC; bool SendD; bool SendE; bool SendF; bool SendG; bool SendH; bool SendI; bool SendJ; bool SendK; bool SendL; bool SendM; bool SendN; bool SendO; bool SendP; bool SendQ; bool SendR; bool SendS; bool SendT; bool SendU; bool SendV; bool SendW; bool SendX; bool SendY; bool SendZ; bool SendLWIN; bool SendRWIN; bool SendAPPS; bool SendSLEEP; bool SendNUMPAD0; bool SendNUMPAD1; bool SendNUMPAD2; bool SendNUMPAD3; bool SendNUMPAD4; bool SendNUMPAD5; bool SendNUMPAD6; bool SendNUMPAD7; bool SendNUMPAD8; bool SendNUMPAD9; bool SendMULTIPLY; bool SendADD; bool SendSEPARATOR; bool SendSUBTRACT; bool SendDECIMAL; bool SendDIVIDE; bool SendF1; bool SendF2; bool SendF3; bool SendF4; bool SendF5; bool SendF6; bool SendF7; bool SendF8; bool SendF9; bool SendF10; bool SendF11; bool SendF12; bool SendF13; bool SendF14; bool SendF15; bool SendF16; bool SendF17; bool SendF18; bool SendF19; bool SendF20; bool SendF21; bool SendF22; bool SendF23; bool SendF24; bool SendNUMLOCK; bool SendSCROLL; bool SendLeftShift; bool SendRightShift; bool SendLeftControl; bool SendRightControl; bool SendLMENU; bool SendRMENU; 
                        bool back; bool start; bool A; bool B; bool X; bool Y; bool up; bool left; bool down; bool right; bool leftstick; bool rightstick; bool leftbumper; bool rightbumper; bool lefttrigger; bool righttrigger; double leftstickx; double leftsticky; double rightstickx; double rightsticky; 
                        double centery = 160f;
                        int irmode = 1, keys12345, keys54321;
                        public static int[] wd = { 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2 };
                        public static int[] wu = { 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2 };
                        public static void valchanged(int n, bool val)
                        {
                            if (val)
                            {
                                if (wd[n] <= 1)
                                {
                                    wd[n] = wd[n] + 1;
                                }
                                wu[n] = 0;
                            }
                            else
                            {
                                if (wu[n] <= 1)
                                {
                                    wu[n] = wu[n] + 1;
                                }
                                wd[n] = 0;
                            }
                        }
                        public object[] Main(int width, int height, double MouseHookX, double MouseHookY, bool MouseHookButtonX1, bool MouseHookButtonX2, bool MouseHookWheelUp, bool MouseHookWheelDown, bool MouseHookRightButton, bool MouseHookLeftButton, bool MouseHookMiddleButton, bool MouseHookXButton, bool Key_LBUTTON, bool Key_RBUTTON, bool Key_CANCEL, bool Key_MBUTTON, bool Key_XBUTTON1, bool Key_XBUTTON2, bool Key_BACK, bool Key_Tab, bool Key_CLEAR, bool Key_Return, bool Key_SHIFT, bool Key_CONTROL, bool Key_MENU, bool Key_PAUSE, bool Key_CAPITAL, bool Key_KANA, bool Key_HANGEUL, bool Key_HANGUL, bool Key_JUNJA, bool Key_FINAL, bool Key_HANJA, bool Key_KANJI, bool Key_Escape, bool Key_CONVERT, bool Key_NONCONVERT, bool Key_ACCEPT, bool Key_MODECHANGE, bool Key_Space, bool Key_PRIOR, bool Key_NEXT, bool Key_END, bool Key_HOME, bool Key_LEFT, bool Key_UP, bool Key_RIGHT, bool Key_DOWN, bool Key_SELECT, bool Key_PRINT, bool Key_EXECUTE, bool Key_SNAPSHOT, bool Key_INSERT, bool Key_DELETE, bool Key_HELP, bool Key_APOSTROPHE, bool Key_0, bool Key_1, bool Key_2, bool Key_3, bool Key_4, bool Key_5, bool Key_6, bool Key_7, bool Key_8, bool Key_9, bool Key_A, bool Key_B, bool Key_C, bool Key_D, bool Key_E, bool Key_F, bool Key_G, bool Key_H, bool Key_I, bool Key_J, bool Key_K, bool Key_L, bool Key_M, bool Key_N, bool Key_O, bool Key_P, bool Key_Q, bool Key_R, bool Key_S, bool Key_T, bool Key_U, bool Key_V, bool Key_W, bool Key_X, bool Key_Y, bool Key_Z, bool Key_LWIN, bool Key_RWIN, bool Key_APPS, bool Key_SLEEP, bool Key_NUMPAD0, bool Key_NUMPAD1, bool Key_NUMPAD2, bool Key_NUMPAD3, bool Key_NUMPAD4, bool Key_NUMPAD5, bool Key_NUMPAD6, bool Key_NUMPAD7, bool Key_NUMPAD8, bool Key_NUMPAD9, bool Key_MULTIPLY, bool Key_ADD, bool Key_SEPARATOR, bool Key_SUBTRACT, bool Key_DECIMAL, bool Key_DIVIDE, bool Key_F1, bool Key_F2, bool Key_F3, bool Key_F4, bool Key_F5, bool Key_F6, bool Key_F7, bool Key_F8, bool Key_F9, bool Key_F10, bool Key_F11, bool Key_F12, bool Key_F13, bool Key_F14, bool Key_F15, bool Key_F16, bool Key_F17, bool Key_F18, bool Key_F19, bool Key_F20, bool Key_F21, bool Key_F22, bool Key_F23, bool Key_F24, bool Key_NUMLOCK, bool Key_SCROLL, bool Key_LeftShift, bool Key_RightShift, bool Key_LeftControl, bool Key_RightControl, bool Key_LMENU, bool Key_RMENU, bool Key_BROWSER_BACK, bool Key_BROWSER_FORWARD, bool Key_BROWSER_REFRESH, bool Key_BROWSER_STOP, bool Key_BROWSER_SEARCH, bool Key_BROWSER_FAVORITES, bool Key_BROWSER_HOME, bool Key_VOLUME_MUTE, bool Key_VOLUME_DOWN, bool Key_VOLUME_UP, bool Key_MEDIA_NEXT_TRACK, bool Key_MEDIA_PREV_TRACK, bool Key_MEDIA_STOP, bool Key_MEDIA_PLAY_PAUSE, bool Key_LAUNCH_MAIL, bool Key_LAUNCH_MEDIA_SELECT, bool Key_LAUNCH_APP1, bool Key_LAUNCH_APP2, bool Key_OEM_1, bool Key_OEM_PLUS, bool Key_OEM_COMMA, bool Key_OEM_MINUS, bool Key_OEM_PERIOD, bool Key_OEM_2, bool Key_OEM_3, bool Key_OEM_4, bool Key_OEM_5, bool Key_OEM_6, bool Key_OEM_7, bool Key_OEM_8, bool Key_OEM_102, bool Key_PROCESSKEY, bool Key_PACKET, bool Key_ATTN, bool Key_CRSEL, bool Key_EXSEL, bool Key_EREOF, bool Key_PLAY, bool Key_ZOOM, bool Key_NONAME, bool Key_PA1, bool Key_OEM_CLEAR, double irx, double iry, bool mWSButtonStateA, bool mWSButtonStateB, bool mWSButtonStateMinus, bool mWSButtonStateHome, bool mWSButtonStatePlus, bool mWSButtonStateOne, bool mWSButtonStateTwo, bool mWSButtonStateUp, bool mWSButtonStateDown, bool mWSButtonStateLeft, bool mWSButtonStateRight, double mWSRawValuesX, double mWSRawValuesY, double mWSRawValuesZ, double mWSNunchuckStateRawJoystickX, double mWSNunchuckStateRawJoystickY, double mWSNunchuckStateRawValuesX, double mWSNunchuckStateRawValuesY, double mWSNunchuckStateRawValuesZ, bool mWSNunchuckStateC, bool mWSNunchuckStateZ, double[] stickRight, bool RightButtonSHOULDER_1, bool RightButtonSHOULDER_2, bool RightButtonSR, bool RightButtonSL, bool RightButtonDPAD_DOWN, bool RightButtonDPAD_RIGHT, bool RightButtonDPAD_UP, bool RightButtonDPAD_LEFT, bool RightButtonPLUS, bool RightButtonHOME, bool RightButtonSTICK, bool RightButtonACC, bool RightButtonSPA, bool RightRollLeft, bool RightRollRight, double RightAccelX, double RightAccelY, double RightGyroX, double RightGyroY, double[] stickLeft, bool LeftButtonSHOULDER_1, bool LeftButtonSHOULDER_2, bool LeftButtonSR, bool LeftButtonSL, bool LeftButtonDPAD_DOWN, bool LeftButtonDPAD_RIGHT, bool LeftButtonDPAD_UP, bool LeftButtonDPAD_LEFT, bool LeftButtonMINUS, bool LeftButtonCAPTURE, bool LeftButtonSTICK, bool LeftButtonACC, bool LeftButtonSMA, bool LeftRollLeft, bool LeftRollRight, double LeftAccelX, double LeftAccelY, double LeftGyroX, double LeftGyroY, bool Controller_A, bool Controller_B, bool Controller_X, bool Controller_Y, bool Controller_LB, bool Controller_RB, bool Controller_LT, bool Controller_RT, bool Controller_MAP, bool Controller_MENU, bool Controller_LSTICK, bool Controller_RSTICK, bool Controller_DU, bool Controller_DD, bool Controller_DL, bool Controller_DR, bool Controller_XBOX, double Controller_LX, double Controller_LY, double Controller_RX, double Controller_RY, string TextFromSpeech, bool ButtonAPressed, bool ButtonBPressed, bool ButtonXPressed, bool ButtonYPressed, bool ButtonStartPressed, bool ButtonBackPressed, bool ButtonDownPressed, bool ButtonUpPressed, bool ButtonLeftPressed, bool ButtonRightPressed, bool ButtonShoulderLeftPressed, bool ButtonShoulderRightPressed, bool ThumbpadLeftPressed, bool ThumbpadRightPressed, bool TriggerLeftPressed, bool TriggerRightPressed, double TriggerLeftPressThreshold, double TriggerRightPressThreshold, double TriggerLeftPosition, double TriggerRightPosition, double ThumbLeftX, double ThumbLeftY, double ThumbRightX, double ThumbRightY)
                        {
                            funct_driver
                            return new object[] { UsersAllowedList, sleeptime, KeyboardMouseDriverType, MouseMoveX, MouseMoveY, MouseAbsX, MouseAbsY, MouseDesktopX, MouseDesktopY, SendLeftClick, SendRightClick, SendMiddleClick, SendWheelUp, SendWheelDown, SendLeft, SendRight, SendUp, SendDown, SendLButton, SendRButton, SendCancel, SendMBUTTON, SendXBUTTON1, SendXBUTTON2, SendBack, SendTab, SendClear, SendReturn, SendSHIFT, SendCONTROL, SendMENU, SendPAUSE, SendCAPITAL, SendKANA, SendHANGEUL, SendHANGUL, SendJUNJA, SendFINAL, SendHANJA, SendKANJI, SendEscape, SendCONVERT, SendNONCONVERT, SendACCEPT, SendMODECHANGE, SendSpace, SendPRIOR, SendNEXT, SendEND, SendHOME, SendLEFT, SendUP, SendRIGHT, SendDOWN, SendSELECT, SendPRINT, SendEXECUTE, SendSNAPSHOT, SendINSERT, SendDELETE, SendHELP, SendAPOSTROPHE, Send0, Send1, Send2, Send3, Send4, Send5, Send6, Send7, Send8, Send9, SendA, SendB, SendC, SendD, SendE, SendF, SendG, SendH, SendI, SendJ, SendK, SendL, SendM, SendN, SendO, SendP, SendQ, SendR, SendS, SendT, SendU, SendV, SendW, SendX, SendY, SendZ, SendLWIN, SendRWIN, SendAPPS, SendSLEEP, SendNUMPAD0, SendNUMPAD1, SendNUMPAD2, SendNUMPAD3, SendNUMPAD4, SendNUMPAD5, SendNUMPAD6, SendNUMPAD7, SendNUMPAD8, SendNUMPAD9, SendMULTIPLY, SendADD, SendSEPARATOR, SendSUBTRACT, SendDECIMAL, SendDIVIDE, SendF1, SendF2, SendF3, SendF4, SendF5, SendF6, SendF7, SendF8, SendF9, SendF10, SendF11, SendF12, SendF13, SendF14, SendF15, SendF16, SendF17, SendF18, SendF19, SendF20, SendF21, SendF22, SendF23, SendF24, SendNUMLOCK, SendSCROLL, SendLeftShift, SendRightShift, SendLeftControl, SendRightControl, SendLMENU, SendRMENU, back, start, A, B, X, Y, up, left, down, right, leftstick, rightstick, leftbumper, rightbumper, lefttrigger, righttrigger, leftstickx, leftsticky, rightstickx, rightsticky, centery, irmode, SpeechToText };
                        }
                        public double Scale(double value, double min, double max, double minScale, double maxScale)
                        {
                            double scaled = minScale + (double)(value - min) / (max - min) * (maxScale - minScale);
                            return scaled;
                        }
                    }
                }";
        MouseHook mouseHook = new MouseHook();
        KeyboardHook keyboardHook = new KeyboardHook();
        public static double MouseHookX, MouseHookY;
        public static int MouseHookWheel, MouseDesktopHookX, MouseDesktopHookY, MouseHookButtonX, MouseHookTime, mousehookwheelcount, mousehookbuttoncount;
        public static bool MouseHookLeftButton, MouseHookRightButton, MouseHookLeftDoubleClick, MouseHookRightDoubleClick, MouseHookMiddleButton, MouseHookXButton, mousehookwheelbool, mousehookbuttonbool, MouseHookButtonX1, MouseHookButtonX2, MouseHookWheelUp, MouseHookWheelDown;
        public static int vkCode, scanCode, mousehookx, mousehooky, tempmousehookx, tempmousehooky, axisx, axisy;
        public static bool KeyboardHookButtonDown, KeyboardHookButtonUp;
        public static bool Controller_A, Controller_B, Controller_X, Controller_Y, Controller_LB, Controller_RB, Controller_LT, Controller_RT, Controller_MAP, Controller_MENU, Controller_LSTICK, Controller_RSTICK, Controller_DU, Controller_DD, Controller_DL, Controller_DR, Controller_XBOX;
        public static double Controller_LX, Controller_LY, Controller_RX, Controller_RY;
        public static System.Collections.Generic.List<double> time = new System.Collections.Generic.List<double>();
        private static string username;
        private static ThreadStart threadstart;
        private static Thread thread;
        private static Ozeki.Media.Microphone microphone;
        private static Ozeki.Media.MediaConnector connector;
        private static Ozeki.Media.SpeechToText speechToText;
        private static string TextFromSpeech, folderpath;
        private static IEnumerable<XBoxController> connectedControllers;
        private static bool iscontrollerconnected;
        public static bool ButtonAPressed;
        public static bool ButtonBPressed;
        public static bool ButtonXPressed;
        public static bool ButtonYPressed;
        public static bool ButtonStartPressed;
        public static bool ButtonBackPressed;
        public static bool ButtonDownPressed;
        public static bool ButtonUpPressed;
        public static bool ButtonLeftPressed;
        public static bool ButtonRightPressed;
        public static bool ButtonShoulderLeftPressed;
        public static bool ButtonShoulderRightPressed;
        public static bool ThumbpadLeftPressed;
        public static bool ThumbpadRightPressed;
        public static bool TriggerLeftPressed;
        public static bool TriggerRightPressed;
        public static double TriggerLeftPressThreshold;
        public static double TriggerRightPressThreshold;
        public static double TriggerLeftPosition;
        public static double TriggerRightPosition;
        public static double ThumbLeftX;
        public static double ThumbLeftY;
        public static double ThumbRightX;
        public static double ThumbRightY;
        public static int[] wd = { 2 };
        public static int[] wu = { 2 };
        public static void valchanged(int n, bool val)
        {
            if (val)
            {
                if (wd[n] <= 1)
                {
                    wd[n] = wd[n] + 1;
                }
                wu[n] = 0;
            }
            else
            {
                if (wu[n] <= 1)
                {
                    wu[n] = wu[n] + 1;
                }
                wd[n] = 0;
            }
        }
        private void Form1_Shown(object sender, EventArgs e)
        {
            TimeBeginPeriod(1);
            NtSetTimerResolution(1, true, ref CurrentResolution);
            username = Program.username;
            mouseHook.Hook += new MouseHook.MouseHookCallback(MouseHook_Hook);
            mouseHook.Install();
            keyboardHook.Hook += new KeyboardHook.KeyboardHookCallback(KeyboardHook_Hook);
            keyboardHook.Install();
            FTA.ScpBus.LoadController();
            connectedControllers = XBoxController.GetConnectedControllers();
            if (connectedControllers.Count() > 0)
            {
                iscontrollerconnected = true;
            }
            else
            {
                iscontrollerconnected = false;
            }
            this.pictureBox1.Dock = DockStyle.Fill;
            EO.WebEngine.BrowserOptions options = new EO.WebEngine.BrowserOptions();
            options.EnableWebSecurity = false;
            EO.WebBrowser.Runtime.DefaultEngineOptions.SetDefaultBrowserOptions(options);
            EO.WebEngine.Engine.Default.Options.AllowProprietaryMediaFormats();
            EO.WebEngine.Engine.Default.Options.SetDefaultBrowserOptions(new EO.WebEngine.BrowserOptions
            {
                EnableWebSecurity = false
            });
            this.webView1.Create(pictureBox1.Handle);
            this.webView1.Engine.Options.AllowProprietaryMediaFormats();
            this.webView1.SetOptions(new EO.WebEngine.BrowserOptions
            {
                EnableWebSecurity = false
            });
            this.webView1.Engine.Options.DisableGPU = false;
            this.webView1.Engine.Options.DisableSpellChecker = true;
            this.webView1.Engine.Options.CustomUserAgent = "Mozilla/5.0 (Windows NT 6.1; WOW64; Trident/7.0; rv:11.0) like Gecko";
            this.webView1.KeyDown += WebView1_KeyDown;
            folderpath = "file:///" + System.Reflection.Assembly.GetEntryAssembly().Location.Replace(@"file:\", "").Replace(Process.GetCurrentProcess().ProcessName + ".exe", "").Replace(@"\", "/").Replace(@"//", "");
            string path = @"fta-script.txt.encrypted";
            ftascript = DecryptFiles(path, "tybtrybrtyertu50727885").Replace("file:///C:/fta/", folderpath);
            path = @"microsoft-keyboard.txt.encrypted";
            microsoftkeyboard = DecryptFiles(path, "tybtrybrtyertu50727885").Replace("file:///C:/fta/", folderpath);
            path = @"microsoft-mouse.txt.encrypted";
            microsoftmouse = DecryptFiles(path, "tybtrybrtyertu50727885").Replace("file:///C:/fta/", folderpath);
            path = @"xbox-controller.txt.encrypted";
            xboxcontroller = DecryptFiles(path, "tybtrybrtyertu50727885").Replace("file:///C:/fta/", folderpath);
            webView1.LoadHtml(ftascript, Application.StartupPath);
            webView1.RegisterJSExtensionFunction("LoadPage", new JSExtInvokeHandler(WebView_JSLoadPage));
            webView1.RegisterJSExtensionFunction("ExecScript", new JSExtInvokeHandler(WebView_JSExecScript));
            webView1.RegisterJSExtensionFunction("getController", new JSExtInvokeHandler(WebView_JSGetController));
            Task.Run(() => GetHtmlScript());
        }
        private void WebView1_KeyDown(object sender, EO.Base.UI.WndMsgEventArgs e)
        {
            Keys key = (Keys)e.WParam;
            OnKeyDown(key);
        }
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            OnKeyDown(e.KeyData);
        }
        private void OnKeyDown(Keys keyData)
        {
            if (keyData == Keys.F1)
            {
                const string message = "• Author: Michaël André Franiatte.\n\r\n\r• Contact: michael.franiatte@gmail.com.\n\r\n\r• Publisher: https://github.com/michaelandrefraniatte.\n\r\n\r• Copyrights: All rights reserved, no permissions granted.\n\r\n\r• License: Not open source, not free of charge to use.";
                const string caption = "About";
                MessageBox.Show(message, caption, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            if (keyData == Keys.Escape)
            {
                this.Close();
            }
        }
        private void MouseHook_Hook(MouseHook.MSLLHOOKSTRUCT mouseStruct) { }
        private void KeyboardHook_Hook(KeyboardHook.KBDLLHOOKSTRUCT keyboardStruct) { }
        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            scriptrunning = false;
            System.Threading.Thread.Sleep(100);
            mouseHook.Hook -= new MouseHook.MouseHookCallback(MouseHook_Hook);
            mouseHook.Uninstall();
            keyboardHook.Hook -= new KeyboardHook.KeyboardHookCallback(KeyboardHook_Hook);
            keyboardHook.Uninstall();
            FTA.ScpBus.UnLoadController();
            webView1.Dispose();
            threadstart = new ThreadStart(ThreadDisconnectClose);
            thread = new Thread(threadstart);
            thread.Start();
        }
        void WebView_JSLoadPage(object sender, JSExtInvokeArgs e)
        {
            pagename = e.Arguments[0] as string;
            if (pagename == "fta-script.txt")
            {
                webView1.LoadHtml(ftascript, Application.StartupPath);
                Task.Run(() => OpenScript(htmlscript));
                Task.Run(() => SetRunScript());
            }
            if (pagename == "microsoft-keyboard.txt")
            {
                webView1.LoadHtml(microsoftkeyboard, Application.StartupPath);
            }
            if (pagename == "microsoft-mouse.txt")
            {
                webView1.LoadHtml(microsoftmouse, Application.StartupPath);
            }
            if (pagename == "xbox-controller.txt")
            {
                webView1.LoadHtml(xboxcontroller, Application.StartupPath);
            }
        }
        private void TraverseElementTree(JSObject root, Action<JSObject> action)
        {
            action(root);
            foreach (var child in root.GetChildren())
                TraverseElementTree(child, action);
        }
        [STAThread]
        void WebView_JSExecScript(object sender, JSExtInvokeArgs e)
        {
            string command = e.Arguments[0] as string;
            if (command == "Run Script" & !disguardscriptrunning)
            {
                if (htmlscript != "Script Encrypted...")
                {
                    htmlscript = htmlscripttemp;
                    stringscript = HtmlToPlainText(htmlscript);
                }
                Task.Run(() => RunScript());
            }
            if (command == "Test Script" & !disguardscriptrunning)
            {
                if (scriptrunning)
                {
                    Task.Run(() => StopScript());
                    System.Threading.Thread.Sleep(100);
                }
                if (htmlscript != "Script Encrypted...")
                {
                    htmlscript = htmlscripttemp;
                    stringscript = HtmlToPlainText(htmlscript);
                }
                Task.Run(() => TestScript());
            }
            if (command == "Open Script" & !disguardscriptrunning)
            {
                if (scriptrunning)
                {
                    Task.Run(() => StopScript());
                    System.Threading.Thread.Sleep(100);
                }
                Thread newThread = new Thread(new ThreadStart(showOpenFileDialog));
                newThread.SetApartmentState(ApartmentState.STA);
                newThread.Start();
            }
            if (command == "Save Script" & !disguardscriptrunning)
            {
                if (scriptrunning)
                {
                    Task.Run(() => StopScript());
                    System.Threading.Thread.Sleep(100);
                }
                Thread newThread = new Thread(new ThreadStart(showSaveFileDialog));
                newThread.SetApartmentState(ApartmentState.STA);
                newThread.Start();
            }
            if (command == "Save Script As" & !disguardscriptrunning)
            {
                if (scriptrunning)
                {
                    Task.Run(() => StopScript());
                    System.Threading.Thread.Sleep(100);
                }
                Thread newThread = new Thread(new ThreadStart(showSaveFileAsDialog));
                newThread.SetApartmentState(ApartmentState.STA);
                newThread.Start();
            }
            if (command == "Connect Controllers" & !disguardscriptrunning)
            {
                if (scriptrunning)
                {
                    Task.Run(() => StopScript());
                    System.Threading.Thread.Sleep(100);
                }
                threadstart = new ThreadStart(ThreadConnect);
                thread = new Thread(threadstart);
                thread.Start();
            }
            if (command == "Disconnect Controllers" & !disguardscriptrunning)
            {
                if (scriptrunning)
                {
                    Task.Run(() => StopScript());
                    System.Threading.Thread.Sleep(100);
                }
                threadstart = new ThreadStart(ThreadDisconnect);
                thread = new Thread(threadstart);
                thread.Start();
            }
        }
        public void showOpenFileDialog()
        {
            OpenFileDialog op = new OpenFileDialog();
            op.Filter = "All Files(*.*)|*.*";
            if (op.ShowDialog() == DialogResult.OK)
            {
                if (!op.FileName.EndsWith(".encrypted"))
                {
                    openpath = op.FileName;
                    string readText = File.ReadAllText(op.FileName);
                    Task.Run(() => OpenScript(readText));
                }
                else
                {
                    Task.Run(() => OpenScript("Script Encrypted..."));
                    DecryptFile(op.FileName, "tybtrybrtyertu50727885");
                }
            }
            disguardscriptrunning = false;
        }
        public void showSaveFileDialog()
        {
            if (openpath != "")
            {
                File.WriteAllText(openpath, htmlscript);
                EncryptFile(openpath, openpath + ".encrypted", "tybtrybrtyertu50727885");
            }
            else
            {
                SaveFileDialog op = new SaveFileDialog();
                op.Filter = "All Files(*.*)|*.*";
                if (op.ShowDialog() == DialogResult.OK)
                {
                    openpath = op.FileName;
                    File.WriteAllText(op.FileName, htmlscript);
                    EncryptFile(op.FileName, op.FileName + ".encrypted", "tybtrybrtyertu50727885");
                }
            }
            disguardscriptrunning = false;
        }
        public void showSaveFileAsDialog()
        {
            SaveFileDialog op = new SaveFileDialog();
            op.Filter = "All Files(*.*)|*.*";
            if (op.ShowDialog() == DialogResult.OK)
            {
                openpath = op.FileName;
                File.WriteAllText(op.FileName, htmlscript);
                EncryptFile(op.FileName, op.FileName + ".encrypted", "tybtrybrtyertu50727885");
            }
            disguardscriptrunning = false;
        }
        void WebView_JSGetController(object sender, JSExtInvokeArgs e)
        {
            try
            {
                Controller_A = Convert.ToBoolean(e.Arguments[0] as string == "1" ? true : false);
                Controller_B = Convert.ToBoolean(e.Arguments[1] as string == "1" ? true : false);
                Controller_X = Convert.ToBoolean(e.Arguments[2] as string == "1" ? true : false);
                Controller_Y = Convert.ToBoolean(e.Arguments[3] as string == "1" ? true : false);
                Controller_LB = Convert.ToBoolean(e.Arguments[4] as string == "1" ? true : false);
                Controller_RB = Convert.ToBoolean(e.Arguments[5] as string == "1" ? true : false);
                Controller_LT = Convert.ToBoolean(e.Arguments[6] as string == "1" ? true : false);
                Controller_RT = Convert.ToBoolean(e.Arguments[7] as string == "1" ? true : false);
                Controller_MAP = Convert.ToBoolean(e.Arguments[8] as string == "1" ? true : false);
                Controller_MENU = Convert.ToBoolean(e.Arguments[9] as string == "1" ? true : false);
                Controller_LSTICK = Convert.ToBoolean(e.Arguments[10] as string == "1" ? true : false);
                Controller_RSTICK = Convert.ToBoolean(e.Arguments[11] as string == "1" ? true : false);
                Controller_DU = Convert.ToBoolean(e.Arguments[12] as string == "1" ? true : false);
                Controller_DD = Convert.ToBoolean(e.Arguments[13] as string == "1" ? true : false);
                Controller_DL = Convert.ToBoolean(e.Arguments[14] as string == "1" ? true : false);
                Controller_DR = Convert.ToBoolean(e.Arguments[15] as string == "1" ? true : false);
                Controller_XBOX = Convert.ToBoolean(e.Arguments[16] as string == "1" ? true : false);
                Controller_LX = Convert.ToDouble(e.Arguments[17]);
                Controller_LY = Convert.ToDouble(e.Arguments[18]);
                Controller_RX = Convert.ToDouble(e.Arguments[19]);
                Controller_RY = Convert.ToDouble(e.Arguments[20]);
            }
            catch { }
        }
        private void ThreadConnect()
        {
            try
            {
                SetConnectControllers();
                if (!wiimoteconnected)
                    connectingWiimote();
                if (!joyconleftconnected)
                    connectingJoyconLeft();
                if (!joyconrightconnected)
                    connectingJoyconRight();
                SetConnectControllers();
                disguardscriptrunning = false;
            }
            catch { }
        }
        private void ThreadDisconnect()
        {
            try
            {
                SetDisconnectControllers();
                if (wiimoteconnected)
                    FormCloseWiimoteNunchuck();
                if (joyconleftconnected)
                    FormCloseLeft();
                if (joyconrightconnected)
                    FormCloseRight();
                SetDisconnectControllers();
                disguardscriptrunning = false;
            }
            catch { }
        }
        private void ThreadDisconnectClose()
        {
            try
            {
                if (wiimoteconnected)
                    FormCloseWiimoteNunchuck();
                if (joyconleftconnected)
                    FormCloseLeft();
                if (joyconrightconnected)
                    FormCloseRight();
            }
            catch { }
        }
        public void SetConnectControllers()
        {
            try
            {
                document = webView1.GetDOMWindow().document;
                TraverseElementTree(document, (currentElement) =>
                {
                    string id = currentElement.GetID();
                    if (id.StartsWith("connectcontrollers"))
                    {
                        if (currentElement.GetValue() == "Connecting...")
                        {
                            currentElement.SetValue("Connect Controllers");
                        }
                        else
                        {
                            if (currentElement.GetValue() == "Connect Controllers")
                            {
                                currentElement.SetValue("Connecting...");
                            }
                        }
                    }
                });
            }
            catch { }
        }
        public void SetDisconnectControllers()
        {
            try
            {
                document = webView1.GetDOMWindow().document;
                TraverseElementTree(document, (currentElement) =>
                {
                    string id = currentElement.GetID();
                    if (id.StartsWith("disconnectcontrollers"))
                    {
                        if (currentElement.GetValue() == "Disconnecting...")
                        {
                            currentElement.SetValue("Disconnect Controllers");
                        }
                        else
                        {
                            if (currentElement.GetValue() == "Disconnect Controllers")
                            {
                                currentElement.SetValue("Disconnecting...");
                            }
                        }
                    }
                });
            }
            catch { }
        }
        public void OpenScript(string readText)
        {
            try
            {
                document = webView1.GetDOMWindow().document;
                TraverseElementTree(document, (currentElement) =>
                {
                    string id = currentElement.GetID();
                    if (id.StartsWith("test-autocomplete-textarea") & id.EndsWith("test-autocomplete-textarea"))
                    {
                        currentElement.SetHtml(readText);
                    }
                });
            }
            catch { }
        }
        public void GetHtmlScript()
        {
            for (; ; )
            {
                try
                {
                    EO.WebBrowser.DOM.Element script = webView1.GetDOMWindow().document.getElementById("test-autocomplete-textarea");
                    htmlscripttemp = script.GetHtml();
                    if (htmlscripttemp != "")
                        htmlscript = htmlscripttemp;
                }
                catch { }
                System.Threading.Thread.Sleep(100);
            }
        }
        public void SetRunScript()
        {
            try
            {
                document = webView1.GetDOMWindow().document;
                TraverseElementTree(document, (currentElement) =>
                {
                    string id = currentElement.GetID();
                    if (id.StartsWith("runscript"))
                    {
                        if (scriptrunning)
                        {
                            currentElement.SetValue("Stop Script");
                        }
                        else
                        {
                            currentElement.SetValue("Run Script");
                        }
                    }
                });
            }
            catch { }
        }
        public void RunScript()
        {
            try
            {
                document = webView1.GetDOMWindow().document;
                TraverseElementTree(document, (currentElement) =>
                {
                    string id = currentElement.GetID();
                    if (id.StartsWith("runscript"))
                    {
                        if (currentElement.GetValue() == "Stop Script")
                        {
                            currentElement.SetValue("Run Script");
                            scriptrunning = false;
                        }
                        else
                        {
                            if (currentElement.GetValue() == "Run Script")
                            {
                                currentElement.SetValue("Stop Script");
                                scriptrunning = true;
                                Task.Run(() => ProcessScript());
                            }
                        }
                    }
                });
            }
            catch { }
        }
        public void StopScript()
        {
            scriptrunning = false;
            disguardscriptrunning = true;
            try
            {
                document = webView1.GetDOMWindow().document;
                TraverseElementTree(document, (currentElement) =>
                {
                    string id = currentElement.GetID();
                    if (id.StartsWith("runscript"))
                    {
                        if (currentElement.GetValue() == "Stop Script")
                        {
                            currentElement.SetValue("Run Script");
                        }
                    }
                });
            }
            catch { }
        }
        public static void EncryptFile(string inputFile, string outputFile, string password)
        {
            byte[] salt = new byte[8];
            using (var rng = new RNGCryptoServiceProvider())
                rng.GetBytes(salt);
            using (var pbkdf = new Rfc2898DeriveBytes(password, salt))
            using (var aes = new RijndaelManaged())
            using (var encryptor = aes.CreateEncryptor(pbkdf.GetBytes(aes.KeySize / 8), pbkdf.GetBytes(aes.BlockSize / 8)))
            using (var input = File.OpenRead(inputFile))
            using (var output = File.Create(outputFile))
            {
                output.Write(salt, 0, salt.Length);
                using (var cs = new CryptoStream(output, encryptor, CryptoStreamMode.Write))
                    input.CopyTo(cs);
            }
        }
        public static void DecryptFile(string inputFile, string password)
        {
            using (var input = File.OpenRead(inputFile))
            {
                byte[] salt = new byte[8];
                input.Read(salt, 0, salt.Length);
                using (var decryptedStream = new MemoryStream())
                using (var pbkdf = new Rfc2898DeriveBytes(password, salt))
                using (var aes = new RijndaelManaged())
                using (var decryptor = aes.CreateDecryptor(pbkdf.GetBytes(aes.KeySize / 8), pbkdf.GetBytes(aes.BlockSize / 8)))
                using (var cs = new CryptoStream(input, decryptor, CryptoStreamMode.Read))
                {
                    string contents;
                    int data;
                    while ((data = cs.ReadByte()) != -1)
                        decryptedStream.WriteByte((byte)data);
                    decryptedStream.Position = 0;
                    using (StreamReader sr = new StreamReader(decryptedStream))
                        contents = sr.ReadToEnd();
                    decryptedStream.Flush();
                    stringscript = HtmlToPlainText(contents);
                }
            }
        }
        public static string DecryptFiles(string inputFile, string password)
        {
            using (var input = File.OpenRead(inputFile))
            {
                byte[] salt = new byte[8];
                input.Read(salt, 0, salt.Length);
                using (var decryptedStream = new MemoryStream())
                using (var pbkdf = new Rfc2898DeriveBytes(password, salt))
                using (var aes = new RijndaelManaged())
                using (var decryptor = aes.CreateDecryptor(pbkdf.GetBytes(aes.KeySize / 8), pbkdf.GetBytes(aes.BlockSize / 8)))
                using (var cs = new CryptoStream(input, decryptor, CryptoStreamMode.Read))
                {
                    string contents;
                    int data;
                    while ((data = cs.ReadByte()) != -1)
                        decryptedStream.WriteByte((byte)data);
                    decryptedStream.Position = 0;
                    using (StreamReader sr = new StreamReader(decryptedStream))
                        contents = sr.ReadToEnd();
                    decryptedStream.Flush();
                    return contents;
                }
            }
        }
        private static string HtmlToPlainText(string html)
        {
            HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
            doc.LoadHtml(html);
            StringWriter sw = new StringWriter();
            ConvertTo(doc.DocumentNode, sw);
            sw.Flush();
            return sw.ToString();
        }
        public static int CountWords(string plainText)
        {
            return !String.IsNullOrEmpty(plainText) ? plainText.Split(' ', '\n').Length : 0;
        }
        public static string Cut(string text, int length)
        {
            if (!String.IsNullOrEmpty(text) && text.Length > length)
            {
                text = text.Substring(0, length - 4) + " ...";
            }
            return text;
        }
        private static void ConvertContentTo(HtmlNode node, TextWriter outText)
        {
            foreach (HtmlNode subnode in node.ChildNodes)
            {
                ConvertTo(subnode, outText);
            }
        }
        private static void ConvertTo(HtmlNode node, TextWriter outText)
        {
            string html;
            switch (node.NodeType)
            {
                case HtmlNodeType.Comment:// don't output comments
                    break;
                case HtmlNodeType.Document:
                    ConvertContentTo(node, outText);
                    break;
                case HtmlNodeType.Text:
                    string parentName = node.ParentNode.Name;// script and style must not be output
                    if ((parentName == "script") || (parentName == "style"))
                        break;
                    html = ((HtmlTextNode)node).Text;// get text
                    if (HtmlNode.IsOverlappedClosingElement(html))// is it in fact a special closing node output as text?
                        break;
                    if (html.Trim().Length > 0)
                    {
                        outText.Write(HtmlEntity.DeEntitize(html));// check the text is meaningful and not a bunch of whitespaces
                    }
                    break;
                case HtmlNodeType.Element:
                    switch (node.Name)
                    {
                        case "p":
                            outText.Write("\r\n");// treat paragraphs as crlf
                            break;
                        case "br":
                            outText.Write("\r\n");
                            break;
                    }
                    if (node.HasChildNodes)
                    {
                        ConvertContentTo(node, outText);
                    }
                    break;
            }
        }
        public void TestScript()
        {
            try
            {
                string finalcode = code.Replace("funct_driver", stringscript);
                parameters = new System.CodeDom.Compiler.CompilerParameters();
                parameters.GenerateExecutable = false;
                parameters.GenerateInMemory = true;
                parameters.ReferencedAssemblies.Add("System.Windows.Forms.dll");
                parameters.ReferencedAssemblies.Add("System.Drawing.dll");
                provider = new Microsoft.CSharp.CSharpCodeProvider();
                results = provider.CompileAssemblyFromSource(parameters, finalcode);
                if (results.Errors.HasErrors)
                {
                    StringBuilder sb = new StringBuilder();
                    foreach (System.CodeDom.Compiler.CompilerError error in results.Errors)
                    {
                        sb.AppendLine(String.Format("Error ({0}) : {1}", error.ErrorNumber, error.ErrorText));
                    }
                    MessageBox.Show("Script Error :\n\r" + sb.ToString());
                    disguardscriptrunning = false;
                    return;
                }
                else
                {
                    MessageBox.Show("Script Ok.");
                }
                assembly = results.CompiledAssembly;
                program = assembly.GetType("StringToCode.FooClass");
                obj = Activator.CreateInstance(program);
                object[] val = (object[])program.InvokeMember("Main", BindingFlags.Default | BindingFlags.InvokeMethod, null, obj, new object[] { width, height, MouseHookX, MouseHookY, MouseHookButtonX1, MouseHookButtonX2, MouseHookWheelUp, MouseHookWheelDown, MouseHookRightButton, MouseHookLeftButton, MouseHookMiddleButton, MouseHookXButton, Key_LBUTTON, Key_RBUTTON, Key_CANCEL, Key_MBUTTON, Key_XBUTTON1, Key_XBUTTON2, Key_BACK, Key_Tab, Key_CLEAR, Key_Return, Key_SHIFT, Key_CONTROL, Key_MENU, Key_PAUSE, Key_CAPITAL, Key_KANA, Key_HANGEUL, Key_HANGUL, Key_JUNJA, Key_FINAL, Key_HANJA, Key_KANJI, Key_Escape, Key_CONVERT, Key_NONCONVERT, Key_ACCEPT, Key_MODECHANGE, Key_Space, Key_PRIOR, Key_NEXT, Key_END, Key_HOME, Key_LEFT, Key_UP, Key_RIGHT, Key_DOWN, Key_SELECT, Key_PRINT, Key_EXECUTE, Key_SNAPSHOT, Key_INSERT, Key_DELETE, Key_HELP, Key_APOSTROPHE, Key_0, Key_1, Key_2, Key_3, Key_4, Key_5, Key_6, Key_7, Key_8, Key_9, Key_A, Key_B, Key_C, Key_D, Key_E, Key_F, Key_G, Key_H, Key_I, Key_J, Key_K, Key_L, Key_M, Key_N, Key_O, Key_P, Key_Q, Key_R, Key_S, Key_T, Key_U, Key_V, Key_W, Key_X, Key_Y, Key_Z, Key_LWIN, Key_RWIN, Key_APPS, Key_SLEEP, Key_NUMPAD0, Key_NUMPAD1, Key_NUMPAD2, Key_NUMPAD3, Key_NUMPAD4, Key_NUMPAD5, Key_NUMPAD6, Key_NUMPAD7, Key_NUMPAD8, Key_NUMPAD9, Key_MULTIPLY, Key_ADD, Key_SEPARATOR, Key_SUBTRACT, Key_DECIMAL, Key_DIVIDE, Key_F1, Key_F2, Key_F3, Key_F4, Key_F5, Key_F6, Key_F7, Key_F8, Key_F9, Key_F10, Key_F11, Key_F12, Key_F13, Key_F14, Key_F15, Key_F16, Key_F17, Key_F18, Key_F19, Key_F20, Key_F21, Key_F22, Key_F23, Key_F24, Key_NUMLOCK, Key_SCROLL, Key_LeftShift, Key_RightShift, Key_LeftControl, Key_RightControl, Key_LMENU, Key_RMENU, Key_BROWSER_BACK, Key_BROWSER_FORWARD, Key_BROWSER_REFRESH, Key_BROWSER_STOP, Key_BROWSER_SEARCH, Key_BROWSER_FAVORITES, Key_BROWSER_HOME, Key_VOLUME_MUTE, Key_VOLUME_DOWN, Key_VOLUME_UP, Key_MEDIA_NEXT_TRACK, Key_MEDIA_PREV_TRACK, Key_MEDIA_STOP, Key_MEDIA_PLAY_PAUSE, Key_LAUNCH_MAIL, Key_LAUNCH_MEDIA_SELECT, Key_LAUNCH_APP1, Key_LAUNCH_APP2, Key_OEM_1, Key_OEM_PLUS, Key_OEM_COMMA, Key_OEM_MINUS, Key_OEM_PERIOD, Key_OEM_2, Key_OEM_3, Key_OEM_4, Key_OEM_5, Key_OEM_6, Key_OEM_7, Key_OEM_8, Key_OEM_102, Key_PROCESSKEY, Key_PACKET, Key_ATTN, Key_CRSEL, Key_EXSEL, Key_EREOF, Key_PLAY, Key_ZOOM, Key_NONAME, Key_PA1, Key_OEM_CLEAR, irx, iry, mWSButtonStateA, mWSButtonStateB, mWSButtonStateMinus, mWSButtonStateHome, mWSButtonStatePlus, mWSButtonStateOne, mWSButtonStateTwo, mWSButtonStateUp, mWSButtonStateDown, mWSButtonStateLeft, mWSButtonStateRight, mWSRawValuesX, mWSRawValuesY, mWSRawValuesZ, mWSNunchuckStateRawJoystickX, mWSNunchuckStateRawJoystickY, mWSNunchuckStateRawValuesX, mWSNunchuckStateRawValuesY, mWSNunchuckStateRawValuesZ, mWSNunchuckStateC, mWSNunchuckStateZ, stickRight, RightButtonSHOULDER_1, RightButtonSHOULDER_2, RightButtonSR, RightButtonSL, RightButtonDPAD_DOWN, RightButtonDPAD_RIGHT, RightButtonDPAD_UP, RightButtonDPAD_LEFT, RightButtonPLUS, RightButtonHOME, RightButtonSTICK, RightButtonACC, RightButtonSPA, RightRollLeft, RightRollRight, RightAccelX, RightAccelY, RightGyroX, RightGyroY, stickLeft, LeftButtonSHOULDER_1, LeftButtonSHOULDER_2, LeftButtonSR, LeftButtonSL, LeftButtonDPAD_DOWN, LeftButtonDPAD_RIGHT, LeftButtonDPAD_UP, LeftButtonDPAD_LEFT, LeftButtonMINUS, LeftButtonCAPTURE, LeftButtonSTICK, LeftButtonACC, LeftButtonSMA, LeftRollLeft, LeftRollRight, LeftAccelX, LeftAccelY, LeftGyroX, LeftGyroY, Controller_A, Controller_B, Controller_X, Controller_Y, Controller_LB, Controller_RB, Controller_LT, Controller_RT, Controller_MAP, Controller_MENU, Controller_LSTICK, Controller_RSTICK, Controller_DU, Controller_DD, Controller_DL, Controller_DR, Controller_XBOX, Controller_LX, Controller_LY, Controller_RX, Controller_RY, TextFromSpeech, ButtonAPressed, ButtonBPressed, ButtonXPressed, ButtonYPressed, ButtonStartPressed, ButtonBackPressed, ButtonDownPressed, ButtonUpPressed, ButtonLeftPressed, ButtonRightPressed, ButtonShoulderLeftPressed, ButtonShoulderRightPressed, ThumbpadLeftPressed, ThumbpadRightPressed, TriggerLeftPressed, TriggerRightPressed, TriggerLeftPressThreshold, TriggerRightPressThreshold, TriggerLeftPosition, TriggerRightPosition, ThumbLeftX, ThumbLeftY, ThumbRightX, ThumbRightY });
                UsersAllowedList = (string[])val[0];
                checkingusername = false;
                if (UsersAllowedList.Length == 0)
                {
                    checkingusername = true;
                }
                else
                {
                    foreach (string userallowed in UsersAllowedList)
                    {
                        if (username == userallowed)
                        {
                            checkingusername = true;
                            break;
                        }
                        System.Threading.Thread.Sleep(1);
                    }
                }
                if (!checkingusername)
                {
                    MessageBox.Show("You are not allowed to run this script.");
                }
                disguardscriptrunning = false;
            }
            catch { }
        }
        private void ProcessScript()
        {
            try
            {
                string finalcode = code.Replace("funct_driver", stringscript);
                parameters = new System.CodeDom.Compiler.CompilerParameters();
                parameters.GenerateExecutable = false;
                parameters.GenerateInMemory = true;
                parameters.ReferencedAssemblies.Add("System.Windows.Forms.dll");
                parameters.ReferencedAssemblies.Add("System.Drawing.dll");
                provider = new Microsoft.CSharp.CSharpCodeProvider();
                results = provider.CompileAssemblyFromSource(parameters, finalcode);
                if (results.Errors.HasErrors)
                {
                    StringBuilder sb = new StringBuilder();
                    foreach (System.CodeDom.Compiler.CompilerError error in results.Errors)
                    {
                        sb.AppendLine(String.Format("Error ({0}) : {1}", error.ErrorNumber, error.ErrorText));
                    }
                    MessageBox.Show("Script Error :\n\r" + sb.ToString());
                    return;
                }
                assembly = results.CompiledAssembly;
                program = assembly.GetType("StringToCode.FooClass");
                obj = Activator.CreateInstance(program);
                object[] val = (object[])program.InvokeMember("Main", BindingFlags.Default | BindingFlags.InvokeMethod, null, obj, new object[] { width, height, MouseHookX, MouseHookY, MouseHookButtonX1, MouseHookButtonX2, MouseHookWheelUp, MouseHookWheelDown, MouseHookRightButton, MouseHookLeftButton, MouseHookMiddleButton, MouseHookXButton, Key_LBUTTON, Key_RBUTTON, Key_CANCEL, Key_MBUTTON, Key_XBUTTON1, Key_XBUTTON2, Key_BACK, Key_Tab, Key_CLEAR, Key_Return, Key_SHIFT, Key_CONTROL, Key_MENU, Key_PAUSE, Key_CAPITAL, Key_KANA, Key_HANGEUL, Key_HANGUL, Key_JUNJA, Key_FINAL, Key_HANJA, Key_KANJI, Key_Escape, Key_CONVERT, Key_NONCONVERT, Key_ACCEPT, Key_MODECHANGE, Key_Space, Key_PRIOR, Key_NEXT, Key_END, Key_HOME, Key_LEFT, Key_UP, Key_RIGHT, Key_DOWN, Key_SELECT, Key_PRINT, Key_EXECUTE, Key_SNAPSHOT, Key_INSERT, Key_DELETE, Key_HELP, Key_APOSTROPHE, Key_0, Key_1, Key_2, Key_3, Key_4, Key_5, Key_6, Key_7, Key_8, Key_9, Key_A, Key_B, Key_C, Key_D, Key_E, Key_F, Key_G, Key_H, Key_I, Key_J, Key_K, Key_L, Key_M, Key_N, Key_O, Key_P, Key_Q, Key_R, Key_S, Key_T, Key_U, Key_V, Key_W, Key_X, Key_Y, Key_Z, Key_LWIN, Key_RWIN, Key_APPS, Key_SLEEP, Key_NUMPAD0, Key_NUMPAD1, Key_NUMPAD2, Key_NUMPAD3, Key_NUMPAD4, Key_NUMPAD5, Key_NUMPAD6, Key_NUMPAD7, Key_NUMPAD8, Key_NUMPAD9, Key_MULTIPLY, Key_ADD, Key_SEPARATOR, Key_SUBTRACT, Key_DECIMAL, Key_DIVIDE, Key_F1, Key_F2, Key_F3, Key_F4, Key_F5, Key_F6, Key_F7, Key_F8, Key_F9, Key_F10, Key_F11, Key_F12, Key_F13, Key_F14, Key_F15, Key_F16, Key_F17, Key_F18, Key_F19, Key_F20, Key_F21, Key_F22, Key_F23, Key_F24, Key_NUMLOCK, Key_SCROLL, Key_LeftShift, Key_RightShift, Key_LeftControl, Key_RightControl, Key_LMENU, Key_RMENU, Key_BROWSER_BACK, Key_BROWSER_FORWARD, Key_BROWSER_REFRESH, Key_BROWSER_STOP, Key_BROWSER_SEARCH, Key_BROWSER_FAVORITES, Key_BROWSER_HOME, Key_VOLUME_MUTE, Key_VOLUME_DOWN, Key_VOLUME_UP, Key_MEDIA_NEXT_TRACK, Key_MEDIA_PREV_TRACK, Key_MEDIA_STOP, Key_MEDIA_PLAY_PAUSE, Key_LAUNCH_MAIL, Key_LAUNCH_MEDIA_SELECT, Key_LAUNCH_APP1, Key_LAUNCH_APP2, Key_OEM_1, Key_OEM_PLUS, Key_OEM_COMMA, Key_OEM_MINUS, Key_OEM_PERIOD, Key_OEM_2, Key_OEM_3, Key_OEM_4, Key_OEM_5, Key_OEM_6, Key_OEM_7, Key_OEM_8, Key_OEM_102, Key_PROCESSKEY, Key_PACKET, Key_ATTN, Key_CRSEL, Key_EXSEL, Key_EREOF, Key_PLAY, Key_ZOOM, Key_NONAME, Key_PA1, Key_OEM_CLEAR, irx, iry, mWSButtonStateA, mWSButtonStateB, mWSButtonStateMinus, mWSButtonStateHome, mWSButtonStatePlus, mWSButtonStateOne, mWSButtonStateTwo, mWSButtonStateUp, mWSButtonStateDown, mWSButtonStateLeft, mWSButtonStateRight, mWSRawValuesX, mWSRawValuesY, mWSRawValuesZ, mWSNunchuckStateRawJoystickX, mWSNunchuckStateRawJoystickY, mWSNunchuckStateRawValuesX, mWSNunchuckStateRawValuesY, mWSNunchuckStateRawValuesZ, mWSNunchuckStateC, mWSNunchuckStateZ, stickRight, RightButtonSHOULDER_1, RightButtonSHOULDER_2, RightButtonSR, RightButtonSL, RightButtonDPAD_DOWN, RightButtonDPAD_RIGHT, RightButtonDPAD_UP, RightButtonDPAD_LEFT, RightButtonPLUS, RightButtonHOME, RightButtonSTICK, RightButtonACC, RightButtonSPA, RightRollLeft, RightRollRight, RightAccelX, RightAccelY, RightGyroX, RightGyroY, stickLeft, LeftButtonSHOULDER_1, LeftButtonSHOULDER_2, LeftButtonSR, LeftButtonSL, LeftButtonDPAD_DOWN, LeftButtonDPAD_RIGHT, LeftButtonDPAD_UP, LeftButtonDPAD_LEFT, LeftButtonMINUS, LeftButtonCAPTURE, LeftButtonSTICK, LeftButtonACC, LeftButtonSMA, LeftRollLeft, LeftRollRight, LeftAccelX, LeftAccelY, LeftGyroX, LeftGyroY, Controller_A, Controller_B, Controller_X, Controller_Y, Controller_LB, Controller_RB, Controller_LT, Controller_RT, Controller_MAP, Controller_MENU, Controller_LSTICK, Controller_RSTICK, Controller_DU, Controller_DD, Controller_DL, Controller_DR, Controller_XBOX, Controller_LX, Controller_LY, Controller_RX, Controller_RY, TextFromSpeech, ButtonAPressed, ButtonBPressed, ButtonXPressed, ButtonYPressed, ButtonStartPressed, ButtonBackPressed, ButtonDownPressed, ButtonUpPressed, ButtonLeftPressed, ButtonRightPressed, ButtonShoulderLeftPressed, ButtonShoulderRightPressed, ThumbpadLeftPressed, ThumbpadRightPressed, TriggerLeftPressed, TriggerRightPressed, TriggerLeftPressThreshold, TriggerRightPressThreshold, TriggerLeftPosition, TriggerRightPosition, ThumbLeftX, ThumbLeftY, ThumbRightX, ThumbRightY });
                UsersAllowedList = (string[])val[0];
                SpeechToText = (string[])val[172];
                checkingusername = false;
                if (UsersAllowedList.Length == 0)
                {
                    checkingusername = true;
                }
                else
                {
                    foreach (string userallowed in UsersAllowedList)
                    {
                        if (username == userallowed)
                        {
                            checkingusername = true;
                            break;
                        }
                        System.Threading.Thread.Sleep(1);
                    }
                }
                if (SpeechToText.Length != 0)
                {
                    microphone = Ozeki.Media.Microphone.GetDefaultDevice();
                    connector = new Ozeki.Media.MediaConnector();
                    SetupSpeechToText(SpeechToText);
                }
                if (checkingusername)
                {
                    if (wiimoteconnected)
                        Task.Run(() => WiimoteNunchuckData());
                    if (joyconleftconnected)
                        Task.Run(() => LeftJoyconData());
                    if (joyconrightconnected)
                        Task.Run(() => RightJoyconData());
                    if (wiimoteconnected | joyconleftconnected | joyconrightconnected)
                        System.Threading.Thread.Sleep(3000);
                    if (wiimoteconnected)
                        InitWiimoteNunchuck();
                    if (joyconleftconnected)
                        InitLeftJoycon();
                    if (joyconrightconnected)
                        InitRightJoycon();
                    Getstate = false;
                    sleeptime = 1;
                    while (scriptrunning)
                    {
                        if (iscontrollerconnected)
                        {
                            ControllerProcess();
                        }
                        KeyboardHookProcessButtons();
                        valchanged(0, Key_ADD);
                        if (wd[0] == 1 & !Getstate)
                        {
                            width = System.Windows.Forms.Screen.PrimaryScreen.Bounds.Width;
                            height = System.Windows.Forms.Screen.PrimaryScreen.Bounds.Height;
                            Getstate = true;
                        }
                        else
                        {
                            if (wd[0] == 1 & Getstate)
                            {
                                Getstate = false;
                            }
                        }
                        MouseHookProcessButtons();
                        if (wiimoteconnected)
                            ProcessButtonsWiimoteNunchuck();
                        if (joyconleftconnected)
                            ProcessButtonsLeftJoycon();
                        if (joyconrightconnected)
                            ProcessButtonsRightJoycon();
                        val = (object[])program.InvokeMember("Main", BindingFlags.Default | BindingFlags.InvokeMethod, null, obj, new object[] { width, height, MouseHookX, MouseHookY, MouseHookButtonX1, MouseHookButtonX2, MouseHookWheelUp, MouseHookWheelDown, MouseHookRightButton, MouseHookLeftButton, MouseHookMiddleButton, MouseHookXButton, Key_LBUTTON, Key_RBUTTON, Key_CANCEL, Key_MBUTTON, Key_XBUTTON1, Key_XBUTTON2, Key_BACK, Key_Tab, Key_CLEAR, Key_Return, Key_SHIFT, Key_CONTROL, Key_MENU, Key_PAUSE, Key_CAPITAL, Key_KANA, Key_HANGEUL, Key_HANGUL, Key_JUNJA, Key_FINAL, Key_HANJA, Key_KANJI, Key_Escape, Key_CONVERT, Key_NONCONVERT, Key_ACCEPT, Key_MODECHANGE, Key_Space, Key_PRIOR, Key_NEXT, Key_END, Key_HOME, Key_LEFT, Key_UP, Key_RIGHT, Key_DOWN, Key_SELECT, Key_PRINT, Key_EXECUTE, Key_SNAPSHOT, Key_INSERT, Key_DELETE, Key_HELP, Key_APOSTROPHE, Key_0, Key_1, Key_2, Key_3, Key_4, Key_5, Key_6, Key_7, Key_8, Key_9, Key_A, Key_B, Key_C, Key_D, Key_E, Key_F, Key_G, Key_H, Key_I, Key_J, Key_K, Key_L, Key_M, Key_N, Key_O, Key_P, Key_Q, Key_R, Key_S, Key_T, Key_U, Key_V, Key_W, Key_X, Key_Y, Key_Z, Key_LWIN, Key_RWIN, Key_APPS, Key_SLEEP, Key_NUMPAD0, Key_NUMPAD1, Key_NUMPAD2, Key_NUMPAD3, Key_NUMPAD4, Key_NUMPAD5, Key_NUMPAD6, Key_NUMPAD7, Key_NUMPAD8, Key_NUMPAD9, Key_MULTIPLY, Key_ADD, Key_SEPARATOR, Key_SUBTRACT, Key_DECIMAL, Key_DIVIDE, Key_F1, Key_F2, Key_F3, Key_F4, Key_F5, Key_F6, Key_F7, Key_F8, Key_F9, Key_F10, Key_F11, Key_F12, Key_F13, Key_F14, Key_F15, Key_F16, Key_F17, Key_F18, Key_F19, Key_F20, Key_F21, Key_F22, Key_F23, Key_F24, Key_NUMLOCK, Key_SCROLL, Key_LeftShift, Key_RightShift, Key_LeftControl, Key_RightControl, Key_LMENU, Key_RMENU, Key_BROWSER_BACK, Key_BROWSER_FORWARD, Key_BROWSER_REFRESH, Key_BROWSER_STOP, Key_BROWSER_SEARCH, Key_BROWSER_FAVORITES, Key_BROWSER_HOME, Key_VOLUME_MUTE, Key_VOLUME_DOWN, Key_VOLUME_UP, Key_MEDIA_NEXT_TRACK, Key_MEDIA_PREV_TRACK, Key_MEDIA_STOP, Key_MEDIA_PLAY_PAUSE, Key_LAUNCH_MAIL, Key_LAUNCH_MEDIA_SELECT, Key_LAUNCH_APP1, Key_LAUNCH_APP2, Key_OEM_1, Key_OEM_PLUS, Key_OEM_COMMA, Key_OEM_MINUS, Key_OEM_PERIOD, Key_OEM_2, Key_OEM_3, Key_OEM_4, Key_OEM_5, Key_OEM_6, Key_OEM_7, Key_OEM_8, Key_OEM_102, Key_PROCESSKEY, Key_PACKET, Key_ATTN, Key_CRSEL, Key_EXSEL, Key_EREOF, Key_PLAY, Key_ZOOM, Key_NONAME, Key_PA1, Key_OEM_CLEAR, irx, iry, mWSButtonStateA, mWSButtonStateB, mWSButtonStateMinus, mWSButtonStateHome, mWSButtonStatePlus, mWSButtonStateOne, mWSButtonStateTwo, mWSButtonStateUp, mWSButtonStateDown, mWSButtonStateLeft, mWSButtonStateRight, mWSRawValuesX, mWSRawValuesY, mWSRawValuesZ, mWSNunchuckStateRawJoystickX, mWSNunchuckStateRawJoystickY, mWSNunchuckStateRawValuesX, mWSNunchuckStateRawValuesY, mWSNunchuckStateRawValuesZ, mWSNunchuckStateC, mWSNunchuckStateZ, stickRight, RightButtonSHOULDER_1, RightButtonSHOULDER_2, RightButtonSR, RightButtonSL, RightButtonDPAD_DOWN, RightButtonDPAD_RIGHT, RightButtonDPAD_UP, RightButtonDPAD_LEFT, RightButtonPLUS, RightButtonHOME, RightButtonSTICK, RightButtonACC, RightButtonSPA, RightRollLeft, RightRollRight, RightAccelX, RightAccelY, RightGyroX, RightGyroY, stickLeft, LeftButtonSHOULDER_1, LeftButtonSHOULDER_2, LeftButtonSR, LeftButtonSL, LeftButtonDPAD_DOWN, LeftButtonDPAD_RIGHT, LeftButtonDPAD_UP, LeftButtonDPAD_LEFT, LeftButtonMINUS, LeftButtonCAPTURE, LeftButtonSTICK, LeftButtonACC, LeftButtonSMA, LeftRollLeft, LeftRollRight, LeftAccelX, LeftAccelY, LeftGyroX, LeftGyroY, Controller_A, Controller_B, Controller_X, Controller_Y, Controller_LB, Controller_RB, Controller_LT, Controller_RT, Controller_MAP, Controller_MENU, Controller_LSTICK, Controller_RSTICK, Controller_DU, Controller_DD, Controller_DL, Controller_DR, Controller_XBOX, Controller_LX, Controller_LY, Controller_RX, Controller_RY, TextFromSpeech, ButtonAPressed, ButtonBPressed, ButtonXPressed, ButtonYPressed, ButtonStartPressed, ButtonBackPressed, ButtonDownPressed, ButtonUpPressed, ButtonLeftPressed, ButtonRightPressed, ButtonShoulderLeftPressed, ButtonShoulderRightPressed, ThumbpadLeftPressed, ThumbpadRightPressed, TriggerLeftPressed, TriggerRightPressed, TriggerLeftPressThreshold, TriggerRightPressThreshold, TriggerLeftPosition, TriggerRightPosition, ThumbLeftX, ThumbLeftY, ThumbRightX, ThumbRightY });
                        UsersAllowedList = (string[])val[0];
                        sleeptime = (int)val[1];
                        string KeyboardMouseDriverType = (string)val[2]; double MouseMoveX = (double)val[3]; double MouseMoveY = (double)val[4]; double MouseAbsX = (double)val[5]; double MouseAbsY = (double)val[6]; double MouseDesktopX = (double)val[7]; double MouseDesktopY = (double)val[8]; bool SendLeftClick = (bool)val[9]; bool SendRightClick = (bool)val[10]; bool SendMiddleClick = (bool)val[11]; bool SendWheelUp = (bool)val[12]; bool SendWheelDown = (bool)val[13]; bool SendLeft = (bool)val[14]; bool SendRight = (bool)val[15]; bool SendUp = (bool)val[16]; bool SendDown = (bool)val[17]; bool SendLButton = (bool)val[18]; bool SendRButton = (bool)val[19]; bool SendCancel = (bool)val[20]; bool SendMBUTTON = (bool)val[21]; bool SendXBUTTON1 = (bool)val[22]; bool SendXBUTTON2 = (bool)val[23]; bool SendBack = (bool)val[24]; bool SendTab = (bool)val[25]; bool SendClear = (bool)val[26]; bool SendReturn = (bool)val[27]; bool SendSHIFT = (bool)val[28]; bool SendCONTROL = (bool)val[29]; bool SendMENU = (bool)val[30]; bool SendPAUSE = (bool)val[31]; bool SendCAPITAL = (bool)val[32]; bool SendKANA = (bool)val[33]; bool SendHANGEUL = (bool)val[34]; bool SendHANGUL = (bool)val[35]; bool SendJUNJA = (bool)val[36]; bool SendFINAL = (bool)val[37]; bool SendHANJA = (bool)val[38]; bool SendKANJI = (bool)val[39]; bool SendEscape = (bool)val[40]; bool SendCONVERT = (bool)val[41]; bool SendNONCONVERT = (bool)val[42]; bool SendACCEPT = (bool)val[43]; bool SendMODECHANGE = (bool)val[44]; bool SendSpace = (bool)val[45]; bool SendPRIOR = (bool)val[46]; bool SendNEXT = (bool)val[47]; bool SendEND = (bool)val[48]; bool SendHOME = (bool)val[49]; bool SendLEFT = (bool)val[50]; bool SendUP = (bool)val[51]; bool SendRIGHT = (bool)val[52]; bool SendDOWN = (bool)val[53]; bool SendSELECT = (bool)val[54]; bool SendPRINT = (bool)val[55]; bool SendEXECUTE = (bool)val[56]; bool SendSNAPSHOT = (bool)val[57]; bool SendINSERT = (bool)val[58]; bool SendDELETE = (bool)val[59]; bool SendHELP = (bool)val[60]; bool SendAPOSTROPHE = (bool)val[61]; bool Send0 = (bool)val[62]; bool Send1 = (bool)val[63]; bool Send2 = (bool)val[64]; bool Send3 = (bool)val[65]; bool Send4 = (bool)val[66]; bool Send5 = (bool)val[67]; bool Send6 = (bool)val[68]; bool Send7 = (bool)val[69]; bool Send8 = (bool)val[70]; bool Send9 = (bool)val[71]; bool SendA = (bool)val[72]; bool SendB = (bool)val[73]; bool SendC = (bool)val[74]; bool SendD = (bool)val[75]; bool SendE = (bool)val[76]; bool SendF = (bool)val[77]; bool SendG = (bool)val[78]; bool SendH = (bool)val[79]; bool SendI = (bool)val[80]; bool SendJ = (bool)val[81]; bool SendK = (bool)val[82]; bool SendL = (bool)val[83]; bool SendM = (bool)val[84]; bool SendN = (bool)val[85]; bool SendO = (bool)val[86]; bool SendP = (bool)val[87]; bool SendQ = (bool)val[88]; bool SendR = (bool)val[89]; bool SendS = (bool)val[90]; bool SendT = (bool)val[91]; bool SendU = (bool)val[92]; bool SendV = (bool)val[93]; bool SendW = (bool)val[94]; bool SendX = (bool)val[95]; bool SendY = (bool)val[96]; bool SendZ = (bool)val[97]; bool SendLWIN = (bool)val[98]; bool SendRWIN = (bool)val[99]; bool SendAPPS = (bool)val[100]; bool SendSLEEP = (bool)val[101]; bool SendNUMPAD0 = (bool)val[102]; bool SendNUMPAD1 = (bool)val[103]; bool SendNUMPAD2 = (bool)val[104]; bool SendNUMPAD3 = (bool)val[105]; bool SendNUMPAD4 = (bool)val[106]; bool SendNUMPAD5 = (bool)val[107]; bool SendNUMPAD6 = (bool)val[108]; bool SendNUMPAD7 = (bool)val[109]; bool SendNUMPAD8 = (bool)val[110]; bool SendNUMPAD9 = (bool)val[111]; bool SendMULTIPLY = (bool)val[112]; bool SendADD = (bool)val[113]; bool SendSEPARATOR = (bool)val[114]; bool SendSUBTRACT = (bool)val[115]; bool SendDECIMAL = (bool)val[116]; bool SendDIVIDE = (bool)val[117]; bool SendF1 = (bool)val[118]; bool SendF2 = (bool)val[119]; bool SendF3 = (bool)val[120]; bool SendF4 = (bool)val[121]; bool SendF5 = (bool)val[122]; bool SendF6 = (bool)val[123]; bool SendF7 = (bool)val[124]; bool SendF8 = (bool)val[125]; bool SendF9 = (bool)val[126]; bool SendF10 = (bool)val[127]; bool SendF11 = (bool)val[128]; bool SendF12 = (bool)val[129]; bool SendF13 = (bool)val[130]; bool SendF14 = (bool)val[131]; bool SendF15 = (bool)val[132]; bool SendF16 = (bool)val[133]; bool SendF17 = (bool)val[134]; bool SendF18 = (bool)val[135]; bool SendF19 = (bool)val[136]; bool SendF20 = (bool)val[137]; bool SendF21 = (bool)val[138]; bool SendF22 = (bool)val[139]; bool SendF23 = (bool)val[140]; bool SendF24 = (bool)val[141]; bool SendNUMLOCK = (bool)val[142]; bool SendSCROLL = (bool)val[143]; bool SendLeftShift = (bool)val[144]; bool SendRightShift = (bool)val[145]; bool SendLeftControl = (bool)val[146]; bool SendRightControl = (bool)val[147]; bool SendLMENU = (bool)val[148]; bool SendRMENU = (bool)val[149];
                        bool back = (bool)val[150]; bool start = (bool)val[151]; bool A = (bool)val[152]; bool B = (bool)val[153]; bool X = (bool)val[154]; bool Y = (bool)val[155]; bool up = (bool)val[156]; bool left = (bool)val[157]; bool down = (bool)val[158]; bool right = (bool)val[159]; bool leftstick = (bool)val[160]; bool rightstick = (bool)val[161]; bool leftbumper = (bool)val[162]; bool rightbumper = (bool)val[163]; bool lefttrigger = (bool)val[164]; bool righttrigger = (bool)val[165]; double leftstickx = (double)val[166]; double leftsticky = (double)val[167]; double rightstickx = (double)val[168]; double rightsticky = (double)val[169]; centery = (double)val[170]; irmode = (int)val[171];
                        SendKeys.SetKM(KeyboardMouseDriverType, MouseMoveX, MouseMoveY, MouseAbsX, MouseAbsY, MouseDesktopX, MouseDesktopY, SendLeftClick, SendRightClick, SendMiddleClick, SendWheelUp, SendWheelDown, SendLeft, SendRight, SendUp, SendDown, SendLButton, SendRButton, SendCancel, SendMBUTTON, SendXBUTTON1, SendXBUTTON2, SendBack, SendTab, SendClear, SendReturn, SendSHIFT, SendCONTROL, SendMENU, SendPAUSE, SendCAPITAL, SendKANA, SendHANGEUL, SendHANGUL, SendJUNJA, SendFINAL, SendHANJA, SendKANJI, SendEscape, SendCONVERT, SendNONCONVERT, SendACCEPT, SendMODECHANGE, SendSpace, SendPRIOR, SendNEXT, SendEND, SendHOME, SendLEFT, SendUP, SendRIGHT, SendDOWN, SendSELECT, SendPRINT, SendEXECUTE, SendSNAPSHOT, SendINSERT, SendDELETE, SendHELP, SendAPOSTROPHE, Send0, Send1, Send2, Send3, Send4, Send5, Send6, Send7, Send8, Send9, SendA, SendB, SendC, SendD, SendE, SendF, SendG, SendH, SendI, SendJ, SendK, SendL, SendM, SendN, SendO, SendP, SendQ, SendR, SendS, SendT, SendU, SendV, SendW, SendX, SendY, SendZ, SendLWIN, SendRWIN, SendAPPS, SendSLEEP, SendNUMPAD0, SendNUMPAD1, SendNUMPAD2, SendNUMPAD3, SendNUMPAD4, SendNUMPAD5, SendNUMPAD6, SendNUMPAD7, SendNUMPAD8, SendNUMPAD9, SendMULTIPLY, SendADD, SendSEPARATOR, SendSUBTRACT, SendDECIMAL, SendDIVIDE, SendF1, SendF2, SendF3, SendF4, SendF5, SendF6, SendF7, SendF8, SendF9, SendF10, SendF11, SendF12, SendF13, SendF14, SendF15, SendF16, SendF17, SendF18, SendF19, SendF20, SendF21, SendF22, SendF23, SendF24, SendNUMLOCK, SendSCROLL, SendLeftShift, SendRightShift, SendLeftControl, SendRightControl, SendLMENU, SendRMENU);
                        ScpBus.SetController(back, start, A, B, X, Y, up, left, down, right, leftstick, rightstick, leftbumper, rightbumper, lefttrigger, righttrigger, leftstickx, leftsticky, rightstickx, rightsticky);
                        System.Threading.Thread.Sleep(sleeptime);
                    }
                    SendKeys.UnLoadKM();
                    if (SpeechToText.Length != 0)
                    {
                        StopSpeechToText();
                    }
                }
                else
                {
                    MessageBox.Show("You are not allowed to run this script.");
                }
            }
            catch { }
        }
        private static void ControllerProcess()
        {
            ButtonAPressed = connectedControllers.FirstOrDefault().ButtonAPressed;
            ButtonBPressed = connectedControllers.FirstOrDefault().ButtonBPressed;
            ButtonXPressed = connectedControllers.FirstOrDefault().ButtonXPressed;
            ButtonYPressed = connectedControllers.FirstOrDefault().ButtonYPressed;
            ButtonStartPressed = connectedControllers.FirstOrDefault().ButtonStartPressed;
            ButtonBackPressed = connectedControllers.FirstOrDefault().ButtonBackPressed;
            ButtonDownPressed = connectedControllers.FirstOrDefault().ButtonDownPressed;
            ButtonUpPressed = connectedControllers.FirstOrDefault().ButtonUpPressed;
            ButtonLeftPressed = connectedControllers.FirstOrDefault().ButtonLeftPressed;
            ButtonRightPressed = connectedControllers.FirstOrDefault().ButtonRightPressed;
            ButtonShoulderLeftPressed = connectedControllers.FirstOrDefault().ButtonShoulderLeftPressed;
            ButtonShoulderRightPressed = connectedControllers.FirstOrDefault().ButtonShoulderRightPressed;
            ThumbpadLeftPressed = connectedControllers.FirstOrDefault().ThumbpadLeftPressed;
            ThumbpadRightPressed = connectedControllers.FirstOrDefault().ThumbpadRightPressed;
            TriggerLeftPressed = connectedControllers.FirstOrDefault().TriggerLeftPressed;
            TriggerRightPressed = connectedControllers.FirstOrDefault().TriggerRightPressed;
            TriggerLeftPressThreshold = connectedControllers.FirstOrDefault().TriggerLeftPressThreshold;
            TriggerRightPressThreshold = connectedControllers.FirstOrDefault().TriggerRightPressThreshold;
            TriggerLeftPosition = connectedControllers.FirstOrDefault().TriggerLeftPosition;
            TriggerRightPosition = connectedControllers.FirstOrDefault().TriggerRightPosition;
            ThumbLeftX = connectedControllers.FirstOrDefault().ThumbLeftX;
            ThumbLeftY = connectedControllers.FirstOrDefault().ThumbLeftY;
            ThumbRightX = connectedControllers.FirstOrDefault().ThumbRightX;
            ThumbRightY = connectedControllers.FirstOrDefault().ThumbRightY;
        }
        static void SetupSpeechToText(string[] speechwords)
        {
            speechToText = Ozeki.Media.SpeechToText.CreateInstance(speechwords); 
            speechToText.WordRecognized += SpeechToText_WordsRecognized; 
            connector.Connect(microphone, speechToText);
            microphone.Start();
        }
        private static void StopSpeechToText()
        {
            try
            {
                speechToText.WordRecognized -= SpeechToText_WordsRecognized;
            }
            catch { }
            try
            {
                connector.Disconnect(microphone, speechToText);
            }
            catch { }
            try
            {
                speechToText.Dispose();
            }
            catch { }
            try
            {
                microphone.Stop();
            }
            catch { }
        }
        private static void SpeechToText_WordsRecognized(object sender, SpeechDetectionEventArgs e)
        {
            TextFromSpeech = e.Word;
        }
        public static void WiimoteNunchuckData()
        {
            while (scriptrunning & wiimoteconnected)
            {
                DataWiimoteNunchuck();
            }
        }
        public static void LeftJoyconData()
        {
            while (scriptrunning & joyconleftconnected)
            {
                DataLeftJoycon();
            }
        }
        public static void RightJoyconData()
        {
            while (scriptrunning & joyconrightconnected)
            {
                DataRightJoycon();
            }
        }
        public static void MouseHookProcessButtons()
        {
            if (Getstate) 
            { 
                SetCursorPos(mousehookx <= 0 ? 0 : width, mousehooky <= 0 ? 0 : height);
                if (time.Count() <= 60)
                    time.Add(MouseHookTime + mousehookx + mousehooky);
                else
                {
                    time.Add(MouseHookTime + mousehookx + mousehooky);
                    time.RemoveAt(0);
                }
                if (time.All(x => x == time.First()))
                {
                    tempmousehookx = 0;
                    tempmousehooky = 0;
                }
                else
                {
                    tempmousehookx = mousehookx;
                    tempmousehooky = mousehooky;
                }
                MouseHookX = tempmousehookx;
                MouseHookY = tempmousehooky;
                if (MouseHookX >= 1024f)
                    MouseHookX = 1024f;
                if (MouseHookX <= -1024f)
                    MouseHookX = -1024f;
                if (MouseHookY >= 1024f)
                    MouseHookY = 1024f;
                if (MouseHookY <= -1024f)
                    MouseHookY = -1024f;
            }
            else
            {
                MouseHookX = mousehookx;
                MouseHookY = mousehooky;
            }
            if (MouseHookWheel != 0)
                mousehookwheelbool = true;
            if (mousehookwheelbool)
                mousehookwheelcount++;
            if (mousehookwheelcount >= 80)
            {
                mousehookwheelbool = false;
                MouseHook.MouseHookWheel = 0;
                MouseHookWheel = 0;
                mousehookwheelcount = 0;
            }
            if (MouseHookButtonX != 0)
                mousehookbuttonbool = true;
            if (mousehookbuttonbool)
                mousehookbuttoncount++;
            if (mousehookbuttoncount >= 80)
            {
                mousehookbuttonbool = false;
                MouseHook.MouseHookButtonX = 0;
                MouseHookButtonX = 0;
                mousehookbuttoncount = 0;
            }
            if (MouseHookButtonX == 65536)
                MouseHookButtonX1 = true;
            else
                MouseHookButtonX1 = false;
            if (MouseHookButtonX == 131072)
                MouseHookButtonX2 = true;
            else
                MouseHookButtonX2 = false;
            if (MouseHookWheel == 7864320)
                MouseHookWheelUp = true;
            else
                MouseHookWheelUp = false;
            if (MouseHookWheel == -7864320)
                MouseHookWheelDown = true;
            else
                MouseHookWheelDown = false;
        }
        public const int S_LBUTTON = (int)0x0;
        public const int S_RBUTTON = 0;
        public const int S_CANCEL = 70;
        public const int S_MBUTTON = 0;
        public const int S_XBUTTON1 = 0;
        public const int S_XBUTTON2 = 0;
        public const int S_BACK = 14;
        public const int S_Tab = 15;
        public const int S_CLEAR = 76;
        public const int S_Return = 28;
        public const int S_SHIFT = 42;
        public const int S_CONTROL = 29;
        public const int S_MENU = 56;
        public const int S_PAUSE = 0;
        public const int S_CAPITAL = 58;
        public const int S_KANA = 0;
        public const int S_HANGEUL = 0;
        public const int S_HANGUL = 0;
        public const int S_JUNJA = 0;
        public const int S_FINAL = 0;
        public const int S_HANJA = 0;
        public const int S_KANJI = 0;
        public const int S_Escape = 1;
        public const int S_CONVERT = 0;
        public const int S_NONCONVERT = 0;
        public const int S_ACCEPT = 0;
        public const int S_MODECHANGE = 0;
        public const int S_Space = 57;
        public const int S_PRIOR = 73;
        public const int S_NEXT = 81;
        public const int S_END = 79;
        public const int S_HOME = 71;
        public const int S_LEFT = 75;
        public const int S_UP = 72;
        public const int S_RIGHT = 77;
        public const int S_DOWN = 80;
        public const int S_SELECT = 0;
        public const int S_PRINT = 0;
        public const int S_EXECUTE = 0;
        public const int S_SNAPSHOT = 84;
        public const int S_INSERT = 82;
        public const int S_DELETE = 83;
        public const int S_HELP = 99;
        public const int S_APOSTROPHE = 41;
        public const int S_0 = 11;
        public const int S_1 = 2;
        public const int S_2 = 3;
        public const int S_3 = 4;
        public const int S_4 = 5;
        public const int S_5 = 6;
        public const int S_6 = 7;
        public const int S_7 = 8;
        public const int S_8 = 9;
        public const int S_9 = 10;
        public const int S_A = 16;
        public const int S_B = 48;
        public const int S_C = 46;
        public const int S_D = 32;
        public const int S_E = 18;
        public const int S_F = 33;
        public const int S_G = 34;
        public const int S_H = 35;
        public const int S_I = 23;
        public const int S_J = 36;
        public const int S_K = 37;
        public const int S_L = 38;
        public const int S_M = 39;
        public const int S_N = 49;
        public const int S_O = 24;
        public const int S_P = 25;
        public const int S_Q = 30;
        public const int S_R = 19;
        public const int S_S = 31;
        public const int S_T = 20;
        public const int S_U = 22;
        public const int S_V = 47;
        public const int S_W = 44;
        public const int S_X = 45;
        public const int S_Y = 21;
        public const int S_Z = 17;
        public const int S_LWIN = 91;
        public const int S_RWIN = 92;
        public const int S_APPS = 93;
        public const int S_SLEEP = 95;
        public const int S_NUMPAD0 = 82;
        public const int S_NUMPAD1 = 79;
        public const int S_NUMPAD2 = 80;
        public const int S_NUMPAD3 = 81;
        public const int S_NUMPAD4 = 75;
        public const int S_NUMPAD5 = 76;
        public const int S_NUMPAD6 = 77;
        public const int S_NUMPAD7 = 71;
        public const int S_NUMPAD8 = 72;
        public const int S_NUMPAD9 = 73;
        public const int S_MULTIPLY = 55;
        public const int S_ADD = 78;
        public const int S_SEPARATOR = 0;
        public const int S_SUBTRACT = 74;
        public const int S_DECIMAL = 83;
        public const int S_DIVIDE = 53;
        public const int S_F1 = 59;
        public const int S_F2 = 60;
        public const int S_F3 = 61;
        public const int S_F4 = 62;
        public const int S_F5 = 63;
        public const int S_F6 = 64;
        public const int S_F7 = 65;
        public const int S_F8 = 66;
        public const int S_F9 = 67;
        public const int S_F10 = 68;
        public const int S_F11 = 87;
        public const int S_F12 = 88;
        public const int S_F13 = 100;
        public const int S_F14 = 101;
        public const int S_F15 = 102;
        public const int S_F16 = 103;
        public const int S_F17 = 104;
        public const int S_F18 = 105;
        public const int S_F19 = 106;
        public const int S_F20 = 107;
        public const int S_F21 = 108;
        public const int S_F22 = 109;
        public const int S_F23 = 110;
        public const int S_F24 = 118;
        public const int S_NUMLOCK = 69;
        public const int S_SCROLL = 70;
        public const int S_LeftShift = 42;
        public const int S_RightShift = 54;
        public const int S_LeftControl = 29;
        public const int S_RightControl = 29;
        public const int S_LMENU = 56;
        public const int S_RMENU = 56;
        public const int S_BROWSER_BACK = 106;
        public const int S_BROWSER_FORWARD = 105;
        public const int S_BROWSER_REFRESH = 103;
        public const int S_BROWSER_STOP = 104;
        public const int S_BROWSER_SEARCH = 101;
        public const int S_BROWSER_FAVORITES = 102;
        public const int S_BROWSER_HOME = 50;
        public const int S_VOLUME_MUTE = 32;
        public const int S_VOLUME_DOWN = 46;
        public const int S_VOLUME_UP = 48;
        public const int S_MEDIA_NEXT_TRACK = 25;
        public const int S_MEDIA_PREV_TRACK = 16;
        public const int S_MEDIA_STOP = 36;
        public const int S_MEDIA_PLAY_PAUSE = 34;
        public const int S_LAUNCH_MAIL = 108;
        public const int S_LAUNCH_MEDIA_SELECT = 109;
        public const int S_LAUNCH_APP1 = 107;
        public const int S_LAUNCH_APP2 = 33;
        public const int S_OEM_1 = 27;
        public const int S_OEM_PLUS = 13;
        public const int S_OEM_COMMA = 50;
        public const int S_OEM_MINUS = 0;
        public const int S_OEM_PERIOD = 51;
        public const int S_OEM_2 = 52;
        public const int S_OEM_3 = 40;
        public const int S_OEM_4 = 12;
        public const int S_OEM_5 = 43;
        public const int S_OEM_6 = 26;
        public const int S_OEM_7 = 41;
        public const int S_OEM_8 = 53;
        public const int S_OEM_102 = 86;
        public const int S_PROCESSKEY = 0;
        public const int S_PACKET = 0;
        public const int S_ATTN = 0;
        public const int S_CRSEL = 0;
        public const int S_EXSEL = 0;
        public const int S_EREOF = 93;
        public const int S_PLAY = 0;
        public const int S_ZOOM = 98;
        public const int S_NONAME = 0;
        public const int S_PA1 = 0;
        public const int S_OEM_CLEAR = 0;
        public static bool Key_LBUTTON;
        public static bool Key_RBUTTON;
        public static bool Key_CANCEL;
        public static bool Key_MBUTTON;
        public static bool Key_XBUTTON1;
        public static bool Key_XBUTTON2;
        public static bool Key_BACK;
        public static bool Key_Tab;
        public static bool Key_CLEAR;
        public static bool Key_Return;
        public static bool Key_SHIFT;
        public static bool Key_CONTROL;
        public static bool Key_MENU;
        public static bool Key_PAUSE;
        public static bool Key_CAPITAL;
        public static bool Key_KANA;
        public static bool Key_HANGEUL;
        public static bool Key_HANGUL;
        public static bool Key_JUNJA;
        public static bool Key_FINAL;
        public static bool Key_HANJA;
        public static bool Key_KANJI;
        public static bool Key_Escape;
        public static bool Key_CONVERT;
        public static bool Key_NONCONVERT;
        public static bool Key_ACCEPT;
        public static bool Key_MODECHANGE;
        public static bool Key_Space;
        public static bool Key_PRIOR;
        public static bool Key_NEXT;
        public static bool Key_END;
        public static bool Key_HOME;
        public static bool Key_LEFT;
        public static bool Key_UP;
        public static bool Key_RIGHT;
        public static bool Key_DOWN;
        public static bool Key_SELECT;
        public static bool Key_PRINT;
        public static bool Key_EXECUTE;
        public static bool Key_SNAPSHOT;
        public static bool Key_INSERT;
        public static bool Key_DELETE;
        public static bool Key_HELP;
        public static bool Key_APOSTROPHE;
        public static bool Key_0;
        public static bool Key_1;
        public static bool Key_2;
        public static bool Key_3;
        public static bool Key_4;
        public static bool Key_5;
        public static bool Key_6;
        public static bool Key_7;
        public static bool Key_8;
        public static bool Key_9;
        public static bool Key_A;
        public static bool Key_B;
        public static bool Key_C;
        public static bool Key_D;
        public static bool Key_E;
        public static bool Key_F;
        public static bool Key_G;
        public static bool Key_H;
        public static bool Key_I;
        public static bool Key_J;
        public static bool Key_K;
        public static bool Key_L;
        public static bool Key_M;
        public static bool Key_N;
        public static bool Key_O;
        public static bool Key_P;
        public static bool Key_Q;
        public static bool Key_R;
        public static bool Key_S;
        public static bool Key_T;
        public static bool Key_U;
        public static bool Key_V;
        public static bool Key_W;
        public static bool Key_X;
        public static bool Key_Y;
        public static bool Key_Z;
        public static bool Key_LWIN;
        public static bool Key_RWIN;
        public static bool Key_APPS;
        public static bool Key_SLEEP;
        public static bool Key_NUMPAD0;
        public static bool Key_NUMPAD1;
        public static bool Key_NUMPAD2;
        public static bool Key_NUMPAD3;
        public static bool Key_NUMPAD4;
        public static bool Key_NUMPAD5;
        public static bool Key_NUMPAD6;
        public static bool Key_NUMPAD7;
        public static bool Key_NUMPAD8;
        public static bool Key_NUMPAD9;
        public static bool Key_MULTIPLY;
        public static bool Key_ADD;
        public static bool Key_SEPARATOR;
        public static bool Key_SUBTRACT;
        public static bool Key_DECIMAL;
        public static bool Key_DIVIDE;
        public static bool Key_F1;
        public static bool Key_F2;
        public static bool Key_F3;
        public static bool Key_F4;
        public static bool Key_F5;
        public static bool Key_F6;
        public static bool Key_F7;
        public static bool Key_F8;
        public static bool Key_F9;
        public static bool Key_F10;
        public static bool Key_F11;
        public static bool Key_F12;
        public static bool Key_F13;
        public static bool Key_F14;
        public static bool Key_F15;
        public static bool Key_F16;
        public static bool Key_F17;
        public static bool Key_F18;
        public static bool Key_F19;
        public static bool Key_F20;
        public static bool Key_F21;
        public static bool Key_F22;
        public static bool Key_F23;
        public static bool Key_F24;
        public static bool Key_NUMLOCK;
        public static bool Key_SCROLL;
        public static bool Key_LeftShift;
        public static bool Key_RightShift;
        public static bool Key_LeftControl;
        public static bool Key_RightControl;
        public static bool Key_LMENU;
        public static bool Key_RMENU;
        public static bool Key_BROWSER_BACK;
        public static bool Key_BROWSER_FORWARD;
        public static bool Key_BROWSER_REFRESH;
        public static bool Key_BROWSER_STOP;
        public static bool Key_BROWSER_SEARCH;
        public static bool Key_BROWSER_FAVORITES;
        public static bool Key_BROWSER_HOME;
        public static bool Key_VOLUME_MUTE;
        public static bool Key_VOLUME_DOWN;
        public static bool Key_VOLUME_UP;
        public static bool Key_MEDIA_NEXT_TRACK;
        public static bool Key_MEDIA_PREV_TRACK;
        public static bool Key_MEDIA_STOP;
        public static bool Key_MEDIA_PLAY_PAUSE;
        public static bool Key_LAUNCH_MAIL;
        public static bool Key_LAUNCH_MEDIA_SELECT;
        public static bool Key_LAUNCH_APP1;
        public static bool Key_LAUNCH_APP2;
        public static bool Key_OEM_1;
        public static bool Key_OEM_PLUS;
        public static bool Key_OEM_COMMA;
        public static bool Key_OEM_MINUS;
        public static bool Key_OEM_PERIOD;
        public static bool Key_OEM_2;
        public static bool Key_OEM_3;
        public static bool Key_OEM_4;
        public static bool Key_OEM_5;
        public static bool Key_OEM_6;
        public static bool Key_OEM_7;
        public static bool Key_OEM_8;
        public static bool Key_OEM_102;
        public static bool Key_PROCESSKEY;
        public static bool Key_PACKET;
        public static bool Key_ATTN;
        public static bool Key_CRSEL;
        public static bool Key_EXSEL;
        public static bool Key_EREOF;
        public static bool Key_PLAY;
        public static bool Key_ZOOM;
        public static bool Key_NONAME;
        public static bool Key_PA1;
        public static bool Key_OEM_CLEAR;
        public static void KeyboardHookProcessButtons()
        {
            if (KeyboardHookButtonDown)
            {
                if (scanCode == S_LBUTTON)
                    Key_LBUTTON = true;
                if (scanCode == S_RBUTTON)
                    Key_RBUTTON = true;
                if (scanCode == S_CANCEL)
                    Key_CANCEL = true;
                if (scanCode == S_MBUTTON)
                    Key_MBUTTON = true;
                if (scanCode == S_XBUTTON1)
                    Key_XBUTTON1 = true;
                if (scanCode == S_XBUTTON2)
                    Key_XBUTTON2 = true;
                if (scanCode == S_BACK)
                    Key_BACK = true;
                if (scanCode == S_Tab)
                    Key_Tab = true;
                if (scanCode == S_CLEAR)
                    Key_CLEAR = true;
                if (scanCode == S_Return)
                    Key_Return = true;
                if (scanCode == S_SHIFT)
                    Key_SHIFT = true;
                if (scanCode == S_CONTROL)
                    Key_CONTROL = true;
                if (scanCode == S_MENU)
                    Key_MENU = true;
                if (scanCode == S_PAUSE)
                    Key_PAUSE = true;
                if (scanCode == S_CAPITAL)
                    Key_CAPITAL = true;
                if (scanCode == S_KANA)
                    Key_KANA = true;
                if (scanCode == S_HANGEUL)
                    Key_HANGEUL = true;
                if (scanCode == S_HANGUL)
                    Key_HANGUL = true;
                if (scanCode == S_JUNJA)
                    Key_JUNJA = true;
                if (scanCode == S_FINAL)
                    Key_FINAL = true;
                if (scanCode == S_HANJA)
                    Key_HANJA = true;
                if (scanCode == S_KANJI)
                    Key_KANJI = true;
                if (scanCode == S_Escape)
                    Key_Escape = true;
                if (scanCode == S_CONVERT)
                    Key_CONVERT = true;
                if (scanCode == S_NONCONVERT)
                    Key_NONCONVERT = true;
                if (scanCode == S_ACCEPT)
                    Key_ACCEPT = true;
                if (scanCode == S_MODECHANGE)
                    Key_MODECHANGE = true;
                if (scanCode == S_Space)
                    Key_Space = true;
                if (scanCode == S_PRIOR)
                    Key_PRIOR = true;
                if (scanCode == S_NEXT)
                    Key_NEXT = true;
                if (scanCode == S_END)
                    Key_END = true;
                if (scanCode == S_HOME)
                    Key_HOME = true;
                if (scanCode == S_LEFT)
                    Key_LEFT = true;
                if (scanCode == S_UP)
                    Key_UP = true;
                if (scanCode == S_RIGHT)
                    Key_RIGHT = true;
                if (scanCode == S_DOWN)
                    Key_DOWN = true;
                if (scanCode == S_SELECT)
                    Key_SELECT = true;
                if (scanCode == S_PRINT)
                    Key_PRINT = true;
                if (scanCode == S_EXECUTE)
                    Key_EXECUTE = true;
                if (scanCode == S_SNAPSHOT)
                    Key_SNAPSHOT = true;
                if (scanCode == S_INSERT)
                    Key_INSERT = true;
                if (scanCode == S_DELETE)
                    Key_DELETE = true;
                if (scanCode == S_HELP)
                    Key_HELP = true;
                if (scanCode == S_APOSTROPHE)
                    Key_APOSTROPHE = true;
                if (scanCode == S_0)
                    Key_0 = true;
                if (scanCode == S_1)
                    Key_1 = true;
                if (scanCode == S_2)
                    Key_2 = true;
                if (scanCode == S_3)
                    Key_3 = true;
                if (scanCode == S_4)
                    Key_4 = true;
                if (scanCode == S_5)
                    Key_5 = true;
                if (scanCode == S_6)
                    Key_6 = true;
                if (scanCode == S_7)
                    Key_7 = true;
                if (scanCode == S_8)
                    Key_8 = true;
                if (scanCode == S_9)
                    Key_9 = true;
                if (scanCode == S_A)
                    Key_A = true;
                if (scanCode == S_B)
                    Key_B = true;
                if (scanCode == S_C)
                    Key_C = true;
                if (scanCode == S_D)
                    Key_D = true;
                if (scanCode == S_E)
                    Key_E = true;
                if (scanCode == S_F)
                    Key_F = true;
                if (scanCode == S_G)
                    Key_G = true;
                if (scanCode == S_H)
                    Key_H = true;
                if (scanCode == S_I)
                    Key_I = true;
                if (scanCode == S_J)
                    Key_J = true;
                if (scanCode == S_K)
                    Key_K = true;
                if (scanCode == S_L)
                    Key_L = true;
                if (scanCode == S_M)
                    Key_M = true;
                if (scanCode == S_N)
                    Key_N = true;
                if (scanCode == S_O)
                    Key_O = true;
                if (scanCode == S_P)
                    Key_P = true;
                if (scanCode == S_Q)
                    Key_Q = true;
                if (scanCode == S_R)
                    Key_R = true;
                if (scanCode == S_S)
                    Key_S = true;
                if (scanCode == S_T)
                    Key_T = true;
                if (scanCode == S_U)
                    Key_U = true;
                if (scanCode == S_V)
                    Key_V = true;
                if (scanCode == S_W)
                    Key_W = true;
                if (scanCode == S_X)
                    Key_X = true;
                if (scanCode == S_Y)
                    Key_Y = true;
                if (scanCode == S_Z)
                    Key_Z = true;
                if (scanCode == S_LWIN)
                    Key_LWIN = true;
                if (scanCode == S_RWIN)
                    Key_RWIN = true;
                if (scanCode == S_APPS)
                    Key_APPS = true;
                if (scanCode == S_SLEEP)
                    Key_SLEEP = true;
                if (scanCode == S_NUMPAD0)
                    Key_NUMPAD0 = true;
                if (scanCode == S_NUMPAD1)
                    Key_NUMPAD1 = true;
                if (scanCode == S_NUMPAD2)
                    Key_NUMPAD2 = true;
                if (scanCode == S_NUMPAD3)
                    Key_NUMPAD3 = true;
                if (scanCode == S_NUMPAD4)
                    Key_NUMPAD4 = true;
                if (scanCode == S_NUMPAD5)
                    Key_NUMPAD5 = true;
                if (scanCode == S_NUMPAD6)
                    Key_NUMPAD6 = true;
                if (scanCode == S_NUMPAD7)
                    Key_NUMPAD7 = true;
                if (scanCode == S_NUMPAD8)
                    Key_NUMPAD8 = true;
                if (scanCode == S_NUMPAD9)
                    Key_NUMPAD9 = true;
                if (scanCode == S_MULTIPLY)
                    Key_MULTIPLY = true;
                if (scanCode == S_ADD)
                    Key_ADD = true;
                if (scanCode == S_SEPARATOR)
                    Key_SEPARATOR = true;
                if (scanCode == S_SUBTRACT)
                    Key_SUBTRACT = true;
                if (scanCode == S_DECIMAL)
                    Key_DECIMAL = true;
                if (scanCode == S_DIVIDE)
                    Key_DIVIDE = true;
                if (scanCode == S_F1)
                    Key_F1 = true;
                if (scanCode == S_F2)
                    Key_F2 = true;
                if (scanCode == S_F3)
                    Key_F3 = true;
                if (scanCode == S_F4)
                    Key_F4 = true;
                if (scanCode == S_F5)
                    Key_F5 = true;
                if (scanCode == S_F6)
                    Key_F6 = true;
                if (scanCode == S_F7)
                    Key_F7 = true;
                if (scanCode == S_F8)
                    Key_F8 = true;
                if (scanCode == S_F9)
                    Key_F9 = true;
                if (scanCode == S_F10)
                    Key_F10 = true;
                if (scanCode == S_F11)
                    Key_F11 = true;
                if (scanCode == S_F12)
                    Key_F12 = true;
                if (scanCode == S_F13)
                    Key_F13 = true;
                if (scanCode == S_F14)
                    Key_F14 = true;
                if (scanCode == S_F15)
                    Key_F15 = true;
                if (scanCode == S_F16)
                    Key_F16 = true;
                if (scanCode == S_F17)
                    Key_F17 = true;
                if (scanCode == S_F18)
                    Key_F18 = true;
                if (scanCode == S_F19)
                    Key_F19 = true;
                if (scanCode == S_F20)
                    Key_F20 = true;
                if (scanCode == S_F21)
                    Key_F21 = true;
                if (scanCode == S_F22)
                    Key_F22 = true;
                if (scanCode == S_F23)
                    Key_F23 = true;
                if (scanCode == S_F24)
                    Key_F24 = true;
                if (scanCode == S_NUMLOCK)
                    Key_NUMLOCK = true;
                if (scanCode == S_SCROLL)
                    Key_SCROLL = true;
                if (scanCode == S_LeftShift)
                    Key_LeftShift = true;
                if (scanCode == S_RightShift)
                    Key_RightShift = true;
                if (scanCode == S_LeftControl)
                    Key_LeftControl = true;
                if (scanCode == S_RightControl)
                    Key_RightControl = true;
                if (scanCode == S_LMENU)
                    Key_LMENU = true;
                if (scanCode == S_RMENU)
                    Key_RMENU = true;
                if (scanCode == S_BROWSER_BACK)
                    Key_BROWSER_BACK = true;
                if (scanCode == S_BROWSER_FORWARD)
                    Key_BROWSER_FORWARD = true;
                if (scanCode == S_BROWSER_REFRESH)
                    Key_BROWSER_REFRESH = true;
                if (scanCode == S_BROWSER_STOP)
                    Key_BROWSER_STOP = true;
                if (scanCode == S_BROWSER_SEARCH)
                    Key_BROWSER_SEARCH = true;
                if (scanCode == S_BROWSER_FAVORITES)
                    Key_BROWSER_FAVORITES = true;
                if (scanCode == S_BROWSER_HOME)
                    Key_BROWSER_HOME = true;
                if (scanCode == S_VOLUME_MUTE)
                    Key_VOLUME_MUTE = true;
                if (scanCode == S_VOLUME_DOWN)
                    Key_VOLUME_DOWN = true;
                if (scanCode == S_VOLUME_UP)
                    Key_VOLUME_UP = true;
                if (scanCode == S_MEDIA_NEXT_TRACK)
                    Key_MEDIA_NEXT_TRACK = true;
                if (scanCode == S_MEDIA_PREV_TRACK)
                    Key_MEDIA_PREV_TRACK = true;
                if (scanCode == S_MEDIA_STOP)
                    Key_MEDIA_STOP = true;
                if (scanCode == S_MEDIA_PLAY_PAUSE)
                    Key_MEDIA_PLAY_PAUSE = true;
                if (scanCode == S_LAUNCH_MAIL)
                    Key_LAUNCH_MAIL = true;
                if (scanCode == S_LAUNCH_MEDIA_SELECT)
                    Key_LAUNCH_MEDIA_SELECT = true;
                if (scanCode == S_LAUNCH_APP1)
                    Key_LAUNCH_APP1 = true;
                if (scanCode == S_LAUNCH_APP2)
                    Key_LAUNCH_APP2 = true;
                if (scanCode == S_OEM_1)
                    Key_OEM_1 = true;
                if (scanCode == S_OEM_PLUS)
                    Key_OEM_PLUS = true;
                if (scanCode == S_OEM_COMMA)
                    Key_OEM_COMMA = true;
                if (scanCode == S_OEM_MINUS)
                    Key_OEM_MINUS = true;
                if (scanCode == S_OEM_PERIOD)
                    Key_OEM_PERIOD = true;
                if (scanCode == S_OEM_2)
                    Key_OEM_2 = true;
                if (scanCode == S_OEM_3)
                    Key_OEM_3 = true;
                if (scanCode == S_OEM_4)
                    Key_OEM_4 = true;
                if (scanCode == S_OEM_5)
                    Key_OEM_5 = true;
                if (scanCode == S_OEM_6)
                    Key_OEM_6 = true;
                if (scanCode == S_OEM_7)
                    Key_OEM_7 = true;
                if (scanCode == S_OEM_8)
                    Key_OEM_8 = true;
                if (scanCode == S_OEM_102)
                    Key_OEM_102 = true;
                if (scanCode == S_PROCESSKEY)
                    Key_PROCESSKEY = true;
                if (scanCode == S_PACKET)
                    Key_PACKET = true;
                if (scanCode == S_ATTN)
                    Key_ATTN = true;
                if (scanCode == S_CRSEL)
                    Key_CRSEL = true;
                if (scanCode == S_EXSEL)
                    Key_EXSEL = true;
                if (scanCode == S_EREOF)
                    Key_EREOF = true;
                if (scanCode == S_PLAY)
                    Key_PLAY = true;
                if (scanCode == S_ZOOM)
                    Key_ZOOM = true;
                if (scanCode == S_NONAME)
                    Key_NONAME = true;
                if (scanCode == S_PA1)
                    Key_PA1 = true;
                if (scanCode == S_OEM_CLEAR)
                    Key_OEM_CLEAR = true;
            }
            if (KeyboardHookButtonUp)
            {
                if (scanCode == S_LBUTTON)
                    Key_LBUTTON = false;
                if (scanCode == S_RBUTTON)
                    Key_RBUTTON = false;
                if (scanCode == S_CANCEL)
                    Key_CANCEL = false;
                if (scanCode == S_MBUTTON)
                    Key_MBUTTON = false;
                if (scanCode == S_XBUTTON1)
                    Key_XBUTTON1 = false;
                if (scanCode == S_XBUTTON2)
                    Key_XBUTTON2 = false;
                if (scanCode == S_BACK)
                    Key_BACK = false;
                if (scanCode == S_Tab)
                    Key_Tab = false;
                if (scanCode == S_CLEAR)
                    Key_CLEAR = false;
                if (scanCode == S_Return)
                    Key_Return = false;
                if (scanCode == S_SHIFT)
                    Key_SHIFT = false;
                if (scanCode == S_CONTROL)
                    Key_CONTROL = false;
                if (scanCode == S_MENU)
                    Key_MENU = false;
                if (scanCode == S_PAUSE)
                    Key_PAUSE = false;
                if (scanCode == S_CAPITAL)
                    Key_CAPITAL = false;
                if (scanCode == S_KANA)
                    Key_KANA = false;
                if (scanCode == S_HANGEUL)
                    Key_HANGEUL = false;
                if (scanCode == S_HANGUL)
                    Key_HANGUL = false;
                if (scanCode == S_JUNJA)
                    Key_JUNJA = false;
                if (scanCode == S_FINAL)
                    Key_FINAL = false;
                if (scanCode == S_HANJA)
                    Key_HANJA = false;
                if (scanCode == S_KANJI)
                    Key_KANJI = false;
                if (scanCode == S_Escape)
                    Key_Escape = false;
                if (scanCode == S_CONVERT)
                    Key_CONVERT = false;
                if (scanCode == S_NONCONVERT)
                    Key_NONCONVERT = false;
                if (scanCode == S_ACCEPT)
                    Key_ACCEPT = false;
                if (scanCode == S_MODECHANGE)
                    Key_MODECHANGE = false;
                if (scanCode == S_Space)
                    Key_Space = false;
                if (scanCode == S_PRIOR)
                    Key_PRIOR = false;
                if (scanCode == S_NEXT)
                    Key_NEXT = false;
                if (scanCode == S_END)
                    Key_END = false;
                if (scanCode == S_HOME)
                    Key_HOME = false;
                if (scanCode == S_LEFT)
                    Key_LEFT = false;
                if (scanCode == S_UP)
                    Key_UP = false;
                if (scanCode == S_RIGHT)
                    Key_RIGHT = false;
                if (scanCode == S_DOWN)
                    Key_DOWN = false;
                if (scanCode == S_SELECT)
                    Key_SELECT = false;
                if (scanCode == S_PRINT)
                    Key_PRINT = false;
                if (scanCode == S_EXECUTE)
                    Key_EXECUTE = false;
                if (scanCode == S_SNAPSHOT)
                    Key_SNAPSHOT = false;
                if (scanCode == S_INSERT)
                    Key_INSERT = false;
                if (scanCode == S_DELETE)
                    Key_DELETE = false;
                if (scanCode == S_HELP)
                    Key_HELP = false;
                if (scanCode == S_APOSTROPHE)
                    Key_APOSTROPHE = false;
                if (scanCode == S_0)
                    Key_0 = false;
                if (scanCode == S_1)
                    Key_1 = false;
                if (scanCode == S_2)
                    Key_2 = false;
                if (scanCode == S_3)
                    Key_3 = false;
                if (scanCode == S_4)
                    Key_4 = false;
                if (scanCode == S_5)
                    Key_5 = false;
                if (scanCode == S_6)
                    Key_6 = false;
                if (scanCode == S_7)
                    Key_7 = false;
                if (scanCode == S_8)
                    Key_8 = false;
                if (scanCode == S_9)
                    Key_9 = false;
                if (scanCode == S_A)
                    Key_A = false;
                if (scanCode == S_B)
                    Key_B = false;
                if (scanCode == S_C)
                    Key_C = false;
                if (scanCode == S_D)
                    Key_D = false;
                if (scanCode == S_E)
                    Key_E = false;
                if (scanCode == S_F)
                    Key_F = false;
                if (scanCode == S_G)
                    Key_G = false;
                if (scanCode == S_H)
                    Key_H = false;
                if (scanCode == S_I)
                    Key_I = false;
                if (scanCode == S_J)
                    Key_J = false;
                if (scanCode == S_K)
                    Key_K = false;
                if (scanCode == S_L)
                    Key_L = false;
                if (scanCode == S_M)
                    Key_M = false;
                if (scanCode == S_N)
                    Key_N = false;
                if (scanCode == S_O)
                    Key_O = false;
                if (scanCode == S_P)
                    Key_P = false;
                if (scanCode == S_Q)
                    Key_Q = false;
                if (scanCode == S_R)
                    Key_R = false;
                if (scanCode == S_S)
                    Key_S = false;
                if (scanCode == S_T)
                    Key_T = false;
                if (scanCode == S_U)
                    Key_U = false;
                if (scanCode == S_V)
                    Key_V = false;
                if (scanCode == S_W)
                    Key_W = false;
                if (scanCode == S_X)
                    Key_X = false;
                if (scanCode == S_Y)
                    Key_Y = false;
                if (scanCode == S_Z)
                    Key_Z = false;
                if (scanCode == S_LWIN)
                    Key_LWIN = false;
                if (scanCode == S_RWIN)
                    Key_RWIN = false;
                if (scanCode == S_APPS)
                    Key_APPS = false;
                if (scanCode == S_SLEEP)
                    Key_SLEEP = false;
                if (scanCode == S_NUMPAD0)
                    Key_NUMPAD0 = false;
                if (scanCode == S_NUMPAD1)
                    Key_NUMPAD1 = false;
                if (scanCode == S_NUMPAD2)
                    Key_NUMPAD2 = false;
                if (scanCode == S_NUMPAD3)
                    Key_NUMPAD3 = false;
                if (scanCode == S_NUMPAD4)
                    Key_NUMPAD4 = false;
                if (scanCode == S_NUMPAD5)
                    Key_NUMPAD5 = false;
                if (scanCode == S_NUMPAD6)
                    Key_NUMPAD6 = false;
                if (scanCode == S_NUMPAD7)
                    Key_NUMPAD7 = false;
                if (scanCode == S_NUMPAD8)
                    Key_NUMPAD8 = false;
                if (scanCode == S_NUMPAD9)
                    Key_NUMPAD9 = false;
                if (scanCode == S_MULTIPLY)
                    Key_MULTIPLY = false;
                if (scanCode == S_ADD)
                    Key_ADD = false;
                if (scanCode == S_SEPARATOR)
                    Key_SEPARATOR = false;
                if (scanCode == S_SUBTRACT)
                    Key_SUBTRACT = false;
                if (scanCode == S_DECIMAL)
                    Key_DECIMAL = false;
                if (scanCode == S_DIVIDE)
                    Key_DIVIDE = false;
                if (scanCode == S_F1)
                    Key_F1 = false;
                if (scanCode == S_F2)
                    Key_F2 = false;
                if (scanCode == S_F3)
                    Key_F3 = false;
                if (scanCode == S_F4)
                    Key_F4 = false;
                if (scanCode == S_F5)
                    Key_F5 = false;
                if (scanCode == S_F6)
                    Key_F6 = false;
                if (scanCode == S_F7)
                    Key_F7 = false;
                if (scanCode == S_F8)
                    Key_F8 = false;
                if (scanCode == S_F9)
                    Key_F9 = false;
                if (scanCode == S_F10)
                    Key_F10 = false;
                if (scanCode == S_F11)
                    Key_F11 = false;
                if (scanCode == S_F12)
                    Key_F12 = false;
                if (scanCode == S_F13)
                    Key_F13 = false;
                if (scanCode == S_F14)
                    Key_F14 = false;
                if (scanCode == S_F15)
                    Key_F15 = false;
                if (scanCode == S_F16)
                    Key_F16 = false;
                if (scanCode == S_F17)
                    Key_F17 = false;
                if (scanCode == S_F18)
                    Key_F18 = false;
                if (scanCode == S_F19)
                    Key_F19 = false;
                if (scanCode == S_F20)
                    Key_F20 = false;
                if (scanCode == S_F21)
                    Key_F21 = false;
                if (scanCode == S_F22)
                    Key_F22 = false;
                if (scanCode == S_F23)
                    Key_F23 = false;
                if (scanCode == S_F24)
                    Key_F24 = false;
                if (scanCode == S_NUMLOCK)
                    Key_NUMLOCK = false;
                if (scanCode == S_SCROLL)
                    Key_SCROLL = false;
                if (scanCode == S_LeftShift)
                    Key_LeftShift = false;
                if (scanCode == S_RightShift)
                    Key_RightShift = false;
                if (scanCode == S_LeftControl)
                    Key_LeftControl = false;
                if (scanCode == S_RightControl)
                    Key_RightControl = false;
                if (scanCode == S_LMENU)
                    Key_LMENU = false;
                if (scanCode == S_RMENU)
                    Key_RMENU = false;
                if (scanCode == S_BROWSER_BACK)
                    Key_BROWSER_BACK = false;
                if (scanCode == S_BROWSER_FORWARD)
                    Key_BROWSER_FORWARD = false;
                if (scanCode == S_BROWSER_REFRESH)
                    Key_BROWSER_REFRESH = false;
                if (scanCode == S_BROWSER_STOP)
                    Key_BROWSER_STOP = false;
                if (scanCode == S_BROWSER_SEARCH)
                    Key_BROWSER_SEARCH = false;
                if (scanCode == S_BROWSER_FAVORITES)
                    Key_BROWSER_FAVORITES = false;
                if (scanCode == S_BROWSER_HOME)
                    Key_BROWSER_HOME = false;
                if (scanCode == S_VOLUME_MUTE)
                    Key_VOLUME_MUTE = false;
                if (scanCode == S_VOLUME_DOWN)
                    Key_VOLUME_DOWN = false;
                if (scanCode == S_VOLUME_UP)
                    Key_VOLUME_UP = false;
                if (scanCode == S_MEDIA_NEXT_TRACK)
                    Key_MEDIA_NEXT_TRACK = false;
                if (scanCode == S_MEDIA_PREV_TRACK)
                    Key_MEDIA_PREV_TRACK = false;
                if (scanCode == S_MEDIA_STOP)
                    Key_MEDIA_STOP = false;
                if (scanCode == S_MEDIA_PLAY_PAUSE)
                    Key_MEDIA_PLAY_PAUSE = false;
                if (scanCode == S_LAUNCH_MAIL)
                    Key_LAUNCH_MAIL = false;
                if (scanCode == S_LAUNCH_MEDIA_SELECT)
                    Key_LAUNCH_MEDIA_SELECT = false;
                if (scanCode == S_LAUNCH_APP1)
                    Key_LAUNCH_APP1 = false;
                if (scanCode == S_LAUNCH_APP2)
                    Key_LAUNCH_APP2 = false;
                if (scanCode == S_OEM_1)
                    Key_OEM_1 = false;
                if (scanCode == S_OEM_PLUS)
                    Key_OEM_PLUS = false;
                if (scanCode == S_OEM_COMMA)
                    Key_OEM_COMMA = false;
                if (scanCode == S_OEM_MINUS)
                    Key_OEM_MINUS = false;
                if (scanCode == S_OEM_PERIOD)
                    Key_OEM_PERIOD = false;
                if (scanCode == S_OEM_2)
                    Key_OEM_2 = false;
                if (scanCode == S_OEM_3)
                    Key_OEM_3 = false;
                if (scanCode == S_OEM_4)
                    Key_OEM_4 = false;
                if (scanCode == S_OEM_5)
                    Key_OEM_5 = false;
                if (scanCode == S_OEM_6)
                    Key_OEM_6 = false;
                if (scanCode == S_OEM_7)
                    Key_OEM_7 = false;
                if (scanCode == S_OEM_8)
                    Key_OEM_8 = false;
                if (scanCode == S_OEM_102)
                    Key_OEM_102 = false;
                if (scanCode == S_PROCESSKEY)
                    Key_PROCESSKEY = false;
                if (scanCode == S_PACKET)
                    Key_PACKET = false;
                if (scanCode == S_ATTN)
                    Key_ATTN = false;
                if (scanCode == S_CRSEL)
                    Key_CRSEL = false;
                if (scanCode == S_EXSEL)
                    Key_EXSEL = false;
                if (scanCode == S_EREOF)
                    Key_EREOF = false;
                if (scanCode == S_PLAY)
                    Key_PLAY = false;
                if (scanCode == S_ZOOM)
                    Key_ZOOM = false;
                if (scanCode == S_NONAME)
                    Key_NONAME = false;
                if (scanCode == S_PA1)
                    Key_PA1 = false;
                if (scanCode == S_OEM_CLEAR)
                    Key_OEM_CLEAR = false;
            }
        }
        [DllImport("LeftJoyconPairing.dll", EntryPoint = "disconnectLeft")]
        public static extern bool disconnectLeft();
        [DllImport("LeftJoyconPairing.dll", EntryPoint = "lconnect")]
        public static extern bool lconnect();
        [DllImport("hid.dll")]
        public static extern void HidD_GetHidGuid(out Guid gHid);
        [DllImport("hid.dll")]
        public extern static bool HidD_SetOutputReport(IntPtr HidDeviceObject, byte[] lpReportBuffer, uint ReportBufferLength);
        [DllImport("setupapi.dll")]
        public static extern IntPtr SetupDiGetClassDevs(ref Guid ClassGuid, string Enumerator, IntPtr hwndParent, UInt32 Flags);
        [DllImport("setupapi.dll")]
        private static extern Boolean SetupDiEnumDeviceInterfaces(IntPtr hDevInfo, IntPtr devInvo, ref Guid interfaceClassGuid, Int32 memberIndex, ref SP_DEVICE_INTERFACE_DATA deviceInterfaceData);
        [DllImport("setupapi.dll")]
        private static extern Boolean SetupDiGetDeviceInterfaceDetail(IntPtr hDevInfo, ref SP_DEVICE_INTERFACE_DATA deviceInterfaceData, IntPtr deviceInterfaceDetailData, UInt32 deviceInterfaceDetailDataSize, out UInt32 requiredSize, IntPtr deviceInfoData);
        [DllImport("setupapi.dll")]
        private static extern Boolean SetupDiGetDeviceInterfaceDetail(IntPtr hDevInfo, ref SP_DEVICE_INTERFACE_DATA deviceInterfaceData, ref SP_DEVICE_INTERFACE_DETAIL_DATA deviceInterfaceDetailData, UInt32 deviceInterfaceDetailDataSize, out UInt32 requiredSize, IntPtr deviceInfoData);
        [DllImport("Kernel32.dll")]
        public static extern SafeFileHandle CreateFile(string fileName, [MarshalAs(UnmanagedType.U4)] FileAccess fileAccess, [MarshalAs(UnmanagedType.U4)] FileShare fileShare, IntPtr securityAttributes, [MarshalAs(UnmanagedType.U4)] FileMode creationDisposition, [MarshalAs(UnmanagedType.U4)] uint flags, IntPtr template);
        [DllImport("Kernel32.dll")]
        public static extern IntPtr CreateFile(string fileName, System.IO.FileAccess fileAccess, System.IO.FileShare fileShare, IntPtr securityAttributes, System.IO.FileMode creationDisposition, EFileAttributes flags, IntPtr template);
        [DllImport("lhidread.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "Lhid_read_timeout")]
        public static unsafe extern int Lhid_read_timeout(SafeFileHandle dev, byte[] data, UIntPtr length);
        [DllImport("lhidread.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "Lhid_write")]
        public static unsafe extern int Lhid_write(SafeFileHandle device, byte[] data, UIntPtr length);
        [DllImport("lhidread.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "Lhid_open_path")]
        public static unsafe extern SafeFileHandle Lhid_open_path(IntPtr handle);
        [DllImport("lhidread.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "Lhid_close")]
        public static unsafe extern void Lhid_close(SafeFileHandle device);
        public static bool LeftButtonSMA, LeftButtonACC, LeftRollLeft, LeftRollRight, joyconleftconnected;
        public static System.Collections.Generic.List<double> LeftValListX = new System.Collections.Generic.List<double>(), LeftValListY = new System.Collections.Generic.List<double>();
        public static System.Collections.Generic.List<double> valListXLeft = new System.Collections.Generic.List<double>(), valListYLeft = new System.Collections.Generic.List<double>();
        public static void connectingJoyconLeft()
        {
            joyconleftconnected = lconnect();
            if (joyconleftconnected)
                ScanLeft();
        }
        public static void InitLeftJoycon()
        {
            try
            {
                stick_rawLeft[0] = report_bufLeft[6 + (ISLEFT ? 0 : 3)];
                stick_rawLeft[1] = report_bufLeft[7 + (ISLEFT ? 0 : 3)];
                stick_rawLeft[2] = report_bufLeft[8 + (ISLEFT ? 0 : 3)];
                stick_calibrationLeft[0] = (UInt16)(stick_rawLeft[0] | ((stick_rawLeft[1] & 0xf) << 8));
                stick_calibrationLeft[1] = (UInt16)((stick_rawLeft[1] >> 4) | (stick_rawLeft[2] << 4));
                gyr_gcalibrationLeftX = (Int16)(report_bufLeft[19] | ((report_bufLeft[20] << 8) & 0xff00));
                gyr_gcalibrationLeftY = (Int16)(report_bufLeft[21] | ((report_bufLeft[22] << 8) & 0xff00));
                gyr_gcalibrationLeftZ = (Int16)(report_bufLeft[23] | ((report_bufLeft[24] << 8) & 0xff00));
                acc_gcalibrationLeftX = (Int16)(report_bufLeft[13] | ((report_bufLeft[14] << 8) & 0xff00));
                acc_gcalibrationLeftY = (Int16)(report_bufLeft[15] | ((report_bufLeft[16] << 8) & 0xff00));
                acc_gcalibrationLeftZ = (Int16)(report_bufLeft[17] | ((report_bufLeft[18] << 8) & 0xff00));
                acc_gLeft.X = ((Int16)(report_bufLeft[13] | ((report_bufLeft[14] << 8) & 0xff00)) - acc_gcalibrationLeftX) * (1.0f / 4000f);
                acc_gLeft.Y = -((Int16)(report_bufLeft[15] | ((report_bufLeft[16] << 8) & 0xff00)) - acc_gcalibrationLeftY) * (1.0f / 4000f);
                acc_gLeft.Z = -((Int16)(report_bufLeft[17] | ((report_bufLeft[18] << 8) & 0xff00)) - acc_gcalibrationLeftZ) * (1.0f / 4000f);
                InitDirectAnglesLeft = acc_gLeft;
            }
            catch { }
        }
        public static void ProcessButtonsLeftJoycon()
        {
            try
            {
                acc_gLeft.X = ((Int16)(report_bufLeft[13] | ((report_bufLeft[14] << 8) & 0xff00)) - acc_gcalibrationLeftX) * (1.0f / 4000f);
                acc_gLeft.Y = ((Int16)(report_bufLeft[15] | ((report_bufLeft[16] << 8) & 0xff00)) - acc_gcalibrationLeftY) * (1.0f / 4000f);
                acc_gLeft.Z = ((Int16)(report_bufLeft[17] | ((report_bufLeft[18] << 8) & 0xff00)) - acc_gcalibrationLeftZ) * (1.0f / 4000f);
                stick_rawLeft[0] = report_bufLeft[6 + (ISLEFT ? 0 : 3)];
                stick_rawLeft[1] = report_bufLeft[7 + (ISLEFT ? 0 : 3)];
                stick_rawLeft[2] = report_bufLeft[8 + (ISLEFT ? 0 : 3)];
                stick_precalLeft[0] = (UInt16)(stick_rawLeft[0] | ((stick_rawLeft[1] & 0xf) << 8));
                stick_precalLeft[1] = (UInt16)((stick_rawLeft[1] >> 4) | (stick_rawLeft[2] << 4));
                stickLeft = CenterSticksLeft(stick_precalLeft);
                LeftButtonSHOULDER_1 = (report_bufLeft[3 + (ISLEFT ? 2 : 0)] & 0x40) != 0;
                LeftButtonSHOULDER_2 = (report_bufLeft[3 + (ISLEFT ? 2 : 0)] & 0x80) != 0;
                LeftButtonSR = (report_bufLeft[3 + (ISLEFT ? 2 : 0)] & 0x10) != 0;
                LeftButtonSL = (report_bufLeft[3 + (ISLEFT ? 2 : 0)] & 0x20) != 0;
                LeftButtonDPAD_DOWN = (report_bufLeft[3 + (ISLEFT ? 2 : 0)] & (ISLEFT ? 0x01 : 0x04)) != 0;
                LeftButtonDPAD_RIGHT = (report_bufLeft[3 + (ISLEFT ? 2 : 0)] & (ISLEFT ? 0x04 : 0x08)) != 0;
                LeftButtonDPAD_UP = (report_bufLeft[3 + (ISLEFT ? 2 : 0)] & (ISLEFT ? 0x02 : 0x02)) != 0;
                LeftButtonDPAD_LEFT = (report_bufLeft[3 + (ISLEFT ? 2 : 0)] & (ISLEFT ? 0x08 : 0x01)) != 0;
                LeftButtonMINUS = (report_bufLeft[4] & 0x01) != 0;
                LeftButtonCAPTURE = (report_bufLeft[4] & 0x20) != 0;
                LeftButtonSTICK = (report_bufLeft[4] & (ISLEFT ? 0x08 : 0x04)) != 0;
                LeftButtonACC = acc_gLeft.X <= -1.13;
                LeftButtonSMA = LeftButtonSL | LeftButtonSR | LeftButtonMINUS | LeftButtonACC;
                if (LeftValListY.Count >= 50)
                {
                    LeftValListY.RemoveAt(0);
                    LeftValListY.Add(acc_gLeft.Y);
                }
                else
                    LeftValListY.Add(acc_gLeft.Y);
                LeftRollLeft = LeftValListY.Average() <= -0.75f;
                LeftRollRight = LeftValListY.Average() >= 0.75f;
                DirectAnglesLeft = acc_gLeft - InitDirectAnglesLeft;
                if (valListXLeft.Count >= 50)
                {
                    valListXLeft.RemoveAt(0);
                    valListXLeft.Add(DirectAnglesLeft.X * 1350f);
                }
                else
                    valListXLeft.Add(DirectAnglesLeft.X * 1350f);
                if (valListYLeft.Count >= 50)
                {
                    valListYLeft.RemoveAt(0);
                    valListYLeft.Add(-(DirectAnglesLeft.Y * 1350f / 0.5f));
                }
                else
                    valListYLeft.Add(-(DirectAnglesLeft.Y * 1350f / 0.5f));
                LeftAccelX = valListXLeft.Average();
                LeftAccelY = valListYLeft.Average();
                if (LeftAccelX >= 1024f)
                    LeftAccelX = 1024f;
                if (LeftAccelX <= -1024f)
                    LeftAccelX = -1024f;
                if (LeftAccelY >= 1024f)
                    LeftAccelY = 1024f;
                if (LeftAccelY <= -1024f)
                    LeftAccelY = -1024f;
                LeftGyroX = -EulerAnglesLeft.X * 1024f * 250f;
                LeftGyroY = -EulerAnglesLeft.Z * 1024f * 300f;
                if (LeftGyroX >= 1024f)
                    LeftGyroX = 1024f;
                if (LeftGyroX <= -1024f)
                    LeftGyroX = -1024f;
                if (LeftGyroY >= 1024f)
                    LeftGyroY = 1024f;
                if (LeftGyroY <= -1024f)
                    LeftGyroY = -1024f;
            }
            catch { }
        }
        public static void DataLeftJoycon()
        {
            try
            {
                Lhid_read_timeout(handleLeft, report_bufLeft, (UIntPtr)report_lenLeft);
                ExtractIMUValuesLeft();
            }
            catch
            {
                System.Threading.Thread.Sleep(1);
            }
        }
        public static void FormCloseLeft()
        {
            try
            {
                Lhid_close(handleLeft);
                handleLeft.Close();
                disconnectLeft();
                joyconleftconnected = false;
            }
            catch { }
        }
        public static Quaternion GetVectoraLeft()
        {
            Vector3 v1 = new Vector3(j_aLeft.X, i_aLeft.X, k_aLeft.X);
            Vector3 v2 = -(new Vector3(j_aLeft.Z, i_aLeft.Z, k_aLeft.Z));
            return QuaternionLookRotationLeft(v1, v2);
        }
        public static Quaternion GetVectorbLeft()
        {
            Vector3 v1 = new Vector3(j_bLeft.X, i_bLeft.X, k_bLeft.X);
            Vector3 v2 = -(new Vector3(j_bLeft.Z, i_bLeft.Z, k_bLeft.Z));
            return QuaternionLookRotationLeft(v1, v2);
        }
        public static Quaternion GetVectorcLeft()
        {
            Vector3 v1 = new Vector3(j_cLeft.X, i_cLeft.X, k_cLeft.X);
            Vector3 v2 = -(new Vector3(j_cLeft.Z, i_cLeft.Z, k_cLeft.Z));
            return QuaternionLookRotationLeft(v1, v2);
        }
        public static Quaternion QuaternionLookRotationLeft(Vector3 forward, Vector3 up)
        {
            Vector3 vector = Vector3.Normalize(forward);
            Vector3 vector2 = Vector3.Normalize(Vector3.Cross(up, vector));
            Vector3 vector3 = Vector3.Cross(vector, vector2);
            var m00 = vector2.X;
            var m01 = vector2.Y;
            var m02 = vector2.Z;
            var m10 = vector3.X;
            var m11 = vector3.Y;
            var m12 = vector3.Z;
            var m20 = vector.X;
            var m21 = vector.Y;
            var m22 = vector.Z;
            double num8 = (m00 + m11) + m22;
            var quaternion = new Quaternion();
            if (num8 > 0f)
            {
                var num = (double)Math.Sqrt(num8 + 1f);
                quaternion.W = (float)num * 0.5f;
                num = 0.5f / num;
                quaternion.X = (float)(m12 - m21) * (float)num;
                quaternion.Y = (float)(m20 - m02) * (float)num;
                quaternion.Z = (float)(m01 - m10) * (float)num;
                return quaternion;
            }
            if ((m00 >= m11) && (m00 >= m22))
            {
                var num7 = (double)Math.Sqrt(((1f + m00) - m11) - m22);
                var num4 = 0.5f / num7;
                quaternion.X = 0.5f * (float)num7;
                quaternion.Y = (float)(m01 + m10) * (float)num4;
                quaternion.Z = (float)(m02 + m20) * (float)num4;
                quaternion.W = (float)(m12 - m21) * (float)num4;
                return quaternion;
            }
            if (m11 > m22)
            {
                var num6 = (double)Math.Sqrt(((1f + m11) - m00) - m22);
                var num3 = 0.5f / num6;
                quaternion.X = (float)(m10 + m01) * (float)num3;
                quaternion.Y = 0.5f * (float)num6;
                quaternion.Z = (float)(m21 + m12) * (float)num3;
                quaternion.W = (float)(m20 - m02) * (float)num3;
                return quaternion;
            }
            var num5 = (double)Math.Sqrt(((1f + m22) - m00) - m11);
            var num2 = 0.5f / num5;
            quaternion.X = (float)(m20 + m02) * (float)num2;
            quaternion.Y = (float)(m21 + m12) * (float)num2;
            quaternion.Z = 0.5f * (float)num5;
            quaternion.W = (float)(m01 - m10) * (float)num2;
            return quaternion;
        }
        public static Vector3 ToEulerAnglesLeft(Quaternion q)
        {
            Vector3 pitchYawRoll = new Vector3();
            double sqw = q.W * q.W;
            double sqx = q.X * q.X;
            double sqy = q.Y * q.Y;
            double sqz = q.Z * q.Z;
            double unit = sqx + sqy + sqz + sqw;
            double test = q.X * q.Y + q.Z * q.W;
            if (test > 0.4999f * unit)
            {
                pitchYawRoll.Y = 2f * (float)Math.Atan2(q.X, q.W);
                pitchYawRoll.X = (float)Math.PI * 0.5f;
                pitchYawRoll.Z = 0f;
                return pitchYawRoll;
            }
            else if (test < -0.4999f * unit)
            {
                pitchYawRoll.Y = -2f * (float)Math.Atan2(q.X, q.W);
                pitchYawRoll.X = -(float)Math.PI * 0.5f;
                pitchYawRoll.Z = 0f;
                return pitchYawRoll;
            }
            else
            {
                pitchYawRoll.Y = (float)Math.Atan2(2f * q.Y * q.W - 2f * q.X * q.Z, sqx - sqy - sqz + sqw);
                pitchYawRoll.X = (float)Math.Asin(2f * test / unit);
                pitchYawRoll.Z = (float)Math.Atan2(2f * q.X * q.W - 2f * q.Y * q.Z, -sqx + sqy - sqz + sqw);
            }
            return pitchYawRoll;
        }
        public static void ExtractIMUValuesLeft()
        {
            gyr_gLeft.X = ((Int16)(report_bufLeft[19] | ((report_bufLeft[20] << 8) & 0xff00)) - gyr_gcalibrationLeftX) * (1.0f / 4000000f);
            gyr_gLeft.Y = ((Int16)(report_bufLeft[21] | ((report_bufLeft[22] << 8) & 0xff00)) - gyr_gcalibrationLeftY) * (1.0f / 4000000f);
            gyr_gLeft.Z = ((Int16)(report_bufLeft[23] | ((report_bufLeft[24] << 8) & 0xff00)) - gyr_gcalibrationLeftZ) * (1.0f / 4000000f);
            i_cLeft = new Vector3(1, 0, 0);
            k_cLeft = new Vector3(0, 0, 1);
            j_cLeft.X = 0f;
            j_cLeft.Y = 1f;
            i_bLeft = new Vector3(1, 0, 0);
            k_bLeft = new Vector3(0, 0, 1);
            j_bLeft.Y = 1f;
            j_bLeft.Z = 0f;
            i_aLeft = new Vector3(1, 0, 0);
            j_aLeft = new Vector3(0, 1, 0);
            k_aLeft.Y = 0f;
            k_aLeft.Z = 1f;
            if (EulerAnglescLeft.Y == 0f)
                j_cLeft = new Vector3(0, 1, 0);
            if (EulerAnglesbLeft.X == 0f)
                j_bLeft = new Vector3(0, 1, 0);
            if (EulerAnglesaLeft.Z == 0f)
                k_aLeft = new Vector3(0, 0, 1);
            if (LeftButtonDPAD_UP)
            {
                j_cLeft = new Vector3(0, 1, 0);
                InitEulerAnglescLeft = ToEulerAnglesLeft(GetVectorcLeft());
                j_bLeft = new Vector3(0, 1, 0);
                InitEulerAnglesbLeft = ToEulerAnglesLeft(GetVectorbLeft());
                k_aLeft = new Vector3(0, 0, 1);
                InitEulerAnglesaLeft = ToEulerAnglesLeft(GetVectoraLeft());
            }
            j_cLeft += Vector3.Cross(Vector3.Negate(gyr_gLeft), j_cLeft);
            j_cLeft = Vector3.Normalize(j_cLeft);
            EulerAnglescLeft = ToEulerAnglesLeft(GetVectorcLeft()) - InitEulerAnglescLeft;
            j_bLeft += Vector3.Cross(Vector3.Negate(gyr_gLeft), j_bLeft);
            j_bLeft = Vector3.Normalize(j_bLeft);
            EulerAnglesbLeft = ToEulerAnglesLeft(GetVectorbLeft()) - InitEulerAnglesbLeft;
            k_aLeft += Vector3.Cross(Vector3.Negate(gyr_gLeft), k_aLeft);
            k_aLeft = Vector3.Normalize(k_aLeft);
            EulerAnglesaLeft = ToEulerAnglesLeft(GetVectoraLeft()) - InitEulerAnglesaLeft;
            EulerAnglesLeft = new Vector3(EulerAnglesbLeft.X, EulerAnglescLeft.Y, EulerAnglesaLeft.Z);
        }
        public const string vendor_id = "57e", vendor_id_ = "057e", product_r1 = "0330", product_r2 = "0306", product_l = "2006", product_r = "2007";
        public enum EFileAttributes : uint
        {
            Overlapped = 0x40000000,
            Normal = 0x80
        };
        struct SP_DEVICE_INTERFACE_DATA
        {
            public int cbSize;
            public Guid InterfaceClassGuid;
            public int Flags;
            public IntPtr RESERVED;
        }
        struct SP_DEVICE_INTERFACE_DETAIL_DATA
        {
            public UInt32 cbSize;
            [System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValTStr, SizeConst = 256)]
            public string DevicePath;
        }
        public static double[] CenterSticksLeft(UInt16[] vals)
        {
            double[] s = { 0, 0 };
            s[0] = ((int)((vals[0] - stick_calibrationLeft[0]) / 100f)) / 13f;
            s[1] = ((int)((vals[1] - stick_calibrationLeft[1]) / 100f)) / 13f;
            return s;
        }
        public static double LeftAccelX, LeftAccelY, LeftGyroX, LeftGyroY;
        public static Vector3 InitEulerAnglesaLeft, EulerAnglesaLeft, InitEulerAnglesbLeft, EulerAnglesbLeft, InitEulerAnglescLeft, EulerAnglescLeft, EulerAnglesLeft;
        public static Vector3 gyr_gLeft = new Vector3();
        public static Vector3 i_aLeft = new Vector3(1, 0, 0);
        public static Vector3 j_aLeft = new Vector3(0, 1, 0);
        public static Vector3 k_aLeft = new Vector3(0, 0, 1);
        public static Vector3 i_bLeft = new Vector3(1, 0, 0);
        public static Vector3 j_bLeft = new Vector3(0, 1, 0);
        public static Vector3 k_bLeft = new Vector3(0, 0, 1);
        public static Vector3 i_cLeft = new Vector3(1, 0, 0);
        public static Vector3 j_cLeft = new Vector3(0, 1, 0);
        public static Vector3 k_cLeft = new Vector3(0, 0, 1);
        public static double[] stickLeft = { 0, 0 };
        public static SafeFileHandle handleLeft;
        public static Vector3 acc_gLeft = new Vector3();
        public static byte[] stick_rawLeft = { 0, 0, 0 };
        public static UInt16[] stick_calibrationLeft = { 0, 0 };
        public static UInt16[] stick_precalLeft = { 0, 0 };
        public const uint report_lenLeft = 25;
        public static Vector3 InitDirectAnglesLeft, DirectAnglesLeft;
        public static bool LeftButtonSHOULDER_1, LeftButtonSHOULDER_2, LeftButtonSR, LeftButtonSL, LeftButtonDPAD_DOWN, LeftButtonDPAD_RIGHT, LeftButtonDPAD_UP, LeftButtonDPAD_LEFT, LeftButtonMINUS, LeftButtonSTICK, LeftButtonCAPTURE, ISLEFT;
        public static byte[] report_bufLeft = new byte[report_lenLeft];
        public static byte[] buf_Left = new byte[report_lenLeft];
        public static float acc_gcalibrationLeftX, acc_gcalibrationLeftY, acc_gcalibrationLeftZ, gyr_gcalibrationLeftX, gyr_gcalibrationLeftY, gyr_gcalibrationLeftZ;
        public static double[] GetStickLeft()
        {
            return stickLeft;
        }
        public static bool ScanLeft()
        {
            int index = 0;
            System.Guid guid;
            HidD_GetHidGuid(out guid);
            System.IntPtr hDevInfo = SetupDiGetClassDevs(ref guid, null, new System.IntPtr(), 0x00000010);
            SP_DEVICE_INTERFACE_DATA diData = new SP_DEVICE_INTERFACE_DATA();
            diData.cbSize = System.Runtime.InteropServices.Marshal.SizeOf(diData);
            while (SetupDiEnumDeviceInterfaces(hDevInfo, new System.IntPtr(), ref guid, index, ref diData))
            {
                System.UInt32 size;
                SetupDiGetDeviceInterfaceDetail(hDevInfo, ref diData, new System.IntPtr(), 0, out size, new System.IntPtr());
                SP_DEVICE_INTERFACE_DETAIL_DATA diDetail = new SP_DEVICE_INTERFACE_DETAIL_DATA();
                diDetail.cbSize = 5;
                if (SetupDiGetDeviceInterfaceDetail(hDevInfo, ref diData, ref diDetail, size, out size, new System.IntPtr()))
                {
                    if ((diDetail.DevicePath.Contains(vendor_id) | diDetail.DevicePath.Contains(vendor_id_)) & diDetail.DevicePath.Contains(product_l))
                    {
                        ISLEFT = true;
                        AttachJoyLeft(diDetail.DevicePath);
                        AttachJoyLeft(diDetail.DevicePath);
                        AttachJoyLeft(diDetail.DevicePath);
                        return true;
                    }
                }
                index++;
            }
            return false;
        }
        public static void AttachJoyLeft(string path)
        {
            do
            {
                IntPtr handle = CreateFile(path, System.IO.FileAccess.ReadWrite, System.IO.FileShare.ReadWrite, new System.IntPtr(), System.IO.FileMode.Open, EFileAttributes.Normal, new System.IntPtr());
                handleLeft = Lhid_open_path(handle);
                SubcommandLeft(0x40, new byte[] { 0x1 }, 1);
                SubcommandLeft(0x3, new byte[] { 0x30 }, 1);
            }
            while (handleLeft.IsInvalid);
        }
        public static void SubcommandLeft(byte sc, byte[] buf, uint len)
        {
            System.Array.Copy(buf, 0, buf_Left, 11, len);
            buf_Left[0] = 0x1;
            buf_Left[1] = 0;
            buf_Left[10] = sc;
            Lhid_write(handleLeft, buf_Left, (UIntPtr)(len + 11));
            Lhid_read_timeout(handleLeft, buf_Left, (UIntPtr)report_lenLeft);
        }
        [DllImport("RightJoyconPairing.dll", EntryPoint = "rconnect")]
        public static extern bool rconnect();
        [DllImport("RightJoyconPairing.dll", EntryPoint = "disconnectRight")]
        public static extern bool disconnectRight();
        [DllImport("rhidread.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "Rhid_read_timeout")]
        public static unsafe extern int Rhid_read_timeout(SafeFileHandle dev, byte[] data, UIntPtr length);
        [DllImport("rhidread.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "Rhid_write")]
        public static unsafe extern int Rhid_write(SafeFileHandle device, byte[] data, UIntPtr length);
        [DllImport("rhidread.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "Rhid_open_path")]
        public static unsafe extern SafeFileHandle Rhid_open_path(IntPtr handle);
        [DllImport("rhidread.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "Rhid_close")]
        public static unsafe extern void Rhid_close(SafeFileHandle device);
        public static bool RightButtonSPA, RightButtonACC, RightRollLeft, RightRollRight, joyconrightconnected;
        public static System.Collections.Generic.List<double> RightValListX = new System.Collections.Generic.List<double>(), RightValListY = new System.Collections.Generic.List<double>();
        public static System.Collections.Generic.List<double> valListXRight = new System.Collections.Generic.List<double>(), valListYRight = new System.Collections.Generic.List<double>();
        public static void connectingJoyconRight()
        {
            joyconrightconnected = rconnect();
            if (joyconrightconnected)
                ScanRight();
        }
        public static void InitRightJoycon()
        {
            try
            {
                stick_rawRight[0] = report_bufRight[6 + (!ISRIGHT ? 0 : 3)];
                stick_rawRight[1] = report_bufRight[7 + (!ISRIGHT ? 0 : 3)];
                stick_rawRight[2] = report_bufRight[8 + (!ISRIGHT ? 0 : 3)];
                stick_calibrationRight[0] = (UInt16)(stick_rawRight[0] | ((stick_rawRight[1] & 0xf) << 8));
                stick_calibrationRight[1] = (UInt16)((stick_rawRight[1] >> 4) | (stick_rawRight[2] << 4));
                gyr_gcalibrationRightX = (Int16)(report_bufRight[19] | ((report_bufRight[20] << 8) & 0xff00));
                gyr_gcalibrationRightY = (Int16)(report_bufRight[21] | ((report_bufRight[22] << 8) & 0xff00));
                gyr_gcalibrationRightZ = (Int16)(report_bufRight[23] | ((report_bufRight[24] << 8) & 0xff00));
                acc_gcalibrationRightX = (Int16)(report_bufRight[13] | ((report_bufRight[14] << 8) & 0xff00));
                acc_gcalibrationRightY = (Int16)(report_bufRight[15] | ((report_bufRight[16] << 8) & 0xff00));
                acc_gcalibrationRightZ = (Int16)(report_bufRight[17] | ((report_bufRight[18] << 8) & 0xff00));
                acc_gRight.X = ((Int16)(report_bufRight[13] | ((report_bufRight[14] << 8) & 0xff00)) - acc_gcalibrationRightX) * (1.0f / 4000f);
                acc_gRight.Y = -((Int16)(report_bufRight[15] | ((report_bufRight[16] << 8) & 0xff00)) - acc_gcalibrationRightY) * (1.0f / 4000f);
                acc_gRight.Z = -((Int16)(report_bufRight[17] | ((report_bufRight[18] << 8) & 0xff00)) - acc_gcalibrationRightZ) * (1.0f / 4000f);
                InitDirectAnglesRight = acc_gRight;
            }
            catch { }
        }
        public static void ProcessButtonsRightJoycon()
        {
            try
            {
                acc_gRight.X = ((Int16)(report_bufRight[13] | ((report_bufRight[14] << 8) & 0xff00)) - acc_gcalibrationRightX) * (1.0f / 4000f);
                acc_gRight.Y = -((Int16)(report_bufRight[15] | ((report_bufRight[16] << 8) & 0xff00)) - acc_gcalibrationRightY) * (1.0f / 4000f);
                acc_gRight.Z = -((Int16)(report_bufRight[17] | ((report_bufRight[18] << 8) & 0xff00)) - acc_gcalibrationRightZ) * (1.0f / 4000f);
                stick_rawRight[0] = report_bufRight[6 + (!ISRIGHT ? 0 : 3)];
                stick_rawRight[1] = report_bufRight[7 + (!ISRIGHT ? 0 : 3)];
                stick_rawRight[2] = report_bufRight[8 + (!ISRIGHT ? 0 : 3)];
                stick_precalRight[0] = (UInt16)(stick_rawRight[0] | ((stick_rawRight[1] & 0xf) << 8));
                stick_precalRight[1] = (UInt16)((stick_rawRight[1] >> 4) | (stick_rawRight[2] << 4));
                stickRight = CenterSticksRight(stick_precalRight);
                RightButtonSHOULDER_1 = (report_bufRight[3 + (!ISRIGHT ? 2 : 0)] & 0x40) != 0;
                RightButtonSHOULDER_2 = (report_bufRight[3 + (!ISRIGHT ? 2 : 0)] & 0x80) != 0;
                RightButtonSR = (report_bufRight[3 + (!ISRIGHT ? 2 : 0)] & 0x10) != 0;
                RightButtonSL = (report_bufRight[3 + (!ISRIGHT ? 2 : 0)] & 0x20) != 0;
                RightButtonDPAD_DOWN = (report_bufRight[3 + (!ISRIGHT ? 2 : 0)] & (!ISRIGHT ? 0x01 : 0x04)) != 0;
                RightButtonDPAD_RIGHT = (report_bufRight[3 + (!ISRIGHT ? 2 : 0)] & (!ISRIGHT ? 0x04 : 0x08)) != 0;
                RightButtonDPAD_UP = (report_bufRight[3 + (!ISRIGHT ? 2 : 0)] & (!ISRIGHT ? 0x02 : 0x02)) != 0;
                RightButtonDPAD_LEFT = (report_bufRight[3 + (!ISRIGHT ? 2 : 0)] & (!ISRIGHT ? 0x08 : 0x01)) != 0;
                RightButtonPLUS = ((report_bufRight[4] & 0x02) != 0);
                RightButtonHOME = ((report_bufRight[4] & 0x10) != 0);
                RightButtonSTICK = ((report_bufRight[4] & (!ISRIGHT ? 0x08 : 0x04)) != 0);
                RightButtonACC = acc_gRight.X <= -1.13;
                RightButtonSPA = RightButtonSL | RightButtonSR | RightButtonPLUS | RightButtonACC;
                if (RightValListY.Count >= 50)
                {
                    RightValListY.RemoveAt(0);
                    RightValListY.Add(acc_gRight.Y);
                }
                else
                    RightValListY.Add(acc_gRight.Y);
                RightRollLeft = RightValListY.Average() <= -0.75f;
                RightRollRight = RightValListY.Average() >= 0.75f;
                DirectAnglesRight = acc_gRight - InitDirectAnglesRight;
                if (valListXRight.Count >= 50)
                {
                    valListXRight.RemoveAt(0);
                    valListXRight.Add(DirectAnglesRight.X * 1350f);
                }
                else
                    valListXRight.Add(DirectAnglesRight.X * 1350f);
                if (valListYRight.Count >= 50)
                {
                    valListYRight.RemoveAt(0);
                    valListYRight.Add(-(DirectAnglesRight.Y * 1350f / 0.5f));
                }
                else
                    valListYRight.Add(-(DirectAnglesRight.Y * 1350f / 0.5f));
                RightAccelX = valListXRight.Average();
                RightAccelY = valListYRight.Average();
                if (RightAccelX >= 1024f)
                    RightAccelX = 1024f;
                if (RightAccelX <= -1024f)
                    RightAccelX = -1024f;
                if (RightAccelY >= 1024f)
                    RightAccelY = 1024f;
                if (RightAccelY <= -1024f)
                    RightAccelY = -1024f;
                RightGyroX = -EulerAnglesRight.X * 1024f * 250f;
                RightGyroY = -EulerAnglesRight.Z * 1024f * 300f;
                if (RightGyroX >= 1024f)
                    RightGyroX = 1024f;
                if (RightGyroX <= -1024f)
                    RightGyroX = -1024f;
                if (RightGyroY >= 1024f)
                    RightGyroY = 1024f;
                if (RightGyroY <= -1024f)
                    RightGyroY = -1024f;
            }
            catch { }
        }
        public static void DataRightJoycon()
        {
            try
            {
                Rhid_read_timeout(handleRight, report_bufRight, (UIntPtr)report_lenRight);
                ExtractIMUValuesRight();
            }
            catch
            {
                System.Threading.Thread.Sleep(1);
            }
        }
        public static void FormCloseRight()
        {
            try
            {
                Rhid_close(handleRight);
                handleRight.Close();
                disconnectRight();
                joyconrightconnected = false;
            }
            catch { }
        }
        public static Quaternion GetVectoraRight()
        {
            Vector3 v1 = new Vector3(j_aRight.X, i_aRight.X, k_aRight.X);
            Vector3 v2 = -(new Vector3(j_aRight.Z, i_aRight.Z, k_aRight.Z));
            return QuaternionLookRotationRight(v1, v2);
        }
        public static Quaternion GetVectorbRight()
        {
            Vector3 v1 = new Vector3(j_bRight.X, i_bRight.X, k_bRight.X);
            Vector3 v2 = -(new Vector3(j_bRight.Z, i_bRight.Z, k_bRight.Z));
            return QuaternionLookRotationRight(v1, v2);
        }
        public static Quaternion GetVectorcRight()
        {
            Vector3 v1 = new Vector3(j_cRight.X, i_cRight.X, k_cRight.X);
            Vector3 v2 = -(new Vector3(j_cRight.Z, i_cRight.Z, k_cRight.Z));
            return QuaternionLookRotationRight(v1, v2);
        }
        public static Quaternion QuaternionLookRotationRight(Vector3 forward, Vector3 up)
        {
            Vector3 vector = Vector3.Normalize(forward);
            Vector3 vector2 = Vector3.Normalize(Vector3.Cross(up, vector));
            Vector3 vector3 = Vector3.Cross(vector, vector2);
            var m00 = vector2.X;
            var m01 = vector2.Y;
            var m02 = vector2.Z;
            var m10 = vector3.X;
            var m11 = vector3.Y;
            var m12 = vector3.Z;
            var m20 = vector.X;
            var m21 = vector.Y;
            var m22 = vector.Z;
            double num8 = (m00 + m11) + m22;
            var quaternion = new Quaternion();
            if (num8 > 0f)
            {
                var num = (double)Math.Sqrt(num8 + 1f);
                quaternion.W = (float)num * 0.5f;
                num = 0.5f / num;
                quaternion.X = (float)(m12 - m21) * (float)num;
                quaternion.Y = (float)(m20 - m02) * (float)num;
                quaternion.Z = (float)(m01 - m10) * (float)num;
                return quaternion;
            }
            if ((m00 >= m11) && (m00 >= m22))
            {
                var num7 = (double)Math.Sqrt(((1f + m00) - m11) - m22);
                var num4 = 0.5f / num7;
                quaternion.X = 0.5f * (float)num7;
                quaternion.Y = (float)(m01 + m10) * (float)num4;
                quaternion.Z = (float)(m02 + m20) * (float)num4;
                quaternion.W = (float)(m12 - m21) * (float)num4;
                return quaternion;
            }
            if (m11 > m22)
            {
                var num6 = (double)Math.Sqrt(((1f + m11) - m00) - m22);
                var num3 = 0.5f / num6;
                quaternion.X = (float)(m10 + m01) * (float)num3;
                quaternion.Y = 0.5f * (float)num6;
                quaternion.Z = (float)(m21 + m12) * (float)num3;
                quaternion.W = (float)(m20 - m02) * (float)num3;
                return quaternion;
            }
            var num5 = (double)Math.Sqrt(((1f + m22) - m00) - m11);
            var num2 = 0.5f / num5;
            quaternion.X = (float)(m20 + m02) * (float)num2;
            quaternion.Y = (float)(m21 + m12) * (float)num2;
            quaternion.Z = 0.5f * (float)num5;
            quaternion.W = (float)(m01 - m10) * (float)num2;
            return quaternion;
        }
        public static Vector3 ToEulerAnglesRight(Quaternion q)
        {
            Vector3 pitchYawRoll = new Vector3();
            double sqw = q.W * q.W;
            double sqx = q.X * q.X;
            double sqy = q.Y * q.Y;
            double sqz = q.Z * q.Z;
            double unit = sqx + sqy + sqz + sqw;
            double test = q.X * q.Y + q.Z * q.W;
            if (test > 0.4999f * unit)
            {
                pitchYawRoll.Y = 2f * (float)Math.Atan2(q.X, q.W);
                pitchYawRoll.X = (float)Math.PI * 0.5f;
                pitchYawRoll.Z = 0f;
                return pitchYawRoll;
            }
            else if (test < -0.4999f * unit)
            {
                pitchYawRoll.Y = -2f * (float)Math.Atan2(q.X, q.W);
                pitchYawRoll.X = -(float)Math.PI * 0.5f;
                pitchYawRoll.Z = 0f;
                return pitchYawRoll;
            }
            else
            {
                pitchYawRoll.Y = (float)Math.Atan2(2f * q.Y * q.W - 2f * q.X * q.Z, sqx - sqy - sqz + sqw);
                pitchYawRoll.X = (float)Math.Asin(2f * test / unit);
                pitchYawRoll.Z = (float)Math.Atan2(2f * q.X * q.W - 2f * q.Y * q.Z, -sqx + sqy - sqz + sqw);
            }
            return pitchYawRoll;
        }
        public static void ExtractIMUValuesRight()
        {
            gyr_gRight.X = ((Int16)(report_bufRight[19] | ((report_bufRight[20] << 8) & 0xff00)) - gyr_gcalibrationRightX) * (1.0f / 4000000f);
            gyr_gRight.Y = -((Int16)(report_bufRight[21] | ((report_bufRight[22] << 8) & 0xff00)) - gyr_gcalibrationRightY) * (1.0f / 4000000f);
            gyr_gRight.Z = -((Int16)(report_bufRight[23] | ((report_bufRight[24] << 8) & 0xff00)) - gyr_gcalibrationRightZ) * (1.0f / 4000000f);
            i_cRight = new Vector3(1, 0, 0);
            k_cRight = new Vector3(0, 0, 1);
            j_cRight.X = 0f;
            j_cRight.Y = 1f;
            i_bRight = new Vector3(1, 0, 0);
            k_bRight = new Vector3(0, 0, 1);
            j_bRight.Y = 1f;
            j_bRight.Z = 0f;
            i_aRight = new Vector3(1, 0, 0);
            j_aRight = new Vector3(0, 1, 0);
            k_aRight.Y = 0f;
            k_aRight.Z = 1f;
            if (EulerAnglescRight.Y == 0f)
                j_cRight = new Vector3(0, 1, 0);
            if (EulerAnglesbRight.X == 0f)
                j_bRight = new Vector3(0, 1, 0);
            if (EulerAnglesaRight.Z == 0f)
                k_aRight = new Vector3(0, 0, 1);
            if (RightButtonDPAD_UP)
            {
                j_cRight = new Vector3(0, 1, 0);
                InitEulerAnglescRight = ToEulerAnglesRight(GetVectorcRight());
                j_bRight = new Vector3(0, 1, 0);
                InitEulerAnglesbRight = ToEulerAnglesRight(GetVectorbRight());
                k_aRight = new Vector3(0, 0, 1);
                InitEulerAnglesaRight = ToEulerAnglesRight(GetVectoraRight());
            }
            j_cRight += Vector3.Cross(Vector3.Negate(gyr_gRight), j_cRight);
            j_cRight = Vector3.Normalize(j_cRight);
            EulerAnglescRight = ToEulerAnglesRight(GetVectorcRight()) - InitEulerAnglescRight;
            j_bRight += Vector3.Cross(Vector3.Negate(gyr_gRight), j_bRight);
            j_bRight = Vector3.Normalize(j_bRight);
            EulerAnglesbRight = ToEulerAnglesRight(GetVectorbRight()) - InitEulerAnglesbRight;
            k_aRight += Vector3.Cross(Vector3.Negate(gyr_gRight), k_aRight);
            k_aRight = Vector3.Normalize(k_aRight);
            EulerAnglesaRight = ToEulerAnglesRight(GetVectoraRight()) - InitEulerAnglesaRight;
            EulerAnglesRight = new Vector3(EulerAnglesbRight.X, EulerAnglescRight.Y, EulerAnglesaRight.Z);
        }
        public static double[] CenterSticksRight(UInt16[] vals)
        {
            double[] s = { 0, 0 };
            s[0] = ((int)((vals[0] - stick_calibrationRight[0]) / 100f)) / 13f;
            s[1] = ((int)((vals[1] - stick_calibrationRight[1]) / 100f)) / 13f;
            return s;
        }
        public static double RightAccelX, RightAccelY, RightGyroX, RightGyroY;
        public static Vector3 InitEulerAnglesaRight, EulerAnglesaRight, InitEulerAnglesbRight, EulerAnglesbRight, InitEulerAnglescRight, EulerAnglescRight, EulerAnglesRight;
        public static Vector3 gyr_gRight = new Vector3();
        public static Vector3 i_cRight = new Vector3(1, 0, 0);
        public static Vector3 j_cRight = new Vector3(0, 1, 0);
        public static Vector3 k_cRight = new Vector3(0, 0, 1);
        public static Vector3 i_bRight = new Vector3(1, 0, 0);
        public static Vector3 j_bRight = new Vector3(0, 1, 0);
        public static Vector3 k_bRight = new Vector3(0, 0, 1);
        public static Vector3 i_aRight = new Vector3(1, 0, 0);
        public static Vector3 j_aRight = new Vector3(0, 1, 0);
        public static Vector3 k_aRight = new Vector3(0, 0, 1);
        public static double[] stickRight = { 0, 0 };
        public static SafeFileHandle handleRight;
        public static byte[] stick_rawRight = { 0, 0, 0 };
        public static UInt16[] stick_calibrationRight = { 0, 0 };
        public static UInt16[] stick_precalRight = { 0, 0 };
        public static Vector3 acc_gRight = new Vector3();
        public const uint report_lenRight = 25;
        public static Vector3 InitDirectAnglesRight, DirectAnglesRight;
        public static bool RightButtonSHOULDER_1, RightButtonSHOULDER_2, RightButtonSR, RightButtonSL, RightButtonDPAD_DOWN, RightButtonDPAD_RIGHT, RightButtonDPAD_UP, RightButtonDPAD_LEFT, RightButtonPLUS, RightButtonSTICK, RightButtonHOME, ISRIGHT;
        public static byte[] report_bufRight = new byte[report_lenRight];
        public static byte[] buf_Right = new byte[report_lenRight];
        public static float acc_gcalibrationRightX, acc_gcalibrationRightY, acc_gcalibrationRightZ, gyr_gcalibrationRightX, gyr_gcalibrationRightY, gyr_gcalibrationRightZ;
        public static double[] GetStickRight()
        {
            return stickRight;
        }
        public static bool ScanRight()
        {
            int index = 0;
            System.Guid guid;
            HidD_GetHidGuid(out guid);
            System.IntPtr hDevInfo = SetupDiGetClassDevs(ref guid, null, new System.IntPtr(), 0x00000010);
            SP_DEVICE_INTERFACE_DATA diData = new SP_DEVICE_INTERFACE_DATA();
            diData.cbSize = System.Runtime.InteropServices.Marshal.SizeOf(diData);
            while (SetupDiEnumDeviceInterfaces(hDevInfo, new System.IntPtr(), ref guid, index, ref diData))
            {
                System.UInt32 size;
                SetupDiGetDeviceInterfaceDetail(hDevInfo, ref diData, new System.IntPtr(), 0, out size, new System.IntPtr());
                SP_DEVICE_INTERFACE_DETAIL_DATA diDetail = new SP_DEVICE_INTERFACE_DETAIL_DATA();
                diDetail.cbSize = 5;
                if (SetupDiGetDeviceInterfaceDetail(hDevInfo, ref diData, ref diDetail, size, out size, new System.IntPtr()))
                {
                    if ((diDetail.DevicePath.Contains(vendor_id) | diDetail.DevicePath.Contains(vendor_id_)) & diDetail.DevicePath.Contains(product_r))
                    {
                        ISRIGHT = true;
                        AttachJoyRight(diDetail.DevicePath);
                        AttachJoyRight(diDetail.DevicePath);
                        AttachJoyRight(diDetail.DevicePath);
                        return true;
                    }
                }
                index++;
            }
            return false;
        }
        public static void AttachJoyRight(string path)
        {
            do
            {
                IntPtr handle = CreateFile(path, System.IO.FileAccess.ReadWrite, System.IO.FileShare.ReadWrite, new System.IntPtr(), System.IO.FileMode.Open, EFileAttributes.Normal, new System.IntPtr());
                handleRight = Rhid_open_path(handle);
                SubcommandRight(0x40, new byte[] { 0x1 }, 1);
                SubcommandRight(0x3, new byte[] { 0x30 }, 1);
            }
            while (handleRight.IsInvalid);
        }
        public static void SubcommandRight(byte sc, byte[] buf, uint len)
        {
            System.Array.Copy(buf, 0, buf_Right, 11, len);
            buf_Right[0] = 0x1;
            buf_Right[1] = 0;
            buf_Right[10] = sc;
            Rhid_write(handleRight, buf_Right, (UIntPtr)(len + 11));
            Rhid_read_timeout(handleRight, buf_Right, (UIntPtr)report_lenRight);
        }
        [DllImport("WiimotePairing.dll", EntryPoint = "connect")]
        public static extern bool connect();
        [DllImport("WiimotePairing.dll", EntryPoint = "disconnect")]
        public static extern bool disconnect();
        public const double REGISTER_IR = 0x04b00030, REGISTER_EXTENSION_INIT_1 = 0x04a400f0, REGISTER_EXTENSION_INIT_2 = 0x04a400fb, REGISTER_EXTENSION_TYPE = 0x04a400fa, REGISTER_EXTENSION_CALIBRATION = 0x04a40020, REGISTER_MOTIONPLUS_INIT = 0x04a600fe;
        public static double irx0, iry0, irx1, iry1, irx, iry, irxc, iryc, mWSIRSensors0X, mWSIRSensors0Y, mWSIRSensors1X, mWSIRSensors1Y, mWSButtonStateIRX, mWSButtonStateIRY, mWSRawValuesX, mWSRawValuesY, mWSRawValuesZ, calibrationxinit, calibrationyinit, calibrationzinit, stickviewxinit, stickviewyinit, mWSNunchuckStateRawValuesX, mWSNunchuckStateRawValuesY, mWSNunchuckStateRawValuesZ, mWSNunchuckStateRawJoystickX, mWSNunchuckStateRawJoystickY, mousex, mousey, mWSIRSensors0Xcam, mWSIRSensors0Ycam, mWSIRSensors1Xcam, mWSIRSensors1Ycam, mWSIRSensorsXcam, mWSIRSensorsYcam, centery = 160f, mWSIR0notfound = 0, irx2, iry2, irx3, iry3;
        public static int irmode = 1;
        public static bool mWSIR1foundcam, mWSIR0foundcam, mWSIR1found, mWSIR0found, mWSIRswitch, mWSButtonStateA, mWSButtonStateB, mWSButtonStateMinus, mWSButtonStateHome, mWSButtonStatePlus, mWSButtonStateOne, mWSButtonStateTwo, mWSButtonStateUp, mWSButtonStateDown, mWSButtonStateLeft, mWSButtonStateRight, mWSNunchuckStateC, mWSNunchuckStateZ, running, wiimoteconnected;
        public static byte[] buff = new byte[] { 0x55 }, mBuff = new byte[22], aBuffer = new byte[22];
        public const byte Type = 0x12, IR = 0x13, WriteMemory = 0x16, ReadMemory = 0x16, IRExtensionAccel = 0x37;
        public static FileStream mStream;
        public static SafeFileHandle handle = null;
        public static System.Collections.Generic.List<double> valListX = new System.Collections.Generic.List<double>(), valListY = new System.Collections.Generic.List<double>(), valListZ = new System.Collections.Generic.List<double>(), valListNX = new System.Collections.Generic.List<double>(), valListNY = new System.Collections.Generic.List<double>(), valListNZ = new System.Collections.Generic.List<double>();
        public static void connectingWiimote()
        {
            wiimoteconnected = connect();
            wiimoteconnected = connect();
            if (wiimoteconnected)
                ScanWiimote();
        }
        public static void InitWiimoteNunchuck()
        {
            try
            {
                calibrationxinit = -aBuffer[3] + 135f;
                calibrationyinit = -aBuffer[4] + 135f;
                calibrationzinit = -aBuffer[5] + 135f;
                stickviewxinit = -aBuffer[16] + 125f;
                stickviewyinit = -aBuffer[17] + 125f;
            }
            catch { }
        }
        public static void ProcessButtonsWiimoteNunchuck()
        {
            try
            {
                if (irmode == 1)
                { 
                    mWSIRSensors0X = aBuffer[6] | ((aBuffer[8] >> 4) & 0x03) << 8;
                    mWSIRSensors0Y = aBuffer[7] | ((aBuffer[8] >> 6) & 0x03) << 8;
                    mWSIRSensors1X = aBuffer[9] | ((aBuffer[8] >> 0) & 0x03) << 8;
                    mWSIRSensors1Y = aBuffer[10] | ((aBuffer[8] >> 2) & 0x03) << 8;
                    mWSIR0found = mWSIRSensors0X > 0f & mWSIRSensors0X <= 1024f & mWSIRSensors0Y > 0f & mWSIRSensors0Y <= 768f;
                    mWSIR1found = mWSIRSensors1X > 0f & mWSIRSensors1X <= 1024f & mWSIRSensors1Y > 0f & mWSIRSensors1Y <= 768f;
                    if (mWSIR0found)
                    {
                        mWSIRSensors0Xcam = mWSIRSensors0X - 512f;
                        mWSIRSensors0Ycam = mWSIRSensors0Y - 384f;
                    }
                    if (mWSIR1found)
                    {
                        mWSIRSensors1Xcam = mWSIRSensors1X - 512f;
                        mWSIRSensors1Ycam = mWSIRSensors1Y - 384f;
                    }
                    if (mWSIR0found & mWSIR1found)
                    {
                        mWSIRSensorsXcam = (mWSIRSensors0Xcam + mWSIRSensors1Xcam) / 2f;
                        mWSIRSensorsYcam = (mWSIRSensors0Ycam + mWSIRSensors1Ycam) / 2f;
                    }
                    if (mWSIR0found)
                    {
                        irx0 = 2 * mWSIRSensors0Xcam - mWSIRSensorsXcam;
                        iry0 = 2 * mWSIRSensors0Ycam - mWSIRSensorsYcam;
                    }
                    if (mWSIR1found)
                    {
                        irx1 = 2 * mWSIRSensors1Xcam - mWSIRSensorsXcam;
                        iry1 = 2 * mWSIRSensors1Ycam - mWSIRSensorsYcam;
                    }
                    irxc = irx0 + irx1;
                    iryc = iry0 + iry1;
                }
                else
                {
                    mWSIR0found = (aBuffer[6] | ((aBuffer[8] >> 4) & 0x03) << 8) > 1 & (aBuffer[6] | ((aBuffer[8] >> 4) & 0x03) << 8) < 1023;
                    mWSIR1found = (aBuffer[9] | ((aBuffer[8] >> 0) & 0x03) << 8) > 1 & (aBuffer[9] | ((aBuffer[8] >> 0) & 0x03) << 8) < 1023;
                    if (mWSIR0notfound == 0 & mWSIR1found)
                        mWSIR0notfound = 1;
                    if (mWSIR0notfound == 1 & !mWSIR0found & !mWSIR1found)
                        mWSIR0notfound = 2;
                    if (mWSIR0notfound == 2 & mWSIR0found)
                    {
                        mWSIR0notfound = 0;
                        if (!mWSIRswitch)
                            mWSIRswitch = true;
                        else
                            mWSIRswitch = false;
                    }
                    if (mWSIR0notfound == 0 & mWSIR0found)
                        mWSIR0notfound = 0;
                    if (mWSIR0notfound == 0 & !mWSIR0found & !mWSIR1found)
                        mWSIR0notfound = 0;
                    if (mWSIR0notfound == 1 & mWSIR0found)
                        mWSIR0notfound = 0;
                    if (mWSIR0found)
                    {
                        mWSIRSensors0X = (aBuffer[6] | ((aBuffer[8] >> 4) & 0x03) << 8);
                        mWSIRSensors0Y = (aBuffer[7] | ((aBuffer[8] >> 6) & 0x03) << 8);
                    }
                    if (mWSIR1found)
                    {
                        mWSIRSensors1X = (aBuffer[9] | ((aBuffer[8] >> 0) & 0x03) << 8);
                        mWSIRSensors1Y = (aBuffer[10] | ((aBuffer[8] >> 2) & 0x03) << 8);
                    }
                    if (mWSIRswitch)
                    {
                        mWSIR0foundcam = mWSIR0found;
                        mWSIR1foundcam = mWSIR1found;
                        mWSIRSensors0Xcam = mWSIRSensors0X - 512f;
                        mWSIRSensors0Ycam = mWSIRSensors0Y - 384f;
                        mWSIRSensors1Xcam = mWSIRSensors1X - 512f;
                        mWSIRSensors1Ycam = mWSIRSensors1Y - 384f;
                    }
                    else
                    {
                        mWSIR1foundcam = mWSIR0found;
                        mWSIR0foundcam = mWSIR1found;
                        mWSIRSensors1Xcam = mWSIRSensors0X - 512f;
                        mWSIRSensors1Ycam = mWSIRSensors0Y - 384f;
                        mWSIRSensors0Xcam = mWSIRSensors1X - 512f;
                        mWSIRSensors0Ycam = mWSIRSensors1Y - 384f;
                    }
                    if (mWSIR0foundcam & mWSIR1foundcam)
                    {
                        irx2 = mWSIRSensors0Xcam;
                        iry2 = mWSIRSensors0Ycam;
                        irx3 = mWSIRSensors1Xcam;
                        iry3 = mWSIRSensors1Ycam;
                        mWSIRSensorsXcam = mWSIRSensors0Xcam - mWSIRSensors1Xcam;
                        mWSIRSensorsYcam = mWSIRSensors0Ycam - mWSIRSensors1Ycam;
                    }
                    if (mWSIR0foundcam & !mWSIR1foundcam)
                    {
                        irx2 = mWSIRSensors0Xcam;
                        iry2 = mWSIRSensors0Ycam;
                        irx3 = mWSIRSensors0Xcam - mWSIRSensorsXcam;
                        iry3 = mWSIRSensors0Ycam - mWSIRSensorsYcam;
                    }
                    if (mWSIR1foundcam & !mWSIR0foundcam)
                    {
                        irx3 = mWSIRSensors1Xcam;
                        iry3 = mWSIRSensors1Ycam;
                        irx2 = mWSIRSensors1Xcam + mWSIRSensorsXcam;
                        iry2 = mWSIRSensors1Ycam + mWSIRSensorsYcam;
                    }
                    irxc = irx2 + irx3;
                    iryc = iry2 + iry3;
                }
                mWSButtonStateIRX = irxc;
                mWSButtonStateIRY = iryc * 2f;
                irx = mWSButtonStateIRX * (1024f / 1360f);
                iry = mWSButtonStateIRY + centery >= 0 ? Scale(mWSButtonStateIRY + centery, 0f, 1360f + centery, 0f, 1024f) : Scale(mWSButtonStateIRY + centery, -1360f + centery, 0f, -1024f, 0f);
                if (irx >= 1024f)
                    irx = 1024f;
                if (irx <= -1024f)
                    irx = -1024f;
                if (iry >= 1024f)
                    iry = 1024f;
                if (iry <= -1024f)
                    iry = -1024f;
                mWSButtonStateA = (aBuffer[2] & 0x08) != 0;
                mWSButtonStateB = (aBuffer[2] & 0x04) != 0;
                mWSButtonStateMinus = (aBuffer[2] & 0x10) != 0;
                mWSButtonStateHome = (aBuffer[2] & 0x80) != 0;
                mWSButtonStatePlus = (aBuffer[1] & 0x10) != 0;
                mWSButtonStateOne = (aBuffer[2] & 0x02) != 0;
                mWSButtonStateTwo = (aBuffer[2] & 0x01) != 0;
                mWSButtonStateUp = (aBuffer[1] & 0x08) != 0;
                mWSButtonStateDown = (aBuffer[1] & 0x04) != 0;
                mWSButtonStateLeft = (aBuffer[1] & 0x01) != 0;
                mWSButtonStateRight = (aBuffer[1] & 0x02) != 0;
                mWSNunchuckStateRawJoystickX = aBuffer[16] - 125f + stickviewxinit;
                mWSNunchuckStateRawJoystickY = aBuffer[17] - 125f + stickviewyinit;
                mWSNunchuckStateC = (aBuffer[21] & 0x02) == 0;
                mWSNunchuckStateZ = (aBuffer[21] & 0x01) == 0;
                if (valListX.Count >= 60)
                {
                    valListX.RemoveAt(0);
                    valListX.Add(aBuffer[3] - 135f + calibrationxinit);
                }
                else
                    valListX.Add(aBuffer[3] - 135f + calibrationxinit);
                mWSRawValuesX = valListX.Average();
                if (valListY.Count >= 60)
                {
                    valListY.RemoveAt(0);
                    valListY.Add(aBuffer[4] - 135f + calibrationyinit);
                }
                else
                    valListY.Add(aBuffer[4] - 135f + calibrationyinit);
                mWSRawValuesY = valListY.Average();
                if (valListZ.Count >= 60)
                {
                    valListZ.RemoveAt(0);
                    valListZ.Add(aBuffer[5] - 135f + calibrationzinit);
                }
                else
                    valListZ.Add(aBuffer[5] - 135f + calibrationzinit);
                mWSRawValuesZ = valListZ.Average();
                if (valListNX.Count >= 60)
                {
                    valListNX.RemoveAt(0);
                    valListNX.Add(aBuffer[18] - 125f);
                }
                else
                    valListNX.Add(aBuffer[18] - 125f);
                mWSNunchuckStateRawValuesX = valListNX.Average();
                if (valListNY.Count >= 60)
                {
                    valListNY.RemoveAt(0);
                    valListNY.Add(aBuffer[19] - 125f);
                }
                else
                    valListNY.Add(aBuffer[19] - 125f);
                mWSNunchuckStateRawValuesY = valListNY.Average();
                if (valListNZ.Count >= 60)
                {
                    valListNZ.RemoveAt(0);
                    valListNZ.Add(aBuffer[20] - 125f);
                }
                else
                    valListNZ.Add(aBuffer[20] - 125f);
                mWSNunchuckStateRawValuesZ = valListNZ.Average();
            }
            catch { }
        }
        public static double Scale(double value, double min, double max, double minScale, double maxScale)
        {
            double scaled = minScale + (double)(value - min) / (max - min) * (maxScale - minScale);
            return scaled;
        }
        public static void DataWiimoteNunchuck()
        {
            try
            {
                mStream.Read(aBuffer, 0, 22);
            }
            catch
            {
                System.Threading.Thread.Sleep(1);
            }
        }
        public static void FormCloseWiimoteNunchuck()
        {
            try
            {
                mStream.Close();
                handle.Close();
                disconnect();
                wiimoteconnected = false;
            }
            catch { }
        }
        public static bool ScanWiimote()
        {
            int index = 0;
            Guid guid;
            HidD_GetHidGuid(out guid);
            IntPtr hDevInfo = SetupDiGetClassDevs(ref guid, null, new IntPtr(), 0x00000010);
            SP_DEVICE_INTERFACE_DATA diData = new SP_DEVICE_INTERFACE_DATA();
            diData.cbSize = Marshal.SizeOf(diData);
            while (SetupDiEnumDeviceInterfaces(hDevInfo, new IntPtr(), ref guid, index, ref diData))
            {
                UInt32 size;
                SetupDiGetDeviceInterfaceDetail(hDevInfo, ref diData, new IntPtr(), 0, out size, new IntPtr());
                SP_DEVICE_INTERFACE_DETAIL_DATA diDetail = new SP_DEVICE_INTERFACE_DETAIL_DATA();
                diDetail.cbSize = 5;
                if (SetupDiGetDeviceInterfaceDetail(hDevInfo, ref diData, ref diDetail, size, out size, new IntPtr()))
                {
                    if ((diDetail.DevicePath.Contains(vendor_id) | diDetail.DevicePath.Contains(vendor_id_)) & (diDetail.DevicePath.Contains(product_r1) | diDetail.DevicePath.Contains(product_r2)))
                    {
                        WiimoteFound(diDetail.DevicePath);
                        WiimoteFound(diDetail.DevicePath);
                        WiimoteFound(diDetail.DevicePath);
                        return true;
                    }
                }
                index++;
            }
            return false;
        }
        public static void WiimoteFound(string path)
        {
            do
            {
                handle = CreateFile(path, FileAccess.ReadWrite, FileShare.ReadWrite, IntPtr.Zero, FileMode.Open, (uint)EFileAttributes.Overlapped, IntPtr.Zero);
                WriteData(handle, IR, (int)REGISTER_IR, new byte[] { 0x08 }, 1);
                WriteData(handle, Type, (int)REGISTER_EXTENSION_INIT_1, new byte[] { 0x55 }, 1);
                WriteData(handle, Type, (int)REGISTER_EXTENSION_INIT_2, new byte[] { 0x00 }, 1);
                WriteData(handle, Type, (int)REGISTER_MOTIONPLUS_INIT, new byte[] { 0x04 }, 1);
                ReadData(handle, 0x0016, 7);
                ReadData(handle, (int)REGISTER_EXTENSION_TYPE, 6);
                ReadData(handle, (int)REGISTER_EXTENSION_CALIBRATION, 16);
                ReadData(handle, (int)REGISTER_EXTENSION_CALIBRATION, 32);
            }
            while (handle.IsInvalid);
            mStream = new FileStream(handle, FileAccess.ReadWrite, 22, true);
        }
        public static void ReadData(SafeFileHandle _hFile, int address, short size)
        {
            mBuff[0] = (byte)ReadMemory;
            mBuff[1] = (byte)((address & 0xff000000) >> 24);
            mBuff[2] = (byte)((address & 0x00ff0000) >> 16);
            mBuff[3] = (byte)((address & 0x0000ff00) >> 8);
            mBuff[4] = (byte)(address & 0x000000ff);
            mBuff[5] = (byte)((size & 0xff00) >> 8);
            mBuff[6] = (byte)(size & 0xff);
            HidD_SetOutputReport(_hFile.DangerousGetHandle(), mBuff, 22);
        }
        public static void WriteData(SafeFileHandle _hFile, byte mbuff, int address, byte[] buff, short size)
        {
            mBuff[0] = (byte)mbuff;
            mBuff[1] = (byte)(0x04);
            mBuff[2] = (byte)IRExtensionAccel;
            System.Array.Copy(buff, 0, mBuff, 3, 1);
            HidD_SetOutputReport(_hFile.DangerousGetHandle(), mBuff, 22);
            mBuff[0] = (byte)WriteMemory;
            mBuff[1] = (byte)(((address & 0xff000000) >> 24));
            mBuff[2] = (byte)((address & 0x00ff0000) >> 16);
            mBuff[3] = (byte)((address & 0x0000ff00) >> 8);
            mBuff[4] = (byte)((address & 0x000000ff) >> 0);
            mBuff[5] = (byte)size;
            System.Array.Copy(buff, 0, mBuff, 6, 1);
            HidD_SetOutputReport(_hFile.DangerousGetHandle(), mBuff, 22);
        }
    }
    public static class JSObjectExtensions
    {
        public static void SetValue(this JSObject jsObj, string value)
        {
            jsObj["value"] = value;
        }
        public static void SetHtml(this JSObject jsObj, string value)
        {
            jsObj["innerHTML"] = value;
        }
        public static string GetValue(this JSObject jsObj)
        {
            return jsObj["value"] as string ?? string.Empty;
        }
        public static string GetHtml(this JSObject jsObj)
        {
            return jsObj["innerHTML"] as string ?? string.Empty;
        }
        public static string GetTagName(this JSObject jsObj)
        {
            return (jsObj["tagName"] as string ?? string.Empty).ToUpper();
        }
        public static string GetID(this JSObject jsObj)
        {
            return jsObj["id"] as string ?? string.Empty;
        }
        public static string GetAttribute(this JSObject jsObj, string attribute)
        {
            return jsObj.InvokeFunction("getAttribute", attribute) as string ?? string.Empty;
        }
        public static JSObject GetParent(this JSObject jsObj)
        {
            return jsObj["parentElement"] as JSObject;
        }
        public static IEnumerable<JSObject> GetChildren(this JSObject jsObj)
        {
            var childrenCollection = (JSObject)jsObj["children"];
            int childObjectCount = (int)childrenCollection["length"];
            for (int i = 0; i < childObjectCount; i++)
            {
                yield return (JSObject)childrenCollection[i];
            }
        }
    }
}
namespace FTA
{
    public class SendKeys
    {
        [DllImport("mouse.dll", EntryPoint = "MoveMouseTo", CallingConvention = CallingConvention.Cdecl)]
        public static extern void MoveMouseTo(int x, int y);
        [DllImport("mouse.dll", EntryPoint = "MoveMouseBy", CallingConvention = CallingConvention.Cdecl)]
        public static extern void MoveMouseBy(int x, int y);
        [DllImport("keyboard.dll", EntryPoint = "SendKey", CallingConvention = CallingConvention.Cdecl)]
        public static extern void SendKey(UInt16 bVk, UInt16 bScan);
        [DllImport("keyboard.dll", EntryPoint = "SendKeyF", CallingConvention = CallingConvention.Cdecl)]
        public static extern void SendKeyF(UInt16 bVk, UInt16 bScan);
        [DllImport("keyboard.dll", EntryPoint = "SendKeyArrows", CallingConvention = CallingConvention.Cdecl)]
        public static extern void SendKeyArrows(UInt16 bVk, UInt16 bScan);
        [DllImport("keyboard.dll", EntryPoint = "SendKeyArrowsF", CallingConvention = CallingConvention.Cdecl)]
        public static extern void SendKeyArrowsF(UInt16 bVk, UInt16 bScan);
        [DllImport("keyboard.dll", EntryPoint = "SendMouseEventButtonLeft", CallingConvention = CallingConvention.Cdecl)]
        public static extern void SendMouseEventButtonLeft();
        [DllImport("keyboard.dll", EntryPoint = "SendMouseEventButtonLeftF", CallingConvention = CallingConvention.Cdecl)]
        public static extern void SendMouseEventButtonLeftF();
        [DllImport("keyboard.dll", EntryPoint = "SendMouseEventButtonRight", CallingConvention = CallingConvention.Cdecl)]
        public static extern void SendMouseEventButtonRight();
        [DllImport("keyboard.dll", EntryPoint = "SendMouseEventButtonRightF", CallingConvention = CallingConvention.Cdecl)]
        public static extern void SendMouseEventButtonRightF();
        [DllImport("keyboard.dll", EntryPoint = "SendMouseEventButtonMiddle", CallingConvention = CallingConvention.Cdecl)]
        public static extern void SendMouseEventButtonMiddle();
        [DllImport("keyboard.dll", EntryPoint = "SendMouseEventButtonMiddleF", CallingConvention = CallingConvention.Cdecl)]
        public static extern void SendMouseEventButtonMiddleF();
        [DllImport("keyboard.dll", EntryPoint = "SendMouseEventButtonWheelUp", CallingConvention = CallingConvention.Cdecl)]
        public static extern void SendMouseEventButtonWheelUp();
        [DllImport("keyboard.dll", EntryPoint = "SendMouseEventButtonWheelDown", CallingConvention = CallingConvention.Cdecl)]
        public static extern void SendMouseEventButtonWheelDown();
        [DllImport("mouse.dll", EntryPoint = "MouseMW3", CallingConvention = CallingConvention.Cdecl)]
        public static extern void MouseMW3(int x, int y);
        [DllImport("mouse.dll", EntryPoint = "MouseBrink", CallingConvention = CallingConvention.Cdecl)]
        public static extern void MouseBrink(int x, int y);
        [DllImport("keyboard.dll", EntryPoint = "SimulateKeyDown", CallingConvention = CallingConvention.Cdecl)]
        public static extern void SimulateKeyDown(UInt16 keyCode, UInt16 bScan);
        [DllImport("keyboard.dll", EntryPoint = "SimulateKeyUp", CallingConvention = CallingConvention.Cdecl)]
        public static extern void SimulateKeyUp(UInt16 keyCode, UInt16 bScan);
        [DllImport("keyboard.dll", EntryPoint = "SimulateKeyDownArrows", CallingConvention = CallingConvention.Cdecl)]
        public static extern void SimulateKeyDownArrows(UInt16 keyCode, UInt16 bScan);
        [DllImport("keyboard.dll", EntryPoint = "SimulateKeyUpArrows", CallingConvention = CallingConvention.Cdecl)]
        public static extern void SimulateKeyUpArrows(UInt16 keyCode, UInt16 bScan);
        [DllImport("keyboard.dll", EntryPoint = "LeftClick", CallingConvention = CallingConvention.Cdecl)]
        public static extern void LeftClick();
        [DllImport("keyboard.dll", EntryPoint = "LeftClickF", CallingConvention = CallingConvention.Cdecl)]
        public static extern void LeftClickF();
        [DllImport("keyboard.dll", EntryPoint = "RightClick", CallingConvention = CallingConvention.Cdecl)]
        public static extern void RightClick();
        [DllImport("keyboard.dll", EntryPoint = "RightClickF", CallingConvention = CallingConvention.Cdecl)]
        public static extern void RightClickF();
        [DllImport("keyboard.dll", EntryPoint = "MiddleClick", CallingConvention = CallingConvention.Cdecl)]
        public static extern void MiddleClick();
        [DllImport("keyboard.dll", EntryPoint = "MiddleClickF", CallingConvention = CallingConvention.Cdecl)]
        public static extern void MiddleClickF();
        [DllImport("keyboard.dll", EntryPoint = "WheelDownF", CallingConvention = CallingConvention.Cdecl)]
        public static extern void WheelDownF();
        [DllImport("keyboard.dll", EntryPoint = "WheelUpF", CallingConvention = CallingConvention.Cdecl)]
        public static extern void WheelUpF();
        [DllImport("user32.dll")]
        public static extern void SetPhysicalCursorPos(int X, int Y);
        [DllImport("user32.dll")]
        public static extern void SetCaretPos(int X, int Y);
        [DllImport("user32.dll")]
        public static extern void SetCursorPos(int X, int Y);
        public const ushort VK_LBUTTON = (ushort)0x01;
        public const ushort VK_RBUTTON = (ushort)0x02;
        public const ushort VK_CANCEL = (ushort)0x03;
        public const ushort VK_MBUTTON = (ushort)0x04;
        public const ushort VK_XBUTTON1 = (ushort)0x05;
        public const ushort VK_XBUTTON2 = (ushort)0x06;
        public const ushort VK_BACK = (ushort)0x08;
        public const ushort VK_Tab = (ushort)0x09;
        public const ushort VK_CLEAR = (ushort)0x0C;
        public const ushort VK_Return = (ushort)0x0D;
        public const ushort VK_SHIFT = (ushort)0x10;
        public const ushort VK_CONTROL = (ushort)0x11;
        public const ushort VK_MENU = (ushort)0x12;
        public const ushort VK_PAUSE = (ushort)0x13;
        public const ushort VK_CAPITAL = (ushort)0x14;
        public const ushort VK_KANA = (ushort)0x15;
        public const ushort VK_HANGEUL = (ushort)0x15;
        public const ushort VK_HANGUL = (ushort)0x15;
        public const ushort VK_JUNJA = (ushort)0x17;
        public const ushort VK_FINAL = (ushort)0x18;
        public const ushort VK_HANJA = (ushort)0x19;
        public const ushort VK_KANJI = (ushort)0x19;
        public const ushort VK_Escape = (ushort)0x1B;
        public const ushort VK_CONVERT = (ushort)0x1C;
        public const ushort VK_NONCONVERT = (ushort)0x1D;
        public const ushort VK_ACCEPT = (ushort)0x1E;
        public const ushort VK_MODECHANGE = (ushort)0x1F;
        public const ushort VK_Space = (ushort)0x20;
        public const ushort VK_PRIOR = (ushort)0x21;
        public const ushort VK_NEXT = (ushort)0x22;
        public const ushort VK_END = (ushort)0x23;
        public const ushort VK_HOME = (ushort)0x24;
        public const ushort VK_LEFT = (ushort)0x25;
        public const ushort VK_UP = (ushort)0x26;
        public const ushort VK_RIGHT = (ushort)0x27;
        public const ushort VK_DOWN = (ushort)0x28;
        public const ushort VK_SELECT = (ushort)0x29;
        public const ushort VK_PRINT = (ushort)0x2A;
        public const ushort VK_EXECUTE = (ushort)0x2B;
        public const ushort VK_SNAPSHOT = (ushort)0x2C;
        public const ushort VK_INSERT = (ushort)0x2D;
        public const ushort VK_DELETE = (ushort)0x2E;
        public const ushort VK_HELP = (ushort)0x2F;
        public const ushort VK_APOSTROPHE = (ushort)0xDE;
        public const ushort VK_0 = (ushort)0x30;
        public const ushort VK_1 = (ushort)0x31;
        public const ushort VK_2 = (ushort)0x32;
        public const ushort VK_3 = (ushort)0x33;
        public const ushort VK_4 = (ushort)0x34;
        public const ushort VK_5 = (ushort)0x35;
        public const ushort VK_6 = (ushort)0x36;
        public const ushort VK_7 = (ushort)0x37;
        public const ushort VK_8 = (ushort)0x38;
        public const ushort VK_9 = (ushort)0x39;
        public const ushort VK_A = (ushort)0x41;
        public const ushort VK_B = (ushort)0x42;
        public const ushort VK_C = (ushort)0x43;
        public const ushort VK_D = (ushort)0x44;
        public const ushort VK_E = (ushort)0x45;
        public const ushort VK_F = (ushort)0x46;
        public const ushort VK_G = (ushort)0x47;
        public const ushort VK_H = (ushort)0x48;
        public const ushort VK_I = (ushort)0x49;
        public const ushort VK_J = (ushort)0x4A;
        public const ushort VK_K = (ushort)0x4B;
        public const ushort VK_L = (ushort)0x4C;
        public const ushort VK_M = (ushort)0x4D;
        public const ushort VK_N = (ushort)0x4E;
        public const ushort VK_O = (ushort)0x4F;
        public const ushort VK_P = (ushort)0x50;
        public const ushort VK_Q = (ushort)0x51;
        public const ushort VK_R = (ushort)0x52;
        public const ushort VK_S = (ushort)0x53;
        public const ushort VK_T = (ushort)0x54;
        public const ushort VK_U = (ushort)0x55;
        public const ushort VK_V = (ushort)0x56;
        public const ushort VK_W = (ushort)0x57;
        public const ushort VK_X = (ushort)0x58;
        public const ushort VK_Y = (ushort)0x59;
        public const ushort VK_Z = (ushort)0x5A;
        public const ushort VK_LWIN = (ushort)0x5B;
        public const ushort VK_RWIN = (ushort)0x5C;
        public const ushort VK_APPS = (ushort)0x5D;
        public const ushort VK_SLEEP = (ushort)0x5F;
        public const ushort VK_NUMPAD0 = (ushort)0x60;
        public const ushort VK_NUMPAD1 = (ushort)0x61;
        public const ushort VK_NUMPAD2 = (ushort)0x62;
        public const ushort VK_NUMPAD3 = (ushort)0x63;
        public const ushort VK_NUMPAD4 = (ushort)0x64;
        public const ushort VK_NUMPAD5 = (ushort)0x65;
        public const ushort VK_NUMPAD6 = (ushort)0x66;
        public const ushort VK_NUMPAD7 = (ushort)0x67;
        public const ushort VK_NUMPAD8 = (ushort)0x68;
        public const ushort VK_NUMPAD9 = (ushort)0x69;
        public const ushort VK_MULTIPLY = (ushort)0x6A;
        public const ushort VK_ADD = (ushort)0x6B;
        public const ushort VK_SEPARATOR = (ushort)0x6C;
        public const ushort VK_SUBTRACT = (ushort)0x6D;
        public const ushort VK_DECIMAL = (ushort)0x6E;
        public const ushort VK_DIVIDE = (ushort)0x6F;
        public const ushort VK_F1 = (ushort)0x70;
        public const ushort VK_F2 = (ushort)0x71;
        public const ushort VK_F3 = (ushort)0x72;
        public const ushort VK_F4 = (ushort)0x73;
        public const ushort VK_F5 = (ushort)0x74;
        public const ushort VK_F6 = (ushort)0x75;
        public const ushort VK_F7 = (ushort)0x76;
        public const ushort VK_F8 = (ushort)0x77;
        public const ushort VK_F9 = (ushort)0x78;
        public const ushort VK_F10 = (ushort)0x79;
        public const ushort VK_F11 = (ushort)0x7A;
        public const ushort VK_F12 = (ushort)0x7B;
        public const ushort VK_F13 = (ushort)0x7C;
        public const ushort VK_F14 = (ushort)0x7D;
        public const ushort VK_F15 = (ushort)0x7E;
        public const ushort VK_F16 = (ushort)0x7F;
        public const ushort VK_F17 = (ushort)0x80;
        public const ushort VK_F18 = (ushort)0x81;
        public const ushort VK_F19 = (ushort)0x82;
        public const ushort VK_F20 = (ushort)0x83;
        public const ushort VK_F21 = (ushort)0x84;
        public const ushort VK_F22 = (ushort)0x85;
        public const ushort VK_F23 = (ushort)0x86;
        public const ushort VK_F24 = (ushort)0x87;
        public const ushort VK_NUMLOCK = (ushort)0x90;
        public const ushort VK_SCROLL = (ushort)0x91;
        public const ushort VK_LeftShift = (ushort)0xA0;
        public const ushort VK_RightShift = (ushort)0xA1;
        public const ushort VK_LeftControl = (ushort)0xA2;
        public const ushort VK_RightControl = (ushort)0xA3;
        public const ushort VK_LMENU = (ushort)0xA4;
        public const ushort VK_RMENU = (ushort)0xA5;
        public const ushort VK_BROWSER_BACK = (ushort)0xA6;
        public const ushort VK_BROWSER_FORWARD = (ushort)0xA7;
        public const ushort VK_BROWSER_REFRESH = (ushort)0xA8;
        public const ushort VK_BROWSER_STOP = (ushort)0xA9;
        public const ushort VK_BROWSER_SEARCH = (ushort)0xAA;
        public const ushort VK_BROWSER_FAVORITES = (ushort)0xAB;
        public const ushort VK_BROWSER_HOME = (ushort)0xAC;
        public const ushort VK_VOLUME_MUTE = (ushort)0xAD;
        public const ushort VK_VOLUME_DOWN = (ushort)0xAE;
        public const ushort VK_VOLUME_UP = (ushort)0xAF;
        public const ushort VK_MEDIA_NEXT_TRACK = (ushort)0xB0;
        public const ushort VK_MEDIA_PREV_TRACK = (ushort)0xB1;
        public const ushort VK_MEDIA_STOP = (ushort)0xB2;
        public const ushort VK_MEDIA_PLAY_PAUSE = (ushort)0xB3;
        public const ushort VK_LAUNCH_MAIL = (ushort)0xB4;
        public const ushort VK_LAUNCH_MEDIA_SELECT = (ushort)0xB5;
        public const ushort VK_LAUNCH_APP1 = (ushort)0xB6;
        public const ushort VK_LAUNCH_APP2 = (ushort)0xB7;
        public const ushort VK_OEM_1 = (ushort)0xBA;
        public const ushort VK_OEM_PLUS = (ushort)0xBB;
        public const ushort VK_OEM_COMMA = (ushort)0xBC;
        public const ushort VK_OEM_MINUS = (ushort)0xBD;
        public const ushort VK_OEM_PERIOD = (ushort)0xBE;
        public const ushort VK_OEM_2 = (ushort)0xBF;
        public const ushort VK_OEM_3 = (ushort)0xC0;
        public const ushort VK_OEM_4 = (ushort)0xDB;
        public const ushort VK_OEM_5 = (ushort)0xDC;
        public const ushort VK_OEM_6 = (ushort)0xDD;
        public const ushort VK_OEM_7 = (ushort)0xDE;
        public const ushort VK_OEM_8 = (ushort)0xDF;
        public const ushort VK_OEM_102 = (ushort)0xE2;
        public const ushort VK_PROCESSKEY = (ushort)0xE5;
        public const ushort VK_PACKET = (ushort)0xE7;
        public const ushort VK_ATTN = (ushort)0xF6;
        public const ushort VK_CRSEL = (ushort)0xF7;
        public const ushort VK_EXSEL = (ushort)0xF8;
        public const ushort VK_EREOF = (ushort)0xF9;
        public const ushort VK_PLAY = (ushort)0xFA;
        public const ushort VK_ZOOM = (ushort)0xFB;
        public const ushort VK_NONAME = (ushort)0xFC;
        public const ushort VK_PA1 = (ushort)0xFD;
        public const ushort VK_OEM_CLEAR = (ushort)0xFE;
        public const ushort S_LBUTTON = (ushort)0x0;
        public const ushort S_RBUTTON = 0;
        public const ushort S_CANCEL = 70;
        public const ushort S_MBUTTON = 0;
        public const ushort S_XBUTTON1 = 0;
        public const ushort S_XBUTTON2 = 0;
        public const ushort S_BACK = 14;
        public const ushort S_Tab = 15;
        public const ushort S_CLEAR = 76;
        public const ushort S_Return = 28;
        public const ushort S_SHIFT = 42;
        public const ushort S_CONTROL = 29;
        public const ushort S_MENU = 56;
        public const ushort S_PAUSE = 0;
        public const ushort S_CAPITAL = 58;
        public const ushort S_KANA = 0;
        public const ushort S_HANGEUL = 0;
        public const ushort S_HANGUL = 0;
        public const ushort S_JUNJA = 0;
        public const ushort S_FINAL = 0;
        public const ushort S_HANJA = 0;
        public const ushort S_KANJI = 0;
        public const ushort S_Escape = 1;
        public const ushort S_CONVERT = 0;
        public const ushort S_NONCONVERT = 0;
        public const ushort S_ACCEPT = 0;
        public const ushort S_MODECHANGE = 0;
        public const ushort S_Space = 57;
        public const ushort S_PRIOR = 73;
        public const ushort S_NEXT = 81;
        public const ushort S_END = 79;
        public const ushort S_HOME = 71;
        public const ushort S_LEFT = 75;
        public const ushort S_UP = 72;
        public const ushort S_RIGHT = 77;
        public const ushort S_DOWN = 80;
        public const ushort S_SELECT = 0;
        public const ushort S_PRINT = 0;
        public const ushort S_EXECUTE = 0;
        public const ushort S_SNAPSHOT = 84;
        public const ushort S_INSERT = 82;
        public const ushort S_DELETE = 83;
        public const ushort S_HELP = 99;
        public const ushort S_APOSTROPHE = 41;
        public const ushort S_0 = 11;
        public const ushort S_1 = 2;
        public const ushort S_2 = 3;
        public const ushort S_3 = 4;
        public const ushort S_4 = 5;
        public const ushort S_5 = 6;
        public const ushort S_6 = 7;
        public const ushort S_7 = 8;
        public const ushort S_8 = 9;
        public const ushort S_9 = 10;
        public const ushort S_A = 16;
        public const ushort S_B = 48;
        public const ushort S_C = 46;
        public const ushort S_D = 32;
        public const ushort S_E = 18;
        public const ushort S_F = 33;
        public const ushort S_G = 34;
        public const ushort S_H = 35;
        public const ushort S_I = 23;
        public const ushort S_J = 36;
        public const ushort S_K = 37;
        public const ushort S_L = 38;
        public const ushort S_M = 39;
        public const ushort S_N = 49;
        public const ushort S_O = 24;
        public const ushort S_P = 25;
        public const ushort S_Q = 30;
        public const ushort S_R = 19;
        public const ushort S_S = 31;
        public const ushort S_T = 20;
        public const ushort S_U = 22;
        public const ushort S_V = 47;
        public const ushort S_W = 44;
        public const ushort S_X = 45;
        public const ushort S_Y = 21;
        public const ushort S_Z = 17;
        public const ushort S_LWIN = 91;
        public const ushort S_RWIN = 92;
        public const ushort S_APPS = 93;
        public const ushort S_SLEEP = 95;
        public const ushort S_NUMPAD0 = 82;
        public const ushort S_NUMPAD1 = 79;
        public const ushort S_NUMPAD2 = 80;
        public const ushort S_NUMPAD3 = 81;
        public const ushort S_NUMPAD4 = 75;
        public const ushort S_NUMPAD5 = 76;
        public const ushort S_NUMPAD6 = 77;
        public const ushort S_NUMPAD7 = 71;
        public const ushort S_NUMPAD8 = 72;
        public const ushort S_NUMPAD9 = 73;
        public const ushort S_MULTIPLY = 55;
        public const ushort S_ADD = 78;
        public const ushort S_SEPARATOR = 0;
        public const ushort S_SUBTRACT = 74;
        public const ushort S_DECIMAL = 83;
        public const ushort S_DIVIDE = 53;
        public const ushort S_F1 = 59;
        public const ushort S_F2 = 60;
        public const ushort S_F3 = 61;
        public const ushort S_F4 = 62;
        public const ushort S_F5 = 63;
        public const ushort S_F6 = 64;
        public const ushort S_F7 = 65;
        public const ushort S_F8 = 66;
        public const ushort S_F9 = 67;
        public const ushort S_F10 = 68;
        public const ushort S_F11 = 87;
        public const ushort S_F12 = 88;
        public const ushort S_F13 = 100;
        public const ushort S_F14 = 101;
        public const ushort S_F15 = 102;
        public const ushort S_F16 = 103;
        public const ushort S_F17 = 104;
        public const ushort S_F18 = 105;
        public const ushort S_F19 = 106;
        public const ushort S_F20 = 107;
        public const ushort S_F21 = 108;
        public const ushort S_F22 = 109;
        public const ushort S_F23 = 110;
        public const ushort S_F24 = 118;
        public const ushort S_NUMLOCK = 69;
        public const ushort S_SCROLL = 70;
        public const ushort S_LeftShift = 42;
        public const ushort S_RightShift = 54;
        public const ushort S_LeftControl = 29;
        public const ushort S_RightControl = 29;
        public const ushort S_LMENU = 56;
        public const ushort S_RMENU = 56;
        public const ushort S_BROWSER_BACK = 106;
        public const ushort S_BROWSER_FORWARD = 105;
        public const ushort S_BROWSER_REFRESH = 103;
        public const ushort S_BROWSER_STOP = 104;
        public const ushort S_BROWSER_SEARCH = 101;
        public const ushort S_BROWSER_FAVORITES = 102;
        public const ushort S_BROWSER_HOME = 50;
        public const ushort S_VOLUME_MUTE = 32;
        public const ushort S_VOLUME_DOWN = 46;
        public const ushort S_VOLUME_UP = 48;
        public const ushort S_MEDIA_NEXT_TRACK = 25;
        public const ushort S_MEDIA_PREV_TRACK = 16;
        public const ushort S_MEDIA_STOP = 36;
        public const ushort S_MEDIA_PLAY_PAUSE = 34;
        public const ushort S_LAUNCH_MAIL = 108;
        public const ushort S_LAUNCH_MEDIA_SELECT = 109;
        public const ushort S_LAUNCH_APP1 = 107;
        public const ushort S_LAUNCH_APP2 = 33;
        public const ushort S_OEM_1 = 27;
        public const ushort S_OEM_PLUS = 13;
        public const ushort S_OEM_COMMA = 50;
        public const ushort S_OEM_MINUS = 0;
        public const ushort S_OEM_PERIOD = 51;
        public const ushort S_OEM_2 = 52;
        public const ushort S_OEM_3 = 40;
        public const ushort S_OEM_4 = 12;
        public const ushort S_OEM_5 = 43;
        public const ushort S_OEM_6 = 26;
        public const ushort S_OEM_7 = 41;
        public const ushort S_OEM_8 = 53;
        public const ushort S_OEM_102 = 86;
        public const ushort S_PROCESSKEY = 0;
        public const ushort S_PACKET = 0;
        public const ushort S_ATTN = 0;
        public const ushort S_CRSEL = 0;
        public const ushort S_EXSEL = 0;
        public const ushort S_EREOF = 93;
        public const ushort S_PLAY = 0;
        public const ushort S_ZOOM = 98;
        public const ushort S_NONAME = 0;
        public const ushort S_PA1 = 0;
        public const ushort S_OEM_CLEAR = 0;
        public static string drivertype;
        public static int[] wd = { 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2 };
        public static int[] wu = { 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2 };
        public static void valchanged(int n, bool val)
        {
            if (val)
            {
                if (wd[n] <= 1)
                {
                    wd[n] = wd[n] + 1;
                }
                wu[n] = 0;
            }
            else
            {
                if (wu[n] <= 1)
                {
                    wu[n] = wu[n] + 1;
                }
                wd[n] = 0;
            }
        }
        public static void UnLoadKM()
        {
            SetKM("kmevent", 0, 0, 0, 0, 0, 0, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false);
            SetKM("sendinput", 0, 0, 0, 0, 0, 0, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false);
        }
        public static void SetKM(string KeyboardMouseDriverType, double MouseMoveX, double MouseMoveY, double MouseAbsX, double MouseAbsY, double MouseDesktopX, double MouseDesktopY, bool SendLeftClick, bool SendRightClick, bool SendMiddleClick, bool SendWheelUp, bool SendWheelDown, bool SendLeft, bool SendRight, bool SendUp, bool SendDown, bool SendLButton, bool SendRButton, bool SendCancel, bool SendMBUTTON, bool SendXBUTTON1, bool SendXBUTTON2, bool SendBack, bool SendTab, bool SendClear, bool SendReturn, bool SendSHIFT, bool SendCONTROL, bool SendMENU, bool SendPAUSE, bool SendCAPITAL, bool SendKANA, bool SendHANGEUL, bool SendHANGUL, bool SendJUNJA, bool SendFINAL, bool SendHANJA, bool SendKANJI, bool SendEscape, bool SendCONVERT, bool SendNONCONVERT, bool SendACCEPT, bool SendMODECHANGE, bool SendSpace, bool SendPRIOR, bool SendNEXT, bool SendEND, bool SendHOME, bool SendLEFT, bool SendUP, bool SendRIGHT, bool SendDOWN, bool SendSELECT, bool SendPRINT, bool SendEXECUTE, bool SendSNAPSHOT, bool SendINSERT, bool SendDELETE, bool SendHELP, bool SendAPOSTROPHE, bool Send0, bool Send1, bool Send2, bool Send3, bool Send4, bool Send5, bool Send6, bool Send7, bool Send8, bool Send9, bool SendA, bool SendB, bool SendC, bool SendD, bool SendE, bool SendF, bool SendG, bool SendH, bool SendI, bool SendJ, bool SendK, bool SendL, bool SendM, bool SendN, bool SendO, bool SendP, bool SendQ, bool SendR, bool SendS, bool SendT, bool SendU, bool SendV, bool SendW, bool SendX, bool SendY, bool SendZ, bool SendLWIN, bool SendRWIN, bool SendAPPS, bool SendSLEEP, bool SendNUMPAD0, bool SendNUMPAD1, bool SendNUMPAD2, bool SendNUMPAD3, bool SendNUMPAD4, bool SendNUMPAD5, bool SendNUMPAD6, bool SendNUMPAD7, bool SendNUMPAD8, bool SendNUMPAD9, bool SendMULTIPLY, bool SendADD, bool SendSEPARATOR, bool SendSUBTRACT, bool SendDECIMAL, bool SendDIVIDE, bool SendF1, bool SendF2, bool SendF3, bool SendF4, bool SendF5, bool SendF6, bool SendF7, bool SendF8, bool SendF9, bool SendF10, bool SendF11, bool SendF12, bool SendF13, bool SendF14, bool SendF15, bool SendF16, bool SendF17, bool SendF18, bool SendF19, bool SendF20, bool SendF21, bool SendF22, bool SendF23, bool SendF24, bool SendNUMLOCK, bool SendSCROLL, bool SendLeftShift, bool SendRightShift, bool SendLeftControl, bool SendRightControl, bool SendLMENU, bool SendRMENU)
        {
            drivertype = KeyboardMouseDriverType;
            if (MouseMoveX != 0f | MouseMoveY != 0f)
                mousebrink((int)(MouseMoveX), (int)(MouseMoveY));
            if (MouseAbsX != 0f | MouseAbsY != 0f)
                mousemw3((int)(MouseAbsX), (int)(MouseAbsY));
            if (MouseDesktopX != 0f | MouseDesktopY != 0f)
            {
                System.Windows.Forms.Cursor.Position = new System.Drawing.Point((int)(MouseDesktopX), (int)(MouseDesktopY));
                SetPhysicalCursorPos((int)(MouseDesktopX), (int)(MouseDesktopY));
                SetCaretPos((int)(MouseDesktopX), (int)(MouseDesktopY));
                SetCursorPos((int)(MouseDesktopX), (int)(MouseDesktopY));
            }
            valchanged(1, SendLeftClick);
            if (wd[1] == 1)
                mouseclickleft();
            if (wu[1] == 1)
                mouseclickleftF();
            valchanged(2, SendRightClick);
            if (wd[2] == 1)
                mouseclickright();
            if (wu[2] == 1)
                mouseclickrightF();
            valchanged(3, SendMiddleClick);
            if (wd[3] == 1)
                mouseclickmiddle();
            if (wu[3] == 1)
                mouseclickmiddleF();
            valchanged(4, SendWheelUp);
            if (wd[4] == 1)
                mousewheelup();
            valchanged(5, SendWheelDown);
            if (wd[5] == 1)
                mousewheeldown();
            valchanged(6, SendLeft);
            if (wd[6] == 1)
                keyboardArrows(VK_LEFT, S_LEFT);
            if (wu[6] == 1)
                keyboardArrowsF(VK_LEFT, S_LEFT);
            valchanged(7, SendRight);
            if (wd[7] == 1)
                keyboardArrows(VK_RIGHT, S_RIGHT);
            if (wu[7] == 1)
                keyboardArrowsF(VK_RIGHT, S_RIGHT);
            valchanged(8, SendUp);
            if (wd[8] == 1)
                keyboardArrows(VK_UP, S_UP);
            if (wu[8] == 1)
                keyboardArrowsF(VK_UP, S_UP);
            valchanged(9, SendDown);
            if (wd[9] == 1)
                keyboardArrows(VK_DOWN, S_DOWN);
            if (wu[9] == 1)
                keyboardArrowsF(VK_DOWN, S_DOWN);
            valchanged(10, SendLButton);
            if (wd[10] == 1)
                keyboard(VK_LBUTTON, S_LBUTTON);
            if (wu[10] == 1)
                keyboardF(VK_LBUTTON, S_LBUTTON);
            valchanged(11, SendRButton);
            if (wd[11] == 1)
                keyboard(VK_RBUTTON, S_RBUTTON);
            if (wu[11] == 1)
                keyboardF(VK_RBUTTON, S_RBUTTON);
            valchanged(12, SendCancel);
            if (wd[12] == 1)
                keyboard(VK_CANCEL, S_CANCEL);
            if (wu[12] == 1)
                keyboardF(VK_CANCEL, S_CANCEL);
            valchanged(13, SendMBUTTON);
            if (wd[13] == 1)
                keyboard(VK_MBUTTON, S_MBUTTON);
            if (wu[13] == 1)
                keyboardF(VK_MBUTTON, S_MBUTTON);
            valchanged(14, SendXBUTTON1);
            if (wd[14] == 1)
                keyboard(VK_XBUTTON1, S_XBUTTON1);
            if (wu[14] == 1)
                keyboardF(VK_XBUTTON1, S_XBUTTON1);
            valchanged(15, SendXBUTTON2);
            if (wd[15] == 1)
                keyboard(VK_XBUTTON2, S_XBUTTON2);
            if (wu[15] == 1)
                keyboardF(VK_XBUTTON2, S_XBUTTON2);
            valchanged(16, SendBack);
            if (wd[16] == 1)
                keyboard(VK_BACK, S_BACK);
            if (wu[16] == 1)
                keyboardF(VK_BACK, S_BACK);
            valchanged(17, SendTab);
            if (wd[17] == 1)
                keyboard(VK_Tab, S_Tab);
            if (wu[17] == 1)
                keyboardF(VK_Tab, S_Tab);
            valchanged(18, SendClear);
            if (wd[18] == 1)
                keyboard(VK_CLEAR, S_CLEAR);
            if (wu[18] == 1)
                keyboardF(VK_CLEAR, S_CLEAR);
            valchanged(19, SendReturn);
            if (wd[19] == 1)
                keyboard(VK_Return, S_Return);
            if (wu[19] == 1)
                keyboardF(VK_Return, S_Return);
            valchanged(20, SendSHIFT);
            if (wd[20] == 1)
                keyboard(VK_SHIFT, S_SHIFT);
            if (wu[20] == 1)
                keyboardF(VK_SHIFT, S_SHIFT);
            valchanged(21, SendCONTROL);
            if (wd[21] == 1)
                keyboard(VK_CONTROL, S_CONTROL);
            if (wu[21] == 1)
                keyboardF(VK_CONTROL, S_CONTROL);
            valchanged(22, SendMENU);
            if (wd[22] == 1)
                keyboard(VK_MENU, S_MENU);
            if (wu[22] == 1)
                keyboardF(VK_MENU, S_MENU);
            valchanged(23, SendPAUSE);
            if (wd[23] == 1)
                keyboard(VK_PAUSE, S_PAUSE);
            if (wu[23] == 1)
                keyboardF(VK_PAUSE, S_PAUSE);
            valchanged(24, SendCAPITAL);
            if (wd[24] == 1)
                keyboard(VK_CAPITAL, S_CAPITAL);
            if (wu[24] == 1)
                keyboardF(VK_CAPITAL, S_CAPITAL);
            valchanged(25, SendKANA);
            if (wd[25] == 1)
                keyboard(VK_KANA, S_KANA);
            if (wu[25] == 1)
                keyboardF(VK_KANA, S_KANA);
            valchanged(26, SendHANGEUL);
            if (wd[26] == 1)
                keyboard(VK_HANGEUL, S_HANGEUL);
            if (wu[26] == 1)
                keyboardF(VK_HANGEUL, S_HANGEUL);
            valchanged(27, SendHANGUL);
            if (wd[27] == 1)
                keyboard(VK_HANGUL, S_HANGUL);
            if (wu[27] == 1)
                keyboardF(VK_HANGUL, S_HANGUL);
            valchanged(28, SendJUNJA);
            if (wd[28] == 1)
                keyboard(VK_JUNJA, S_JUNJA);
            if (wu[28] == 1)
                keyboardF(VK_JUNJA, S_JUNJA);
            valchanged(29, SendFINAL);
            if (wd[29] == 1)
                keyboard(VK_FINAL, S_FINAL);
            if (wu[29] == 1)
                keyboardF(VK_FINAL, S_FINAL);
            valchanged(30, SendHANJA);
            if (wd[30] == 1)
                keyboard(VK_HANJA, S_HANJA);
            if (wu[30] == 1)
                keyboardF(VK_HANJA, S_HANJA);
            valchanged(31, SendKANJI);
            if (wd[31] == 1)
                keyboard(VK_KANJI, S_KANJI);
            if (wu[31] == 1)
                keyboardF(VK_KANJI, S_KANJI);
            valchanged(32, SendEscape);
            if (wd[32] == 1)
                keyboard(VK_Escape, S_Escape);
            if (wu[32] == 1)
                keyboardF(VK_Escape, S_Escape);
            valchanged(33, SendCONVERT);
            if (wd[33] == 1)
                keyboard(VK_CONVERT, S_CONVERT);
            if (wu[33] == 1)
                keyboardF(VK_CONVERT, S_CONVERT);
            valchanged(34, SendNONCONVERT);
            if (wd[34] == 1)
                keyboard(VK_NONCONVERT, S_NONCONVERT);
            if (wu[34] == 1)
                keyboardF(VK_NONCONVERT, S_NONCONVERT);
            valchanged(35, SendACCEPT);
            if (wd[35] == 1)
                keyboard(VK_ACCEPT, S_ACCEPT);
            if (wu[35] == 1)
                keyboardF(VK_ACCEPT, S_ACCEPT);
            valchanged(36, SendMODECHANGE);
            if (wd[36] == 1)
                keyboard(VK_MODECHANGE, S_MODECHANGE);
            if (wu[36] == 1)
                keyboardF(VK_MODECHANGE, S_MODECHANGE);
            valchanged(37, SendSpace);
            if (wd[37] == 1)
                keyboard(VK_Space, S_Space);
            if (wu[37] == 1)
                keyboardF(VK_Space, S_Space);
            valchanged(38, SendPRIOR);
            if (wd[38] == 1)
                keyboard(VK_PRIOR, S_PRIOR);
            if (wu[38] == 1)
                keyboardF(VK_PRIOR, S_PRIOR);
            valchanged(39, SendNEXT);
            if (wd[39] == 1)
                keyboard(VK_NEXT, S_NEXT);
            if (wu[39] == 1)
                keyboardF(VK_NEXT, S_NEXT);
            valchanged(40, SendEND);
            if (wd[40] == 1)
                keyboard(VK_END, S_END);
            if (wu[40] == 1)
                keyboardF(VK_END, S_END);
            valchanged(41, SendHOME);
            if (wd[41] == 1)
                keyboard(VK_HOME, S_HOME);
            if (wu[41] == 1)
                keyboardF(VK_HOME, S_HOME);
            valchanged(42, SendLEFT);
            if (wd[42] == 1)
                keyboard(VK_LEFT, S_LEFT);
            if (wu[42] == 1)
                keyboardF(VK_LEFT, S_LEFT);
            valchanged(43, SendUP);
            if (wd[43] == 1)
                keyboard(VK_UP, S_UP);
            if (wu[43] == 1)
                keyboardF(VK_UP, S_UP);
            valchanged(44, SendRIGHT);
            if (wd[44] == 1)
                keyboard(VK_RIGHT, S_RIGHT);
            if (wu[44] == 1)
                keyboardF(VK_RIGHT, S_RIGHT);
            valchanged(45, SendDOWN);
            if (wd[45] == 1)
                keyboard(VK_DOWN, S_DOWN);
            if (wu[45] == 1)
                keyboardF(VK_DOWN, S_DOWN);
            valchanged(46, SendSELECT);
            if (wd[46] == 1)
                keyboard(VK_SELECT, S_SELECT);
            if (wu[46] == 1)
                keyboardF(VK_SELECT, S_SELECT);
            valchanged(47, SendPRINT);
            if (wd[47] == 1)
                keyboard(VK_PRINT, S_PRINT);
            if (wu[47] == 1)
                keyboardF(VK_PRINT, S_PRINT);
            valchanged(48, SendEXECUTE);
            if (wd[48] == 1)
                keyboard(VK_EXECUTE, S_EXECUTE);
            if (wu[48] == 1)
                keyboardF(VK_EXECUTE, S_EXECUTE);
            valchanged(49, SendSNAPSHOT);
            if (wd[49] == 1)
                keyboard(VK_SNAPSHOT, S_SNAPSHOT);
            if (wu[49] == 1)
                keyboardF(VK_SNAPSHOT, S_SNAPSHOT);
            valchanged(50, SendINSERT);
            if (wd[50] == 1)
                keyboard(VK_INSERT, S_INSERT);
            if (wu[50] == 1)
                keyboardF(VK_INSERT, S_INSERT);
            valchanged(51, SendDELETE);
            if (wd[51] == 1)
                keyboard(VK_DELETE, S_DELETE);
            if (wu[51] == 1)
                keyboardF(VK_DELETE, S_DELETE);
            valchanged(52, SendHELP);
            if (wd[52] == 1)
                keyboard(VK_HELP, S_HELP);
            if (wu[52] == 1)
                keyboardF(VK_HELP, S_HELP);
            valchanged(53, SendAPOSTROPHE);
            if (wd[53] == 1)
                keyboard(VK_APOSTROPHE, S_APOSTROPHE);
            if (wu[53] == 1)
                keyboardF(VK_APOSTROPHE, S_APOSTROPHE);
            valchanged(54, Send0);
            if (wd[54] == 1)
                keyboard(VK_0, S_0);
            if (wu[54] == 1)
                keyboardF(VK_0, S_0);
            valchanged(55, Send1);
            if (wd[55] == 1)
                keyboard(VK_1, S_1);
            if (wu[55] == 1)
                keyboardF(VK_1, S_1);
            valchanged(56, Send2);
            if (wd[56] == 1)
                keyboard(VK_2, S_2);
            if (wu[56] == 1)
                keyboardF(VK_2, S_2);
            valchanged(57, Send3);
            if (wd[57] == 1)
                keyboard(VK_3, S_3);
            if (wu[57] == 1)
                keyboardF(VK_3, S_3);
            valchanged(58, Send4);
            if (wd[58] == 1)
                keyboard(VK_4, S_4);
            if (wu[58] == 1)
                keyboardF(VK_4, S_4);
            valchanged(59, Send5);
            if (wd[59] == 1)
                keyboard(VK_5, S_5);
            if (wu[59] == 1)
                keyboardF(VK_5, S_5);
            valchanged(60, Send6);
            if (wd[60] == 1)
                keyboard(VK_6, S_6);
            if (wu[60] == 1)
                keyboardF(VK_6, S_6);
            valchanged(61, Send7);
            if (wd[61] == 1)
                keyboard(VK_7, S_7);
            if (wu[61] == 1)
                keyboardF(VK_7, S_7);
            valchanged(62, Send8);
            if (wd[62] == 1)
                keyboard(VK_8, S_8);
            if (wu[62] == 1)
                keyboardF(VK_8, S_8);
            valchanged(63, Send9);
            if (wd[63] == 1)
                keyboard(VK_9, S_9);
            if (wu[63] == 1)
                keyboardF(VK_9, S_9);
            valchanged(64, SendA);
            if (wd[64] == 1)
                keyboard(VK_A, S_A);
            if (wu[64] == 1)
                keyboardF(VK_A, S_A);
            valchanged(65, SendB);
            if (wd[65] == 1)
                keyboard(VK_B, S_B);
            if (wu[65] == 1)
                keyboardF(VK_B, S_B);
            valchanged(66, SendC);
            if (wd[66] == 1)
                keyboard(VK_C, S_C);
            if (wu[66] == 1)
                keyboardF(VK_C, S_C);
            valchanged(67, SendD);
            if (wd[67] == 1)
                keyboard(VK_D, S_D);
            if (wu[67] == 1)
                keyboardF(VK_D, S_D);
            valchanged(68, SendE);
            if (wd[68] == 1)
                keyboard(VK_E, S_E);
            if (wu[68] == 1)
                keyboardF(VK_E, S_E);
            valchanged(69, SendF);
            if (wd[69] == 1)
                keyboard(VK_F, S_F);
            if (wu[69] == 1)
                keyboardF(VK_F, S_F);
            valchanged(70, SendG);
            if (wd[70] == 1)
                keyboard(VK_G, S_G);
            if (wu[70] == 1)
                keyboardF(VK_G, S_G);
            valchanged(71, SendH);
            if (wd[71] == 1)
                keyboard(VK_H, S_H);
            if (wu[71] == 1)
                keyboardF(VK_H, S_H);
            valchanged(72, SendI);
            if (wd[72] == 1)
                keyboard(VK_I, S_I);
            if (wu[72] == 1)
                keyboardF(VK_I, S_I);
            valchanged(73, SendJ);
            if (wd[73] == 1)
                keyboard(VK_J, S_J);
            if (wu[73] == 1)
                keyboardF(VK_J, S_J);
            valchanged(74, SendK);
            if (wd[74] == 1)
                keyboard(VK_K, S_K);
            if (wu[74] == 1)
                keyboardF(VK_K, S_K);
            valchanged(75, SendL);
            if (wd[75] == 1)
                keyboard(VK_L, S_L);
            if (wu[75] == 1)
                keyboardF(VK_L, S_L);
            valchanged(76, SendM);
            if (wd[76] == 1)
                keyboard(VK_M, S_M);
            if (wu[76] == 1)
                keyboardF(VK_M, S_M);
            valchanged(77, SendN);
            if (wd[77] == 1)
                keyboard(VK_N, S_N);
            if (wu[77] == 1)
                keyboardF(VK_N, S_N);
            valchanged(78, SendO);
            if (wd[78] == 1)
                keyboard(VK_O, S_O);
            if (wu[78] == 1)
                keyboardF(VK_O, S_O);
            valchanged(79, SendP);
            if (wd[79] == 1)
                keyboard(VK_P, S_P);
            if (wu[79] == 1)
                keyboardF(VK_P, S_P);
            valchanged(80, SendQ);
            if (wd[80] == 1)
                keyboard(VK_Q, S_Q);
            if (wu[80] == 1)
                keyboardF(VK_Q, S_Q);
            valchanged(81, SendR);
            if (wd[81] == 1)
                keyboard(VK_R, S_R);
            if (wu[81] == 1)
                keyboardF(VK_R, S_R);
            valchanged(82, SendS);
            if (wd[82] == 1)
                keyboard(VK_S, S_S);
            if (wu[82] == 1)
                keyboardF(VK_S, S_S);
            valchanged(83, SendT);
            if (wd[83] == 1)
                keyboard(VK_T, S_T);
            if (wu[83] == 1)
                keyboardF(VK_T, S_T);
            valchanged(84, SendU);
            if (wd[84] == 1)
                keyboard(VK_U, S_U);
            if (wu[84] == 1)
                keyboardF(VK_U, S_U);
            valchanged(85, SendV);
            if (wd[85] == 1)
                keyboard(VK_V, S_V);
            if (wu[85] == 1)
                keyboardF(VK_V, S_V);
            valchanged(86, SendW);
            if (wd[86] == 1)
                keyboard(VK_W, S_W);
            if (wu[86] == 1)
                keyboardF(VK_W, S_W);
            valchanged(87, SendX);
            if (wd[87] == 1)
                keyboard(VK_X, S_X);
            if (wu[87] == 1)
                keyboardF(VK_X, S_X);
            valchanged(88, SendY);
            if (wd[88] == 1)
                keyboard(VK_Y, S_Y);
            if (wu[88] == 1)
                keyboardF(VK_Y, S_Y);
            valchanged(89, SendZ);
            if (wd[89] == 1)
                keyboard(VK_Z, S_Z);
            if (wu[89] == 1)
                keyboardF(VK_Z, S_Z);
            valchanged(90, SendLWIN);
            if (wd[90] == 1)
                keyboard(VK_LWIN, S_LWIN);
            if (wu[90] == 1)
                keyboardF(VK_LWIN, S_LWIN);
            valchanged(91, SendRWIN);
            if (wd[91] == 1)
                keyboard(VK_RWIN, S_RWIN);
            if (wu[91] == 1)
                keyboardF(VK_RWIN, S_RWIN);
            valchanged(92, SendAPPS);
            if (wd[92] == 1)
                keyboard(VK_APPS, S_APPS);
            if (wu[92] == 1)
                keyboardF(VK_APPS, S_APPS);
            valchanged(93, SendSLEEP);
            if (wd[93] == 1)
                keyboard(VK_SLEEP, S_SLEEP);
            if (wu[93] == 1)
                keyboardF(VK_SLEEP, S_SLEEP);
            valchanged(94, SendNUMPAD0);
            if (wd[94] == 1)
                keyboard(VK_NUMPAD0, S_NUMPAD0);
            if (wu[94] == 1)
                keyboardF(VK_NUMPAD0, S_NUMPAD0);
            valchanged(95, SendNUMPAD1);
            if (wd[95] == 1)
                keyboard(VK_NUMPAD1, S_NUMPAD1);
            if (wu[95] == 1)
                keyboardF(VK_NUMPAD1, S_NUMPAD1);
            valchanged(96, SendNUMPAD2);
            if (wd[96] == 1)
                keyboard(VK_NUMPAD2, S_NUMPAD2);
            if (wu[96] == 1)
                keyboardF(VK_NUMPAD2, S_NUMPAD2);
            valchanged(97, SendNUMPAD3);
            if (wd[97] == 1)
                keyboard(VK_NUMPAD3, S_NUMPAD3);
            if (wu[97] == 1)
                keyboardF(VK_NUMPAD3, S_NUMPAD3);
            valchanged(98, SendNUMPAD4);
            if (wd[98] == 1)
                keyboard(VK_NUMPAD4, S_NUMPAD4);
            if (wu[98] == 1)
                keyboardF(VK_NUMPAD4, S_NUMPAD4);
            valchanged(99, SendNUMPAD5);
            if (wd[99] == 1)
                keyboard(VK_NUMPAD5, S_NUMPAD5);
            if (wu[99] == 1)
                keyboardF(VK_NUMPAD5, S_NUMPAD5);
            valchanged(100, SendNUMPAD6);
            if (wd[100] == 1)
                keyboard(VK_NUMPAD6, S_NUMPAD6);
            if (wu[100] == 1)
                keyboardF(VK_NUMPAD6, S_NUMPAD6);
            valchanged(101, SendNUMPAD7);
            if (wd[101] == 1)
                keyboard(VK_NUMPAD7, S_NUMPAD7);
            if (wu[101] == 1)
                keyboardF(VK_NUMPAD7, S_NUMPAD7);
            valchanged(102, SendNUMPAD8);
            if (wd[102] == 1)
                keyboard(VK_NUMPAD8, S_NUMPAD8);
            if (wu[102] == 1)
                keyboardF(VK_NUMPAD8, S_NUMPAD8);
            valchanged(103, SendNUMPAD9);
            if (wd[103] == 1)
                keyboard(VK_NUMPAD9, S_NUMPAD9);
            if (wu[103] == 1)
                keyboardF(VK_NUMPAD9, S_NUMPAD9);
            valchanged(104, SendMULTIPLY);
            if (wd[104] == 1)
                keyboard(VK_MULTIPLY, S_MULTIPLY);
            if (wu[104] == 1)
                keyboardF(VK_MULTIPLY, S_MULTIPLY);
            valchanged(105, SendADD);
            if (wd[105] == 1)
                keyboard(VK_ADD, S_ADD);
            if (wu[105] == 1)
                keyboardF(VK_ADD, S_ADD);
            valchanged(106, SendSEPARATOR);
            if (wd[106] == 1)
                keyboard(VK_SEPARATOR, S_SEPARATOR);
            if (wu[106] == 1)
                keyboardF(VK_SEPARATOR, S_SEPARATOR);
            valchanged(107, SendSUBTRACT);
            if (wd[107] == 1)
                keyboard(VK_SUBTRACT, S_SUBTRACT);
            if (wu[107] == 1)
                keyboardF(VK_SUBTRACT, S_SUBTRACT);
            valchanged(108, SendDECIMAL);
            if (wd[108] == 1)
                keyboard(VK_DECIMAL, S_DECIMAL);
            if (wu[108] == 1)
                keyboardF(VK_DECIMAL, S_DECIMAL);
            valchanged(109, SendDIVIDE);
            if (wd[109] == 1)
                keyboard(VK_DIVIDE, S_DIVIDE);
            if (wu[109] == 1)
                keyboardF(VK_DIVIDE, S_DIVIDE);
            valchanged(110, SendF1);
            if (wd[110] == 1)
                keyboard(VK_F1, S_F1);
            if (wu[110] == 1)
                keyboardF(VK_F1, S_F1);
            valchanged(111, SendF2);
            if (wd[111] == 1)
                keyboard(VK_F2, S_F2);
            if (wu[111] == 1)
                keyboardF(VK_F2, S_F2);
            valchanged(112, SendF3);
            if (wd[112] == 1)
                keyboard(VK_F3, S_F3);
            if (wu[112] == 1)
                keyboardF(VK_F3, S_F3);
            valchanged(113, SendF4);
            if (wd[113] == 1)
                keyboard(VK_F4, S_F4);
            if (wu[113] == 1)
                keyboardF(VK_F4, S_F4);
            valchanged(114, SendF5);
            if (wd[114] == 1)
                keyboard(VK_F5, S_F5);
            if (wu[114] == 1)
                keyboardF(VK_F5, S_F5);
            valchanged(115, SendF6);
            if (wd[115] == 1)
                keyboard(VK_F6, S_F6);
            if (wu[115] == 1)
                keyboardF(VK_F6, S_F6);
            valchanged(116, SendF7);
            if (wd[116] == 1)
                keyboard(VK_F7, S_F7);
            if (wu[116] == 1)
                keyboardF(VK_F7, S_F7);
            valchanged(117, SendF8);
            if (wd[117] == 1)
                keyboard(VK_F8, S_F8);
            if (wu[117] == 1)
                keyboardF(VK_F8, S_F8);
            valchanged(118, SendF9);
            if (wd[118] == 1)
                keyboard(VK_F9, S_F9);
            if (wu[118] == 1)
                keyboardF(VK_F9, S_F9);
            valchanged(119, SendF10);
            if (wd[119] == 1)
                keyboard(VK_F10, S_F10);
            if (wu[119] == 1)
                keyboardF(VK_F10, S_F10);
            valchanged(120, SendF11);
            if (wd[120] == 1)
                keyboard(VK_F11, S_F11);
            if (wu[120] == 1)
                keyboardF(VK_F11, S_F11);
            valchanged(121, SendF12);
            if (wd[121] == 1)
                keyboard(VK_F12, S_F12);
            if (wu[121] == 1)
                keyboardF(VK_F12, S_F12);
            valchanged(122, SendF13);
            if (wd[122] == 1)
                keyboard(VK_F13, S_F13);
            if (wu[122] == 1)
                keyboardF(VK_F13, S_F13);
            valchanged(123, SendF14);
            if (wd[123] == 1)
                keyboard(VK_F14, S_F14);
            if (wu[123] == 1)
                keyboardF(VK_F14, S_F14);
            valchanged(124, SendF15);
            if (wd[124] == 1)
                keyboard(VK_F15, S_F15);
            if (wu[124] == 1)
                keyboardF(VK_F15, S_F15);
            valchanged(125, SendF16);
            if (wd[125] == 1)
                keyboard(VK_F16, S_F16);
            if (wu[125] == 1)
                keyboardF(VK_F16, S_F16);
            valchanged(126, SendF17);
            if (wd[126] == 1)
                keyboard(VK_F17, S_F17);
            if (wu[126] == 1)
                keyboardF(VK_F17, S_F17);
            valchanged(127, SendF18);
            if (wd[127] == 1)
                keyboard(VK_F18, S_F18);
            if (wu[127] == 1)
                keyboardF(VK_F18, S_F18);
            valchanged(128, SendF19);
            if (wd[128] == 1)
                keyboard(VK_F19, S_F19);
            if (wu[128] == 1)
                keyboardF(VK_F19, S_F19);
            valchanged(129, SendF20);
            if (wd[129] == 1)
                keyboard(VK_F20, S_F20);
            if (wu[129] == 1)
                keyboardF(VK_F20, S_F20);
            valchanged(130, SendF21);
            if (wd[130] == 1)
                keyboard(VK_F21, S_F21);
            if (wu[130] == 1)
                keyboardF(VK_F21, S_F21);
            valchanged(131, SendF22);
            if (wd[131] == 1)
                keyboard(VK_F22, S_F22);
            if (wu[131] == 1)
                keyboardF(VK_F22, S_F22);
            valchanged(132, SendF23);
            if (wd[132] == 1)
                keyboard(VK_F23, S_F23);
            if (wu[132] == 1)
                keyboardF(VK_F23, S_F23);
            valchanged(133, SendF24);
            if (wd[133] == 1)
                keyboard(VK_F24, S_F24);
            if (wu[133] == 1)
                keyboardF(VK_F24, S_F24);
            valchanged(134, SendNUMLOCK);
            if (wd[134] == 1)
                keyboard(VK_NUMLOCK, S_NUMLOCK);
            if (wu[134] == 1)
                keyboardF(VK_NUMLOCK, S_NUMLOCK);
            valchanged(135, SendSCROLL);
            if (wd[135] == 1)
                keyboard(VK_SCROLL, S_SCROLL);
            if (wu[135] == 1)
                keyboardF(VK_SCROLL, S_SCROLL);
            valchanged(136, SendLeftShift);
            if (wd[136] == 1)
                keyboard(VK_LeftShift, S_LeftShift);
            if (wu[136] == 1)
                keyboardF(VK_LeftShift, S_LeftShift);
            valchanged(137, SendRightShift);
            if (wd[137] == 1)
                keyboard(VK_RightShift, S_RightShift);
            if (wu[137] == 1)
                keyboardF(VK_RightShift, S_RightShift);
            valchanged(138, SendLeftControl);
            if (wd[138] == 1)
                keyboard(VK_LeftControl, S_LeftControl);
            if (wu[138] == 1)
                keyboardF(VK_LeftControl, S_LeftControl);
            valchanged(139, SendRightControl);
            if (wd[139] == 1)
                keyboard(VK_RightControl, S_RightControl);
            if (wu[139] == 1)
                keyboardF(VK_RightControl, S_RightControl);
            valchanged(140, SendLMENU);
            if (wd[140] == 1)
                keyboard(VK_LMENU, S_LMENU);
            if (wu[140] == 1)
                keyboardF(VK_LMENU, S_LMENU);
            valchanged(141, SendRMENU);
            if (wd[141] == 1)
                keyboard(VK_RMENU, S_RMENU);
            if (wu[141] == 1)
                keyboardF(VK_RMENU, S_RMENU);
        }
        public static void mousebrink(int x, int y)
        {
            if (drivertype == "sendinput")
                MoveMouseBy(x, y);
            else
                MouseBrink(x, y);
        }
        public static void mousemw3(int x, int y)
        {
            if (drivertype == "sendinput")
                MoveMouseTo(x, y);
            else
                MouseMW3(x, y);
        }
        public static void mouseclickleft()
        {
            if (drivertype == "sendinput")
                SendMouseEventButtonLeft();
            else
                LeftClick();
        }
        public static void mouseclickleftF()
        {
            if (drivertype == "sendinput")
                SendMouseEventButtonLeftF();
            else
                LeftClickF();
        }
        public static void mouseclickright()
        {
            if (drivertype == "sendinput")
                SendMouseEventButtonRight();
            else
                RightClick();
        }
        public static void mouseclickrightF()
        {
            if (drivertype == "sendinput")
                SendMouseEventButtonRightF();
            else
                RightClickF();
        }
        public static void mouseclickmiddle()
        {
            if (drivertype == "sendinput")
                SendMouseEventButtonMiddle();
            else
                MiddleClick();
        }
        public static void mouseclickmiddleF()
        {
            if (drivertype == "sendinput")
                SendMouseEventButtonMiddleF();
            else
                MiddleClickF();
        }
        public static void mousewheelup()
        {
            if (drivertype == "sendinput")
                SendMouseEventButtonWheelUp();
            else
                WheelUpF();
        }
        public static void mousewheeldown()
        {
            if (drivertype == "sendinput")
                SendMouseEventButtonWheelDown();
            else
                WheelDownF();
        }
        public static void keyboard(UInt16 bVk, UInt16 bScan)
        {
            if (drivertype == "sendinput")
                SendKey(bVk, bScan);
            else
                SimulateKeyDown(bVk, bScan);
        }
        public static void keyboardF(UInt16 bVk, UInt16 bScan)
        {
            if (drivertype == "sendinput")
                SendKeyF(bVk, bScan);
            else
                SimulateKeyUp(bVk, bScan);
        }
        public static void keyboardArrows(UInt16 bVk, UInt16 bScan)
        {
            if (drivertype == "sendinput")
                SendKeyArrows(bVk, bScan);
            else
                SimulateKeyDownArrows(bVk, bScan);
        }
        public static void keyboardArrowsF(UInt16 bVk, UInt16 bScan)
        {
            if (drivertype == "sendinput")
                SendKeyArrowsF(bVk, bScan);
            else
                SimulateKeyUpArrows(bVk, bScan);
        }
    }
    public class ScpBus : IDisposable
    {
        public static int[] wd = { 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2 };
        public static int[] wu = { 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2 };
        public static void valchanged(int n, bool val)
        {
            if (val)
            {
                if (wd[n] <= 1)
                {
                    wd[n] = wd[n] + 1;
                }
                wu[n] = 0;
            }
            else
            {
                if (wu[n] <= 1)
                {
                    wu[n] = wu[n] + 1;
                }
                wd[n] = 0;
            }
        }
        public static ScpBus scpBus;
        public static X360Controller controller;
        public static void LoadController()
        {
            scpBus = new ScpBus();
            scpBus.PlugIn(1);
            controller = new X360Controller();
        }
        public static void UnLoadController()
        {
            SetController(false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, 0, 0, 0, 0);
            Thread.Sleep(100);
            scpBus.Unplug(1);
        }
        public static void SetController(bool back, bool start, bool A, bool B, bool X, bool Y, bool up, bool left, bool down, bool right, bool leftstick, bool rightstick, bool leftbumper, bool rightbumper, bool lefttrigger, bool righttrigger, double leftstickx, double leftsticky, double rightstickx, double rightsticky)
        {
            valchanged(1, back);
            if (wd[1] == 1)
                controller.Buttons ^= X360Buttons.Back;
            if (wu[1] == 1)
                controller.Buttons &= ~X360Buttons.Back;
            valchanged(2, start);
            if (wd[2] == 1)
                controller.Buttons ^= X360Buttons.Start;
            if (wu[2] == 1)
                controller.Buttons &= ~X360Buttons.Start;
            valchanged(3, A);
            if (wd[3] == 1)
                controller.Buttons ^= X360Buttons.A;
            if (wu[3] == 1)
                controller.Buttons &= ~X360Buttons.A;
            valchanged(4, B);
            if (wd[4] == 1)
                controller.Buttons ^= X360Buttons.B;
            if (wu[4] == 1)
                controller.Buttons &= ~X360Buttons.B;
            valchanged(5, X);
            if (wd[5] == 1)
                controller.Buttons ^= X360Buttons.X;
            if (wu[5] == 1)
                controller.Buttons &= ~X360Buttons.X;
            valchanged(6, Y);
            if (wd[6] == 1)
                controller.Buttons ^= X360Buttons.Y;
            if (wu[6] == 1)
                controller.Buttons &= ~X360Buttons.Y;
            valchanged(7, up);
            if (wd[7] == 1)
                controller.Buttons ^= X360Buttons.Up;
            if (wu[7] == 1)
                controller.Buttons &= ~X360Buttons.Up;
            valchanged(8, left);
            if (wd[8] == 1)
                controller.Buttons ^= X360Buttons.Left;
            if (wu[8] == 1)
                controller.Buttons &= ~X360Buttons.Left;
            valchanged(9, down);
            if (wd[9] == 1)
                controller.Buttons ^= X360Buttons.Down;
            if (wu[9] == 1)
                controller.Buttons &= ~X360Buttons.Down;
            valchanged(10, right);
            if (wd[10] == 1)
                controller.Buttons ^= X360Buttons.Right;
            if (wu[10] == 1)
                controller.Buttons &= ~X360Buttons.Right;
            valchanged(11, leftstick);
            if (wd[11] == 1)
                controller.Buttons ^= X360Buttons.LeftStick;
            if (wu[11] == 1)
                controller.Buttons &= ~X360Buttons.LeftStick;
            valchanged(12, rightstick);
            if (wd[12] == 1)
                controller.Buttons ^= X360Buttons.RightStick;
            if (wu[12] == 1)
                controller.Buttons &= ~X360Buttons.RightStick;
            valchanged(13, leftbumper);
            if (wd[13] == 1)
                controller.Buttons ^= X360Buttons.LeftBumper;
            if (wu[13] == 1)
                controller.Buttons &= ~X360Buttons.LeftBumper;
            valchanged(14, rightbumper);
            if (wd[14] == 1)
                controller.Buttons ^= X360Buttons.RightBumper;
            if (wu[14] == 1)
                controller.Buttons &= ~X360Buttons.RightBumper;
            if (lefttrigger)
                controller.LeftTrigger = 255;
            else
                controller.LeftTrigger = 0;
            if (righttrigger)
                controller.RightTrigger = 255;
            else
                controller.RightTrigger = 0;
            controller.LeftStickX = (short)leftstickx;
            controller.LeftStickY = (short)leftsticky;
            controller.RightStickX = (short)rightstickx;
            controller.RightStickY = (short)rightsticky;
            scpBus.Report(controller.GetReport());
        }
        public const string SCP_BUS_CLASS_GUID = "{F679F562-3164-42CE-A4DB-E7DDBE723909}";
        public const int ReportSize = 28;

        public readonly SafeFileHandle _deviceHandle;

        /// <summary>
        /// Creates a new ScpBus object, which will then try to get a handle to the SCP Virtual Bus device. If it is unable to get the handle, an IOException will be thrown.
        /// </summary>
        public ScpBus() : this(0) { }

        /// <summary>
        /// Creates a new ScpBus object, which will then try to get a handle to the SCP Virtual Bus device. If it is unable to get the handle, an IOException will be thrown.
        /// </summary>
        /// <param name="instance">Specifies which SCP Virtual Bus device to use. This is 0-based.</param>
        public ScpBus(int instance)
        {
            string devicePath = "";

            if (Find(new Guid(SCP_BUS_CLASS_GUID), ref devicePath, instance))
            {
                _deviceHandle = GetHandle(devicePath);
            }
            else
            {
                throw new IOException("SCP Virtual Bus Device not found");
            }
        }

        /// <summary>
        /// Creates a new ScpBus object, which will then try to get a handle to the specified SCP Virtual Bus device. If it is unable to get the handle, an IOException will be thrown.
        /// </summary>
        /// <param name="devicePath">The path to the SCP Virtual Bus device that you want to use.</param>
        public ScpBus(string devicePath)
        {
            _deviceHandle = GetHandle(devicePath);
        }

        /// <summary>
        /// Closes the handle to the SCP Virtual Bus device. Call this when you are done with your instance of ScpBus.
        /// 
        /// (This method does the same thing as the Dispose() method. Use one or the other.)
        /// </summary>
        public void Close()
        {
            Dispose();
        }

        /// <summary>
        /// Closes the handle to the SCP Virtual Bus device. Call this when you are done with your instance of ScpBus.
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Internal disposer, called by either the finalizer or the Dispose() method.
        /// </summary>
        /// <param name="disposing">True if called from Dispose(), false if called from finalizer.</param>
        protected virtual void Dispose(bool disposing)
        {
            if (_deviceHandle != null && !_deviceHandle.IsInvalid)
            {
                _deviceHandle.Dispose();
            }
        }

        /// <summary>
        /// Plugs in an emulated Xbox 360 controller.
        /// </summary>
        /// <param name="controllerNumber">Used to identify the controller. Give each controller you plug in a different number. Number must be non-zero.</param>
        /// <returns>True if the operation was successful, false otherwise.</returns>
        public bool PlugIn(int controllerNumber)
        {
            if (_deviceHandle.IsInvalid)
                throw new ObjectDisposedException("SCP Virtual Bus device handle is closed");

            int transfered = 0;
            byte[] buffer = new byte[16];

            buffer[0] = 0x10;
            buffer[1] = 0x00;
            buffer[2] = 0x00;
            buffer[3] = 0x00;

            buffer[4] = (byte)((controllerNumber) & 0xFF);
            buffer[5] = (byte)((controllerNumber >> 8) & 0xFF);
            buffer[6] = (byte)((controllerNumber >> 16) & 0xFF);
            buffer[7] = (byte)((controllerNumber >> 24) & 0xFF);

            return NativeMethods.DeviceIoControl(_deviceHandle, 0x2A4000, buffer, buffer.Length, null, 0, ref transfered, IntPtr.Zero);
        }

        /// <summary>
        /// Unplugs an emulated Xbox 360 controller.
        /// </summary>
        /// <param name="controllerNumber">The controller you want to unplug.</param>
        /// <returns>True if the operation was successful, false otherwise.</returns>
        public bool Unplug(int controllerNumber)
        {
            if (_deviceHandle.IsInvalid)
                throw new ObjectDisposedException("SCP Virtual Bus device handle is closed");

            int transfered = 0;
            byte[] buffer = new Byte[16];

            buffer[0] = 0x10;
            buffer[1] = 0x00;
            buffer[2] = 0x00;
            buffer[3] = 0x00;

            buffer[4] = (byte)((controllerNumber) & 0xFF);
            buffer[5] = (byte)((controllerNumber >> 8) & 0xFF);
            buffer[6] = (byte)((controllerNumber >> 16) & 0xFF);
            buffer[7] = (byte)((controllerNumber >> 24) & 0xFF);

            return NativeMethods.DeviceIoControl(_deviceHandle, 0x2A4004, buffer, buffer.Length, null, 0, ref transfered, IntPtr.Zero);
        }

        /// <summary>
        /// Unplugs all emulated Xbox 360 controllers.
        /// </summary>
        /// <returns>True if the operation was successful, false otherwise.</returns>
        public bool UnplugAll()
        {
            if (_deviceHandle.IsInvalid)
                throw new ObjectDisposedException("SCP Virtual Bus device handle is closed");

            int transfered = 0;
            byte[] buffer = new byte[16];

            buffer[0] = 0x10;
            buffer[1] = 0x00;
            buffer[2] = 0x00;
            buffer[3] = 0x00;

            return NativeMethods.DeviceIoControl(_deviceHandle, 0x2A4004, buffer, buffer.Length, null, 0, ref transfered, IntPtr.Zero);
        }
        int transferred;
        byte[] outputBuffer = null;
        /// <summary>
        /// Sends an input report for the current state of the specified emulated Xbox 360 controller. Note: Only use this if you don't care about rumble data, otherwise use the 3-parameter version of Report().
        /// </summary>
        /// <param name="controllerNumber">The controller to report.</param>
        /// <param name="controllerReport">The controller report. If using the included X360Controller class, this can be generated with the GetReport() method. Otherwise see http://free60.org/wiki/GamePad#Input_report for details.</param>
        /// <returns>True if the operation was successful, false otherwise.</returns>
        public bool Report(byte[] controllerReport)
        {
            return NativeMethods.DeviceIoControl(_deviceHandle, 0x2A400C, controllerReport, controllerReport.Length, outputBuffer, outputBuffer?.Length ?? 0, ref transferred, IntPtr.Zero);
        }

        public static bool Find(Guid target, ref string path, int instance = 0)
        {
            IntPtr detailDataBuffer = IntPtr.Zero;
            IntPtr deviceInfoSet = IntPtr.Zero;

            try
            {
                NativeMethods.SP_DEVICE_INTERFACE_DATA DeviceInterfaceData = new NativeMethods.SP_DEVICE_INTERFACE_DATA(), da = new NativeMethods.SP_DEVICE_INTERFACE_DATA();
                int bufferSize = 0, memberIndex = 0;

                deviceInfoSet = NativeMethods.SetupDiGetClassDevs(ref target, IntPtr.Zero, IntPtr.Zero, NativeMethods.DIGCF_PRESENT | NativeMethods.DIGCF_DEVICEINTERFACE);

                DeviceInterfaceData.cbSize = da.cbSize = Marshal.SizeOf(DeviceInterfaceData);

                while (NativeMethods.SetupDiEnumDeviceInterfaces(deviceInfoSet, IntPtr.Zero, ref target, memberIndex, ref DeviceInterfaceData))
                {
                    NativeMethods.SetupDiGetDeviceInterfaceDetail(deviceInfoSet, ref DeviceInterfaceData, IntPtr.Zero, 0, ref bufferSize, ref da);
                    detailDataBuffer = Marshal.AllocHGlobal(bufferSize);

                    Marshal.WriteInt32(detailDataBuffer, (IntPtr.Size == 4) ? (4 + Marshal.SystemDefaultCharSize) : 8);

                    if (NativeMethods.SetupDiGetDeviceInterfaceDetail(deviceInfoSet, ref DeviceInterfaceData, detailDataBuffer, bufferSize, ref bufferSize, ref da))
                    {
                        IntPtr pDevicePathName = detailDataBuffer + 4;

                        path = Marshal.PtrToStringAuto(pDevicePathName).ToUpper(CultureInfo.InvariantCulture);
                        Marshal.FreeHGlobal(detailDataBuffer);

                        if (memberIndex == instance) return true;
                    }
                    else Marshal.FreeHGlobal(detailDataBuffer);


                    memberIndex++;
                }
            }
            finally
            {
                if (deviceInfoSet != IntPtr.Zero)
                {
                    NativeMethods.SetupDiDestroyDeviceInfoList(deviceInfoSet);
                }
            }

            return false;
        }

        public static SafeFileHandle GetHandle(string devicePath)
        {
            devicePath = devicePath.ToUpper(CultureInfo.InvariantCulture);

            SafeFileHandle handle = NativeMethods.CreateFile(devicePath, (NativeMethods.GENERIC_WRITE | NativeMethods.GENERIC_READ), NativeMethods.FILE_SHARE_READ | NativeMethods.FILE_SHARE_WRITE, IntPtr.Zero, NativeMethods.OPEN_EXISTING, NativeMethods.FILE_ATTRIBUTE_NORMAL | NativeMethods.FILE_FLAG_OVERLAPPED, UIntPtr.Zero);

            if (handle == null || handle.IsInvalid)
            {
                throw new IOException("Unable to get SCP Virtual Bus Device handle");
            }

            return handle;
        }
    }

    internal static class NativeMethods
    {
        [StructLayout(LayoutKind.Sequential)]
        internal struct SP_DEVICE_INTERFACE_DATA
        {
            internal int cbSize;
            internal Guid InterfaceClassGuid;
            internal int Flags;
            internal IntPtr Reserved;
        }

        internal const uint FILE_ATTRIBUTE_NORMAL = 0x80;
        internal const uint FILE_FLAG_OVERLAPPED = 0x40000000;
        internal const uint FILE_SHARE_READ = 1;
        internal const uint FILE_SHARE_WRITE = 2;
        internal const uint GENERIC_READ = 0x80000000;
        internal const uint GENERIC_WRITE = 0x40000000;
        internal const uint OPEN_EXISTING = 3;
        internal const int DIGCF_PRESENT = 0x0002;
        internal const int DIGCF_DEVICEINTERFACE = 0x0010;

        [DllImport("kernel32.dll", SetLastError = true, CharSet = CharSet.Unicode)]
        internal static extern SafeFileHandle CreateFile(string lpFileName, uint dwDesiredAccess, uint dwShareMode, IntPtr lpSecurityAttributes, uint dwCreationDisposition, uint dwFlagsAndAttributes, UIntPtr hTemplateFile);

        [DllImport("kernel32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        internal static extern bool DeviceIoControl(SafeFileHandle hDevice, int dwIoControlCode, byte[] lpInBuffer, int nInBufferSize, byte[] lpOutBuffer, int nOutBufferSize, ref int lpBytesReturned, IntPtr lpOverlapped);

        [DllImport("setupapi.dll", SetLastError = true)]
        internal static extern int SetupDiDestroyDeviceInfoList(IntPtr deviceInfoSet);

        [DllImport("setupapi.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        internal static extern bool SetupDiEnumDeviceInterfaces(IntPtr hDevInfo, IntPtr devInfo, ref Guid interfaceClassGuid, int memberIndex, ref SP_DEVICE_INTERFACE_DATA deviceInterfaceData);

        [DllImport("setupapi.dll", SetLastError = true, CharSet = CharSet.Auto)]
        internal static extern IntPtr SetupDiGetClassDevs(ref Guid classGuid, IntPtr enumerator, IntPtr hwndParent, int flags);

        [DllImport("setupapi.dll", SetLastError = true, CharSet = CharSet.Auto)]
        [return: MarshalAs(UnmanagedType.Bool)]
        internal static extern bool SetupDiGetDeviceInterfaceDetail(IntPtr hDevInfo, ref SP_DEVICE_INTERFACE_DATA deviceInterfaceData, IntPtr deviceInterfaceDetailData, int deviceInterfaceDetailDataSize, ref int requiredSize, ref SP_DEVICE_INTERFACE_DATA deviceInfoData);
    }
    /// <summary>
    /// A virtual Xbox 360 Controller. After setting the desired values, use the GetReport() method to generate a controller report that can be used with ScpBus's Report() method.
    /// </summary>
    public class X360Controller
    {
        /// <summary>
        /// Generates a new X360Controller object with the default initial state (no buttons pressed, all analog inputs 0).
        /// </summary>
        public X360Controller()
        {
            Buttons = X360Buttons.None;
            LeftTrigger = 0;
            RightTrigger = 0;
            LeftStickX = 0;
            LeftStickY = 0;
            RightStickX = 0;
            RightStickY = 0;
        }

        /// <summary>
        /// Generates a new X360Controller object. Optionally, you can specify the initial state of the controller.
        /// </summary>
        /// <param name="buttons">The pressed buttons. Use like flags (i.e. (X360Buttons.A | X360Buttons.X) would be mean both A and X are pressed).</param>
        /// <param name="leftTrigger">Left trigger analog input. 0 to 255.</param>
        /// <param name="rightTrigger">Right trigger analog input. 0 to 255.</param>
        /// <param name="leftStickX">Left stick X-axis. -32,768 to 32,767.</param>
        /// <param name="leftStickY">Left stick Y-axis. -32,768 to 32,767.</param>
        /// <param name="rightStickX">Right stick X-axis. -32,768 to 32,767.</param>
        /// <param name="rightStickY">Right stick Y-axis. -32,768 to 32,767.</param>
        public X360Controller(X360Buttons buttons, byte leftTrigger, byte rightTrigger, short leftStickX, short leftStickY, short rightStickX, short rightStickY)
        {
            Buttons = buttons;
            LeftTrigger = leftTrigger;
            RightTrigger = rightTrigger;
            LeftStickX = leftStickX;
            LeftStickY = leftStickY;
            RightStickX = rightStickX;
            RightStickY = rightStickY;
        }

        /// <summary>
        /// Generates a new X360Controller object with the same values as the specified X360Controller object.
        /// </summary>
        /// <param name="controller">An X360Controller object to copy values from.</param>
        public X360Controller(X360Controller controller)
        {
            Buttons = controller.Buttons;
            LeftTrigger = controller.LeftTrigger;
            RightTrigger = controller.RightTrigger;
            LeftStickX = controller.LeftStickX;
            LeftStickY = controller.LeftStickY;
            RightStickX = controller.RightStickX;
            RightStickY = controller.RightStickY;
        }

        /// <summary>
        /// The controller's currently pressed buttons. Use the X360Button values like flags (i.e. (X360Buttons.A | X360Buttons.X) would be mean both A and X are pressed).
        /// </summary>
        public X360Buttons Buttons { get; set; }

        /// <summary>
        /// The controller's left trigger analog input. Value can range from 0 to 255.
        /// </summary>
        public byte LeftTrigger { get; set; }

        /// <summary>
        /// The controller's right trigger analog input. Value can range from 0 to 255.
        /// </summary>
        public byte RightTrigger { get; set; }

        /// <summary>
        /// The controller's left stick X-axis. Value can range from -32,768 to 32,767.
        /// </summary>
        public short LeftStickX { get; set; }

        /// <summary>
        /// The controller's left stick Y-axis. Value can range from -32,768 to 32,767.
        /// </summary>
        public short LeftStickY { get; set; }

        /// <summary>
        /// The controller's right stick X-axis. Value can range from -32,768 to 32,767.
        /// </summary>
        public short RightStickX { get; set; }

        /// <summary>
        /// The controller's right stick Y-axis. Value can range from -32,768 to 32,767.
        /// </summary>
        public short RightStickY { get; set; }

        byte[] bytes = new byte[20];
        byte[] fullReport = { 0x1C, 0, 0, 0, (byte)((1) & 0xFF), (byte)((1 >> 8) & 0xFF), (byte)((1 >> 16) & 0xFF), (byte)((1 >> 24) & 0xFF), 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        /// <summary>
        /// Generates an Xbox 360 controller report as specified here: http://free60.org/wiki/GamePad#Input_report. This can be used with ScpBus's Report() method.
        /// </summary>
        /// <returns>A 20-byte Xbox 360 controller report.</returns>
        public byte[] GetReport()
        {
            bytes[0] = 0x00;                                 // Message type (input report)
            bytes[1] = 0x14;                                 // Message size (20 bytes)

            bytes[2] = (byte)((ushort)Buttons & 0xFF);       // Buttons low
            bytes[3] = (byte)((ushort)Buttons >> 8 & 0xFF);  // Buttons high

            bytes[4] = LeftTrigger;                          // Left trigger
            bytes[5] = RightTrigger;                         // Right trigger

            bytes[6] = (byte)(LeftStickX & 0xFF);            // Left stick X-axis low
            bytes[7] = (byte)(LeftStickX >> 8 & 0xFF);       // Left stick X-axis high
            bytes[8] = (byte)(LeftStickY & 0xFF);            // Left stick Y-axis low
            bytes[9] = (byte)(LeftStickY >> 8 & 0xFF);       // Left stick Y-axis high

            bytes[10] = (byte)(RightStickX & 0xFF);          // Right stick X-axis low
            bytes[11] = (byte)(RightStickX >> 8 & 0xFF);     // Right stick X-axis high
            bytes[12] = (byte)(RightStickY & 0xFF);          // Right stick Y-axis low
            bytes[13] = (byte)(RightStickY >> 8 & 0xFF);     // Right stick Y-axis high

            // Remaining bytes are unused

            System.Array.Copy(bytes, 0, fullReport, 8, 20);

            return fullReport;
        }
    }

    /// <summary>
    /// The buttons to be used with an X360Controller object.
    /// </summary>
    [Flags]
    public enum X360Buttons
    {
        None = 0,

        Up = 1 << 0,
        Down = 1 << 1,
        Left = 1 << 2,
        Right = 1 << 3,

        Start = 1 << 4,
        Back = 1 << 5,

        LeftStick = 1 << 6,
        RightStick = 1 << 7,

        LeftBumper = 1 << 8,
        RightBumper = 1 << 9,

        Logo = 1 << 10,

        A = 1 << 12,
        B = 1 << 13,
        X = 1 << 14,
        Y = 1 << 15,

    }
    public class MouseHook
    {
        public static int MouseHookWheel, MouseHookButtonX, MouseDesktopHookX, MouseDesktopHookY, mousehookx, mousehooky, MouseHookTime;
        public static bool MouseHookLeftButton, MouseHookRightButton, MouseHookLeftDoubleClick, MouseHookRightDoubleClick, MouseHookMiddleButton, MouseHookXButton;
        public static int mousehookwheelcount, mousehookbuttoncount;
        public static bool mousehookwheelbool, mousehookbuttonbool;
        public static bool MouseHookButtonX1, MouseHookButtonX2, MouseHookWheelUp, MouseHookWheelDown;
        public delegate IntPtr MouseHookHandler(int nCode, IntPtr wParam, IntPtr lParam);
        public MouseHookHandler hookHandler;
        public MSLLHOOKSTRUCT mouseStruct;
        public delegate void MouseHookCallback(MSLLHOOKSTRUCT mouseStruct);
        public event MouseHookCallback Hook;
        public IntPtr hookID = IntPtr.Zero;
        public static int width = System.Windows.Forms.Screen.PrimaryScreen.Bounds.Width;
        public static int height = System.Windows.Forms.Screen.PrimaryScreen.Bounds.Height;
        public static System.Collections.Generic.List<double> time = new System.Collections.Generic.List<double>();
        public void Install()
        {
            hookHandler = HookFunc;
            hookID = SetHook(hookHandler);
        }
        public void Uninstall()
        {
            if (hookID == IntPtr.Zero)
                return;
            UnhookWindowsHookEx(hookID);
            hookID = IntPtr.Zero;
        }
        ~MouseHook()
        {
            Uninstall();
        }
        public IntPtr SetHook(MouseHookHandler proc)
        {
            using (ProcessModule module = Process.GetCurrentProcess().MainModule)
                return SetWindowsHookEx(WH_MOUSE_LL, proc, GetModuleHandle(module.ModuleName), 0);
        }
        public IntPtr HookFunc(int nCode, IntPtr wParam, IntPtr lParam)
        {
            mouseStruct = (MSLLHOOKSTRUCT)Marshal.PtrToStructure(lParam, typeof(MSLLHOOKSTRUCT));
            if (MouseHook.MouseMessages.WM_RBUTTONDOWN == (MouseHook.MouseMessages)wParam)
                MouseHookRightButton = true;
            if (MouseHook.MouseMessages.WM_RBUTTONUP == (MouseHook.MouseMessages)wParam)
                MouseHookRightButton = false;
            if (MouseHook.MouseMessages.WM_LBUTTONDOWN == (MouseHook.MouseMessages)wParam)
                MouseHookLeftButton = true;
            if (MouseHook.MouseMessages.WM_LBUTTONUP == (MouseHook.MouseMessages)wParam)
                MouseHookLeftButton = false;
            if (MouseHook.MouseMessages.WM_MBUTTONDOWN == (MouseHook.MouseMessages)wParam)
                MouseHookMiddleButton = true;
            if (MouseHook.MouseMessages.WM_MBUTTONUP == (MouseHook.MouseMessages)wParam)
                MouseHookMiddleButton = false;
            if (MouseHook.MouseMessages.WM_XBUTTONDOWN == (MouseHook.MouseMessages)wParam)
                MouseHookXButton = true;
            if (MouseHook.MouseMessages.WM_XBUTTONUP == (MouseHook.MouseMessages)wParam)
                MouseHookXButton = false;
            if (MouseHook.MouseMessages.WM_LBUTTONDBLCLK == (MouseHook.MouseMessages)wParam)
                MouseHookLeftDoubleClick = true;
            else
                MouseHookLeftDoubleClick = false;
            if (MouseHook.MouseMessages.WM_RBUTTONDBLCLK == (MouseHook.MouseMessages)wParam)
                MouseHookRightDoubleClick = true;
            else
                MouseHookRightDoubleClick = false;
            if (MouseHook.MouseMessages.WM_MOUSEWHEEL == (MouseHook.MouseMessages)wParam)
                MouseHookWheel = (int)mouseStruct.mouseData; // 7864320, -7864320
            else
                MouseHookWheel = 0;
            if (MouseHook.MouseMessages.WM_XBUTTONDOWN == (MouseHook.MouseMessages)wParam)
                MouseHookButtonX = (int)mouseStruct.mouseData; //131072, 65536
            else
                MouseHookButtonX = 0;
            if (Form1.Getstate)
            { 
                GetCursorPos(out MouseDesktopHookX, out MouseDesktopHookY);
                mousehookx = (mouseStruct.pt.x - MouseDesktopHookX) * 15;
                mousehooky = (mouseStruct.pt.y - MouseDesktopHookY) * 30;
            }
            else
            {
                mousehookx = mouseStruct.pt.x;
                mousehooky = mouseStruct.pt.y;
            }
            Form1.mousehookx = mousehookx;
            Form1.mousehooky = mousehooky;
            MouseHookTime = (int)mouseStruct.time;
            Form1.MouseHookTime = MouseHookTime;
            Form1.MouseHookRightButton = MouseHookRightButton;
            Form1.MouseHookLeftButton = MouseHookLeftButton;
            Form1.MouseHookMiddleButton = MouseHookMiddleButton;
            Form1.MouseHookXButton = MouseHookXButton;
            Form1.MouseHookLeftDoubleClick = MouseHookLeftDoubleClick;
            Form1.MouseHookRightDoubleClick = MouseHookRightDoubleClick;
            Form1.MouseHookWheel = MouseHookWheel;
            Form1.MouseHookButtonX = MouseHookButtonX;
            Hook((MSLLHOOKSTRUCT)Marshal.PtrToStructure(lParam, typeof(MSLLHOOKSTRUCT)));
            return CallNextHookEx(hookID, nCode, wParam, lParam);
        }
        public const int WH_MOUSE_LL = 14;
        public enum MouseMessages
        {
            WM_LBUTTONDOWN = 0x0201,
            WM_LBUTTONUP = 0x0202,
            WM_MOUSEMOVE = 0x0200,
            WM_MOUSEWHEEL = 0x020A,
            WM_RBUTTONDOWN = 0x0204,
            WM_RBUTTONUP = 0x0205,
            WM_LBUTTONDBLCLK = 0x0203,
            WM_RBUTTONDBLCLK = 0x0206,
            WM_MBUTTONDOWN = 0x0207,
            WM_MBUTTONUP = 0x0208,
            WM_XBUTTONDOWN = 0x020B,
            WM_XBUTTONUP = 0x020C
        }
        [StructLayout(LayoutKind.Sequential)]
        public struct POINT
        {
            public int x;
            public int y;
        }
        [StructLayout(LayoutKind.Sequential)]
        public struct MSLLHOOKSTRUCT
        {
            public POINT pt;
            public uint mouseData;
            public uint flags;
            public uint time;
            public IntPtr dwExtraInfo;
        }
        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern IntPtr SetWindowsHookEx(int idHook, MouseHookHandler lpfn, IntPtr hMod, uint dwThreadId);
        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool UnhookWindowsHookEx(IntPtr hhk);
        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern IntPtr CallNextHookEx(IntPtr hhk, int nCode, IntPtr wParam, IntPtr lParam);
        [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern IntPtr GetModuleHandle(string lpModuleName);
        [DllImport("User32.dll")]
        public static extern bool GetCursorPos(out int x, out int y);
        [DllImport("user32.dll")]
        public static extern void SetCursorPos(int X, int Y);
    }
    public class KeyboardHook
    {
        public static bool KeyboardHookButtonDown, KeyboardHookButtonUp;
        public delegate IntPtr KeyboardHookHandler(int nCode, IntPtr wParam, IntPtr lParam);
        public KeyboardHookHandler hookHandler;
        public KBDLLHOOKSTRUCT keyboardStruct;
        public delegate void KeyboardHookCallback(KBDLLHOOKSTRUCT keyboardStruct);
        public event KeyboardHookCallback Hook;
        public IntPtr hookID = IntPtr.Zero;
        public static int scanCode, vkCode;
        public void Install()
        {
            hookHandler = HookFunc;
            hookID = SetHook(hookHandler);
        }
        public void Uninstall()
        {
            if (hookID == IntPtr.Zero)
                return;
            UnhookWindowsHookEx(hookID);
            hookID = IntPtr.Zero;
        }
        ~KeyboardHook()
        {
            Uninstall();
        }
        public IntPtr SetHook(KeyboardHookHandler proc)
        {
            using (ProcessModule module = Process.GetCurrentProcess().MainModule)
                return SetWindowsHookEx(WH_KEYBOARD_LL, proc, GetModuleHandle(module.ModuleName), 0);
        }
        public IntPtr HookFunc(int nCode, IntPtr wParam, IntPtr lParam)
        {
            keyboardStruct = (KBDLLHOOKSTRUCT)Marshal.PtrToStructure(lParam, typeof(KBDLLHOOKSTRUCT));
            if (KeyboardHook.KeyboardMessages.WM_KEYDOWN == (KeyboardHook.KeyboardMessages)wParam)
                KeyboardHookButtonDown = true;
            else
                KeyboardHookButtonDown = false;
            if (KeyboardHook.KeyboardMessages.WM_KEYUP == (KeyboardHook.KeyboardMessages)wParam)
                KeyboardHookButtonUp = true;
            else
                KeyboardHookButtonUp = false;
            Form1.KeyboardHookButtonDown = KeyboardHookButtonDown;
            Form1.KeyboardHookButtonUp = KeyboardHookButtonUp;
            Form1.vkCode = (int)keyboardStruct.vkCode;
            Form1.scanCode = (int)keyboardStruct.scanCode;
            Hook((KBDLLHOOKSTRUCT)Marshal.PtrToStructure(lParam, typeof(KBDLLHOOKSTRUCT)));
            return CallNextHookEx(hookID, nCode, wParam, lParam);
        }

        public const int WH_KEYBOARD_LL = 13;
        public enum KeyboardMessages
        {
            WM_ACTIVATE = 0x0006,
            WM_APPCOMMAND = 0x0319,
            WM_CHAR = 0x0102,
            WM_DEADCHAR = 0x010,
            WM_HOTKEY = 0x0312,
            WM_KEYDOWN = 0x0100,
            WM_KEYUP = 0x0101,
            WM_KILLFOCUS = 0x0008,
            WM_SETFOCUS = 0x0007,
            WM_SYSDEADCHAR = 0x0107,
            WM_SYSKEYDOWN = 0x0104,
            WM_SYSKEYUP = 0x0105,
            WM_UNICHAR = 0x0109
        }
        [StructLayout(LayoutKind.Sequential)]
        public struct KBDLLHOOKSTRUCT
        {
            public uint vkCode;
            public uint scanCode;
            public uint flags;
            public uint time;
            public IntPtr dwExtraInfo;
        }
        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern IntPtr SetWindowsHookEx(int idHook, KeyboardHookHandler lpfn, IntPtr hMod, uint dwThreadId);
        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool UnhookWindowsHookEx(IntPtr hhk);
        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern IntPtr CallNextHookEx(IntPtr hhk, int nCode, IntPtr wParam, IntPtr lParam);
        [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern IntPtr GetModuleHandle(string lpModuleName);
    }
}