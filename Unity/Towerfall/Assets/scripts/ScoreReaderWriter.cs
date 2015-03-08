using UnityEngine;
using System.Collections;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class ScoreReaderWriter
{
  private static string filepath = Application.persistentDataPath + "/" + "highscore.dat";
  public static int getHighscore()

  {
    if (File.Exists(filepath))
    {
      
      BinaryFormatter bf = new BinaryFormatter();
      FileStream file = File.Open(filepath, FileMode.Open);
      int score = (int)bf.Deserialize(file);   
      file.Close();
      return score;
    }
    return 0;
  }

  public static void saveHighscore(int score)
  {
    

    BinaryFormatter bf = new BinaryFormatter();
    FileStream stream = File.Create(filepath);
    bf.Serialize(stream, score);
    stream.Close();

 
  }
}
