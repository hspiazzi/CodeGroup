using Microsoft.Practices.EnterpriseLibrary.Data;
using PM.Domain.Dto;
using PM.Domain.Entities;
using System;
using System.Data;
using System.Data.Common;

namespace PM.Infra.Dao
{
    public class PessoaDao : BaseDao, IDisposable, IPessoaDao
    {
        public DataSet Listar(PessoaFiltroDto filtro)
        {
            string proc = "[dbo].[PR_Pessoa_Sel]";
            using (DbCommand dbCommand = db.GetStoredProcCommand(proc))
            {
                db.AddInParameter(dbCommand, "@Id", DbType.Int64, filtro.Id);
                db.AddInParameter(dbCommand, "@Nome", DbType.String, filtro.Nome);
                db.AddInParameter(dbCommand, "@CPF", DbType.String, filtro.CPF);
                db.AddInParameter(dbCommand, "@Funcionario", DbType.Boolean, filtro.Funcionario);

                return db.ExecuteDataSet(dbCommand);
            }
        }

        public DataSet Consultar(long id)
        {
            string proc = "[dbo].[PR_Pessoa_Sel_Por_Id]";
            using (DbCommand dbCommand = db.GetStoredProcCommand(proc))
            {
                db.AddInParameter(dbCommand, "@Id", DbType.Int64, id);

                return db.ExecuteDataSet(dbCommand);
            }
        }

        public int Excluir(long id)
        {
            string proc = "[dbo].[PR_Pessoa_Del]";
            using (DbCommand dbCommand = db.GetStoredProcCommand(proc))
            {
                db.AddInParameter(dbCommand, "@Id", DbType.Int64, id);
                return db.ExecuteNonQuery(dbCommand);
            }
        }

        public DataSet Inserir(Pessoa pessoa)
        {
            string proc = "[dbo].[PR_Pessoa_Ins]";
            using (DbCommand dbCommand = db.GetStoredProcCommand(proc))
            {
                db.AddInParameter(dbCommand, "@Nome", DbType.String, pessoa.Nome);
                db.AddInParameter(dbCommand, "@DataNascimento", DbType.DateTime, pessoa.DataNascimento);
                db.AddInParameter(dbCommand, "@CPF", DbType.String, pessoa.CPF);
                db.AddInParameter(dbCommand, "@Funcionario", DbType.Boolean, pessoa.Funcionario);

                return db.ExecuteDataSet(dbCommand);
            }
        }

        public DataSet Alterar(Pessoa pessoa)
        {
            string proc = "[dbo].[PR_Pessoa_Upd]";
            using (DbCommand dbCommand = db.GetStoredProcCommand(proc))
            {
                db.AddInParameter(dbCommand, "@Id", DbType.Int64, pessoa.Id);
                db.AddInParameter(dbCommand, "@Nome", DbType.String, pessoa.Nome);
                db.AddInParameter(dbCommand, "@DataNascimento", DbType.DateTime, pessoa.DataNascimento);
                db.AddInParameter(dbCommand, "@CPF", DbType.String, pessoa.CPF);
                db.AddInParameter(dbCommand, "@Funcionario", DbType.Boolean, pessoa.Funcionario);

                return db.ExecuteDataSet(dbCommand);
            }
        }
    }
}
