﻿using System;

namespace plus
{
    class Program
    {
        static void Main(string[] args)
		{
			//stock_lower_limit_material:低於數量進行補貨
			const int stock_lower_limit_material = 5;
			//staff_number:員工人數
			int staff_number = 2;
			int Revenue = 0;
			int all_cost = 0;
			int food_cost = 0;

			Set_up_the_system(out string name_of_the_store, out string password, out string name_of_the_administrator, out staff_number);
			Generate_the_menu
				(out string[] material_icecream, out int[] price_unit_material_icecream, out int[] num_unit_material_icecream, out int[] expirationDate_unit_material_icecream,
				 out string[] material_fruits, out int[] price_unit_material_fruits, out int[] num_unit_material_fruits, out int[] expirationDate_unit_material_fruits,
				 out string[] material_drinks, out int[] price_unit_material_drinks, out int[] num_unit_material_drinks, out int[] expirationDate_unit_material_drinks,
				 out string[] material_main_meal, out int[] price_unit_material_main_meal, out int[] num_unit_material_main_meal, out int[] expirationDate_unit_material_main_meal,
				 out string[] material_syrup, out int[] price_unit_material_syrup, out int[] num_unit_material_syrup, out int[] expirationDate_unit_material_syrup,
				 out string[] material_main_meal_toppings, out int[] price_unit_material_main_meal_toppings, out int[] num_unit_material_main_meal_toppings, out int[] expirationDate_unit_material_main_meal_toppings,
				 out string[] material_drinks_toppings, out int[] price_unit_material_drinks_toppings, out int[] num_unit_material_drinks_toppings, out int[] expirationDate_unit_material_drinks_toppings,
				 out int[] standby_num_unit_material_icecream, out int[] standby_expirationDate_unit_material_icecream, out int[] intact_expirationDate_unit_material_icecream,
				 out int[] standby_num_unit_material_fruits, out int[] standby_expirationDate_unit_material_fruits, out int[] intact_expirationDate_unit_material_fruits,
				 out int[] standby_num_unit_material_drinks, out int[] standby_expirationDate_unit_material_drinks, out int[] intact_expirationDate_unit_material_drinks,
				 out int[] standby_num_unit_material_main_meal, out int[] standby_expirationDate_unit_material_main_meal, out int[] intact_expirationDate_unit_material_main_meal,
				 out int[] standby_num_unit_material_syrup, out int[] standby_expirationDate_unit_material_syrup, out int[] intact_expirationDate_unit_material_syrup,
				 out int[] standby_num_unit_material_main_meal_toppings, out int[] standby_expirationDate_unit_material_main_meal_toppings, out int[] intact_expirationDate_unit_material_main_meal_toppings,
				 out int[] standby_num_unit_material_drinks_toppings, out int[] standby_expirationDate_unit_material_drinks_toppings, out int[] intact_expirationDate_unit_material_drinks_toppings,
				 ref food_cost);
			string[] order_waiting_list = new string[] { "" };
			string[] order_history_list = new string[] { "" };
			string[] material_stock = new string[100];
			string[] material_extra = new string[10];
			string[] membership_member_name = { "" };
			string[] membership_member_phone_number = { "" };
			string[] membership_member_status = { "" };
			string[] membership_member_exclusive_order = { "" };
			int[] membership_member_exclusive_order_price = { 0 };
			int[] membership_member_cumulaative_comsumption_amount = { 0 };
			//會員折扣可改成讓店主自行決定
			double[] discount_of_each_member_status = { 1, 0.95, 0.9, 0.85 };
			int[] standard_of_member_status = { 0, 2000, 4000, 6000 };
			bool extra = false;
			int i = 1, martial_No = 0;
			for (i = 1; true; i++)
			{
				for (int j = 0; j < order_waiting_list.Length; j++)
				{
					if (order_waiting_list[j] != "")
					{
						Console.WriteLine(order_waiting_list[j]);
					}
				}
				Console.Write("會員快速點餐請輸入\"4\"，顯示菜單請輸入\"3\"，出餐請輸入\"2\"，顧客點餐請輸入\"1\"，欲進入系統管理請輸入\"0\":");
				string function = Console.ReadLine();
				Console.Clear();
				while (function != "2" && function != "1" && function != "0" && function != "3" && function != "4")
				{
					Console.WriteLine("輸入錯誤，請重新輸入!");
					Console.Write("會員快速點餐請輸入\"4\"，" + '\n' + "顯示菜單請輸入\"3\"，" + '\n' + "出餐請輸入\"2\"，" + '\n' + "顧客點餐請輸入\"1\"，" + '\n' + "欲進入系統管理請輸入\"0\":");
					function = Console.ReadLine();
					Console.Clear();
				}
				Console.Clear();
				if (function == "1")
				{
					Array.Resize(ref order_waiting_list, i + 1);
					Array.Resize(ref order_history_list, i + 1);
					//增加庫存系統變數、Revneue
					Take_an_order
						(name_of_the_store,
						 material_icecream, price_unit_material_icecream,
						 material_fruits, price_unit_material_fruits,
						 material_drinks, price_unit_material_drinks,
						 material_main_meal, price_unit_material_main_meal,
						 material_syrup, price_unit_material_syrup,
						 material_main_meal_toppings, price_unit_material_main_meal_toppings,
						 material_drinks_toppings, price_unit_material_drinks_toppings,
						 out int price_of_the_total_order, out string a_new_order, out string material, out Revenue);
					//取得點餐內容
					material_stock[i] = material;
					order_waiting_list[i] = "訂單編號:00" + i + '\n' + '\n' + a_new_order + '\n';
					order_history_list[i] = order_waiting_list[i];
					Checkout
						(ref price_of_the_total_order, ref Revenue, ref a_new_order,
						 name_of_the_store, ref membership_member_name, ref membership_member_phone_number,
						 ref membership_member_status, ref membership_member_cumulaative_comsumption_amount,
						 discount_of_each_member_status, standard_of_member_status,
						 ref membership_member_exclusive_order_price, ref membership_member_exclusive_order,
						 ref material_extra, material);
				}
				if (function == "0")
				{
					Console.Write("請輸入管理員密碼:");
					string input_password = Console.ReadLine();
					while (input_password != password)
					{
						Console.Write("密碼輸入錯誤，請重新輸入:");
						input_password = Console.ReadLine();
						Console.Clear();
					}

					//  會員系統:3  庫存系統:2  財務系統:1  系統設定:0
					Console.Clear();
					Console.Write("欲進入會員系統請輸入\"3\"，欲進入庫存系統請輸入\"2\"，欲進入財務系統請輸入\"1\"，系統設定請輸入\"0\":");
					string system_repuest = Console.ReadLine();
					Console.Clear();

					//============================*系統設定*==============================
					if (system_repuest == "0")
					{
						string function_system_management;
						do
						{
							Console.Write("重設系統請輸入\"reset\"，重設密碼請輸入\"p\"，其他功能更新中:");
							function_system_management = Console.ReadLine();
							Console.Clear();
						} while (function_system_management != "reset" && function_system_management != "p");
						switch (function_system_management)
						{
							case "reset":
								Console.Clear();
								Set_up_the_system(out name_of_the_store, out password, out name_of_the_administrator, out staff_number);

								//增加庫存系統變數
								Generate_the_menu(out material_icecream, out price_unit_material_icecream, out num_unit_material_icecream, out expirationDate_unit_material_icecream, out material_fruits, out price_unit_material_fruits, out num_unit_material_fruits, out expirationDate_unit_material_fruits, out material_drinks, out price_unit_material_drinks, out num_unit_material_drinks, out expirationDate_unit_material_drinks, out material_main_meal, out price_unit_material_main_meal, out num_unit_material_main_meal, out expirationDate_unit_material_main_meal, out material_syrup, out price_unit_material_syrup, out num_unit_material_syrup, out expirationDate_unit_material_syrup, out material_main_meal_toppings, out price_unit_material_main_meal_toppings, out num_unit_material_main_meal_toppings, out expirationDate_unit_material_main_meal_toppings, out material_drinks_toppings, out price_unit_material_drinks_toppings, out num_unit_material_drinks_toppings, out expirationDate_unit_material_drinks_toppings,
								out standby_num_unit_material_icecream, out standby_expirationDate_unit_material_icecream, out intact_expirationDate_unit_material_icecream,
								out standby_num_unit_material_fruits, out standby_expirationDate_unit_material_fruits, out intact_expirationDate_unit_material_fruits,
								out standby_num_unit_material_drinks, out standby_expirationDate_unit_material_drinks, out intact_expirationDate_unit_material_drinks,
								out standby_num_unit_material_main_meal, out standby_expirationDate_unit_material_main_meal, out intact_expirationDate_unit_material_main_meal,
								out standby_num_unit_material_syrup, out standby_expirationDate_unit_material_syrup, out intact_expirationDate_unit_material_syrup,
								out standby_num_unit_material_main_meal_toppings, out standby_expirationDate_unit_material_main_meal_toppings, out intact_expirationDate_unit_material_main_meal_toppings,
								out standby_num_unit_material_drinks_toppings, out standby_expirationDate_unit_material_drinks_toppings, out intact_expirationDate_unit_material_drinks_toppings,
								ref food_cost);
								break;
							case "p":
								Console.WriteLine("功能更新中!");
								break;
						}
					}
					//============================*財務系統*===============================
					else if (system_repuest == "1")
					{
						Financial_System(Revenue, all_cost, staff_number, ref food_cost);
						food_cost = 0;
						expirationDate
							(material_icecream, price_unit_material_icecream,
							num_unit_material_icecream, expirationDate_unit_material_icecream,
							material_fruits, price_unit_material_fruits,
							num_unit_material_fruits, expirationDate_unit_material_fruits,
							material_drinks, price_unit_material_drinks,
							num_unit_material_drinks, expirationDate_unit_material_drinks,
							material_main_meal, price_unit_material_main_meal,
							num_unit_material_main_meal, expirationDate_unit_material_main_meal,
							material_syrup, price_unit_material_syrup,
							num_unit_material_syrup, expirationDate_unit_material_syrup,
							material_main_meal_toppings, price_unit_material_main_meal_toppings,
							num_unit_material_main_meal_toppings, expirationDate_unit_material_main_meal_toppings,
							material_drinks_toppings, price_unit_material_drinks_toppings,
							num_unit_material_drinks_toppings, expirationDate_unit_material_drinks_toppings,
							standby_num_unit_material_icecream, standby_expirationDate_unit_material_icecream,
							standby_num_unit_material_fruits, standby_expirationDate_unit_material_fruits,
							standby_num_unit_material_drinks, standby_expirationDate_unit_material_drinks,
							standby_num_unit_material_main_meal, standby_expirationDate_unit_material_main_meal,
							standby_num_unit_material_syrup, standby_expirationDate_unit_material_syrup,
							standby_num_unit_material_main_meal_toppings, standby_expirationDate_unit_material_main_meal_toppings,
							standby_num_unit_material_drinks_toppings, standby_expirationDate_unit_material_drinks_toppings,
							intact_expirationDate_unit_material_icecream, intact_expirationDate_unit_material_fruits,
							intact_expirationDate_unit_material_drinks, intact_expirationDate_unit_material_main_meal,
							intact_expirationDate_unit_material_syrup, intact_expirationDate_unit_material_main_meal_toppings,
							intact_expirationDate_unit_material_drinks_toppings, stock_lower_limit_material, ref food_cost);
					}
					//============================*庫存系統*===============================
					else if (system_repuest == "2")
					{
						stock
							(material_icecream, price_unit_material_icecream, num_unit_material_icecream, expirationDate_unit_material_icecream,
							 material_fruits, price_unit_material_fruits, num_unit_material_fruits, expirationDate_unit_material_fruits,
			 				 material_drinks, price_unit_material_drinks, num_unit_material_drinks, expirationDate_unit_material_drinks,
			 				 material_main_meal, price_unit_material_main_meal, num_unit_material_main_meal, expirationDate_unit_material_main_meal,
			 				 material_syrup, price_unit_material_syrup, num_unit_material_syrup, expirationDate_unit_material_syrup,
							 material_main_meal_toppings, price_unit_material_main_meal_toppings, num_unit_material_main_meal_toppings, expirationDate_unit_material_main_meal_toppings,
			 				 material_drinks_toppings, price_unit_material_drinks_toppings, num_unit_material_drinks_toppings, expirationDate_unit_material_drinks_toppings,
							 stock_lower_limit_material,
							 standby_num_unit_material_icecream, standby_expirationDate_unit_material_icecream,
							 standby_num_unit_material_fruits, standby_expirationDate_unit_material_fruits,
							 standby_num_unit_material_drinks, standby_expirationDate_unit_material_drinks,
							 standby_num_unit_material_main_meal, standby_expirationDate_unit_material_main_meal,
							 standby_num_unit_material_syrup, standby_expirationDate_unit_material_syrup,
							 standby_num_unit_material_main_meal_toppings, standby_expirationDate_unit_material_main_meal_toppings,
							 standby_num_unit_material_drinks_toppings, standby_expirationDate_unit_material_drinks_toppings);
						Console.Write("請按任意鍵繼續:");
						Console.ReadKey();
					}
					//===========================*會員系統*===============================
					else if (system_repuest == "3")
					{
						Membership_arrangement
							(ref i, name_of_the_store, ref membership_member_phone_number, ref membership_member_name,
							 ref membership_member_status, ref membership_member_cumulaative_comsumption_amount,
							 ref membership_member_exclusive_order_price, ref membership_member_exclusive_order);
					}
					else
					{
						Console.WriteLine("輸入錯誤，請重新輸入");
						Console.Write("欲進入會員系統請輸入\"3\"，欲進入庫存系統請輸入\"2\"，欲進入財務系統請輸入\"1\"，系統設定請輸入\"0\":");
						system_repuest = Console.ReadLine();
						Console.Clear();
					}
					i--;
				}
				if (function == "2")
				{
					for (int j = 0; j < order_waiting_list.Length; j++)
					{
						Console.WriteLine(order_waiting_list[j]);
					}
					Console.Write("請輸入要出餐的訂單編號:");
					string serve_number_input = Console.ReadLine();
					int serve_number;
					while (!int.TryParse(serve_number_input, out serve_number) || serve_number > i - 1 || serve_number <= 0)
					{
						Console.Write("輸入錯誤，請重新輸入要出餐的訂單編號:");
						serve_number_input = Console.ReadLine();
					}
					//可加入確認環節
					order_waiting_list[serve_number] = "";
					//確認原物料使用
					string[] material_type;
					if (extra)
					{
						material_stock[serve_number] = material_extra[martial_No];
					}
					material_type = material_stock[serve_number].Split(".");
					for (int j = 0; j < material_type.Length - 1; ++j)
					{
						for (int k = 0; k < material_icecream.Length; k++)
						{
							if (material_icecream[k] == material_type[j])
							{
								num_unit_material_icecream[k] -= 1;
                                Revenue+=price_unit_material_icecream[k];
							}
						}
						for (int k = 0; k < material_fruits.Length; k++)
						{
							if (material_type[j] == material_fruits[k])
							{
								num_unit_material_fruits[k] -= 1;
                                Revenue+=price_unit_material_fruits[k];
							}
						}
						for (int k = 0; k < material_drinks.Length; k++)
						{
							if (material_type[j] == material_icecream[k])
							{
								num_unit_material_drinks[k] -= 1;
                                Revenue+=price_unit_material_drinks[k];
							}
						}
						for (int k = 0; k < material_main_meal.Length; k++)
						{
							if (material_type[j] == material_main_meal[k])
							{
								num_unit_material_main_meal[k] -= 1;
                                Revenue+=price_unit_material_main_meal[k];
							}
						}
						for (int k = 0; k < material_syrup.Length; k++)
						{
							if (material_type[j] == material_syrup[k])
							{
								num_unit_material_syrup[k] -= 1;
                                Revenue+=price_unit_material_syrup[k];
							}
						}
						for (int k = 0; k < material_main_meal_toppings.Length; k++)
						{
							if (material_type[j] == material_main_meal_toppings[k])
							{
								num_unit_material_main_meal_toppings[k] -= 1;
                                Revenue+=price_unit_material_main_meal_toppings[k];
							}
						}
						for (int k = 0; k < material_drinks_toppings.Length; k++)
						{
							if (material_type[j] == material_drinks_toppings[k])
							{
								num_unit_material_drinks_toppings[k] -= 1;
                                Revenue+=price_unit_material_drinks_toppings[k];
							}
						}
						if (material_type.Length == 3 && j == 1)
						{
							Console.WriteLine("num:" + int.Parse(material_type[j]));
							Console.WriteLine("umu:" + material_type[j - 1]);
							for (int k = 0; k < material_icecream.Length; k++)
							{
								if (material_type[j - 1] == material_icecream[k])
								{
									num_unit_material_icecream[k] -= int.Parse(material_type[j]) - 1;
                                    Revenue+=price_unit_material_icecream[j-1]*int.Parse(material_type[j])-price_unit_material_icecream[j-1];
								}
							}
							for (int k = 0; k < material_fruits.Length; k++)
							{
								if (material_type[j - 1] == material_fruits[k])
								{
									num_unit_material_fruits[k] -= int.Parse(material_type[j]) - 1;
                                    Revenue+=price_unit_material_fruits[j-1]*int.Parse(material_type[j])-price_unit_material_fruits[j-1];
								}
							}
							for (int k = 0; k < material_drinks.Length; k++)
							{
								if (material_type[j - 1] == material_drinks[k])
								{
									num_unit_material_drinks[k] -= int.Parse(material_type[j]) - 1;
                                    Revenue+=price_unit_material_drinks[j-1]*int.Parse(material_type[j])-price_unit_material_drinks[j-1];
								}
							}
							for (int k = 0; k < material_main_meal.Length; k++)
							{
								if (material_type[j - 1] == material_main_meal[k])
								{
									num_unit_material_main_meal[k] -= int.Parse(material_type[j]) - 1;
                                    Revenue+=price_unit_material_main_meal[j-1]*int.Parse(material_type[j])-price_unit_material_main_meal[j-1];
								}
							}
							for (int k = 0; k < material_syrup.Length; k++)
							{
								if (material_type[j - 1] == material_syrup[k])
								{
									num_unit_material_syrup[k] -= int.Parse(material_type[j]) - 1;
                                    Revenue+=price_unit_material_syrup[j-1]*int.Parse(material_type[j])-price_unit_material_syrup[j-1];
								}
							}
							for (int k = 0; k < material_main_meal_toppings.Length; k++)
							{
								if (material_type[j - 1] == material_main_meal_toppings[k])
								{
									num_unit_material_main_meal_toppings[k] -= int.Parse(material_type[j]) - 1;
                                    Revenue+=price_unit_material_main_meal_toppings[j-1]*int.Parse(material_type[j])-price_unit_material_main_meal_toppings[j-1];
								}
							}
							for (int k = 0; k < material_drinks_toppings.Length; k++)
							{
								if (material_type[j - 1] == material_drinks_toppings[k])
								{
									num_unit_material_drinks_toppings[k] -= int.Parse(material_type[j]) - 1;
                                    Revenue+=price_unit_material_drinks_toppings[j-1]*int.Parse(material_type[j])-price_unit_material_drinks_toppings[j-1];
								}
							}
						}
					}
					//補貨
					replenishment
						(material_icecream, price_unit_material_icecream, num_unit_material_icecream, expirationDate_unit_material_icecream, material_fruits, price_unit_material_fruits, num_unit_material_fruits, expirationDate_unit_material_fruits,
						 material_drinks, price_unit_material_drinks, num_unit_material_drinks, expirationDate_unit_material_drinks, material_main_meal, price_unit_material_main_meal, num_unit_material_main_meal, expirationDate_unit_material_main_meal,
						 material_syrup, price_unit_material_syrup, num_unit_material_syrup, expirationDate_unit_material_syrup, material_main_meal_toppings, price_unit_material_main_meal_toppings, num_unit_material_main_meal_toppings, expirationDate_unit_material_main_meal_toppings,
						 material_drinks_toppings, price_unit_material_drinks_toppings, num_unit_material_drinks_toppings, expirationDate_unit_material_drinks_toppings,
						 standby_num_unit_material_icecream, standby_expirationDate_unit_material_icecream, standby_num_unit_material_fruits, standby_expirationDate_unit_material_fruits,
						 standby_num_unit_material_drinks, standby_expirationDate_unit_material_drinks, standby_num_unit_material_main_meal, standby_expirationDate_unit_material_main_meal,
						 standby_num_unit_material_syrup, standby_expirationDate_unit_material_syrup, standby_num_unit_material_main_meal_toppings, standby_expirationDate_unit_material_main_meal_toppings,
						 standby_num_unit_material_drinks_toppings, standby_expirationDate_unit_material_drinks_toppings, intact_expirationDate_unit_material_icecream, intact_expirationDate_unit_material_fruits,
						 intact_expirationDate_unit_material_drinks, intact_expirationDate_unit_material_main_meal,
						 intact_expirationDate_unit_material_syrup, intact_expirationDate_unit_material_main_meal_toppings,
						 intact_expirationDate_unit_material_drinks_toppings, stock_lower_limit_material, ref food_cost);
					Console.ReadLine();
					i--;
					Console.Clear();
				}
				if (function == "3")
				{
					Print_the_menu
					(material_icecream, price_unit_material_icecream,
					 material_fruits, price_unit_material_fruits,
					 material_drinks, price_unit_material_drinks,
					 material_main_meal, price_unit_material_main_meal,
					 material_syrup, price_unit_material_syrup,
					 material_main_meal_toppings, price_unit_material_main_meal_toppings,
					 material_drinks_toppings, price_unit_material_drinks_toppings);
					i--;
					Console.Write("離開請按任意鍵:");
					Console.ReadKey();
					Console.Clear();
				}
				if (function == "4")
				{
					Take_then_checkout_an_member_exclusive_order
						(membership_member_exclusive_order, membership_member_exclusive_order_price,
						 membership_member_phone_number, membership_member_status, discount_of_each_member_status,
						 ref Revenue, membership_member_cumulaative_comsumption_amount, standard_of_member_status, ref i,
						 ref order_waiting_list, ref order_history_list, ref martial_No);
					extra = true;
				}
			}
		}
		static void Generate_the_menu//記得回來改成console.readline
									(out string[] material_icecream, out int[] price_unit_material_icecream,
									out int[] num_unit_material_icecream, out int[] expirationDate_unit_material_icecream,
									out string[] material_fruits, out int[] price_unit_material_fruits,
									out int[] num_unit_material_fruits, out int[] expirationDate_unit_material_fruits,
									out string[] material_drinks, out int[] price_unit_material_drinks,
									out int[] num_unit_material_drinks, out int[] expirationDate_unit_material_drinks,
									out string[] material_main_meal, out int[] price_unit_material_main_meal,
									out int[] num_unit_material_main_meal, out int[] expirationDate_unit_material_main_meal,
									out string[] material_syrup, out int[] price_unit_material_syrup,
									out int[] num_unit_material_syrup, out int[] expirationDate_unit_material_syrup,
									out string[] material_main_meal_toppings, out int[] price_unit_material_main_meal_toppings,
									out int[] num_unit_material_main_meal_toppings, out int[] expirationDate_unit_material_main_meal_toppings,
									out string[] material_drinks_toppings, out int[] price_unit_material_drinks_toppings,
									out int[] num_unit_material_drinks_toppings, out int[] expirationDate_unit_material_drinks_toppings,
									out int[] standby_num_unit_material_icecream, out int[] standby_expirationDate_unit_material_icecream, out int[] intact_expirationDate_unit_material_icecream,
									out int[] standby_num_unit_material_fruits, out int[] standby_expirationDate_unit_material_fruits, out int[] intact_expirationDate_unit_material_fruits,
									out int[] standby_num_unit_material_drinks, out int[] standby_expirationDate_unit_material_drinks, out int[] intact_expirationDate_unit_material_drinks,
									out int[] standby_num_unit_material_main_meal, out int[] standby_expirationDate_unit_material_main_meal, out int[] intact_expirationDate_unit_material_main_meal,
									out int[] standby_num_unit_material_syrup, out int[] standby_expirationDate_unit_material_syrup, out int[] intact_expirationDate_unit_material_syrup,
									out int[] standby_num_unit_material_main_meal_toppings, out int[] standby_expirationDate_unit_material_main_meal_toppings, out int[] intact_expirationDate_unit_material_main_meal_toppings,
									out int[] standby_num_unit_material_drinks_toppings, out int[] standby_expirationDate_unit_material_drinks_toppings, out int[] intact_expirationDate_unit_material_drinks_toppings,
									ref int food_cost)
		{
			/*冰淇淋*/
			Console.WriteLine("請輸入原料冰淇淋口味並以空格隔開(e.g.薄荷巧克力 香檳葡萄 海鹽花生):");
			material_icecream = Console.ReadLine().Split(" ");
			Console.WriteLine("請依序輸入上列各原料冰淇淋口味的庫存數量並以空格隔開(e.g.\"5 6 7\"):");
			num_unit_material_icecream = Array.ConvertAll<string, int>(Console.ReadLine().Split(" "), s => int.Parse(s));
			standby_num_unit_material_icecream = (int[])num_unit_material_icecream.Clone();
			Console.WriteLine("請依序輸入上列各原料冰淇淋口味的單球價格並以空格隔開(e.g.\"20 20 25\"):");
			price_unit_material_icecream = Array.ConvertAll<string, int>(Console.ReadLine().Split(" "), s => int.Parse(s));
			Console.WriteLine("請依序輸入上列各原料冰淇淋口味的可保存天數並以空格隔開(e.g.\"8 10 12\"):");
			expirationDate_unit_material_icecream = Array.ConvertAll<string, int>(Console.ReadLine().Split(" "), s => int.Parse(s));
			standby_expirationDate_unit_material_icecream = (int[])expirationDate_unit_material_icecream.Clone();
			intact_expirationDate_unit_material_icecream = (int[])expirationDate_unit_material_icecream.Clone();
			/*水果*/
			Console.WriteLine('\n' + "請輸入原料水果種類並以空格隔開(e.g.香蕉 葡萄 芒果):");
			material_fruits = Console.ReadLine().Split(" ");
			Console.WriteLine("請依序輸入上列各原料水果口味的庫存數量並以空格隔開(e.g.\"5 6 7\"):");
			num_unit_material_fruits = Array.ConvertAll<string, int>(Console.ReadLine().Split(" "), s => int.Parse(s));
			standby_num_unit_material_fruits = (int[])num_unit_material_fruits.Clone();
			Console.WriteLine("請依序輸入上列各原料水果種類的單份價格並以空格隔開(e.g.\"15 20 25\"):");
			price_unit_material_fruits = Array.ConvertAll(Console.ReadLine().Split(" "), s => int.Parse(s));
			Console.WriteLine("請依序輸入上列各原料水果口味的可保存天數並以空格隔開(e.g.\"8 10 12\"):");
			expirationDate_unit_material_fruits = Array.ConvertAll<string, int>(Console.ReadLine().Split(" "), s => int.Parse(s));
			standby_expirationDate_unit_material_fruits = (int[])expirationDate_unit_material_fruits.Clone();
			intact_expirationDate_unit_material_fruits = (int[])expirationDate_unit_material_fruits.Clone();
			/*飲料*/
			Console.WriteLine('\n' + "請輸入原料飲料種類並以空格隔開(e.g.可樂 多多 牛奶):");
			material_drinks = Console.ReadLine().Split(" ");
			Console.WriteLine("請依序輸入上列各原料飲料口味的庫存數量並以空格隔開(e.g.\"5 6 7\"):");
			num_unit_material_drinks = Array.ConvertAll<string, int>(Console.ReadLine().Split(" "), s => int.Parse(s));
			standby_num_unit_material_drinks = (int[])num_unit_material_drinks.Clone();
			Console.WriteLine("請依序輸入上列各原料飲料種類的單杯價格並以空格隔開(e.g.\"25 30 35\"):");
			price_unit_material_drinks = Array.ConvertAll(Console.ReadLine().Split(" "), s => int.Parse(s));
			Console.WriteLine("請依序輸入上列各原料飲料口味的可保存天數並以空格隔開(e.g.\"8 10 12\"):");
			expirationDate_unit_material_drinks = Array.ConvertAll<string, int>(Console.ReadLine().Split(" "), s => int.Parse(s));
			standby_expirationDate_unit_material_drinks = (int[])expirationDate_unit_material_drinks.Clone();
			intact_expirationDate_unit_material_drinks = (int[])expirationDate_unit_material_drinks.Clone();
			/*主餐*/
			Console.WriteLine('\n' + "請輸入原料主食種類並以空格隔開(e.g.格子鬆餅 美式煎餅 舒芙蕾):");
			material_main_meal = Console.ReadLine().Split(" ");
			Console.WriteLine("請依序輸入上列各原料主食口味的庫存數量並以空格隔開(e.g.\"5 6 7\"):");
			num_unit_material_main_meal = Array.ConvertAll<string, int>(Console.ReadLine().Split(" "), s => int.Parse(s));
			standby_num_unit_material_main_meal = (int[])num_unit_material_main_meal.Clone();
			Console.WriteLine("請依序輸入上列各原料主食種類的單份價格並以空格隔開(e.g.\"55 50 75\"):");
			price_unit_material_main_meal = Array.ConvertAll(Console.ReadLine().Split(" "), s => int.Parse(s));
			Console.WriteLine("請依序輸入上列各原料主食口味的可保存天數並以空格隔開(e.g.\"8 10 12\"):");
			expirationDate_unit_material_main_meal = Array.ConvertAll<string, int>(Console.ReadLine().Split(" "), s => int.Parse(s));
			standby_expirationDate_unit_material_main_meal = (int[])expirationDate_unit_material_main_meal.Clone();
			intact_expirationDate_unit_material_main_meal = (int[])expirationDate_unit_material_main_meal.Clone();
			/*糖漿*/
			Console.WriteLine('\n' + "請輸入糖漿口味並以空格隔開(e.g.蜂蜜 巧克力醬 卡士達醬):");
			material_syrup = Console.ReadLine().Split(" ");
			Console.WriteLine("請依序輸入上列各糖漿口味的庫存數量並以空格隔開(e.g.\"5 6 7\"):");
			num_unit_material_syrup = Array.ConvertAll<string, int>(Console.ReadLine().Split(" "), s => int.Parse(s));
			standby_num_unit_material_syrup = (int[])num_unit_material_syrup.Clone();
			Console.WriteLine("請依序輸入上列各糖漿口味的單份價格並以空格隔開(e.g.\"20 10 20\"):");
			price_unit_material_syrup = Array.ConvertAll(Console.ReadLine().Split(" "), s => int.Parse(s));
			Console.WriteLine("請依序輸入上列各糖漿口味的可保存天數並以空格隔開(e.g.\"8 10 12\"):");
			expirationDate_unit_material_syrup = Array.ConvertAll<string, int>(Console.ReadLine().Split(" "), s => int.Parse(s));
			standby_expirationDate_unit_material_syrup = (int[])expirationDate_unit_material_syrup.Clone();
			intact_expirationDate_unit_material_syrup = (int[])expirationDate_unit_material_syrup.Clone();
			/*主餐配料*/
			Console.WriteLine('\n' + "請輸入主食配料種類並以空格隔開(e.g.杏仁片 脆片 棉花糖):");
			material_main_meal_toppings = Console.ReadLine().Split(" ");
			Console.WriteLine("請依序輸入上列各主食配料種類的庫存數量並以空格隔開(e.g.\"5 6 7\"):");
			num_unit_material_main_meal_toppings = Array.ConvertAll<string, int>(Console.ReadLine().Split(" "), s => int.Parse(s));
			standby_num_unit_material_main_meal_toppings = (int[])num_unit_material_main_meal_toppings.Clone();
			Console.WriteLine("請依序輸入上列各主食配料種類的單份價格並以空格隔開(e.g.\"15 20 25\"):");
			price_unit_material_main_meal_toppings = Array.ConvertAll(Console.ReadLine().Split(" "), a => int.Parse(a));
			Console.WriteLine("請依序輸入上列各主食配料種類的可保存天數並以空格隔開(e.g.\"8 10 12\"):");
			expirationDate_unit_material_main_meal_toppings = Array.ConvertAll<string, int>(Console.ReadLine().Split(" "), s => int.Parse(s));
			standby_expirationDate_unit_material_main_meal_toppings = (int[])expirationDate_unit_material_main_meal_toppings.Clone();
			intact_expirationDate_unit_material_main_meal_toppings = (int[])expirationDate_unit_material_main_meal_toppings.Clone();
			/*飲料配料*/
			Console.WriteLine('\n' + "請輸入飲料配料種類並以空格隔開(e.g.珍珠 椰果 愛玉凍):");
			material_drinks_toppings = Console.ReadLine().Split(" ");
			Console.WriteLine("請依序輸入上列各飲料配料種類的庫存數量並以空格隔開(e.g.\"5 6 7\"):");
			num_unit_material_drinks_toppings = Array.ConvertAll<string, int>(Console.ReadLine().Split(" "), s => int.Parse(s));
			standby_num_unit_material_drinks_toppings = (int[])num_unit_material_drinks_toppings.Clone();
			Console.WriteLine("請依序輸入上列各飲料配料種類的單份價格並以空格隔開(e.g.\"5 5 10\"):");
			price_unit_material_drinks_toppings = Array.ConvertAll(Console.ReadLine().Split(" "), s => int.Parse(s));
			Console.WriteLine("請依序輸入上列各飲料配料種類的可保存天數並以空格隔開(e.g.\"8 10 12\"):");
			expirationDate_unit_material_drinks_toppings = Array.ConvertAll<string, int>(Console.ReadLine().Split(" "), s => int.Parse(s));
			standby_expirationDate_unit_material_drinks_toppings = (int[])expirationDate_unit_material_drinks_toppings.Clone();
			intact_expirationDate_unit_material_drinks_toppings = (int[])expirationDate_unit_material_drinks_toppings.Clone();
			Console.Clear();
			for (int i = 0; i < material_icecream.Length; i++)
			{
				food_cost += num_unit_material_icecream[i] * price_unit_material_icecream[i];
				standby_num_unit_material_icecream[i] = 0;
			}
			for (int i = 0; i < material_fruits.Length; i++)
			{
				food_cost += num_unit_material_fruits[i] * price_unit_material_fruits[i];
				standby_num_unit_material_fruits[i] = 0;
			}
			for (int i = 0; i < material_drinks.Length; i++)
			{
				food_cost += num_unit_material_drinks[i] * price_unit_material_drinks[i];
				standby_num_unit_material_drinks[i] = 0;
			}
			for (int i = 0; i < material_main_meal.Length; i++)
			{
				food_cost += num_unit_material_main_meal[i] * price_unit_material_main_meal[i];
				standby_num_unit_material_main_meal[i] = 0;
			}
			for (int i = 0; i < material_syrup.Length; i++)
			{
				food_cost += num_unit_material_syrup[i] * price_unit_material_syrup[i];
				standby_num_unit_material_syrup[i] = 0;
			}
			for (int i = 0; i < material_main_meal_toppings.Length; i++)
			{
				food_cost += num_unit_material_main_meal_toppings[i] * price_unit_material_main_meal_toppings[i];
				standby_num_unit_material_main_meal_toppings[i] = 0;
			}
			for (int i = 0; i < material_drinks_toppings.Length; i++)
			{
				food_cost += num_unit_material_drinks_toppings[i] * price_unit_material_drinks_toppings[i];
				standby_num_unit_material_drinks_toppings[i] = 0;
			}
			Console.Write("輸入完畢，請按任意鍵繼續:");
			Console.ReadKey();
		}
		static void Set_up_the_system//記得回來把password改成console.readline
			(out string name_of_the_store, out string password, out string name_of_the_administrator, out int staff_number)
		{
			Console.Write("歡迎光臨下午茶店營運系統，請先為您的店舖取個名字吧:");
			name_of_the_store = Console.ReadLine();
			Console.Clear();
			Console.Write("為建立{0}下午茶店營運系統，請輸入店主您的名字，您同時也是此系統的管理員:", name_of_the_store);
			name_of_the_administrator = Console.ReadLine();
			Console.Clear();
			Console.WriteLine("接著請為{0}下午茶店營運系統建立管理員密碼，", name_of_the_store);
			Console.WriteLine();
			Console.WriteLine("此密碼長度必須大於等於8且包含至少一個大寫字母、一個小寫字母、一個數字");
			Console.WriteLine();
			Console.Write("請輸入您的密碼:");
			password = Console.ReadLine();//記得回來把password改成console.readline
			bool password_is_qualified = Password_is_qualified(password);
			while (password_is_qualified == false)
			{
				Console.WriteLine('\n' + "此密碼長度必須大於等於8且包含至少一個大寫字母、一個小寫字母、一個數字");
				Console.Write("您剛才輸入的密碼不符規定，請重新輸入:");
				password = Console.ReadLine();
				password_is_qualified = Password_is_qualified(password);
			}
			//可再加入重新輸入密碼確認已記住
			Console.WriteLine('\n' + "密碼設定成功，請牢記此密碼。");
			Console.Write("請按任意鍵繼續:");
			Console.ReadKey();
			Console.Clear();
			//**增加設定員工人數的功能
			Console.Write("請輸入員工人數: ");
			staff_number = Convert.ToInt32(Console.ReadLine());
			/*for (int i = 3; i >= 1; i--)
			{
				for (int j = 1; j <= 100; j++)
				{
					Console.Write('\b');
				}
				Console.Write("再{0}秒後進入價目表設定...", i);
				Thread.Sleep(1000);
			}*/
			Console.Clear();
		}
		static bool Password_is_qualified(string password)
		{
			bool password_is_qualified = false;
			bool password_is_longer_than_8_characters = password.Length >= 8 ? true : false;
			bool password_include_upper_letters = false;
			bool password_include_lower_letters = false;
			bool password_include_numbers = false;
			for (int i = 0; i < password.Length && password_is_longer_than_8_characters; i++)
			{
				string c = password.Substring(i, 1);
				if (c == "A" || c == "B" || c == "C" || c == "D" || c == "E" || c == "F" || c == "G" || c == "H" || c == "I" || c == "J" || c == "K" || c == "L" || c == "M" || c == "N" || c == "O" || c == "P" || c == "Q" || c == "R" || c == "S" || c == "T" || c == "U" || c == "V" || c == "W" || c == "X" || c == "Y" || c == "Z")
				{
					password_include_upper_letters = true;
				}
				if (c == "a" || c == "b" || c == "c" || c == "d" || c == "e" || c == "f" || c == "g" || c == "h" || c == "i" || c == "j" || c == "k" || c == "l" || c == "m" || c == "n" || c == "o" || c == "p" || c == "q" || c == "r" || c == "s" || c == "t" || c == "u" || c == "v" || c == "w" || c == "x" || c == "y" || c == "z")
				{
					password_include_lower_letters = true;
				}
				if (c == "1" || c == "2" || c == "3" || c == "4" || c == "5" || c == "6" || c == "7" || c == "8" || c == "9" || c == "0")
				{
					password_include_numbers = true;
				}
				if (password_include_upper_letters && password_include_lower_letters && password_include_numbers)
				{
					break;
				}
			}
			if (password_include_upper_letters && password_include_lower_letters && password_include_numbers && password_is_longer_than_8_characters)
			{
				password_is_qualified = true;
			}
			else
			{
				password_is_qualified = false;
			}
			return password_is_qualified;
		}
		static void Take_a_new_combo_order
			(string[] material_icecream, int[] price_unit_material_icecream,
			 string[] material_fruits, int[] price_unit_material_fruits,
			 string[] material_drinks, int[] price_unit_material_drinks,
			 string[] material_main_meal, int[] price_unit_material_main_meal,
			 string[] material_syrup, int[] price_unit_material_syrup,
			 string[] material_main_meal_toppings, int[] price_unit_material_main_meal_toppings,
			 string[] material_drinks_toppings, int[] price_unit_material_drinks_toppings,
			 out string order_icecream, out int price_order_icecream,
			 out string order_fruits, out int price_order_fruits,
			 out string order_drinks, out int price_order_drinks,
			 out string order_main_meal, out int price_order_main_meal,
			 out string order_syrup, out int price_order_syrup,
			 out string order_main_meal_toppings, out int price_order_main_meal_toppings,
			 out string order_drinks_toppings, out int price_order_drinks_toppings)
		{
			Console.WriteLine("點購套餐，請依指示選擇品項點餐:" + '\n');
			/*主餐*/
			Console.WriteLine("請先選擇主餐，主餐有以下幾樣選擇:" + '\n');
			for (int i = 0; i < material_main_meal.Length; i++)
			{
				int j = i + 1;
				Console.WriteLine(j + ". " + material_main_meal[i] + " $" + price_unit_material_main_meal[i]);
			}
			Console.WriteLine();
			Console.Write("請輸入編號點餐(e.g.\"1\"): ");
			int k = int.Parse(Console.ReadLine()) - 1;
			order_main_meal = material_main_meal[k];
			price_order_main_meal = price_unit_material_main_meal[k];
			Console.Clear();
			/*水果*/
			Console.WriteLine("接著請選擇搭配的水果，水果有以下幾樣選擇:" + '\n');
			for (int i = 0; i < material_fruits.Length; i++)
			{
				int j = i + 1;
				Console.WriteLine(j + ". " + material_fruits[i] + " $" + price_unit_material_fruits[i]);
			}
			Console.WriteLine();
			Console.Write("請輸入編號點餐(e.g.\"1\"): ");
			k = int.Parse(Console.ReadLine()) - 1;
			order_fruits = material_fruits[k];
			price_order_fruits = price_unit_material_fruits[k];
			Console.Clear();
			/*冰淇淋*/
			Console.WriteLine("接著請選擇搭配的冰淇淋，冰淇淋有以下幾種口味:" + '\n');
			for (int i = 0; i < material_icecream.Length; i++)
			{
				int j = i + 1;
				Console.WriteLine(j + ". " + material_icecream[i] + " $" + price_unit_material_icecream[i]);
			}
			Console.WriteLine();
			Console.Write("請輸入編號點餐(e.g.\"1\"): ");
			k = int.Parse(Console.ReadLine()) - 1;
			order_icecream = material_icecream[k];
			price_order_icecream = price_unit_material_icecream[k];
			Console.Clear();
			/*糖漿*/
			Console.WriteLine("接著請選擇要淋上哪種糖漿，糖漿有以下幾種選擇:" + '\n');
			for (int i = 0; i < material_syrup.Length; i++)
			{
				int j = i + 1;
				Console.WriteLine(j + ". " + material_syrup[i] + " $" + price_unit_material_syrup[i]);
			}
			Console.WriteLine();
			Console.Write("請輸入編號點餐(e.g.\"1\"): ");
			k = int.Parse(Console.ReadLine()) - 1;
			order_syrup = material_syrup[k];
			price_order_syrup = price_unit_material_syrup[k];
			Console.Clear();
			/*主餐配料*/
			Console.WriteLine("想為主餐加點配料嗎，配料有以下幾種選擇:" + '\n');
			for (int i = 0; i < material_main_meal_toppings.Length; i++)
			{
				int j = i + 1;
				Console.WriteLine(j + ". " + material_main_meal_toppings[i] + " $" + price_unit_material_main_meal_toppings[i]);
			}
			Console.WriteLine();
			Console.Write("請輸入編號點餐(e.g.\"1\"): ");
			k = int.Parse(Console.ReadLine()) - 1;
			order_main_meal_toppings = material_main_meal_toppings[k];
			price_order_main_meal_toppings = price_unit_material_main_meal_toppings[k];
			Console.Clear();
			/*飲料*/
			Console.WriteLine("再來是飲料的部分，請挑選一樣飲品:" + '\n');
			for (int i = 0; i < material_drinks.Length; i++)
			{
				int j = i + 1;
				Console.WriteLine(j + ". " + material_drinks[i] + " $" + price_unit_material_drinks[i]);
			}
			Console.WriteLine();
			Console.Write("請輸入編號點餐(e.g.\"1\"): ");
			k = int.Parse(Console.ReadLine()) - 1;
			order_drinks = material_drinks[k];
			price_order_drinks = price_unit_material_drinks[k];
			Console.Clear();
			/*飲料配料*/
			Console.WriteLine("最後是飲料的配料，請選擇您喜愛的口感:" + '\n');
			for (int i = 0; i < material_drinks_toppings.Length; i++)
			{
				int j = i + 1;
				Console.WriteLine(j + ". " + material_drinks_toppings[i] + " $" + price_unit_material_drinks_toppings[i]);
			}
			Console.WriteLine();
			Console.Write("請輸入編號點餐(e.g.\"1\"): ");
			k = int.Parse(Console.ReadLine()) - 1;
			order_drinks_toppings = material_drinks_toppings[k];
			price_order_drinks_toppings = price_unit_material_drinks_toppings[k];
			Console.Clear();
		}

		static void Take_a_new_single_order
			(string[] material_icecream, int[] price_unit_material_icecream,
			 string[] material_fruits, int[] price_unit_material_fruits,
			 string[] material_drinks, int[] price_unit_material_drinks,
		 	 string[] material_main_meal, int[] price_unit_material_main_meal,
			 string[] material_syrup, int[] price_unit_material_syrup,
			 string[] material_main_meal_toppings, int[] price_unit_material_main_meal_toppings,
			 string[] material_drinks_toppings, int[] price_unit_material_drinks_toppings,
			 out string single_item, out int price_single_item, out int quantity_single_item,
			 ref string material_simple)
		{
			Console.WriteLine("以下為單點價目表，請依指示選擇品項點餐:" + '\n');
			Console.WriteLine("A. 冰淇淋" + '\n');
			for (int i = 0; i < material_icecream.Length; i++)
			{
				Console.Write("  " + (i + 1) + "." + material_icecream[i] + " $" + price_unit_material_icecream[i]);
			}
			Console.WriteLine(); Console.WriteLine(); Console.WriteLine();
			Console.WriteLine("B. 水果" + '\n');
			for (int i = 0; i < material_fruits.Length; i++)
			{
				Console.Write("  " + (i + 1) + "." + material_fruits[i] + " $" + price_unit_material_fruits[i]);
			}
			Console.WriteLine(); Console.WriteLine(); Console.WriteLine();
			Console.WriteLine("C. 主食" + '\n');
			for (int i = 0; i < material_main_meal.Length; i++)
			{
				Console.Write("  " + (i + 1) + "." + material_main_meal[i] + " $" + price_unit_material_main_meal[i]);
			}
			Console.WriteLine(); Console.WriteLine(); Console.WriteLine();
			Console.WriteLine("D. 飲料" + '\n');
			for (int i = 0; i < material_drinks.Length; i++)
			{
				Console.Write("  " + (i + 1) + "." + material_drinks[i] + " $" + price_unit_material_drinks[i]);
			}
			Console.WriteLine(); Console.WriteLine(); Console.WriteLine();
			Console.WriteLine("E. 主餐配料" + '\n');
			for (int i = 0; i < material_main_meal_toppings.Length; i++)
			{
				Console.Write("  " + (i + 1) + "." + material_main_meal_toppings[i] + " $" + price_unit_material_main_meal_toppings[i]);
			}
			Console.WriteLine(); Console.WriteLine(); Console.WriteLine();
			Console.WriteLine("F. 飲料加料" + '\n');
			for (int i = 0; i < material_drinks_toppings.Length; i++)
			{
				Console.Write("  " + (i + 1) + "." + material_drinks_toppings[i] + " $" + price_unit_material_drinks_toppings[i]);
			}
			Console.WriteLine(); Console.WriteLine(); Console.WriteLine();
			Console.WriteLine("G. 糖漿、淋醬" + '\n');
			for (int i = 0; i < material_syrup.Length; i++)
			{
				Console.Write("  " + (i + 1) + "." + material_syrup[i] + " $" + price_unit_material_syrup[i]);
			}
			Console.WriteLine(); Console.WriteLine(); Console.WriteLine();
			Console.WriteLine("請輸入品項代號點餐，請注意您一次只能點購一種品項。");
			Console.Write("請先輸入種類代號(e.g.\"A\"):");
			string single_item_category = Console.ReadLine();
			while (single_item_category != "A" && single_item_category != "B" && single_item_category != "C" && single_item_category != "D" && single_item_category != "E" && single_item_category != "F" && single_item_category != "G")
			{
				Console.Write("輸入錯誤，請重新輸入種類代號(e.g.\"A\"):");
				single_item_category = Console.ReadLine();
			}
			int j = 0;
			switch (single_item_category)
			{
				case "A":
					j = material_icecream.Length - 1; break;
				case "B":
					j = material_fruits.Length - 1; break;
				case "C":
					j = material_main_meal.Length - 1; break;
				case "D":
					j = material_drinks.Length - 1; break;
				case "E":
					j = material_main_meal_toppings.Length - 1; break;
				case "F":
					j = material_drinks_toppings.Length - 1; break;
				case "G":
					j = material_syrup.Length - 1; break;
			}
			Console.Write("請再輸入品項編號(e.g.\"1\"):");
			string single_item_codename = Console.ReadLine();
			int k;
			while (!int.TryParse(single_item_codename, out k) || k - 1 > j || k - 1 < 0)
			{
				Console.Write("輸入錯誤，請重新輸入{0}種類中的品項編號(e.g.\"1\"):", single_item_category);
				single_item_codename = Console.ReadLine();
			}
			switch (single_item_category)
			{
				case "A":
					material_simple = material_icecream[k - 1];
					single_item = material_icecream[k - 1] + "冰淇淋";
					price_single_item = price_unit_material_icecream[k - 1];
					break;
				case "B":
					material_simple = material_fruits[k - 1];
					single_item = material_fruits[k - 1];
					price_single_item = price_unit_material_fruits[k - 1];
					break;
				case "C":
					material_simple = material_main_meal[k - 1];
					single_item = material_main_meal[k - 1];
					price_single_item = price_unit_material_main_meal[k - 1];
					break;
				case "D":
					material_simple = material_drinks[k - 1];
					single_item = material_drinks[k - 1];
					price_single_item = price_unit_material_drinks[k - 1];
					break;
				case "E":
					material_simple = material_main_meal_toppings[k - 1];
					single_item = "主餐配料" + material_main_meal_toppings[k - 1];
					price_single_item = price_unit_material_main_meal_toppings[k - 1];
					break;
				case "F":
					material_simple = material_drinks_toppings[k - 1];
					single_item = "飲料配料" + material_drinks_toppings[k - 1];
					price_single_item = price_unit_material_drinks_toppings[k - 1];
					break;
				case "G":
					material_simple = material_syrup[k - 1];
					single_item = material_syrup[k - 1];
					price_single_item = price_unit_material_syrup[k - 1];
					break;
				default:
					single_item = "";
					price_single_item = 0;
					break;
			}
			Console.Write("最後請輸入數量(e.g.\"1\"):");
			string single_item_quantity_input = Console.ReadLine();
			while (!int.TryParse(single_item_quantity_input, out quantity_single_item) || quantity_single_item <= 0)
			{
				Console.Write("輸入錯誤，請重新輸入數量(e.g.\"1\"):", single_item_category);
				single_item_quantity_input = Console.ReadLine();
			}
		}
		static void Print_the_menu
			(string[] material_icecream, int[] price_unit_material_icecream,
			 string[] material_fruits, int[] price_unit_material_fruits,
			 string[] material_drinks, int[] price_unit_material_drinks,
			 string[] material_main_meal, int[] price_unit_material_main_meal,
			 string[] material_syrup, int[] price_unit_material_syrup,
			 string[] material_main_meal_toppings, int[] price_unit_material_main_meal_toppings,
			 string[] material_drinks_toppings, int[] price_unit_material_drinks_toppings)
		{
			Console.WriteLine("以下是我們的價目一覽表:" + '\n');
			/*主餐*/
			Console.WriteLine("請先選擇主餐，主餐有以下幾樣選擇:" + '\n');
			for (int i = 0; i < material_main_meal.Length; i++)
			{
				Console.WriteLine(material_main_meal[i] + " $" + price_unit_material_main_meal[i]);
			}
			Console.WriteLine('\n');
			/*水果*/
			Console.WriteLine("接著請選擇搭配的水果，水果有以下幾樣選擇:" + '\n');
			for (int i = 0; i < material_fruits.Length; i++)
			{
				Console.WriteLine(material_fruits[i] + " $" + price_unit_material_fruits[i]);
			}
			Console.WriteLine('\n');
			/*冰淇淋*/
			Console.WriteLine("接著請選擇搭配的冰淇淋，冰淇淋有以下幾種口味:" + '\n');
			for (int i = 0; i < material_icecream.Length; i++)
			{
				Console.WriteLine(material_icecream[i] + " $" + price_unit_material_icecream[i]);
			}
			Console.WriteLine('\n');
			/*糖漿*/
			Console.WriteLine("接著請選擇要淋上哪種糖漿，糖漿有以下幾種選擇:" + '\n');
			for (int i = 0; i < material_syrup.Length; i++)
			{
				Console.WriteLine(material_syrup[i] + " $" + price_unit_material_syrup[i]);
			}
			Console.WriteLine('\n');
			/*主餐配料*/
			Console.WriteLine("想為主餐加點配料嗎，配料有以下幾種選擇:" + '\n');
			for (int i = 0; i < material_main_meal_toppings.Length; i++)
			{
				Console.WriteLine(material_main_meal_toppings[i] + " $" + price_unit_material_main_meal_toppings[i]);
			}
			Console.WriteLine('\n');
			/*飲料*/
			Console.WriteLine("再來是飲料的部分，請挑選一樣飲品:" + '\n');
			for (int i = 0; i < material_drinks.Length; i++)
			{
				Console.WriteLine(material_drinks[i] + " $" + price_unit_material_drinks[i]);
			}
			Console.WriteLine('\n');
			/*飲料配料*/
			Console.WriteLine("最後是飲料的配料，請選擇您喜愛的口感:" + '\n');
			for (int i = 0; i < material_drinks_toppings.Length; i++)
			{
				Console.WriteLine(material_drinks_toppings[i] + " $" + price_unit_material_drinks_toppings[i]);
			}
			Console.WriteLine('\n');
		}
		static void Take_an_order
			(string name_of_the_store,
			 string[] material_icecream, int[] price_unit_material_icecream,
			 string[] material_fruits, int[] price_unit_material_fruits,
			 string[] material_drinks, int[] price_unit_material_drinks,
			 string[] material_main_meal, int[] price_unit_material_main_meal,
			 string[] material_syrup, int[] price_unit_material_syrup,
			 string[] material_main_meal_toppings, int[] price_unit_material_main_meal_toppings,
			 string[] material_drinks_toppings, int[] price_unit_material_drinks_toppings,
			 out int price_of_the_total_order, out string a_new_order, out string material, out int Revenue)
		{
			price_of_the_total_order = 0;
			Revenue = 0;
			Console.WriteLine("歡迎光臨{0}下午茶店!", name_of_the_store);
			int price_item = 0;
			a_new_order = "";
			material = "";
			int item_number;
			bool order_next_item = true;
			for (item_number = 1; order_next_item; item_number++)
			{
				Console.Write("想點套餐請輸入\"1\"，想單點請輸入\"2\": ");
				string order_category = Console.ReadLine();
				Console.Clear();
				if (order_category == "1")
				{
					Take_a_new_combo_order
						(material_icecream, price_unit_material_icecream,
						 material_fruits, price_unit_material_fruits,
						 material_drinks, price_unit_material_drinks,
						 material_main_meal, price_unit_material_main_meal,
						 material_syrup, price_unit_material_syrup,
						 material_main_meal_toppings, price_unit_material_main_meal_toppings,
						 material_drinks_toppings, price_unit_material_drinks_toppings,
						 out string order_icecream, out int price_order_icecream,
						 out string order_fruits, out int price_order_fruits,
						 out string order_drinks, out int price_order_drinks,
						 out string order_main_meal, out int price_order_main_meal,
						 out string order_syrup, out int price_order_syrup,
						 out string order_main_meal_toppings, out int price_order_main_meal_toppings,
						 out string order_drinks_toppings, out int price_order_drinks_toppings);
					price_item = price_order_icecream + price_order_fruits + price_order_drinks + price_order_main_meal + price_order_syrup + price_order_main_meal_toppings + price_order_drinks_toppings;
					price_of_the_total_order += price_item;
					material += order_icecream + "." + order_main_meal + "." + order_fruits + "." + order_main_meal_toppings + "." + order_syrup + "." + order_drinks + "." + order_drinks_toppings + ".";
					a_new_order += "品項" + item_number + ": " + order_icecream + "冰淇淋" + order_main_meal + "佐" + order_fruits + "加" + order_main_meal_toppings + "淋" + order_syrup + "，搭配飲料" + order_drinks + "加" + order_drinks_toppings + "     $" + price_item + '\n';
					Console.Clear();
					Console.WriteLine("您目前點購的餐點為:" + '\n');
					Console.WriteLine(a_new_order);
					Console.Write("點餐完畢請輸入\"1\"，繼續點餐請輸入\"0\": ");
					string c = Console.ReadLine();
					while (c != "1" && c != "0")
					{
						Console.Clear();
						Console.WriteLine("輸入錯誤，請重新輸入。");
						Console.Write("點餐完畢請輸入\"1\"，繼續點餐請輸入\"0\": ");
						c = Console.ReadLine();
					}
					order_next_item = c == "0" ? true : false;
					Console.Clear();
				}
				else if (order_category == "2")
				{
					string material_simple = "";
					Take_a_new_single_order
						(material_icecream, price_unit_material_icecream,
						  material_fruits, price_unit_material_fruits,
						  material_drinks, price_unit_material_drinks,
		 				  material_main_meal, price_unit_material_main_meal,
						  material_syrup, price_unit_material_syrup,
						  material_main_meal_toppings, price_unit_material_main_meal_toppings,
						  material_drinks_toppings, price_unit_material_drinks_toppings,
						  out string single_item, out int price_single_item, out int quantity_single_item, ref material_simple);
					price_of_the_total_order += price_single_item * quantity_single_item;
					material += material_simple + "." + quantity_single_item + ".";
					a_new_order += "品項" + item_number + ": " + single_item + "*" + quantity_single_item + "     $" + price_single_item * quantity_single_item + '\n';
					Console.Clear();
					Console.WriteLine("您目前點購的餐點為:" + '\n');
					Console.WriteLine(a_new_order);
					Console.Write("點餐完畢請輸入\"1\"，繼續點餐請輸入\"0\": ");
					string c = Console.ReadLine();
					while (c != "1" && c != "0")
					{
						Console.Clear();
						Console.WriteLine("輸入錯誤，請重新輸入。");
						Console.Write("點餐完畢請輸入\"1\"，繼續點餐請輸入\"0\": ");
						c = Console.ReadLine();
					}
					order_next_item = c == "0" ? true : false;
					Console.Clear();
				}
				else
				{
					Console.WriteLine("輸入錯誤，請重新輸入");
					item_number--;
				}
				if (order_next_item == false)
				{
					Console.Clear();
					Console.WriteLine();
				}
			}
		}
		static void Register_a_new_member
			(string name_of_the_store, ref string[] membership_member_name, ref string[] membership_member_phone_number,
			  ref string[] membership_member_status, ref int[] membership_member_cumulaative_comsumption_amount,
			  ref int[] membership_member_exclusive_order_price, ref string[] membership_member_exclusive_order)
		{
			Console.Clear();
			Console.WriteLine("歡迎加入{0}下午茶店會員，請依照以下步驟輸入資料，謝謝您。", name_of_the_store);
			Console.Write("請輸入您的姓名:");
			membership_member_name[membership_member_name.Length - 1] = Console.ReadLine();
			Array.Resize(ref membership_member_name, membership_member_name.Length + 1);
			Console.Write("請輸入您的手機號碼:");
			membership_member_phone_number[membership_member_phone_number.Length - 1] = Console.ReadLine();
			Array.Resize(ref membership_member_phone_number, membership_member_phone_number.Length + 1);
			membership_member_cumulaative_comsumption_amount[membership_member_cumulaative_comsumption_amount.Length - 1] = 0;
			Array.Resize(ref membership_member_cumulaative_comsumption_amount, membership_member_cumulaative_comsumption_amount.Length + 1);
			membership_member_status[membership_member_status.Length - 1] = "ordinary";
			Array.Resize(ref membership_member_status, membership_member_status.Length + 1);
			membership_member_exclusive_order_price[membership_member_exclusive_order_price.Length - 1] = 0;
			Array.Resize(ref membership_member_exclusive_order_price, membership_member_exclusive_order_price.Length + 1);
			Console.Clear();
			Console.WriteLine("以下為您的會員資料:"); Console.WriteLine();
			Console.WriteLine("您的姓名: {0}", membership_member_name[membership_member_name.Length - 2]); Console.WriteLine();
			Console.WriteLine("您的手機號碼: {0}", membership_member_phone_number[membership_member_phone_number.Length - 2]); Console.WriteLine();
			Console.WriteLine("您的會員等級: {0}", membership_member_status[membership_member_status.Length - 2]); Console.WriteLine();
			Console.WriteLine("您的累積消費金額: ${0}", membership_member_cumulaative_comsumption_amount[membership_member_cumulaative_comsumption_amount.Length - 2]); Console.WriteLine();
			Console.Write("請按任意鍵離開:");
			Console.ReadKey();
			Console.Clear();
		}
		static void Membership_arrangement
			(ref int i, string name_of_the_store, ref string[] membership_member_phone_number, ref string[] membership_member_name,
			 ref string[] membership_member_status, ref int[] membership_member_cumulaative_comsumption_amount,
			 ref int[] membership_member_exclusive_order_price, ref string[] membership_member_exclusive_order)
		{
			Console.Clear();
			Console.Write("查看會員紀錄請輸入\"1\"，加入會員請輸入\"0\"，離開請輸入\"2\":");
			string xxx = Console.ReadLine();
			while (xxx != "0" && xxx != "1" && xxx != "2")
			{
				Console.Clear();
				Console.WriteLine("輸入錯誤，請重新輸入。");
				Console.Write("查看會員紀錄請輸入\"1\"，加入會員請輸入\"0\"，離開請輸入\"2\"");
				xxx = Console.ReadLine();
			}
			Console.Clear();
			if (xxx == "1")
			{
				Console.Write("請輸入您的手機號碼: ");
				string xxx1 = Console.ReadLine();
				bool phone_number_exist = false;
				int g = 0;
				for (int o = 0; !phone_number_exist; o++)
				{
					if (o != 0)
					{
						Console.Clear();
						Console.Write("輸入錯誤或此會員不存在，請重新輸入您的手機號碼: ");
						xxx1 = Console.ReadLine();
					}
					for (g = 0; g < membership_member_phone_number.Length; g++)
					{
						if (membership_member_phone_number[g] == xxx1)
						{
							phone_number_exist = true;
							break;
						}
					}
				}
				Console.Clear();
				Console.WriteLine("以下為您的會員資料:"); Console.WriteLine();
				Console.WriteLine("您的姓名: {0}", membership_member_name[g]); Console.WriteLine();
				Console.WriteLine("您的手機號碼: {0}", membership_member_phone_number[g]); Console.WriteLine();
				Console.WriteLine("您的會員等級: {0}", membership_member_status[g]); Console.WriteLine();
				Console.WriteLine("您的累積消費金額: {0}", membership_member_cumulaative_comsumption_amount[g]); Console.WriteLine();
				Console.Write("查詢完畢請按任意鍵離開:");
				Console.ReadKey();
				Console.Clear();
			}
			if (xxx == "0")
			{
				Register_a_new_member
					(name_of_the_store, ref membership_member_name, ref membership_member_phone_number,
					 ref membership_member_status, ref membership_member_cumulaative_comsumption_amount,
					 ref membership_member_exclusive_order_price, ref membership_member_exclusive_order);
			}
			if (xxx == "2")
			{
				//離開
			}
			i--;
		}
		static void Checkout
			(ref int price_of_the_total_order, ref int Revenue, ref string a_new_order,
			  string name_of_the_store, ref string[] membership_member_name, ref string[] membership_member_phone_number,
			  ref string[] membership_member_status, ref int[] membership_member_cumulaative_comsumption_amount,
			  double[] discount_of_each_member_status, int[] standard_of_member_status,
			  ref int[] membership_member_exclusive_order_price, ref string[] membership_member_exclusive_order,
			  ref string[] material_extra, string material)
		{
			Console.Clear();
			Console.WriteLine("您的訂單如下:");
			Console.WriteLine(a_new_order);
			Console.WriteLine();
			Console.Write("有會員請輸入\"y\"，沒有會員請輸入\"n\": ");
			string xxx2 = Console.ReadLine();
			while (xxx2 != "y" && xxx2 != "n")
			{
				Console.Write("輸入錯誤，有會員請輸入\"y\"，沒有會員請輸入\"n\": ");
				xxx2 = Console.ReadLine();
			}
			string xxx3 = "";
			if (xxx2 == "n")
			{
				Console.Write("欲加入會員請輸入\"y\"，不加入會員請輸入\"n\": ");
				xxx3 = Console.ReadLine();
				while (xxx3 != "y" && xxx2 != "n")
				{
					Console.Write("欲加入會員請輸入\"y\"，不加入會員請輸入\"n\": ");
					xxx3 = Console.ReadLine();
				}
				if (xxx3 == "y")
				{
					Register_a_new_member
						(name_of_the_store, ref membership_member_name, ref membership_member_phone_number,
						 ref membership_member_status, ref membership_member_cumulaative_comsumption_amount,
						 ref membership_member_exclusive_order_price, ref membership_member_exclusive_order);
					Console.WriteLine("請您再次輸入手機號碼，以將此訂單套用會員資格。");
				}
				if (xxx3 == "n")
				{
					//繼續結帳
				}
			}
			if (xxx2 == "y" || xxx3 == "y")
			{
				Console.Write("請輸入您的手機號碼: ");
				string xxx4 = Console.ReadLine();
				bool phone_number_exist = false;
				int g = 0;
				for (int o = 0; !phone_number_exist; o++)
				{
					if (o != 0)
					{
						Console.Clear();
						Console.Write("輸入錯誤或此會員不存在，請重新輸入您的手機號碼: ");
						xxx4 = Console.ReadLine();
					}
					for (g = 0; g < membership_member_phone_number.Length; g++)
					{
						if (membership_member_phone_number[g] == xxx4)
						{
							phone_number_exist = true;
							break;
						}
					}
				}
				Console.Clear();
				Console.WriteLine("您的訂單原始總金額為$" + price_of_the_total_order);
				Console.WriteLine();
				int discount_level;
				discount_level = membership_member_status[g] == "bronze" ? 1 : 0;
				discount_level = membership_member_status[g] == "silver" && discount_level != 1 ? 2 : 0;
				discount_level = membership_member_status[g] == "gold" && discount_level != 1 && discount_level != 2 ? 3 : 0;
				int temp1 = price_of_the_total_order;
				price_of_the_total_order = (int)(price_of_the_total_order * discount_of_each_member_status[discount_level]);
				Console.WriteLine
					("您的會員等級為{0}，可獲得總價*{1}的折扣，因此您的最終訂單金額為${2}",
					 membership_member_status[g], discount_of_each_member_status[discount_level], price_of_the_total_order);
				Console.WriteLine();
				Console.Write("請輸入您要付費的金額:");
				//找零
				int payment = Convert.ToInt32(Console.ReadLine());  //payment為付款金額
				int change = payment - Convert.ToInt16(price_of_the_total_order);  //change為找零
				while (payment - price_of_the_total_order < 0)
				{
					Console.WriteLine("金額不足");
					Console.Write("請輸入付款金額:");
					payment = Convert.ToInt32(Console.ReadLine());
					change = payment - Convert.ToInt16(price_of_the_total_order);
				}
				Console.WriteLine("應找" + change + "元");
				int a1000 = change / 1000;  //a1000為1000元的張數
				int a500 = change % 1000 / 500;  //a500為500元的張數
				int a100 = change % 1000 % 500 / 100;  //a100為100的張數
				int a50 = change % 1000 % 500 % 100 / 50;  //a50為50的個數
				int a10 = change % 1000 % 500 % 100 % 50 / 10;  //a10為10的個數
				int a5 = change % 1000 % 500 % 100 % 50 % 10 / 5; //a5為5的個數
				int a1 = change % 1000 % 500 % 100 % 50 % 10 % 5;  //a1為1的個數
				if (a1000 > 0)
				{
					Console.WriteLine("1000元紙鈔" + a1000 + "張");
				}
				if (a500 > 0)
				{
					Console.WriteLine("500元紙鈔" + a500 + "張");
				}
				if (a100 > 0)
				{
					Console.WriteLine("100元紙鈔" + a100 + "張");
				}
				if (a50 > 0)
				{
					Console.WriteLine("50元硬幣" + a50 + "枚");
				}
				if (a10 > 0)
				{
					Console.WriteLine("10元硬幣" + a10 + "枚");
				}
				if (a5 > 0)
				{
					Console.WriteLine("5元硬幣" + a5 + "枚");
				}
				if (a1 > 0)
				{
					Console.WriteLine("1元硬幣" + a1 + "枚");
				}
				Revenue += price_of_the_total_order;
				membership_member_cumulaative_comsumption_amount[g] += price_of_the_total_order;
				membership_member_status[g] = membership_member_cumulaative_comsumption_amount[g] >= standard_of_member_status[3] ? "gold" : "silver";
				membership_member_status[g] = membership_member_cumulaative_comsumption_amount[g] >= standard_of_member_status[2] ? "silver" : "bronze";
				membership_member_status[g] = membership_member_cumulaative_comsumption_amount[g] >= standard_of_member_status[1] ? "bronze" : "original";
				Console.WriteLine("您要將此訂單列入常購清單中嗎?");
				Console.Write("要列入常購清單請輸入\"y\"，不列入清單請輸入\"n\": ");
				string xxx5 = Console.ReadLine();
				while (xxx5 != "y" && xxx5 != "n")
				{
					Console.WriteLine("輸入錯誤，請重新輸入。");
					Console.Write("要列入常購清單請輸入\"y\"，不列入清單請輸入\"n\": ");
					xxx5 = Console.ReadLine();
				}
				if (xxx5 == "y")
				{
					material_extra[g] = material;
					membership_member_exclusive_order[g] = a_new_order;
					membership_member_exclusive_order_price[g] = temp1;
					Console.WriteLine("已成功加入常購清單，若您下次點餐時於主畫面點選\"會員快速點餐\"，可以直接訂購同樣的餐點組合。");
				}
				Console.WriteLine("點餐完畢，請按任意鍵離開");
				Console.ReadKey();
				Console.Clear();
			}
		}
		static void Take_then_checkout_an_member_exclusive_order
			(string[] membership_member_exclusive_order, int[] membership_member_exclusive_order_price,
			 string[] membership_member_phone_number, string[] membership_member_status, double[] discount_of_each_member_status,
			 ref int Revenue, int[] membership_member_cumulaative_comsumption_amount, int[] standard_of_member_status, ref int i,
			 ref string[] order_waiting_list, ref string[] order_history_list, ref int martial_No)
		{
			Console.Write("請輸入您的手機號碼: ");
			string xxx6 = Console.ReadLine();
			bool phone_number_exist = false;
			int g = 0;
			for (int o = 0; !phone_number_exist; o++)
			{
				if (o != 0)
				{
					Console.Clear();
					Console.Write("輸入錯誤或此會員不存在，請輸入\"0\"離開，或重新輸入您的手機號碼: ");
					xxx6 = Console.ReadLine();
				}
				for (g = 0; g < membership_member_phone_number.Length; g++)
				{
					if (membership_member_phone_number[g] == xxx6)
					{
						phone_number_exist = true;
						break;
					}
				}
				if (xxx6 == "0")
				{
					break;
				}
			}
			Console.Clear();
			if (xxx6 != "0" && membership_member_exclusive_order[g] == "")
			{
				Console.Write("您尚未儲存常購訂單，請記得於下次結帳時儲存，請按任意鍵離開:");
				Console.ReadKey();
				i--;
			}
			else if (xxx6 == "0")
			{
				i--;
			}
			else
			{
				Console.WriteLine("您儲存的常購訂單如下:");
				Console.WriteLine(membership_member_exclusive_order[g]);
				martial_No = g;
				Console.WriteLine("您的訂單原始總金額為$" + membership_member_exclusive_order_price[g]);
				Console.WriteLine();
				int discount_level;
				discount_level = membership_member_status[g] == "bronze" ? 1 : 0;
				discount_level = membership_member_status[g] == "silver" && discount_level != 1 ? 2 : 0;
				discount_level = membership_member_status[g] == "gold" && discount_level != 1 && discount_level != 2 ? 3 : 0;
				int price_of_the_total_order = (int)(membership_member_exclusive_order_price[g] * discount_of_each_member_status[discount_level]);
				Console.WriteLine
					("您的會員等級為{0}，可獲得總價*{1}的折扣，因此您的最終訂單金額為${2}",
					 membership_member_status[g], discount_of_each_member_status[discount_level], price_of_the_total_order);
				Array.Resize(ref order_waiting_list, i + 1);
				order_waiting_list[i] = membership_member_exclusive_order[g];
				Array.Resize(ref order_history_list, i + 1);
				order_history_list[i] = membership_member_exclusive_order[g];
				order_waiting_list[i] = "訂單編號:00" + i + '\n' + '\n' + membership_member_exclusive_order[g] + '\n';
				order_history_list[i] = order_waiting_list[i];
				Console.WriteLine();
				Console.Write("請輸入您要付費的金額:");
				//找零
				int payment = Convert.ToInt32(Console.ReadLine());  //payment為付款金額
				int change = payment - Convert.ToInt16(price_of_the_total_order);  //change為找零
				while (payment - price_of_the_total_order < 0)
				{
					Console.WriteLine("金額不足");
					Console.Write("請輸入付款金額:");
					payment = Convert.ToInt32(Console.ReadLine());
					change = payment - Convert.ToInt16(price_of_the_total_order);
				}
				Console.WriteLine("應找" + change + "元");
				int a1000 = change / 1000;  //a1000為1000元的張數
				int a500 = change % 1000 / 500;  //a500為500元的張數
				int a100 = change % 1000 % 500 / 100;  //a100為100的張數
				int a50 = change % 1000 % 500 % 100 / 50;  //a50為50的個數
				int a10 = change % 1000 % 500 % 100 % 50 / 10;  //a10為10的個數
				int a5 = change % 1000 % 500 % 100 % 50 % 10 / 5; //a5為5的個數
				int a1 = change % 1000 % 500 % 100 % 50 % 10 % 5;  //a1為1的個數
				if (a1000 > 0)
				{
					Console.WriteLine("1000元紙鈔" + a1000 + "張");
				}
				if (a500 > 0)
				{
					Console.WriteLine("500元紙鈔" + a500 + "張");
				}
				if (a100 > 0)
				{
					Console.WriteLine("100元紙鈔" + a100 + "張");
				}
				if (a50 > 0)
				{
					Console.WriteLine("50元硬幣" + a50 + "枚");
				}
				if (a10 > 0)
				{
					Console.WriteLine("10元硬幣" + a10 + "枚");
				}
				if (a5 > 0)
				{
					Console.WriteLine("5元硬幣" + a5 + "枚");
				}
				if (a1 > 0)
				{
					Console.WriteLine("1元硬幣" + a1 + "枚");
				}
				Console.WriteLine("點餐完畢，請按任意鍵離開");
				Console.ReadKey();
				Console.Clear();
				Revenue += price_of_the_total_order;
				membership_member_cumulaative_comsumption_amount[g] += price_of_the_total_order;
				membership_member_status[g] = membership_member_cumulaative_comsumption_amount[g] >= standard_of_member_status[3] ? "gold" : "silver";
				membership_member_status[g] = membership_member_cumulaative_comsumption_amount[g] >= standard_of_member_status[2] ? "silver" : "bronze";
				membership_member_status[g] = membership_member_cumulaative_comsumption_amount[g] >= standard_of_member_status[1] ? "bronze" : "original";
			}
		}
		static void stock//庫存清單
			(string[] material_icecream, int[] price_unit_material_icecream,
			int[] num_unit_material_icecream, int[] expirationDate_unit_material_icecream,
			string[] material_fruits, int[] price_unit_material_fruits,
			int[] num_unit_material_fruits, int[] expirationDate_unit_material_fruits,
			string[] material_drinks, int[] price_unit_material_drinks,
			int[] num_unit_material_drinks, int[] expirationDate_unit_material_drinks,
			string[] material_main_meal, int[] price_unit_material_main_meal,
			int[] num_unit_material_main_meal, int[] expirationDate_unit_material_main_meal,
			string[] material_syrup, int[] price_unit_material_syrup,
			int[] num_unit_material_syrup, int[] expirationDate_unit_material_syrup,
			string[] material_main_meal_toppings, int[] price_unit_material_main_meal_toppings,
			int[] num_unit_material_main_meal_toppings, int[] expirationDate_unit_material_main_meal_toppings,
			string[] material_drinks_toppings, int[] price_unit_material_drinks_toppings,
			int[] num_unit_material_drinks_toppings, int[] expirationDate_unit_material_drinks_toppings,
			int stock_lower_limit_material, int[] standby_num_unit_material_icecream, int[] standby_expirationDate_unit_material_icecream,
			int[] standby_num_unit_material_fruits, int[] standby_expirationDate_unit_material_fruits,
			int[] standby_num_unit_material_drinks, int[] standby_expirationDate_unit_material_drinks,
			int[] standby_num_unit_material_main_meal, int[] standby_expirationDate_unit_material_main_meal,
			int[] standby_num_unit_material_syrup, int[] standby_expirationDate_unit_material_syrup,
			int[] standby_num_unit_material_main_meal_toppings, int[] standby_expirationDate_unit_material_main_meal_toppings,
			int[] standby_num_unit_material_drinks_toppings, int[] standby_expirationDate_unit_material_drinks_toppings)
		{
			Console.WriteLine("商品     單價     數量     保存期限");
			for (int i = 0; i < material_icecream.Length; i++)
			{
				Console.WriteLine("{0}         {1}        {2}       {3}", material_icecream[i], price_unit_material_icecream[i], num_unit_material_icecream[i], expirationDate_unit_material_icecream[i]);
				if (standby_num_unit_material_icecream[i] != 0) Console.WriteLine("{0}         {1}        {2}       {3}", material_icecream[i], price_unit_material_icecream[i], standby_num_unit_material_icecream[i], standby_expirationDate_unit_material_icecream[i]);
			}
			for (int i = 0; i < material_fruits.Length; i++)
			{
				Console.WriteLine("{0}         {1}        {2}       {3}", material_fruits[i], price_unit_material_fruits[i], num_unit_material_fruits[i], expirationDate_unit_material_fruits[i]);
				if (standby_num_unit_material_fruits[i] != 0) Console.WriteLine("{0}         {1}        {2}       {3}", material_fruits[i], price_unit_material_fruits[i], standby_num_unit_material_fruits[i], standby_expirationDate_unit_material_fruits[i]);
			}
			for (int i = 0; i < material_drinks.Length; i++)
			{
				Console.WriteLine("{0}         {1}        {2}       {3}", material_drinks[i], price_unit_material_drinks[i], num_unit_material_drinks[i], expirationDate_unit_material_drinks[i]);
				if (standby_num_unit_material_drinks[i] != 0) Console.WriteLine("{0}         {1}        {2}       {3}", material_drinks[i], price_unit_material_drinks[i], standby_num_unit_material_drinks[i], standby_expirationDate_unit_material_drinks[i]);
			}
			for (int i = 0; i < material_main_meal.Length; i++)
			{
				Console.WriteLine("{0}         {1}        {2}       {3}", material_main_meal[i], price_unit_material_main_meal[i], num_unit_material_main_meal[i], expirationDate_unit_material_main_meal[i]);
				if (standby_num_unit_material_main_meal[i] != 0) Console.WriteLine("{0}         {1}        {2}       {3}", material_main_meal[i], price_unit_material_main_meal[i], standby_num_unit_material_main_meal[i], standby_expirationDate_unit_material_main_meal[i]);
			}
			for (int i = 0; i < material_syrup.Length; i++)
			{
				Console.WriteLine("{0}         {1}        {2}       {3}", material_syrup[i], price_unit_material_syrup[i], num_unit_material_syrup[i], expirationDate_unit_material_syrup[i]);
				if (standby_num_unit_material_syrup[i] != 0) Console.WriteLine("{0}         {1}        {2}       {3}", material_syrup[i], price_unit_material_syrup[i], standby_num_unit_material_syrup[i], standby_expirationDate_unit_material_syrup[i]);
			}
			for (int i = 0; i < material_main_meal_toppings.Length; i++)
			{
				Console.WriteLine("{0}         {1}        {2}       {3}", material_main_meal_toppings[i], price_unit_material_main_meal_toppings[i], num_unit_material_main_meal_toppings[i], expirationDate_unit_material_main_meal_toppings[i]);
				if (standby_num_unit_material_main_meal_toppings[i] != 0) Console.WriteLine("{0}         {1}        {2}       {3}", material_main_meal_toppings[i], price_unit_material_main_meal_toppings[i], standby_num_unit_material_main_meal_toppings[i], standby_expirationDate_unit_material_main_meal_toppings[i]);
			}
			for (int i = 0; i < material_drinks_toppings.Length; i++)
			{
				Console.WriteLine("{0}         {1}        {2}       {3}", material_drinks_toppings[i], price_unit_material_drinks_toppings[i], num_unit_material_drinks_toppings[i], expirationDate_unit_material_drinks_toppings[i]);
				if (standby_num_unit_material_drinks_toppings[i] != 0) Console.WriteLine("{0}         {1}        {2}       {3}", material_drinks_toppings[i], price_unit_material_drinks_toppings[i], standby_num_unit_material_drinks_toppings[i], standby_expirationDate_unit_material_drinks_toppings[i]);
			}
		}
		static void replenishment //補貨
			(string[] material_icecream, int[] price_unit_material_icecream,
			int[] num_unit_material_icecream, int[] expirationDate_unit_material_icecream,
			string[] material_fruits, int[] price_unit_material_fruits,
			int[] num_unit_material_fruits, int[] expirationDate_unit_material_fruits,
			string[] material_drinks, int[] price_unit_material_drinks,
			int[] num_unit_material_drinks, int[] expirationDate_unit_material_drinks,
			string[] material_main_meal, int[] price_unit_material_main_meal,
			int[] num_unit_material_main_meal, int[] expirationDate_unit_material_main_meal,
			string[] material_syrup, int[] price_unit_material_syrup,
			int[] num_unit_material_syrup, int[] expirationDate_unit_material_syrup,
			string[] material_main_meal_toppings, int[] price_unit_material_main_meal_toppings,
			int[] num_unit_material_main_meal_toppings, int[] expirationDate_unit_material_main_meal_toppings,
			string[] material_drinks_toppings, int[] price_unit_material_drinks_toppings,
			int[] num_unit_material_drinks_toppings, int[] expirationDate_unit_material_drinks_toppings,
			int[] standby_num_unit_material_icecream, int[] standby_expirationDate_unit_material_icecream,
			int[] standby_num_unit_material_fruits, int[] standby_expirationDate_unit_material_fruits,
			int[] standby_num_unit_material_drinks, int[] standby_expirationDate_unit_material_drinks,
			int[] standby_num_unit_material_main_meal, int[] standby_expirationDate_unit_material_main_meal,
			int[] standby_num_unit_material_syrup, int[] standby_expirationDate_unit_material_syrup,
			int[] standby_num_unit_material_main_meal_toppings, int[] standby_expirationDate_unit_material_main_meal_toppings,
			int[] standby_num_unit_material_drinks_toppings, int[] standby_expirationDate_unit_material_drinks_toppings,
			int[] intact_expirationDate_unit_material_icecream, int[] intact_expirationDate_unit_material_fruits,
			int[] intact_expirationDate_unit_material_drinks, int[] intact_expirationDate_unit_material_main_meal,
			int[] intact_expirationDate_unit_material_syrup, int[] intact_expirationDate_unit_material_main_meal_toppings,
			int[] intact_expirationDate_unit_material_drinks_toppings, int stock_lower_limit_material, ref int food_cost)
		{
			for (int i = 0; i < material_icecream.Length; i++)
			{
				if (num_unit_material_icecream[i] < 1)
				{
					num_unit_material_icecream[i] += standby_num_unit_material_icecream[i];
					expirationDate_unit_material_icecream[i] = standby_expirationDate_unit_material_icecream[i];
					standby_num_unit_material_icecream[i] = 0;
				}
				while (standby_num_unit_material_icecream[i] + num_unit_material_icecream[i] < stock_lower_limit_material)
				{
					standby_num_unit_material_icecream[i] += stock_lower_limit_material;
					standby_expirationDate_unit_material_icecream[i] = intact_expirationDate_unit_material_icecream[i];
					food_cost += price_unit_material_icecream[i] * stock_lower_limit_material;
				}
			}
			for (int i = 0; i < material_fruits.Length; i++)
			{
				if (num_unit_material_fruits[i] < 1)
				{
					num_unit_material_fruits[i] += standby_num_unit_material_fruits[i];
					expirationDate_unit_material_fruits[i] = standby_expirationDate_unit_material_fruits[i];
					standby_num_unit_material_fruits[i] = 0;
				}
				while (standby_num_unit_material_fruits[i] + num_unit_material_fruits[i] < stock_lower_limit_material)
				{
					standby_num_unit_material_fruits[i] += stock_lower_limit_material;
					standby_expirationDate_unit_material_fruits[i] = intact_expirationDate_unit_material_fruits[i];
					food_cost += price_unit_material_fruits[i] * stock_lower_limit_material;
				}
			}
			for (int i = 0; i < material_drinks.Length; i++)
			{
				if (num_unit_material_drinks[i] < 1)
				{
					num_unit_material_drinks[i] += standby_num_unit_material_drinks[i];
					expirationDate_unit_material_drinks[i] = standby_expirationDate_unit_material_drinks[i];
					standby_num_unit_material_drinks[i] = 0;
				}
				while (standby_num_unit_material_drinks[i] + num_unit_material_drinks[i] < stock_lower_limit_material)
				{
					standby_num_unit_material_drinks[i] += stock_lower_limit_material;
					standby_expirationDate_unit_material_drinks[i] = intact_expirationDate_unit_material_drinks[i];
					food_cost += price_unit_material_drinks[i] * stock_lower_limit_material;
				}
			}
			for (int i = 0; i < material_main_meal.Length; i++)
			{
				if (num_unit_material_main_meal[i] < 1)
				{
					num_unit_material_main_meal[i] += standby_num_unit_material_main_meal[i];
					expirationDate_unit_material_main_meal[i] = standby_expirationDate_unit_material_main_meal[i];
					standby_num_unit_material_main_meal[i] = 0;
				}
				while (standby_num_unit_material_main_meal[i] + num_unit_material_main_meal[i] < stock_lower_limit_material)
				{
					standby_num_unit_material_main_meal[i] += stock_lower_limit_material;
					standby_expirationDate_unit_material_main_meal[i] = intact_expirationDate_unit_material_main_meal[i];
					food_cost += price_unit_material_main_meal[i] * stock_lower_limit_material;
				}
			}
			for (int i = 0; i < material_syrup.Length; i++)
			{
				if (num_unit_material_syrup[i] < 1)
				{
					num_unit_material_syrup[i] += standby_num_unit_material_syrup[i];
					expirationDate_unit_material_syrup[i] = standby_expirationDate_unit_material_syrup[i];
					standby_num_unit_material_syrup[i] = 0;
				}
				while (standby_num_unit_material_syrup[i] + num_unit_material_syrup[i] < stock_lower_limit_material)
				{
					standby_num_unit_material_syrup[i] += stock_lower_limit_material;
					standby_expirationDate_unit_material_syrup[i] = intact_expirationDate_unit_material_syrup[i];
					food_cost += price_unit_material_syrup[i] * stock_lower_limit_material;
				}
			}
			for (int i = 0; i < material_main_meal_toppings.Length; i++)
			{
				if (num_unit_material_main_meal_toppings[i] < 1)
				{
					num_unit_material_main_meal_toppings[i] += standby_num_unit_material_main_meal_toppings[i];
					expirationDate_unit_material_main_meal_toppings[i] = standby_expirationDate_unit_material_main_meal_toppings[i];
					standby_num_unit_material_main_meal_toppings[i] = 0;
				}
				while (standby_num_unit_material_main_meal_toppings[i] + num_unit_material_main_meal_toppings[i] < stock_lower_limit_material)
				{
					standby_num_unit_material_main_meal_toppings[i] += stock_lower_limit_material;
					standby_expirationDate_unit_material_main_meal_toppings[i] = intact_expirationDate_unit_material_main_meal_toppings[i];
					food_cost += price_unit_material_main_meal_toppings[i] * stock_lower_limit_material;
				}
			}
			for (int i = 0; i < material_drinks_toppings.Length; i++)
			{
				if (num_unit_material_drinks_toppings[i] < 1)
				{
					num_unit_material_drinks_toppings[i] += standby_num_unit_material_drinks_toppings[i];
					expirationDate_unit_material_drinks_toppings[i] = standby_expirationDate_unit_material_drinks_toppings[i];
					standby_num_unit_material_drinks_toppings[i] = 0;
				}
				while (standby_num_unit_material_drinks_toppings[i] + num_unit_material_drinks_toppings[i] < stock_lower_limit_material)
				{
					standby_num_unit_material_drinks_toppings[i] += stock_lower_limit_material;
					standby_expirationDate_unit_material_drinks_toppings[i] = intact_expirationDate_unit_material_drinks_toppings[i];
					food_cost += price_unit_material_drinks_toppings[i] * stock_lower_limit_material;
				}
			}
		}
		static void expirationDate//有效日期(時間運作不確定,還沒有呼叫方式)
			(string[] material_icecream, int[] price_unit_material_icecream,
			int[] num_unit_material_icecream, int[] expirationDate_unit_material_icecream,
			string[] material_fruits, int[] price_unit_material_fruits,
			int[] num_unit_material_fruits, int[] expirationDate_unit_material_fruits,
			string[] material_drinks, int[] price_unit_material_drinks,
			int[] num_unit_material_drinks, int[] expirationDate_unit_material_drinks,
			string[] material_main_meal, int[] price_unit_material_main_meal,
			int[] num_unit_material_main_meal, int[] expirationDate_unit_material_main_meal,
			string[] material_syrup, int[] price_unit_material_syrup,
			int[] num_unit_material_syrup, int[] expirationDate_unit_material_syrup,
			string[] material_main_meal_toppings, int[] price_unit_material_main_meal_toppings,
			int[] num_unit_material_main_meal_toppings, int[] expirationDate_unit_material_main_meal_toppings,
			string[] material_drinks_toppings, int[] price_unit_material_drinks_toppings,
			int[] num_unit_material_drinks_toppings, int[] expirationDate_unit_material_drinks_toppings,
			int[] standby_num_unit_material_icecream, int[] standby_expirationDate_unit_material_icecream,
			int[] standby_num_unit_material_fruits, int[] standby_expirationDate_unit_material_fruits,
			int[] standby_num_unit_material_drinks, int[] standby_expirationDate_unit_material_drinks,
			int[] standby_num_unit_material_main_meal, int[] standby_expirationDate_unit_material_main_meal,
			int[] standby_num_unit_material_syrup, int[] standby_expirationDate_unit_material_syrup,
			int[] standby_num_unit_material_main_meal_toppings, int[] standby_expirationDate_unit_material_main_meal_toppings,
			int[] standby_num_unit_material_drinks_toppings, int[] standby_expirationDate_unit_material_drinks_toppings,
			int[] intact_expirationDate_unit_material_icecream, int[] intact_expirationDate_unit_material_fruits,
			int[] intact_expirationDate_unit_material_drinks, int[] intact_expirationDate_unit_material_main_meal,
			int[] intact_expirationDate_unit_material_syrup, int[] intact_expirationDate_unit_material_main_meal_toppings,
			int[] intact_expirationDate_unit_material_drinks_toppings, int stock_lower_limit_material, ref int food_cost)
		{
			for (int i = 0; i < material_icecream.Length; i++)
			{
				expirationDate_unit_material_icecream[i] -= 1;
				if (expirationDate_unit_material_icecream[i] == 1)
				{
					Console.WriteLine("{0},數量:{1}將在一天內過期", material_icecream, num_unit_material_icecream);
				}
				if (expirationDate_unit_material_icecream[i] == 0)
				{
					Console.WriteLine("{0},數量:{1}已過期,全數清掉", material_icecream, num_unit_material_icecream);
					num_unit_material_icecream[i] = 0;
					if (standby_num_unit_material_icecream[i] == 0)
					{
						replenishment
							(material_icecream, price_unit_material_icecream, num_unit_material_icecream, expirationDate_unit_material_icecream, material_fruits, price_unit_material_fruits, num_unit_material_fruits, expirationDate_unit_material_fruits,
							 material_drinks, price_unit_material_drinks, num_unit_material_drinks, expirationDate_unit_material_drinks, material_main_meal, price_unit_material_main_meal, num_unit_material_main_meal, expirationDate_unit_material_main_meal,
							 material_syrup, price_unit_material_syrup, num_unit_material_syrup, expirationDate_unit_material_syrup, material_main_meal_toppings, price_unit_material_main_meal_toppings, num_unit_material_main_meal_toppings, expirationDate_unit_material_main_meal_toppings,
							 material_drinks_toppings, price_unit_material_drinks_toppings, num_unit_material_drinks_toppings, expirationDate_unit_material_drinks_toppings,
							 standby_num_unit_material_icecream, standby_expirationDate_unit_material_icecream, standby_num_unit_material_fruits, standby_expirationDate_unit_material_fruits,
							 standby_num_unit_material_drinks, standby_expirationDate_unit_material_drinks, standby_num_unit_material_main_meal, standby_expirationDate_unit_material_main_meal,
							 standby_num_unit_material_syrup, standby_expirationDate_unit_material_syrup, standby_num_unit_material_main_meal_toppings, standby_expirationDate_unit_material_main_meal_toppings,
							 standby_num_unit_material_drinks_toppings, standby_expirationDate_unit_material_drinks_toppings, intact_expirationDate_unit_material_icecream, intact_expirationDate_unit_material_fruits,
							 intact_expirationDate_unit_material_drinks, intact_expirationDate_unit_material_main_meal,
							 intact_expirationDate_unit_material_syrup, intact_expirationDate_unit_material_main_meal_toppings,
							 intact_expirationDate_unit_material_drinks_toppings, stock_lower_limit_material, ref food_cost);
					}
					num_unit_material_icecream[i] = standby_num_unit_material_icecream[i];
					expirationDate_unit_material_icecream[i] = standby_expirationDate_unit_material_icecream[i];
					standby_num_unit_material_icecream[i] = 0;
					standby_expirationDate_unit_material_icecream[i] = 0;
				}
			}
			for (int i = 0; i < material_fruits.Length; i++)
			{
				expirationDate_unit_material_fruits[i] -= 1;
				if (expirationDate_unit_material_fruits[i] == 1)
				{
					Console.WriteLine("{0},數量:{1}將在一天內過期", material_fruits, num_unit_material_fruits);
				}
				if (expirationDate_unit_material_fruits[i] == 0)
				{
					Console.WriteLine("{0},數量:{1}已過期,全數清掉", material_fruits, num_unit_material_fruits);
					num_unit_material_fruits[i] = 0;
					if (standby_num_unit_material_fruits[i] == 0)
					{
						replenishment
							(material_icecream, price_unit_material_icecream, num_unit_material_icecream, expirationDate_unit_material_icecream, material_fruits, price_unit_material_fruits, num_unit_material_fruits, expirationDate_unit_material_fruits,
							 material_drinks, price_unit_material_drinks, num_unit_material_drinks, expirationDate_unit_material_drinks, material_main_meal, price_unit_material_main_meal, num_unit_material_main_meal, expirationDate_unit_material_main_meal,
							 material_syrup, price_unit_material_syrup, num_unit_material_syrup, expirationDate_unit_material_syrup, material_main_meal_toppings, price_unit_material_main_meal_toppings, num_unit_material_main_meal_toppings, expirationDate_unit_material_main_meal_toppings,
							 material_drinks_toppings, price_unit_material_drinks_toppings, num_unit_material_drinks_toppings, expirationDate_unit_material_drinks_toppings,
							 standby_num_unit_material_icecream, standby_expirationDate_unit_material_icecream, standby_num_unit_material_fruits, standby_expirationDate_unit_material_fruits,
							 standby_num_unit_material_drinks, standby_expirationDate_unit_material_drinks, standby_num_unit_material_main_meal, standby_expirationDate_unit_material_main_meal,
							 standby_num_unit_material_syrup, standby_expirationDate_unit_material_syrup, standby_num_unit_material_main_meal_toppings, standby_expirationDate_unit_material_main_meal_toppings,
							 standby_num_unit_material_drinks_toppings, standby_expirationDate_unit_material_drinks_toppings, intact_expirationDate_unit_material_icecream, intact_expirationDate_unit_material_fruits,
							 intact_expirationDate_unit_material_drinks, intact_expirationDate_unit_material_main_meal,
							 intact_expirationDate_unit_material_syrup, intact_expirationDate_unit_material_main_meal_toppings,
							 intact_expirationDate_unit_material_drinks_toppings, stock_lower_limit_material, ref food_cost);
					}
					num_unit_material_fruits[i] = standby_num_unit_material_fruits[i];
					expirationDate_unit_material_fruits[i] = standby_expirationDate_unit_material_fruits[i];
					standby_num_unit_material_fruits[i] = 0;
					standby_expirationDate_unit_material_fruits[i] = 0;
				}
			}
			for (int i = 0; i < material_drinks.Length; i++)
			{
				expirationDate_unit_material_drinks[i] -= 1;
				if (expirationDate_unit_material_drinks[i] == 1)
				{
					Console.WriteLine("{0},數量:{1}將在一天內過期", material_drinks, num_unit_material_drinks);
				}
				if (expirationDate_unit_material_drinks[i] == 0)
				{
					Console.WriteLine("{0},數量:{1}已過期,全數清掉", material_drinks, num_unit_material_drinks);
					num_unit_material_drinks[i] = 0;
					if (standby_num_unit_material_drinks[i] == 0)
					{
						replenishment
							(material_icecream, price_unit_material_icecream, num_unit_material_icecream, expirationDate_unit_material_icecream, material_fruits, price_unit_material_fruits, num_unit_material_fruits, expirationDate_unit_material_fruits,
							  material_drinks, price_unit_material_drinks, num_unit_material_drinks, expirationDate_unit_material_drinks, material_main_meal, price_unit_material_main_meal, num_unit_material_main_meal, expirationDate_unit_material_main_meal,
							  material_syrup, price_unit_material_syrup, num_unit_material_syrup, expirationDate_unit_material_syrup, material_main_meal_toppings, price_unit_material_main_meal_toppings, num_unit_material_main_meal_toppings, expirationDate_unit_material_main_meal_toppings,
							  material_drinks_toppings, price_unit_material_drinks_toppings, num_unit_material_drinks_toppings, expirationDate_unit_material_drinks_toppings,
							  standby_num_unit_material_icecream, standby_expirationDate_unit_material_icecream, standby_num_unit_material_fruits, standby_expirationDate_unit_material_fruits,
							  standby_num_unit_material_drinks, standby_expirationDate_unit_material_drinks, standby_num_unit_material_main_meal, standby_expirationDate_unit_material_main_meal,
							  standby_num_unit_material_syrup, standby_expirationDate_unit_material_syrup, standby_num_unit_material_main_meal_toppings, standby_expirationDate_unit_material_main_meal_toppings,
							  standby_num_unit_material_drinks_toppings, standby_expirationDate_unit_material_drinks_toppings, intact_expirationDate_unit_material_icecream, intact_expirationDate_unit_material_fruits,
							  intact_expirationDate_unit_material_drinks, intact_expirationDate_unit_material_main_meal,
							  intact_expirationDate_unit_material_syrup, intact_expirationDate_unit_material_main_meal_toppings,
							  intact_expirationDate_unit_material_drinks_toppings, stock_lower_limit_material, ref food_cost);
					}
					num_unit_material_drinks[i] = standby_num_unit_material_drinks[i];
					expirationDate_unit_material_drinks[i] = standby_expirationDate_unit_material_drinks[i];
					standby_num_unit_material_drinks[i] = 0;
					standby_expirationDate_unit_material_drinks[i] = 0;
				}
			}
			for (int i = 0; i < material_main_meal.Length; i++)
			{
				expirationDate_unit_material_main_meal[i] -= 1;
				if (expirationDate_unit_material_main_meal[i] == 1)
				{
					Console.WriteLine("{0},數量:{1}將在一天內過期", material_main_meal, num_unit_material_main_meal);
				}
				if (expirationDate_unit_material_main_meal[i] == 0)
				{
					Console.WriteLine("{0},數量:{1}已過期,全數清掉", material_main_meal, num_unit_material_main_meal);
					num_unit_material_main_meal[i] = 0;
					if (standby_num_unit_material_main_meal[i] == 0)
					{
						replenishment
							(material_icecream, price_unit_material_icecream, num_unit_material_icecream, expirationDate_unit_material_icecream, material_fruits, price_unit_material_fruits, num_unit_material_fruits, expirationDate_unit_material_fruits,
							 material_drinks, price_unit_material_drinks, num_unit_material_drinks, expirationDate_unit_material_drinks, material_main_meal, price_unit_material_main_meal, num_unit_material_main_meal, expirationDate_unit_material_main_meal,
							 material_syrup, price_unit_material_syrup, num_unit_material_syrup, expirationDate_unit_material_syrup, material_main_meal_toppings, price_unit_material_main_meal_toppings, num_unit_material_main_meal_toppings, expirationDate_unit_material_main_meal_toppings,
							 material_drinks_toppings, price_unit_material_drinks_toppings, num_unit_material_drinks_toppings, expirationDate_unit_material_drinks_toppings,
							 standby_num_unit_material_icecream, standby_expirationDate_unit_material_icecream, standby_num_unit_material_fruits, standby_expirationDate_unit_material_fruits,
							 standby_num_unit_material_drinks, standby_expirationDate_unit_material_drinks, standby_num_unit_material_main_meal, standby_expirationDate_unit_material_main_meal,
							 standby_num_unit_material_syrup, standby_expirationDate_unit_material_syrup, standby_num_unit_material_main_meal_toppings, standby_expirationDate_unit_material_main_meal_toppings,
							 standby_num_unit_material_drinks_toppings, standby_expirationDate_unit_material_drinks_toppings, intact_expirationDate_unit_material_icecream, intact_expirationDate_unit_material_fruits,
							 intact_expirationDate_unit_material_drinks, intact_expirationDate_unit_material_main_meal,
							 intact_expirationDate_unit_material_syrup, intact_expirationDate_unit_material_main_meal_toppings,
							 intact_expirationDate_unit_material_drinks_toppings, stock_lower_limit_material, ref food_cost);
					}
					num_unit_material_main_meal[i] = standby_num_unit_material_main_meal[i];
					expirationDate_unit_material_main_meal[i] = standby_expirationDate_unit_material_main_meal[i];
					standby_num_unit_material_main_meal[i] = 0;
					standby_expirationDate_unit_material_main_meal[i] = 0;
				}
			}
			for (int i = 0; i < material_syrup.Length; i++)
			{
				expirationDate_unit_material_syrup[i] -= 1;
				if (expirationDate_unit_material_syrup[i] == 1)
				{
					Console.WriteLine("{0},數量:{1}將在一天內過期", material_syrup, num_unit_material_syrup);
				}
				if (expirationDate_unit_material_syrup[i] == 0)
				{
					Console.WriteLine("{0},數量:{1}已過期,全數清掉", material_syrup, num_unit_material_syrup);
					num_unit_material_syrup[i] = 0;
					if (standby_num_unit_material_syrup[i] == 0)
					{
						replenishment
							(material_icecream, price_unit_material_icecream, num_unit_material_icecream, expirationDate_unit_material_icecream, material_fruits, price_unit_material_fruits, num_unit_material_fruits, expirationDate_unit_material_fruits,
							 material_drinks, price_unit_material_drinks, num_unit_material_drinks, expirationDate_unit_material_drinks, material_main_meal, price_unit_material_main_meal, num_unit_material_main_meal, expirationDate_unit_material_main_meal,
							 material_syrup, price_unit_material_syrup, num_unit_material_syrup, expirationDate_unit_material_syrup, material_main_meal_toppings, price_unit_material_main_meal_toppings, num_unit_material_main_meal_toppings, expirationDate_unit_material_main_meal_toppings,
							 material_drinks_toppings, price_unit_material_drinks_toppings, num_unit_material_drinks_toppings, expirationDate_unit_material_drinks_toppings,
							 standby_num_unit_material_icecream, standby_expirationDate_unit_material_icecream, standby_num_unit_material_fruits, standby_expirationDate_unit_material_fruits,
							 standby_num_unit_material_drinks, standby_expirationDate_unit_material_drinks, standby_num_unit_material_main_meal, standby_expirationDate_unit_material_main_meal,
							 standby_num_unit_material_syrup, standby_expirationDate_unit_material_syrup, standby_num_unit_material_main_meal_toppings, standby_expirationDate_unit_material_main_meal_toppings,
							 standby_num_unit_material_drinks_toppings, standby_expirationDate_unit_material_drinks_toppings, intact_expirationDate_unit_material_icecream, intact_expirationDate_unit_material_fruits,
							 intact_expirationDate_unit_material_drinks, intact_expirationDate_unit_material_main_meal,
							 intact_expirationDate_unit_material_syrup, intact_expirationDate_unit_material_main_meal_toppings,
							 intact_expirationDate_unit_material_drinks_toppings, stock_lower_limit_material, ref food_cost);
					}
					num_unit_material_syrup[i] = standby_num_unit_material_syrup[i];
					expirationDate_unit_material_syrup[i] = standby_expirationDate_unit_material_syrup[i];
					standby_num_unit_material_syrup[i] = 0;
					standby_expirationDate_unit_material_syrup[i] = 0;
				}
			}
			for (int i = 0; i < material_main_meal_toppings.Length; i++)
			{
				expirationDate_unit_material_main_meal_toppings[i] -= 1;
				if (expirationDate_unit_material_main_meal_toppings[i] == 1)
				{
					Console.WriteLine("{0},數量:{1}將在一天內過期", material_main_meal_toppings, num_unit_material_main_meal_toppings);
				}
				if (expirationDate_unit_material_main_meal_toppings[i] == 0)
				{
					Console.WriteLine("{0},數量:{1}已過期,全數清掉", material_main_meal_toppings, num_unit_material_main_meal_toppings);
					num_unit_material_main_meal_toppings[i] = 0;
					if (standby_num_unit_material_main_meal_toppings[i] == 0)
					{
						replenishment
							(material_icecream, price_unit_material_icecream, num_unit_material_icecream, expirationDate_unit_material_icecream, material_fruits, price_unit_material_fruits, num_unit_material_fruits, expirationDate_unit_material_fruits,
							 material_drinks, price_unit_material_drinks, num_unit_material_drinks, expirationDate_unit_material_drinks, material_main_meal, price_unit_material_main_meal, num_unit_material_main_meal, expirationDate_unit_material_main_meal,
							 material_syrup, price_unit_material_syrup, num_unit_material_syrup, expirationDate_unit_material_syrup, material_main_meal_toppings, price_unit_material_main_meal_toppings, num_unit_material_main_meal_toppings, expirationDate_unit_material_main_meal_toppings,
							 material_drinks_toppings, price_unit_material_drinks_toppings, num_unit_material_drinks_toppings, expirationDate_unit_material_drinks_toppings,
							 standby_num_unit_material_icecream, standby_expirationDate_unit_material_icecream, standby_num_unit_material_fruits, standby_expirationDate_unit_material_fruits,
							 standby_num_unit_material_drinks, standby_expirationDate_unit_material_drinks, standby_num_unit_material_main_meal, standby_expirationDate_unit_material_main_meal,
							 standby_num_unit_material_syrup, standby_expirationDate_unit_material_syrup, standby_num_unit_material_main_meal_toppings, standby_expirationDate_unit_material_main_meal_toppings,
							 standby_num_unit_material_drinks_toppings, standby_expirationDate_unit_material_drinks_toppings, intact_expirationDate_unit_material_icecream, intact_expirationDate_unit_material_fruits,
							 intact_expirationDate_unit_material_drinks, intact_expirationDate_unit_material_main_meal,
							 intact_expirationDate_unit_material_syrup, intact_expirationDate_unit_material_main_meal_toppings,
							 intact_expirationDate_unit_material_drinks_toppings, stock_lower_limit_material, ref food_cost);
					}
					num_unit_material_main_meal_toppings[i] = standby_num_unit_material_main_meal_toppings[i];
					expirationDate_unit_material_main_meal_toppings[i] = standby_expirationDate_unit_material_main_meal_toppings[i];
					standby_num_unit_material_main_meal_toppings[i] = 0;
					standby_expirationDate_unit_material_main_meal_toppings[i] = 0;
				}
			}
			for (int i = 0; i < material_drinks_toppings.Length; i++)
			{
				expirationDate_unit_material_drinks_toppings[i] -= 1;
				if (expirationDate_unit_material_drinks_toppings[i] == 1)
				{
					Console.WriteLine("{0},數量:{1}將在一天內過期", material_drinks_toppings, num_unit_material_drinks_toppings);
				}
				if (expirationDate_unit_material_drinks_toppings[i] == 0)
				{
					Console.WriteLine("{0},數量:{1}已過期,全數清掉", material_drinks_toppings, num_unit_material_drinks_toppings);
					num_unit_material_drinks_toppings[i] = 0;
					if (standby_num_unit_material_drinks_toppings[i] == 0)
					{
						replenishment
							(material_icecream, price_unit_material_icecream, num_unit_material_icecream, expirationDate_unit_material_icecream, material_fruits, price_unit_material_fruits, num_unit_material_fruits, expirationDate_unit_material_fruits,
							 material_drinks, price_unit_material_drinks, num_unit_material_drinks, expirationDate_unit_material_drinks, material_main_meal, price_unit_material_main_meal, num_unit_material_main_meal, expirationDate_unit_material_main_meal,
							 material_syrup, price_unit_material_syrup, num_unit_material_syrup, expirationDate_unit_material_syrup, material_main_meal_toppings, price_unit_material_main_meal_toppings, num_unit_material_main_meal_toppings, expirationDate_unit_material_main_meal_toppings,
							 material_drinks_toppings, price_unit_material_drinks_toppings, num_unit_material_drinks_toppings, expirationDate_unit_material_drinks_toppings,
							 standby_num_unit_material_icecream, standby_expirationDate_unit_material_icecream, standby_num_unit_material_fruits, standby_expirationDate_unit_material_fruits,
							 standby_num_unit_material_drinks, standby_expirationDate_unit_material_drinks, standby_num_unit_material_main_meal, standby_expirationDate_unit_material_main_meal,
							 standby_num_unit_material_syrup, standby_expirationDate_unit_material_syrup, standby_num_unit_material_main_meal_toppings, standby_expirationDate_unit_material_main_meal_toppings,
							 standby_num_unit_material_drinks_toppings, standby_expirationDate_unit_material_drinks_toppings, intact_expirationDate_unit_material_icecream, intact_expirationDate_unit_material_fruits,
							 intact_expirationDate_unit_material_drinks, intact_expirationDate_unit_material_main_meal,
							 intact_expirationDate_unit_material_syrup, intact_expirationDate_unit_material_main_meal_toppings,
							 intact_expirationDate_unit_material_drinks_toppings, stock_lower_limit_material, ref food_cost);
					}
					num_unit_material_drinks_toppings[i] = standby_num_unit_material_drinks_toppings[i];
					expirationDate_unit_material_drinks_toppings[i] = standby_expirationDate_unit_material_drinks_toppings[i];
					standby_num_unit_material_drinks_toppings[i] = 0;
					standby_expirationDate_unit_material_drinks_toppings[i] = 0;
				}
			}
		}
		static void Financial_System(int Revenue, int all_cost, int staff_number, ref int food_cost)
		{
            bool finance=true;
            int electric_cost = 0; int water_cost = 0; int gas_cost = 0;
		TestLabel:
            while(finance){
                Console.Write("\n計算營業開銷請輸入\"1\"，查詢獲利請輸入\"0\": ");
    			string use_financial_system = Console.ReadLine();
	    		Console.Clear();
		    	

			//======================== 查詢獲利 =======================
			    if (use_financial_system == "0")
			    {
				    Console.WriteLine("總營收: {0}元", Revenue);
    				Console.WriteLine("總營業開銷: {0}元", all_cost);

	    			if (electric_cost == 0 || water_cost == 0 || gas_cost == 0 || food_cost==0)
		    		{
			    		Console.Write(" !!提醒!! ");
				    	if (electric_cost == 0) Console.Write("電費、");
					    if (water_cost == 0) Console.Write("水費、");
					    if (gas_cost == 0) Console.Write("瓦斯費");
                        if(food_cost==0) Console.Write("原料費");
    					Console.WriteLine("\t 尚未計算!");

	    				Console.Write("是否返回計算開銷 (y/n)?");
		    			string answer = Console.ReadLine();
			    		while (answer == "y")
				    	{
    						goto TestLabel;
	    				}
		    		}
			    	Console.WriteLine();

				    int profit = Revenue - all_cost;
	    			Console.WriteLine("總獲利: {0}元", profit);

		    		if (profit * 1 / 2 <= 24000 * staff_number)
			    	{
				    	Console.WriteLine("!!! *警示* !!!   本月獲利的1/2不足以付給薪資!");
					    Console.ReadLine();
    				}
                    finance=false;

				//============================================ 計算營業開銷 ========================================================
	    		}
		    	else if (use_financial_system == "1")
			    {

    				Console.Write("計算瓦斯費請輸入\"3\"，計算水費請輸入\"2\"，計算電費請輸入\"1\"，查詢原料成本請輸入\"0\": ");
	    			string operate_cost = Console.ReadLine();
		    		Console.Clear();

				//============================電費計算===============================
			    	if (operate_cost == "1")
				    {
					    Console.Write("請輸入用電度數: ");
    					double electric_amount = Convert.ToInt32(Console.ReadLine());

	    				double accumulate_price = 0;
		    			double[] price = new double[7];
			    		double[] stage = new double[7];
				    	stage[0] = 0;
					    stage[1] = 120; price[1] = 1.63;//120 度以下部分
    					stage[2] = 330; price[2] = 2.38;//121~330 度部分 
	    				stage[3] = 500; price[3] = 3.52;//331~500 度部分
		    			stage[4] = 700; price[4] = 4.80;//501~700 度部分 
			    		stage[5] = 1000; price[5] = 5.66;//701~1000 度部分
				    	stage[6] = electric_amount; ; price[6] = 6.41;//1001 度以上部分
					    double rest = electric_amount;
    					for (int i = 1; i < 7; i++)
	    				{
		    				if (electric_amount > stage[i])
			    			{
				    			accumulate_price += (stage[i] - stage[i - 1]) * price[i];
					    		rest -= stage[i] - stage[i - 1];
    						}
	    					else
		    				{
			    				accumulate_price += rest * price[i];
				    			break;
					    	}
					    }
    					electric_cost = Convert.ToInt32(Math.Ceiling(accumulate_price));
	    				Console.Write("電費價格:  {0}元", electric_cost);
		    			all_cost += electric_cost;

	    			}
				//==========================水費計算============================
		    		else if (operate_cost == "2")
			    	{
    					Console.Write("請輸入用水度數: ");
	    				double water_amount = Convert.ToInt32(Console.ReadLine());
		    			double[] price = new double[5];
			    		double[] stage = new double[5];
				    	double accumulate_price = 0;
					    stage[0] = 0;
    					stage[1] = 10; price[1] = 7.35;
	    				stage[2] = 30; price[2] = 9.45;
		    			stage[3] = 50; price[3] = 11.55;
			    		stage[4] = water_amount; price[4] = 12.075;
				    	double rest = water_amount;

					    for (int i = 1; i < 5; i++)
					    {
    						if (water_amount > stage[i])
	    					{
		    					accumulate_price += (stage[i] - stage[i - 1]) * price[i];
			    				rest -= stage[i] - stage[i - 1];
				    		}
					    	else
						    {
    							accumulate_price += rest * price[i];
	    						break;
		    				}
			    		}
				    	water_cost = Convert.ToInt32(Math.Ceiling(accumulate_price));
					    Console.Write("水費價格:  {0}元\n", water_cost);
    					all_cost += water_cost;
	    			}//===========================瓦斯費計算===============================
		    		else if (operate_cost == "3")
			    	{
				    	Console.Write("請輸入瓦斯度數: ");
					    double gas_amount = Convert.ToInt32(Console.ReadLine());

    					gas_cost = 60 + Convert.ToInt32(Math.Ceiling(gas_amount * 21.5));   // 基本費 60元  每度21.5元
	    				Console.Write("瓦斯費價格:  {0}元\n", gas_cost);
		    			all_cost += gas_cost;

			    	}
				    else if (operate_cost == "0")
				    {
    					Console.Write("本次原料價格:  {0}元\n", food_cost);
	    				all_cost += food_cost;
		    		}
			    	else
				    {

    					Console.Clear();
	    				Console.WriteLine("輸入錯誤，請重新輸入。");
		    			Console.Write("計算瓦斯費請輸入\"2\"，計算水費請輸入\"1\"，計算電費請輸入\"0\": ");
			    		operate_cost = Console.ReadLine();
				    }
			    }
    			else
	    		{
		    		Console.Clear();
			    	Console.WriteLine("輸入錯誤，請重新輸入。");
				    Console.Write("計算營業開銷請輸入\"1\"，查詢獲利請輸入\"0\": ");
    				use_financial_system = Console.ReadLine();
	    		}
            }
		}
    }
}