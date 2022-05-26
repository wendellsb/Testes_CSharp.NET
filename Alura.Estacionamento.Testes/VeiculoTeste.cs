using Alura.Estacionamento.Alura.Estacionamento.Modelos;
using Alura.Estacionamento.Modelos;
using System;
using Xunit;
using Xunit.Abstractions;

namespace Alura.Estacionamento.Testes
{
    public class VeiculoTeste : IDisposable
    {
        //[Fact] tem como objetivo ser o atributo de um método para testar um fato único.
        //Com o Theory, podemos parametrizar um método de testes para um conjunto de dados.

        //Usamos a anotação[Fact] para testar “fatos” únicos, ou seja, um único método, e quando não temos 
        //    a necessidade de parâmetros;
        //Existe vantagem da utilização da anotação[Theory], passar um conjunto grande de valores para um 
        //    método de teste que serão entendidos como uma novo teste;

        // [Fact(DisplayName = "Teste n°1")] - mudando a forma de vizualização no Gerenciador de Testes
        // [Trait("Funcionalidade", "Acelerar")] // colocando caracteristicas

        private Veiculo veiculo;
        public ITestOutputHelper SaidaConsoleTeste;
        public VeiculoTeste(ITestOutputHelper _saidaConsoleTeste)
        {
            SaidaConsoleTeste = _saidaConsoleTeste;
            SaidaConsoleTeste.WriteLine("Construtor invocado.");
            veiculo = new Veiculo();
        }

        [Fact]
        public void TestaVeiculoAcelerarComParametro10()
        {
            // Padrão AAA
            //Arrange - preparação de cenário
            //var veiculo = new Veiculo();

            //Act - metodo a ser testado
            veiculo.Acelerar(10);

            //Assert - resultado obtido a partir de validações com o resultado esperado de acordo com o metodo
            Assert.Equal(100, veiculo.VelocidadeAtual);
        }

        [Fact]
        public void TestarVeiculoFrearComParametro10()
        {
            // Padrão AAA
            //Arrange - preparação de cenário
            //var veiculo = new Veiculo();

            //Act - metodo a ser testado
            veiculo.Frear(10);

            //Assert - resultado obtido a partir de validações com o resultado esperado de acordo com o metodo
            Assert.Equal(-150, veiculo.VelocidadeAtual);
        }

        [Fact(Skip = "Teste ainda não implementado. Ignorar")] //ignorando um teste
        public void ValidaNomeProprietarioDoVeiculo()
        {
            // falta implementar
        }

        [Fact]
        public void FichaDeInformacaoDoVeiculo()
        {
            // Arrange
            //var carro = new Veiculo();
            veiculo.Proprietario = "Carlos Silva";
            veiculo.Tipo = TipoVeiculo.Automovel;
            veiculo.Placa = "ZAP-7419";
            veiculo.Cor = "Verde";
            veiculo.Modelo = "Variante";

            // Act
            string dados = veiculo.ToString();

            // Assert --- Contains - verifica se tem o determinado valor dentro de uma string
            Assert.Contains("Tipo do Veículo", dados);
        }

        public void Dispose()
        {
            SaidaConsoleTeste.WriteLine("Dispose invocado.");
        }
    }
}
