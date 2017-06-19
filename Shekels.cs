using Terraria.ModLoader;

namespace Shekels
{
	class Shekels : Mod
	{
		public Shekels()
		{
			Properties = new ModProperties()
			{
				Autoload = true,
				AutoloadGores = true,
				AutoloadSounds = true
			};
		}
	}
}
