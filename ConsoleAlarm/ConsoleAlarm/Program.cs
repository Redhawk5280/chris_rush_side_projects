using ConsoleAlarm.Exceptions;
using System.Diagnostics;
using System.Globalization;
using System.Threading;
using System.Media;
using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;

namespace ConsoleAlarm
{
    internal class Program
    {
        static void Main(string[] args)
        {
            SoundPlayer player = new SoundPlayer("C:\\Users\\Student\\workspace\\chris_rush_side_projects\\ConsoleAlarm\\ConsoleAlarm\\Alarm_Clock_Audio.wav");

            Console.WriteLine("Hello, Please enter a time you would like to have your alarm go off at.");
            Console.WriteLine("Must be entered in one of the following formats:\nMM/DD/YYYY HH:MM | MM/DD/YY HH:MM | MM-DD-YYYY HH:MM | MM-DD-YY HH:MM | HH:MM");
            string timeUserEntered = Console.ReadLine();
            bool alarmTimeAcceptable = false;
            DateTime alarmTime;
            alarmTimeAcceptable = DateTime.TryParse(timeUserEntered, out alarmTime);
            if (!alarmTimeAcceptable || alarmTime <= DateTime.Today)
            {
                while (!alarmTimeAcceptable || alarmTime <= DateTime.Today) 
                {
                    try
                    {
                        alarmTimeAcceptable = DateTime.TryParse(timeUserEntered, out alarmTime);
                        //if (alarmTime <= DateTime.Today)
                        //{
                        //    throw new BeforeCurrentDateException("You cannot set an alarm before the current time.");
                        //}
                        Console.WriteLine(alarmTime);

                    }
                    catch (FormatException exf)
                    {
                        Console.WriteLine("This time is not in one of the correct formats.");
                        Console.WriteLine("Please Enter in a valid time.");
                        Thread.Sleep(1000);
                        Console.WriteLine("Must be entered in one of the following formats:\nMM/DD/YYYY HH:MM | MM/DD/YY HH:MM | MM-DD-YYYY HH:MM | MM-DD-YY HH:MM | HH:MM");
                        
                    }
                    catch (BeforeCurrentDateException exb)
                    {
                        Console.WriteLine("Time entered was before the current time, we cannot go back in time.");
                        Thread.Sleep(1000);
                        Console.WriteLine("Please Enter in a valid time.");
                        Console.WriteLine("Must be entered in one of the following formats:\nMM/DD/YYYY HH:MM | MM/DD/YY HH:MM | MM-DD-YYYY HH:MM | MM-DD-YY HH:MM | HH:MM");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("An unknown error has occured.");
                        Thread.Sleep(1000);
                        Console.WriteLine("Please Enter in a valid time.");
                        Console.WriteLine("Must be entered in one of the following formats:\nMM/DD/YYYY HH:MM | MM/DD/YY HH:MM | MM-DD-YYYY HH:MM | MM-DD-YY HH:MM | HH:MM");
                    }

                }
            }
            Console.WriteLine($"Alarm is set for {timeUserEntered}");
            while (true)
            {
                if (DateTime.Now.ToString("HH:mm").Equals(timeUserEntered))
                {
                    player.Load();
                    player.PlayLooping();
                    Console.WriteLine("Alarm is going off! Enter \"stop\" to stop alarm.");
                    string userEndAlarmCommand = Console.ReadLine();
                    userEndAlarmCommand = userEndAlarmCommand.ToLower();
                    while (!userEndAlarmCommand.Equals("stop"))
                    {
                        Console.WriteLine("Invalid entry, enter \"stop\" to stop alarm.");
                        userEndAlarmCommand = Console.ReadLine();
                        continue;
                    }
                    break;
                }
                else
                {
                    Thread.Sleep(1000);
                    continue;
                }
            }

        }
    }
}