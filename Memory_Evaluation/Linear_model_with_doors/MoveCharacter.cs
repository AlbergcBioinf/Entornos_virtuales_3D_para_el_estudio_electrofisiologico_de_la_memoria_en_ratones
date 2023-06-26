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

    public float sector1EndZ = -12.5f;
    public float sector2EndZ = 22.5f;
    public float sector3EndZ = 57.5f;

    void Start()
    {
        sp = new SerialPort("COM3", 9600);
        sp.Open();
        sp.ReadTimeout = 1;

        // Create the output directory if it doesn't exist
        string directoryPath = Path.Combine(Application.dataPath, "output");
        if (!Directory.Exists(directoryPath))
        {
            Directory.CreateDirectory(directoryPath);
        }

        // Generate the file name with current date and time
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

                if (characterPositionZ < sector1EndZ)
                {
                    sector = "Sector 1";
                }
                else if (sector2EndZ > characterPositionZ && characterPositionZ > sector1EndZ)

                {
                    sector = "Sector 2";
                }
                else if (sector3EndZ > characterPositionZ && characterPositionZ > sector2EndZ)

                {
                    sector = "Sector 3";
                }
                else
                {
                    sector = "Sector 4";
                }

                string positionData = string.Format("{0},{1},{2}", characterPositionZ, Time.time, sector);
                sw.WriteLine(positionData);
            }
            catch (System.Exception)
            {
            }

        }


    }


    public void EnviarComando(string comando)
    {
        // Envía el comando al motor paso a paso
        sp.Write(comando);

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
