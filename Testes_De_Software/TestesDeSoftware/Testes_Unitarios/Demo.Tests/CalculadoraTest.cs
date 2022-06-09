using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Demo.Tests
{
    public class CalculadoraTest
    {
        [Fact]
        public void Calculadora_Somar_RetornarValorSoma()
        {
            //Arragen (preparação dos pré requisitos para as funções compilarem)
            var calculadora = new Calculadora();

            //Act (Execução da função a ser testada)
            var resultado = calculadora.Somar(1, 2);

            //Assert (O que se espera de resultado)
            Assert.Equal(3, resultado);
        }
    }
}
