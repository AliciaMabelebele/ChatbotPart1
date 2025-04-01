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
        {//Call out the Methods
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
                SoundPlayer soundPlayer = new SoundPlayer("welcome.wav");//location of the sound file
                soundPlayer.PlaySync();//makes the code wait for the sound to finish playing

            }
            catch (Exception ex) //Error message if you can not find the audio
            {
                Console.WriteLine("Error Audio can not be found:  " + ex.Message);


            }


        }

        static void DisplayGreetUser()
        {
            Console.WriteLine("What is your name?");
            var userName = Console.ReadLine();
            TypingDelay($"\nHello,{userName}!Welcom to The Huzz Chatbot,where you can be infored about the internet.");

        }
        static void DisplayUserInputs()
        {
            while (true)
            {
                Console.WriteLine("How can i help you ");
                string input = Console.ReadLine().Trim().ToLower();//allows to print the input in diffrent cases


                if (input == "exit")
                    break;


                switch (input)
                {
                    case "how are you ?":
                        TypingDelay("I'm just a bot, but i'm here to help you stay safe online");

                        break;

                    case " What is a strong password to use":
                        TypingDelay(" Length: Aim for at least 12 characters, though more is even better. Longer passwords are harder to crack.\r\n\r\nComplexity: Use a mix of:\r\n\r\nUppercase letters (A-Z)\r\n\r\nLowercase letters (a-z)\r\n\r\nNumbers (0-9)\r\n\r\nSpecial characters (e.g., !, @, #, $, %, ^, &, *)");

                        break;

                    case "how to avoid phishing attacks?":
                        TypingDelay("Be cautious of unsolicited emails: Don't click on links or open attachments from unknown sources.\r\n\r\nVerify the sender: Check the email address carefully and hover over links to check the URL.\r\n\r\nUse HTTPS: Ensure websites have \"https\" and a padlock symbol before entering sensitive info.\r\n\r\nEnable Multi-Factor Authentication (MFA): Adds extra protection even if your password is compromised.\r\n\r\nKeep software updated: Install the latest security patches and use antivirus tools.");

                         break;

                    case "how to browse safely online?":
                        TypingDelay("Use HTTPS, keep software updated, enable 2FA, avoid phishing links, use strong passwords, be cautious with downloads, limit personal info sharing, install an ad blocker, and clear cookies regularly. Consider a VPN and a privacy-focused browser.\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n");


                        break;
                    case "what do i need to know about cybersecurity? ":
                        TypingDelay("Use strong passwords & 2FA, avoid phishing & malware, keep software updated, use secure networks & VPNs, limit data sharing, browse with HTTPS & ad blockers, and back up files regularly. Stay alert to scams & social engineering.");
                        break;

                        default:
                        TypingDelay("sorry i dont understand");
                        break;

                }
            }
        }

        
        static void TypingDelay(string message)
        {
            foreach (char c in message) 
            {
                Console.Write(c);
                Thread.Sleep(30);//30mins delay the bot typing to make it more humaine
            }
            Console.WriteLine("\n");
        }




     }
}
