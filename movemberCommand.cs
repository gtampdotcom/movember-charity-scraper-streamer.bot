// https://github.com/gtampdotcom/movember-charity-scraper-streamer.bot

using System;
using System.IO;
		
public class CPHInline
{
	public bool Execute()
	{
		string total = "0";
		string searchWord = "<h1 class=\"mospace-heroarea--donations-target-amount-number\">";
		string searchWordEnd = "</h1>";

		var page = args["page"].ToString();
		var filename = args["filename"].ToString();
		int start = page.IndexOf(searchWord)+searchWord.Length+1;
		int end = page.IndexOf(searchWordEnd,start);
		total = page.Substring(start,end-start).Trim();
		total = total.Replace("$","");
		
		CPH.SendMessage("Total: $" + total);
		File.WriteAllText(filename, total);

		return true;
	}
}
