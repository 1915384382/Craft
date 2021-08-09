public class GameConst
{
    //玩家子弹速度
    public float PlayerBulltSpeed = 150;
    //敌人子弹速度
    public float EnemyBulltSpeed = 50;
    //子弹击中特效
    public string BulletHitEffect = "eff_huoqiu_explosion";
    //战机爆炸特效
    public string AirCraftBombEffect = "eff_juji_explosion";
    private static GameConst ins;
    public static GameConst Instance
    {
        get
        {
            if (ins == null)
            {
                ins = new GameConst();
            }
            return ins;
        } }
    public string[] rewards = new string[] { "RewardLifeUp", "RewardLvUp"};
    public string LogoBGM = "Logo";
    public string GameBGM = "MainGame";
}