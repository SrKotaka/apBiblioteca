﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
  class Livro
  {
    const int tamanhoCodigo = 6;
    const int tamanhoTitulo = 50;
    const int tamanhoAutor = 50;

    int idLivro;
    string codigoLivro;
    string tituloLivro;
    string autorLivro;

    public Livro(int id, string codigo, string titulo, string autor)
    {
      IdLivro = id;
      CodigoLivro = codigo;
      TituloLivro = titulo;
      AutorLivro = autor;
    }

    public int IdLivro
    {
      get => idLivro;
      set
      {
        if (value < 0)
          throw new Exception("Id negativo para livro é inválido!");
        idLivro = value; // armazena o valor passado no atributo de destino
      }
    }
    public string CodigoLivro
    {
      get => codigoLivro;
      set
      {
        // preenche codigo com zeros à esquerda até completar o tamanho máximo
        // remove qualquer caracter além do tamanho máximo do campo
        codigoLivro = value.PadLeft(tamanhoCodigo, '0').Substring(0,tamanhoCodigo);
        }
    }
    public string TituloLivro
    {
      get => tituloLivro;
      set
      {
        // remove qualquer caracter além do tamanho máximo do campo
        // preenche título com espaços à direita até completar o tamanho mãximo
        // armazena o valor passado no atributo de destino
        tituloLivro = value.PadRight(tamanhoTitulo, ' ').Substring(0, tamanhoTitulo); 
 
      }
    }
    public string AutorLivro
    {
      get => autorLivro;
      set
      {
        // remove qualquer caracter além do tamanho máximo do campo
        // preenche título com espaços à direita até completar o tamanho mãximo
        // armazena o valor passado no atributo de destino
        autorLivro = value.PadRight(tamanhoAutor, ' ').Substring(0, tamanhoAutor);
      }
    }
  }
}