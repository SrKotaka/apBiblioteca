using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
  class Leitor
  {
    const int tamanhoNome     =  50,
              tamanhoTelefone =  20,
              tamanhoEmail    =  50,
              tamanhoEndereco = 100;

    int idLeitor;
    string nomeLeitor,
           telefoneLeitor,
           emailLeitor,
           enderecoLeitor;

    public Leitor(int idLeitor, string nomeLeitor, 
      string telefoneLeitor, string emailLeitor, 
      string enderecoLeitor)
    {
      IdLeitor       = idLeitor;
      NomeLeitor     = nomeLeitor;
      TelefoneLeitor = telefoneLeitor;
      EmailLeitor    = emailLeitor;
      EnderecoLeitor = enderecoLeitor;
    }

    public int IdLeitor 
    { 
      get => idLeitor;
      set
      {
        if (value <= 0)
          throw new Exception("Id de livro deve ser maior que 0.");
        idLeitor = value;
      }
    }
    public string NomeLeitor 
    { 
      get => nomeLeitor;
      set 
      { 
        nomeLeitor = value.Remove(tamanhoNome).PadRight(tamanhoNome,' '); 
      }
    }
    public string TelefoneLeitor 
    { 
      get => telefoneLeitor;
      set
      {
        telefoneLeitor = value.Remove(tamanhoTelefone).PadRight(tamanhoTelefone, ' ');
      }
    }
    public string EmailLeitor 
    { 
      get => emailLeitor;
      set
      {
        emailLeitor = value.Remove(tamanhoEmail).PadRight(tamanhoEmail, ' ');
      }
    }
    public string EnderecoLeitor 
    { 
      get => enderecoLeitor;
      set
      {
        enderecoLeitor = value.Remove(tamanhoEndereco).PadRight(tamanhoEndereco, ' ');
      }
    }
  }
}
