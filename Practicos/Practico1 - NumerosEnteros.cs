using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practico_1
{
    class Entero
    {
        private int num;
        public Entero()
        {
            num = 0;
        }
        public void Cargar(int numero)
        {
            num = numero;
        }
        public int Descargar()
        {
            return num;
        }





        public int Factorial()//1. Obtener el factorial de un numero entero
        {
            int dato = this.num;
            int resultado = 1; int idx = 1;
            if (dato <= 1)
            {
                return resultado;
            }
            else
            {
                while(idx<= dato)
                {
                    resultado = resultado * idx;
                    idx++;
                }
                return resultado;
            }
            
        }





        public bool Fibonacci()//2. Verificar si un numero entero pertenece a la serie de Fibonacci
        {
            int dato = this.num;
            int n1 = 0; int n2 = 1; int n3 = 0;
            bool bandera;
            while (n3 < dato)
            {
                n3 = n1 + n2;
                n1 = n2;
                n2 = n3;
            }
            if (n3 == dato)
            {
                bandera = true;
            }
            else
            {
                bandera = false;
            }
            return bandera;
        }




    

        public bool Exponencial(int Base)//3. Verificar si un numero entero pertenece a la serie de Exponencial con base 2.
        {
            int dato = this.num;
            int result = 1;
            bool respuesta = false;
            while (result <= dato)
            {
                if (dato == result)
                {
                    respuesta = true;
                }
                result = result * Base;
            }
            return respuesta;
        }





        public bool EsMultiplo(Entero multiplo)//4. Verificar si un numero entero es múltiplo de otro número entero
        {
            bool esmult;
            int residuo;
            residuo = this.num % multiplo.num;
            if (residuo == 0)
            {
                esmult = true;
            }
            else
            {
                esmult = false;
            }
            return esmult;

        }






        public bool EsSubmultiplo(Entero submultiplo)//5. Verificar si un numero entero es sub múltiplo de otro número entero
        {
            bool submult;
            int residuo;
            residuo = submultiplo.num %  this.num;
            if (residuo == 0)
            {
                submult = true;
            }
            else
            {
                submult = false;
            }
            return submult;
        }






        public int Digitos(int numero)// Sacar Digitos de un numero sin libreria .Math
        {
            int cont = 0;
            if(numero == 0)
            {
                cont = 1;
                return cont;
            }
            while (numero != 0)
            {
                numero = numero / 10;
                cont++;

            }
            return cont;
        }






        /*public void Union(Entero num2, ref Entero num3)//6. Unir dos números enteros, al menor el mayor en un tercer objeto. (no une numeros con diferentes numeros de digitos)
        {
            int digito =1;
            num3.num = 0;
            int idx = 1;
            if (this.num <= num2.num)
            {
                while(idx <= Digitos(num))
                {
                    digito = 10 * digito;
                    idx++;
                }
                num3.num = this.num * digito + num2.num;
            }
            else
            {
                while (idx <= num2.Digitos(num2.num))
                {
                    digito = 10 * digito;
                    idx++;
                }
                num3.num = num2.num * digito + this.num;
            }

        }*/



        public void Union(Entero num2, ref Entero num3)//6. Unir dos números enteros, al menor el mayor en un tercer objeto.
        {
            int digito = 1;
            if (this.num < num2.num)
            {
                int aux = num2.num;
                while (aux > 0)
                {
                    digito = digito * 10;
                    aux = aux / 10;
                }
                num3.num = this.num * digito + num2.num;

            }
            else
            {
                int aux = this.num;
                while (aux > 0)
                {
                    digito = digito * 10;
                    aux = aux / 10;
                }
                num3.num = num2.num * digito + this.num;
                

            }
        }








        public void Union2(Entero num2,Entero num3, ref Entero num4)//7. Unir 3 números enteros, el menor, intermedio y el mayor en un cuarto objeto.
        {
            int digito = 1;
            num4.num = 0;
            int idx = 1;
            if((this.num <= num2.num) && (this.num <= num3.num))
            {
                if(num2.num <= num3.num)
                {
                    while (idx <= num2.Digitos(num2.num))
                    {
                        digito = 10 * digito;
                        idx++;
                    }
                    num4.num = this.num * digito + num2.num;
                    while (idx <= num3.Digitos(num3.num))
                    {
                        digito = 10 * digito;
                        idx++;
                    }
                    num4.num = num4.num * digito + num3.num;
                }
                else
                {
                    while (idx <= num3.Digitos(num3.num))
                    {
                        digito = 10 * digito;
                        idx++;
                    }
                    num4.num = this.num * digito + num3.num;
                    while (idx <= num2.Digitos(num2.num))
                    {
                        digito = 10 * digito;
                        idx++;
                    }
                    num4.num = num4.num * digito + num2.num;
                }
            }
            else if ((num2.num <= this.num) && (num2.num <= num3.num))
            {
                if (this.num <= num3.num)
                {
                    while (idx <= Digitos(num))
                    {
                        digito = 10 * digito;
                        idx++;
                    }
                    num4.num = num2.num * digito + this.num;
                    while (idx <= num3.Digitos(num3.num))
                    {
                        digito = 10 * digito;
                        idx++;
                    }
                    num4.num = num4.num * digito + num3.num;
                }
                else
                {
                    while (idx <= num3.Digitos(num3.num))
                    {
                        digito = 10 * digito;
                        idx++;
                    }
                    num4.num = num2.num * digito + num3.num;
                    while (idx <= Digitos(num))
                    {
                        digito = 10 * digito;
                        idx++;
                    }
                    num4.num = num4.num * digito + this.num;

                }

            }
            else if ((num3.num <= this.num) && (num3.num <= num2.num)){
                if(this.num <= num2.num)
                {
                    while (idx <= Digitos(num))
                    {
                        digito = 10 * digito;
                        idx++;
                    }
                    num4.num = num3.num * digito + this.num;
                    while (idx <= num2.Digitos(num2.num))
                    {
                        digito = 10 * digito;
                        idx++;
                    }
                    num4.num = num4.num * digito + num2.num;
                }
                else
                {
                    while (idx <= num2.Digitos(num2.num))
                    {
                        digito = 10 * digito;
                        idx++;
                    }
                    num4.num = num3.num * digito + num2.num;
                    while (idx <= Digitos(num))
                    {
                        digito = 10 * digito;
                        idx++;
                    }
                    num4.num = num4.num * digito + this.num;

                }

            }

        }




        public int Mayor(Entero num2, Entero num3, Entero num4)//8. Encontrar el número de objeto que tiene el número mayor.
        {
            int intMayor = 0;

            if ((this.num >= num2.num) && (this.num >= num3.num) && (this.num >= num4.num))
            {
                intMayor = this.num;
            }
            else if ((num2.num >= this.num) && (num2.num >= num3.num) && (num2.num >= num4.num))
            {
                intMayor = num2.num;
            }
            else if ((num3.num >= this.num) && (num3.num >= num2.num) && (num3.num >= num4.num))
            {
                intMayor = num3.num;
            }
            else if ((num4.num >= this.num) && (num4.num >= num2.num) && (num4.num >= num3.num))
            {
                intMayor = num4.num;
            }
            return intMayor;
        }



        public bool SonIguales()//9. Verificar si los dígitos de un número entero son iguales.
        {
            int dato = this.num;
            bool respuesta = true;
            int digito1, digito2, aux;
            aux = this.num;
            digito1 = dato % 10;
            dato = dato / 10;
            while ((dato > 0) && (respuesta == true))
            {
                digito2 = dato % 10;
                dato = dato / 10;
                if (!(digito2 == digito1))
                {
                    respuesta = false;
                }
            }
            return respuesta;
        }
        public bool SonPares()//10. Verificar si todos los dígitos de un numero enteros son pares.
        {
            bool respuesta = true;
            int digito, dato, aux;
            dato = this.num; aux = this.num;
            digito = dato % 10;
            dato = dato / 10;
            while ((dato > 0) && (respuesta == true))
            {
                if (!((digito % 2) == 0))
                {
                    respuesta = false;
                }
                digito = dato % 10;
                dato = dato / 10;
            }
            return respuesta;

        }


    }
}
