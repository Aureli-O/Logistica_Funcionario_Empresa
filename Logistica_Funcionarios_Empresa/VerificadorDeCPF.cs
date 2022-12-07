using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logistica_Empresa
{
    internal class VerificadorDeCPF
    {
        protected bool flag = false;

        public bool Verificar(string CPF)
        {
            if (string.IsNullOrEmpty(CPF))
            {
                throw new FormatException();
            }
            else
            {
                while (true)
                {
                    int verificar = 0;
                    int verificar2 = 0;
                    int teste1 = 1;
                    int teste2 = 9;
                    int[] cpf_ver = new int[9];
                    int[] cpf_ver2 = new int[10];
                    int[] cpf_completo = new int[11];

                    CPF = CPF.Replace(".", "").Replace("-", "");

                    for (int i = 0; i < cpf_completo.Length; i++)
                    {
                        cpf_completo[i] = Convert.ToInt32(CPF.Substring(i, 1));
                    }

                    for (int i = 0; i < cpf_ver.Length; i++)
                    {
                        cpf_ver[i] = Convert.ToInt32(CPF.Substring(i, 1));
                        verificar += cpf_ver[i] * teste1;
                        teste1++;
                    }

                    verificar %= 11;

                    if (verificar == 10)
                    {
                        verificar = 0;
                    }

                    for (int j = 0; j < cpf_ver2.Length; j++)
                    {
                        cpf_ver2[j] = Convert.ToInt32(CPF.Substring(j, 1));
                        verificar2 += cpf_ver2[j] * teste2;
                        teste2--;
                    }

                    verificar2 %= 11;

                    if (verificar2 == 10)
                    {
                        verificar2 = 0;
                    }

                    int x = 0;


                    for (int i = 0, k = 1; k < cpf_completo.Length; i++, k++)
                    {
                        if (cpf_completo[i] == cpf_completo[k])
                        {
                            x++;
                            if(x == 10)
                            {
                                flag = true;
                                return flag;
                            }
                        }
                        else if (cpf_completo[9] == verificar && cpf_completo[10] == verificar2)
                        {
                            flag = true;
                            return flag;
                        }
                        else
                        {
                            flag = false;
                            throw new CPFInvalidoException("CPF Inválido, digite novamente: ");
                        }
                    }
                }
            }
        }
    }
}