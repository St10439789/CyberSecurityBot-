using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Management.Instrumentation;
using System.Runtime.Remoting.Lifetime;

namespace CyberSecurityBot_
{
    internal class Chatbot
    {
        ConsoleTypeEffect consoleType = new ConsoleTypeEffect();

        // Instance of SoundManager and UIManager to handle tasks
        private SoundManager _soundManager;
        private LogoDisplay _logoDisplay;

        // Constructor to initialize the SoundManager and UIManager
        public Chatbot()
        {
            _soundManager = new SoundManager();
            _logoDisplay = new LogoDisplay();
        }

        // Method that starts the chatbot and initiates all necessary tasks
        public void Start()
        {
            // Play the greeting sound when the application starts
            _soundManager.PlayGreeting();

            // Displaying the UI elements like the header and ASCII logo
            _logoDisplay.DisplayHeader();
            _logoDisplay.DisplayAsciiLogo();

            // Asking the user for their name and greet them
            AskUserName();

            // Start the basic response system for user interaction
            BasicResponseSystem();
        }

        // Method to ask the user for their name and display a personalized greeting
        private void AskUserName()

        {
           

            // Prompt for the user's name and display the prompt in green
            Console.ForegroundColor = ConsoleColor.Green;
            consoleType.typyingeffect("\nPlease enter your name: ");
            
            Console.ResetColor();

            // Getting the user's name as input
            string userName = Console.ReadLine();

            // Display a personalized welcome message in yellow
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            consoleType.typyingeffect($"\nHello, {userName}! Welcome to the Cybersecurity Awareness Bot.");
            Console.ResetColor();
        }

        // Method that handles the basic response system where the bot responds to user questions
        public void BasicResponseSystem()
        {
            
            // Inform the user to ask something about cybersecurity
            Console.ForegroundColor = ConsoleColor.Cyan;
            consoleType.typyingeffect("\n I am here to help you stay safe online, kindly confirm your name to get started");
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.Green;
            consoleType.typyingeffect("Your Name: ");

            string userName = Console.ReadLine();

            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Cyan;
            consoleType.typyingeffect("Hello " + userName + ", I am here to help you stay safe online. Ask me something about cybersecurity!");
            Console.ResetColor();
            string userQuestion;
            // Create an ArrayList to hold questions and responses
            ArrayList responses = new ArrayList
    {
        new { Keywords = new[] { "how are you" }, Response = "I'm doing great, thank you for asking! How about you?" },
        new { Keywords = new[] { "what's your purpose", "purpose" }, Response = "I'm here to help you learn about staying safe online. I can answer questions about password safety, phishing, and safe browsing." },
        new { Keywords = new[] { "password safety", "password" }, Response = "Always use strong, unique passwords for each account. A good password has a mix of letters, numbers, and special characters." },
        new { Keywords = new[] { "phishing" }, Response = "Be careful of suspicious emails or websites that try to steal your personal information. Don't click on links or attachments from untrusted sources." },
        new { Keywords = new[] { "safe browsing", "browsing" }, Response = "Always use secure websites (look for HTTPS in the URL). Avoid using public Wi-Fi for sensitive activities." },
        new { Keywords = new[] { "ransomware" }, Response = "Ransomware is a type of harmful software that locks your files or computer and demands money to unlock them. It's a form of extortion." },
        new { Keywords = new[] { "sabotage" }, Response = "Sabotage involves intentionally damaging or disrupting a computer system or data, often carried out by someone inside the organization." },
        new { Keywords = new[] { "malware" }, Response = "Malware is any software designed to harm or exploit computers, including viruses, worms, and ransomware. It can disrupt your system or steal sensitive data." },
        new { Keywords = new[] { "social engineering", "engineering" }, Response = "Social engineering refers to tricks used to manipulate people into giving away sensitive information, like passwords, often through deceptive emails or messages." },
        new { Keywords = new[] { "vpn", "virtual private network" }, Response = "A VPN (Virtual Private Network) is a service that creates a secure connection over the internet, helping to protect your data and privacy while online." }
    };
            // Infinite loop to keep the conversation going until the user exits
            while (true)
            {
                // Read the user's question in lowercase for easier comparison
                Console.ForegroundColor = ConsoleColor.Magenta; 
                Console.Write(userName + ": "); 
                Console.ResetColor(); 
                userQuestion = Console.ReadLine().ToLower();
                Console.WriteLine(); 
                if (string.IsNullOrWhiteSpace(userQuestion))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    consoleType.typyingeffect("I didn't quite understand that. Could you rephrase?");
                    Console.ResetColor();
                }
                else if (userQuestion.Contains("exit") || userQuestion.Contains("goodbye"))
                {
                    // Farewell message with a green color
                    Console.ForegroundColor = ConsoleColor.Green;
                    consoleType.typyingeffect("Goodbye! Thank you for your time today, take care and see you soon. Stay safe online!");
                    Console.ResetColor();
                    break; // Exit the loop after displaying the message
                }
                else
                {
                    // Split the user's question into separate potential queries using a question mark or other delimiters
                    string[] queries = userQuestion.Split(new[] { '?' }, StringSplitOptions.RemoveEmptyEntries);
                    List<string> allRelevantResponses = new List<string>();
                    foreach (var query in queries)
                    {
                        bool found = false;
                        foreach (var item in responses)
                        {
                            var responseItem = (dynamic)item; // Use dynamic to access properties
                            foreach (var keyword in responseItem.Keywords)
                            {
                                if (query.Contains(keyword))
                                {
                                    allRelevantResponses.Add(responseItem.Response);
                                    found = true;
                                }
                            }
                        }
                        if (!found)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            consoleType.typyingeffect("Sorry, I didn't quite understand that. Could you rephrase?");
                            Console.ResetColor();
                        }
                    }
                    if (allRelevantResponses.Count > 0)
                    {
                        foreach (var response in allRelevantResponses)
                        {
                            Console.ForegroundColor = ConsoleColor.Cyan;
                            Console.Write("CyberSecurityBot: ");
                            Console.ResetColor();
                            Console.ForegroundColor = ConsoleColor.Blue;
                            Console.WriteLine(response);
                            Console.ResetColor();
                        }
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        consoleType.typyingeffect("Sorry, I couldn't find any answers for your questions.");
                        Console.ResetColor();
                    }
                    Console.WriteLine(); // Add an empty line after bot response
                }
            }
        }
    }
}
