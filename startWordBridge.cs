using System;

public class CPHInline
{
	public bool Execute()
	{
		//Tell Streamer.Bot that the game is active. 
		CPH.SetGlobalVar("wordBridgeActive", true, true); 
		
		CPH.SendMessage("Starting a game of Word Bridge!"); 
		
		//Pick some random numbers for the random letters of the alpabet. 
		Random random = new Random(); 
		int firstIndex = random.Next(26); 
		int endIndex = random.Next(26);
		
		//tell Streamer.Bot what the first and last letters are, after picking them
		string firstLetter = getRandomLetter(firstIndex); 
		string endLetter = getRandomLetter(endIndex); 
		CPH.SetGlobalVar("wordBridgeStart", firstLetter, true); 
		CPH.SetGlobalVar("wordBridgeEnd", endLetter, true); 
		
		//Print out to chat what the first and last letterrs are, and how to play 
		CPH.SendMessage("The first letter of the word has to be... " + firstLetter);
		CPH.SendMessage("The last letter of the word has to be... " + endLetter); 
		CPH.SendMessage("Guess words by using !gw [word]"); 
		
		
		return true;
	}
	
	
	//A small helper function to get a random letter
	public string getRandomLetter(int randIndex)
	{
		string letters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ"; ; 
		string result = letters.Substring(randIndex, 1); 
		return result; 
	}
	
	
}
