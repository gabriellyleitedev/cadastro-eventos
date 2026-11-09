# Cadastro de Eventos

App em .NET MAUI que cadastra um evento e mostra um resumo com a duração e o custo total calculados.

Atividade da Agenda 15 de Programação Mobile I (Etec).

## Funcionalidades

- Cadastro de nome, local, data de início, data de término, número de participantes e custo por participante
- Duração do evento calculada com `DateTime` e exibida com `TimeSpan`
- Custo total = participantes × custo por participante
- Resumo em uma nova página, usando `BindingContext` e `StringFormat`
- Validação dos campos com alertas
- Interface em tema claro, com cards e destaque para o custo total

## Estrutura

- `Models/Evento.cs`: model com as propriedades e os cálculos
- `Views/CadastroEvento.xaml`: tela de cadastro
- `Views/ResumoEvento.xaml`: tela de resumo

## Executar

```bash
dotnet run -f net10.0-windows10.0.19041.0
```
