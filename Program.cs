int players = 2;
int matches = 24;
int minMatchDraw = 1;
int maxMatchDraw = 3;
int matchLoseCondition = 0;
char match = '|';
int turnCounter = -1;

Console.WriteLine("Welcome to Nim!");
while (IsMatchesLeft())
{
    SwitchPlayers();
    PrintMatches();
    CurrentPlayerDraw();
}

Console.WriteLine("Game Over.");

void SwitchPlayers()
{
    turnCounter++;
}

void CurrentPlayerDraw()
{
    
    int currentPlayer = turnCounter % players;
    if (currentPlayer == 0)
    {
        UserDraw();
    }
    else
    {
        AIDraw();
    }
}

void PrintMatches()
{
    for (int i = 0; i < matches; i++)
    {
        Console.Write(match);
    }

    Console.WriteLine($" ({matches})");
}

void UserDraw()
{
    int input;
    do
    {
        Console.WriteLine("How many matches do you want to draw?");
        input = Convert.ToInt32(Console.ReadLine());
    } while (IsValidInput(input) == false);

    matches -= input;
}

void AIDraw()
{
    // validation happens here by ensuring that the AI never draws too few or too many
    int maxDraw = Math.Min(maxMatchDraw, matches);
    int input = Random.Shared.Next(minMatchDraw, maxDraw + 1);
    Console.WriteLine($"The AI #{turnCounter % players} draws {input} matches.");
    matches -= input;
}

bool IsMatchesLeft()
{
    return matches > matchLoseCondition;
}

bool IsValidInput(int input)
{
    return input >= minMatchDraw && input <= maxMatchDraw && input <= matches;
}