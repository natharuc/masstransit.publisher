<p align="center">
    <picture>
        <source media="(prefers-color-scheme: dark)" srcset="https://raw.githubusercontent.com/natharuc/masstransit.publisher/main/assets/logo-dark.svg">
        <source media="(prefers-color-scheme: light)" srcset="https://raw.githubusercontent.com/natharuc/masstransit.publisher/main/assets/logo-light.svg">
        <img alt="Crie eventos com um clique ⭐️✉️" src="https://raw.githubusercontent.com/natharuc/masstransit.publisher/main/assets/logo-light.svg" width="700">
    </picture>
</p>

<div align="center">

[![License](https://img.shields.io/github/license/natharuc/masstransit.publisher?style=for-the-badge)](LICENSE)
[![codecov](https://img.shields.io/codecov/c/github/natharuc/masstransit.publisher?branch=main&style=for-the-badge)](https://codecov.io/github/natharuc/masstransit.publisher?branch=main)
[![GitHub commits since latest release (by date)](https://img.shields.io/github/commits-since/natharuc/masstransit.publisher/latest?label=new+commits&style=for-the-badge)](https://github.com/natharuc/masstransit.publisher/commits/main)
![Size](https://img.shields.io/github/repo-size/natharuc/masstransit.publisher?style=for-the-badge)
[![GitHub contributors](https://img.shields.io/github/contributors/natharuc/masstransit.publisher?style=for-the-badge)](https://github.com/natharuc/masstransit.publisher/contributors)

</div>

## Introdução

O **MassTransit Publisher** é uma ferramenta desktop (Windows Forms) para publicar, enviar e executar eventos de mensageria via [MassTransit](https://masstransit.io/) sem precisar escrever código. É voltada para desenvolvedores e analistas que precisam testar contratos, simular eventos e disparar fluxos de RoutingSlip diretamente do ambiente local.

## Requisitos

- .NET 8 ou superior
- [WebView2 Runtime](https://developer.microsoft.com/en-us/microsoft-edge/webview2/) instalado (para o editor Monaco)
- Acesso ao broker desejado (RabbitMQ, Azure Service Bus, Kafka, Amazon SQS ou ActiveMQ)

## Como executar

```bash
cd src/Masstransit.Publisher.Windows
dotnet run
```

A configuração da última sessão é salva automaticamente em `config.json` na pasta de execução e recarregada ao abrir o aplicativo.

---

## Funcionalidades

### 1. Seleção de broker

Na barra lateral esquerda estão os botões de seleção do broker. Os brokers suportados são:

| Broker | Configuração necessária |
|---|---|
| **RabbitMQ** | Host, Virtual Host, Usuário, Senha |
| **Azure Service Bus** | Connection String |
| **Kafka** | Host, Porta |
| **Amazon SQS** | Host, Usuário, Senha |
| **ActiveMQ** | Host, Usuário, Senha |

Ao selecionar um broker, o painel de configuração correspondente é exibido automaticamente.

---

### 2. Carregamento de contrato (.dll)

Clique em **"Select DLL"** para carregar uma assembly `.dll` que contenha as interfaces ou classes dos contratos de mensagem. Após carregar, os contratos disponíveis aparecem no campo de busca.

- Digite parte do nome do contrato para filtrar
- Contratos genéricos (ex: `IWrapper<T>`) exigem a seleção de um tipo interno adicional

---

### 3. Editor JSON (Monaco Editor)

O corpo da mensagem é editado em um editor Monaco integrado (mesmo engine do VS Code), com syntax highlighting e formatação automática de JSON.

- O JSON é preenchido automaticamente ao usar o **Mock**
- Pode ser editado livremente antes de enviar
- O último JSON utilizado é salvo e recarregado na próxima sessão

---

### 4. Mock automático de JSON

Botão **"Mock"**: gera automaticamente um JSON preenchido com valores fictícios baseados nos tipos da interface/classe do contrato selecionado.

Configurações de mock (acessadas pelo botão **"Mock Settings"**):

| Configuração | Descrição |
|---|---|
| **Min/Max Array Length** | Tamanho mínimo e máximo dos arrays gerados |
| **Custom Properties** | Permite fixar ou regenerar valores específicos de propriedades |

#### Custom Properties

Cada propriedade customizada possui:

- **Name**: nome da propriedade no JSON (case-insensitive)
- **Type**: tipo do valor a gerar (ex: `Guid`, `String`, `Int32`)
- **Value**: valor fixo a ser usado
- **Ignore**: ignora a propriedade no mock
- **Regenerate Before Sending**: gera um novo valor para essa propriedade a cada mensagem enviada (útil para IDs únicos em envios em lote)

---

### 5. Publish

Botão **"Publish (N)"**: publica a mensagem no tópico/exchange do broker usando `PublishBatch` do MassTransit. Não exige fila de destino — o roteamento é feito pelo broker conforme as assinaturas existentes.

---

### 6. Send

Botão **"Send (N)"**: envia a mensagem diretamente para uma fila específica.

A fila de destino é configurada em **"Sender Settings"**:

| Campo | Descrição |
|---|---|
| **Queue** | Nome da fila de destino |
| **Message Count** | Quantidade de mensagens a enviar por clique |

Quando `Message Count > 1` e existe alguma propriedade com **Regenerate Before Sending**, cada mensagem recebe um valor novo para aquela propriedade.

---

### 7. Execute Activity (RoutingSlip)

Botão **"Execute Activity (N)"**: executa um fluxo de RoutingSlip do MassTransit. Usado para disparar workflows compostos por múltiplas activities em sequência.

Configurado pelo botão **"Activity Settings"**:

| Campo | Descrição |
|---|---|
| **Tracking Number Property** | Nome da propriedade no JSON que contém o GUID de rastreamento do RoutingSlip (buscada na raiz do JSON) |
| **Success Queue** | Fila que recebe a notificação de conclusão bem-sucedida |
| **Fault Queue** | Fila que recebe a notificação em caso de falha |
| **Listen to Fault Queue** | Se habilitado, a ferramenta escuta a fila de fault e exibe erros no log |
| **Activities** | Lista ordenada de activities (nome + fila de execução) |
| **Success Contract** | Contrato customizado para a mensagem de sucesso (opcional; padrão: `ActivityCompleted`) |
| **Fault Contract** | Contrato customizado para a mensagem de falha (opcional; padrão: `ActivityFaulted`) |

> **Importante:** a propriedade de tracking number é buscada primeiro no nível raiz do JSON. Isso evita conflito com campos de mesmo nome em objetos aninhados (ex: um identificador de cobertura que não é um GUID).

---

### 8. Log

A aba **"Log"** exibe em tempo real todas as operações realizadas: publicações, envios, erros e execuções de activities. Cada entrada pode ser clicada para ver os detalhes completos.

---

## Estrutura do projeto

```
src/
├── Masstransit.Publisher.Domain/       # Classes de domínio, interfaces e enums
├── Masstransit.Publisher.Services/     # Serviços: publicação, mock, bus factory
├── Masstransit.Publisher.Windows/      # Interface Windows Forms
└── Masstransit.Publisher.Tests/        # Testes unitários (xUnit)
```

## Executar os testes

```bash
cd src
dotnet test Masstransit.Publisher.Tests
```
