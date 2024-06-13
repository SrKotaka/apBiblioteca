﻿using System;

namespace DTO
{
    public class Livro
    {
        const int tamanhoCodigo = 10;
        const int tamanhoTitulo = 50;
        const int tamanhoAutor = 50;
        
        int idLivro;
        string codigoLivro;
        string tituloLivro;
        string autorLivro;

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
        public string CodigoLivro
        {
            get => codigoLivro;
            set
            {
                if (value.Length > tamanhoCodigo)
                    // remove qualquer caracter além do tamanho máximo do campo
                    value = value.Remove(tamanhoCodigo);
                // preenche codigo com zeros à esquerda até completar o tamanho mãximo 
                value = value.PadRight(tamanhoCodigo, '0');
                // armazena o valor passado no atributo de destino
                codigoLivro = value;
            }
        }
        public string TituloLivro
        {
            get => tituloLivro;
            set
            {
                if (value.Length > tamanhoTitulo)
                    // remove qualquer caracter além do tamanho máximo do campo
                    value = value.Remove(tamanhoTitulo);
                // preenche título com espaços à direita até completar o tamanho mãximo
                value = value.PadRight(tamanhoTitulo, ' ');
                // armazena o valor passado no atributo de destino
                tituloLivro = value;
            }
        }
        public string AutorLivro
        {
            get { return autorLivro; }

            set
            {
                if (value.Length > tamanhoAutor)
                    // remove qualquer caracter além do tamanho máximo do campo
                    value = value.Remove(tamanhoAutor);
                // preenche título com espaços à direita até completar o tamanho mãximo
                value = value.PadRight(tamanhoAutor, ' ');
                // armazena o valor passado no atributo de destino
                autorLivro = value;
            }
        }
        public Livro(int id, string codigo, string titulo, string autor)
        {
            IdLivro = id;
            CodigoLivro = codigo;
            TituloLivro = titulo;
            AutorLivro = autor;
        }
    }
}