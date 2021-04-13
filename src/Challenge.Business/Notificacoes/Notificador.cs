﻿using Template.Business.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Template.Business.Notificacoes
{
    public class Notificador : INotificador
    {

        private List<Notificacao> _notificacoes;

        public Notificador()
        {
            _notificacoes = new List<Notificacao>();
        }

        public List<Notificacao> ObterNotificacoes()
        {
            return _notificacoes;
        }

        public bool TemNotificacao()
        {
            return _notificacoes.Any();
        }

        public void AddNotificacao(Notificacao notificacao)
        {
            _notificacoes.Add(notificacao);
        }
    }
}
