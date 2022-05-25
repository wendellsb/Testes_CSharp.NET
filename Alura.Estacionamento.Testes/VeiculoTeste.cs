using Alura.Estacionamento.Modelos;
using System;
using Xunit;

namespace Alura.Estacionamento.Testes
{
    public class VeiculoTeste
    {
        //[Fact] tem como objetivo ser o atributo de um método para testar um fato único.
        //Com o Theory, podemos parametrizar um método de testes para um conjunto de dados.

        //Usamos a anotação[Fact] para testar “fatos” únicos, ou seja, um único método, e quando não temos 
        //    a necessidade de parâmetros;
        //Existe vantagem da utilização da anotação[Theory], passar um conjunto grande de valores para um 
        //    método de teste que serão entendidos como uma novo teste;
        [Fact(DisplayName = "Teste n°1")] // mudando a forma de vizualização no Gerenciador de Testes
        [Trait("Funcionalidade", "Acelerar")] // colocando caracteristicas
        public void TestaVeiculoAcelerar()
        {
            // Padrão AAA
            //Arrange - preparação de cenário
            var veiculo = new Veiculo();

            //Act - metodo a ser testado
            veiculo.Acelerar(10);

            //Assert - resultado obtido a partir de validações com o resultado esperado de acordo com o metodo
            Assert.Equal(100, veiculo.VelocidadeAtual);
        }

        [Fact(DisplayName = "Teste n°2")]
        [Trait("Funcionalidade", "Frear")]
        public void TestarVeiculoFrear()
        {
            // Padrão AAA
            //Arrange - preparação de cenário
            var veiculo = new Veiculo();

            //Act - metodo a ser testado
            veiculo.Frear(10);

            //Assert - resultado obtido a partir de validações com o resultado esperado de acordo com o metodo
            Assert.Equal(-150, veiculo.VelocidadeAtual);
        }

        [Fact(DisplayName = "Teste n°3", Skip = "Teste ainda não implementado. Ignorar")] //ignorando um teste
        public void ValidaNomeProprietario()
        {

        }
    }
}
