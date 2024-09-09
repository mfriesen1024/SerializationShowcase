using Assets.Scripts.Player;
using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

namespace Assets.Scripts.Managers
{
    internal class DataManager
    {
        public PlayerController PlayerController;

        string dataPath;
        string playerFile = "player.dat";

        public void Init()
        {
            dataPath = Application.persistentDataPath + "\\saveData\\";
            PlayerController = GameManager.Instance.playerController;
        }

        /// <summary>
        /// Should load and unpack all data from files.
        /// </summary>
        public void Load()
        {
            BinaryFormatter binaryFormatter = new();

            LoadPlayer();

            // Separate playerloading for my own sanity.
            void LoadPlayer()
            {
                if (PlayerController == null)
                {
                    // if pc is null, make it known that this is problem.
                    throw new InvalidOperationException("Cannot unpack playerdata to a nonexistent player.");
                }

                // Check if stuff exists, leave a bool as a flag for logging.
                bool exists = false;
                if (Directory.Exists(dataPath))
                {
                    if (File.Exists(dataPath + playerFile))
                    {
                        // if both dir and file exist, dont log the error.
                        exists = true;

                        // deserialize.
                        FileStream fs = File.OpenRead(dataPath + playerFile);
                        PlayerController.statMan = (PlayerSave)binaryFormatter.Deserialize(fs);
                        fs.Close();
                    }
                }
                else { Directory.CreateDirectory(dataPath); }

                // It automatically creates a new save before this fails, just note that in logs.                    
                if (!exists) { Debug.LogWarning("File didn't exist, assuming PC will auto create a new statman."); }
            }
        }

        public void Save()
        {
            SavePlayer();

            void SavePlayer()
            {
                BinaryFormatter binaryFormatter = new();

                if (PlayerController == null)
                {
                    // if pc is null, make it known that this is problem.
                    throw new InvalidOperationException("Cannot unpack playerdata to a nonexistent player.");
                }

                // This time, we're saving it as long as things aren't null, so dont quit if directory is nonexistent.
                if (!Directory.Exists(dataPath)) { Directory.CreateDirectory(dataPath); }

                FileStream fs = File.Create(dataPath + playerFile);
                binaryFormatter.Serialize(fs, (PlayerSave)PlayerController.statMan);
                fs.Close();
            }
        }
    }
}
