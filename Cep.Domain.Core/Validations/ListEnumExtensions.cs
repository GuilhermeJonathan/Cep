using System;
using System.Collections.Generic;
using System.Linq;


namespace Cep.Domain.Core.Validations
{
    public static class ListEnumExtensions
    {
        public static IEnumerable<SelectDTO> DoEnum<T>(string selecionado) where T : struct
        {
            return DoEnum<T>((T)Enum.Parse(typeof(T), selecionado, true));
        }

        public static IEnumerable<SelectDTO> DoEnum<T>(T? selecionado = null) where T : struct
        {
            if (!typeof(T).IsEnum)
                throw new InvalidOperationException("Não é possível criar uma lista de SelectListItens de um tipo que não é Enum");

            var lista = new List<SelectDTO>();

            var inicializacao = new SelectDTO { Label = "Selecione", Value = string.Empty };

            foreach (var item in Enum.GetValues(typeof(T)))
            {
                var itemSelecionado = item.ToString() == selecionado.ToString();

                lista.Add(new SelectDTO { Label = preecherAtributosDoEnum((Enum)Enum.Parse(typeof(T), item.ToString())), Value = ((int)item).ToString(), Selected = itemSelecionado });
            }

            lista.Insert(0, inicializacao);

            return lista;
        }

        public static IEnumerable<SelectDTO> DoEnumSemOpcaoPadrao<T>(T? selecionado = null) where T : struct
        {
            if (!typeof(T).IsEnum)
                throw new InvalidOperationException("Não é possível criar uma lista de SelectListItens de um tipo que não é Enum");

            var lista = new List<SelectDTO>();
            foreach (var item in Enum.GetValues(typeof(T)))
            {
                var itemSelecionado = item.ToString() == selecionado.ToString();

                lista.Add(new SelectDTO { Label = preecherAtributosDoEnum((Enum)Enum.Parse(typeof(T), item.ToString())), Value = ((int)item).ToString(), Selected = itemSelecionado });
            }
            return lista;
        }

        public static string GetDescripionDoEnum<T>(string nome) where T : struct

        {
            foreach (var item in Enum.GetValues(typeof(T)))
            {
                System.Reflection.FieldInfo fi = item.GetType().GetField(item.ToString());

                System.ComponentModel.DescriptionAttribute[] attributes = (System.ComponentModel.DescriptionAttribute[])fi.GetCustomAttributes(typeof(System.ComponentModel.DescriptionAttribute), false);
                if (attributes.Length > 0 && item.ToString() == nome)
                    return attributes[0].Description;
            }

            return nome;
        }

        public static string preecherAtributosDoEnum(Enum value)

        {
            System.Reflection.FieldInfo fi = value.GetType().GetField(value.ToString());

            System.ComponentModel.DescriptionAttribute[] attributes = (System.ComponentModel.DescriptionAttribute[])fi.GetCustomAttributes(typeof(System.ComponentModel.DescriptionAttribute), false);

            if (attributes.Length > 0)
                return attributes[0].Description;
            else
                return value.ToString();

        }

        public static IEnumerable<SelectDTO> DaClasse<T>(string texto, string valor, Func<IEnumerable<T>> metodoDeBuscaDaLista, int valorSelecionado = 0) where T : class
        {
            var lista = new List<SelectDTO>();
            var listaDeObjetosRetornados = metodoDeBuscaDaLista.Invoke();

            return PreencherSelectList<T>(listaDeObjetosRetornados, texto, valor, valorSelecionado);
        }

        public static IEnumerable<SelectDTO> DaClasseComOpcaoPadrao<T>(string texto, string valor, Func<IEnumerable<T>> metodoDeBuscaDaLista, int valorSelecionado = 0) where T : class
        {
            var lista = new List<SelectDTO> { new SelectDTO { Label = "Selecione", Value = string.Empty } };
            var listaDeObjetosRetornados = metodoDeBuscaDaLista.Invoke();
            lista.AddRange(PreencherSelectList<T>(listaDeObjetosRetornados, texto, valor, valorSelecionado));

            return lista;
        }

        private static IEnumerable<SelectDTO> PreencherSelectList<T>(IEnumerable<T> lista, string texto, string valor, int valorSelecionado) where T : class
        {
            var listaDeRetorno = new List<SelectDTO>();

            if (lista == null || !lista.Any())
                return listaDeRetorno;

            foreach (var item in lista)
            {
                var tipoDoItem = item.GetType();
                var textoDoItem = tipoDoItem.GetProperty(texto);
                var valorDoItem = tipoDoItem.GetProperty(valor);
                var selecionado = valorDoItem?.GetValue(item).ToString() == valorSelecionado.ToString();

                listaDeRetorno.Add(new SelectDTO
                {
                    Label = textoDoItem?.GetValue(item).ToString(),
                    Value = valorDoItem?.GetValue(item).ToString(),
                    Selected = selecionado
                });
            }

            return listaDeRetorno;
        }
    }
}
