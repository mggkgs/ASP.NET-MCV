using System;

class Program
{
    static void Main()
    {
        Console.WriteLine("Welcome to Twenty-One!");

        while (true)
        {
            Console.WriteLine("Press Enter to start a new round or 'Q' to quit.");
            string userInput = Console.ReadLine();

            if (userInput?.ToUpper() == "Q")
                break;

            // Start a new round
            PlayRound();

            Console.WriteLine("Press Enter to play again or 'Q' to quit.");
            userInput = Console.ReadLine();

            if (userInput?.ToUpper() == "Q")
                break;
        }

        Console.WriteLine("Thanks for playing Twenty-One!");
    }

    static void PlayRound()
    {
        // Simple implementation for a single round
        Random random = new Random();

        int playerCard1 = random.Next(1, 11);
        int playerCard2 = random.Next(1, 11);

        int dealerCard1 = random.Next(1, 11);
        int dealerCard2 = random.Next(1, 11);

        int playerTotal = playerCard1 + playerCard2;
        int dealerTotal = dealerCard1 + dealerCard2;

        Console.WriteLine($"Player's cards: {playerCard1}, {playerCard2} (Total: {playerTotal})");
        Console.WriteLine($"Dealer's face-up card: {dealerCard1}");

        // Player's turn
        while (playerTotal < 21)
        {
            Console.WriteLine("Do you want to hit (H) or stand (S)?");
            string choice = Console.ReadLine()?.ToUpper();

            if (choice == "H")
            {
                int newCard = random.Next(1, 11);
                Console.WriteLine($"You drew a {newCard}.");
                playerTotal += newCard;
                Console.WriteLine($"Player's total: {playerTotal}");
            }
            else if (choice == "S")
            {
                break;
            }
        }

        // Dealer's turn
        Console.WriteLine($"Dealer's face-down card: {dealerCard2}");
        while (dealerTotal < 17)
        {
            int newCard = random.Next(1, 11);
            Console.WriteLine($"Dealer drew a {newCard}.");
            dealerTotal += newCard;
        }

        Console.WriteLine($"Player's total: {playerTotal}");
        Console.WriteLine($"Dealer's total: {dealerTotal}");

        // Determine the winner
        if (playerTotal > 21 || (dealerTotal <= 21 && dealerTotal >= playerTotal))
        {
            Console.WriteLine("Dealer wins!");
        }
        else
        {
            Console.WriteLine("Player wins!");
        }
    }
}