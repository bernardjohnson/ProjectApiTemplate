using Template.Business.Notificacoes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Template.Business.Interfaces
{
    public interface INotificador
    {
        bool TemNotificacao();
        List<Notificacao> ObterNotificacoes();
        void AddNotificacao(Notificacao notificacao);
    }
}
