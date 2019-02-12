using System.Collections.Generic;
using UnityEngine;
using Game;

namespace Tests
{
    public class BotController:BaseController
    {
        public List<Bot> GetBotList { get; } = new List<Bot>();
        public int CountBot;

        public void Init()
        {
            for(var index=0;index<CountBot;index++)
            {
                var tempBot = Bot.Instantiate(Main.Instance.RefBotPrefab,
                    Patrol.GenericPoint(Main.Instance.PlayerTransform),
                    Quaternion.identity);

                tempBot.Agent.avoidancePriority = index;
                tempBot.Target = Main.Instance.PlayerTransform;//разных противников
                AddBotToList(tempBot);
            }
        }
        public void AddBotToList(Bot bot)
        {
            if(!GetBotList.Contains(bot))
            {
                GetBotList.Add(bot);
            }
        }
        public void RemoveBotToList(Bot bot)
        {
            if(GetBotList.Contains(bot))
            {
                GetBotList.Remove(bot);
            }
        }
        public override void OnUpdate()
        {
            if (!IsActive) return;
            foreach(var bot in GetBotList)
            {
                bot.Tick();
            }
        }
    }
}
