# Cadastro de Eventos

Aplicativo em **.NET MAUI** para cadastrar um evento e exibir seu resumo, com cálculo automático da duração e do custo total.

Atividade da Agenda 15 de Programação Mobile I (Etec / Centro Paula Souza).

## Funcionalidades

- Cadastro com nome, local, data de início, data de término, número de participantes e custo por participante
- Validação dos campos antes de avançar
- Cálculo da duração do evento com `DateTime` e `TimeSpan`
- Cálculo do custo total (participantes × custo por participante)
- Página de resumo com os dados formatados via `BindingContext` e `StringFormat`

## Estrutura

```
CadastroEventos/
├── Models/
│   └── Evento.cs                # Model com as propriedades e os cálculos
├── Views/
│   ├── CadastroEvento.xaml      # Tela de cadastro
│   ├── CadastroEvento.xaml.cs   # Validação e navegação para o resumo
│   ├── ResumoEvento.xaml        # Tela de resumo com Bindings
│   └── ResumoEvento.xaml.cs
├── App.xaml.cs                  # Define a cultura pt-BR (datas e moeda)
├── AppShell.xaml                # Navegação
└── MauiProgram.cs
```

## Como funciona

### Model `Evento`

```csharp
public TimeSpan Intervalo
{
    get => DataTermino.Date.Subtract(DataInicio.Date);
}

public int DuracaoEmDias
{
    get => Intervalo.Days + 1;
}

public double CustoTotal
{
    get => NumeroParticipantes * CustoPorParticipante;
}
```

- `Intervalo` subtrai duas datas `DateTime` e devolve um `TimeSpan`.
- `DuracaoEmDias` conta o dia de início e o de término. Um evento de 10/11 a 12/11 tem intervalo de 2 dias e duração de 3 dias.
- `CustoTotal` multiplica o número de participantes pelo custo de cada um.

### Envio dos dados para o resumo

Na tela de cadastro, o objeto `Evento` é criado e passado como `BindingContext` da página de resumo:

```csharp
await Navigation.PushAsync(new ResumoEvento()
{
    BindingContext = evento
});
```

### Exibição formatada

```xml
<Label Text="{Binding DataInicio, StringFormat='Início: {0:dddd, dd/MM/yyyy}'}" />
<Label Text="{Binding Intervalo, StringFormat='Intervalo entre as datas (TimeSpan): {0:%d} dia(s)'}" />
<Label Text="{Binding CustoTotal, StringFormat='Custo total: {0:C}'}" />
```

## Como executar

Requisitos: .NET 10 SDK com a carga de trabalho `maui`.

```bash
dotnet restore
dotnet run -f net10.0-windows10.0.19041.0
```

Para Android, é necessário ter o Android SDK instalado (por exemplo, pelo Visual Studio):

```bash
dotnet build -t:Run -f net10.0-android
```
