using System;

namespace DTO
{
    public class Emprestimo
    {
        int idEmprestimo;
        int idLivro;
        int idLeitor;
        DateTime dataEmprestimo;
        DateTime dataDevolucaoPrevista;
        DateTime dataDevolucaoReal;

        // aqui, foram criados dois construtores: um com o dataDevolucaoReal e um sem
        // o motivo foi para, caso quiséssemos inserir no banco de dados um registro sem o campo, isso se tornasse possível
        public Emprestimo(int idEmprestimo, int idLivro, int idLeitor, DateTime dataEmprestimo, DateTime dataDevolucaoPrevista, DateTime dataDevolucaoReal)
        {
            this.IdEmprestimo = idEmprestimo;
            this.IdLivro = idLivro;
            this.IdLeitor = idLeitor;
            this.DataEmprestimo = dataEmprestimo;
            this.DataDevolucaoPrevista = dataDevolucaoPrevista;
            this.DataDevolucaoReal = dataDevolucaoReal;
        }

        public Emprestimo(int idEmprestimo, int idLivro, int idLeitor, DateTime dataEmprestimo, DateTime dataDevolucaoPrevista)
        {
            this.IdEmprestimo = idEmprestimo;
            this.IdLivro = idLivro;
            this.IdLeitor = idLeitor;
            this.DataEmprestimo = dataEmprestimo;
            this.DataDevolucaoPrevista = dataDevolucaoPrevista;
        }

        public int IdEmprestimo
        {
            get => idEmprestimo;
            set
            {
                if (value < 0)
                    throw new Exception("Id negativo é inválido!");
                idEmprestimo = value;
            }

        }
        public int IdLivro
        {
            get => idLivro;
            set
            {
                if (value < 0)
                    throw new Exception("Id negativo é inválido!");
                idLivro = value; // armazena o valor passado no atributo de destino
            }
        }
        public int IdLeitor
        {
            get => idLeitor;
            set
            {
                if (value < 0)
                    throw new Exception("Id negativo é inválido!");
                idLeitor = value; // armazena o valor passado no atributo de destino
            }
        }
        public DateTime DataEmprestimo
        {
            get => dataEmprestimo;
            set => dataEmprestimo = value;
        }
        public DateTime DataDevolucaoPrevista
        {
            get => dataDevolucaoPrevista;
            set
            {
                if (value < DataEmprestimo)
                    throw new Exception("A data de devolução prevista deve ser cadastrada, no máximo, 15 dias depois da data do empréstimo");
                dataDevolucaoPrevista = value;
            }
        }
        public DateTime DataDevolucaoReal
        {
            get => dataDevolucaoReal;
            set
            {
                if (value < DataEmprestimo)
                    throw new Exception("A data de devolução real deve ser maior ou igual a data do empréstimo");
                dataDevolucaoReal = value;
            }
        }
    }
}