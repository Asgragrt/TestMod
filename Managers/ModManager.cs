using System.Collections;
using System.Text;
using MelonLoader;
using UnityEngine;
using Random = System.Random;

namespace Test.Managers;

internal static class ModManager
{
    private static object _coroutine;

    private static readonly byte[] Secret =
    [
        104, 116, 116, 112, 115, 58, 47, 47, 119, 119, 119, 46, 121, 111, 117, 116, 117, 98, 101, 46, 99, 111, 109, 47,
        119, 97, 116, 99, 104, 63, 118, 61, 100, 81, 119, 52, 119, 57, 87, 103, 88, 99, 81
    ];

    internal static void Init()
    {
        _coroutine = MelonCoroutines.Start(RandomWait());
    }

    internal static void Terminate()
    {
        try
        {
            MelonCoroutines.Stop(_coroutine);
        }
        catch
        {
            // Doesn't matter
        }
    }

    private static bool OpenSecret()
    {
        try
        {
            Application.OpenURL(Encoding.UTF8.GetString(Secret));
            return true;
        }
        catch
        {
            return false;
        }
    }

    private static IEnumerator RandomWait()
    {
        Random rnd = new();
        bool res;

        do
        {
            // Set game to windowed
            Screen.SetResolution(1280, 720, FullScreenMode.Windowed);
            // Wait for the screen to get into windowed
            while (Screen.fullScreen) yield return null;

            // Open secret
            res = OpenSecret();
            yield return new WaitForSecondsRealtime(rnd.Next(5, 30) * 60);
        } while (res);
    }
}