using System;

/// <summary>
/// �Q�[���̃f�[�^
/// </summary>
[Serializable]  // ��������邱�ƂŃV���A�������ł���悤�ɂȂ�
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
