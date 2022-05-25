using Alura.Estacionamento.Modelos;
using System;
using Xunit;

namespace Alura.Estacionamento.Testes
{
    public class VeiculoTeste
    {
        [Fact]
        public void TestaVeiculoAcelerar()
        {
            // Padr�o AAA
            //Arrange - prepara��o de cen�rio
            var veiculo = new Veiculo();

            //Act - metodo a ser testado
            veiculo.Acelerar(10);

            //Assert - resultado obtido a partir de valida��es com o resultado esperado de acordo com o metodo
            Assert.Equal(100, veiculo.VelocidadeAtual);
        }

        [Fact]
        public void TestarVeiculoFrear()
        {
            // Padr�o AAA
            //Arrange - prepara��o de cen�rio
            var veiculo = new Veiculo();

            //Act - metodo a ser testado
            veiculo.Frear(10);

            //Assert - resultado obtido a partir de valida��es com o resultado esperado de acordo com o metodo
            Assert.Equal(-150, veiculo.VelocidadeAtual);
        }
    }
}
