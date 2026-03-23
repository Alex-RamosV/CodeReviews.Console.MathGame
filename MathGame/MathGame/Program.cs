
string? userInput;
int questionsAsked = 0;
int maxQuestionAsked = 5;
int correctAnswers = 0;
List<string> gamesPlayed = [];
int userResult;
int numberOne;
int numberTwo;
int result;

do
{
    Console.Clear();

    Console.WriteLine("Hello, Welcome to Math Game!\n");

    Console.WriteLine("- 1 - Addition operation.");
    Console.WriteLine("- 2 - Addition subtraction.");
    Console.WriteLine("- 3 - Addition division.");
    Console.WriteLine("- 4 - Addition multiplication.");
    Console.WriteLine("- 5 - Review results.\n");

    Console.WriteLine("Please type a number to choose an option from the menu: ");

    userInput = Console.ReadLine().Trim();

    switch (userInput)
    {
        case "1":
            if (CheckStatusGame())
            {
                break;
            }

            numberOne = GetRandomNumber(10);
            numberTwo = GetRandomNumber(10);

            result = numberOne + numberTwo;

            Console.WriteLine("\nWhat is the result of the following operation?");
            Console.WriteLine($"\n{numberOne} + {numberTwo} = ? \n");
            userInput = Console.ReadLine().Trim();

            try
            {
                userResult = Convert.ToInt32(userInput);
            }
            catch
            {
                Console.WriteLine("\nInvalid input!");
                Console.WriteLine("\nPress the Enter key to continue.");
                Console.ReadLine();
                break;
            }

            if (userResult == result)
            {
                Console.WriteLine("\nCorrect!");
                questionsAsked++;
                correctAnswers++;
            }
            else
            {
                Console.WriteLine("\nWrong answer!");
                questionsAsked++;
                correctAnswers--;
            }

            Console.WriteLine("\nPress the Enter key to continue.");
            Console.ReadLine();
            break;

        case "2":
            if (CheckStatusGame())
            {
                break;
            }

            numberOne = GetRandomNumber(10);
            numberTwo = GetRandomNumber(10);

            result = numberOne - numberTwo;

            Console.WriteLine("\nWhat is the result of the following operation?");
            Console.WriteLine($"\n{numberOne} - {numberTwo} = ? \n");
            userInput = Console.ReadLine().Trim();

            try
            {
                userResult = Convert.ToInt32(userInput);
            }
            catch
            {
                Console.WriteLine("\nInvalid input!");
                Console.WriteLine("\nPress the Enter key to continue.");
                Console.ReadLine();
                break;
            }

            if (userResult == Math.Abs(result))
            {
                Console.WriteLine("\nCorrect!");
                questionsAsked++;
                correctAnswers++;
            }
            else
            {
                Console.WriteLine("\nWrong answer!");
                questionsAsked++;
                correctAnswers--;
            }

            Console.WriteLine("\nPress the Enter key to continue.");
            Console.ReadLine();
            break;

        case "3":
            if (CheckStatusGame())
            {
                break;
            }

            numberOne = GetRandomNumber(100);
            numberTwo = 2;

            result = numberOne % numberTwo;

            if (result == 0)
            {
                result = numberOne / numberTwo;
            }
            else
            {
                while (result != 0)
                {
                    numberOne = GetRandomNumber(100);

                    result = numberOne % numberTwo;
                }

                result = numberOne / numberTwo;
            }

            Console.WriteLine("\nWhat is the result of the following operation?");
            Console.WriteLine($"\n{numberOne} / {numberTwo} = ? \n");
            userInput = Console.ReadLine().Trim();

            try
            {
                userResult = Convert.ToInt32(userInput);
            }
            catch
            {
                Console.WriteLine("\nInvalid input!");
                Console.WriteLine("\nPress the Enter key to continue.");
                Console.ReadLine();
                break;
            }

            if (userResult == result)
            {
                Console.WriteLine("\nCorrect!");
                questionsAsked++;
                correctAnswers++;
            }
            else
            {
                Console.WriteLine("\nWrong answer!");
                questionsAsked++;
                correctAnswers--;
            }

            Console.WriteLine("\nYou have choose division.");

            Console.WriteLine("\nPress the Enter key to continue.");
            Console.ReadLine();
            break;

        case "4":
            if (CheckStatusGame())
            {
                break;
            }

            numberOne = GetRandomNumber(10);
            numberTwo = GetRandomNumber(10);

            result = numberOne * numberTwo;

            Console.WriteLine("\nWhat is the result of the following operation?");
            Console.WriteLine($"\n{numberOne} x {numberTwo} = ? \n");
            userInput = Console.ReadLine().Trim();

            try
            {
                userResult = Convert.ToInt32(userInput);
            }
            catch
            {
                Console.WriteLine("\nInvalid input!");
                Console.WriteLine("\nPress the Enter key to continue.");
                Console.ReadLine();
                break;
            }

            if (userResult == result)
            {
                Console.WriteLine("\nCorrect!");
                questionsAsked++;
                correctAnswers++;
            }
            else
            {
                Console.WriteLine("\nWrong answer!");
                questionsAsked++;
                correctAnswers--;
            }

            Console.WriteLine("\nYou have choose multiplication.");

            Console.WriteLine("\nPress the Enter key to continue.");
            Console.ReadLine();
            break;

        case "5":

            Console.WriteLine("\nReview your games!\n");

            if (gamesPlayed.Count() == 0)
            {
                Console.WriteLine("You have not complete any game yet!");
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
    return randomNumber.Next(number);
}

bool CheckStatusGame()
{
    if (questionsAsked == maxQuestionAsked)
    {
        gamesPlayed.Add($"You got {correctAnswers}/{maxQuestionAsked} correct answers!");

        Console.WriteLine("\nGame over!\n");
        Console.WriteLine($"Here are your results: {correctAnswers}/{maxQuestionAsked}");
        Console.WriteLine("\nPress the Enter key to play a new game.");
        Console.ReadLine();

        correctAnswers = 0;
        questionsAsked = 0;

        return true;
    }

    return false;
}
