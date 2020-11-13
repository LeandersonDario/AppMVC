using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AppMVC.Models
{
    public class Produto
    {
        public int Id { get; set; }

        /// <summary>
        /// Data Annotation.: A validação dos dados é uma tarefa essencial em qualquer aplicação e validar 
        /// seus dados pode se tornar um processo trabalhoso dependendo do tipo de aplicação
        /// link.: https://www.codigoexpresso.com.br/Home/Postagem/27
        /// link.: https://docs.microsoft.com/pt-br/ef/ef6/modeling/code-first/data-annotations
        /// </summary>
        [Display(Name = "Descrição")]
        [Required(ErrorMessage = " O campo descrição é obrigatório")]
        public string Descricao { get; set; }
        [Range(1, 100, ErrorMessage = "Quantidade fora da faixa")]
        public int Quantidade { get; set; }
        public int CategoriaId { get; set; }
        [Display(Name = "Categoria")]
        public Categoria Categoria { get; set; }


    }
}

