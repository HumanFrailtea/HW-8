/// Homework No.__ Exercise No.__
/// File Name:     HW 8.sln
/// @author:       Upendra Samaranayake
/// Date:          November 2, 2020
///
/// Problem Statement: Write a program to simulate the duels of Aaron, Bob and Charlie. 
///    
/// Overall Plan (step-by-step, how you want the code to make it happen):
/// 1. Set up a class to hold the values for name, accuracy and living status.
/// 2. Enter the values in the class Duelist.
/// 3. Simulate the duel with each target being shot based on how accurate they are.
/// 4. Run a loop of 10,000 duels.
/// 5. Print out probability of winning for each contesant which is incremented in the loop.
/// etc.
/// 
using System;

namespace HW_8_1
{
	public class DuelistDemo
	{
		private string name;
		private double accuracy;
		private bool alive;
		public DuelistDemo(string n, double acc)
		{
			this.name = n;
			this.accuracy = acc;
			alive = true;
		}
		public virtual bool Alive
		{
			get
			{
				return alive;
			}
		}
		public virtual string Name
		{
			get
			{
				return name;
			}
		}
		public virtual void ShootAtTarget(DuelistDemo dd)
		{
			if (GlobalRandom.NextDouble < accuracy)
			{
				dd.alive = false;
			}
		}
	}

	internal static class GlobalRandom
	{
		private static System.Random randomInstance = null;

		public static double NextDouble
		{
			get
			{
				if (randomInstance == null)
					randomInstance = new System.Random();

				return randomInstance.NextDouble();
			}
		}
	}
	public class DuelistTest
	{

		public static void Main(string[] args)
		{
			int aWin = 0;
			int bWin = 0;
			int cWin = 0;
			for (int i = 1; i <= 10000; i++)
			{
				DuelistDemo aaron = new DuelistDemo("Aaron", 0.33);
				DuelistDemo bob = new DuelistDemo("Bob", 0.5);
				DuelistDemo charlie = new DuelistDemo("Charlie", 1);
				int aliveCount = 3;
				while (aliveCount > 1)
				{

					if (aaron.Alive)
					{
						if (charlie.Alive)
						{
							aaron.ShootAtTarget(charlie);
							if (!charlie.Alive)
							{
								aliveCount--;
							}
						}
						else
						{
							aaron.ShootAtTarget(bob);
							if (!bob.Alive)
							{
								aliveCount--;
							}
						}
					}
					if (bob.Alive)
					{
						if (charlie.Alive)
						{
							bob.ShootAtTarget(charlie);

							if (!charlie.Alive)
							{
								aliveCount--;
							}
						}
						else
						{
							bob.ShootAtTarget(aaron);

							if (aaron.Alive)
							{
								aWin++;
							}
						}
					}
					if (charlie.Alive)
					{
						if (bob.Alive)
						{
							charlie.ShootAtTarget(bob);
							if (!bob.Alive)
							{
								aliveCount--;
							}
						}
						else
						{
							charlie.ShootAtTarget(aaron);

							if (!aaron.Alive)
							{
								aliveCount--;
							}
						}
					}
				}
				if (aaron.Alive)
				{
					aWin++;
				}
				else if (bob.Alive)
				{
					bWin++;
				}
				else
				{
					cWin++;
				}
			}
			Console.WriteLine("Aaron has won " + aWin + " times of 10000 duels.");
			Console.WriteLine("Bob has won " + bWin + " times of 10000 duels.");
			Console.WriteLine("Charlie has won " + cWin + " times of 10000 duels");
		}

	}
}
