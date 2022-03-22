using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sudoku_
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        int[,] sudoku = new int[9, 9];
        void mostraSudoku()
        {
            for (int l = 0; l < 9; l++)
            {
                for (int c = 0; c < 9; c++)
                {
                    {
                        richTextBox1.AppendText(sudoku[l, c].ToString() + "  ");
                    }
                }
                richTextBox1.AppendText(Environment.NewLine);
            }
        }
        int[] numValido = new int[9];//array
        Random random = new Random();
        int linhas = 0; int rnd = 0; int contador = 0; int contador2 = 0;
        private int criarLinhas(int i)
        {
            if (linhas == 9)
            {
                richTextBox1.AppendText("/////////////////" + Environment.NewLine);
                return 0;
            }
            if (contador == 9)
            {
                richTextBox1.AppendText(Environment.NewLine);
                linhas++;
                contador = 0;
                for (int j = 0; j < 9; j++)
                {
                    numValido[j] = 0;
                }
                return criarLinhas(i = 0);
            }
            else
            {
                rnd = random.Next(1, 10);
                if (!numValido.Contains(rnd))
                {
                    numValido[contador] = rnd;
                    richTextBox1.AppendText(Convert.ToString(numValido[contador] + "-"));
                    sudoku[linhas, contador] = rnd; //poem o valor na matriz
                    contador++;
                }
                return criarLinhas(i + 1);
            }
        }
        int valorRepetido = 0; int proxCol = 0; int coluna = 0;
        private int alterar(int linha)
        {
            if (coluna == 9)
            {
                return 0;
            }
            if (linha == 9)
            {
                proxCol++;
                contador++;
                valorRepetido = 0;
                for (int i = 0; i < 9; i++)
                {
                    numValido[i] = 0;
                }
                return alterar(linha = 0);
            }
            if (proxCol == 9)
            {

                coluna++;
                proxCol = 0;
                proxCol = coluna + 1;
                valorRepetido = 0;
                contador = 0;
                contador2++;
                if (coluna == 9)
                {
                    proxCol = 0;
                }
                for (int i = 0; i < 9; i++)
                {
                    numValido[i] = 0;
                }
                return alterar(linha = 0);
            }
            if (linha <= 9 & coluna <= 9)
            {
                if (!numValido.Contains(sudoku[linha, coluna]))
                {
                    numValido[linha] = sudoku[linha, coluna];
                }
                else
                {
                    valorRepetido = sudoku[linha, coluna];
                    sudoku[linha, coluna] = sudoku[linha, proxCol];
                    sudoku[linha, proxCol] = valorRepetido;
                }

                return alterar(linha + 1);
            }
            else
            {
                return alterar(linha);
            }
        }
        int valorRepetido_1 = 0; int proxCol_1 = 0; int coluna_1 = 0;
        private int alterarColReverso(int linha)
        {
            if (coluna_1 == 8)
            {
                return 0;
            }
            if (linha == -1)
            {
                proxCol_1++;
                contador++;
                valorRepetido_1 = 0;
                for (int i = 0; i < 9; i++)
                {
                    numValido[i] = 0;
                }
                linha = 8;
            }
            if (proxCol_1 == 9)
            {
                coluna_1++;
                proxCol_1 = 0;
                proxCol_1 = coluna_1 + 1;
                valorRepetido_1 = 0;
                contador = 0;
                contador2++;
                if (coluna_1 == 9)
                {
                    proxCol_1 = 0;
                }
                for (int i = 0; i < 9; i++)
                {
                    numValido[i] = 0;
                }
                linha = 8;
            }
            if (linha <= 9)
            {
                if (!numValido.Contains(sudoku[linha, coluna_1]))
                {
                    numValido[linha] = sudoku[linha, coluna_1];
                }
                else
                {
                    valorRepetido_1 = sudoku[linha, coluna_1];
                    sudoku[linha, coluna_1] = sudoku[linha, proxCol_1];
                    sudoku[linha, proxCol_1] = valorRepetido_1;
                }
                return alterarColReverso(linha - 1);
            }
            else
            {
                return alterarColReverso(linha);
            }
        }



        private int alterar_DIR_ESQ(int linha)
        {
            if (coluna == 0)
            {
                return 0;
            }
            if (linha == 9)
            {
                proxCol--;
                contador--;
                valorRepetido = 0;
                for (int i = 0; i < 9; i++) //zera as posicoes do array
                {
                    numValido[i] = 0;
                }
                linha = 0;
            }
            if (proxCol == 0)
            {
                coluna--;
                proxCol = 0;
                proxCol = coluna - 1;
                valorRepetido = 0;
                contador = 0;
                contador2--;
                if (coluna == 0)
                {
                    proxCol = 0;
                }
                for (int i = 0; i < 9; i++) //zera as posições do array
                {
                    numValido[i] = 0;
                }
                linha = 0;
            }
            if (linha <= 9 & coluna <= 9)
            {

                if (!numValido.Contains(sudoku[linha, coluna])) //verifica se o valor é repetido ou não
                {
                    numValido[linha] = sudoku[linha, coluna];
                }
                else //faz a troca do valor repetido com a proxima coluna 
                {
                    valorRepetido = sudoku[linha, coluna]; // guarda o valor repetido para ser colocado na proxima coluna
                    sudoku[linha, coluna] = sudoku[linha, proxCol]; // pega o valor repetido e coloca na proxima coluna 
                    sudoku[linha, proxCol] = valorRepetido; //coloca na proxima coluna o da coluna anterior 
                }
                return alterar_DIR_ESQ(linha + 1);
            }
            else
            {
                return alterar_DIR_ESQ(linha);
            }
        }

        private int alterar_DIR_ESQ_REVERSO(int linha)
        {

            if (coluna == 0)
            {
                return 0;
            }
            if (linha == -1)
            {
                proxCol--;
                contador--;
                valorRepetido = 0;
                for (int i = 0; i < 9; i++) //zera as posicoes do array
                {
                    numValido[i] = 0;
                }
                linha = 8;
            }
            if (proxCol == 0)
            {

                coluna--;
                proxCol = 0;
                proxCol = coluna - 1;
                valorRepetido = 0;
                contador = 0;
                contador2--;
                if (coluna == 0)  //se a coluna atual for a ultima a proxima seja a ultima também
                {
                    proxCol = 0;
                }
                for (int i = 0; i < 9; i++) //zera as posições do array
                {
                    numValido[i] = 0;
                }
                linha = 8;
            }
            if (linha <= 9 & coluna <= 9)
            {
                if (!numValido.Contains(sudoku[linha, coluna])) //verifica se o valor é repetido ou não
                {
                    numValido[linha] = sudoku[linha, coluna];
                }
                else //faz a troca do valor repetido com a proxima coluna 
                {
                    valorRepetido = sudoku[linha, coluna]; // guarda o valor repetido para ser colocado na proxima coluna
                    sudoku[linha, coluna] = sudoku[linha, proxCol]; // pega o valor repetido e coloca na proxima coluna    
                    sudoku[linha, proxCol] = valorRepetido; //coloca na proxima coluna o da coluna anterior 

                }
                return alterar_DIR_ESQ_REVERSO(linha - 1);
            }
            else
            {
                return alterar_DIR_ESQ_REVERSO(linha);
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            criarLinhas(0);
            mostraSudoku();
            richTextBox1.AppendText("--------------------------" + Environment.NewLine);
        }
        int numeros_ok = 0; int col = 0; int vezesQpassou = 0;
        private void button2_Click(object sender, EventArgs e)
        {
            verificar_Numeros(0);

            int verificar_Numeros(int i)
            {
                for (int j = 0; j < 9; j++)
                {
                    numValido[j] = 0;
                }
                if (vezesQpassou == 100 || col == 9)
                {
                    return 0;
                }
                if (!numValido.Contains(sudoku[i, col])) //verifica se o valor é repetido ou não
                {
                    numValido[i] = sudoku[i, col];
                    numeros_ok++;
                }
                if (numeros_ok == 9)
                {
                    for (int j = 0; j < 9; j++)
                    {
                        numValido[j] = 0;
                    }
                    numeros_ok = 0;
                    vezesQpassou = 0;
                    col++;
                    return verificar_Numeros(i = 0);
                }
                else
                {
                    vezesQpassou++;
                    valorRepetido = 0; proxCol = 0; coluna = 0; contador = 0; contador2 = 0;
                    alterar(0);
                    valorRepetido = 0; proxCol = 8; coluna = 8; contador = 0; contador2 = 0;
                    alterar_DIR_ESQ(0);
                    valorRepetido_1 = 0; proxCol_1 = 0; coluna_1 = 0; contador = 0; contador2 = 0;
                    alterarColReverso(8);
                    valorRepetido = 0; proxCol = 8; coluna = 8; contador = 0; contador2 = 0;
                    alterar_DIR_ESQ_REVERSO(8);
                    return verificar_Numeros(i + 1);
                }
            }
            mostraSudoku();
        }
    }
}
