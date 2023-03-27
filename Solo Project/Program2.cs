
using System;

namespace FruitGame
{
    class program
    {
        static void Main(string[] args)
        {	
            string[,] board = { {" ", " ", " "," "," "},
                                {" ", " ", " "," "," "},
                                {" ", " ", " "," "," "},
                                {" ", " ", " "," "," "} };
            string[,] Result = { {" ", " ", " "," "," "},
                                {" ", " ", " "," "," "},
                                {" ", " ", " "," "," "},
                                {" ", " ", " "," "," "} };
            int count=0;
            bool continu = true;
            int game_time = 0;        //增加一個計次器

            // 顯示棋盤
                Display(board);
                Console.WriteLine("     0     1     2     3     4  ");
                Console.WriteLine("              ");
                Console.WriteLine("0    {0}  |  {1}  |  {2}  |  {3}  |  {4} ",
                    board[0, 0], board[0, 1], board[0, 2], board[0,3], board[0,4]);
                Console.WriteLine("    --- + --- + --- + --- + ---");
                Console.WriteLine("1    {0}  |  {1}  |  {2}  |  {3}  |  {4} ",
                    board[1, 0], board[1, 1], board[1, 2], board[1,3], board[1,4]);
                Console.WriteLine("    --- + --- + --- + --- + ---");
                Console.WriteLine("2    {0}  |  {1}  |  {2}  |  {3}  |  {4} ",
                    board[2, 0], board[2, 1], board[2, 2], board[2,3], board[2,4]);
                Console.WriteLine("    --- + --- + --- + --- + ---");
                Console.WriteLine("3    {0}  |  {1}  |  {2}  |  {3}  |  {4} ",
                    board[3, 0], board[3, 1], board[3, 2], board[3,3], board[3,4]);
                Console.WriteLine("              "); 
                Console.Clear();

            //水果隨機定位
            RandomNumber(board);
			
			static void RandomNumber(string[,] board){
				Random random = new Random();
                // 將水果名存入p陣列中
				string []p = {"橘子", "蘋果", "芭樂", "奇異果", "葡萄",    
			                  "西瓜", "水蜜桃", "鳳梨", "香蕉", "檸檬"};

				// 設定一個陣列負責記錄水果已存入board的次數
				int[] fruit_count = new int[10];   
				int k;
				for(k=0; k<10; k++){
					fruit_count[k]=0;
				}
                // 依序將水果存入board中
				for(int i=0; i<4; i++){
					for(int j=0; j<5; j++){
						int r = random.Next() %10; 
						fruit_count[r] = ++fruit_count[r];
						board[i,j] = p[r];

                        // 當一個水果已存入超過2次 就在重新做一次隨機取值
					    while(fruit_count[r]>2){ 
							fruit_count[r] = --fruit_count[r];
							r = random.Next() %10; 
							board[i,j] = p[r];
							fruit_count[r] = ++fruit_count[r];
						}
					}
				}
			}

        do{
            
                Display(Result);
            /* 顯示棋盤
                Console.Clear();
                Console.WriteLine("     0     1     2     3     4  ");
                Console.WriteLine("              ");
                Console.WriteLine("0       |     |     |     |      ");
                Console.WriteLine("    --- + --- + --- + --- + ---");
                Console.WriteLine("1       |     |     |     |      ");
                Console.WriteLine("    --- + --- + --- + --- + ---");
                Console.WriteLine("2       |     |     |     |      ");
                Console.WriteLine("    --- + --- + --- + --- + ---");
                Console.WriteLine("3       |     |     |     |      ");
                Console.WriteLine("              ");*/
            
            //顯示提問
            Console.Write("輸入第一個的座標, 以逗點分隔: ");
            string[] input1 = new string[2];
            input1 = Console.ReadLine().Split(',');
            int x1 = Convert.ToInt16(input1[0]);
            int x2 = Convert.ToInt16(input1[1]);
            

            Console.Write("輸入第二個的座標, 以逗點分隔: ");
            string[] input2 = new string[2];
            input2 = Console.ReadLine().Split(',');
            int y1 = Convert.ToInt16(input2[0]);
            int y2 = Convert.ToInt16(input2[1]);

            /*要顯示輸入位置對應的水果
            如果還沒結束就再回去循環一次*/

            game_time = game_time +1;   //每進行一次就將計次器+1

            Console.Write("[{0},{1}]: ",x1,x2);
            Console.WriteLine(board[x1,x2]);
            Console.Write("[{0},{1}]: ",y1,y2);
            Console.WriteLine(board[y1,y2]);
            Console.WriteLine("                        ");
            if(board[x1,x2]==board[y1,y2]){
                count = count+2;
                Console.WriteLine("配對成功!");  
                Result[x1,x2]=Result[y1,y2]="X";
            }
            Console.ReadLine();   
               
            if(count==20){ 
                continu = false; 
                }
        }while(continu);

            //最終完成後 顯示成功完成和嘗試次數
            Console.WriteLine("恭喜你完成了!");
            Console.WriteLine("一共嘗試了{0}次",game_time);  
            Console.ReadLine();

            // 顯示棋盤
            static void Display(string[,] board){
                Console.Clear();
                Console.WriteLine("     0     1     2     3     4  ");
                Console.WriteLine("              ");
                Console.WriteLine("0    {0}  |  {1}  |  {2}  |  {3}  |  {4} ",
                    board[0, 0], board[0, 1], board[0, 2], board[0,3], board[0,4]);
                Console.WriteLine("    --- + --- + --- + --- + ---");
                Console.WriteLine("1    {0}  |  {1}  |  {2}  |  {3}  |  {4} ",
                    board[1, 0], board[1, 1], board[1, 2], board[1,3], board[1,4]);
                Console.WriteLine("    --- + --- + --- + --- + ---");
                Console.WriteLine("2    {0}  |  {1}  |  {2}  |  {3}  |  {4} ",
                    board[2, 0], board[2, 1], board[2, 2], board[2,3], board[2,4]);
                Console.WriteLine("    --- + --- + --- + --- + ---");
                Console.WriteLine("3    {0}  |  {1}  |  {2}  |  {3}  |  {4} ",
                    board[3, 0], board[3, 1], board[3, 2], board[3,3], board[3,4]);
                Console.WriteLine("              "); 
         } 
    }
}
}