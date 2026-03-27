// Math Game Project

using System.Diagnostics;

string? userInput;

int questionsAsked = 0;
int maxQuestionAsked = 5;
int correctAnswers = 0;

Stopwatch stopwatch = new();

List<string> gamesPlayed = [];

bool isChronometer = false;
bool isRandom = false;
int difficulty = 10;
int userResult = 0;
int numberOne = 0;
int numberTwo = 0;
int result = 0;


do
{
    Console.Clear();

    Console.WriteLine("Welcome to Math Game!\n");

    Console.WriteLine("- 1 - Addition operation.");
    Console.WriteLine("- 2 - Subtraction operation.");
    Console.WriteLine("- 3 - Division operation.");
    Console.WriteLine("- 4 - Multiplication operation.");
    Console.WriteLine("- 5 - Random Game.");
    Console.WriteLine("- 6 - Change the difficulty.");
    Console.WriteLine("- 7 - Review results.");

    DisplayDifficulty();

    Console.WriteLine("Please type a number to choose an option from the menu: (exit)");

    userInput = Console.ReadLine().Trim();

    switch (userInput)
    {
        case "1":
            SumOperation();
            break;

        case "2":
            SubOperation();
            break;

        case "3":
            DivOperation();
            break;

        case "4":
            MultOperation();
            break;

        case "5":
            PlayRandomGame();
            break;

        case "6":
            ModifyDifficulty();
            break;

        case "7":

            Console.WriteLine("\nReview your games!\n");

            if (gamesPlayed.Count == 0)
            {
                Console.WriteLine("You haven't finished any games yet!");
                Console.WriteLine("\nPress the Enter key to continue.");
                Console.ReadLine();
                break;
            }

            foreach (var game in gamesPlayed)
            {
                Console.WriteLine($"{game}");
            }

            Console.WriteLine("\nPress the Enter key to continue.");
            Console.ReadLine();
            break;

        default:
            break;
    }
}
while (userInput != "exit");


int GetRandomNumber(int number)
{
    Random randomNumber = new();
    return randomNumber.Next(1, number);
}


bool IsGameOver()
{
    if (questionsAsked != maxQuestionAsked)
    {
        return false;
    }

    TimeSpan timeSpan = stopwatch.Elapsed;

    string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}", timeSpan.Hours, timeSpan.TotalMinutes, timeSpan.Seconds, timeSpan.Milliseconds / 10);

    gamesPlayed.Add($"You got {correctAnswers}/{maxQuestionAsked} correct answers! - Time: {elapsedTime}");

    Console.WriteLine("\nGame over!\n");
    Console.WriteLine($"Here are your results: {correctAnswers}/{maxQuestionAsked}");
    Console.WriteLine($"You complete the game under: {elapsedTime}");
    Console.WriteLine("\nPress the Enter key to play a new game.");

    correctAnswers = 0;
    questionsAsked = 0;

    stopwatch.Reset();
    isChronometer = false;

    Console.ReadLine();

    return true;
}


void CheckQuestion(int userAnswer, int operationResult)
{
    if (userAnswer == operationResult)
    {
        Console.WriteLine("\nCorrect!");
        questionsAsked++;
        correctAnswers++;
    }
    else
    {
        Console.WriteLine("\nWrong answer!");
        questionsAsked++;
    }

    Console.WriteLine("\nPress the Enter key to continue.");
    Console.ReadLine();
}


int DisplayOperation(char charOperation, int valueOne, int valueTwo)
{
    int parsedInput = 0;

    do
    {
        Console.Clear();
        Console.WriteLine("\nWhat is the result of the following operation?");
        Console.WriteLine($"\n{valueOne} {charOperation} {valueTwo} = ? \n");
        userInput = Console.ReadLine().Trim();
    }
    while (int.TryParse(userInput, out parsedInput) == false);

    return parsedInput;
}


void SumOperation()
{
    if (isRandom)
    {
        numberOne = GetRandomNumber(difficulty);
        numberTwo = GetRandomNumber(difficulty);

        result = numberOne + numberTwo;

        userResult = DisplayOperation('+', numberOne, numberTwo);

        CheckQuestion(userResult, result);

        return;
    }

    CheckChronometerStatus();

    for (int i = 0; i < maxQuestionAsked; i++)
    {
        numberOne = GetRandomNumber(difficulty);
        numberTwo = GetRandomNumber(difficulty);

        result = numberOne + numberTwo;

        userResult = DisplayOperation('+', numberOne, numberTwo);

        CheckQuestion(userResult, result);
    }

    Console.Clear();
    IsGameOver();
}


void SubOperation()
{
    if (isRandom)
    {
        numberOne = GetRandomNumber(difficulty);
        numberTwo = GetRandomNumber(difficulty);

        result = Math.Abs(numberOne - numberTwo);

        userResult = DisplayOperation('-', numberOne, numberTwo);

        CheckQuestion(userResult, result);

        return;
    }

    CheckChronometerStatus();

    for (int i = 0; i < maxQuestionAsked; i++)
    {
        numberOne = GetRandomNumber(difficulty);
        numberTwo = GetRandomNumber(difficulty);

        result = Math.Abs(numberOne - numberTwo);

        userResult = DisplayOperation('-', numberOne, numberTwo);

        CheckQuestion(userResult, result);
    }

    Console.Clear();
    IsGameOver();
}


void DivOperation()
{
    if (isRandom)
    {
        numberOne = GetRandomNumber(difficulty);
        numberTwo = GetRandomNumber(difficulty);

        result = numberOne % numberTwo;

        if (result == 0)
        {
            result = numberOne / numberTwo;
        }
        else
        {
            while (result != 0)
            {
                numberOne = GetRandomNumber(difficulty);
                numberTwo = GetRandomNumber(difficulty);

                result = numberOne % numberTwo;
            }

            result = numberOne / numberTwo;
        }

        userResult = DisplayOperation('/', numberOne, numberTwo);

        CheckQuestion(userResult, result);

        return;
    }

    CheckChronometerStatus();

    for (int i = 0; i < maxQuestionAsked; i++)
    {
        numberOne = GetRandomNumber(difficulty);
        numberTwo = GetRandomNumber(difficulty);

        result = numberOne % numberTwo;

        if (result == 0)
        {
            result = numberOne / numberTwo;
        }
        else
        {
            while (result != 0)
            {
                numberOne = GetRandomNumber(difficulty);
                numberTwo = GetRandomNumber(difficulty);

                result = numberOne % numberTwo;
            }

            result = numberOne / numberTwo;
        }

        userResult = DisplayOperation('/', numberOne, numberTwo);

        CheckQuestion(userResult, result);
    }

    Console.Clear();
    IsGameOver();
}


void MultOperation()
{
    if (isRandom)
    {
        numberOne = GetRandomNumber(difficulty);
        numberTwo = GetRandomNumber(difficulty);

        result = numberOne * numberTwo;

        userResult = DisplayOperation('x', numberOne, numberTwo);

        CheckQuestion(userResult, result);

        return;
    }

    CheckChronometerStatus();

    for (int i = 0; i < maxQuestionAsked; i++)
    {
        numberOne = GetRandomNumber(difficulty);
        numberTwo = GetRandomNumber(difficulty);

        result = numberOne * numberTwo;

        userResult = DisplayOperation('x', numberOne, numberTwo);

        CheckQuestion(userResult, result);
    }

    Console.Clear();
    IsGameOver();
}


void PlayRandomGame()
{
    do
    {
        Console.WriteLine("\nDo you want to play a random game? Y/N");
        userInput = Console.ReadLine().ToLower().Trim();
    }
    while (userInput != "y" && userInput != "n");

    if (userInput.Equals("y"))
    {
        isRandom = true;

        CheckChronometerStatus();

        for (int i = 0; i < maxQuestionAsked; i++)
        {
            int index = GetRandomNumber(4);

            switch (index)
            {
                case 0:
                    SumOperation();
                    break;

                case 1:
                    SubOperation();
                    break;

                case 2:
                    DivOperation();
                    break;

                case 3:
                    MultOperation();
                    break;

                default:
                    break;
            }
        }

        Console.Clear();

        isRandom = false;

        IsGameOver();
    }
    else
    {
        Console.WriteLine("\nYou cancel the game.");
        Console.WriteLine("\nPress the Enter key to continue.");
        Console.ReadLine();
    }
}


void ModifyDifficulty()
{
    Console.Clear();

    Console.WriteLine("\nProgression level\n");

    Console.WriteLine("- 1 - Easy Level");
    Console.WriteLine("- 2 - Medium Level");
    Console.WriteLine("- 3 - Hard Level");

    DisplayDifficulty();

    Console.WriteLine("Type \"back\" to go back to main menu");

    do
    {
        Console.WriteLine("\nChoose an option from the menu\n");
        userInput = Console.ReadLine().Trim();

        switch (userInput)
        {

            case "1":
                Console.WriteLine("\nEasy level setted!");
                difficulty = 10;
                Console.WriteLine("\nPress the Enter key to continue.");
                Console.ReadLine();
                return;

            case "2":
                Console.WriteLine("\nMedium level setted!");
                difficulty = 100;
                Console.WriteLine("\nPress the Enter key to continue.");
                Console.ReadLine();
                return;

            case "3":
                Console.WriteLine("\nHard level setted!");
                difficulty = 1000;
                Console.WriteLine("\nPress the Enter key to continue.");
                Console.ReadLine();
                return;
        }
    }
    while (userInput != "back");
}


void DisplayDifficulty()
{
    switch (difficulty)
    {
        case 10:
            Console.WriteLine($"\nCurrent level of difficulty is Easy.\n");
            break;

        case 100:
            Console.WriteLine($"\nCurrent level of difficulty is Medium.\n");
            break;

        case 1000:
            Console.WriteLine($"\nCurrent level of difficulty is Hard.\n");
            break;
    }
}


void CheckChronometerStatus()
{
    if (!isChronometer)
    {
        stopwatch.Start();
        isChronometer = true;
    }
}