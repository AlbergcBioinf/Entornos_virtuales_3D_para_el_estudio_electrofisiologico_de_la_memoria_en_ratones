using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO.Ports;
using System.IO;


public class MoveCharacter : MonoBehaviour
{
    public float moveSpeed = 5f;
    private SerialPort sp;
    private int lastEncoderPos = 0;
    public bool hideMouse = true;
    private string fileName;
    private StreamWriter sw;

    public float dark1EndZ = 222.0f;
    public float light1EndZ = 248.0f;
    public float dark2EndZ = 276.0f;
    public float light2EndZ = 302.0f;
    public float dark3EndZ = 330.0f;

    void Start()
    {
        sp = new SerialPort("COM3", 9600);
        sp.Open();
        sp.ReadTimeout = 1;

        string directoryPath = Path.Combine(Application.dataPath, "output");
        if (!Directory.Exists(directoryPath))
        {
            Directory.CreateDirectory(directoryPath);
        }

        fileName = Path.Combine(directoryPath, System.DateTime.Now.ToString("yyyyMMddHHmmss") + "_position.csv");
        sw = new StreamWriter(fileName);
    }

    void Update()
    {
        if (sp.IsOpen)
        {
            try
            {
                int encoderPos = int.Parse(sp.ReadLine().Trim());
                if (encoderPos > lastEncoderPos)
                {
                    transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
                }
                else if (encoderPos < lastEncoderPos)
                {
                    transform.Translate(Vector3.back * moveSpeed * Time.deltaTime);
                }
                lastEncoderPos = encoderPos;

                string sector;
                float characterPositionZ = transform.position.z;

                if (characterPositionZ < dark1EndZ)
                {
                    sector = "Dark Sector1";
                }
                else if (light1EndZ > characterPositionZ && characterPositionZ > dark1EndZ)

                {
                    sector = "Light Sector1";
                }
                else if (dark2EndZ > characterPositionZ && characterPositionZ > light1EndZ)

                {
                    sector = "Dark Sector2";
                }
                else if (light2EndZ > characterPositionZ && characterPositionZ > dark2EndZ)

                {
                    sector = "Light Sector2";
                }
                else if (dark3EndZ > characterPositionZ && characterPositionZ > light2EndZ)

                {
                    sector = "Dark Sector3";
                }
                else
                {
                    sector = "Light Sector3";
                }

                string positionData = string.Format("{0},{1},{2}", characterPositionZ, Time.time, sector);
                sw.WriteLine(positionData);
            }
            catch (System.Exception)
            {
            }

        }
    }

    void OnApplicationQuit()
    {
        if (sp.IsOpen)
        {
            sp.Close();
        }

        if (sw != null)
        {
            sw.Close();
        }
    }
}
