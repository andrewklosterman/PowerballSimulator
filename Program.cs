namespace Lottery
{
	static class Program
	{
		static void Main()
		{
			Console.ForegroundColor = ConsoleColor.White;
			Console.WriteLine("Welcome to the Lottery Simulator!");
			Console.WriteLine("Please select 5 white numbers between 1-69.");
			// Pick the white balls. Numbers must be between 1-69 and you can not pick the same number twice.
			int[] whitePicks = new int[5];
			for (int i = 1; i <= 5; i++) {
				Console.Write("#" + i + ": ");
				int tempInput = Convert.ToInt16(Console.ReadLine());
				if (whitePicks.Contains(tempInput)) {
					Console.WriteLine("You already chose that number.");
					i--;
				} else if (tempInput >= 1 && tempInput <= 69) {
					whitePicks[i - 1] = tempInput;
				} else {
					Console.WriteLine("Please pick a number between 1-69.");
					i--;
				}
			}
			// Pick the red powerball. Must be between 1-26 and CAN be the same as a white pick.
			Console.WriteLine("Pick a red powerball number between 1-26.");
			Console.Write("#6: ");
			Console.ForegroundColor = ConsoleColor.Red;
			int redPick = Convert.ToInt16(Console.ReadLine());
			Console.ForegroundColor = ConsoleColor.White;
			// Display the player's picks
			Console.WriteLine();
			Console.Write("You chose ");
			foreach (int i in whitePicks) {
				Console.Write(i + " ");
			}
			Console.ForegroundColor = ConsoleColor.Red;
			Console.Write(redPick);
			Console.ForegroundColor = ConsoleColor.White;
			Console.WriteLine(". Good luck!");
			// Ask the player how many drawings they would like to simulate.
			Console.WriteLine("How many drawings would you like to simulate?");
			Console.Write("Drawings: ");
			int money = 0;
			int earnings = 0;
			int totalEarnings = 0;
			int numberOfDrawings = Convert.ToInt32(Console.ReadLine());
			// Run the simulations and check for matches. Tracks profits assuming a $2 ticket.
			Random random = new Random();
			for (int j = 0; j < numberOfDrawings; j++) {
				money -= 2;
				earnings = 0;
				int drawingNumber = j + 1;
				// Generate 5 white balls and one powerball.
				int[] whiteResults = new int[5];
				for (int k = 0; k < 5; k++) {
					int whiteTempBall = random.Next(1,70);
					if (whiteResults.Contains(whiteTempBall)) {
						k--;
					} else {
						whiteResults[k] = whiteTempBall;
					}
				}
				int redBall = random.Next(1,27);
				Console.Write("Drawing " + drawingNumber + ": ");
				foreach (int l in whiteResults) {
					Console.Write(l + " ");
				}
				Console.ForegroundColor = ConsoleColor.Red;
				Console.Write(redBall);
				Console.ForegroundColor = ConsoleColor.White;
				Console.WriteLine();
				// Check for matches and calculate profits.
				int whiteMatches = whiteResults.Count(whitePicks.Contains);
				bool redMatch = (redPick == redBall);
				switch (whiteMatches) {
					case 0:
						if (redMatch) {money += 4; earnings = 4;}
						break;
					case 1:
						if (redMatch) {money += 4; earnings = 4;}
						break;
					case 2:
						if (redMatch) {money += 7; earnings = 7;}
						break;
					case 3:
						if (redMatch) {money += 100; earnings = 100;} else {money += 7; earnings = 7;}
						break;
					case 4:
						if (redMatch) {money +=50000; earnings = 50000;} else {money += 100; earnings = 100;}
						break;
					case 5:
						if (redMatch) {money += 20000000; earnings = 20000000;} else {money += 1000000; earnings = 1000000;}
						break;
				}
				totalEarnings += earnings;
				// Tell the player what they matched, what they won, and their current stats.
				Console.Write("You matched " + whiteMatches + " white balls");
				if (redMatch) {
					Console.ForegroundColor = ConsoleColor.Red;
					Console.WriteLine(" and the powerball!");
					Console.ForegroundColor = ConsoleColor.White;
				} else {
					Console.WriteLine(".");
				}
				Console.WriteLine("You won $" + earnings + ".");
				Console.WriteLine();
			}
			// Show the player their post-simulation final stats.
			Console.WriteLine();
			Console.WriteLine("Your total earnings are $" + totalEarnings + ".");
			Console.WriteLine("Your profit is $" + money + ".");
			Console.Write("Press ENTER to exit...");
			Console.ReadLine();
		}
	}
}