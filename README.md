# projeto-x

📊 PJ Work Tracker

Aplicação para controle de jornada de trabalho para profissionais PJ, permitindo registrar horas trabalhadas por empresa, calcular faturamento mensal, gerar relatórios e gerenciar lembretes de faturamento.

O objetivo do projeto é ajudar profissionais que prestam serviços para uma ou mais empresas a organizar:

horas trabalhadas

valor a faturar

relatórios mensais

lembretes de emissão de nota fiscal

🧱 Arquitetura

O sistema é dividido em Frontend + Backend, seguindo boas práticas modernas.

Frontend

Angular

Ionic

SPA (Single Page Application)

Estrutura focada em:

performance

reutilização de componentes

arquitetura modular

Backend

Tecnologias:

.NET 10

CQRS

MediatR

Entity Framework Core

Padrões utilizados:

Clean Architecture

Repository Pattern

Separation of Concerns

Banco de Dados

ORM:

Entity Framework Core

Tabelas principais:

Users

Companies

WorkSessions

Reminders

Geração de PDF

Para geração de relatórios será utilizado:

jsPDF através de um serviço gerador de PDF

📦 Roadmap de desenvolvimento

O projeto está dividido em Épicos e Cards, permitindo desenvolvimento incremental.

📦 ÉPICO 1 — Estrutura inicial do projeto
Card 1 — Criar repositório e estrutura do projeto
Descrição

Criar estrutura inicial do projeto e configurar repositório.

Tasks

Criar repositório Git

Criar projeto backend

Criar projeto frontend

Configurar README

Responsável sugerido: Dev 1

Card 2 — Configurar banco de dados
Descrição

Criar estrutura inicial do banco de dados.

Tasks

Criar banco

Criar migrations

Configurar ORM (EF Core)

Criar tabelas iniciais

Tabelas:

Users

Companies

WorkSessions

Reminders

Responsável: Dev 1

🏢 ÉPICO 2 — Cadastro de empresas
Card 3 — Modelagem de empresa
Descrição

Criar entidade empresa.

Campos

Id

Nome

TipoCobranca (Hora / Mensal)

ValorHora

ValorMensal

Tasks

Criar model

Criar migration

Criar repository

Responsável: Dev 1

Card 4 — API de empresas
Descrição

Criar endpoints CRUD para empresas.

Endpoints
POST /companies
GET /companies
GET /companies/{id}
PUT /companies
DELETE /companies

Responsável: Dev 1

Card 5 — Tela cadastro de empresa
Descrição

Criar interface para cadastro de empresas.

Campos

Nome

Tipo cobrança

Valor

Tasks

Criar formulário

Implementar validação

Integrar com API

Responsável: Dev 2

⏱️ ÉPICO 3 — Controle de jornada
Card 6 — Modelagem de jornada
Descrição

Criar entidade para registrar sessões de trabalho.

Campos

Id

CompanyId

Data

HoraInicio

HoraFim

TotalHoras

Responsável: Dev 1

Card 7 — API controle de jornada
Endpoints
POST /work/start
POST /work/finish
GET /work/today
GET /work/month
Regras

Não permitir duas sessões abertas

Calcular horas automaticamente

Responsável: Dev 1

Card 8 — Tela controle de jornada
Interface

Empresa: XPTO

Botões:

Iniciar trabalho
Finalizar trabalho

Exibir:

Hora início

Hora fim

Total de horas

Responsável: Dev 2

📊 ÉPICO 4 — Dashboard mensal
Card 9 — Endpoint dashboard mensal

Endpoint:

GET /dashboard/month
Retornar

empresas

horas trabalhadas

valor faturado

Exemplo
XPTO
160h
R$ 19.200

Responsável: Dev 1

Card 10 — Tela dashboard
Exibir
Abril 2026

XPTO Tecnologia
160h
R$ 19.200

Startup ABC
20h
R$ 2.400

Total: R$ 21.600

Responsável: Dev 2

📄 ÉPICO 5 — Relatório PDF
Card 11 — Gerar relatório mensal

Endpoint:

GET /reports/month

Gerar PDF contendo:

Empresa: XPTO
Período: Abril 2026

01/04 — 8h
02/04 — 9h
03/04 — 7h

Bibliotecas possíveis:

iText

QuestPDF

Responsável: Dev 3

Card 12 — Botão gerar relatório

Adicionar botão no dashboard:

[ Gerar relatório ]

Função:

gerar PDF

baixar relatório

Responsável: Dev 2

🔔 ÉPICO 6 — Lembrete de faturamento
Card 13 — Modelagem de lembretes

Tabela:

Reminders

Campos:

Id

CompanyId

DiaLembrete

Valor

Ativo

Responsável: Dev 1

Card 14 — Sistema de lembrete

Criar job diário que:

verifica empresas com lembrete no dia

dispara notificação

Responsável: Dev 3

Card 15 — Tela de lembretes

Permitir:

definir dia do lembrete

visualizar avisos

Exemplo:

⚠️ Emitir nota para XPTO
Valor: R$ 19.200

Responsável: Dev 2

⚙️ ÉPICO 7 — Infraestrutura
Card 16 — Deploy backend

Tasks

Configurar VPS

Deploy API

Configurar banco

Responsável: Dev 3

Card 17 — Deploy frontend

Tasks

Build da aplicação

Deploy

Configurar domínio

Responsável: Dev 3

👨‍💻 Distribuição dos desenvolvedores
Dev 1 — Backend Core

Responsável por:

Banco de dados

API Empresas

API Jornada

Dashboard API

Dev 2 — Frontend

Responsável por:

Tela empresas

Tela jornada

Dashboard

Botão relatório

Dev 3 — Infraestrutura e Features Extras

Responsável por:

Geração de PDF

Sistema de lembretes

Deploy

🧩 Modelos de Entidade
Company
public class Company
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string? Document { get; set; } // CNPJ ou CPF
    public string BillingType { get; set; } // Hourly | Monthly
    public decimal Rate { get; set; } // valor hora ou mensal
    public string? Email { get; set; }
    public DateTime CreatedAt { get; set; }
}
WorkSession
public class WorkSession
{
    public Guid Id { get; set; }

    public Guid CompanyId { get; set; }

    public Company Company { get; set; }

    public DateTime StartTime { get; set; }

    public DateTime EndTime { get; set; }

    public decimal TotalHours { get; set; }

    public DateTime CreatedAt { get; set; }
}
