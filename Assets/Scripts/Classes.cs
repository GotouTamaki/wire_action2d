using System;

/// <summary>
/// ゲームのデータ
/// </summary>
[Serializable]  // これをつけることでシリアル化ができるようになる
public class SaveData
{
    public string[] StageName;
    public float[] BestTime;

    public SaveData(string[] stageName, float[] bestTime, int maxHp, int hp)
    {
        this.StageName = stageName;
        this.BestTime = bestTime;
    }
}
