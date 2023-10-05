using PM.Domain.Dto;
using PM.Domain.Entities;
using System;
using System.Data;
using System.Data.Common;

namespace PM.Infra.Dao
{
    public class ProjetoDao : BaseDao, IDisposable, IProjetoDao
    {
        public DataSet Listar(ProjetoFiltroDto filtro)
        {
            string proc = "[dbo].[PR_Projeto_Sel]";
            using (DbCommand dbCommand = db.GetStoredProcCommand(proc))
            {
                db.AddInParameter(dbCommand, "@Id", DbType.Int64, filtro.Id);
                db.AddInParameter(dbCommand, "@Nome", DbType.String, filtro.Nome);
                db.AddInParameter(dbCommand, "@Risco", DbType.String, filtro.Risco);
                db.AddInParameter(dbCommand, "@Status", DbType.String, filtro.Status);

                return db.ExecuteDataSet(dbCommand);
            }
        }

        public DataSet Consultar(long id)
        {
            string proc = "[dbo].[PR_Projeto_Sel_Por_Id]";
            using (DbCommand dbCommand = db.GetStoredProcCommand(proc))
            {
                db.AddInParameter(dbCommand, "@Id", DbType.Int64, id);
                return db.ExecuteDataSet(dbCommand);
            }
        }

        public int Excluir(long id)
        {
            string proc = "[dbo].[PR_Projeto_Del]";
            using (DbCommand dbCommand = db.GetStoredProcCommand(proc))
            {
                db.AddInParameter(dbCommand, "@Id", DbType.Int64, id);
                return db.ExecuteNonQuery(dbCommand);
            }
        }

        public DataSet Inserir(Projeto projeto)
        {
            string proc = "[dbo].[PR_Projeto_Ins]";
            using (DbCommand dbCommand = db.GetStoredProcCommand(proc))
            {
                db.AddInParameter(dbCommand, "@Nome", DbType.String, projeto.Nome);
                db.AddInParameter(dbCommand, "@DataInicio", DbType.DateTime, projeto.DataInicio);
                db.AddInParameter(dbCommand, "@DataPrevisaoFim", DbType.DateTime, projeto.DataPrevisaoFim);
                db.AddInParameter(dbCommand, "@DataFim", DbType.DateTime, projeto.DataFim);
                db.AddInParameter(dbCommand, "@Descricao", DbType.String, projeto.Descricao);
                db.AddInParameter(dbCommand, "@Status", DbType.String, projeto.Status);
                db.AddInParameter(dbCommand, "@Orcamento", DbType.Double, projeto.Orcamento);
                db.AddInParameter(dbCommand, "@Risco", DbType.String, projeto.Risco);
                db.AddInParameter(dbCommand, "@IdGerente", DbType.Int64, projeto.IdGerente);

                return db.ExecuteDataSet(dbCommand);
            }
        }

        public int InserirMembro(long idProjeto, long idMembro)
        {
            string proc = "[dbo].[PR_ProjetoMembro_Ins]";
            using (DbCommand dbCommand = db.GetStoredProcCommand(proc))
            {
                db.AddInParameter(dbCommand, "@IdProjeto", DbType.Int64, idProjeto);
                db.AddInParameter(dbCommand, "@IdPessoa", DbType.Int64, idMembro);

                return db.ExecuteNonQuery(dbCommand);
            }
        }

        public DataSet Alterar(Projeto projeto)
        {
            string proc = "[dbo].[PR_Projeto_Upd]";
            using (DbCommand dbCommand = db.GetStoredProcCommand(proc))
            {
                db.AddInParameter(dbCommand, "@Id", DbType.Int64, projeto.Id);
                db.AddInParameter(dbCommand, "@Nome", DbType.String, projeto.Nome);
                db.AddInParameter(dbCommand, "@DataInicio", DbType.DateTime, projeto.DataInicio);
                db.AddInParameter(dbCommand, "@DataPrevisaoFim", DbType.DateTime, projeto.DataPrevisaoFim);
                db.AddInParameter(dbCommand, "@DataFim", DbType.DateTime, projeto.DataFim);
                db.AddInParameter(dbCommand, "@Descricao", DbType.String, projeto.Descricao);
                db.AddInParameter(dbCommand, "@Status", DbType.String, projeto.Status);
                db.AddInParameter(dbCommand, "@Orcamento", DbType.Double, projeto.Orcamento);
                db.AddInParameter(dbCommand, "@Risco", DbType.String, projeto.Risco);
                db.AddInParameter(dbCommand, "@IdGerente", DbType.Int64, projeto.IdGerente);

                return db.ExecuteDataSet(dbCommand);
            }
        }
    }
}
