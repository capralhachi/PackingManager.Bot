using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Threading;
using Telegram.Bot;
using Telegram.Bot.Args;
using Telegram.Bot.Extensions;
using Telegram.Bot.Polling;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.ReplyMarkups;

namespace PackingManager.Bot
{
	class Program
	{
		const string TOKEN = "6670028917:AAFQpyF6xRWacyB8khzzdF4ZVUFRP_JPd5I";
		private const string newPack = "New Pack";
		private const string listPack = "List Pack";
		Newpack Newpack = new Newpack();
		Listpack Listpack = new Listpack();


		static void Main(string[] agrs)
		{
			while (true)
			{
				try
				{
					GetMessages().Wait();
				}
				catch (Exception ex)
				{
					Console.WriteLine("Error:" + ex);
				}
				
			}
		}
		static async Task GetMessages()
		{
			TelegramBotClient _client = new TelegramBotClient(TOKEN);
			int offset = 0;
			int timeOut = 0;
			try
			{
				await _client.SetWebhookAsync("");
				while (true)
				{
					var updates = await _client.GetUpdatesAsync(offset, timeOut);
					foreach (var update in updates) 
					{
						var message = update.Message;
						if (message.Text == "/start")
						{
							var keyboard = new ReplyKeyboardMarkup(
							new KeyboardButton[][]
							{
								new KeyboardButton[]
								{
									new KeyboardButton (newPack),
									new KeyboardButton (listPack),
								}
							}
						);
							await _client.SendTextMessageAsync(
								chatId: message.Chat.Id,
								text: "Opcija:",
								replyMarkup: keyboard
							);
						}
						if (message.Text == "New Pack")
						{
							Newpack.writeInfo();
						}
						if (message.Text == "List Pack")
						{

						}
						offset = update.Id + 1;
					}
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine("Error: " + ex);
			}
		}
	}
}