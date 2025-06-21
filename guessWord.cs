using System;
using System.Net.Http; 
using System.Threading.Tasks; 

public class CPHInline
{
	public string user; 
	public string firstLetter;
	public string endLetter; 
	
	
	public bool Execute()
	{
		string userGuess; 
		firstLetter = CPH.GetGlobalVar<string>("wordBridgeStart", true); 
		endLetter = CPH.GetGlobalVar<string>("wordBridgeEnd", true); 
		bool wordBridgeActive = CPH.GetGlobalVar<bool>("wordBridgeActive", true); 
		
		CPH.TryGetArg("user", out user); 
		CPH.TryGetArg("rawInput", out userGuess);
		
		if(wordBridgeActive)
		{
			checkWord(userGuess.ToLower(), firstLetter.ToLower(), endLetter.ToLower()); 
		}
		else
		{
			CPH.SendMessage("Word Bridge is not currently active!"); 
		}
		
		return true;
	}
	
	
	public async Task<bool> checkWord(string word, string firstLetter, string endLetter)
	{
		//uses the free dictionary api to check if the user actually typed in a word
		string url = $"https://api.dictionaryapi.dev/api/v2/entries/en/{word}";
	    using(HttpClient client = new HttpClient())
        {
			try
			{
				HttpResponseMessage response = await client.GetAsync(url);
				if(response.IsSuccessStatusCode)
				{
					//check the first and end letter
					if(word.Substring(0,1).Equals(firstLetter) && word.Substring(word.Length-1, 1).Equals(endLetter))
					{
						CPH.SendMessage(user + ",  " + word + " is a great word! You win!");

						CPH.SetGlobalVar("wordBridgeActive", false, true); 
					}
					else
					{
						CPH.SendMessage("Sorry, that word doesn't start with " + firstLetter + " and end with " + endLetter); 
					}
				}  
				else
				{
					CPH.SendMessage("That word isn't in the dictionary!"); 
				}
				
				return response.IsSuccessStatusCode; 
			}
			catch
			{
				return false; 
			}
        }
        	
		
	}
	
	

	
}
