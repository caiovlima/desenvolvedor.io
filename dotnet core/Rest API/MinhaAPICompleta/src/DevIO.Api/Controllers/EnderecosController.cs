using DevIO.Business.Intefaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevIO.Api.Controllers
{
    public class EnderecosController : MainController
    {
        public EnderecosController(INotificador notificador) : base (notificador)
        {

        }

    }
}
