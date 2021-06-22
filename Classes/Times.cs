using System;

namespace DIO.Times
{
    //Atributos
    public class Time : EntidadeBase
    {
        private Divisao Divisao{ get; set; }

        private string Nome { get; set; }

        private string Estado { get; set; }

        private bool Excluido{ get; set; }
    
  //Métodos

    public Time(int id, Divisao divisao, string nome, string estado)   
    {
        this.Id = id;
        this.Divisao = divisao;
        this.Nome = nome;
        this.Estado = estado;
        this.Excluido = false;
    }

    public override string ToString()
    {
        string retorno = "";
        retorno += "Nome: " + this.Nome + Environment.NewLine;
        retorno += "Divisão: " + this.Divisao + Environment.NewLine;
        retorno += "Estado: ".ToUpper() + this.Estado + Environment.NewLine;
        retorno += "Excluido :" + this.Excluido + Environment.NewLine;
			return retorno;
    }

    public int retornaId(){
        return this.Id;
    }

    public string retornaNome(){
        return this.Nome;
    }

    public string retornaDivisao(){
        return this.Divisao.ToString();
    }

    public bool retornaExcluido(){         
          return this.Excluido;
    }
    public void Excluir(){
        this.Excluido = true;
    }
    }
}
  
    

