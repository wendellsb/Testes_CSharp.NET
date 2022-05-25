using Alura.Estacionamento.Modelos;
using System;
using Xunit;

namespace Alura.Estacionamento.Testes
{
    public class VeiculoTeste
    {
        //[Fact] tem como objetivo ser o atributo de um m�todo para testar um fato �nico.
        //Com o Theory, podemos parametrizar um m�todo de testes para um conjunto de dados.

        //Usamos a anota��o[Fact] para testar �fatos� �nicos, ou seja, um �nico m�todo, e quando n�o temos 
        //    a necessidade de par�metros;
        //Existe vantagem da utiliza��o da anota��o[Theory], passar um conjunto grande de valores para um 
        //    m�todo de teste que ser�o entendidos como uma novo teste;
        [Fact(DisplayName = "Teste n�1")] // mudando a forma de vizualiza��o no Gerenciador de Testes
        [Trait("Funcionalidade", "Acelerar")] // colocando caracteristicas
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

        [Fact(DisplayName = "Teste n�2")]
        [Trait("Funcionalidade", "Frear")]
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

        [Fact(DisplayName = "Teste n�3", Skip = "Teste ainda n�o implementado. Ignorar")] //ignorando um teste
        public void ValidaNomeProprietario()
        {

        }
    }
}
