
using System;

namespace game
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

            //水果定位
            board[0, 0]="橘子"; board[0, 1]="蘋果"; board[0, 2]="檸檬"; board[0,3]="奇異果"; board[0,4]="香蕉";
            board[1, 0]="芭樂"; board[1, 1]="蘋果"; board[1, 2]="西瓜"; board[1,3]="橘子"; board[1,4]="葡萄";
            board[2, 0]="奇異果"; board[2, 1]="水蜜桃"; board[2, 2]="鳳梨"; board[2,3]="香蕉"; board[2,4]="鳳梨";
            board[3, 0]="葡萄"; board[3, 1]="西瓜"; board[3, 2]="水蜜桃"; board[3,3]="芭樂"; board[3,4]="檸檬";
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

            Console.Write("["+x1+","+x2+"]: ");
            switch(board[x1,x2]){
            case "蘋果":
                Console.WriteLine("蘋果");
                break;
            case "香蕉":
                Console.WriteLine("香蕉");
                break;
            case "橘子":
                Console.WriteLine("橘子");
                break;
            case "鳳梨":
                Console.WriteLine("鳳梨");
                break;
            case "西瓜":
                Console.WriteLine("西瓜");
                break;
            case "芭樂":
                Console.WriteLine("芭樂");
                break;
            case "葡萄":
                Console.WriteLine("葡萄");
                break;
            case "奇異果":
                Console.WriteLine("奇異果");
                break;
            case "檸檬":
                Console.WriteLine("檸檬");
                break;
            case "水蜜桃":
                Console.WriteLine("水蜜桃");
                break;
            }
            
            Console.Write("["+y1+","+y2+"]: ");
            switch(board[y1,y2]){
            case "蘋果":
                Console.WriteLine("蘋果");
                break;
            case "香蕉":
                Console.WriteLine("香蕉");
                break;
            case "橘子":
                Console.WriteLine("橘子");
                break;
            case "鳳梨":
                Console.WriteLine("鳳梨");
                break;
            case "西瓜":
                Console.WriteLine("西瓜");
                break;
            case "芭樂":
                Console.WriteLine("芭樂");
                break;
            case "葡萄":
                Console.WriteLine("葡萄");
                break;
            case "奇異果":
                Console.WriteLine("奇異果");
                break;
            case "檸檬":
                Console.WriteLine("檸檬");
                break;
            case "水蜜桃":
                Console.WriteLine("水蜜桃");
                break;
            }
            Console.WriteLine("                        ");
            Console.ReadLine();


               if(board[x1,x2]==board[y1,y2]){
                    count = count+2;
                    Result[x1,x2]=Result[y1,y2]="X";
                    Console.Write(board[x1,x2]);
                    Console.Write(board[y1,y2]);
                    }
            if(count==20){ 
                continu = false; 
                }
        }while(continu);

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