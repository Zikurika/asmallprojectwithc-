using System;
using System.Collections.Generic;

namespace haja
{
    class Program
    {
        static void Main(string[] args)
        {
            int[,] mat ;
            List<int> tabCol = new List<int>();
            List<int> tabLin = new List<int>();
            
            
           
            while (true) {
                int n = 0;
                Console.WriteLine("Bienvenue Dans notre application:");
                Console.WriteLine("pour Remplire la mattrice tapez 1 \n pour entre avec la matrice par defaut tappez 2");
                n = Convert.ToInt16(Console.ReadLine());
            if (n == 1)
            {

                mat = getMatrix();
                showMatrix(mat);
                tabCol = searchColone(mat);
                tabLin = searchLigne(mat, tabCol);
                Console.WriteLine("\n Moment of truth");
                Console.WriteLine("\n /***********************************/");
                orgonizeTable(tabLin, tabCol, mat);
                Console.WriteLine("\n /***********************************/");
                    int m = 0;
                    m = Convert.ToInt16(Console.ReadLine());
                    if (m == 1)
                    {
                        break;
                    }
                    else if (m == 2)
                    {
                        continue;
                    }
                    else
                    {
                        Console.WriteLine("\n veuillle saisir un nombre correct :(");
                    }
                }
            else if (n == 2)
            {
                mat = getMatrix1();
                showMatrix(mat);
                tabCol = searchColone(mat);
                tabLin = searchLigne(mat, tabCol);
                Console.WriteLine("\n Moment of truth");
                Console.WriteLine("\n /***********************************/");
                orgonizeTable(tabLin, tabCol, mat);
                Console.WriteLine("\n /***********************************/");
                Console.WriteLine("\n Pour Sortir tappez 1 \n pour retourner au menu principale tappez 2");
                int m = 0;
                m = Convert.ToInt16(Console.ReadLine());
                    if (m == 1)
                    {
                        break;
                    }else if (m == 2)
                    {
                        continue;
                    }else
                    {
                        Console.WriteLine("\n veuillle saisir un nombre correct :(");
                    }
                }
            else
            {
                Console.WriteLine("\n veuillle saisir un nombre correct :(");
            }
            }
            Environment.Exit(0);
        }
        static public int[,] getMatrix( )
        {
            int n, m , x , y;
            Console.WriteLine("\n donne le nombre de ligne:");
            n = Convert.ToInt16(Console.ReadLine()) ;
            Console.WriteLine("\n donne le nombre de Colone:");
            m = Convert.ToInt16(Console.ReadLine()) ;
            int[,] mat = new int[n, m];
       
            for (int i = 0; i < n; i++)
            {
                for(int j = 0; j < m; j++)
                {
                    x = i + 1;
                    y = j + 1;
                    Console.WriteLine("donne Matrice[" + x + "," + y + "]");
                    mat[i, j] = Convert.ToInt16(Console.ReadLine());
                }
            }
            return mat;
        }
        static public int[,] getMatrix1()
        {
            int[,] mat = new int[9, 11];
            mat[0, 4] = 1; mat[0, 6] = 1; mat[0, 10] = 1;
            mat[1, 0] = 1; mat[1, 2] = 1; mat[1, 5] = 1; mat[1, 7] = 1;
            mat[2, 1] = 1; mat[2, 3] = 0; mat[2, 8] = 1; mat[2, 9] = 1;
            mat[3, 4] = 1; mat[3, 6] = 1; mat[3, 10] = 1;
            mat[4, 0] = 1; mat[4, 2] = 1; mat[4, 5] = 1; mat[4, 7] = 1; mat[4, 8] = 1;
            mat[5, 1] = 1; mat[5, 3] = 1; mat[5, 8] = 1; mat[5, 9] = 1;
            mat[6, 4] = 1; mat[6, 6] = 1; mat[6, 10] = 1;
            mat[7, 0] = 1; mat[7, 2] = 1; mat[7, 5] = 1; mat[7, 7] = 1; mat[7, 8] = 1;
            mat[8, 1] = 1; mat[8, 3] = 1; mat[8, 9] = 1;

            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    if (mat[i, j] != 1)
                    {
                        mat[i, j] = 0;
                    }
                }
            }
            return mat;
        }

        static public void orgonizeTable(List<int> tabLigne , List<int> tabColone , int[,] mat)
        {
            foreach(int l in tabLigne)
            {
                Console.Write("\n");
                foreach(int c in tabColone)
                {
                    Console.Write(mat[l, c]);
                }
            }
        } 

        static public void showMatrix(int[,] mat)
        {
            for (int i = 0; i < mat.GetLength(0); i++)
            {
                Console.Write("\n|");
                for (int j = 0; j < mat.GetLength(1); j++)
                {

                    Console.Write(mat[i, j]+"|");
                }
            }
        }
        static public void showTable(List<int> tab,String comment)
        {
            Console.WriteLine(comment);
            for (int p = 0; p < tab.Count; p++)
            {
                Console.WriteLine(tab[p]);
            }
        }
        static public List<int> searchColone(int[,] mat)
        {
            int i = 0, j = 0, n = 0;
            List<int> tabCol = new List<int>();
            List<int> tabLin = new List<int>();
            Boolean testCol = false;
            Boolean testLin = false;
            for (i = 0; i < mat.GetLength(0); i++)
            {
                int countl = 0;
                testLin = false;
                foreach (int Line in tabLin)
                {

                    if (Line == i)
                    {
                        testLin = true;
                    }
                    countl++;

                }
                if (testLin == false)
                {
                    tabLin.Add(i);
                    for (j = 0; j < mat.GetLength(1); j++)
                    {
                        int countc = 0;
                        testCol = false;
                        foreach (int Col in tabCol)
                        {
                            if (Col == j)
                            {
                                testCol = true;
                            }
                            countc++;

                        }
                        if (mat[i, j] == 1 && testCol == false)
                        {
                            tabCol.Add(j);
                        }

                    }
                }
            }
            return tabCol;
        }

        static public List<int> searchLigne(int[,] mat, List<int> tabCol)
        {
            
            int i = 0;
            Boolean test = true;
            List<int> tablin = new List<int>();
          
            foreach (int j in tabCol)
            {
               
                for (i = 0; i < mat.GetLength(0); i++)
                {
                    test = true;
                    foreach (int l in tablin)
                    {
                        if (l == i)
                        {
                            test = false;
                        }
                     }
                        if (test && mat[i,j]==1)
                        {
                            tablin.Add(i);
                        }
                }
            }
        return tablin;
        }
    }
}