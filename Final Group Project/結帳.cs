
//                                        點餐
//===============================================================================================  點餐完畢 進行結帳
				if(order_next_item==false){
					Console.Clear();
					Console.WriteLine();
					Checkout(price_of_the_total_order, Revenue);
				}
			}
		}

	//=========================================*結帳功能*===============================================		
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