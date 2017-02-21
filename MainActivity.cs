using Android.App;
using Android.Widget;
using Android.OS;

using WowDotNetAPI;
using WowDotNetAPI.Models;

namespace guildCraft
{
	[Activity(Label = "guildCraft", MainLauncher = true, Icon = "@mipmap/icon")]
	public class MainActivity : Activity
	{
		//int count = 1;


		protected override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);

			// Set our view from the "main" layout resource
			SetContentView(Resource.Layout.Main);

			// connect to the Mashery API
			WowExplorer explorer = new WowExplorer(Region.US, Locale.en_US, "r8qtcbzwx8sc3dvrxwsgbh4rczmkf8jm");

			// explicitly look up a guild
			//Guild userGuild = explorer.GetGuild("thrall", "blackfyre", GuildOptions.GetEverything);

			Character userCharacter = explorer.GetCharacter("thrall", "zantlock", CharacterOptions.GetPvP);

			TextView charName = FindViewById<TextView>(Resource.Id.charName1);
			TextView charKills = FindViewById<TextView>(Resource.Id.totalKills1);

			//userCharacter.PvP.TotalHonorableKills

			// Get our button from the layout resource,
			// and attach an event to it
			Button btnGetKills = FindViewById<Button>(Resource.Id.getPvpKills);
			btnGetKills.Click += delegate
			{
				charName.Text = userCharacter.Name;
				charKills.Text = userCharacter.PvP.TotalHonorableKills.ToString();
			};

			//button.Click += delegate { button.Text = string.Format("{0} clicks!", count++); };
		}
	}
}

