using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Media;
using System.Threading;
using System.Runtime.InteropServices.ComTypes;

namespace ChatbotPart1
{
    internal class Program
    {
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
                SoundPlayer soundPlayer = new SoundPlayer("welcome.wav"); // Location of the sound file
                soundPlayer.PlaySync(); // Makes the code wait for the sound to finish playing
            }
            catch (Exception ex) // Error message if the audio file cannot be found
            {
                Console.WriteLine("Error: Audio cannot be found: " + ex.Message);
            }
        }

        static void DisplayGreetUser()
        {
            Console.WriteLine("What is your name?");
            var userName = Console.ReadLine();
            TypingDelay($"\nHello, {userName}! Welcome to The Huzz Chatbot, where you can be informed about the internet.");
        }

        static void DisplayUserInputs()
        {
            while (true)
            {
                Console.WriteLine("How can I help you?");
                string input = Console.ReadLine().Trim().ToLower(); // Normalize user input

                if (input == "exit")
                    break;

                switch (input)
                {
                    case "how are you?":
                        TypingDelay("I'm just a bot, but I'm here to help you stay safe online.");
                        break;

                    case "what is a strong password to use?":
                        TypingDelay("A strong password should be at least 12 characters long and include uppercase and lowercase letters, numbers, and special characters.");
                        break;

                    case "how to avoid phishing attacks?":
                        TypingDelay("Be cautious of emails from unknown sources, verify senders, use HTTPS, enable Multi-Factor Authentication (MFA), and keep your software updated.");
                        break;

                    case "how to browse safely online?":
                        TypingDelay("Use HTTPS, enable 2FA, avoid phishing links, use strong passwords, limit personal info sharing, and consider using a VPN.");
                        break;

                    case "what do I need to know about cybersecurity?":
                        TypingDelay("Use strong passwords, enable 2FA, avoid phishing and malware, keep software updated, use secure networks, and back up important files.");
                        break;

                    default:
                        TypingDelay("Sorry, I don't understand. Please try again.");
                        break;
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
