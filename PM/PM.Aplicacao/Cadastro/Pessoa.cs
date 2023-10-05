using PM.Domain.Dto;
using PM.Infra.Common.Extensions;
using PM.Infra.Dao;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Transactions;

namespace PM.Aplicacao.Cadastro
{
    public class Pessoa : Domain.Entities.Pessoa, IPessoa
    {
        private readonly IPessoaDao dao;

        public Pessoa()
        {
            if(dao == null)
                this.dao = new PessoaDao();
        }

        public Pessoa(IPessoaDao _dao)
        {
                this.dao = _dao;
        }

        /// <summary>
        /// Retorna uma lista de Pessoas baseado no filtro informado.
        /// </summary>
        /// <param name="filtro"></param>
        /// <returns></returns>
        public List<Pessoa> Listar(PessoaFiltroDto filtro)
        {
            try
            {
                var ds = dao.Listar(filtro);
                return ds.Tables[0].ToList<Pessoa>();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Retorna uma Pessoa baseado no Id informado.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Pessoa Consultar(long id)
        {
            try
            {
                var ds = dao.Consultar(id);
                Pessoa pessoa = ds.Tables[0].ToList<Pessoa>().FirstOrDefault();
                return pessoa;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Exclui um registro de Pessoa da base de dados baseado no Id informado.
        /// Retorna o número de registros afetados na base de dados.
        /// </summary>
        public virtual int Excluir()
        {
            try
            {
                return dao.Excluir(this.Id);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        /// <summary>
        /// Insere uma nova Pessoa na base de dados.
        /// </summary>
        /// <exception cref="Exception"></exception>
        public virtual Pessoa Inserir()
        {
            var erros = this.Validar();
            if (erros.Count > 0)
            {
                var errorMessages = new StringBuilder();
                foreach (var item in erros)
                {
                    errorMessages.AppendLine(item.ErrorMessage.ToString());
                }
                throw new Exception(errorMessages.ToString());
            }
            else
            {
                using (TransactionScope scope = new TransactionScope())
                {
                    try
                    {
                        var ds = dao.Inserir(this);
                        scope.Complete();
                        return ds.Tables[0].ToList<Pessoa>().FirstOrDefault();
                    }
                    catch (Exception ex)
                    {
                        scope.Dispose();
                        throw ex;
                    }
                }
            }
        }

        /// <summary>
        /// Insere uma nova Pessoa na base de dados.
        /// </summary>
        /// <exception cref="Exception"></exception>
        public virtual Pessoa Atualizar()
        {
            var erros = this.Validar();
            if (erros.Count > 0)
            {
                var errorMessages = new StringBuilder();
                foreach (var item in erros)
                {
                    errorMessages.AppendLine(item.ErrorMessage.ToString());
                }
                throw new Exception(errorMessages.ToString());
            }
            else
            {
                using (TransactionScope scope = new TransactionScope())
                {
                    try
                    {
                        var ds = dao.Alterar(this);
                        scope.Complete();
                        return ds.Tables[0].ToList<Pessoa>().FirstOrDefault();
                    }
                    catch (Exception ex)
                    {
                        scope.Dispose();
                        throw ex;
                    }
                }
            }
        }

        /// <summary>
        /// Insere ou Atualiza uma Pessoa na base de dados.
        /// </summary>
        public virtual void Salvar()
        {
            if (this.Id > 0)
                this.Atualizar();
            else
                this.Inserir();
        }

        public virtual List<ValidationResult> Validar()
        {
            var validationContext = new ValidationContext(this, null, null);
            var results = new List<ValidationResult>();

            bool isValid = Validator.TryValidateObject(this, validationContext, results, true);

            var errorMessages = new StringBuilder();

            return results;
        }
    }
}
