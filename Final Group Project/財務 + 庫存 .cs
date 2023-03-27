using System;
using System.Threading;



namespace homework_2
{
	class Program
	{
		static void Main(string[] args)
		{
			string[] order_waiting_list = new string[] { "" };
			string[] order_history_list = new string[] { "" };


		//設定補貨時機,stock_lower_limit_material:小於數量時補貨
            int stock_lower_limit_material=5;
			string[] material_stock = new string[10];
		//========================================================
			int staff_number;
			int Revenue =0;
			int all_cost =0;  //總開銷
		//========================================================

		Set_up_the_system(out string name_of_the_store, out string password, out string name_of_the_administrator, out staff_number);
			
			//增加庫存系統變數
		Generate_the_menu(
				out string[] material_icecream, out int[] price_unit_material_icecream,out int[] num_unit_material_icecream,out int[] expirationDate_unit_material_icecream,
				out string[] material_fruits, out int[] price_unit_material_fruits,out int[] num_unit_material_fruits,out int[] expirationDate_unit_material_fruits,
				out string[] material_drinks, out int[] price_unit_material_drinks,out int[] num_unit_material_drinks,out int[] expirationDate_unit_material_drinks,
				out string[] material_main_meal, out int[] price_unit_material_main_meal,out int[] num_unit_material_main_meal,out int[] expirationDate_unit_material_main_meal,
				out string[] material_syrup, out int[] price_unit_material_syrup,out int[] num_unit_material_syrup,out int[] expirationDate_unit_material_syrup,
				out string[] material_main_meal_toppings, out int[] price_unit_material_main_meal_toppings,out int[] num_unit_material_main_meal_toppings,out int[] expirationDate_unit_material_main_meal_toppings,
				out string[] material_drinks_toppings, out int[] price_unit_material_drinks_toppings,out int[] num_unit_material_drinks_toppings,out int[] expirationDate_unit_material_drinks_toppings,
                out int[] standby_num_unit_material_icecream,out int[] standby_expirationDate_unit_material_icecream,out int[] intact_expirationDate_unit_material_icecream,
                out int[] standby_num_unit_material_fruits,out int[] standby_expirationDate_unit_material_fruits,out int[] intact_expirationDate_unit_material_fruits,
                out int[] standby_num_unit_material_drinks,out int[] standby_expirationDate_unit_material_drinks,out int[] intact_expirationDate_unit_material_drinks,
                out int[] standby_num_unit_material_main_meal,out int[] standby_expirationDate_unit_material_main_meal,out int[] intact_expirationDate_unit_material_main_meal,
                out int[] standby_num_unit_material_syrup,out int[] standby_expirationDate_unit_material_syrup,out int[] intact_expirationDate_unit_material_syrup,
                out int[] standby_num_unit_material_main_meal_toppings,out int[] standby_expirationDate_unit_material_main_meal_toppings,out int[] intact_expirationDate_unit_material_main_meal_toppings,
                out int[] standby_num_unit_material_drinks_toppings,out int[] standby_expirationDate_unit_material_drinks_toppings,out int[] intact_expirationDate_unit_material_drinks_toppings);
			


			for (int i = 1; true; i++)
			{
				for (int j = 0; j < order_waiting_list.Length; j++)
				{
					Console.WriteLine(order_waiting_list[j]);
				}
				Console.Clear(); //是否要清除?
				Console.Write("顯示菜單請輸入\"3\"，出餐請輸入\"2\"，顧客點餐請輸入\"1\"，欲進入系統總管請輸入\"0\":");
				string function = Console.ReadLine();
				Console.Clear();
				while (function != "2" && function != "1" && function != "0" && function != "3")
				{
					Console.WriteLine("輸入錯誤，請重新輸入!");
					Console.Write("顯示菜單請輸入\"3\"，出餐請輸入\"2\"，顧客點餐請輸入\"1\"，欲進入系統總管請輸入\"0\":");
					function = Console.ReadLine();
					Console.Clear();
				}
				Console.Clear();

	//================================================= ***點餐系統*** =====================================================
				if (function == "1")
				{
					Array.Resize(ref order_waiting_list, i + 1);
					Array.Resize(ref order_history_list, i + 1);
					//增加庫存系統變數、Revneue
					Take_an_order(
						name_of_the_store,
						 material_icecream, price_unit_material_icecream,
						 material_fruits, price_unit_material_fruits,
						 material_drinks, price_unit_material_drinks,
						 material_main_meal, price_unit_material_main_meal,
						 material_syrup, price_unit_material_syrup,
						 material_main_meal_toppings, price_unit_material_main_meal_toppings,
						 material_drinks_toppings, price_unit_material_drinks_toppings,
						 out int price_of_the_total_order, out string a_new_order, out string material, out Revenue); 

					//取得點餐內容
					material_stock[i]=material;

					order_waiting_list[i] = "訂單編號:00"+i+'\n'+'\n' + a_new_order +'\n';
					order_history_list[i] = order_waiting_list[i];
				}
	//================================================ ***系統總管*** ======================================================
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
					if(system_repuest == "0"){
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
								Generate_the_menu(out material_icecream, out price_unit_material_icecream,out num_unit_material_icecream,out expirationDate_unit_material_icecream,out material_fruits, out price_unit_material_fruits,out num_unit_material_fruits,out expirationDate_unit_material_fruits,out material_drinks, out price_unit_material_drinks,out num_unit_material_drinks,out expirationDate_unit_material_drinks,out material_main_meal, out price_unit_material_main_meal,out num_unit_material_main_meal,out expirationDate_unit_material_main_meal,out material_syrup, out price_unit_material_syrup,out num_unit_material_syrup,out expirationDate_unit_material_syrup,out material_main_meal_toppings, out price_unit_material_main_meal_toppings,out num_unit_material_main_meal_toppings,out expirationDate_unit_material_main_meal_toppings,out material_drinks_toppings, out price_unit_material_drinks_toppings,out num_unit_material_drinks_toppings,out expirationDate_unit_material_drinks_toppings,
                            	out standby_num_unit_material_icecream,out standby_expirationDate_unit_material_icecream,out intact_expirationDate_unit_material_icecream,
                            	out standby_num_unit_material_fruits,out standby_expirationDate_unit_material_fruits,out intact_expirationDate_unit_material_fruits,
                            	out standby_num_unit_material_drinks,out standby_expirationDate_unit_material_drinks,out intact_expirationDate_unit_material_drinks,
                            	out standby_num_unit_material_main_meal,out standby_expirationDate_unit_material_main_meal,out intact_expirationDate_unit_material_main_meal,
                            	out standby_num_unit_material_syrup,out standby_expirationDate_unit_material_syrup,out intact_expirationDate_unit_material_syrup,
                            	out standby_num_unit_material_main_meal_toppings,out standby_expirationDate_unit_material_main_meal_toppings,out intact_expirationDate_unit_material_main_meal_toppings,
                            	out standby_num_unit_material_drinks_toppings,out standby_expirationDate_unit_material_drinks_toppings,out intact_expirationDate_unit_material_drinks_toppings);
								break;
							case "p":
								Console.WriteLine("功能更新中!");
								break;
						}
					}
					//============================*財務系統*===============================
					else if(system_repuest == "1"){
						
						Financial_System(Revenue, all_cost, staff_number);
					
					}
					//============================*庫存系統*===============================
					else if(system_repuest == "2"){
						
						stock (
						material_icecream, price_unit_material_icecream,num_unit_material_icecream,expirationDate_unit_material_icecream,
						material_fruits,price_unit_material_fruits,
             			num_unit_material_fruits,expirationDate_unit_material_fruits,
			 			material_drinks,price_unit_material_drinks,
             			num_unit_material_drinks,expirationDate_unit_material_drinks,
			 			material_main_meal,price_unit_material_main_meal,
             			num_unit_material_main_meal,expirationDate_unit_material_main_meal,
			 			material_syrup,price_unit_material_syrup,
             			num_unit_material_syrup,expirationDate_unit_material_syrup,
						material_main_meal_toppings,price_unit_material_main_meal_toppings,
             			num_unit_material_main_meal_toppings,expirationDate_unit_material_main_meal_toppings,
			 			material_drinks_toppings,price_unit_material_drinks_toppings,
             			num_unit_material_drinks_toppings,expirationDate_unit_material_drinks_toppings,
             			stock_lower_limit_material,standby_num_unit_material_icecream,standby_expirationDate_unit_material_icecream,
             			standby_num_unit_material_fruits,standby_expirationDate_unit_material_fruits,
             			standby_num_unit_material_drinks,standby_expirationDate_unit_material_drinks,
             			standby_num_unit_material_main_meal,standby_expirationDate_unit_material_main_meal,
             			standby_num_unit_material_syrup,standby_expirationDate_unit_material_syrup,
             			standby_num_unit_material_main_meal_toppings,standby_expirationDate_unit_material_main_meal_toppings,
             			standby_num_unit_material_drinks_toppings,standby_expirationDate_unit_material_drinks_toppings);

					}
					//===========================*會員系統*===============================
					else if(system_repuest == "3"){
						

					}
					else{
						Console.WriteLine("輸入錯誤，請重新輸入");
						Console.Write("欲進入會員系統請輸入\"3\"，欲進入庫存系統請輸入\"2\"，欲進入財務系統請輸入\"1\"，系統設定請輸入\"0\":");
						system_repuest = Console.ReadLine();
						Console.Clear();
					}
					

					i--;
				}

	//====================================================== ***出餐系統*** ======================================================
				if (function == "2")
				{

					for (int j = 0; j < order_waiting_list.Length; j++)
					{
						Console.WriteLine(order_waiting_list[j]);
					}
					Console.Write("請輸入要出餐的訂單編號:");
					string serve_number_input = Console.ReadLine();
					int serve_number;
					while (!int.TryParse(serve_number_input, out serve_number)||serve_number>i-1||serve_number<=0)
					{
						Console.Write("輸入錯誤，請重新輸入要出餐的訂單編號:");
						serve_number_input = Console.ReadLine();
					}
					//可加入確認環節
					order_waiting_list[serve_number] = "";


					//確認原物料使用
					string[] material_type;
                    material_type=material_stock[i].Split(" ");
                    for(int j=0; j<material_type.Length; j++){
						//判定是否為數字
						bool number=true;
                        for(int k = 0; i < material_icecream.Length; i++){
                            if(material_type[j]==material_icecream[k]){
                                num_unit_material_icecream[k]-=1;
								number=false;
                            }
                        }
                        for(int k = 0; i < material_fruits.Length; i++){
                            if(material_type[j]==material_fruits[k]){
                                num_unit_material_fruits[k]-=1;
								number=false;
                            }
                        }
                        for(int k = 0; i < material_drinks.Length; i++){
                            if(material_type[j]==material_icecream[k]){
                                num_unit_material_icecream[k]-=1;
								number=false;
                            }
                        }
                        for(int k = 0; i < material_main_meal.Length; i++){
                            if(material_type[j]==material_main_meal[k]){
                                num_unit_material_main_meal[k]-=1;
								number=false;
                            }
                        }
                        for(int k = 0; i < material_syrup.Length; i++){
                            if(material_type[j]==material_syrup[k]){
                                num_unit_material_syrup[k]-=1;
								number=false;
                            }
                        }
                        for(int k = 0; i < material_main_meal_toppings.Length; i++){
                            if(material_type[j]==material_main_meal_toppings[k]){
                                num_unit_material_main_meal_toppings[k]-=1;
								number=false;
                            }
                        }
                        for(int k = 0; i < material_drinks_toppings.Length; i++){
                            if(material_type[j]==material_drinks_toppings[k]){
                                num_unit_material_drinks_toppings[k]-=1;
								number=false;
                            }
                        }
						if(number){
							for(int k = 0; i < material_icecream.Length; i++){
                            	if(material_type[j-1]==material_icecream[k]){
                               	 	num_unit_material_icecream[k]-=int.Parse(material_type[j]);
                            	}
                        	}
                        	for(int k = 0; i < material_fruits.Length; i++){
                            	if(material_type[j-1]==material_fruits[k]){
    	                           	num_unit_material_fruits[k]-=int.Parse(material_type[j]);
            	                }
                	        }
                    	    for(int k = 0; i < material_drinks.Length; i++){
                        	    if(material_type[j-1]==material_icecream[k]){
                            	    num_unit_material_drinks[k]-=int.Parse(material_type[j]);
    	                        }
        	                }
            	            for(int k = 0; i < material_main_meal.Length; i++){
                	            if(material_type[j-1]==material_main_meal[k]){
                    	            num_unit_material_main_meal[k]-=int.Parse(material_type[j]);
                            	}
                        	}
	                        for(int k = 0; i < material_syrup.Length; i++){
    	                        if(material_type[j-1]==material_syrup[k]){
        	                        num_unit_material_syrup[k]-=int.Parse(material_type[j]);
                	            }
                    	    }
                        	for(int k = 0; i < material_main_meal_toppings.Length; i++){
                            	if(material_type[j-1]==material_main_meal_toppings[k]){
                                	num_unit_material_main_meal_toppings[k]-=int.Parse(material_type[j]);
    	                        }
        	                }
            	            for(int k = 0; i < material_drinks_toppings.Length; i++){
                	            if(material_type[j-1]==material_drinks_toppings[k]){
                    	            num_unit_material_drinks_toppings[k]-=int.Parse(material_type[j]);
                            	}
                        	}
						}
                    }

					//補貨
                    replenishment(
						material_icecream,price_unit_material_icecream,num_unit_material_icecream,expirationDate_unit_material_icecream,material_fruits,price_unit_material_fruits,num_unit_material_fruits,expirationDate_unit_material_fruits,
                        material_drinks,price_unit_material_drinks,num_unit_material_drinks,expirationDate_unit_material_drinks,material_main_meal,price_unit_material_main_meal,num_unit_material_main_meal,expirationDate_unit_material_main_meal,
			            material_syrup,price_unit_material_syrup,num_unit_material_syrup,expirationDate_unit_material_syrup,material_main_meal_toppings,price_unit_material_main_meal_toppings,num_unit_material_main_meal_toppings,expirationDate_unit_material_main_meal_toppings,
			            material_drinks_toppings,price_unit_material_drinks_toppings,num_unit_material_drinks_toppings,expirationDate_unit_material_drinks_toppings,
                        standby_num_unit_material_icecream,standby_expirationDate_unit_material_icecream,standby_num_unit_material_fruits,standby_expirationDate_unit_material_fruits,
                        standby_num_unit_material_drinks,standby_expirationDate_unit_material_drinks,standby_num_unit_material_main_meal,standby_expirationDate_unit_material_main_meal,
                        standby_num_unit_material_syrup,standby_expirationDate_unit_material_syrup,standby_num_unit_material_main_meal_toppings,standby_expirationDate_unit_material_main_meal_toppings,
                        standby_num_unit_material_drinks_toppings,standby_expirationDate_unit_material_drinks_toppings,intact_expirationDate_unit_material_icecream,intact_expirationDate_unit_material_fruits,
                        intact_expirationDate_unit_material_drinks,intact_expirationDate_unit_material_main_meal,
                        intact_expirationDate_unit_material_syrup,intact_expirationDate_unit_material_main_meal_toppings,
                        intact_expirationDate_unit_material_drinks_toppings,stock_lower_limit_material
                    );

					i--;
					Console.Clear();
				}
	//==================================================== ***顯示菜單*** ======================================================			
				if (function == "3")
				{
					Print_the_menu(
					material_icecream, price_unit_material_icecream,
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
			}
		}

//================================================================================================================================================= 
		
    	//================================================ 密碼設定 ====================================================
		static void Set_up_the_system(//記得回來把password改成console.readline
			out string name_of_the_store, out string password, out string name_of_the_administrator, out int staff_number)
		{
			Console.Write("歡迎光臨法式甜點店營運系統，請先為您的店舖取個名字吧:");
			name_of_the_store = Console.ReadLine();
			Console.Clear();
			Console.Write("為建立\"{0}\"甜點店營運系統，請輸入店主您的名字，您同時也是此系統的管理員:", name_of_the_store);
			name_of_the_administrator = Console.ReadLine();
			Console.Clear();
			Console.WriteLine("接著請為\"{0}\"甜點店營運系統建立管理員密碼，", name_of_the_store);
			Console.WriteLine();
			Console.WriteLine("此密碼長度必須大於等於8且包含至少一個大寫字母、一個小寫字母、一個數字");
			Console.WriteLine();
			Console.Write("請輸入您的密碼:");
			password = Console.ReadLine();//記得回來把password改成console.readline
			bool password_is_qualified = Password_is_qualified(password);
			while (password_is_qualified == false)
			{
				Console.WriteLine('\n'+"此密碼長度必須大於等於8且包含至少一個大寫字母、一個小寫字母、一個數字");
				Console.Write("您剛才輸入的密碼不符規定，請重新輸入:");
				password = Console.ReadLine();
				password_is_qualified = Password_is_qualified(password);
			}
			//可再加入重新輸入密碼確認已記住
			Console.WriteLine('\n'+"密碼設定成功，請牢記此密碼。");
			Console.WriteLine();

			//**增加設定員工人數的功能
			Console.Write("請輸入員工人數: ");
			staff_number = Convert.ToInt32(Console.ReadLine());


			for (int i = 3; i >= 1; i--)
			{
				for (int j = 1; j <= 100; j++)
				{
					Console.Write('\b');
				}
				Console.Write("再{0}秒後進入價目表設定...", i);
				Thread.Sleep(1000);
			}
			Console.Clear();
		}
		static bool Password_is_qualified(string password)
		{
			bool password_is_qualified = false;
			bool password_is_longer_than_8_characters = password.Length >= 8 ? true : false;
			bool password_include_upper_letters = false;
			bool password_include_lower_letters = false;
			bool password_include_numbers = false;
			for (int i = 0; i < password.Length&& password_is_longer_than_8_characters; i++)
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

	//=================================================== 建立菜單 ==================================================
		static void Generate_the_menu(    //記得回來改成console.readline
			out string[] material_icecream, out int[] price_unit_material_icecream,
            out int[] num_unit_material_icecream,out int[] expirationDate_unit_material_icecream,
			out string[] material_fruits, out int[] price_unit_material_fruits,
            out int[] num_unit_material_fruits,out int[] expirationDate_unit_material_fruits,
			out string[] material_drinks, out int[] price_unit_material_drinks,
            out int[] num_unit_material_drinks,out int[] expirationDate_unit_material_drinks,
			out string[] material_main_meal, out int[] price_unit_material_main_meal,
            out int[] num_unit_material_main_meal,out int[] expirationDate_unit_material_main_meal,
			out string[] material_syrup, out int[] price_unit_material_syrup,
            out int[] num_unit_material_syrup,out int[] expirationDate_unit_material_syrup,
			out string[] material_main_meal_toppings, out int[] price_unit_material_main_meal_toppings,
            out int[] num_unit_material_main_meal_toppings,out int[] expirationDate_unit_material_main_meal_toppings,
			out string[] material_drinks_toppings, out int[] price_unit_material_drinks_toppings,
            out int[] num_unit_material_drinks_toppings,out int[] expirationDate_unit_material_drinks_toppings,
            out int[] standby_num_unit_material_icecream,out int[] standby_expirationDate_unit_material_icecream,out int[] intact_expirationDate_unit_material_icecream,
            out int[] standby_num_unit_material_fruits,out int[] standby_expirationDate_unit_material_fruits,out int[] intact_expirationDate_unit_material_fruits,
            out int[] standby_num_unit_material_drinks,out int[] standby_expirationDate_unit_material_drinks,out int[] intact_expirationDate_unit_material_drinks,
            out int[] standby_num_unit_material_main_meal,out int[] standby_expirationDate_unit_material_main_meal,out int[] intact_expirationDate_unit_material_main_meal,
            out int[] standby_num_unit_material_syrup,out int[] standby_expirationDate_unit_material_syrup,out int[] intact_expirationDate_unit_material_syrup,
            out int[] standby_num_unit_material_main_meal_toppings,out int[] standby_expirationDate_unit_material_main_meal_toppings,out int[] intact_expirationDate_unit_material_main_meal_toppings,
            out int[] standby_num_unit_material_drinks_toppings,out int[] standby_expirationDate_unit_material_drinks_toppings,out int[] intact_expirationDate_unit_material_drinks_toppings
            )
		{
			//增加詢問庫存數量和有效期限及建立補貨清單

			/*冰淇淋*/
			Console.WriteLine("請輸入原料冰淇淋口味並以空格隔開(e.g.薄荷巧克力 香檳葡萄 海鹽花生):");
			material_icecream = Console.ReadLine().Split(" ");
            Console.WriteLine("請依序輸入上列各原料冰淇淋口味的庫存數量並以空格隔開(e.g.\"5 6 7\"):");
			num_unit_material_icecream = Array.ConvertAll<string, int>(Console.ReadLine().Split(" "), s => int.Parse(s)) ;
            standby_num_unit_material_icecream=num_unit_material_icecream;
			Console.WriteLine("請依序輸入上列各原料冰淇淋口味的單球價格並以空格隔開(e.g.\"20 20 25\"):");
			price_unit_material_icecream = Array.ConvertAll<string, int>(Console.ReadLine().Split(" "), s => int.Parse(s)) ;
            Console.WriteLine("請依序輸入上列各原料冰淇淋口味的有效期限並以空格隔開(e.g.\"8 10 12\"):");
			expirationDate_unit_material_icecream = Array.ConvertAll<string, int>(Console.ReadLine().Split(" "), s => int.Parse(s)) ;
            standby_expirationDate_unit_material_icecream=expirationDate_unit_material_icecream;
            intact_expirationDate_unit_material_icecream=expirationDate_unit_material_icecream;
			/*水果*/
			Console.WriteLine('\n'+"請輸入原料水果種類並以空格隔開(e.g.香蕉 葡萄 芒果):");
			material_fruits = Console.ReadLine().Split(" ");
            Console.WriteLine("請依序輸入上列各原料水果口味的庫存數量並以空格隔開(e.g.\"5 6 7\"):");
            num_unit_material_fruits = Array.ConvertAll<string, int>(Console.ReadLine().Split(" "), s => int.Parse(s)) ;
			standby_num_unit_material_fruits=num_unit_material_fruits;
            Console.WriteLine("請依序輸入上列各原料水果種類的單份價格並以空格隔開(e.g.\"15 20 25\"):");
			price_unit_material_fruits = Array.ConvertAll(Console.ReadLine().Split(" "), s => int.Parse(s));
            Console.WriteLine("請依序輸入上列各原料水果口味的有效期限並以空格隔開(e.g.\"8 10 12\"):");
            expirationDate_unit_material_fruits = Array.ConvertAll<string, int>(Console.ReadLine().Split(" "), s => int.Parse(s)) ;
			standby_expirationDate_unit_material_fruits=expirationDate_unit_material_fruits;
            intact_expirationDate_unit_material_fruits=expirationDate_unit_material_fruits;
            /*飲料*/
			Console.WriteLine('\n' + "請輸入原料飲料種類並以空格隔開(e.g.可樂 多多 牛奶):");
			material_drinks = Console.ReadLine().Split(" ");
            Console.WriteLine("請依序輸入上列各原料飲料口味的庫存數量並以空格隔開(e.g.\"5 6 7\"):");
            num_unit_material_drinks = Array.ConvertAll<string, int>(Console.ReadLine().Split(" "), s => int.Parse(s)) ;
			standby_num_unit_material_drinks=num_unit_material_drinks;
            Console.WriteLine("請依序輸入上列各原料飲料種類的單杯價格並以空格隔開(e.g.\"25 30 35\"):");
			price_unit_material_drinks = Array.ConvertAll(Console.ReadLine().Split(" "), s => int.Parse(s));
            Console.WriteLine("請依序輸入上列各原料飲料口味的有效期限並以空格隔開(e.g.\"8 10 12\"):");
            expirationDate_unit_material_drinks = Array.ConvertAll<string, int>(Console.ReadLine().Split(" "), s => int.Parse(s)) ;
			standby_expirationDate_unit_material_drinks=expirationDate_unit_material_drinks;
            intact_expirationDate_unit_material_drinks=expirationDate_unit_material_drinks;
            /*主餐*/
			Console.WriteLine('\n' + "請輸入原料主食種類並以空格隔開(e.g.格子鬆餅 美式煎餅 舒芙蕾):");
			material_main_meal = Console.ReadLine().Split(" ");
            Console.WriteLine("請依序輸入上列各原料主食口味的庫存數量並以空格隔開(e.g.\"5 6 7\"):");
            num_unit_material_main_meal = Array.ConvertAll<string, int>(Console.ReadLine().Split(" "), s => int.Parse(s)) ;
			standby_num_unit_material_main_meal=num_unit_material_main_meal;
            Console.WriteLine("請依序輸入上列各原料主食種類的單份價格並以空格隔開(e.g.\"55 50 75\"):");
			price_unit_material_main_meal = Array.ConvertAll(Console.ReadLine().Split(" "), s => int.Parse(s));
            Console.WriteLine("請依序輸入上列各原料主食口味的有效期限並以空格隔開(e.g.\"8 10 12\"):");
            expirationDate_unit_material_main_meal = Array.ConvertAll<string, int>(Console.ReadLine().Split(" "), s => int.Parse(s)) ;
			standby_expirationDate_unit_material_main_meal=expirationDate_unit_material_main_meal;
            intact_expirationDate_unit_material_main_meal=expirationDate_unit_material_main_meal;
            /*糖漿*/
			Console.WriteLine('\n' + "請輸入糖漿口味並以空格隔開(e.g.蜂蜜 巧克力醬 卡士達醬):");
			material_syrup = Console.ReadLine().Split(" ");
            Console.WriteLine("請依序輸入上列各糖漿口味的庫存數量並以空格隔開(e.g.\"5 6 7\"):");
            num_unit_material_syrup = Array.ConvertAll<string, int>(Console.ReadLine().Split(" "), s => int.Parse(s)) ;
			standby_num_unit_material_syrup=num_unit_material_syrup;
            Console.WriteLine("請依序輸入上列各糖漿口味的單份價格並以空格隔開(e.g.\"20 10 20\"):");
			price_unit_material_syrup = Array.ConvertAll(Console.ReadLine().Split(" "), s => int.Parse(s));
            Console.WriteLine("請依序輸入上列各糖漿口味的有效期限並以空格隔開(e.g.\"8 10 12\"):");
            expirationDate_unit_material_syrup = Array.ConvertAll<string, int>(Console.ReadLine().Split(" "), s => int.Parse(s)) ;
			standby_expirationDate_unit_material_syrup=expirationDate_unit_material_syrup;
            intact_expirationDate_unit_material_syrup=expirationDate_unit_material_syrup;
            /*主餐配料*/
			Console.WriteLine('\n' + "請輸入主食配料種類並以空格隔開(e.g.杏仁片 脆片 棉花糖):");
			material_main_meal_toppings = Console.ReadLine().Split(" ");
            Console.WriteLine("請依序輸入上列各主食配料種類的庫存數量並以空格隔開(e.g.\"5 6 7\"):");
            num_unit_material_main_meal_toppings = Array.ConvertAll<string, int>(Console.ReadLine().Split(" "), s => int.Parse(s)) ;
			standby_num_unit_material_main_meal_toppings=num_unit_material_main_meal_toppings;
            Console.WriteLine("請依序輸入上列各主食配料種類的單份價格並以空格隔開(e.g.\"15 20 25\"):");
			price_unit_material_main_meal_toppings = Array.ConvertAll(Console.ReadLine().Split(" "), a => int.Parse(a));
			Console.WriteLine("請依序輸入上列各主食配料種類的有效期限並以空格隔開(e.g.\"8 10 12\"):");
            expirationDate_unit_material_main_meal_toppings = Array.ConvertAll<string, int>(Console.ReadLine().Split(" "), s => int.Parse(s)) ;
            standby_expirationDate_unit_material_main_meal_toppings=expirationDate_unit_material_main_meal_toppings;
            intact_expirationDate_unit_material_main_meal_toppings=expirationDate_unit_material_main_meal_toppings;
            /*飲料配料*/
			Console.WriteLine('\n' + "請輸入飲料配料種類並以空格隔開(e.g.珍珠 椰果 愛玉凍):");
			material_drinks_toppings = Console.ReadLine().Split(" ");
            Console.WriteLine("請依序輸入上列各飲料配料種類的庫存數量並以空格隔開(e.g.\"5 6 7\"):");
            num_unit_material_drinks_toppings = Array.ConvertAll<string, int>(Console.ReadLine().Split(" "), s => int.Parse(s)) ;
			standby_num_unit_material_drinks_toppings=num_unit_material_drinks_toppings;
            Console.WriteLine("請依序輸入上列各飲料配料種類的單份價格並以空格隔開(e.g.\"5 5 10\"):");
			price_unit_material_drinks_toppings = Array.ConvertAll(Console.ReadLine().Split(" "), s => int.Parse(s));
            Console.WriteLine("請依序輸入上列各飲料配料種類的有效期限並以空格隔開(e.g.\"8 10 12\"):");
            expirationDate_unit_material_drinks_toppings = Array.ConvertAll<string, int>(Console.ReadLine().Split(" "), s => int.Parse(s)) ;
            standby_expirationDate_unit_material_drinks_toppings=expirationDate_unit_material_drinks_toppings;
            intact_expirationDate_unit_material_drinks_toppings=expirationDate_unit_material_drinks_toppings;
            for(int i = 0; i < material_icecream.Length; i++){
                standby_num_unit_material_icecream[i]=0;
            }
            for(int i = 0; i < material_fruits.Length; i++){
                standby_num_unit_material_fruits[i]=0;
            }
            for(int i = 0; i < material_drinks.Length; i++){
                standby_num_unit_material_drinks[i]=0;
            }
            for(int i = 0; i < material_main_meal.Length; i++){
                standby_num_unit_material_main_meal[i]=0;
            }
            for(int i = 0; i < material_syrup.Length; i++){
                standby_num_unit_material_syrup[i]=0;
            }
            for(int i = 0; i < material_main_meal_toppings.Length; i++){
                standby_num_unit_material_main_meal_toppings[i]=0;
            }
            for(int i = 0; i < material_drinks_toppings.Length; i++){
                standby_num_unit_material_drinks_toppings[i]=0;
            }
		}

	//=======================================================*庫存系統*==========================================================
		
		static void stock(   //庫存清單
            string[] material_icecream,int[] price_unit_material_icecream,
            int[] num_unit_material_icecream,int[] expirationDate_unit_material_icecream,
			string[] material_fruits,int[] price_unit_material_fruits,
            int[] num_unit_material_fruits,int[] expirationDate_unit_material_fruits,
			string[] material_drinks,int[] price_unit_material_drinks,
            int[] num_unit_material_drinks,int[] expirationDate_unit_material_drinks,
			string[] material_main_meal,int[] price_unit_material_main_meal,
            int[] num_unit_material_main_meal,int[] expirationDate_unit_material_main_meal,
			string[] material_syrup,int[] price_unit_material_syrup,
            int[] num_unit_material_syrup,int[] expirationDate_unit_material_syrup,
			string[] material_main_meal_toppings,int[] price_unit_material_main_meal_toppings,
            int[] num_unit_material_main_meal_toppings,int[] expirationDate_unit_material_main_meal_toppings,
			string[] material_drinks_toppings,int[] price_unit_material_drinks_toppings,
            int[] num_unit_material_drinks_toppings, int[] expirationDate_unit_material_drinks_toppings,
            int stock_lower_limit_material,int[] standby_num_unit_material_icecream,int[] standby_expirationDate_unit_material_icecream,
            int[] standby_num_unit_material_fruits,int[] standby_expirationDate_unit_material_fruits,
            int[] standby_num_unit_material_drinks,int[] standby_expirationDate_unit_material_drinks,
            int[] standby_num_unit_material_main_meal,int[] standby_expirationDate_unit_material_main_meal,
            int[] standby_num_unit_material_syrup,int[] standby_expirationDate_unit_material_syrup,
            int[] standby_num_unit_material_main_meal_toppings,int[] standby_expirationDate_unit_material_main_meal_toppings,
            int[] standby_num_unit_material_drinks_toppings,int[] standby_expirationDate_unit_material_drinks_toppings)
        {
            Console.WriteLine("商品        單價        數量        保存期限");
            for(int i = 0; i < material_icecream.Length; i++){
                Console.WriteLine("{0}      {1}        {2}       {3}",material_icecream[i],price_unit_material_icecream[i],num_unit_material_icecream[i],expirationDate_unit_material_icecream[i]);
                if(standby_num_unit_material_icecream[i]!=0)    Console.WriteLine("{0}      {1}        {2}       {3}",material_icecream[i],price_unit_material_icecream[i],standby_num_unit_material_icecream[i],standby_expirationDate_unit_material_icecream[i]);
            }
            for(int i = 0; i < material_fruits.Length; i++){
                Console.WriteLine("{0}      {1}        {2}       {3}",material_fruits[i],price_unit_material_fruits[i],num_unit_material_fruits[i],expirationDate_unit_material_fruits[i]);
                if(standby_num_unit_material_fruits[i]!=0)    Console.WriteLine("{0}      {1}        {2}       {3}",material_fruits[i],price_unit_material_fruits[i],standby_num_unit_material_fruits[i],standby_expirationDate_unit_material_fruits[i]);
            }
            for(int i = 0; i < material_drinks.Length; i++){
                Console.WriteLine("{0}      {1}        {2}       {3}",material_drinks[i],price_unit_material_drinks[i],num_unit_material_drinks[i],expirationDate_unit_material_drinks[i]);
                if(standby_num_unit_material_drinks[i]!=0)    Console.WriteLine("{0}      {1}        {2}       {3}",material_drinks[i],price_unit_material_drinks[i],standby_num_unit_material_drinks[i],standby_expirationDate_unit_material_drinks[i]);
            }
            for(int i = 0; i < material_main_meal.Length; i++){
                Console.WriteLine("{0}      {1}        {2}       {3}",material_main_meal[i],price_unit_material_main_meal[i],num_unit_material_main_meal[i],expirationDate_unit_material_main_meal[i]);
                if(standby_num_unit_material_main_meal[i]!=0)    Console.WriteLine("{0}      {1}        {2}       {3}",material_main_meal[i],price_unit_material_main_meal[i],standby_num_unit_material_main_meal[i],standby_expirationDate_unit_material_main_meal[i]);
            }
            for(int i = 0; i < material_syrup.Length; i++){
                Console.WriteLine("{0}      {1}        {2}       {3}",material_syrup[i],price_unit_material_syrup[i],num_unit_material_syrup[i],expirationDate_unit_material_syrup[i]);
                if(standby_num_unit_material_syrup[i]!=0)    Console.WriteLine("{0}      {1}        {2}       {3}",material_syrup[i],price_unit_material_syrup[i],standby_num_unit_material_syrup[i],standby_expirationDate_unit_material_syrup[i]);
            }
            for(int i = 0; i < material_main_meal_toppings.Length; i++){
                Console.WriteLine("{0}      {1}        {2}       {3}",material_main_meal_toppings[i],price_unit_material_main_meal_toppings[i],num_unit_material_main_meal_toppings,expirationDate_unit_material_main_meal_toppings[i]);
                if(standby_num_unit_material_main_meal_toppings[i]!=0)    Console.WriteLine("{0}      {1}        {2}       {3}",material_main_meal_toppings[i],price_unit_material_main_meal_toppings[i],standby_num_unit_material_main_meal_toppings[i],standby_expirationDate_unit_material_main_meal_toppings[i]);
            }
            for(int i = 0; i < material_drinks_toppings.Length; i++){
                Console.WriteLine("{0}      {1}        {2}       {3}",material_drinks_toppings[i],price_unit_material_drinks_toppings[i],num_unit_material_drinks_toppings[i],expirationDate_unit_material_drinks_toppings[i]);
                if(standby_num_unit_material_drinks_toppings[i]!=0)    Console.WriteLine("{0}      {1}        {2}       {3}",material_drinks_toppings[i],price_unit_material_drinks_toppings[i],standby_num_unit_material_drinks_toppings[i],standby_expirationDate_unit_material_drinks_toppings[i]);
            }
		}
		
		static void replenishment (  //補貨
            string[] material_icecream,int[] price_unit_material_icecream,
            int[] num_unit_material_icecream,int[] expirationDate_unit_material_icecream,
			string[] material_fruits,int[] price_unit_material_fruits,
            int[] num_unit_material_fruits,int[] expirationDate_unit_material_fruits,
			string[] material_drinks,int[] price_unit_material_drinks,
            int[] num_unit_material_drinks,int[] expirationDate_unit_material_drinks,
			string[] material_main_meal,int[] price_unit_material_main_meal,
            int[] num_unit_material_main_meal,int[] expirationDate_unit_material_main_meal,
			string[] material_syrup,int[] price_unit_material_syrup,
            int[] num_unit_material_syrup,int[] expirationDate_unit_material_syrup,
			string[] material_main_meal_toppings,int[] price_unit_material_main_meal_toppings,
            int[] num_unit_material_main_meal_toppings,int[] expirationDate_unit_material_main_meal_toppings,
			string[] material_drinks_toppings,int[] price_unit_material_drinks_toppings,
            int[] num_unit_material_drinks_toppings, int[] expirationDate_unit_material_drinks_toppings,
            int[] standby_num_unit_material_icecream,int[] standby_expirationDate_unit_material_icecream,
            int[] standby_num_unit_material_fruits,int[] standby_expirationDate_unit_material_fruits,
            int[] standby_num_unit_material_drinks,int[] standby_expirationDate_unit_material_drinks,
            int[] standby_num_unit_material_main_meal,int[] standby_expirationDate_unit_material_main_meal,
            int[] standby_num_unit_material_syrup,int[] standby_expirationDate_unit_material_syrup,
            int[] standby_num_unit_material_main_meal_toppings,int[] standby_expirationDate_unit_material_main_meal_toppings,
            int[] standby_num_unit_material_drinks_toppings,int[] standby_expirationDate_unit_material_drinks_toppings,
            int[] intact_expirationDate_unit_material_icecream,int[] intact_expirationDate_unit_material_fruits,
            int[] intact_expirationDate_unit_material_drinks,int[] intact_expirationDate_unit_material_main_meal,
            int[] intact_expirationDate_unit_material_syrup,int[] intact_expirationDate_unit_material_main_meal_toppings,
            int[] intact_expirationDate_unit_material_drinks_toppings,int stock_lower_limit_material)
        {
            for(int i = 0; i < material_icecream.Length; i++){
                if(num_unit_material_icecream[i]<1){
                    num_unit_material_icecream[i]+=standby_num_unit_material_icecream[i];
                    expirationDate_unit_material_icecream[i]=standby_expirationDate_unit_material_icecream[i];
                    standby_num_unit_material_icecream[i]=0;
                    
                }
                if(standby_num_unit_material_icecream[i]+num_unit_material_icecream[i]<stock_lower_limit_material){
                    standby_num_unit_material_icecream[i]+=stock_lower_limit_material;
                    standby_expirationDate_unit_material_icecream[i]=intact_expirationDate_unit_material_icecream[i];
                }
                
            }
            for(int i = 0; i < material_fruits.Length; i++){
                if(num_unit_material_fruits[i]<1){
                    num_unit_material_fruits[i]+=standby_num_unit_material_fruits[i];
                    expirationDate_unit_material_fruits[i]=standby_expirationDate_unit_material_fruits[i];
                    standby_num_unit_material_fruits[i]=0;
                    
                }
                if(standby_num_unit_material_fruits[i]+num_unit_material_fruits[i]<stock_lower_limit_material){
                    standby_num_unit_material_fruits[i]+=stock_lower_limit_material;
                    standby_expirationDate_unit_material_fruits[i]=intact_expirationDate_unit_material_fruits[i];
                }
            }
            for(int i = 0; i < material_drinks.Length; i++){
                if(num_unit_material_drinks[i]<1){
                    num_unit_material_drinks[i]+=standby_num_unit_material_drinks[i];
                    expirationDate_unit_material_drinks[i]=standby_expirationDate_unit_material_drinks[i];
                    standby_num_unit_material_drinks[i]=0;
                    
                }
                if(standby_num_unit_material_drinks[i]+num_unit_material_drinks[i]<stock_lower_limit_material){
                    standby_num_unit_material_drinks[i]+=stock_lower_limit_material;
                    standby_expirationDate_unit_material_drinks[i]=intact_expirationDate_unit_material_drinks[i];
                }
            }
            for(int i = 0; i < material_main_meal.Length; i++){
                if(num_unit_material_main_meal[i]<1){
                    num_unit_material_main_meal[i]+=standby_num_unit_material_main_meal[i];
                    expirationDate_unit_material_main_meal[i]=standby_expirationDate_unit_material_main_meal[i];
                    standby_num_unit_material_main_meal[i]=0;
                    
                }
                if(standby_num_unit_material_main_meal[i]+num_unit_material_main_meal[i]<stock_lower_limit_material){
                    standby_num_unit_material_main_meal[i]+=stock_lower_limit_material;
                    standby_expirationDate_unit_material_main_meal[i]=intact_expirationDate_unit_material_main_meal[i];
                }
            }
            for(int i = 0; i < material_syrup.Length; i++){
                if(num_unit_material_syrup[i]<1){
                    num_unit_material_syrup[i]+=standby_num_unit_material_syrup[i];
                    expirationDate_unit_material_syrup[i]=standby_expirationDate_unit_material_syrup[i];
                    standby_num_unit_material_syrup[i]=0;
                    
                }
                if(standby_num_unit_material_syrup[i]+num_unit_material_syrup[i]<stock_lower_limit_material){
                    standby_num_unit_material_syrup[i]+=stock_lower_limit_material;
                    standby_expirationDate_unit_material_syrup[i]=intact_expirationDate_unit_material_syrup[i];
                }
            }
            for(int i = 0; i < material_main_meal_toppings.Length; i++){
                if(num_unit_material_main_meal_toppings[i]<1){
                    num_unit_material_main_meal_toppings[i]+=standby_num_unit_material_main_meal_toppings[i];
                    expirationDate_unit_material_main_meal_toppings[i]=standby_expirationDate_unit_material_main_meal_toppings[i];
                    standby_num_unit_material_main_meal_toppings[i]=0;
                    
                }
                if(standby_num_unit_material_main_meal_toppings[i]+num_unit_material_main_meal_toppings[i]<stock_lower_limit_material){
                    standby_num_unit_material_main_meal_toppings[i]+=stock_lower_limit_material;
                    standby_expirationDate_unit_material_main_meal_toppings[i]=intact_expirationDate_unit_material_main_meal_toppings[i];
                }
            }
            for(int i = 0; i < material_drinks_toppings.Length; i++){
                if(num_unit_material_drinks_toppings[i]<1){
                    num_unit_material_drinks_toppings[i]+=standby_num_unit_material_drinks_toppings[i];
                    expirationDate_unit_material_drinks_toppings[i]=standby_expirationDate_unit_material_drinks_toppings[i];
                    standby_num_unit_material_drinks_toppings[i]=0;
                    
                }
                if(standby_num_unit_material_drinks_toppings[i]+num_unit_material_drinks_toppings[i]<stock_lower_limit_material){
                    standby_num_unit_material_drinks_toppings[i]+=stock_lower_limit_material;
                    standby_expirationDate_unit_material_drinks_toppings[i]=intact_expirationDate_unit_material_drinks_toppings[i];
                }
            }
        }

    	static void expirationDate(  //有效日期(時間運作不確定,還沒有呼叫方式)
            string[] material_icecream,int[] price_unit_material_icecream,
            int[] num_unit_material_icecream,int[] expirationDate_unit_material_icecream,
			string[] material_fruits,int[] price_unit_material_fruits,
            int[] num_unit_material_fruits,int[] expirationDate_unit_material_fruits,
			string[] material_drinks,int[] price_unit_material_drinks,
            int[] num_unit_material_drinks,int[] expirationDate_unit_material_drinks,
			string[] material_main_meal,int[] price_unit_material_main_meal,
            int[] num_unit_material_main_meal,int[] expirationDate_unit_material_main_meal,
			string[] material_syrup,int[] price_unit_material_syrup,
            int[] num_unit_material_syrup,int[] expirationDate_unit_material_syrup,
			string[] material_main_meal_toppings,int[] price_unit_material_main_meal_toppings,
            int[] num_unit_material_main_meal_toppings,int[] expirationDate_unit_material_main_meal_toppings,
			string[] material_drinks_toppings,int[] price_unit_material_drinks_toppings,
            int[] num_unit_material_drinks_toppings, int[] expirationDate_unit_material_drinks_toppings,
            int[] standby_num_unit_material_icecream,int[] standby_expirationDate_unit_material_icecream,
            int[] standby_num_unit_material_fruits,int[] standby_expirationDate_unit_material_fruits,
            int[] standby_num_unit_material_drinks,int[] standby_expirationDate_unit_material_drinks,
            int[] standby_num_unit_material_main_meal,int[] standby_expirationDate_unit_material_main_meal,
            int[] standby_num_unit_material_syrup,int[] standby_expirationDate_unit_material_syrup,
            int[] standby_num_unit_material_main_meal_toppings,int[] standby_expirationDate_unit_material_main_meal_toppings,
            int[] standby_num_unit_material_drinks_toppings,int[] standby_expirationDate_unit_material_drinks_toppings,
            int[] intact_expirationDate_unit_material_icecream,int[] intact_expirationDate_unit_material_fruits,
            int[] intact_expirationDate_unit_material_drinks,int[] intact_expirationDate_unit_material_main_meal,
            int[] intact_expirationDate_unit_material_syrup,int[] intact_expirationDate_unit_material_main_meal_toppings,
            int[] intact_expirationDate_unit_material_drinks_toppings,int stock_lower_limit_material)
        {
            for(int i = 0; i < material_icecream.Length; i++){
                expirationDate_unit_material_icecream[i]-=1;
                if(expirationDate_unit_material_icecream[i]==1){
                    Console.WriteLine("{0},數量:{1}將在今天過期",material_icecream,num_unit_material_icecream);
                }
                if(expirationDate_unit_material_icecream[i]==0){
                    Console.WriteLine("{0},數量:{1}已過期,全數清掉",material_icecream,num_unit_material_icecream);
                    num_unit_material_icecream[i]=0;
                    if(standby_num_unit_material_icecream[i]==0){
                        replenishment(material_icecream,price_unit_material_icecream,num_unit_material_icecream,expirationDate_unit_material_icecream,material_fruits,price_unit_material_fruits,num_unit_material_fruits,expirationDate_unit_material_fruits,
                                      material_drinks,price_unit_material_drinks,num_unit_material_drinks,expirationDate_unit_material_drinks,material_main_meal,price_unit_material_main_meal,num_unit_material_main_meal,expirationDate_unit_material_main_meal,
			                          material_syrup,price_unit_material_syrup,num_unit_material_syrup,expirationDate_unit_material_syrup,material_main_meal_toppings,price_unit_material_main_meal_toppings,num_unit_material_main_meal_toppings,expirationDate_unit_material_main_meal_toppings,
			                          material_drinks_toppings,price_unit_material_drinks_toppings,num_unit_material_drinks_toppings,expirationDate_unit_material_drinks_toppings,
                                      standby_num_unit_material_icecream,standby_expirationDate_unit_material_icecream,standby_num_unit_material_fruits,standby_expirationDate_unit_material_fruits,
                                      standby_num_unit_material_drinks,standby_expirationDate_unit_material_drinks,standby_num_unit_material_main_meal,standby_expirationDate_unit_material_main_meal,
                                      standby_num_unit_material_syrup,standby_expirationDate_unit_material_syrup,standby_num_unit_material_main_meal_toppings,standby_expirationDate_unit_material_main_meal_toppings,
                                      standby_num_unit_material_drinks_toppings,standby_expirationDate_unit_material_drinks_toppings,intact_expirationDate_unit_material_icecream,intact_expirationDate_unit_material_fruits,
                                      intact_expirationDate_unit_material_drinks,intact_expirationDate_unit_material_main_meal,
                                      intact_expirationDate_unit_material_syrup,intact_expirationDate_unit_material_main_meal_toppings,
                                      intact_expirationDate_unit_material_drinks_toppings,stock_lower_limit_material
                        );
                    }
                    num_unit_material_icecream[i]=standby_num_unit_material_icecream[i];
                    expirationDate_unit_material_icecream[i]=standby_expirationDate_unit_material_icecream[i];
                    standby_num_unit_material_icecream[i]=0;
                    standby_expirationDate_unit_material_icecream[i]=0;
                }
            }
            for(int i = 0; i < material_fruits.Length; i++){
                expirationDate_unit_material_fruits[i]-=1;
                if(expirationDate_unit_material_fruits[i]==1){
                    Console.WriteLine("{0},數量:{1}將在今天過期",material_fruits,num_unit_material_fruits);
                }
                if(expirationDate_unit_material_fruits[i]==0){
                    Console.WriteLine("{0},數量:{1}已過期,全數清掉",material_fruits,num_unit_material_fruits);
                    num_unit_material_fruits[i]=0;
                    if(standby_num_unit_material_fruits[i]==0){
                        replenishment(material_icecream,price_unit_material_icecream,num_unit_material_icecream,expirationDate_unit_material_icecream,material_fruits,price_unit_material_fruits,num_unit_material_fruits,expirationDate_unit_material_fruits,
                                      material_drinks,price_unit_material_drinks,num_unit_material_drinks,expirationDate_unit_material_drinks,material_main_meal,price_unit_material_main_meal,num_unit_material_main_meal,expirationDate_unit_material_main_meal,
			                          material_syrup,price_unit_material_syrup,num_unit_material_syrup,expirationDate_unit_material_syrup,material_main_meal_toppings,price_unit_material_main_meal_toppings,num_unit_material_main_meal_toppings,expirationDate_unit_material_main_meal_toppings,
			                          material_drinks_toppings,price_unit_material_drinks_toppings,num_unit_material_drinks_toppings,expirationDate_unit_material_drinks_toppings,
                                      standby_num_unit_material_icecream,standby_expirationDate_unit_material_icecream,standby_num_unit_material_fruits,standby_expirationDate_unit_material_fruits,
                                      standby_num_unit_material_drinks,standby_expirationDate_unit_material_drinks,standby_num_unit_material_main_meal,standby_expirationDate_unit_material_main_meal,
                                      standby_num_unit_material_syrup,standby_expirationDate_unit_material_syrup,standby_num_unit_material_main_meal_toppings,standby_expirationDate_unit_material_main_meal_toppings,
                                      standby_num_unit_material_drinks_toppings,standby_expirationDate_unit_material_drinks_toppings,intact_expirationDate_unit_material_icecream,intact_expirationDate_unit_material_fruits,
                                      intact_expirationDate_unit_material_drinks,intact_expirationDate_unit_material_main_meal,
                                      intact_expirationDate_unit_material_syrup,intact_expirationDate_unit_material_main_meal_toppings,
                                      intact_expirationDate_unit_material_drinks_toppings,stock_lower_limit_material
                        );
                    }
                    num_unit_material_fruits[i]=standby_num_unit_material_fruits[i];
                    expirationDate_unit_material_fruits[i]=standby_expirationDate_unit_material_fruits[i];
                    standby_num_unit_material_fruits[i]=0;
                    standby_expirationDate_unit_material_fruits[i]=0;
                }
            }
            for(int i = 0; i < material_drinks.Length; i++){
                expirationDate_unit_material_drinks[i]-=1;
                if(expirationDate_unit_material_drinks[i]==1){
                    Console.WriteLine("{0},數量:{1}將在今天過期",material_drinks,num_unit_material_drinks);
                }
                if(expirationDate_unit_material_drinks[i]==0){
                    Console.WriteLine("{0},數量:{1}已過期,全數清掉",material_drinks,num_unit_material_drinks);
                    num_unit_material_drinks[i]=0;
                    if(standby_num_unit_material_drinks[i]==0){
                        replenishment(material_icecream,price_unit_material_icecream,num_unit_material_icecream,expirationDate_unit_material_icecream,material_fruits,price_unit_material_fruits,num_unit_material_fruits,expirationDate_unit_material_fruits,
                                      material_drinks,price_unit_material_drinks,num_unit_material_drinks,expirationDate_unit_material_drinks,material_main_meal,price_unit_material_main_meal,num_unit_material_main_meal,expirationDate_unit_material_main_meal,
			                          material_syrup,price_unit_material_syrup,num_unit_material_syrup,expirationDate_unit_material_syrup,material_main_meal_toppings,price_unit_material_main_meal_toppings,num_unit_material_main_meal_toppings,expirationDate_unit_material_main_meal_toppings,
			                          material_drinks_toppings,price_unit_material_drinks_toppings,num_unit_material_drinks_toppings,expirationDate_unit_material_drinks_toppings,
                                      standby_num_unit_material_icecream,standby_expirationDate_unit_material_icecream,standby_num_unit_material_fruits,standby_expirationDate_unit_material_fruits,
                                      standby_num_unit_material_drinks,standby_expirationDate_unit_material_drinks,standby_num_unit_material_main_meal,standby_expirationDate_unit_material_main_meal,
                                      standby_num_unit_material_syrup,standby_expirationDate_unit_material_syrup,standby_num_unit_material_main_meal_toppings,standby_expirationDate_unit_material_main_meal_toppings,
                                      standby_num_unit_material_drinks_toppings,standby_expirationDate_unit_material_drinks_toppings,intact_expirationDate_unit_material_icecream,intact_expirationDate_unit_material_fruits,
                                      intact_expirationDate_unit_material_drinks,intact_expirationDate_unit_material_main_meal,
                                      intact_expirationDate_unit_material_syrup,intact_expirationDate_unit_material_main_meal_toppings,
                                      intact_expirationDate_unit_material_drinks_toppings,stock_lower_limit_material
                        );
                    }
                    num_unit_material_drinks[i]=standby_num_unit_material_drinks[i];
                    expirationDate_unit_material_drinks[i]=standby_expirationDate_unit_material_drinks[i];
                    standby_num_unit_material_drinks[i]=0;
                    standby_expirationDate_unit_material_drinks[i]=0;
                }
            }
            for(int i = 0; i < material_main_meal.Length; i++){
                expirationDate_unit_material_main_meal[i]-=1;
                if(expirationDate_unit_material_main_meal[i]==1){
                    Console.WriteLine("{0},數量:{1}將在今天過期",material_main_meal,num_unit_material_main_meal);
                }
                if(expirationDate_unit_material_main_meal[i]==0){
                    Console.WriteLine("{0},數量:{1}已過期,全數清掉",material_main_meal,num_unit_material_main_meal);
                    num_unit_material_main_meal[i]=0;
                    if(standby_num_unit_material_main_meal[i]==0){
                        replenishment(material_icecream,price_unit_material_icecream,num_unit_material_icecream,expirationDate_unit_material_icecream,material_fruits,price_unit_material_fruits,num_unit_material_fruits,expirationDate_unit_material_fruits,
                                      material_drinks,price_unit_material_drinks,num_unit_material_drinks,expirationDate_unit_material_drinks,material_main_meal,price_unit_material_main_meal,num_unit_material_main_meal,expirationDate_unit_material_main_meal,
			                          material_syrup,price_unit_material_syrup,num_unit_material_syrup,expirationDate_unit_material_syrup,material_main_meal_toppings,price_unit_material_main_meal_toppings,num_unit_material_main_meal_toppings,expirationDate_unit_material_main_meal_toppings,
			                          material_drinks_toppings,price_unit_material_drinks_toppings,num_unit_material_drinks_toppings,expirationDate_unit_material_drinks_toppings,
                                      standby_num_unit_material_icecream,standby_expirationDate_unit_material_icecream,standby_num_unit_material_fruits,standby_expirationDate_unit_material_fruits,
                                      standby_num_unit_material_drinks,standby_expirationDate_unit_material_drinks,standby_num_unit_material_main_meal,standby_expirationDate_unit_material_main_meal,
                                      standby_num_unit_material_syrup,standby_expirationDate_unit_material_syrup,standby_num_unit_material_main_meal_toppings,standby_expirationDate_unit_material_main_meal_toppings,
                                      standby_num_unit_material_drinks_toppings,standby_expirationDate_unit_material_drinks_toppings,intact_expirationDate_unit_material_icecream,intact_expirationDate_unit_material_fruits,
                                      intact_expirationDate_unit_material_drinks,intact_expirationDate_unit_material_main_meal,
                                      intact_expirationDate_unit_material_syrup,intact_expirationDate_unit_material_main_meal_toppings,
                                      intact_expirationDate_unit_material_drinks_toppings,stock_lower_limit_material
                        );
                    }
                    num_unit_material_main_meal[i]=standby_num_unit_material_main_meal[i];
                    expirationDate_unit_material_main_meal[i]=standby_expirationDate_unit_material_main_meal[i];
                    standby_num_unit_material_main_meal[i]=0;
                    standby_expirationDate_unit_material_main_meal[i]=0;
                }
            }
            for(int i = 0; i < material_syrup.Length; i++){
                expirationDate_unit_material_syrup[i]-=1;
                if(expirationDate_unit_material_syrup[i]==1){
                    Console.WriteLine("{0},數量:{1}將在今天過期",material_syrup,num_unit_material_syrup);
                }
                if(expirationDate_unit_material_syrup[i]==0){
                    Console.WriteLine("{0},數量:{1}已過期,全數清掉",material_syrup,num_unit_material_syrup);
                    num_unit_material_syrup[i]=0;
                    if(standby_num_unit_material_syrup[i]==0){
                        replenishment(material_icecream,price_unit_material_icecream,num_unit_material_icecream,expirationDate_unit_material_icecream,material_fruits,price_unit_material_fruits,num_unit_material_fruits,expirationDate_unit_material_fruits,
                                      material_drinks,price_unit_material_drinks,num_unit_material_drinks,expirationDate_unit_material_drinks,material_main_meal,price_unit_material_main_meal,num_unit_material_main_meal,expirationDate_unit_material_main_meal,
			                          material_syrup,price_unit_material_syrup,num_unit_material_syrup,expirationDate_unit_material_syrup,material_main_meal_toppings,price_unit_material_main_meal_toppings,num_unit_material_main_meal_toppings,expirationDate_unit_material_main_meal_toppings,
			                          material_drinks_toppings,price_unit_material_drinks_toppings,num_unit_material_drinks_toppings,expirationDate_unit_material_drinks_toppings,
                                      standby_num_unit_material_icecream,standby_expirationDate_unit_material_icecream,standby_num_unit_material_fruits,standby_expirationDate_unit_material_fruits,
                                      standby_num_unit_material_drinks,standby_expirationDate_unit_material_drinks,standby_num_unit_material_main_meal,standby_expirationDate_unit_material_main_meal,
                                      standby_num_unit_material_syrup,standby_expirationDate_unit_material_syrup,standby_num_unit_material_main_meal_toppings,standby_expirationDate_unit_material_main_meal_toppings,
                                      standby_num_unit_material_drinks_toppings,standby_expirationDate_unit_material_drinks_toppings,intact_expirationDate_unit_material_icecream,intact_expirationDate_unit_material_fruits,
                                      intact_expirationDate_unit_material_drinks,intact_expirationDate_unit_material_main_meal,
                                      intact_expirationDate_unit_material_syrup,intact_expirationDate_unit_material_main_meal_toppings,
                                      intact_expirationDate_unit_material_drinks_toppings,stock_lower_limit_material
                        );
                    }
                    num_unit_material_syrup[i]=standby_num_unit_material_syrup[i];
                    expirationDate_unit_material_syrup[i]=standby_expirationDate_unit_material_syrup[i];
                    standby_num_unit_material_syrup[i]=0;
                    standby_expirationDate_unit_material_syrup[i]=0;
                }
            }
            for(int i = 0; i < material_main_meal_toppings.Length; i++){
                expirationDate_unit_material_main_meal_toppings[i]-=1;
                if(expirationDate_unit_material_main_meal_toppings[i]==1){
                    Console.WriteLine("{0},數量:{1}將在今天過期",material_main_meal_toppings,num_unit_material_main_meal_toppings);
                }
                if(expirationDate_unit_material_main_meal_toppings[i]==0){
                    Console.WriteLine("{0},數量:{1}已過期,全數清掉",material_main_meal_toppings,num_unit_material_main_meal_toppings);
                    num_unit_material_main_meal_toppings[i]=0;
                    if(standby_num_unit_material_main_meal_toppings[i]==0){
                        replenishment(material_icecream,price_unit_material_icecream,num_unit_material_icecream,expirationDate_unit_material_icecream,material_fruits,price_unit_material_fruits,num_unit_material_fruits,expirationDate_unit_material_fruits,
                                      material_drinks,price_unit_material_drinks,num_unit_material_drinks,expirationDate_unit_material_drinks,material_main_meal,price_unit_material_main_meal,num_unit_material_main_meal,expirationDate_unit_material_main_meal,
			                          material_syrup,price_unit_material_syrup,num_unit_material_syrup,expirationDate_unit_material_syrup,material_main_meal_toppings,price_unit_material_main_meal_toppings,num_unit_material_main_meal_toppings,expirationDate_unit_material_main_meal_toppings,
			                          material_drinks_toppings,price_unit_material_drinks_toppings,num_unit_material_drinks_toppings,expirationDate_unit_material_drinks_toppings,
                                      standby_num_unit_material_icecream,standby_expirationDate_unit_material_icecream,standby_num_unit_material_fruits,standby_expirationDate_unit_material_fruits,
                                      standby_num_unit_material_drinks,standby_expirationDate_unit_material_drinks,standby_num_unit_material_main_meal,standby_expirationDate_unit_material_main_meal,
                                      standby_num_unit_material_syrup,standby_expirationDate_unit_material_syrup,standby_num_unit_material_main_meal_toppings,standby_expirationDate_unit_material_main_meal_toppings,
                                      standby_num_unit_material_drinks_toppings,standby_expirationDate_unit_material_drinks_toppings,intact_expirationDate_unit_material_icecream,intact_expirationDate_unit_material_fruits,
                                      intact_expirationDate_unit_material_drinks,intact_expirationDate_unit_material_main_meal,
                                      intact_expirationDate_unit_material_syrup,intact_expirationDate_unit_material_main_meal_toppings,
                                      intact_expirationDate_unit_material_drinks_toppings,stock_lower_limit_material
                        );
                    }
                    num_unit_material_main_meal_toppings[i]=standby_num_unit_material_main_meal_toppings[i];
                    expirationDate_unit_material_main_meal_toppings[i]=standby_expirationDate_unit_material_main_meal_toppings[i];
                    standby_num_unit_material_main_meal_toppings[i]=0;
                    standby_expirationDate_unit_material_main_meal_toppings[i]=0;
                }
            }
            for(int i = 0; i < material_drinks_toppings.Length; i++){
                expirationDate_unit_material_drinks_toppings[i]-=1;
                if(expirationDate_unit_material_drinks_toppings[i]==1){
                    Console.WriteLine("{0},數量:{1}將在今天過期",material_drinks_toppings,num_unit_material_drinks_toppings);
                }
                if(expirationDate_unit_material_drinks_toppings[i]==0){
                    Console.WriteLine("{0},數量:{1}已過期,全數清掉",material_drinks_toppings,num_unit_material_drinks_toppings);
                    num_unit_material_drinks_toppings[i]=0;
                    if(standby_num_unit_material_drinks_toppings[i]==0){
                        replenishment(material_icecream,price_unit_material_icecream,num_unit_material_icecream,expirationDate_unit_material_icecream,material_fruits,price_unit_material_fruits,num_unit_material_fruits,expirationDate_unit_material_fruits,
                                      material_drinks,price_unit_material_drinks,num_unit_material_drinks,expirationDate_unit_material_drinks,material_main_meal,price_unit_material_main_meal,num_unit_material_main_meal,expirationDate_unit_material_main_meal,
			                          material_syrup,price_unit_material_syrup,num_unit_material_syrup,expirationDate_unit_material_syrup,material_main_meal_toppings,price_unit_material_main_meal_toppings,num_unit_material_main_meal_toppings,expirationDate_unit_material_main_meal_toppings,
			                          material_drinks_toppings,price_unit_material_drinks_toppings,num_unit_material_drinks_toppings,expirationDate_unit_material_drinks_toppings,
                                      standby_num_unit_material_icecream,standby_expirationDate_unit_material_icecream,standby_num_unit_material_fruits,standby_expirationDate_unit_material_fruits,
                                      standby_num_unit_material_drinks,standby_expirationDate_unit_material_drinks,standby_num_unit_material_main_meal,standby_expirationDate_unit_material_main_meal,
                                      standby_num_unit_material_syrup,standby_expirationDate_unit_material_syrup,standby_num_unit_material_main_meal_toppings,standby_expirationDate_unit_material_main_meal_toppings,
                                      standby_num_unit_material_drinks_toppings,standby_expirationDate_unit_material_drinks_toppings,intact_expirationDate_unit_material_icecream,intact_expirationDate_unit_material_fruits,
                                      intact_expirationDate_unit_material_drinks,intact_expirationDate_unit_material_main_meal,
                                      intact_expirationDate_unit_material_syrup,intact_expirationDate_unit_material_main_meal_toppings,
                                      intact_expirationDate_unit_material_drinks_toppings,stock_lower_limit_material
                        );
                    }
                    num_unit_material_drinks_toppings[i]=standby_num_unit_material_drinks_toppings[i];
                    expirationDate_unit_material_drinks_toppings[i]=standby_expirationDate_unit_material_drinks_toppings[i];
                    standby_num_unit_material_drinks_toppings[i]=0;
                    standby_expirationDate_unit_material_drinks_toppings[i]=0;
                }
            }
        }
	//======================================================== 點餐 ===========================================================		
		
		static void Take_an_order(
			string name_of_the_store,
			 string[] material_icecream, int[] price_unit_material_icecream,
			 string[] material_fruits, int[] price_unit_material_fruits,
			 string[] material_drinks, int[] price_unit_material_drinks,
			 string[] material_main_meal, int[] price_unit_material_main_meal,
			 string[] material_syrup, int[] price_unit_material_syrup,
			 string[] material_main_meal_toppings, int[] price_unit_material_main_meal_toppings,
			 string[] material_drinks_toppings, int[] price_unit_material_drinks_toppings,
			 out int price_of_the_total_order, out string a_new_order, out string material, out int Revenue)  // Revenue
		{
			price_of_the_total_order = 0;
			Revenue = 0;
			Console.WriteLine("歡迎光臨{0}甜點店!", name_of_the_store);
			int price_item = 0;
			a_new_order="";
            material="";
			int item_number;
			bool order_next_item = true;
			for (item_number=1; order_next_item; item_number++)
			{
				Console.Write("想點套餐請輸入\"1\"，想單點請輸入\"2\": ");
				string order_category = Console.ReadLine();
				Console.Clear();
				if (order_category == "1")
				{
					Take_a_new_combo_order(
						material_icecream, price_unit_material_icecream,
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
					//紀錄套餐品項
                    material+=order_icecream+" "+ order_main_meal + " " + order_fruits + " " + order_main_meal_toppings + " " + order_syrup + " " + order_drinks + " " + order_drinks_toppings+" ";
					a_new_order += "品項" + item_number + ": " + order_icecream + "冰淇淋" + order_main_meal + "佐" + order_fruits + "加" + order_main_meal_toppings + "淋" + order_syrup + "，搭配飲料" + order_drinks + "加" + order_drinks_toppings + "     $" + price_item + '\n';
					Console.Clear();
					Console.WriteLine("您目前點購的餐點為:"+'\n');
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
					Take_a_new_single_order(
						material_icecream, price_unit_material_icecream,
						  material_fruits, price_unit_material_fruits,
						  material_drinks, price_unit_material_drinks,
		 				  material_main_meal, price_unit_material_main_meal,
						  material_syrup, price_unit_material_syrup,
						  material_main_meal_toppings, price_unit_material_main_meal_toppings,
						  material_drinks_toppings, price_unit_material_drinks_toppings,
						 out string single_item, out int price_single_item, out int quantity_single_item);
					price_of_the_total_order += price_single_item * quantity_single_item;
					//紀錄單點品項
                    material+=single_item +" "+ quantity_single_item +" ";
					a_new_order += "品項" + item_number + ": " +single_item +"*"+ quantity_single_item + "     $" + price_single_item * quantity_single_item + '\n';
					Console.Clear();
					Console.WriteLine("您目前點購的餐點為:"+'\n');
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
            //===================================================================  點餐完畢 進行結帳
				if(order_next_item==false){
					Console.Clear();
					Console.WriteLine();
					Checkout(price_of_the_total_order, Revenue);
				}
			}
		}
		
		static void Take_a_new_combo_order(  //套餐
			string[] material_icecream, int[] price_unit_material_icecream,
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
				Console.WriteLine(j+". "+material_main_meal[i] + " $" + price_unit_material_main_meal[i]);
			}
			Console.WriteLine();
			Console.Write("請輸入編號點餐(e.g.\"1\"): ");
			int k = int.Parse(Console.ReadLine())-1;
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
			k = int.Parse(Console.ReadLine())-1;
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
			k = int.Parse(Console.ReadLine())-1;
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

		static void Take_a_new_single_order(  //單點
			string[] material_icecream, int[] price_unit_material_icecream,
			 string[] material_fruits, int[] price_unit_material_fruits,
			 string[] material_drinks, int[] price_unit_material_drinks,
		 	 string[] material_main_meal, int[] price_unit_material_main_meal,
			 string[] material_syrup, int[] price_unit_material_syrup,
			 string[] material_main_meal_toppings, int[] price_unit_material_main_meal_toppings,
			 string[] material_drinks_toppings, int[] price_unit_material_drinks_toppings
			
			,out string single_item, out int price_single_item, out int quantity_single_item)
		{
			Console.WriteLine("以下為單點價目表，請依指示選擇品項點餐:" + '\n');
			Console.WriteLine("A. 冰淇淋"+'\n');
			for (int i = 0; i < material_icecream.Length; i++)
			{
				Console.Write("  "+(i+1)+"."+material_icecream[i]+" $"+ price_unit_material_icecream[i]);
			}
			Console.WriteLine(); Console.WriteLine(); Console.WriteLine();
			Console.WriteLine("B. 水果"+'\n');
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
			Console.WriteLine( "D. 飲料" + '\n');
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
					j = material_icecream.Length - 1;break;
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
					single_item = material_icecream[k - 1] + "冰淇淋";
					price_single_item = price_unit_material_icecream[k - 1];
					break;
				case "B":
					single_item = material_fruits[k - 1];
					price_single_item = price_unit_material_fruits[k - 1];
					break;
				case "C":
					single_item = material_main_meal[k - 1];
					price_single_item = price_unit_material_main_meal[k - 1];
					break;
				case "D":
					single_item = material_drinks[k - 1];
					price_single_item = price_unit_material_drinks[k - 1];
					break;
				case "E":
					single_item = "主餐配料" + material_main_meal_toppings[k - 1];
					price_single_item = price_unit_material_main_meal_toppings[k - 1];
					break;
				case "F":
					single_item = "飲料配料" + material_drinks_toppings[k - 1];
					price_single_item = price_unit_material_drinks_toppings[k - 1];
					break;
				case "G":
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

		static void Print_the_menu(  //菜單
			string[] material_icecream, int[] price_unit_material_icecream,
			string[] material_fruits, int[] price_unit_material_fruits,
			string[] material_drinks, int[] price_unit_material_drinks,
			string[] material_main_meal, int[] price_unit_material_main_meal,
			string[] material_syrup, int[] price_unit_material_syrup,
			string[] material_main_meal_toppings, int[] price_unit_material_main_meal_toppings,
			string[] material_drinks_toppings, int[] price_unit_material_drinks_toppings)
		{
			Console.WriteLine("以下是我們的價目表，採套餐制，請依序選擇品項點餐:"+'\n');
			/*主餐*/
			Console.WriteLine("請先選擇主餐，主餐有以下幾樣選擇:"+'\n');
			for (int i = 0; i < material_main_meal.Length; i++)
			{
				Console.WriteLine(material_main_meal[i]+" $"+ price_unit_material_main_meal[i]);
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
			Console.WriteLine( '\n');
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


	//=============================================== **結帳功能** ===============================================		
		static void Checkout (int price_of_the_total_order, int Revenue)   //還要引入會員資料
		{   
			Console.WriteLine("總金額: " + price_of_the_total_order);

		//會員===========================================================
			Console.Write("有會員請輸入\"y\"，沒有會員請輸入\"n\": ");
			string answer = Console.ReadLine();
			
			if(answer == "n"){
				Console.Write("是否申辦會員(y/n): ");
				string apply_membership = Console.ReadLine();

				if(apply_membership == "y"){
					//跳轉到會員系統
				}else if(apply_membership == "n"){
					//繼續結帳
					
				}else{
					
					Console.Clear();   //不要清除前面的訂單資料
					Console.WriteLine("輸入錯誤，請重新輸入。");
					Console.Write("是否申辦會員(y/n): ");
					apply_membership = Console.ReadLine();
					
				}

			}else if(answer == "y"){
				Console.Write("請輸入會員編號: ");  // or其他資料
				//引入會員資料

				if(price_of_the_total_order>=200){   //消費金額超過200元 可累積1點

				}

				// 有無折價券
			}else{

				Console.WriteLine("輸入錯誤，請重新輸入。");
				Console.Write("有會員請輸入\"y\"，沒有會員請輸入\"n\": ");
				answer = Console.ReadLine();
			}
		
		
			//付款   (付款方式)
			Console.Write("輸入付款金額: ");
			int customer_pay = Convert.ToInt32(Console.ReadLine());
			int give_change = customer_pay - price_of_the_total_order;
			Console.Write("應找 {0}元", give_change);
			
			Revenue += price_of_the_total_order;

			Console.Write("結束請按任意鍵: ");
			Console.ReadKey();
			Console.Clear();

		}
		
	//================================================ **財務系統** ==================================================
		static void Financial_System(int Revenue, int all_cost, int staff_number){

			TestLabel:   
			Console.Write("計算營業開銷請輸入\"1\"，查詢獲利請輸入\"0\": ");
			string use_financial_system = Console.ReadLine();
			Console.Clear();

			int electric_cost=0; int water_cost=0; int gas_cost=0;

			//======================== 查詢獲利 =======================
			if(use_financial_system == "0"){
				Console.WriteLine("總營收: {0}元", Revenue);
				Console.WriteLine("總營業開銷: {0}元", all_cost);

				if(electric_cost==0 || water_cost==0 || gas_cost==0){
					Console.Write(" !!提醒!! ");
					if(electric_cost==0) Console.Write("電費、"); 
					if(water_cost==0) Console.Write("水費、");
					if(gas_cost==0) Console.Write("瓦斯費");
					Console.WriteLine("\t 尚未計算!");

					Console.Write("是否返回計算開銷 (y/n)?");
					string answer = Console.ReadLine();
					while(answer=="y"){
						goto TestLabel;
					}	
				}
				Console.WriteLine();

				int profit = Revenue-all_cost;
				Console.WriteLine("總獲利: {0}元", profit);

				if(profit*1/2 <= 24000*staff_number){
					Console.WriteLine("!!! *警示* !!!   本月獲利的1/2不足以付給薪資!");
					Console.ReadLine();
				}

			//============================================ 計算營業開銷 ========================================================
			}else if(use_financial_system == "1"){
				
				Console.Write("計算瓦斯費請輸入\"3\"，計算水費請輸入\"2\"，計算電費請輸入\"1\"，查詢原料成本請輸入\"0\": ");
				string operate_cost = Console.ReadLine();
				Console.Clear();

				//============================電費計算===============================
				if(operate_cost == "1"){     
					Console.Write("請輸入用電度數: ");
					double electric_amount = Convert.ToInt32(Console.ReadLine());

					double accumulate_price = 0;
					double[] price = new double[7];
					double[] stage = new double[7];
					stage[0] = 0;
					stage[1] = 120; price[1] = 1.63;   //120 度以下部分
					stage[2] = 330; price[2] = 2.38;     //121~330 度部分 
					stage[3] = 500; price[3] = 3.52;     //331~500 度部分
					stage[4] = 700; price[4] = 4.80;     //501~700 度部分 
					stage[5] = 1000; price[5] = 5.66;    //701~1000 度部分
					stage[6] = electric_amount; ; price[6] = 6.41;    //1001 度以上部分
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

				}//==========================水費計算============================
				else if(operate_cost == "2") {   
					Console.Write("請輸入用水度數: ");
					double water_amount = Convert.ToInt32(Console.ReadLine());
					
					double[] price = new double[5];
					double[] stage = new double[5];
					double accumulate_price = 0;
					stage[0] = 0;
					stage[1] = 10; price[1] =7.35;
					stage[2] = 30; price[2] =9.45;
					stage[3] = 50; price[3] =11.55;
					stage[4] = water_amount; price[4] =12.075;
					double rest = water_amount;

					for(int i=1; i<5; i++){
						
						if(water_amount > stage[i]){
							accumulate_price += ( stage[i] - stage[i-1] ) *price[i];
							rest -= stage[i] - stage[i-1];
						}
						else{
							accumulate_price += rest * price[i];
							break;
						}
					}

					water_cost = Convert.ToInt32(Math.Ceiling(accumulate_price));
					Console.Write("電費價格:  {0}元", water_cost);
					all_cost += water_cost;

				}//===========================瓦斯費計算===============================
				else if(operate_cost == "3") {   
					Console.Write("請輸入瓦斯度數: ");
					double gas_amount = Convert.ToInt32(Console.ReadLine());

					gas_cost = 60 + Convert.ToInt32(Math.Ceiling(gas_amount*21.5));   // 基本費 60元  每度21.5元
					Console.Write("瓦斯費價格:  {0}元", gas_cost);
					all_cost += gas_cost;

				}
				else if (operate_cost == "0"){
					//成本
				}
				else{

					Console.Clear();  
					Console.WriteLine("輸入錯誤，請重新輸入。");
					Console.Write("計算瓦斯費請輸入\"2\"，計算水費請輸入\"1\"，計算電費請輸入\"0\": ");
					operate_cost = Console.ReadLine();
				}



			}else{

				Console.Clear();  
				Console.WriteLine("輸入錯誤，請重新輸入。");
				Console.Write("計算營業開銷請輸入\"1\"，查詢獲利請輸入\"0\": ");
				use_financial_system = Console.ReadLine();
			}
			
			
		}
	}
	
}
