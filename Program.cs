using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Media;
using System.Threading;
using System.IO;

namespace ChatbotPart2
{
    internal class Program
    {
        static string userName = "";
        static string userMood = "";

        static void Main(string[] args)
        {
            // Call out the Methods
            DisplayLogo();
            DisplayVoiceGreeting();
            DisplayGreetUser();
            DisplayUserInputs();
        }

        static void DisplayLogo()
        {
            string logo = @"
  ________            __  __                   ________          __  __          __ 
 /_  __/ /_  ___     / / / /_  __________     / ____/ /_  ____ _/ /_/ /_  ____  / /_
  / / / __ \/ _ \   / /_/ / / / /_  /_  /    / /   / __ \/ __ `/ __/ __ \/ __ \/ __/
 / / / / / /  __/  / __  / /_/ / / /_/ /_   / /___/ / / / /_/ / /_/ /_/ / /_/ / /_  
/_/ /_/ /_/\___/  /_/ /_/\__,_/ /___/___/   \____/_/ /_/\__,_/\__/_.___/\____/\__/  
                                                                                    ";
            Console.WriteLine(logo);
        }

        static void DisplayVoiceGreeting()
        {
            try
            {
                if (File.Exists("welcome.wav"))
                {
                    SoundPlayer soundPlayer = new SoundPlayer("welcome.wav");
                    soundPlayer.PlaySync(); // Wait for sound to finish
                }
                else
                {
                    Console.WriteLine("Audio file 'welcome.wav' not found.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: Audio cannot be found: " + ex.Message);
            }
        }

        static void DisplayGreetUser()
        {
            Console.WriteLine("What is your name?");
            userName = Console.ReadLine();
            TypingDelay($"\nHello, {userName}! Welcome to The Huzz Chatbot, where you can be informed about the internet.");

            Console.WriteLine("How are you feeling today?");
            userMood = Console.ReadLine().ToLower();
            RespondToMood(userMood);
        }

        static void RespondToMood(string mood)
        {
            if (mood.Contains("happy") || mood.Contains("good"))
            {
                TypingDelay("I'm glad to hear you're doing well!");
            }
            else if (mood.Contains("sad") || mood.Contains("down"))
            {
                TypingDelay("I'm sorry to hear that. I hope I can make your day a little better with some helpful tips.");
            }
            else if (mood.Contains("angry") || mood.Contains("frustrated"))
            {
                TypingDelay("I understand how frustrating things can be. Let me know if there's anything specific I can help you with.");
            }
          Console.WriteLine("Thanks for sharing.");
         
        }

        static void DisplayUserInputs()
        {
            while (true)
            {
                Console.WriteLine($"\n{userName}, how can I help you?");
                string input = Console.ReadLine().Trim().ToLower();

                if (input == "exit")
                {
                    TypingDelay("Goodbye! Stay safe online.");
                    break;
                }

                // Keyword recognition logic
                if (input.Contains("password"))
                {
                    TypingDelay("Make sure to use strong, unique passwords for each account. Avoid using personal details in your passwords.");
                }
                else if (input.Contains("scam") || input.Contains("phishing"))
                {
                    TypingDelay("Scams often appear as legitimate messages. Avoid clicking unknown links or giving out personal information.");
                }
                else if (input.Contains("privacy"))
                {
                    TypingDelay("Protect your privacy by limiting what you share online and reviewing app permissions regularly.");
                }
                else if (input.Contains("cybersecurity"))
                {
                    TypingDelay("Cybersecurity means protecting your systems, devices, and data from digital threats like malware and hackers.");
                }
                else if (input.Contains("help"))
                {
                    TypingDelay("You can ask me about:\n- Password safety\n- Scam or phishing protection\n- Online privacy\nType 'exit' to quit.");
                }
                else
                {
                    TypingDelay("I'm not sure how to respond to that. Try asking about password safety, scams, or online privacy.");
                }
            }
        }

        static void TypingDelay(string message)
        {
            foreach (char c in message)
            {
                Console.Write(c);
                Thread.Sleep(30); // 30ms delay to simulate human typing
            }
            Console.WriteLine("\n");
        }
    }
}
