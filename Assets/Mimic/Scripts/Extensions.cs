using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public static class Extensions
{
    public static void Serialize<T>(this T obj, string path)
    {
        using (var fs = new FileStream(path, FileMode.Create))
        {
            try
            {
                var formatter = new BinaryFormatter();
                formatter.Serialize(fs, obj);
            }
            finally
            {
                fs.Close();
            }
        }
    }

    public static T Deserialize<T>(string path)
    {
        using (var fs = new FileStream(path, FileMode.Open))
        {
            try
            {
                var formatter = new BinaryFormatter();
                return (T)formatter.Deserialize(fs);
            }
            finally
            {
                fs.Close();
            }
        }
    }
}

public enum ControllerButton
{
    None,
    Scripted,
    Grip,
    Trigger,
    Pad
}

[System.Serializable]
public class MiButtonMenu
{
    public string menuName;
    public MiButton[] buttons;
}

[System.Serializable]
public class MiButton
{
    public string buttonName;
    public Material material;
    public Material hover;
    public Vector3 position;
    public GameObject clickTarget;
    public string clickEvent;

    public virtual void Click(string param)
    {
        Debug.Log("Clicked button: " + buttonName + ". Param: " + param);
        if (clickTarget == null) return;

        clickTarget.SendMessage(clickEvent, buttonName, SendMessageOptions.DontRequireReceiver);
    }
}