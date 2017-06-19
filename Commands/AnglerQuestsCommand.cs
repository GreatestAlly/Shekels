using Terraria;
using Terraria.ModLoader;

namespace Shekels.Commands
{
	public class AnglerQuestsCommand : ModCommand
	{
		public override CommandType Type
		{
			get { return CommandType.Chat; }
		}

		public override string Command
		{
			get { return "checkquests"; }
		}

        public override string Usage
        {
            get { return "test"; }
        }

		public override string Description 
		{
			get { return "Print the number of angler quests that have been completed"; }
		}

		public override void Action(CommandCaller caller, string input, string[] args)
		{
            caller.Reply(caller.Player.name + " has completed " + caller.Player.anglerQuestsFinished + " quests.");
		}
	}
}