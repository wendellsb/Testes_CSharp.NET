using Alura.Estacionamento.Alura.Estacionamento.Modelos;
using Alura.Estacionamento.Modelos;
using System;
using Xunit;
using Xunit.Abstractions;

namespace Alura.Estacionamento.Testes
{
    public class PatioTeste : IDisposable
    {
        private Veiculo veiculo;
        public ITestOutputHelper SaidaConsoleTeste;
        public PatioTeste(ITestOutputHelper _saidaConsoleTeste)
        {
            SaidaConsoleTeste = _saidaConsoleTeste;
            SaidaConsoleTeste.WriteLine("Construtor invocado.");
            veiculo = new Veiculo();
        }

        //O [Fact] declara um método de teste que é executado.
        [Fact]
        public void ValidaFaturamentoDoEscionamentoComVeiculo() // testando o metodo TotalFaturado()
        {
            // Arrange
            var estacionamento = new Patio();
            //var veiculo = new Veiculo();
            veiculo.Proprietario = "André Silva";
            veiculo.Tipo = TipoVeiculo.Automovel;
            veiculo.Cor = "Verde";
            veiculo.Modelo = "Fusca";
            veiculo.Placa = "asd-9999";

            estacionamento.RegistrarEntradaVeiculo(veiculo);
            estacionamento.RegistrarSaidaVeiculo(veiculo.Placa);

            // Act
            double faturamento = estacionamento.TotalFaturado();

            //Assert
            Assert.Equal(2, faturamento);
        }
        //O[Theory] representa um pacote de testes que executa o mesmo código, mas têm diferentes argumentos de entrada.
        //O atributo[InlineData] especifica valores para essas entradas. Passando com parametros para serem feitos os testes.
        [Theory]
        [InlineData("André Silva", "ASD-1498", "Preto", "Gol")]
        [InlineData("José Silva", "POL-9242", "Cinza", "Fusca")]
        [InlineData("Maria Silva", "GDR-6524", "Azul", "Opala")]
        [InlineData("Pedro Silva", "GDR-1210", "Azul", "Corsa")]
        public void ValidaFaturamentoDoEstacionamentoComVariosVeiculos(string proprietario,
                                                       string placa,
                                                       string cor,
                                                       string modelo)
        {
            // Arrange
            var estacionamento = new Patio();
            //var veiculo = new Veiculo();
            veiculo.Proprietario = proprietario;
            veiculo.Placa = placa;
            veiculo.Cor = cor;
            veiculo.Modelo = modelo;

            estacionamento.RegistrarEntradaVeiculo(veiculo);
            estacionamento.RegistrarSaidaVeiculo(veiculo.Placa);
            //Act
            double faturamento = estacionamento.TotalFaturado();

            //Assert
            Assert.Equal(2, faturamento);
        }

        [Theory]
        [InlineData("André Silva", "ASD-1498", "Preto", "Gol")]
        public void LocalizaVeiculoNoPatioComBaseNaIdTicket(string proprietario,
                                                       string placa,
                                                       string cor,
                                                       string modelo)
        {
            // Arrange
            var estacionamento = new Patio();
            //var veiculo = new Veiculo();
            veiculo.Proprietario = proprietario;
            veiculo.Placa = placa;
            veiculo.Cor = cor;
            veiculo.Modelo = modelo;
            estacionamento.RegistrarEntradaVeiculo(veiculo);

            // Act
            var consultado = estacionamento.PesquisaVeiculo(veiculo.IdTicket);

            //Assert
            Assert.Contains("### Ticket Estacionamento Alura ###", consultado.Ticket);
        }

        // Alterando dados
        [Fact]
        public void AlterarDadosDoProprioVeiculo()
        {
            // Arrange
            var estacionamento = new Patio();
            //var veiculo = new Veiculo();
            veiculo.Proprietario = "José Silva";
            veiculo.Placa = "ZXC-8524";
            veiculo.Cor = "Verde";
            veiculo.Modelo = "Opala";
            estacionamento.RegistrarEntradaVeiculo(veiculo);

            var veiculoAlterado = new Veiculo();
            veiculoAlterado.Proprietario = "José Silva";
            veiculoAlterado.Placa = "ZXC-8524";
            veiculoAlterado.Cor = "Preto"; // Alterado
            veiculoAlterado.Modelo = "Opala";

            // Act
            Veiculo alterado = estacionamento.AlterarDadosVeiculo(veiculoAlterado);

            //Assert
            Assert.Equal(alterado.Cor, veiculoAlterado.Cor);
        }

        public void Dispose()
        {
            SaidaConsoleTeste.WriteLine("Dispose invocado.");
        }
    }
}
