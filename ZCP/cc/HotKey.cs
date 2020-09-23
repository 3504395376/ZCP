using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Windows.Forms;
using System.Runtime.InteropServices;

public class HotKey : IMessageFilter
{
    public delegate void HotkeyEventHandler(int HotKeyID);
    public event HotkeyEventHandler OnHotkey;
    private Hashtable keyIDs = new Hashtable();
    private IntPtr hWnd;

    /// <summary>
    /// 辅助按键
    /// </summary>
    public enum KeyFlags
    {
        MOD_NULL = 0x0,
        MOD_ALT = 0x1,
        MOD_CONTROL = 0x2,
        MOD_SHIFT = 0x4,
        MOD_WIN = 0x8
    }

    /// <summary>
    /// 注册热键API
    /// </summary>
    [DllImport("user32.dll")]
    public static extern UInt32 RegisterHotKey(IntPtr hWnd, UInt32 id, UInt32 fsModifiers, UInt32 vk);

    /// <summary>
    /// 注销热键API
    /// </summary>
    [DllImport("user32.dll")]
    public static extern UInt32 UnregisterHotKey(IntPtr hWnd, UInt32 id);

    /// <summary>
    /// 全局原子表添加原子
    /// </summary>
    [DllImport("kernel32.dll")]
    public static extern UInt32 GlobalAddAtom(String lpString);

    /// <summary>
    /// 全局原子表删除原子
    /// </summary>
    [DllImport("kernel32.dll")]
    public static extern UInt32 GlobalDeleteAtom(UInt32 nAtom);
    /// <summary>
    /// 窗口最前
    /// </summary>
    /// <param name="hWnd"></param>
    /// <param name="hWndInsertAfter"></param>
    /// <param name="x"></param>
    /// <param name="y"></param>
    /// <param name="Width"></param>
    /// <param name="Height"></param>
    /// <param name="flags"></param>
    /// <returns></returns>
    [DllImport("user32.dll", CharSet = CharSet.Auto)]
    public static extern int SetWindowPos(IntPtr hWnd, int hWndInsertAfter, int x, int y, int Width, int Height, int flags);
    /// <summary>
    /// 按键精灵
    /// </summary>
    /// <param name="flags"></param>
    /// <param name="dx"></param>
    /// <param name="dy"></param>
    /// <param name="data"></param>
    /// <param name="extraLnfo"></param>
    [DllImport("user32.dll")]
    private static extern int mouse_event(int dwFlags, int dx, int dy, int cButtons, int dwExtraInfo);
    //移动鼠标 
    private const int MOUSEEVENTF_MOVE = 0x0001;
    //模拟鼠标左键按下 
    private const int MOUSEEVENTF_LEFTDOWN = 0x0002;
    //模拟鼠标左键抬起 
    private const int MOUSEEVENTF_LEFTUP = 0x0004;
    //模拟鼠标右键按下 
    private const int MOUSEEVENTF_RIGHTDOWN = 0x0008;
    //模拟鼠标右键抬起 
    private const int MOUSEEVENTF_RIGHTUP = 0x0010;
    //模拟鼠标中键按下 
    private const int MOUSEEVENTF_MIDDLEDOWN = 0x0020;
    //模拟鼠标中键抬起 
    private const int MOUSEEVENTF_MIDDLEUP = 0x0040;
    //标示是否采用绝对坐标 
    private const int MOUSEEVENTF_ABSOLUTE = 0x8000;
    /// <summary>
    /// 构造函数
    /// </summary>
    /// <param name="hWnd">当前句柄</param>
    public HotKey(IntPtr hWnd)
    {
        this.hWnd = hWnd;
        Application.AddMessageFilter(this);
    }

    /// <summary>
    /// 注册热键
    /// </summary>
    public int RegisterHotkey(Keys Key, KeyFlags keyflags)
    {
        UInt32 hotkeyid = GlobalAddAtom(System.Guid.NewGuid().ToString());
        RegisterHotKey((IntPtr)hWnd, hotkeyid, (UInt32)keyflags, (UInt32)Key);
        keyIDs.Add(hotkeyid, hotkeyid);
        return (int)hotkeyid;
    }

    /// <summary>
    /// 注销所有热键
    /// </summary>
    public void UnregisterHotkeys()
    {
        Application.RemoveMessageFilter(this);
        foreach (UInt32 key in keyIDs.Values)
        {
            UnregisterHotKey(hWnd, key);
            GlobalDeleteAtom(key);
        }
    }

    /// <summary>
    /// 消息筛选
    /// </summary>
    public bool PreFilterMessage(ref Message m)
    {
        if (m.Msg == 0x312)
        {
            if (OnHotkey != null)
            {
                foreach (UInt32 key in keyIDs.Values)
                {
                    if ((UInt32)m.WParam == key)
                    {
                        OnHotkey((int)m.WParam);
                        return true;
                    }
                }
            }
        }
        return false;
    }
    /// <summary>
    /// 延迟 鼠标移动到 from 延迟 左键按下 延迟 移动到 to 延迟 左键抬起
    /// </summary>
    /// <param name="delay"></param>
    /// <param name="moveFromX"></param>
    /// <param name="moveFromY"></param>
    /// <param name="moveToX"></param>
    /// <param name="moveToY"></param>
    public void DropObj(int delay, int moveFromX, int moveFromY, int moveToX, int moveToY)
    {
        int SH = Screen.PrimaryScreen.Bounds.Height;
        int SW = Screen.PrimaryScreen.Bounds.Width;

        System.Threading.Thread.Sleep(delay);
        HotKey.mouse_event(HotKey.MOUSEEVENTF_MOVE | HotKey.MOUSEEVENTF_ABSOLUTE, moveFromX * 65536 / SW, moveFromY * 65536 / SH, 0, 0);
        System.Threading.Thread.Sleep(delay);
        HotKey.mouse_event(HotKey.MOUSEEVENTF_LEFTDOWN, 0, 0, 0, 0);
        System.Threading.Thread.Sleep(delay);
        HotKey.mouse_event(HotKey.MOUSEEVENTF_MOVE | HotKey.MOUSEEVENTF_ABSOLUTE, moveToX * 65536 / SW, moveToY * 65536 / SH, 0, 0);
        System.Threading.Thread.Sleep(delay);
        HotKey.mouse_event(HotKey.MOUSEEVENTF_LEFTUP, 0, 0, 0, 0);
    }
}