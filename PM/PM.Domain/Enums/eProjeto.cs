using System;

[Serializable]
public class eProjeto
{
    public enum Status
    {
        EmAnalise = 1,
        AnaliseRealizada = 2,
        AnaliseAprovada = 3,
        Iniciado = 4,
        Planejado = 5,
        EmAndamento = 6,
        Encerrado = 7,
        Cancelado = 8
    }
    public enum Risco
    {
        Alto = 1,
        Medio = 2,
        Baixo = 3
    }
}
