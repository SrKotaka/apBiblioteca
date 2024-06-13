using System;

namespace DTO
{
    public class Leitor
    {
        int idLeitor;
        string nomeLeitor,
               telefoneLeitor,
               emailLeitor,
               enderecoLeitor;

        public const int tamanhoNome = 50,
                         tamanhoTelefone = 20,
                         tamanhoEmail = 50,
                         tamanhoEndereco = 100;

        public Leitor(int idLeitor, string nomeLeitor, string telefoneLeitor, string emailLeitor, string enderecoLeitor)
        {
            IdLeitor = idLeitor;
            NomeLeitor = nomeLeitor;
            TelefoneLeitor = telefoneLeitor;
            EmailLeitor = emailLeitor;
            EnderecoLeitor = enderecoLeitor;
        }

        public int IdLeitor
        {
            get => idLeitor;
            set
            {
                if (value < 0)
                    throw new Exception("Id negativo é inválido!");
                idLeitor = value;
            }
        }

        public string NomeLeitor
        {
            get => nomeLeitor;
            set
            {
                if (value.Length > tamanhoNome)
                    value = value.Remove(tamanhoNome);
                        
                value = value.PadRight(tamanhoNome, ' ');
                nomeLeitor = value;
            }
        }

        public string TelefoneLeitor
        {
            get => telefoneLeitor;
            set
            {
                if (value.Length > tamanhoTelefone)
                    value = value.Remove(tamanhoTelefone);
                
                value = value.PadRight(tamanhoTelefone, ' ');
                telefoneLeitor = value;
            }
        }

        public string EmailLeitor
        {
            get => emailLeitor;
            set
            {
                if (value.Length > tamanhoEmail)
                    value = value.Remove(tamanhoEmail);
                
                value = value.PadRight(tamanhoEmail, ' ');
                emailLeitor = value;
            }
        }

        public string EnderecoLeitor
        {
            get => enderecoLeitor;
            set
            {
                if (value.Length > tamanhoEndereco)
                    value = value.Remove(tamanhoEndereco);
                
                value = value.PadRight(tamanhoEndereco, ' ');
                enderecoLeitor = value;
            }
        }
    }
}