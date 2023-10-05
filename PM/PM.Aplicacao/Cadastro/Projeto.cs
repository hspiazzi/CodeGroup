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
    public class Projeto : Domain.Entities.Projeto
    {
        public virtual string GerenteNome { get; set; }

        /// <summary>
        /// Retorna uma lista de Projetos baseado no filtro informado.
        /// </summary>
        /// <param name="filtro"></param>
        /// <returns></returns>
        public static List<Projeto> Listar(ProjetoFiltroDto filtro)
        {
            try
            {
                using (ProjetoDao dao = new ProjetoDao())
                {
                    var dsProjeto = dao.Listar(filtro);
                    return dsProjeto.Tables[0].ToList<Projeto>();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Retorna uma Projeto baseado no Id informado.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static Projeto Consultar(long id)
        {
            try
            {
                using (ProjetoDao dao = new ProjetoDao())
                {
                    var ds = dao.Consultar(id);

                    Projeto projeto = ds.Tables[0].ToList<Projeto>().FirstOrDefault();

                    if (projeto != null)
                    {
                        projeto.Membros = ds.Tables[1].ToList<Pessoa>();
                    }

                    return projeto;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Exclui um registro de Projeto da base de dados baseado no Id informado.
        /// Retorna o número de registros afetados na base de dados.
        /// </summary>
        public virtual int Excluir()
        {
            try
            {
                using (ProjetoDao dao = new ProjetoDao())
                {
                    string statusNaoPermitidos = $"iniciado em andamento encerrado";
                    if (!statusNaoPermitidos.Contains(this.Status.ToLower()))
                        return dao.Excluir(this.Id);
                    else
                        throw new Exception("Projetos com Status igual a: Iniciado, Em Andamento ou Encerrados não podem ser excluídos!");
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        /// <summary>
        /// Insere um novo Projeto na base de dados.
        /// </summary>
        /// <exception cref="Exception"></exception>
        public virtual Projeto Inserir()
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
                        using (ProjetoDao dao = new ProjetoDao())
                        {
                            var dsProjeto = dao.Inserir(this);
                            
                            scope.Complete();

                            return dsProjeto.Tables[0].ToList<Projeto>().FirstOrDefault();
                        }
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
        /// Insere um novo membro Pessoa existente ao Projeto existente na base de dados.
        /// </summary>
        /// <exception cref="Exception"></exception>
        public virtual int InserirMembro(long idProjeto, long idMembro)
        {
            using (TransactionScope scope = new TransactionScope())
            {
                try
                {
                    using (ProjetoDao dao = new ProjetoDao())
                    {
                        var rows = dao.InserirMembro(idProjeto, idMembro);

                        scope.Complete();

                        return rows;
                    }
                }
                catch (Exception ex)
                {
                    scope.Dispose();
                    throw ex;
                }
            }
        }

        /// <summary>
        /// Insere um novo Projeto na base de dados.
        /// </summary>
        /// <exception cref="Exception"></exception>
        public virtual Projeto Atualizar()
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
                        using (ProjetoDao dao = new ProjetoDao())
                        {
                            var dsProjeto = dao.Alterar(this);
                            scope.Complete();
                            return dsProjeto.Tables[0].ToList<Projeto>().FirstOrDefault();
                        }
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
        /// Insere ou Atualiza um Projeto na base de dados.
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
