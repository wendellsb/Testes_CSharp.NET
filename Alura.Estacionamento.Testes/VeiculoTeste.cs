using Alura.Estacionamento.Alura.Estacionamento.Modelos;
using Alura.Estacionamento.Modelos;
using System;
using Xunit;
using Xunit.Abstractions;

namespace Alura.Estacionamento.Testes
{
    public class VeiculoTeste : IDisposable
    {
        //[Fact] tem como objetivo ser o atributo de um m�todo para testar um fato �nico.
        //Com o Theory, podemos parametrizar um m�todo de testes para um conjunto de dados.

        //Usamos a anota��o[Fact] para testar �fatos� �nicos, ou seja, um �nico m�todo, e quando n�o temos 
        //    a necessidade de par�metros;
        //Existe vantagem da utiliza��o da anota��o[Theory], passar um conjunto grande de valores para um 
        //    m�todo de teste que ser�o entendidos como uma novo teste;

        // [Fact(DisplayName = "Teste n�1")] - mudando a forma de vizualiza��o no Gerenciador de Testes
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
            // Padr�o AAA
            //Arrange - prepara��o de cen�rio
            //var veiculo = new Veiculo();

            //Act - metodo a ser testado
            veiculo.Acelerar(10);

            //Assert - resultado obtido a partir de valida��es com o resultado esperado de acordo com o metodo
            Assert.Equal(100, veiculo.VelocidadeAtual);
        }

        [Fact]
        public void TestarVeiculoFrearComParametro10()
        {
            // Padr�o AAA
            //Arrange - prepara��o de cen�rio
            //var veiculo = new Veiculo();

            //Act - metodo a ser testado
            veiculo.Frear(10);

            //Assert - resultado obtido a partir de valida��es com o resultado esperado de acordo com o metodo
            Assert.Equal(-150, veiculo.VelocidadeAtual);
        }

        [Fact(Skip = "Teste ainda n�o implementado. Ignorar")] //ignorando um teste
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
            Assert.Contains("Ficha do Ve�culo", dados);
        }

        [Fact]
        public void TestaNomeProprietarioVeiculoComMenosDeTresCaracteres()
        {
            // Arrange
            string nomeProprietario = "Ab";

            // Assert
            // Metodo Throws tem que passar o parametro da exce��o que espera receber 
            Assert.Throws<System.FormatException>(
                // Act
                () => new Veiculo(nomeProprietario));
        }

        [Fact]
        public void TestaMensagemDeExcecaoDoQuartoCaractereDaPlaca()
        {
            // Arrange
            string placa = "ASDF8888";

            // Act
            var mensagem = Assert.Throws<System.FormatException>(
                () => new Veiculo().Placa = placa
                );

            // Assert
            Assert.Equal("O 4� caractere deve ser um h�fen", mensagem.Message);
        }

        public void Dispose()
        {
            SaidaConsoleTeste.WriteLine("Dispose invocado.");
        }
    }
}
