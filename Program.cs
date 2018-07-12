using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TESTE_Cálculo
{
    class Program
    {
        /*As expressões Math.Pow abaixo são representações da potênciação na linguagem C#, que são respectivamente:
          Math.Pow(número a ser elevado, grau da potência)*/

        //Função que descreve o padrão de equações polinomiais de segundo grau
         static double PolinomialGrau2(double a,double b,double c,double exp1,double const1,double const2, int exp2 = 1)
        {
            return((const1*(Math.Pow(a,exp1)))+(const2*(Math.Pow(b,exp2)))+c);
        }
        //Função que descreve o padrão de equações polinomiais de terceiro grau
        static double PolinomialGrau3(double a,double b,double c,double d,double const1,double const2,double const3,double exp1,double exp2,int exp3=1)
        {
            return ((const1*(Math.Pow(a,exp1)))+(const2*(Math.Pow(b,exp2)))+(const3*(Math.Pow(c,exp3)))+d);
        }
        //Função que descreve o padrão de equações polinomiais de quarto grau
        static double PolinomialGrau4(double a,double b,double c,double d,double e,double const1,double const2,double const3,double const4,double exp1,double exp2,double exp3,int exp4=1)
        {
            return ((const1*(Math.Pow(a,exp1)))+(const2*(Math.Pow(b,exp2)))+(const3*(Math.Pow(c,exp3)))+(const4*(Math.Pow(d,exp4)))+e);
        }
        //Função que descreve o padrão da derivada de uma equação do segundo grau
        static double DerivadaFunçãoPolinomialGrau2(double a,double b, double exp1,double const1,double const2, int exp2 = 1)
        {

            return(exp1 * (const1 *( Math.Pow(a, (exp1 - 1))))) + (exp2 * (const2 * (Math.Pow(b, (exp2-1)))));
        }
        //Função que descreve o padrão da derivada de uma equação do terceiro grau
        static double DerivadaFunçãoPolinomialGrau3(double a,double b,double c,double const1,double const2,double const3,double exp1,double exp2,int exp3=1)
        {
            return ((exp1*(const1*(Math.Pow(a,(exp1-1)))))+(exp2*(const2*(Math.Pow(b,(exp2-1)))))+(exp3*(const3*(Math.Pow(c,(exp3-1))))));
        }
        //Função que descreve o padrão da derivada de uma equação do quarto grau
        static double DerivadaFunçãoPolinomialGrau4(double a,double b,double c,double d,double const1,double const2,double const3,double const4,double exp1,double exp2,double exp3,double exp4=1)
        {
            return ((exp1*(const1*(Math.Pow(a,(exp1-1)))))+(exp2*(const2*Math.Pow(b,(exp2-1))))+(exp3*(const3*(Math.Pow(c,exp3-1))))+(exp4*(const4*(Math.Pow(d,(exp4-1))))));
        }

        static void Main()
        {     
            //Variáveis para a realização dos cálculos
            double E; //épsilon
            int Kmax; //Número máximo de iterações
            int K=0; //Contador de iterações
            double Xo; //X inicial
            double erro; //Variável do Erro
            double xAtual;
            double const1,const2,const3,const4; //Constantes das funções polinomiais e derivadas  
            double exp1,exp2,exp3;   //Expoentes das funções polinomias e derivadas
            double polinomial; //Variável a receber o padrão da equação polinomial
            double derivada;   //Variável a receber o padrão da derivada
            double c,d,e;    //Constantes C,D e E de equações polinomiais

            //Instruções do programa
            Console.WriteLine("\tMétodo de Newton-Raphson\n");
            Console.WriteLine("________________________________________________________________________________________________________________");
            Console.WriteLine("\tInstruções:");
            Console.WriteLine("\nGraus de polinômios válidos e seus respectivos padrões:\n2º f(x)=a*x^2+b*x+c\n3º f(x)=a*x^3+b*x^2+c*x+d\n4º f(x)=a*x^4+b*x^3+c*x^2+d*x+e\n");
            Console.WriteLine("Dicas:\n- Ao invés de informar um número fracionário, informe decimais !\n" +
                "\n-Caso algum dos números de sua equação não se apresentem em sua equação,informe o valor da constante relacionada como zero\n" +
                "\nExemplo: X^3-9*X+3 \n(No caso, a segunda raiz seria algum número ao quadrado como este (de acordo com o padrão da equação de terceiro grau) : 2*X^2, que no caso não existe, então a constante multiplicada é ZERO!!" +
                "\nEntão a equação de terceiro grau no programa será formada da seguinte maneira:X^3+ 0*X^n -9*X+3\n");
            Console.WriteLine("-A equação será formada passo a passo, portanto, fique tranquilo, o programa irá receber os valores separadamente!\n");
            Console.WriteLine("________________________________________________________________________________________________________________");
            //Inicia o passo a passo
            Console.Write("\nInforme o valor de Épsilon (ε): ");
            E = Double.Parse(Console.ReadLine());
            Console.Write("Insira o número máximo de iterações: ");
            Kmax = Int16.Parse(Console.ReadLine());
            Console.Write("Informe o grau da função: ");
            exp1 = Double.Parse(Console.ReadLine());        
            
            //Irá denominar o padrão de equação polinomial e derivada pelo grau da função
            switch (exp1)
            {
                case 2://Caso seja de segundo grau
                    Console.Write("Informe o valor do chute: ");
                    Xo = Double.Parse(Console.ReadLine());
                    Console.Write("Insira o valor da primeira constante: ");
                    const1 = Double.Parse(Console.ReadLine());
                    Console.Write("Insira o valor da segunda constante: ");
                    const2 = Double.Parse(Console.ReadLine());
                    Console.Write("Insira o valor de C: ");
                    c= Double.Parse(Console.ReadLine());
                    //Denomina como padrão de equação do segundo grau
                    polinomial=PolinomialGrau2(Xo, Xo, c, exp1, const1, const2);
                    derivada=DerivadaFunçãoPolinomialGrau2(Xo, Xo, exp1, const1, const2);

                    xAtual = Xo;
                    erro = (polinomial / derivada);
                    xAtual = xAtual - erro;
                    K++;
                    Console.WriteLine("\n");
                    //Primeira iteração (grau 2)
                    Console.WriteLine("Primeira iteração");
                    Console.WriteLine("Valor da função polinomial no x" + K + " ={0}", polinomial);
                    Console.WriteLine("Valor da derivada da função no x" + K + "={0}", derivada);
                    Console.WriteLine("Valor do X atual={0}", xAtual);
                    Console.WriteLine("Valor do erro = {0}", (polinomial / derivada));
                    Console.WriteLine("Nº de iterações={0}", K);
                    Console.WriteLine("\n");
                    //Inicia o loop
                    do
                    {
                        polinomial = PolinomialGrau2(xAtual, xAtual, c, exp1, const1, const2);
                        derivada = DerivadaFunçãoPolinomialGrau2(xAtual, xAtual, exp1, const1, const2);

                        erro = (polinomial / derivada);
                        xAtual = xAtual - erro;
                        K++;
                        Console.WriteLine("Valor da função polinomial no x" + K + " ={0}", polinomial);
                        Console.WriteLine("Valor da derivada da função no x" + K + "={0}", derivada);
                        Console.WriteLine("Valor do X atual={0}", xAtual);
                        Console.WriteLine("Valor do erro = {0}", (polinomial / derivada));
                        Console.WriteLine("Nº de iterações={0}", K);
                        Console.WriteLine("\n");
                    } while (erro >= E && Kmax > K);//Condição do loop e fim do loop

                    break;
                case 3://Caso seja de terceiro grau
                    Console.Write("Insira o valor do chute: ");
                    Xo = Double.Parse(Console.ReadLine());
                    Console.Write("Insira o valor da primeira constante: ");
                    const1 = Double.Parse(Console.ReadLine());
                    Console.Write("Insira o valor da segunda constante: ");
                    const2 = Double.Parse(Console.ReadLine());
                    Console.Write("Insira o valor da terceira constante: ");
                    const3 = Double.Parse(Console.ReadLine());
                    Console.Write("Insira o valor do expoente da segunda raiz: ");
                    exp2 = Double.Parse(Console.ReadLine());
                    Console.Write("Insira o valor de D: ");
                    d = Double.Parse(Console.ReadLine());
                    //Denomina como padrão de equação do terceiro grau
                    polinomial = PolinomialGrau3(Xo, Xo, Xo, d, const1, const2, const3, exp1, exp2);
                    derivada=DerivadaFunçãoPolinomialGrau3(Xo, Xo, Xo, const1, const2, const3, exp1, exp2);

                    xAtual = Xo;
                    erro = (polinomial / derivada);
                    xAtual = xAtual - erro;
                    K++;
                    Console.WriteLine("\n");
                    //Primeira iteração (grau 3)
                    Console.WriteLine("Primeira iteração");
                    Console.WriteLine("Valor da função polinomial no x" + K + " ={0}", polinomial);
                    Console.WriteLine("Valor da derivada da função no x" + K + "={0}", derivada);
                    Console.WriteLine("Valor do X atual={0}", xAtual);
                    Console.WriteLine("Valor do erro = {0}", (polinomial / derivada));
                    Console.WriteLine("Nº de iterações={0}", K);
                    Console.WriteLine("\n");

                    do
                    {
                        polinomial = PolinomialGrau3(xAtual,xAtual, xAtual, d, const1, const2, const3, exp1, exp2);
                        derivada = DerivadaFunçãoPolinomialGrau3(xAtual,xAtual, xAtual, const1, const2, const3, exp1, exp2);
                        erro = (polinomial / derivada);
                        xAtual = xAtual - erro;
                        K++;
                        Console.WriteLine("Valor da função polinomial no x" + K + " ={0}", polinomial);
                        Console.WriteLine("Valor da derivada da função no x" + K + "={0}", derivada);
                        Console.WriteLine("Valor do X atual={0}", xAtual);
                        Console.WriteLine("Valor do erro = {0}", (polinomial / derivada));
                        Console.WriteLine("Nº de iterações={0}", K);
                        Console.WriteLine("\n");
                    } while (erro >= E && Kmax > K);

                    break;
                case 4://Caso seja de quarto grau
                    Console.Write("Insira o valor do chute: ");
                    Xo = Double.Parse(Console.ReadLine());
                    Console.WriteLine("Insira o valor da primeira constante: ");
                    const1 = Double.Parse(Console.ReadLine());
                    Console.Write("Insira o valor da segunda constante: ");
                    const2 = Double.Parse(Console.ReadLine());
                    Console.Write("Insira o valor da terceira constante: ");
                    const3 = Double.Parse(Console.ReadLine());
                    Console.Write("Insira o valor da quarta constante: ");
                    const4 = Double.Parse(Console.ReadLine());
                    Console.Write("Insira o valor do expoente da segunda raiz: ");
                    exp2 = Double.Parse(Console.ReadLine());
                    Console.Write("Insira o valor do expoente da terceira raiz: ");
                    exp3 = Double.Parse(Console.ReadLine());
                    Console.Write("Insira o valor de E: ");
                    e = Double.Parse(Console.ReadLine());
                    //Denomina como padrão de equação do quarto grau
                    polinomial = PolinomialGrau4(Xo,Xo , Xo, Xo, e, const1, const2, const3, const4, exp1, exp2, exp3);
                    derivada=DerivadaFunçãoPolinomialGrau4(Xo, Xo, Xo, Xo, const1, const2, const3, const4, exp1, exp2, exp3);

                    xAtual = Xo;
                    erro = (polinomial / derivada);
                    xAtual = xAtual - erro;
                    K++;

                    Console.WriteLine("\n");
                    //Primeira iteração (grau 4)
                    Console.WriteLine("Primeira iteração");
                    Console.WriteLine("Valor da função polinomial no x" + K + " ={0}", polinomial);
                    Console.WriteLine("Valor da derivada da função no x" + K + "={0}", derivada);
                    Console.WriteLine("Valor do X atual={0}", xAtual);
                    Console.WriteLine("Valor do erro = {0}", (polinomial / derivada));
                    Console.WriteLine("Nº de iterações={0}", K);
                    Console.WriteLine("\n");

                    do
                    {
                        polinomial = PolinomialGrau4(Xo, Xo, Xo, Xo, e, const1, const2, const3, const4, exp1, exp2, exp3);
                        derivada = DerivadaFunçãoPolinomialGrau4(Xo, Xo, Xo, Xo, const1, const2, const3, const4, exp1, exp2, exp3);
                        erro = (polinomial / derivada);
                        xAtual = xAtual - erro;
                        K++;
                        Console.WriteLine("Valor da função polinomial no x" + K + " ={0}", polinomial);
                        Console.WriteLine("Valor da derivada da função no x" + K + "={0}", derivada);
                        Console.WriteLine("Valor do X atual={0}", xAtual);
                        Console.WriteLine("Valor do erro = {0}", (polinomial / derivada));
                        Console.WriteLine("Nº de iterações={0}", K);
                        Console.WriteLine("\n");
                    } while (erro >= E && Kmax > K);

                    break;
                default://Opção inválida
                    Console.WriteLine("Grau de função inválido !! Insira no máximo até o quarto grau !!");
                    break;
            }            

            Console.WriteLine("Pressione qualquer tecla para sair . . .");
            Console.ReadKey();
        }
    }
}
